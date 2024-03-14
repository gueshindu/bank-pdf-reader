Public Class BCAKoreksiBunga
    Inherits BCATrans

    Public Const TRANS_TYPE = "DR KOREKSI BUNGA"
    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format:
        '31/01 DR KOREKSI BUNGA0.44 DB

        oneLineTrans = oneLineTrans.Replace(TRANS_TYPE, "")  '31/01 0.44 DB
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
