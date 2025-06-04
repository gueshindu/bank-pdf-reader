Public Class BSIAngsuran
    Inherits BSITrans
    Public Const TRANS_TYPE = "Pembayaran Angsuran"
    Public Sub New(saldoAwal As String, periode As Date)
        MyBase.New(saldoAwal, periode)
        bankTrans = New BankTrans With {
            .TransDate = periode,
            .TransType = TRANS_TYPE
        }
        bankTrans.Keterangan = bankTrans.TransType
        bankTrans.DBCR = "DB"

        Dim lineSplit = saldoAwal.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
        bankTrans.Mutasi = GueUtils.ParseDouble(lineSplit(lineSplit.Length - 3))
        bankTrans.IsValid = True
    End Sub
End Class
