Public Class BCAPajakBunga
    Inherits BCATrans

    Public Const TRANS_TYPE = "PAJAK BUNGA"
    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format:
        '31/01 PAJAK BUNGA426.34 DB 183,852,726.76

        oneLineTrans = oneLineTrans.Replace(TRANS_TYPE, "")  '31/01 426.34 DB 183,852,726.76
        Dim split2 = oneLineTrans.Split(" ")

        bankTrans.TransType = TRANS_TYPE
        bankTrans.DBCR = "DB"
        bankTrans.Keterangan = TRANS_TYPE
        bankTrans.Reference = ""
        bankTrans.Nama = ""

        bankTrans.Mutasi = GueUtils.ParseDouble(split2(1))
        bankTrans.IsValid = True

    End Sub
End Class
