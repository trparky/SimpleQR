Public Class frmDecoded
    Private Sub btnClipboard_Click(sender As Object, e As EventArgs) Handles btnClipboard.Click
        Clipboard.SetText(txtResults.Text)
    End Sub
End Class