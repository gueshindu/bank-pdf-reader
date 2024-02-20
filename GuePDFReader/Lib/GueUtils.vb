Imports System.Globalization

Public Class GueUtils
    Public Shared Function GetBulanIndonesia(bulan As String) As Integer
        Select Case bulan.ToLower
            Case "januari", "jan" : Return 1
            Case "fabruari", "feb", "pebruari", "peb" : Return 2
            Case "maret", "mar" : Return 3
            Case "april", "apr" : Return 4
            Case "mei" : Return 5
            Case "juni", "jun" : Return 6
            Case "juli", "jul" : Return 7
            Case "agustus", "agt" : Return 8
            Case "september", "sep" : Return 9
            Case "oktober", "okt" : Return 10
            Case "nopember", "nop", "november", "nov" : Return 11
            Case "desember", "des" : Return 12
            Case Else : Return 0
        End Select
    End Function

    Public Shared Function MergeSplitString(splitString As String(), fromIndex As Integer, toIndex As Integer, Optional joinString As String = " ") As String
        Dim str = ""

        Try
            For i As Integer = fromIndex To toIndex - 1
                str = str & splitString(i) & joinString
            Next
            str &= splitString(toIndex)
        Catch ex As Exception
        End Try
        Return str
    End Function

    Public Shared Function ParseDouble(strDouble As String, Optional usingENUSFormat As Boolean = True) As Double
        Dim format As IFormatProvider
        If usingENUSFormat Then
            format = CultureInfo.CreateSpecificCulture("en-US")
        Else
            format = CultureInfo.CreateSpecificCulture("id-ID")
        End If

        Return Double.Parse(strDouble, format)
    End Function

End Class
