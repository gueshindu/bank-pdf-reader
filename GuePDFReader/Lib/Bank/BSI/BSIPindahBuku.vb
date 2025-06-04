
Public Class BSIPindahBuku
    Inherits BSITrans
    Public Const TRANS_TYPE = "Pemindahbukuan"

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildMe()
    End Sub

    Private Sub BuildMe()
        'CONTOH: 
        'KREDIT
        'JAN 2025 Pemindahbukuan FT250169V4NL 142,000.00 0.00 4,429,035.49
        '15:08 615075418033-085648121224-712433

        'DEBIT
        '03 JAN 2025
        '17:16
        'Pemindahbukuan
        'Tarik Tunai BSI - BSI ATM\006032
        'FT2500368LTF 1, 900, 000.00 0.00 11, 727, 925.04

        'SINGLE LINE
        '02 JAN 2025
        '14:54
        'Pemindahbukuan FT25002HW8TS 1, 100, 000.00 0.00 13, 757, 925.04

        bankTrans.TransType = TRANS_TYPE
        If splitLine(splitLine.Length - 3) = "0.00" Then
            bankTrans.DBCR = "CR"
            bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(splitLine.Length - 2))
        Else
            bankTrans.DBCR = "DB"
            bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(splitLine.Length - 3))
        End If
        bankTrans.Reference = splitLine(splitLine.Length - 4)
        bankTrans.IsValid = True
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            bankTrans.Keterangan = line
        End If

        Return True

    End Function
End Class
