Public Class Tip
    Private Sub Tip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkDontShowTipAgain.Checked = If(My.Settings.boolShowScreenshotTip, False, True)
        PictureBox1.Image = SystemIcons.Exclamation.ToBitmap()
        Media.SystemSounds.Exclamation.Play()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.boolShowScreenshotTip = If(chkDontShowTipAgain.Checked, False, True)
        Me.Close()
    End Sub
End Class