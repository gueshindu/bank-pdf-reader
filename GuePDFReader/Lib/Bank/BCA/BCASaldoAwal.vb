Public Class BCASaldoAwal
    Inherits BCATrans
    Public Const TRANS_TYPE = "SALDO AWAL"

    Public Sub New(saldoAwal As String, periode As Date)
        MyBase.New(saldoAwal, periode)
        bankTrans.TransDate = periode
        bankTrans.TransType = "SALDO AWAL"
        bankTrans.DBCR = ""
        bankTrans.Mutasi = 0
        saldoAwal = saldoAwal.Replace(bankTrans.TransDate.ToString("dd/MM ") & bankTrans.TransType & " ", "")
        bankTrans.Saldo = GueUtils.ParseDouble(saldoAwal)
        bankTrans.IsValid = True
    End Sub
End Class
