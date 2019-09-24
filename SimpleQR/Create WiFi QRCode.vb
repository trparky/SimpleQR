Public Class Create_WiFi_QRCode
    Public Property boolCreateQRCode As Boolean = False
    Public Property strSSID As String
    Public Property strNetworkPassword As String
    Public Property netType As networkType

    Enum networkType As Short
        open = 0
        wep = 1
        wpa = 2
    End Enum

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCreateQRCode.Click
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

        strSSID = txtSSID.Text.Trim
        strNetworkPassword = txtNetworkPassword.Text.Trim

        Me.Close()
        boolCreateQRCode = True
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
End Class