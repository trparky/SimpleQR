<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Create_TOTP_QRCode
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Create_TOTP_QRCode))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServiceName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSecret = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIssuer = New System.Windows.Forms.TextBox()
        Me.btnCreateQRCode = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.line = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Name:"
        '
        'txtServiceName
        '
        Me.txtServiceName.ForeColor = System.Drawing.Color.Gray
        Me.txtServiceName.Location = New System.Drawing.Point(95, 91)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(215, 20)
        Me.txtServiceName.TabIndex = 1
        Me.txtServiceName.Text = "ex: Microsoft"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtAccountName
        '
        Me.txtAccountName.ForeColor = System.Drawing.Color.Gray
        Me.txtAccountName.Location = New System.Drawing.Point(95, 113)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(215, 20)
        Me.txtAccountName.TabIndex = 3
        Me.txtAccountName.Text = "ex: someone@somedomain.com"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TOTP Secret:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Required)"
        '
        'txtSecret
        '
        Me.txtSecret.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecret.Location = New System.Drawing.Point(95, 145)
        Me.txtSecret.Name = "txtSecret"
        Me.txtSecret.Size = New System.Drawing.Size(215, 20)
        Me.txtSecret.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 26)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Issuer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtIssuer
        '
        Me.txtIssuer.ForeColor = System.Drawing.Color.Gray
        Me.txtIssuer.Location = New System.Drawing.Point(95, 183)
        Me.txtIssuer.Name = "txtIssuer"
        Me.txtIssuer.Size = New System.Drawing.Size(215, 20)
        Me.txtIssuer.TabIndex = 7
        Me.txtIssuer.Text = "ex: Microsoft"
        '
        'btnCreateQRCode
        '
        Me.btnCreateQRCode.Location = New System.Drawing.Point(10, 212)
        Me.btnCreateQRCode.Name = "btnCreateQRCode"
        Me.btnCreateQRCode.Size = New System.Drawing.Size(300, 23)
        Me.btnCreateQRCode.TabIndex = 8
        Me.btnCreateQRCode.Text = "Create TOTP QRCode"
        Me.btnCreateQRCode.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(299, 65)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'line
        '
        Me.line.BackColor = System.Drawing.Color.Black
        Me.line.Location = New System.Drawing.Point(0, 84)
        Me.line.Name = "line"
        Me.line.Size = New System.Drawing.Size(329, 1)
        Me.line.TabIndex = 10
        '
        'Create_TOTP_QRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 245)
        Me.Controls.Add(Me.line)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCreateQRCode)
        Me.Controls.Add(Me.txtIssuer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSecret)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtServiceName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Create_TOTP_QRCode"
        Me.Text = "Create TOTP QRCode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtServiceName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAccountName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSecret As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIssuer As TextBox
    Friend WithEvents btnCreateQRCode As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents line As Label
End Class
