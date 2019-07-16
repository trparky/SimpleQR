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
        Me.components = New System.ComponentModel.Container()
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
        Me.radTOTP = New System.Windows.Forms.RadioButton()
        Me.radHOTP = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.txtDigits = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Service Name:"
        '
        'txtServiceName
        '
        Me.txtServiceName.ForeColor = System.Drawing.Color.Gray
        Me.txtServiceName.Location = New System.Drawing.Point(95, 91)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(215, 20)
        Me.txtServiceName.TabIndex = 7
        Me.txtServiceName.Text = "ex: Microsoft"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Account Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtAccountName
        '
        Me.txtAccountName.ForeColor = System.Drawing.Color.Gray
        Me.txtAccountName.Location = New System.Drawing.Point(95, 113)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(215, 20)
        Me.txtAccountName.TabIndex = 8
        Me.txtAccountName.Text = "ex: someone@somedomain.com"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Secret:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Required)"
        '
        'txtSecret
        '
        Me.txtSecret.ForeColor = System.Drawing.Color.Gray
        Me.txtSecret.Location = New System.Drawing.Point(95, 145)
        Me.txtSecret.Name = "txtSecret"
        Me.txtSecret.Size = New System.Drawing.Size(215, 20)
        Me.txtSecret.TabIndex = 9
        Me.txtSecret.Text = "Required"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 26)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Issuer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtIssuer
        '
        Me.txtIssuer.ForeColor = System.Drawing.Color.Gray
        Me.txtIssuer.Location = New System.Drawing.Point(95, 183)
        Me.txtIssuer.Name = "txtIssuer"
        Me.txtIssuer.Size = New System.Drawing.Size(215, 20)
        Me.txtIssuer.TabIndex = 10
        Me.txtIssuer.Text = "ex: Microsoft"
        '
        'btnCreateQRCode
        '
        Me.btnCreateQRCode.Location = New System.Drawing.Point(10, 271)
        Me.btnCreateQRCode.Name = "btnCreateQRCode"
        Me.btnCreateQRCode.Size = New System.Drawing.Size(300, 23)
        Me.btnCreateQRCode.TabIndex = 15
        Me.btnCreateQRCode.Text = "Create TOTP QRCode"
        Me.btnCreateQRCode.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(299, 65)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'line
        '
        Me.line.BackColor = System.Drawing.Color.Black
        Me.line.Location = New System.Drawing.Point(0, 84)
        Me.line.Name = "line"
        Me.line.Size = New System.Drawing.Size(329, 1)
        Me.line.TabIndex = 0
        '
        'radTOTP
        '
        Me.radTOTP.AutoSize = True
        Me.radTOTP.Checked = True
        Me.radTOTP.Location = New System.Drawing.Point(15, 218)
        Me.radTOTP.Name = "radTOTP"
        Me.radTOTP.Size = New System.Drawing.Size(228, 17)
        Me.radTOTP.TabIndex = 11
        Me.radTOTP.TabStop = True
        Me.radTOTP.Text = "TOTP (Default, this is the most typical type)"
        Me.radTOTP.UseVisualStyleBackColor = True
        '
        'radHOTP
        '
        Me.radHOTP.AutoSize = True
        Me.radHOTP.Location = New System.Drawing.Point(249, 218)
        Me.radHOTP.Name = "radHOTP"
        Me.radHOTP.Size = New System.Drawing.Size(55, 17)
        Me.radHOTP.TabIndex = 12
        Me.radHOTP.Text = "HOTP"
        Me.radHOTP.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Period:"
        Me.ToolTip.SetToolTip(Me.Label6, "This is typically set to 30.")
        '
        'txtPeriod
        '
        Me.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriod.Location = New System.Drawing.Point(58, 245)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriod.TabIndex = 13
        Me.txtPeriod.Text = "30"
        Me.ToolTip.SetToolTip(Me.txtPeriod, "This is typically set to 30.")
        '
        'txtDigits
        '
        Me.txtDigits.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDigits.Location = New System.Drawing.Point(252, 245)
        Me.txtDigits.Name = "txtDigits"
        Me.txtDigits.Size = New System.Drawing.Size(58, 20)
        Me.txtDigits.TabIndex = 14
        Me.txtDigits.Text = "6"
        Me.ToolTip.SetToolTip(Me.txtDigits, "This is typically set to 6.")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(207, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Digits:"
        Me.ToolTip.SetToolTip(Me.Label7, "This is typically set to 6.")
        '
        'Create_TOTP_QRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 304)
        Me.Controls.Add(Me.txtDigits)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.radHOTP)
        Me.Controls.Add(Me.radTOTP)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
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
    Friend WithEvents radTOTP As RadioButton
    Friend WithEvents radHOTP As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPeriod As TextBox
    Friend WithEvents txtDigits As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolTip As ToolTip
End Class
