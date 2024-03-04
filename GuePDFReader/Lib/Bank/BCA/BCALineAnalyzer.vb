
Public Class BCALineAnalyzer

    Private ReadOnly periode As Date

    Private ReadOnly lines As String()

    Public Sub New(lines As String(), periode As Date)
        Me.lines = lines
        Me.periode = periode
    End Sub

    Public Function AnalyzeLine(lineIndex As Integer) As BCATrans

        Dim line = lines(lineIndex)

        Console.WriteLine(lineIndex & ". " & line)

        If line.StartsWith(periode.ToString("dd/MM") & " " & BCASaldoAwal.TRANS_TYPE) Then
            Return New BCASaldoAwal(line, periode)
        ElseIf line.Contains(BCABiayaAdmin.TRANS_TYPE) Then
            Return New BCABiayaAdmin(line, periode)
        ElseIf line.Contains(BCATarikanATM.TRANS_TYPE) Then
            Return New BCATarikanATM(line, periode)
        ElseIf line.Contains(BCATransferEbanking.TRANS_TYPE) Then
            Return RunTransferEbanking(line, lineIndex)
        ElseIf line.Contains(BCABIFast.TRANS_TYPE) Then
            If line.Substring(6, 7) = BCABIFast.TRANS_TYPE Then
                Return RunTransferBIFast(line, lineIndex)
            End If
        End If
        Return Nothing
    End Function

    Private Function RunTransferEbanking(line As String, lineIndex As Integer) As BCATransferEbanking
        Dim ebanking = New BCATransferEbanking(line, periode)

        If Not ebanking.GetBankTrans.IsValid Then
            Return Nothing
        End If

        lineIndex += 1

        While (lineIndex < lines.Length)
            If Not ebanking.NextLine(lines(lineIndex)) Then
                Exit While
            End If
            lineIndex += 1
        End While
        Return ebanking
    End Function

    Private Function RunTransferBIFast(line As String, lineIndex As Integer) As BCABIFast
        Dim ebanking = New BCABIFast(line, periode)

        If Not ebanking.GetBankTrans.IsValid Then
            Return Nothing
        End If

        lineIndex += 1

        While (lineIndex < lines.Length)
            If Not ebanking.NextLine(lines(lineIndex)) Then
                Exit While
            End If
            lineIndex += 1
        End While
        Return ebanking
    End Function

End Class
