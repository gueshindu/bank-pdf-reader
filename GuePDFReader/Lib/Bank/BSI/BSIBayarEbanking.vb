Public Class BSIBayarEbanking
    Inherits BSITrans
    Public Const TRANS_TYPE = "Pembayaran via e-Banking"

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildMe()
    End Sub

    Private Sub BuildMe()

        bankTrans.TransType = TRANS_TYPE
        If splitLine(splitLine.Length - 3) = "0.00" Then
            BankTrans.DBCR = "CR"
            BankTrans.Mutasi = GueUtils.ParseDouble(splitLine(splitLine.Length - 2))
        Else
            BankTrans.DBCR = "DB"
            BankTrans.Mutasi = GueUtils.ParseDouble(splitLine(splitLine.Length - 3))
        End If
        BankTrans.Reference = splitLine(splitLine.Length - 4)
        BankTrans.IsValid = True
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            BankTrans.Keterangan = line
        End If

        Return True

    End Function
End Class
