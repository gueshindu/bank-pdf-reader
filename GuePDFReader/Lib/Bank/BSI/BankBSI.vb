Imports System.ComponentModel
Imports System.Globalization
Imports iText.Kernel.Geom

Public Class BankBSI
    Implements IGueBank

    Private linesPDFText As String()
    Private errorText As String

    Private bankInfo As BankInfo
    Private periode As Date

    'Private lastIndex As Integer
    Private alreadySaldoAwal As Boolean

    Private daftarTransaksi As List(Of BankTrans)

    Public Sub New()
        Console.WriteLine("Type: Bank BSI")
    End Sub

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
            errorText = "Sepertinya bukan rekening BSI"
            Return False
        End If
        Dim tmp As String

        'Get name
        bankInfo.NamaBank = "BSI"
        bankInfo.NamaRekening = linesPDFText(1)

        'Get period
        tmp = linesPDFText(2).Replace("Periode : ", "")
        Dim tmp2 = tmp.Split(" ")
        Dim tahun = CInt(tmp2(4))
        periode = DateTime.Parse("1 " & tmp2(3) & " " & tahun)

        'Get account name
        tmp = linesPDFText(8)
        If tmp.StartsWith("BSI TABUNGAN EASY MUDHARABAH") Then
            bankInfo.TipeRekening = "BSI TABUNGAN EASY MUDHARABAH"
        ElseIf tmp.StartsWith("BSI TAB HAJI INDONESIA MUDHARABAH") Then
            bankInfo.TipeRekening = "BSI TAB HAJI INDONESIA MUDHARABAH"
        End If
        tmp = tmp.Replace(bankInfo.TipeRekening & " - ", "")
        bankInfo.MataUang = tmp.Substring(0, 3)
        tmp = tmp.Replace(bankInfo.MataUang & " - ", "")
        bankInfo.NomorRekening = tmp.Substring(0, 10)

        For i As Integer = 9 To 25
            tmp = linesPDFText(i).Trim
            If (tmp = "Date & Time Detail Transaksi No Reﬀ Debit Kredit Saldo") Then
                'lastIndex = i
                Exit For
            End If
        Next
        Return True
    End Function

    Private Function ParseBody() As Boolean
        daftarTransaksi = New List(Of BankTrans)
        Dim bsi = New BSILineAnalyzer(linesPDFText, periode)

        For i As Integer = 8 To linesPDFText.Length - 1
            Console.WriteLine(i & ". " & linesPDFText(i))

            If linesPDFText(i).Contains(bankInfo.TipeRekening) And Not alreadySaldoAwal Then
                Dim bsiTrx = New BSISaldoAwal(linesPDFText(i), periode)
                If bsiTrx IsNot Nothing Then
                    daftarTransaksi.Add(bsiTrx.GetBankTrans())
                    alreadySaldoAwal = True
                End If
                i += 1 'Loncati header
            ElseIf linesPDFText(i).Contains("--- AKHIR LAPORAN ---") Then
                'Footer
                Dim line = linesPDFText(i - 3)
                Dim lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
                bankInfo.SaldoAkhir = GueUtils.ParseDouble(lineSplit.Last)
                '
                line = linesPDFText(i - 4)
                lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
                bankInfo.DB = GueUtils.ParseDouble(lineSplit.Last)
                '
                line = linesPDFText(i - 5)
                lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
                bankInfo.CR = GueUtils.ParseDouble(lineSplit.Last)
                '
                line = linesPDFText(i - 6)
                lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
                bankInfo.SaldoAwal = GueUtils.ParseDouble(lineSplit.Last)
                Return True

            Else

                Dim bsiTrx = bsi.AnalyzeLine(i)

                If bsiTrx IsNot Nothing Then
                    daftarTransaksi.Add(bsiTrx.GetBankTrans())
                    i += bsiTrx.GetLastIndex
                End If
            End If
        Next
        Return True
    End Function


End Class
