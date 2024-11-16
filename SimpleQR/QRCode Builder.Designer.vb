<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QRCode_Builder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QRCode_Builder))
        Me.line = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtNetworkPassword = New System.Windows.Forms.TextBox()
        Me.btnCreateWiFiQRCode = New System.Windows.Forms.Button()
        Me.lblNetworkPassword = New System.Windows.Forms.Label()
        Me.radioNone = New System.Windows.Forms.RadioButton()
        Me.radioWPA = New System.Windows.Forms.RadioButton()
        Me.radioWEP = New System.Windows.Forms.RadioButton()
        Me.txtSSID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtDigits = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.radHOTP = New System.Windows.Forms.RadioButton()
        Me.radTOTP = New System.Windows.Forms.RadioButton()
        Me.btnCreateTOTPQRCode = New System.Windows.Forms.Button()
        Me.txtIssuer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSecret = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtServiceName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'line
        '
        Me.line.BackColor = System.Drawing.Color.Black
        Me.line.Location = New System.Drawing.Point(0, 84)
        Me.line.Name = "line"
        Me.line.Size = New System.Drawing.Size(329, 1)
        Me.line.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(299, 65)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 88)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(326, 171)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.chkHidden)
        Me.TabPage1.Controls.Add(Me.txtNetworkPassword)
        Me.TabPage1.Controls.Add(Me.btnCreateWiFiQRCode)
        Me.TabPage1.Controls.Add(Me.lblNetworkPassword)
        Me.TabPage1.Controls.Add(Me.radioNone)
        Me.TabPage1.Controls.Add(Me.radioWPA)
        Me.TabPage1.Controls.Add(Me.radioWEP)
        Me.TabPage1.Controls.Add(Me.txtSSID)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(318, 145)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "WiFi"
        '
        'txtNetworkPassword
        '
        Me.txtNetworkPassword.Enabled = False
        Me.txtNetworkPassword.Location = New System.Drawing.Point(10, 91)
        Me.txtNetworkPassword.Name = "txtNetworkPassword"
        Me.txtNetworkPassword.Size = New System.Drawing.Size(294, 20)
        Me.txtNetworkPassword.TabIndex = 17
        '
        'btnCreateWiFiQRCode
        '
        Me.btnCreateWiFiQRCode.Enabled = False
        Me.btnCreateWiFiQRCode.Location = New System.Drawing.Point(8, 117)
        Me.btnCreateWiFiQRCode.Name = "btnCreateWiFiQRCode"
        Me.btnCreateWiFiQRCode.Size = New System.Drawing.Size(296, 23)
        Me.btnCreateWiFiQRCode.TabIndex = 16
        Me.btnCreateWiFiQRCode.Text = "Create WiFi QRCode"
        Me.btnCreateWiFiQRCode.UseVisualStyleBackColor = True
        '
        'lblNetworkPassword
        '
        Me.lblNetworkPassword.AutoSize = True
        Me.lblNetworkPassword.Location = New System.Drawing.Point(5, 75)
        Me.lblNetworkPassword.Name = "lblNetworkPassword"
        Me.lblNetworkPassword.Size = New System.Drawing.Size(146, 13)
        Me.lblNetworkPassword.TabIndex = 15
        Me.lblNetworkPassword.Text = "Network Password (Disabled)"
        '
        'radioNone
        '
        Me.radioNone.AutoSize = True
        Me.radioNone.Checked = True
        Me.radioNone.Location = New System.Drawing.Point(8, 45)
        Me.radioNone.Name = "radioNone"
        Me.radioNone.Size = New System.Drawing.Size(125, 17)
        Me.radioNone.TabIndex = 14
        Me.radioNone.TabStop = True
        Me.radioNone.Text = "None/Open Network"
        Me.ToolTip.SetToolTip(Me.radioNone, "WARNING!!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leaving your network open without encryption will put" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "your network" &
        " at risk of being hacked and/or exploited." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If at all possible, use WPA/WPA2.")
        Me.radioNone.UseVisualStyleBackColor = True
        '
        'radioWPA
        '
        Me.radioWPA.AutoSize = True
        Me.radioWPA.Location = New System.Drawing.Point(195, 45)
        Me.radioWPA.Name = "radioWPA"
        Me.radioWPA.Size = New System.Drawing.Size(122, 17)
        Me.radioWPA.TabIndex = 13
        Me.radioWPA.Text = "WPA/WPA2/WPA3"
        Me.ToolTip.SetToolTip(Me.radioWPA, "Highly Recommended!!!")
        Me.radioWPA.UseVisualStyleBackColor = True
        '
        'radioWEP
        '
        Me.radioWEP.AutoSize = True
        Me.radioWEP.Location = New System.Drawing.Point(139, 45)
        Me.radioWEP.Name = "radioWEP"
        Me.radioWEP.Size = New System.Drawing.Size(50, 17)
        Me.radioWEP.TabIndex = 12
        Me.radioWEP.Text = "WEP"
        Me.ToolTip.SetToolTip(Me.radioWEP, "WARNING!!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This encryption setting for WiFi networks is HIGHLY not" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "recommende" &
        "d. Please use WPA/WPA2 instead.")
        Me.radioWEP.UseVisualStyleBackColor = True
        '
        'txtSSID
        '
        Me.txtSSID.Location = New System.Drawing.Point(10, 19)
        Me.txtSSID.Name = "txtSSID"
        Me.txtSSID.Size = New System.Drawing.Size(294, 20)
        Me.txtSSID.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "WiFi Network Name or SSID"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.txtDigits)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtPeriod)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.radHOTP)
        Me.TabPage2.Controls.Add(Me.radTOTP)
        Me.TabPage2.Controls.Add(Me.btnCreateTOTPQRCode)
        Me.TabPage2.Controls.Add(Me.txtIssuer)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtSecret)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtAccountName)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtServiceName)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(318, 145)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TOTP"
        '
        'txtDigits
        '
        Me.txtDigits.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDigits.Location = New System.Drawing.Point(245, 157)
        Me.txtDigits.Name = "txtDigits"
        Me.txtDigits.Size = New System.Drawing.Size(58, 20)
        Me.txtDigits.TabIndex = 28
        Me.txtDigits.Text = "6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(200, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Digits:"
        '
        'txtPeriod
        '
        Me.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriod.Location = New System.Drawing.Point(51, 157)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriod.TabIndex = 27
        Me.txtPeriod.Text = "30"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Period:"
        '
        'radHOTP
        '
        Me.radHOTP.AutoSize = True
        Me.radHOTP.Location = New System.Drawing.Point(242, 130)
        Me.radHOTP.Name = "radHOTP"
        Me.radHOTP.Size = New System.Drawing.Size(55, 17)
        Me.radHOTP.TabIndex = 26
        Me.radHOTP.Text = "HOTP"
        Me.radHOTP.UseVisualStyleBackColor = True
        '
        'radTOTP
        '
        Me.radTOTP.AutoSize = True
        Me.radTOTP.Checked = True
        Me.radTOTP.Location = New System.Drawing.Point(8, 130)
        Me.radTOTP.Name = "radTOTP"
        Me.radTOTP.Size = New System.Drawing.Size(228, 17)
        Me.radTOTP.TabIndex = 25
        Me.radTOTP.TabStop = True
        Me.radTOTP.Text = "TOTP (Default, this is the most typical type)"
        Me.radTOTP.UseVisualStyleBackColor = True
        '
        'btnCreateTOTPQRCode
        '
        Me.btnCreateTOTPQRCode.Enabled = False
        Me.btnCreateTOTPQRCode.Location = New System.Drawing.Point(3, 183)
        Me.btnCreateTOTPQRCode.Name = "btnCreateTOTPQRCode"
        Me.btnCreateTOTPQRCode.Size = New System.Drawing.Size(300, 23)
        Me.btnCreateTOTPQRCode.TabIndex = 30
        Me.btnCreateTOTPQRCode.Text = "Create TOTP QRCode"
        Me.btnCreateTOTPQRCode.UseVisualStyleBackColor = True
        '
        'txtIssuer
        '
        Me.txtIssuer.ForeColor = System.Drawing.Color.Gray
        Me.txtIssuer.Location = New System.Drawing.Point(88, 95)
        Me.txtIssuer.Name = "txtIssuer"
        Me.txtIssuer.Size = New System.Drawing.Size(215, 20)
        Me.txtIssuer.TabIndex = 24
        Me.txtIssuer.Text = "ex: Microsoft"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 26)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Issuer:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtSecret
        '
        Me.txtSecret.ForeColor = System.Drawing.Color.Gray
        Me.txtSecret.Location = New System.Drawing.Point(88, 57)
        Me.txtSecret.Name = "txtSecret"
        Me.txtSecret.Size = New System.Drawing.Size(215, 20)
        Me.txtSecret.TabIndex = 23
        Me.txtSecret.Text = "Required"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 26)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Secret:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Required)"
        '
        'txtAccountName
        '
        Me.txtAccountName.ForeColor = System.Drawing.Color.Gray
        Me.txtAccountName.Location = New System.Drawing.Point(88, 25)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(215, 20)
        Me.txtAccountName.TabIndex = 22
        Me.txtAccountName.Text = "ex: someone@somedomain.com"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 26)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Account Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtServiceName
        '
        Me.txtServiceName.ForeColor = System.Drawing.Color.Gray
        Me.txtServiceName.Location = New System.Drawing.Point(88, 3)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(215, 20)
        Me.txtServiceName.TabIndex = 21
        Me.txtServiceName.Text = "ex: Microsoft"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Service Name:"
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = True
        Me.chkHidden.Location = New System.Drawing.Point(195, 74)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(109, 17)
        Me.chkHidden.TabIndex = 18
        Me.chkHidden.Text = "Hidden Network?"
        Me.ToolTip.SetToolTip(Me.chkHidden, "Check this box if the SSID is hidden when scanning for WiFi networks.")
        Me.chkHidden.UseVisualStyleBackColor = True
        '
        'QRCode_Builder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 266)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.line)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "QRCode_Builder"
        Me.Text = "QRCode Builder"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents line As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtNetworkPassword As TextBox
    Friend WithEvents btnCreateWiFiQRCode As Button
    Friend WithEvents lblNetworkPassword As Label
    Friend WithEvents radioNone As RadioButton
    Friend WithEvents radioWPA As RadioButton
    Friend WithEvents radioWEP As RadioButton
    Friend WithEvents txtSSID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDigits As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPeriod As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents radHOTP As RadioButton
    Friend WithEvents radTOTP As RadioButton
    Friend WithEvents btnCreateTOTPQRCode As Button
    Friend WithEvents txtIssuer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSecret As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAccountName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtServiceName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents chkHidden As CheckBox
End Class
