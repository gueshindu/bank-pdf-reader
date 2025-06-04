Public Class BCASetoranViaCDM
    Inherits BCATrans

    Public Const TRANS_TYPE = "SETORAN VIA CDM"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        bankTrans.TransType = TRANS_TYPE
        bankTrans.Keterangan = bankTrans.TransType
        bankTrans.DBCR = "CR"
        Dim mutasi = splitLine(6)  '==> 31/122,500,000.00

        If Not GueUtils.IsNumeric(mutasi) Then
            mutasi = mutasi.Substring(5) ' ==> 2,500,000.00
        End If
        bankTrans.Mutasi = GueUtils.ParseDouble(mutasi)
        bankTrans.Nama = splitLine(5)
        bankTrans.Reference = splitLine(5)

    End Sub
End Class
