Imports System.Runtime.CompilerServices
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser

Public Class GuePdfParser

    Protected textToParse As String
    Protected textToParsePerPage As List(Of String)

    ReadOnly pdfFile As String
    Protected bank As IGueBank
    Private strtPage As Integer = 1

    Public Sub New(pdfFilePath As String)
        Me.pdfFile = pdfFilePath
        OpenPDFFile()
    End Sub

    Public Property StartPage As Integer
        Get
            Return strtPage
        End Get
        Set(value As Integer)
            strtPage = value
        End Set
    End Property

    Public Function GetPDFText() As String
        Return textToParse
    End Function
    ''' <summary>
    ''' Get PDF text per page
    ''' </summary>
    ''' <param name="page">Page start from 1</param>
    ''' <returns></returns>
    Public Function GetPDFTextPerPage(page As Integer) As String
        Try
            Return textToParsePerPage(page - 1)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function OpenPDFFile() As Boolean
        If IO.File.Exists(pdfFile) Then
            Dim pdfDoc = New PdfDocument(New PdfReader(pdfFile))
            Dim numPage = pdfDoc.GetNumberOfPages()
            textToParsePerPage = New List(Of String)
            textToParse = ""
            For i As Integer = 1 To numPage
                If (i >= strtPage) Then
                    textToParsePerPage.Add(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)))
                Else
                    textToParsePerPage.Add("")
                End If
                textToParse &= textToParsePerPage(i - 1) & vbCrLf
                'Debug
                'Console.WriteLine(textToParse)
            Next
            Return textToParse.Length > 10
        Else
            Return False
        End If
    End Function

    Public Sub SetBankAuto()
        Dim tmpBank As IGueBank
        Dim strTmp = GetPDFTextPerPage(1)
        If strTmp.Contains(" BCA berhak setiap saat melakukan koreksi apabila ada") Then
            tmpBank = New BankBCA()
        ElseIf strTmp.Contains("www.bankbsi.co.id") Then
            tmpBank = New BankBSI()
        Else
            tmpBank = New BankBCA()
        End If
        SetBank(tmpBank)

    End Sub
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
