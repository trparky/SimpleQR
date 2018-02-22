Public Class bigImage
    Public textToEncode As String

    Sub generateImage()
        Try
            Dim writer As New ZXing.BarcodeWriter
            writer.Options.Width = qrCodeImage.Size.Width
            writer.Options.Height = qrCodeImage.Size.Height
            writer.Options.PureBarcode = True
            writer.Options.Margin = 0
            writer.Format = ZXing.BarcodeFormat.QR_CODE
            qrCodeImage.Image = writer.Write(textToEncode)
        Catch ex As ArgumentException
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bigImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = My.Settings.biggerWindowSize
        generateImage()
    End Sub

    Private Sub bigImage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        generateImage()
    End Sub

    Private Sub bigImage_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        My.Settings.biggerWindowSize = Me.Size
    End Sub
End Class