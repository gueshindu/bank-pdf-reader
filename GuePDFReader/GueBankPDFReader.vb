Public Class GueBankPDFReader
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitForm()

        lblVersion.Text = "Versi: " & My.Application.Info.Version.ToString
        lblVersion.Text += " -- " + My.Application.Info.Description

    End Sub

    Private Sub InitForm()
        btnProcess.Enabled = False
        btnCopy.Enabled = False
        btnOpen.Enabled = True
        lblFileName.Text = "-"
        lblCopyToExcel.Visible = False
        lblStatus.Text = "Ready"
    End Sub

    Private Sub ReadyToProcess()
        btnOpen.Enabled = False
        btnCopy.Enabled = False
        btnProcess.Enabled = True
        lblCopyToExcel.Visible = False
        lblStatus.Text = "Ready to process"
    End Sub

    Private Sub ProcessDone()
        lblCopyToExcel.Visible = True
        If (stringToClipBoard <> "") Then
            Clipboard.SetText(stringToClipBoard)
        End If
        btnProcess.Enabled = False
        btnOpen.Enabled = True
        btnCopy.Enabled = True
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

        'parser.SetBank(New BankBCA())
        parser.SetBankAuto()
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
        stringToClipBoard = ""
        For i As Integer = 0 To listBankTrans.Count - 1

            If (stringToClipBoard = "") Then
                stringToClipBoard = listBankTrans(i).ToFormatedTextHeader(
                    showNama:=chkNama.Checked,
                    showKeterangan:=chkKet.Checked,
                    showTipe:=chkTipe.Checked
                ) & vbCrLf
            End If

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

            stringToClipBoard &= listBankTrans(i).ToFormatedText(
                showNama:=chkNama.Checked,
                showKeterangan:=chkKet.Checked,
                showTipe:=chkTipe.Checked
            ) & vbCrLf
        Next

        lblStatus.Text = "Data sudah tercopy. Silahkan paste di file excel"
    End Sub


    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        IsiGrid()
        Clipboard.SetText(stringToClipBoard)
    End Sub
End Class