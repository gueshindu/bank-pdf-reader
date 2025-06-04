Public Class BCATransaksiDebit
    Inherits BCATrans

    Public Const TRANS_TYPE = "TRANSAKSI DEBIT"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format: 02/01 TARIKAN ATM 31/12 2,500,000.00 DB
        'Tidak diketahui penyebanya hasilnya sepeti ini: 02/01 TARIKAN ATM 31/122,500,000.00 DB
        If (bankTrans.DBCR = "DB") Then
            bankTrans.TransType = TRANS_TYPE
            bankTrans.Keterangan = bankTrans.TransType
            Dim mutasi = splitLine(lastLineIndex - 1) '==> 31/122,500,000.00

            If Not GueUtils.IsNumeric(mutasi) Then
                mutasi = mutasi.Substring(5) ' ==> 2,500,000.00
            End If
            bankTrans.Mutasi = GueUtils.ParseDouble(mutasi)
        End If

    End Sub
End Class
