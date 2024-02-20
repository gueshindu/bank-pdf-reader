Imports System.Diagnostics.Eventing.Reader

Public Class BCABIFast
    Inherits BCATrans

    Public Const TRANS_TYPE = "BI-FAST"
    Private tmpKeterangan As String

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildBIFast()
    End Sub

    Private Sub BuildBIFast()
        Dim tmpStr = ""
        bankTrans.TransType = TRANS_TYPE
        For i As Integer = lastLineIndex + 1 To splitLine.Length - 1
            Dim tmp = splitLine(i)
            If IsNumeric(tmp.Replace(",", "")) Then
                bankTrans.Mutasi = GueUtils.ParseDouble(tmp)
                Exit For
            Else
                tmpStr += tmp & " "
            End If
        Next
        bankTrans.Keterangan = tmpStr
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            bankTrans.Nama = tmpKeterangan
            bankTrans.Keterangan = bankTrans.Keterangan.Substring(0, bankTrans.Keterangan.Length - tmpKeterangan.Length - 1)
            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            ProsesLine2()
        ElseIf transLineNumber > 2 Then
            'Contoh:    RS PKU AISYIYAH BO
            'Contoh 2:  M-BCA
            tmpKeterangan = line
            bankTrans.Keterangan &= " " & tmpKeterangan
        End If

        Return True

    End Function

    Private Sub ProsesLine2()
        'Contoh: TANGGAL :31/12 008
        If (splitLine(0).Contains("TANGGAL")) Then
            bankTrans.Keterangan = splitLine(0) & splitLine(1) & " " & bankTrans.Keterangan
            bankTrans.Keterangan &= String.Join(" ", splitLine, 2, splitLine.Length - 2)
        ElseIf (splitLine.Length > 1) Then
            bankTrans.Keterangan &= String.Join(" ", splitLine, 0, splitLine.Length - 1)
        End If
    End Sub
End Class
