Public Class QRCode_Builder
    Public Property strQRCodeData As String = Nothing

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
        lblNetworkPassword.Text = "Network Password (Disabled)"
        doNetworkSettingsValidation()
    End Sub

    Private Sub radioWEP_Click(sender As Object, e As EventArgs) Handles radioWEP.Click
        txtNetworkPassword.Enabled = True
        lblNetworkPassword.Text = "Network Password"
        doNetworkSettingsValidation()
    End Sub

    Private Sub radioWPA_Click(sender As Object, e As EventArgs) Handles radioWPA.Click
        txtNetworkPassword.Enabled = True
        lblNetworkPassword.Text = "Network Password"
        doNetworkSettingsValidation()
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

        Dim period, digits As Short

        If Not Short.TryParse(txtPeriod.Text, period) Then
            MsgBox("The period entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        If Not Short.TryParse(txtDigits.Text, digits) Then
            MsgBox("The digits entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        strQRCodeData = "otpauth://"
        strQRCodeData &= If(radHOTP.Checked, "hotp", "totp") & "/" & txtServiceName.Text.Trim

        If Not String.IsNullOrWhiteSpace(txtAccountName.Text.Trim) Then strQRCodeData = String.Concat(strQRCodeData, ":", txtAccountName.Text.Trim)
        strQRCodeData = String.Concat(strQRCodeData, "?secret=", txtSecret.Text.Trim)
        If Not String.IsNullOrWhiteSpace(txtIssuer.Text.Trim) Then strQRCodeData = String.Concat(strQRCodeData, "&issuer=", txtIssuer.Text.Trim)

        If radTOTP.Checked And period <> 30 Then
            strQRCodeData = String.Concat(strQRCodeData, "&period=", period.ToString)
        End If

        If digits <> 6 Then strQRCodeData = String.Concat(strQRCodeData, "&digits=", digits.ToString)

        Me.Close()
    End Sub

    Private Sub btnCreateWiFiQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateWiFiQRCode.Click
        If String.IsNullOrWhiteSpace(txtNetworkPassword.Text) And (radioWEP.Checked Or radioWPA.Checked) Then
            MsgBox("You must provide a network password if you choose either WEP or WPA/WPA2.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        If radioNone.Checked Then
            strQRCodeData = String.Format("WIFI:S:{0};T:nopass;P:;;", txtSSID.Text.Trim)
        ElseIf radioWEP.Checked Then
            strQRCodeData = String.Format("WIFI:S:{0};T:WEP;P:{1};;", txtSSID.Text.Trim, txtNetworkPassword.Text.Trim)
        ElseIf radioWPA.Checked Then
            strQRCodeData = String.Format("WIFI:S:{0};T:WPA;P:{1};;", txtSSID.Text.Trim, txtNetworkPassword.Text.Trim)
        End If

        Me.Close()
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If e.TabPageIndex = 0 Then
            Size = New Size(335, 297)
        ElseIf e.TabPageIndex = 1 Then
            Size = New Size(335, 365)
        End If
    End Sub

    Private Sub txtSSID_TextChanged(sender As Object, e As EventArgs) Handles txtSSID.TextChanged
        doNetworkSettingsValidation()
    End Sub

    Private Sub txtNetworkPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNetworkPassword.TextChanged
        doNetworkSettingsValidation()
    End Sub

    Private Sub doNetworkSettingsValidation()
        btnCreateWiFiQRCode.Enabled = True

        If String.IsNullOrWhiteSpace(txtSSID.Text) Then
            btnCreateWiFiQRCode.Enabled = False
        End If
        If String.IsNullOrWhiteSpace(txtNetworkPassword.Text) And (radioWEP.Checked Or radioWPA.Checked) Then
            btnCreateWiFiQRCode.Enabled = False
        End If
    End Sub
End Class