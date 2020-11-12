Public Class frmDecoded
    Private Sub BtnClipboard_Click(sender As Object, e As EventArgs) Handles btnClipboard.Click
        Clipboard.SetText(txtResults.Text)
    End Sub
End Class