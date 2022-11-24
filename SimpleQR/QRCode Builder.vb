Public Class QRCode_Builder
    Public Property StrQRCodeData As String = Nothing

    Private Sub TxtServiceName_Click(sender As Object, e As EventArgs) Handles txtServiceName.Click
        If txtServiceName.Text.Equals("ex: Microsoft") Then
            txtServiceName.Text = Nothing
            txtServiceName.ForeColor = Color.Black
        End If
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub TxtServiceName_Leave(sender As Object, e As EventArgs) Handles txtServiceName.Leave
        If String.IsNullOrWhiteSpace(txtServiceName.Text) Then
            txtServiceName.Text = "ex: Microsoft"
            txtServiceName.ForeColor = Color.Gray
        End If
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub TxtServiceName_TextChanged(sender As Object, e As EventArgs) Handles txtServiceName.TextChanged
        If Not txtServiceName.Text.Equals("ex: Microsoft") Then txtServiceName.ForeColor = Color.Black
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub TxtAccountName_Click(sender As Object, e As EventArgs) Handles txtAccountName.Click
        If txtAccountName.Text.Equals("ex: someone@somedomain.com") Then
            txtAccountName.Text = Nothing
            txtAccountName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtAccountName_Leave(sender As Object, e As EventArgs) Handles txtAccountName.Leave
        If String.IsNullOrWhiteSpace(txtAccountName.Text) Then
            txtAccountName.Text = "ex: someone@somedomain.com"
            txtAccountName.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtAccountName_TextChanged(sender As Object, e As EventArgs) Handles txtAccountName.TextChanged
        If Not txtAccountName.Text.Equals("ex: someone@somedomain.com") Then txtAccountName.ForeColor = Color.Black
    End Sub

    Private Sub TxtIssuer_Click(sender As Object, e As EventArgs) Handles txtIssuer.Click
        If txtIssuer.Text.Equals("ex: Microsoft") Then
            txtIssuer.Text = Nothing
            txtIssuer.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtIssuer_Leave(sender As Object, e As EventArgs) Handles txtIssuer.Leave
        If String.IsNullOrWhiteSpace(txtIssuer.Text) Then
            txtIssuer.Text = "ex: Microsoft"
            txtIssuer.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtIssuer_TextChanged(sender As Object, e As EventArgs) Handles txtIssuer.TextChanged
        If Not txtIssuer.Text.Equals("ex: Microsoft") Then txtIssuer.ForeColor = Color.Black
    End Sub

    Private Sub RadioNone_Click(sender As Object, e As EventArgs) Handles radioNone.Click
        txtNetworkPassword.Enabled = False
        txtNetworkPassword.Text = Nothing
        lblNetworkPassword.Text = "Network Password (Disabled)"
        DoNetworkSettingsValidation()
    End Sub

    Private Sub RadioWEP_Click(sender As Object, e As EventArgs) Handles radioWEP.Click
        txtNetworkPassword.Enabled = True
        lblNetworkPassword.Text = "Network Password"
        DoNetworkSettingsValidation()
    End Sub

    Private Sub RadioWPA_Click(sender As Object, e As EventArgs) Handles radioWPA.Click
        txtNetworkPassword.Enabled = True
        lblNetworkPassword.Text = "Network Password"
        DoNetworkSettingsValidation()
    End Sub

    Private Sub RadTOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radTOTP.CheckedChanged
        txtPeriod.Enabled = True
    End Sub

    Private Sub RadHOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radHOTP.CheckedChanged
        txtPeriod.Enabled = False
    End Sub

    Private Sub TxtSecret_Click(sender As Object, e As EventArgs) Handles txtSecret.Click
        If txtSecret.Text.Equals("Required") Then
            txtSecret.Text = Nothing
            txtSecret.ForeColor = Color.Black
        End If
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub TxtSecret_Leave(sender As Object, e As EventArgs) Handles txtSecret.Leave
        If String.IsNullOrWhiteSpace(txtSecret.Text) Then
            txtSecret.Text = "Required"
            txtSecret.ForeColor = Color.Gray
        End If
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub TxtSecret_TextChanged(sender As Object, e As EventArgs) Handles txtSecret.TextChanged
        If Not txtSecret.Text.Equals("Required") Then txtSecret.ForeColor = Color.Black
        btnCreateTOTPQRCode.Enabled = Not txtServiceName.Text.Equals("ex: Microsoft") And Not txtSecret.Text.Equals("Required") And Not String.IsNullOrWhiteSpace(txtServiceName.Text) And Not String.IsNullOrWhiteSpace(txtSecret.Text)
    End Sub

    Private Sub BtnCreateTOTPQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateTOTPQRCode.Click
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

        StrQRCodeData = "otpauth://"
        StrQRCodeData &= $"{If(radHOTP.Checked, "hotp", "totp")}/{Uri.EscapeUriString(txtServiceName.Text.Trim)}"

        If Not String.IsNullOrWhiteSpace(txtAccountName.Text.Trim) Then StrQRCodeData &= $":{Uri.EscapeUriString(txtAccountName.Text.Trim)}"
        StrQRCodeData &= $"?secret={txtSecret.Text.Trim}"
        If Not String.IsNullOrWhiteSpace(txtIssuer.Text.Trim) Then StrQRCodeData &= $"&issuer={Uri.EscapeUriString(txtIssuer.Text.Trim)}"
        If radTOTP.Checked And period <> 30 Then StrQRCodeData &= $"&period={period}"
        If digits <> 6 Then StrQRCodeData &= $"&digits={digits}"

        Me.Close()
    End Sub

    Private Sub BtnCreateWiFiQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateWiFiQRCode.Click
        If radioNone.Checked Then
            StrQRCodeData = $"WIFI:T:nopass;S:{Uri.EscapeUriString(txtSSID.Text.Trim)};P:;H:{If(chkHidden.Checked, "true", "false")};"
        ElseIf radioWEP.Checked Then
            StrQRCodeData = $"WIFI:T:WEP;S:{Uri.EscapeUriString(txtSSID.Text.Trim)};P:{txtNetworkPassword.Text.Trim};H:{If(chkHidden.Checked, "true", "false")};"
        ElseIf radioWPA.Checked Then
            StrQRCodeData = $"WIFI:T:WPA;S:{Uri.EscapeUriString(txtSSID.Text.Trim)};P:{txtNetworkPassword.Text.Trim};H:{If(chkHidden.Checked, "true", "false")};"
        End If

        Me.Close()
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If e.TabPageIndex = 0 Then
            Size = New Size(335, 308)
        ElseIf e.TabPageIndex = 1 Then
            Size = New Size(335, 374)
        End If
    End Sub

    Private Sub TxtSSID_TextChanged(sender As Object, e As EventArgs) Handles txtSSID.TextChanged
        DoNetworkSettingsValidation()
    End Sub

    Private Sub TxtNetworkPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNetworkPassword.TextChanged
        DoNetworkSettingsValidation()
    End Sub

    Private Sub DoNetworkSettingsValidation()
        btnCreateWiFiQRCode.Enabled = True

        If String.IsNullOrWhiteSpace(txtSSID.Text) Then
            btnCreateWiFiQRCode.Enabled = False
        End If
        If String.IsNullOrWhiteSpace(txtNetworkPassword.Text) And (radioWEP.Checked Or radioWPA.Checked) Then
            btnCreateWiFiQRCode.Enabled = False
        End If
    End Sub
End Class