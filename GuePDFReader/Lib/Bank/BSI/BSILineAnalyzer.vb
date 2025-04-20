
Public Class BSILineAnalyzer

    Private ReadOnly periode As Date

    Private ReadOnly lines As String()

    Public Sub New(lines As String(), periode As Date)
        Me.lines = lines
        Me.periode = periode
    End Sub

    Public Function AnalyzeLine(lineIndex As Integer) As BSITrans

        Dim line = lines(lineIndex)
        If line.Length < 10 Then
            Return Nothing
        End If

        Dim transType = line.Substring(6)

        Console.WriteLine(lineIndex & ". " & line)

        'If transType.StartsWith(BCASaldoAwal.TRANS_TYPE) Then 'SALDO AWAL
        '    Return New BCASaldoAwal(line, periode)
        'ElseIf transType.StartsWith(BCABiayaAdmin.TRANS_TYPE) Then 'BY ADMIN
        '    Return New BCABiayaAdmin(line, periode)
        'ElseIf transType.StartsWith(BCATarikanATM.TRANS_TYPE) Then 'TARIKAN ATM
        '    Return New BCATarikanATM(line, periode)
        'ElseIf transType.StartsWith(BCASetoranTunai.TRANS_TYPE) Then 'SERTORAN TUNAI
        '    Return New BCASetoranTunai(line, periode)
        'ElseIf transType.StartsWith(BCABunga.TRANS_TYPE) Then 'BUNGA
        '    Return New BCABunga(line, periode)
        'ElseIf transType.StartsWith(BCAKoreksiBunga.TRANS_TYPE) Then 'KOREKSI BUNGA
        '    Return New BCAKoreksiBunga(line, periode)
        'ElseIf transType.StartsWith(BCAPajakBunga.TRANS_TYPE) Then 'PAJAK BUNGA
        '    Return New BCAPajakBunga(line, periode)
        'ElseIf transType.StartsWith(BCATransferEbanking.TRANS_TYPE) Then 'TRF E BANKING
        '    Return RunMultiLineTrans(New BCATransferEbanking(line, periode), lineIndex)
        'ElseIf transType.StartsWith(BCABIFast.TRANS_TYPE) Then 'TRF BI FAST
        '    Return RunMultiLineTrans(New BCABIFast(line, periode), lineIndex)
        'ElseIf transType.StartsWith(BCAKROtomatis.TRANS_TYPE) Then 'KR OTOMATIS
        '    Return RunMultiLineTrans(New BCAKROtomatis(line, periode), lineIndex)
        'ElseIf transType.StartsWith(BCASwitching.TRANS_TYPE) Then 'SWITCHING
        '    Return RunMultiLineTrans(New BCASwitching(line, periode), lineIndex)
        'End If
        Return Nothing
    End Function

    Private Function RunMultiLineTrans(trans As BCATrans, lineIndex As Integer) As BCATrans
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
