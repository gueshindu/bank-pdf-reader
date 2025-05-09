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
        Me.numHalaman = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.chkTipe = New System.Windows.Forms.CheckBox()
        Me.chkKet = New System.Windows.Forms.CheckBox()
        Me.chkNama = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.lblCopyToExcel = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlCmd.SuspendLayout()
        CType(Me.numHalaman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInfo.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
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
        Me.btnProcess.Location = New System.Drawing.Point(232, 6)
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
        Me.lstData.Size = New System.Drawing.Size(923, 321)
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
        Me.pnlTop.Size = New System.Drawing.Size(923, 62)
        Me.pnlTop.TabIndex = 9
        '
        'pnlCmd
        '
        Me.pnlCmd.BackColor = System.Drawing.Color.White
        Me.pnlCmd.Controls.Add(Me.numHalaman)
        Me.pnlCmd.Controls.Add(Me.Label4)
        Me.pnlCmd.Controls.Add(Me.CheckBox3)
        Me.pnlCmd.Controls.Add(Me.CheckBox2)
        Me.pnlCmd.Controls.Add(Me.chkTipe)
        Me.pnlCmd.Controls.Add(Me.chkKet)
        Me.pnlCmd.Controls.Add(Me.chkNama)
        Me.pnlCmd.Controls.Add(Me.CheckBox1)
        Me.pnlCmd.Controls.Add(Me.btnCopy)
        Me.pnlCmd.Controls.Add(Me.lblCopyToExcel)
        Me.pnlCmd.Controls.Add(Me.btnOpen)
        Me.pnlCmd.Controls.Add(Me.btnProcess)
        Me.pnlCmd.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCmd.Location = New System.Drawing.Point(0, 62)
        Me.pnlCmd.Name = "pnlCmd"
        Me.pnlCmd.Size = New System.Drawing.Size(923, 36)
        Me.pnlCmd.TabIndex = 10
        '
        'numHalaman
        '
        Me.numHalaman.Location = New System.Drawing.Point(177, 9)
        Me.numHalaman.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numHalaman.Name = "numHalaman"
        Me.numHalaman.Size = New System.Drawing.Size(44, 20)
        Me.numHalaman.TabIndex = 4
        Me.numHalaman.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(93, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mulai halaman:"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(858, 10)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox3.TabIndex = 13
        Me.CheckBox3.Text = "Kredit"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(801, 10)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "Debit"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chkTipe
        '
        Me.chkTipe.AutoSize = True
        Me.chkTipe.Location = New System.Drawing.Point(734, 9)
        Me.chkTipe.Name = "chkTipe"
        Me.chkTipe.Size = New System.Drawing.Size(47, 17)
        Me.chkTipe.TabIndex = 11
        Me.chkTipe.Text = "Tipe"
        Me.chkTipe.UseVisualStyleBackColor = True
        '
        'chkKet
        '
        Me.chkKet.AutoSize = True
        Me.chkKet.Checked = True
        Me.chkKet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKet.Location = New System.Drawing.Point(647, 10)
        Me.chkKet.Name = "chkKet"
        Me.chkKet.Size = New System.Drawing.Size(81, 17)
        Me.chkKet.TabIndex = 10
        Me.chkKet.Text = "Keterangan"
        Me.chkKet.UseVisualStyleBackColor = True
        '
        'chkNama
        '
        Me.chkNama.AutoSize = True
        Me.chkNama.Checked = True
        Me.chkNama.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNama.Location = New System.Drawing.Point(587, 10)
        Me.chkNama.Name = "chkNama"
        Me.chkNama.Size = New System.Drawing.Size(54, 17)
        Me.chkNama.TabIndex = 9
        Me.chkNama.Text = "Nama"
        Me.chkNama.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(516, 10)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Tanggal"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.BackColor = System.Drawing.Color.Aqua
        Me.btnCopy.Location = New System.Drawing.Point(313, 6)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(135, 23)
        Me.btnCopy.TabIndex = 6
        Me.btnCopy.Text = "Copy data ke Excel"
        Me.btnCopy.UseVisualStyleBackColor = False
        '
        'lblCopyToExcel
        '
        Me.lblCopyToExcel.AutoSize = True
        Me.lblCopyToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyToExcel.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCopyToExcel.Location = New System.Drawing.Point(454, 9)
        Me.lblCopyToExcel.Name = "lblCopyToExcel"
        Me.lblCopyToExcel.Size = New System.Drawing.Size(56, 15)
        Me.lblCopyToExcel.TabIndex = 7
        Me.lblCopyToExcel.Text = "Format:"
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
        Me.pnlInfo.Size = New System.Drawing.Size(923, 163)
        Me.pnlInfo.TabIndex = 11
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.lblVersion)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 582)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(8)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlBottom.Size = New System.Drawing.Size(923, 28)
        Me.pnlBottom.TabIndex = 12
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblStatus.Location = New System.Drawing.Point(29, 3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(8, 13)
        Me.lblStatus.TabIndex = 1
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblVersion.Location = New System.Drawing.Point(3, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(26, 13)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Ver."
        '
        'GueBankPDFReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 610)
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
        CType(Me.numHalaman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
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
    Friend WithEvents lblCopyToExcel As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnCopy As Button
    Friend WithEvents chkNama As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents chkTipe As CheckBox
    Friend WithEvents chkKet As CheckBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents numHalaman As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
