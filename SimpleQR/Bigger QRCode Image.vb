Public Class BigImage
    Public textToEncode As String

    Sub GenerateImage()
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
    End Sub

    Private Sub BigImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = My.Settings.biggerWindowSize
        GenerateImage()
    End Sub

    Private Sub BigImage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GenerateImage()
    End Sub

    Private Sub BigImage_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        My.Settings.biggerWindowSize = Me.Size
    End Sub

    Private Sub CopyImageToWindowsClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyImageToWindowsClipboardToolStripMenuItem.Click
        Clipboard.SetImage(qrCodeImage.Image)
    End Sub
End Class