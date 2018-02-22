<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bigImage
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
        Me.qrCodeImage = New System.Windows.Forms.PictureBox()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'qrCodeImage
        '
        Me.qrCodeImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrCodeImage.Location = New System.Drawing.Point(12, 12)
        Me.qrCodeImage.Name = "qrCodeImage"
        Me.qrCodeImage.Size = New System.Drawing.Size(384, 361)
        Me.qrCodeImage.TabIndex = 1
        Me.qrCodeImage.TabStop = False
        '
        'bigImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 385)
        Me.Controls.Add(Me.qrCodeImage)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(424, 424)
        Me.Name = "bigImage"
        Me.Text = "Bigger QRCode Image"
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents qrCodeImage As PictureBox
End Class
