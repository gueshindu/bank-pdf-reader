Public Class BCABiayaAdmin
    Inherits BCATrans

    Public Const TRANS_TYPE = "BIAYA ADM"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        'Contoh format: 31/01 BIAYA ADM30,000.00 DB 33,969,734.00
        'If (splitLine.Length > 2) Then
        '    bankTrans.TransType = "BIAYA ADMIN"
        '    bankTrans.Keterangan = bankTrans.TransType
        '    Dim tmp = splitLine(2).Replace("ADM", "")
        '    bankTrans.Mutasi = GueUtils.ParseDouble(tmp)
        'End If


        If (bankTrans.DBCR = "DB") Then
            bankTrans.TransType = TRANS_TYPE
            bankTrans.Keterangan = bankTrans.TransType
            Dim mutasi = splitLine(lastLineIndex - 1) '==> 31/122,500,000.00

            mutasi = mutasi.Replace("ADM", "")

            If Not GueUtils.IsNumeric(mutasi) Then
                mutasi = mutasi.Substring(5) ' ==> 2,500,000.00
            End If
            bankTrans.Mutasi = GueUtils.ParseDouble(mutasi)
        End If

    End Sub
End Class
