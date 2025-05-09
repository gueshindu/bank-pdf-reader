Public Class BCADebitDomestik
    Inherits BCATrans

    Public Const TRANS_TYPE = "DB DEBIT DOMESTIK"

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)

        For i As Integer = 2 To splitLine.Length - 1
            Dim tmp = splitLine(i)

            If tmp = "DB" Then
                'DB/CR
                lastLineIndex = i
                bankTrans.IsValid = True
                Exit For
            End If
        Next

        If (bankTrans.DBCR = "DB") Then
            bankTrans.TransType = TRANS_TYPE
            bankTrans.Keterangan = bankTrans.TransType
            Dim mutasi = splitLine(lastLineIndex - 1) '==> 31/122,500,000.00

            If Not IsNumeric(mutasi) Then
                mutasi = mutasi.Substring(5) ' ==> 2,500,000.00
            End If
            bankTrans.Mutasi = GueUtils.ParseDouble(mutasi)
        End If

    End Sub
End Class
