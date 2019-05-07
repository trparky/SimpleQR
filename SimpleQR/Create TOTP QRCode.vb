Public Class Create_TOTP_QRCode
    Public Property serviceName As String
    Public Property accountName As String
    Public Property secret As String
    Public Property issuer As String
    Public Property boolCreateQRCode As Boolean = False

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

        Me.Close()
        boolCreateQRCode = True
    End Sub
End Class