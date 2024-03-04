Public Class BCATarikanATM
    Inherits BCATrans

    Public Const TRANS_TYPE = "TARIKAN ATM"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format: 02/01 TARIKAN ATM 31/12 2,500,000.00 DB
        'Tidak diketahui penyebanya hasilnya sepeti ini: 02/01 TARIKAN ATM 31/122,500,000.00 DB
        If (bankTrans.DBCR = "DB") Then
            bankTrans.TransType = TRANS_TYPE
            Dim mutasi = splitLine(lastLineIndex - 1) '==> 31/122,500,000.00
            mutasi = mutasi.Substring(5) ' ==> 2,500,000.00

            bankTrans.Mutasi = GueUtils.ParseDouble(mutasi)
            bankTrans.Keterangan = TRANS_TYPE & " " & splitLine(lastLineIndex - 2)
        End If

    End Sub
End Class
