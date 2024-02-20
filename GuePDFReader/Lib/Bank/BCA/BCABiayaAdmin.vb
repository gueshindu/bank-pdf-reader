Public Class BCABiayaAdmin
    Inherits BCATrans

    Public Const TRANS_TYPE = "BIAYA ADM"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format: 31/01 BIAYA ADM30,000.00 DB 33,969,734.00
        If (splitLine.Length > 2) Then
            bankTrans.TransType = "BIAYA ADMIN"
            Dim tmp = splitLine(2).Replace("ADM", "")
            bankTrans.Mutasi = GueUtils.ParseDouble(tmp)
        End If

    End Sub
End Class
