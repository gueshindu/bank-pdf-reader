Public Class BCATransferEbanking
    Inherits BCATrans

    Public Const TRANS_TYPE = "TRSF E-BANKING"

    Private tmpKeterangan As String

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        'COntoh:
        '10/01 TRSF E-BANKING CR 10/01 /Z2WF1/00000 1,500,000.000
        '10/01 TRSF E-BANKING CR 1001/FTSCY/WS95031 1,350,000.00 392,166,606.40
        '05/01 TRSF E-BANKING DB 0501/FTSCY/WS95031 2,000,000.00 DB
        BuildEbankingTrans()
    End Sub

    Private Sub BuildEbankingTrans()
        bankTrans.TransType = TRANS_TYPE
        bankTrans.Reference = ""

        For i As Integer = lastLineIndex + 1 To splitLine.Length - 1
            Dim tmp = splitLine(i)

            'Kalau ada . (titik) dan , (koma) dianggap itu adalah rupiah
            If (GueUtils.IsRupiah(tmp)) Then
                bankTrans.Mutasi = GueUtils.ParseDouble(tmp)
                Exit For
            Else
                bankTrans.Reference += tmp
            End If

        Next
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            If (tmpKeterangan Is Nothing) Then
                bankTrans.Nama = bankTrans.Keterangan
                bankTrans.Keterangan = ""
            Else
                bankTrans.Nama = tmpKeterangan
                bankTrans.Keterangan = bankTrans.Keterangan.Substring(0, bankTrans.Keterangan.Length - tmpKeterangan.Length - 1)
            End If

            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            ProsesLine2()
        ElseIf transLineNumber > 2 Then
            'Contoh:    IDA MURYANI SETIOW
            'Contoh 2:  Bukuwarung A
            '           996831
            '           NUSA SATU INTI ART

            tmpKeterangan = line
            bankTrans.Keterangan &= " " & tmpKeterangan
        End If

        Return True

    End Function

    Private Sub ProsesLine2()
        'Contoh: TANGGAL :02/01        8026800.00
        If (splitLine.Length > 1) Then
            bankTrans.Keterangan = String.Join(" ", splitLine, 0, splitLine.Length - 1)
        Else
            bankTrans.Keterangan = splitLine(0)
        End If
    End Sub

End Class
