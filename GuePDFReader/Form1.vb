Imports System.Globalization
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim pdfDoc As PdfDocument
        Dim str As String

        OpenFileDialog1.Filter = "File PDF|*.pdf"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            pdfDoc = New PdfDocument(New PdfReader(OpenFileDialog1.FileName))
            str = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(1))

            Dim parser = New GuePdfParser(OpenFileDialog1.FileName)

            parser.SetBank(New BankBCA())
            parser.ReadBankDocument()

            Dim listTrans = parser.GetBank().GetListTransaksi

            For i As Integer = 0 To listTrans.Count - 1
                Console.WriteLine(listTrans(i).ToString)
            Next

            Console.WriteLine(parser.GetBank().GetBankInfo().ToString)

        End If

    End Sub
End Class
