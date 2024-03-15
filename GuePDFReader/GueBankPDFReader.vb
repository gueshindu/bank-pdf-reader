Public Class GueBankPDFReader
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitForm()
    End Sub

    Private Sub InitForm()
        btnProcess.Enabled = False
        btnOpen.Enabled = True
        lblFileName.Text = "-"
        lblDataCopied.Visible = False
    End Sub

    Private Sub ReadyToProcess()
        btnOpen.Enabled = False
        btnProcess.Enabled = True
        lblDataCopied.Visible = False
    End Sub

    Private Sub ProcessDone()
        lblDataCopied.Visible = True
        Clipboard.SetText(stringToClipBoard)
        btnProcess.Enabled = False
        btnOpen.Enabled = True
    End Sub
    Private Sub OpenFile_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        dlgOpenFile.Filter = "File PDF|*.pdf"
        If dlgOpenFile.ShowDialog() = DialogResult.OK Then
            lblFileName.Text = dlgOpenFile.FileName
            ReadyToProcess()
        End If
    End Sub

    Dim listBankTrans As List(Of BankTrans)
    Dim stringToClipBoard As String

    Private Sub Process_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        If Not IO.File.Exists(lblFileName.Text) Then
            MsgBox("File " & lblFileName.Text & " tidak valid!", MsgBoxStyle.Exclamation)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim parser = New GuePdfParser(lblFileName.Text)

        parser.SetBank(New BankBCA())
        parser.ReadBankDocument()

        listBankTrans?.Clear()
        stringToClipBoard = ""

        listBankTrans = parser.GetBank().GetListTransaksi

        IsiGrid()

        lblInfoBank.Text = parser.GetBank().GetBankInfo().ToString
        ProcessDone()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub IsiGrid()
        lstData.Items.Clear()
        stringToClipBoard = "Tanggal" & vbTab & "Nama" & vbTab & "Keterangan" & vbTab & "Tipe" & vbTab & "Debit" & vbTab & "Kredit" & vbCrLf
        For i As Integer = 0 To listBankTrans.Count - 1
            lstData.Items.Add(
                New ListViewItem({
                                 listBankTrans(i).TransDate.ToString("dd-MMM-yyyy"),
                                 listBankTrans(i).TransType,
                                 listBankTrans(i).Nama.Trim,
                                 listBankTrans(i).RefDanKeterangan(),
                                 listBankTrans(i).DBCR,
                                 listBankTrans(i).Mutasi.ToString("#,##0.00")
                                 })
                )

            stringToClipBoard &= listBankTrans(i).ToFormatedText & vbCrLf
        Next
    End Sub
End Class