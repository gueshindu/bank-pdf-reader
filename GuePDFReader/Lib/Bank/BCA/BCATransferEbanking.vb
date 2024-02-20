Public Class BCATransferEbanking
    Inherits BCATrans

    Public Const TRANS_TYPE = "TRSF E-BANKING"

    Private tmpKeterangan As String

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildEbankingTrans()
    End Sub

    Private Sub BuildEbankingTrans()
        bankTrans.TransType = TRANS_TYPE
        For i As Integer = lastLineIndex + 1 To splitLine.Length - 1
            Dim tmp = splitLine(i)

            If i = lastLineIndex + 1 Then
                'Referensi, contoh: 3112/FTSCY/WS95051
                bankTrans.Reference = tmp

            ElseIf i = lastLineIndex + 2 Then
                'Mutasi
                bankTrans.Mutasi = GueUtils.ParseDouble(tmp)
                Exit For
            End If
        Next
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            bankTrans.Nama = tmpKeterangan
            bankTrans.Keterangan = bankTrans.Keterangan.Substring(0, bankTrans.Keterangan.Length - tmpKeterangan.Length - 1)
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
        End If
    End Sub

End Class
