<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GueBankPDFReader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GueBankPDFReader))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblInfoBank = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.colTgl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNama = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKet = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDK = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMutasi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlCmd = New System.Windows.Forms.Panel()
        Me.lblDataCopied = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.pnlTop.SuspendLayout()
        Me.pnlCmd.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(304, 24)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Bank PDF Transaction Downloader"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(391, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Program untuk mengekstrak file PDF transksi bank untuk digunakan ditempat lain"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 6)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Pilih file PDF"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(83, 10)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(10, 13)
        Me.lblFileName.TabIndex = 3
        Me.lblFileName.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nama file:"
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "OpenFileDialog1"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(100, 6)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 5
        Me.btnProcess.Text = "Baca file PDF"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Informasi file:"
        '
        'lblInfoBank
        '
        Me.lblInfoBank.AutoSize = True
        Me.lblInfoBank.Location = New System.Drawing.Point(83, 32)
        Me.lblInfoBank.Name = "lblInfoBank"
        Me.lblInfoBank.Size = New System.Drawing.Size(10, 13)
        Me.lblInfoBank.TabIndex = 7
        Me.lblInfoBank.Text = "-"
        '
        'lstData
        '
        Me.lstData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTgl, Me.colType, Me.colNama, Me.colKet, Me.colDK, Me.colMutasi})
        Me.lstData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(0, 261)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(861, 321)
        Me.lstData.TabIndex = 8
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'colTgl
        '
        Me.colTgl.Text = "Tanggal"
        Me.colTgl.Width = 100
        '
        'colType
        '
        Me.colType.Text = "Transaksi"
        Me.colType.Width = 150
        '
        'colNama
        '
        Me.colNama.Text = "Nama"
        Me.colNama.Width = 200
        '
        'colKet
        '
        Me.colKet.Text = "Keterangan"
        Me.colKet.Width = 200
        '
        'colDK
        '
        Me.colDK.Text = "D/K"
        '
        'colMutasi
        '
        Me.colMutasi.Text = "Mutasi"
        Me.colMutasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMutasi.Width = 120
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.MintCream
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(861, 62)
        Me.pnlTop.TabIndex = 9
        '
        'pnlCmd
        '
        Me.pnlCmd.BackColor = System.Drawing.Color.White
        Me.pnlCmd.Controls.Add(Me.lblDataCopied)
        Me.pnlCmd.Controls.Add(Me.btnOpen)
        Me.pnlCmd.Controls.Add(Me.btnProcess)
        Me.pnlCmd.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCmd.Location = New System.Drawing.Point(0, 62)
        Me.pnlCmd.Name = "pnlCmd"
        Me.pnlCmd.Size = New System.Drawing.Size(861, 36)
        Me.pnlCmd.TabIndex = 10
        '
        'lblDataCopied
        '
        Me.lblDataCopied.AutoSize = True
        Me.lblDataCopied.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCopied.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDataCopied.Location = New System.Drawing.Point(191, 11)
        Me.lblDataCopied.Name = "lblDataCopied"
        Me.lblDataCopied.Size = New System.Drawing.Size(473, 15)
        Me.lblDataCopied.TabIndex = 6
        Me.lblDataCopied.Text = "Data transaksi sudah dicopy. Silahkan paste pada file Excel yang kosong"
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.White
        Me.pnlInfo.Controls.Add(Me.Label2)
        Me.pnlInfo.Controls.Add(Me.lblFileName)
        Me.pnlInfo.Controls.Add(Me.Label3)
        Me.pnlInfo.Controls.Add(Me.lblInfoBank)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 98)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(861, 163)
        Me.pnlInfo.TabIndex = 11
        '
        'pnlBottom
        '
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 582)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(861, 28)
        Me.pnlBottom.TabIndex = 12
        '
        'GueBankPDFReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 610)
        Me.Controls.Add(Me.lstData)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlCmd)
        Me.Controls.Add(Me.pnlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GueBankPDFReader"
        Me.Text = "Bank PDF Trans Downloader"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlCmd.ResumeLayout(False)
        Me.pnlCmd.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOpen As Button
    Friend WithEvents lblFileName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dlgOpenFile As OpenFileDialog
    Friend WithEvents btnProcess As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblInfoBank As Label
    Friend WithEvents lstData As ListView
    Friend WithEvents colTgl As ColumnHeader
    Friend WithEvents colNama As ColumnHeader
    Friend WithEvents colKet As ColumnHeader
    Friend WithEvents colMutasi As ColumnHeader
    Friend WithEvents colType As ColumnHeader
    Friend WithEvents colDK As ColumnHeader
    Friend WithEvents pnlTop As Panel
    Friend WithEvents pnlCmd As Panel
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblDataCopied As Label
End Class
