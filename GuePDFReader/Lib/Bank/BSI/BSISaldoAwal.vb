Public Class BSISaldoAwal
    Inherits BSITrans
    Public Const TRANS_TYPE = "SALDO AWAL"
    Public Sub New(saldoAwal As String, periode As Date)
        MyBase.New(saldoAwal, periode)
        bankTrans = New BankTrans With {
            .TransDate = periode,
            .TransType = TRANS_TYPE
        }
        bankTrans.Keterangan = bankTrans.TransType
        bankTrans.DBCR = "CR"

        Dim lineSplit = saldoAwal.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
        bankTrans.Saldo = GueUtils.ParseDouble(lineSplit.Last)
        bankTrans.Mutasi = bankTrans.Saldo
        bankTrans.IsValid = True
    End Sub
End Class


