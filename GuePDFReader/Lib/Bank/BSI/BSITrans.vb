Public Class BSITrans

    Protected bankTrans As BankTrans
    Protected skipGlobalIndex As Integer

    Protected lastLineIndex As Integer

    Protected periode As Date

    Protected splitLine As String()

    Protected transLineNumber As Integer

    Public Sub New(line As String, periode As Date)
        Me.periode = periode
        Me.splitLine = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)

        If IsFirstLine() Then
            transLineNumber = 1
            CreateBankTrans()
        Else
            bankTrans = Nothing
        End If
    End Sub

    Protected Function IsFirstLine() As Boolean
        If splitLine.Length >= 8 Then
            Dim dateString = splitLine(0) & " " & splitLine(1) & " " & splitLine(2)
            If IsDate(dateString) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetBankTrans() As BankTrans
        Return bankTrans
    End Function

    Public Function GetLastIndex() As Integer
        Return skipGlobalIndex
    End Function

    Protected Sub CreateBankTrans()
        bankTrans = New BankTrans()

        For i As Integer = 0 To splitLine.Length - 1
            Dim tmp = splitLine(i)

            If i < 3 Then
                'tanggal
                bankTrans.TransDate = New Date(periode.Year, periode.Month, CInt(splitLine(0)))
                i = 3
            Else
                bankTrans.IsValid = True
                Exit For
            End If
        Next

    End Sub

    Public Overridable Function NextLine(line As String) As Boolean
        Me.splitLine = line.Split(CType(" ", Char()), StringSplitOptions.RemoveEmptyEntries)

        If line = "Bersambung ke Halaman berikut" Then
            skipGlobalIndex = transLineNumber
            Return False
        ElseIf Not IsFirstLine() Then
            transLineNumber += 1
            Return True
        Else
            skipGlobalIndex = transLineNumber
            Return False
        End If
    End Function

End Class
