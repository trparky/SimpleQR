Public Class Tip
    Private Sub Tip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkDontShowTipAgain.Checked = Not My.Settings.boolShowScreenshotTip
        PictureBox1.Image = SystemIcons.Exclamation.ToBitmap()
        Media.SystemSounds.Exclamation.Play()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.boolShowScreenshotTip = Not chkDontShowTipAgain.Checked
        Close()
    End Sub
End Class