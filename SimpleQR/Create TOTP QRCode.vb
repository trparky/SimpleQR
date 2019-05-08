Public Class Create_TOTP_QRCode
    Public Property serviceName As String
    Public Property accountName As String
    Public Property secret As String
    Public Property issuer As String
    Public Property boolCreateQRCode As Boolean = False
    Public Property type As authType
    Public Property period As Short
    Public Property digits As Short

    Enum authType As Short
        totp = 0
        hotp = 1
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

    Private Sub BtnCreateQRCode_Click(sender As Object, e As EventArgs) Handles btnCreateQRCode.Click
        If String.IsNullOrWhiteSpace(txtSecret.Text) Then
            MsgBox("You must provide a secret, that's what is used to generate the digits required for your authenticator.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        If txtServiceName.Text.Equals("ex: Microsoft") Then txtServiceName.Text = Nothing
        If txtIssuer.Text.Equals("ex: Microsoft") Then txtIssuer.Text = Nothing
        If txtAccountName.Text.Equals("ex: someone@somedomain.com") Then txtAccountName.Text = Nothing

        serviceName = txtServiceName.Text.Trim
        accountName = txtAccountName.Text.Trim
        secret = txtSecret.Text.Trim
        issuer = txtIssuer.Text.Trim

        If radTOTP.Checked Then
            type = authType.totp
        Else
            type = authType.hotp
        End If

        If Not Short.TryParse(txtPeriod.Text, period) Then MsgBox("The period entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)
        If Not Short.TryParse(txtDigits.Text, digits) Then MsgBox("The digits entry field must contain a numerical value.", MsgBoxStyle.Critical, Me.Text)

        Me.Close()
        boolCreateQRCode = True
    End Sub

    Private Sub RadTOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radTOTP.CheckedChanged
        txtPeriod.Enabled = True
    End Sub

    Private Sub RadHOTP_CheckedChanged(sender As Object, e As EventArgs) Handles radHOTP.CheckedChanged
        txtPeriod.Enabled = False
    End Sub
End Class