Imports System.ComponentModel
Imports iText.Kernel.Geom

Public Class BankBCA
    Implements IGueBank

    Private linesPDFText As String()
    Private errorText As String

    Private bankInfo As BankInfo
    Private periode As Date

    Private lastIndex As Integer

    Private daftarTransaksi As List(Of BankTrans)

    Public Sub ShowError()
        MsgBox(errorText, MsgBoxStyle.Exclamation)
    End Sub

    Public Sub SetTextToParse(txt As String) Implements IGueBank.SetTextToParse
        linesPDFText = txt.Split(CType(vbCrLf, Char()), StringSplitOptions.RemoveEmptyEntries)
        bankInfo = New BankInfo()
    End Sub

    Public Function ExecuteParse() As Boolean Implements IGueBank.ExecuteParse
        Dim result = ParseHeader()

        If result Then
            result = ParseBody()
        End If
        Return result
    End Function


    Public Function GetBankInfo() As BankInfo Implements IGueBank.GetBankInfo
        Return bankInfo
    End Function

    Public Function GetBankDocsPeriode() As Date Implements IGueBank.GetBankDocsPeriode
        Return periode
    End Function

    Public Function GetListTransaksi() As List(Of BankTrans) Implements IGueBank.GetListTransaksi
        Return daftarTransaksi
    End Function

    Private Function ParseHeader() As Boolean
        If linesPDFText.Length <= 16 Then
            errorText = "Sepertinya bukan rekening BCA"
            Return False
        End If
        Dim tmp As String

        bankInfo.NamaBank = "BANK BCA"

        For i As Integer = 0 To 25
            tmp = linesPDFText(i).Trim
            If (tmp.StartsWith("REKENING")) Then
                bankInfo.TipeRekening = tmp
            ElseIf (tmp.StartsWith("NO. REKENING")) Then
                bankInfo.NomorRekening = tmp.Replace("NO. REKENING : ", "")
                bankInfo.NamaRekening = linesPDFText(i - 1).Trim
            ElseIf (tmp.StartsWith("PERIODE")) Then
                Dim tmp2 = tmp.Replace("PERIODE : ", "")
                Dim tahun = Strings.Right(tmp2, 4)
                Dim bulan = tmp2.Replace(" " & tahun, "")
                periode = New Date(year:=CInt(tahun), month:=GueUtils.GetBulanIndonesia(bulan), day:=1)
            ElseIf (tmp.StartsWith("MATA UANG")) Then
                bankInfo.MataUang = Strings.Right(tmp, 3)
            ElseIf (tmp = "TANGGAL KETERANGAN CBG MUTASI SALDO") Then
                lastIndex = i
                Exit For
            End If
        Next
        Return True
    End Function

    Private Function ParseBody() As Boolean
        daftarTransaksi = New List(Of BankTrans)
        Dim bca = New BCALineAnalyzer(linesPDFText, periode)

        For i As Integer = lastIndex + 1 To linesPDFText.Length - 1

            If (i > linesPDFText.Length - 6) Then
                Dim line = linesPDFText(i)
                Dim lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)

                'FOOTER
                If line.StartsWith("SALDO AWAL :") Then
                    bankInfo.SaldoAwal = GueUtils.ParseDouble(lineSplit(3))
                ElseIf line.StartsWith("MUTASI CR :") Then
                    bankInfo.CR = GueUtils.ParseDouble(lineSplit(3))
                ElseIf line.StartsWith("MUTASI DB :") Then
                    bankInfo.DB = GueUtils.ParseDouble(lineSplit(3))
                ElseIf line.StartsWith("SALDO AKHIR :") Then
                    bankInfo.SaldoAkhir = GueUtils.ParseDouble(lineSplit(3))
                End If
            Else

                Dim bcaTrans = bca.AnalyzeLine(i)

                If bcaTrans IsNot Nothing Then
                    daftarTransaksi.Add(bcaTrans.GetBankTrans())
                    i += bcaTrans.GetLastIndex
                End If
            End If
        Next
        Return True
    End Function


End Class
