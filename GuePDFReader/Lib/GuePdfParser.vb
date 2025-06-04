Imports System.Runtime.CompilerServices
Imports iText.Kernel.Exceptions
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser

Public Class GuePdfParser

    Protected textToParse As String
    Protected textToParsePerPage As List(Of String)

    ReadOnly pdfFile As String
    Protected bank As IGueBank
    Private strtPage As Integer = 1

    Public Sub New(pdfFilePath As String, Optional pageStart As Integer = 1)
        Me.pdfFile = pdfFilePath
        Me.strtPage = pageStart
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
        If textToParsePerPage Is Nothing Then
            Return ""
        End If
        Try
            Return textToParsePerPage(page - 1)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function OpenPDFFile() As Boolean
        If IO.File.Exists(pdfFile) Then
            Dim idx As Integer = 0
            Dim pdfRead As PdfReader
            Dim pdfDoc As PdfDocument

            pdfRead = New PdfReader(pdfFile)
            Try
                pdfDoc = New PdfDocument(pdfRead)

            Catch ex As BadPasswordException
                MsgBox("PDF encripted. cannot open!", MsgBoxStyle.Exclamation, "PDF with password")
                Return False
            End Try

            Dim numPage = pdfDoc.GetNumberOfPages()
            textToParsePerPage = New List(Of String)
            textToParse = ""
            For i As Integer = StartPage To numPage
                If (i >= strtPage) Then
                    textToParsePerPage.Add(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)))
                Else
                    textToParsePerPage.Add("")
                End If
                textToParse &= textToParsePerPage(idx) & vbCrLf
                idx += 1
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
            tmpBank = Nothing
        End If
        SetBank(tmpBank)

    End Sub
    Public Sub SetBank(bank As IGueBank)
        If (bank IsNot Nothing) Then
            Me.bank = bank
            Me.bank.SetTextToParse(textToParse)
        End If

    End Sub

    Public Function ReadBankDocument() As Boolean
        If bank IsNot Nothing Then
            Return bank.ExecuteParse()
        End If
        Return False
    End Function

    Public Function GetBank() As IGueBank
        Return bank
    End Function
End Class
