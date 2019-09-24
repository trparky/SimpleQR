<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Create_WiFi_QRCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Create_WiFi_QRCode))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.line = New System.Windows.Forms.Label()
        Me.txtSSID = New System.Windows.Forms.TextBox()
        Me.radioWEP = New System.Windows.Forms.RadioButton()
        Me.radioWPA = New System.Windows.Forms.RadioButton()
        Me.radioNone = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateQRCode = New System.Windows.Forms.Button()
        Me.txtNetworkPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "WiFi Network Name or SSID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(299, 65)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'line
        '
        Me.line.BackColor = System.Drawing.Color.Black
        Me.line.Location = New System.Drawing.Point(0, 84)
        Me.line.Name = "line"
        Me.line.Size = New System.Drawing.Size(329, 1)
        Me.line.TabIndex = 2
        '
        'txtSSID
        '
        Me.txtSSID.Location = New System.Drawing.Point(12, 111)
        Me.txtSSID.Name = "txtSSID"
        Me.txtSSID.Size = New System.Drawing.Size(294, 20)
        Me.txtSSID.TabIndex = 3
        '
        'radioWEP
        '
        Me.radioWEP.AutoSize = True
        Me.radioWEP.Location = New System.Drawing.Point(141, 137)
        Me.radioWEP.Name = "radioWEP"
        Me.radioWEP.Size = New System.Drawing.Size(50, 17)
        Me.radioWEP.TabIndex = 4
        Me.radioWEP.Text = "WEP"
        Me.radioWEP.UseVisualStyleBackColor = True
        '
        'radioWPA
        '
        Me.radioWPA.AutoSize = True
        Me.radioWPA.Location = New System.Drawing.Point(197, 137)
        Me.radioWPA.Name = "radioWPA"
        Me.radioWPA.Size = New System.Drawing.Size(86, 17)
        Me.radioWPA.TabIndex = 5
        Me.radioWPA.Text = "WPA/WPA2"
        Me.radioWPA.UseVisualStyleBackColor = True
        '
        'radioNone
        '
        Me.radioNone.AutoSize = True
        Me.radioNone.Checked = True
        Me.radioNone.Location = New System.Drawing.Point(10, 137)
        Me.radioNone.Name = "radioNone"
        Me.radioNone.Size = New System.Drawing.Size(125, 17)
        Me.radioNone.TabIndex = 6
        Me.radioNone.TabStop = True
        Me.radioNone.Text = "None/Open Network"
        Me.radioNone.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Network Password"
        '
        'btnCreateQRCode
        '
        Me.btnCreateQRCode.Location = New System.Drawing.Point(10, 209)
        Me.btnCreateQRCode.Name = "btnCreateQRCode"
        Me.btnCreateQRCode.Size = New System.Drawing.Size(296, 23)
        Me.btnCreateQRCode.TabIndex = 8
        Me.btnCreateQRCode.Text = "Create WiFi QRCode"
        Me.btnCreateQRCode.UseVisualStyleBackColor = True
        '
        'txtNetworkPassword
        '
        Me.txtNetworkPassword.Enabled = False
        Me.txtNetworkPassword.Location = New System.Drawing.Point(12, 183)
        Me.txtNetworkPassword.Name = "txtNetworkPassword"
        Me.txtNetworkPassword.Size = New System.Drawing.Size(294, 20)
        Me.txtNetworkPassword.TabIndex = 9
        '
        'Create_WiFi_QRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 244)
        Me.Controls.Add(Me.txtNetworkPassword)
        Me.Controls.Add(Me.btnCreateQRCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.radioNone)
        Me.Controls.Add(Me.radioWPA)
        Me.Controls.Add(Me.radioWEP)
        Me.Controls.Add(Me.txtSSID)
        Me.Controls.Add(Me.line)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Create_WiFi_QRCode"
        Me.Text = "Create WiFi QRCode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents line As Label
    Friend WithEvents txtSSID As TextBox
    Friend WithEvents radioWEP As RadioButton
    Friend WithEvents radioWPA As RadioButton
    Friend WithEvents radioNone As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCreateQRCode As Button
    Friend WithEvents txtNetworkPassword As TextBox
End Class
