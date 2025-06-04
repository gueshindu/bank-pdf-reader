Public Class BSIByPindahBukuEbanking
    Inherits BSITrans
    Public Const TRANS_TYPE = "Biaya Pemindahbukuan e-Banking"

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildMe()
    End Sub

    Private Sub BuildMe()

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
