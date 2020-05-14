<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtTextToEncode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnDecode = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnCheckForUpdates = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.qrCodeImage = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuItemShowBiggerImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnClipboard = New System.Windows.Forms.Button()
        Me.chkUseSSL = New System.Windows.Forms.CheckBox()
        Me.btnDecodeFromScreenShot = New System.Windows.Forms.Button()
        Me.btnQRCodeBuilder = New System.Windows.Forms.Button()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTextToEncode
        '
        Me.txtTextToEncode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextToEncode.Location = New System.Drawing.Point(12, 90)
        Me.txtTextToEncode.MaxLength = 2950
        Me.txtTextToEncode.Multiline = True
        Me.txtTextToEncode.Name = "txtTextToEncode"
        Me.txtTextToEncode.Size = New System.Drawing.Size(503, 56)
        Me.txtTextToEncode.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 78)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'lblLength
        '
        Me.lblLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLength.AutoSize = True
        Me.lblLength.Location = New System.Drawing.Point(433, 74)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(52, 13)
        Me.lblLength.TabIndex = 5
        Me.lblLength.Text = "Length: 0"
        '
        'btnDecode
        '
        Me.btnDecode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDecode.Image = Global.SimpleQR.My.Resources.Resources.Browse
        Me.btnDecode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDecode.Location = New System.Drawing.Point(218, 249)
        Me.btnDecode.Name = "btnDecode"
        Me.btnDecode.Size = New System.Drawing.Size(148, 23)
        Me.btnDecode.TabIndex = 9
        Me.btnDecode.Text = "Decode QRCode Image"
        Me.btnDecode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDecode.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Image = Global.SimpleQR.My.Resources.Resources.info_blue
        Me.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbout.Location = New System.Drawing.Point(439, 307)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(61, 23)
        Me.btnAbout.TabIndex = 8
        Me.btnAbout.Text = "About"
        Me.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnCheckForUpdates
        '
        Me.btnCheckForUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckForUpdates.Image = Global.SimpleQR.My.Resources.Resources.refresh
        Me.btnCheckForUpdates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckForUpdates.Location = New System.Drawing.Point(313, 307)
        Me.btnCheckForUpdates.Name = "btnCheckForUpdates"
        Me.btnCheckForUpdates.Size = New System.Drawing.Size(120, 23)
        Me.btnCheckForUpdates.TabIndex = 7
        Me.btnCheckForUpdates.Text = "Check for Updates"
        Me.btnCheckForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckForUpdates.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.SimpleQR.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(218, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save Image"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'qrCodeImage
        '
        Me.qrCodeImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.qrCodeImage.ContextMenuStrip = Me.ContextMenuStrip
        Me.qrCodeImage.Location = New System.Drawing.Point(12, 152)
        Me.qrCodeImage.Name = "qrCodeImage"
        Me.qrCodeImage.Size = New System.Drawing.Size(200, 200)
        Me.qrCodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.qrCodeImage.TabIndex = 0
        Me.qrCodeImage.TabStop = False
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemShowBiggerImage})
        Me.ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(177, 26)
        '
        'menuItemShowBiggerImage
        '
        Me.menuItemShowBiggerImage.Name = "menuItemShowBiggerImage"
        Me.menuItemShowBiggerImage.Size = New System.Drawing.Size(176, 22)
        Me.menuItemShowBiggerImage.Text = "&Show Bigger Image"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnClipboard
        '
        Me.btnClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClipboard.Location = New System.Drawing.Point(218, 278)
        Me.btnClipboard.Name = "btnClipboard"
        Me.btnClipboard.Size = New System.Drawing.Size(195, 23)
        Me.btnClipboard.TabIndex = 10
        Me.btnClipboard.Text = "Copy Image to Windows Clipboard"
        Me.btnClipboard.UseVisualStyleBackColor = True
        '
        'chkUseSSL
        '
        Me.chkUseSSL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseSSL.AutoSize = True
        Me.chkUseSSL.Location = New System.Drawing.Point(220, 336)
        Me.chkUseSSL.Name = "chkUseSSL"
        Me.chkUseSSL.Size = New System.Drawing.Size(280, 17)
        Me.chkUseSSL.TabIndex = 12
        Me.chkUseSSL.Text = "Use SSL to check for and download program updates"
        Me.chkUseSSL.UseVisualStyleBackColor = True
        '
        'btnDecodeFromScreenShot
        '
        Me.btnDecodeFromScreenShot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDecodeFromScreenShot.Location = New System.Drawing.Point(372, 249)
        Me.btnDecodeFromScreenShot.Name = "btnDecodeFromScreenShot"
        Me.btnDecodeFromScreenShot.Size = New System.Drawing.Size(146, 23)
        Me.btnDecodeFromScreenShot.TabIndex = 13
        Me.btnDecodeFromScreenShot.Text = "Decode from Screen Shot"
        Me.btnDecodeFromScreenShot.UseVisualStyleBackColor = True
        '
        'btnQRCodeBuilder
        '
        Me.btnQRCodeBuilder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQRCodeBuilder.Location = New System.Drawing.Point(419, 278)
        Me.btnQRCodeBuilder.Name = "btnQRCodeBuilder"
        Me.btnQRCodeBuilder.Size = New System.Drawing.Size(99, 23)
        Me.btnQRCodeBuilder.TabIndex = 16
        Me.btnQRCodeBuilder.Text = "QRCode Builder"
        Me.btnQRCodeBuilder.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 365)
        Me.Controls.Add(Me.btnDecodeFromScreenShot)
        Me.Controls.Add(Me.chkUseSSL)
        Me.Controls.Add(Me.btnClipboard)
        Me.Controls.Add(Me.btnDecode)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnCheckForUpdates)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTextToEncode)
        Me.Controls.Add(Me.qrCodeImage)
        Me.Controls.Add(Me.btnQRCodeBuilder)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(543, 404)
        Me.Name = "Form1"
        Me.Text = "SimpleQR"
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents qrCodeImage As System.Windows.Forms.PictureBox
    Friend WithEvents txtTextToEncode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnCheckForUpdates As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents btnDecode As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnClipboard As System.Windows.Forms.Button
    Friend WithEvents chkUseSSL As CheckBox
    Friend WithEvents btnDecodeFromScreenShot As Button
    Friend WithEvents btnQRCodeBuilder As Button
    Friend Shadows WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents menuItemShowBiggerImage As ToolStripMenuItem
End Class
