Public Class QRCode_Builder
    Private Sub QRCode_Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Property boolCreateQRCode As Boolean = False
    Public Property strQRCodeData As String

    Enum authType As Short
        totp = 0
        hotp = 1
    End Enum

    Enum networkType As Short
        open = 0
        wep = 1
        wpa = 2
    End Enum

    Private Sub txtServiceName_Click(sender As Object, e As EventArgs) Handles txtServiceName.Click
        If txtServiceName.Text.Equals("ex: Microsoft") Then
            txtServiceName.Text = Nothing
            txtServiceName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtServiceName_Leave(sender As Object, e As EventArgs) Handles txtServiceName.Leave
        If String.IsNullOrWhiteSpace(txtServiceName.Text) Then
            txtServiceName.Text = "ex: Microsoft"
            txtServiceName.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtServiceName_TextChanged(sender As Object, e As EventArgs) Handles txtServiceName.TextChanged
        If Not txtServiceName.Text.Equals("ex: Microsoft") Then txtServiceName.ForeColor = Color.Black
    End Sub

    Private Sub txtAccountName_Click(sender As Object, e As EventArgs) Handles txtAccountName.Click
        If txtAccountName.Text.Equals("ex: someone@somedomain.com") Then
            txtAccountName.Text = Nothing
            txtAccountName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtAccountName_Leave(sender As Object, e As EventArgs) Handles txtAccountName.Leave
        If String.IsNullOrWhiteSpace(txtAccountName.Text) Then
            txtAccountName.Text = "ex: someone@somedomain.com"
            txtAccountName.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtAccountName_TextChanged(sender As Object, e As EventArgs) Handles txtAccountName.TextChanged
        If Not txtAccountName.Text.Equals("ex: someone@somedomain.com") Then txtAccountName.ForeColor = Color.Black
    End Sub

    Private Sub txtIssuer_Click(sender As Object, e As EventArgs) Handles txtIssuer.Click
        If txtIssuer.Text.Equals("ex: Microsoft") Then
            txtIssuer.Text = Nothing
            txtIssuer.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtIssuer_Leave(sender As Object, e As EventArgs) Handles txtIssuer.Leave
        If String.IsNullOrWhiteSpace(txtIssuer.Text) Then
            txtIssuer.Text = "ex: Microsoft"
            txtIssuer.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtIssuer_TextChanged(sender As Object, e As EventArgs) Handles txtIssuer.TextChanged
        If Not txtIssuer.Text.Equals("ex: Microsoft") Then txtIssuer.ForeColor = Color.Black
    End Sub

    Private Sub radioNone_Click(sender As Object, e As EventArgs) Handles radioNone.Click
        txtNetworkPassword.Enabled = False
        txtNetworkPassword.Text = Nothing
    End Sub

    Private Sub radioWEP_Click(sender As Object, e As EventArgs) Handles radioWEP.Click
        txtNetworkPassword.Enabled = True
    End Sub

    Private Sub radioWPA_Click(sender As Object, e As EventArgs) Handles radioWPA.Click
        txtNetworkPassword.Enabled = True
    End Sub

    Private Sub RadTOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radTOTP.CheckedChanged
        txtPeriod.Enabled = True
    End Sub

    Private Sub RadHOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radHOTP.CheckedChanged
        txtPeriod.Enabled = False
    End Sub

    Private Sub txtSecret_Click(sender As Object, e As EventArgs) Handles txtSecret.Click
        If txtSecret.Text.Equals("Required") Then
            txtSecret.Text = Nothing
            txtSecret.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSecret_Leave(sender As Object, e As EventArgs) Handles txtSecret.Leave
        If String.IsNullOrWhiteSpace(txtSecret.Text) Then
            txtSecret.Text = "Required"
            txtSecret.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtSecret_TextChanged(sender As Object, e As EventArgs) Handles txtSecret.TextChanged
        If Not txtSecret.Text.Equals("Required") Then txtSecret.ForeColor = Color.Black
    End Sub

    Private Sub btnCreateTOTPQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateTOTPQRCode.Click
        If txtSecret.Text.Equals("Required", StringComparison.OrdinalIgnoreCase) Then
            MsgBox("You must provide a secret, that's what is used to generate the digits required for your authenticator.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        If txtServiceName.Text.Equals("ex: Microsoft") Then txtServiceName.Text = Nothing
        If txtIssuer.Text.Equals("ex: Microsoft") Then txtIssuer.Text = Nothing
        If txtAccountName.Text.Equals("ex: someone@somedomain.com") Then txtAccountName.Text = Nothing

        Dim serviceName As String = txtServiceName.Text.Trim
        Dim accountName As String = txtAccountName.Text.Trim
        Dim secret As String = txtSecret.Text.Trim
        Dim issuer As String = txtIssuer.Text.Trim
        Dim type As authType
        Dim period, digits As Short

        If radTOTP.Checked Then
            type = authType.totp
        Else
            type = authType.hotp
        End If

        If Not Short.TryParse(txtPeriod.Text, period) Then MsgBox("The period entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)
        If Not Short.TryParse(txtDigits.Text, digits) Then MsgBox("The digits entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)

        Me.Close()
        boolCreateQRCode = True

        strQRCodeData = "otpauth://"
        strQRCodeData &= If(type = authType.hotp, "hotp", "totp") & "/" & serviceName

        If Not String.IsNullOrWhiteSpace(accountName) Then strQRCodeData = String.Concat(strQRCodeData, ":", accountName)
        strQRCodeData = String.Concat(strQRCodeData, "?secret=", secret)
        If Not String.IsNullOrWhiteSpace(issuer) Then strQRCodeData = String.Concat(strQRCodeData, "&issuer=", issuer)

        If type = authType.totp And period <> 30 Then
            strQRCodeData = String.Concat(strQRCodeData, "&period=", period.ToString)
        End If

        If digits <> 6 Then strQRCodeData = String.Concat(strQRCodeData, "&digits=", digits.ToString)
    End Sub

    Private Sub btnCreateWiFiQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateWiFiQRCode.Click
        Dim nettype As networkType

        If radioNone.Checked Then
            netType = networkType.open
        ElseIf radioWEP.Checked Then
            netType = networkType.wep
        ElseIf radioWPA.Checked Then
            netType = networkType.wpa
        End If

        If String.IsNullOrWhiteSpace(txtNetworkPassword.Text) And (netType = networkType.wep Or netType = networkType.wpa) Then
            MsgBox("You must provide a network password if you choose either WEP or WPA/WPA2.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        Dim strSSID As String = txtSSID.Text.Trim
        Dim strNetworkPassword As String = txtNetworkPassword.Text.Trim

        If nettype = networkType.open Then
            strQRCodeData = String.Format("NONE WIFI:S:{0};T:nopass;P:;;", strSSID)
        ElseIf nettype = networkType.wep Then
            strQRCodeData = String.Format("WIFI:S:{0};T:WEP;P:{1};;", strSSID, strNetworkPassword)
        ElseIf nettype = networkType.wpa Then
            strQRCodeData = String.Format("WIFI:S:{0};T:WPA;P:{1};;", strSSID, strNetworkPassword)
        End If

        Me.Close()
        boolCreateQRCode = True
    End Sub
End Class