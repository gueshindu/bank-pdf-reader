Imports System.Runtime.CompilerServices
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser

Public Class GuePdfParser

    Protected textToParse As String
    ReadOnly pdfFile As String
    Protected bank As IGueBank

    Public Sub New(pdfFilePath As String)
        Me.pdfFile = pdfFilePath
        OpenPDFFile()
    End Sub

    Public Function GetPDFText() As String
        Return textToParse
    End Function

    Public Function OpenPDFFile() As Boolean
        If IO.File.Exists(pdfFile) Then
            Dim pdfDoc = New PdfDocument(New PdfReader(pdfFile))
            Dim numPage = pdfDoc.GetNumberOfPages()
            textToParse = ""
            For i As Integer = 1 To numPage
                textToParse &= PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)) & vbCrLf
            Next
            Return textToParse.Length > 10
        Else
            Return False
        End If
    End Function

    Public Sub SetBank(bank As IGueBank)
        Me.bank = bank
        Me.bank.SetTextToParse(textToParse)
    End Sub

    Public Function ReadBankDocument() As Boolean
        Return bank.ExecuteParse()
    End Function

    Public Function GetBank() As IGueBank
        Return bank
    End Function
End Class
