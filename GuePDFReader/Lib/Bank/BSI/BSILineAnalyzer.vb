
Public Class BSILineAnalyzer

    Private ReadOnly periode As Date

    Private ReadOnly lines As String()

    Public Sub New(lines As String(), periode As Date)
        Me.lines = lines
        Me.periode = periode
    End Sub

    Public Function AnalyzeLine(lineIndex As Integer) As BSITrans

        Dim line = lines(lineIndex)
        Dim lineSplit = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)
        Dim transType = ""
        If lineSplit.Length > 3 Then
            transType = lineSplit(3)
        End If


        If line.Contains(BSIByAdmin.TRANS_TYPE) Then 'Biaya admin
            Return New BSIByAdmin(line, periode)
        ElseIf line.Contains(BSIAngsuran.TRANS_TYPE) Then 'Bayar angsuran
            Return New BSIAngsuran(line, periode)
        ElseIf line.Contains(BSIPajak.TRANS_TYPE) Then 'Pajak
            Return New BSIPajak(line, periode)
        ElseIf line.Contains(BSIBagiHasil.TRANS_TYPE) Then 'Bagi hasil
            Return New BSIBagiHasil(line, periode)
        ElseIf line.Contains(BSIByPindahBukuEbanking.TRANS_TYPE) Then 'Biaya pindah buku ebanking
            Return RunMultiLineTrans(New BSIByPindahBukuEbanking(line, periode), lineIndex)
        ElseIf line.Contains(BSIBayarEbanking.TRANS_TYPE) Then 'Pembaran ebanking
            Return RunMultiLineTrans(New BSIBayarEbanking(line, periode), lineIndex)
        ElseIf transType = BSIPindahBuku.TRANS_TYPE Then 'Pemindahbukuan
            Return RunMultiLineTrans(New BSIPindahBuku(line, periode), lineIndex)
        End If
        Return Nothing
    End Function

    Private Function RunMultiLineTrans(trans As BSITrans, lineIndex As Integer) As BSITrans
        If trans Is Nothing Then
            Return trans
        End If
        If Not trans.GetBankTrans.IsValid Then
            Return Nothing
        End If

        lineIndex += 1

        While (lineIndex < lines.Length)
            If Not trans.NextLine(lines(lineIndex)) Then
                Exit While
            End If
            lineIndex += 1
        End While
        Return trans
    End Function

End Class
