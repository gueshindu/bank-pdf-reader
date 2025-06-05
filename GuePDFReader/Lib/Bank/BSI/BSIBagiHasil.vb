Public Class BSIBagiHasil

    Inherits BSITrans
    Public Const TRANS_TYPE = "Bagi Hasil atau Bonus"
    Public Sub New(saldoAwal As String, periode As Date)
        MyBase.New(saldoAwal, periode)
        bankTrans.TransType = TRANS_TYPE

        bankTrans.Keterangan = BankTrans.TransType
        bankTrans.DBCR = "CR"

        Dim lineSplit = saldoAwal.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
        bankTrans.Mutasi = GueUtils.ParseDouble(lineSplit(lineSplit.Length - 2))
        bankTrans.IsValid = True
    End Sub
End Class
