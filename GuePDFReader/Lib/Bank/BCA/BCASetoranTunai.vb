Public Class BCASetoranTunai
    Inherits BCATrans

    Public Const TRANS_TYPE = "SETORAN TUNAI"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format: 17/01 SETORAN TUNAI 8545 255,450,000.00
        If (bankTrans.DBCR = "CR") Then
            bankTrans.TransType = TRANS_TYPE
            bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(4))
            bankTrans.Keterangan = " CBG: " & splitLine(3)
        End If

    End Sub
End Class
