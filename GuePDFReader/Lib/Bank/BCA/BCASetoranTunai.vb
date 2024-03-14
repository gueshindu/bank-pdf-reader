Public Class BCASetoranTunai
    Inherits BCATrans

    Public Const TRANS_TYPE = "SETORAN TUNAI"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format:
        '17/01 SETORAN TUNAI 8545 255,450,000.00 122,234,345.00
        '10/01 SETORAN TUNAI8545 273,200,000.00

        bankTrans.TransType = TRANS_TYPE
        bankTrans.DBCR = "CR"
        bankTrans.Keterangan = TRANS_TYPE
        bankTrans.Reference = ""
        bankTrans.Nama = ""

        Dim idx = splitLine.Length
        Dim value As Double = 0

        While idx > 0
            If GueUtils.IsRupiah(splitLine(idx - 1)) Then
                value = GueUtils.ParseDouble(splitLine(idx - 1))
            End If
            idx -= 1
        End While
        bankTrans.Mutasi = value
        bankTrans.IsValid = True

    End Sub
End Class
