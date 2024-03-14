Public Class BCABunga
    Inherits BCATrans

    Public Const TRANS_TYPE = "BUNGA"
    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format:
        '31/01 BUNGA2,132.14 183,853,153.10

        oneLineTrans = oneLineTrans.Replace(TRANS_TYPE, "")  '31/01 2,132.14 183,853,153.10
        Dim split2 = oneLineTrans.Split(" ")

        bankTrans.TransType = TRANS_TYPE
        bankTrans.DBCR = "CR"
        bankTrans.Keterangan = TRANS_TYPE
        bankTrans.Reference = ""
        bankTrans.Nama = ""

        bankTrans.Mutasi = GueUtils.ParseDouble(split2(1))
        bankTrans.IsValid = True

    End Sub

End Class
