<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BigImage
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
        Me.components = New System.ComponentModel.Container()
        Me.qrCodeImage = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyImageToWindowsClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveImageToDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'qrCodeImage
        '
        Me.qrCodeImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrCodeImage.ContextMenuStrip = Me.ContextMenuStrip
        Me.qrCodeImage.Location = New System.Drawing.Point(12, 12)
        Me.qrCodeImage.Name = "qrCodeImage"
        Me.qrCodeImage.Size = New System.Drawing.Size(392, 367)
        Me.qrCodeImage.TabIndex = 1
        Me.qrCodeImage.TabStop = False
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyImageToWindowsClipboardToolStripMenuItem, Me.SaveImageToDiskToolStripMenuItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(260, 48)
        '
        'CopyImageToWindowsClipboardToolStripMenuItem
        '
        Me.CopyImageToWindowsClipboardToolStripMenuItem.Name = "CopyImageToWindowsClipboardToolStripMenuItem"
        Me.CopyImageToWindowsClipboardToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.CopyImageToWindowsClipboardToolStripMenuItem.Text = "Copy Image to Windows Clipboard"
        '
        'SaveImageToDiskToolStripMenuItem
        '
        Me.SaveImageToDiskToolStripMenuItem.Image = Global.SimpleQR.My.Resources.Resources.save
        Me.SaveImageToDiskToolStripMenuItem.Name = "SaveImageToDiskToolStripMenuItem"
        Me.SaveImageToDiskToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.SaveImageToDiskToolStripMenuItem.Text = "Save Image to Disk"
        '
        'bigImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 391)
        Me.Controls.Add(Me.qrCodeImage)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(424, 424)
        Me.Name = "bigImage"
        Me.Text = "Bigger QRCode Image"
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents qrCodeImage As PictureBox
    Shadows WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents CopyImageToWindowsClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveImageToDiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog As SaveFileDialog
End Class
