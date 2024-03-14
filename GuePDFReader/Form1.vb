Imports System.Globalization
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser
Imports iText.Kernel.Pdf.Canvas.Parser.Listener

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim result As String
        OpenFileDialog1.Filter = "File PDF|*.pdf"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            'Dim pdfDoc = New PdfDocument(New PdfReader(OpenFileDialog1.FileName))

            'Dim text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(9))
            'Console.WriteLine(text)

            'Return

            Dim parser = New GuePdfParser(OpenFileDialog1.FileName)

            parser.SetBank(New BankBCA())
            parser.ReadBankDocument()

            Dim listTrans = parser.GetBank().GetListTransaksi

            result = "Tanggal" & vbTab & "Nama" & vbTab & "Keterangan" & vbTab & "Tipe" & vbTab & "Debit" & vbTab & "Kredit" & vbCrLf

            For i As Integer = 0 To listTrans.Count - 1
                result &= listTrans(i).ToFormatedText & vbCrLf
            Next

            Clipboard.SetText(result)


            Console.WriteLine(parser.GetBank().GetBankInfo().ToString)

        End If

    End Sub
End Class
