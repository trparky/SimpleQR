Public Class BigImage
    Public textToEncode As String

    Sub GenerateImage()
        If Not String.IsNullOrWhiteSpace(textToEncode) Then
            Try
                Dim writer As New ZXing.BarcodeWriter
                With writer
                    .Options.Width = qrCodeImage.Size.Width
                    .Options.Height = qrCodeImage.Size.Height
                    .Options.PureBarcode = True
                    .Options.Margin = 0
                    .Format = ZXing.BarcodeFormat.QR_CODE
                    qrCodeImage.Image = .Write(textToEncode)
                End With
            Catch ex As ArgumentException
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BigImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Size = My.Settings.biggerWindowSize
        GenerateImage()
    End Sub

    Private Sub BigImage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GenerateImage()
    End Sub

    Private Sub BigImage_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        My.Settings.biggerWindowSize = Size
    End Sub

    Private Sub CopyImageToWindowsClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyImageToWindowsClipboardToolStripMenuItem.Click
        Clipboard.SetImage(qrCodeImage.Image)
    End Sub

    Private Sub SaveImageToDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveImageToDiskToolStripMenuItem.Click
        With SaveFileDialog
            .Title = "Save QRCode Image to File"
            .Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|Windows Meta Image File|*.wmf"
            .FileName = ""
            .OverwritePrompt = True
        End With

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim fileFormat As Imaging.ImageFormat

            If SaveFileDialog.FileName.ToLower.EndsWith(".png") Then
                fileFormat = Imaging.ImageFormat.Png
            ElseIf SaveFileDialog.FileName.ToLower.EndsWith(".jpg") Then
                fileFormat = Imaging.ImageFormat.Jpeg
            ElseIf SaveFileDialog.FileName.ToLower.EndsWith(".bmp") Then
                fileFormat = Imaging.ImageFormat.Bmp
            ElseIf SaveFileDialog.FileName.ToLower.EndsWith(".gif") Then
                fileFormat = Imaging.ImageFormat.Gif
            ElseIf SaveFileDialog.FileName.ToLower.EndsWith(".wmf") Then
                fileFormat = Imaging.ImageFormat.Wmf
            Else
                MsgBox("Invalid file type.", MsgBoxStyle.Critical, "SimpleQR")
                Exit Sub
            End If

            Dim writer As New ZXing.BarcodeWriter
            With writer
                .Options.PureBarcode = True
                .Options.Margin = 0
                .Options.Width = qrCodeImage.Size.Width
                .Options.Height = qrCodeImage.Size.Height
                .Format = ZXing.BarcodeFormat.QR_CODE
                .Write(textToEncode).Save(SaveFileDialog.FileName, fileFormat)
            End With
            MsgBox("Image Saved.", MsgBoxStyle.Information, "SimpleQR")
        End If
    End Sub
End Class