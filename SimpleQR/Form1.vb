Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(Application.ExecutablePath & ".new.exe") Then
            Dim newFileDeleterThread As New Threading.Thread(Sub()
                                                                 searchForProcessAndKillIt(Application.ExecutablePath & ".new.exe")
                                                                 IO.File.Delete(Application.ExecutablePath & ".new.exe")
                                                             End Sub)
            newFileDeleterThread.Start()
        End If

        chkUseSSL.Checked = My.Settings.useSSL
        Me.Size = My.Settings.windowSize
    End Sub

    Sub generateQRCodeImage(text As String)
        Try
            Dim writer As New ZXing.BarcodeWriter
            With writer
                .Options.Width = 500
                .Options.Height = 500
                .Options.PureBarcode = True
                .Options.Margin = 0
                .Format = ZXing.BarcodeFormat.QR_CODE
            End With
            qrCodeImage.Image = ResizeImage(writer.Write(text), 200, 200)
            btnClipboard.Enabled = True
        Catch ex As ZXing.WriterException
            MsgBox("QRCode encoding error detected.", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Public Overloads Shared Function ResizeImage(SourceImage As Image, TargetWidth As Int32, TargetHeight As Int32) As Bitmap
        Dim bmSource As New Bitmap(SourceImage)
        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
    End Function

    Public Overloads Shared Function ResizeImage(bmSource As Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Bitmap
        Dim bmDest As New Bitmap(TargetWidth, TargetHeight, Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio As Integer = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio As Integer = bmDest.Width / bmDest.Height

        Dim NewX As Integer = 0
        Dim NewY As Integer = 0
        Dim NewWidth As Integer = bmDest.Width
        Dim NewHeight As Integer = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function

    Private Sub txtTextToEncode_TextChanged(sender As Object, e As EventArgs) Handles txtTextToEncode.TextChanged
        lblLength.Text = "Length: " & txtTextToEncode.TextLength

        If txtTextToEncode.TextLength = 0 Then
            qrCodeImage.Image = Nothing
            btnClipboard.Enabled = False
            btnSave.Enabled = False
        Else
            Try
                If Not String.IsNullOrWhiteSpace(txtTextToEncode.Text) Then
                    generateQRCodeImage(txtTextToEncode.Text)
                    btnSave.Enabled = True
                End If
            Catch ex As IndexOutOfRangeException
                MsgBox("Error generating QRCode Image.  Perhaps you entered too much data.", MsgBoxStyle.Critical, Me.Text)
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With SaveFileDialog1
            .Title = "Save QRCode Image to File"
            .Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|Windows Meta Image File|*.wmf"
            .FileName = ""
            .OverwritePrompt = True
        End With

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileFormat As Imaging.ImageFormat

            If SaveFileDialog1.FileName.ToLower.EndsWith(".png") Then
                fileFormat = Imaging.ImageFormat.Png
            ElseIf SaveFileDialog1.FileName.ToLower.EndsWith(".jpg") Then
                fileFormat = Imaging.ImageFormat.Jpeg
            ElseIf SaveFileDialog1.FileName.ToLower.EndsWith(".bmp") Then
                fileFormat = Imaging.ImageFormat.Bmp
            ElseIf SaveFileDialog1.FileName.ToLower.EndsWith(".gif") Then
                fileFormat = Imaging.ImageFormat.Gif
            ElseIf SaveFileDialog1.FileName.ToLower.EndsWith(".wmf") Then
                fileFormat = Imaging.ImageFormat.Wmf
            Else
                MsgBox("Invalid file type.", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            Dim writer As New ZXing.BarcodeWriter
            With writer
                .Options.PureBarcode = True
                .Options.Margin = 0
                .Options.Width = 500
                .Options.Height = 500
                .Format = ZXing.BarcodeFormat.QR_CODE
                .Write(txtTextToEncode.Text).Save(SaveFileDialog1.FileName, fileFormat)
            End With
            MsgBox("Image Saved.", MsgBoxStyle.Information, "Image Saved")
        End If
    End Sub

    Private Sub btnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles btnCheckForUpdates.Click
        Dim userInitiatedCheckForUpdatesThread As New Threading.Thread(Sub()
                                                                           Dim g As New Check_for_Update_Stuff(Me)
                                                                           g.checkForUpdates()
                                                                       End Sub) With {
            .Name = "User Initiated Check For Updates Thread",
            .Priority = Threading.ThreadPriority.Lowest
        }
        userInitiatedCheckForUpdatesThread.Start()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim version() As String = Application.ProductVersion.Split(".".ToCharArray) ' Gets the program version
        Dim stringBuilder As New StringBuilder

        With stringBuilder
            .AppendLine(Me.Text)
            .AppendLine("Written By Tom Parkison")
            .AppendLine("Copyright Thomas Parkison 2012-2015.")
            .AppendLine()
            .AppendFormat("Version {0}.{1} Build {2}", version(0), version(1), version(2))
        End With

        MsgBox(stringBuilder.ToString.Trim, MsgBoxStyle.Information, "About")
    End Sub

    Private Sub btnDecode_Click(sender As Object, e As EventArgs) Handles btnDecode.Click
        With OpenFileDialog1
            .Title = "Open QRCode Image to File"
            .Filter = "All Supported Image Formats|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.wmf|PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif|Windows Meta Image File|*.wmf"
            .FileName = ""
        End With

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using bitMap As New Bitmap(OpenFileDialog1.FileName)
                decodeFromImage(bitMap)
            End Using
        End If
    End Sub

    Private Sub btnClipboard_Click(sender As Object, e As EventArgs) Handles btnClipboard.Click
        Clipboard.SetImage(qrCodeImage.Image)
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        My.Settings.windowSize = Me.Size
    End Sub

    Private Sub chkUseSSL_Click(sender As Object, e As EventArgs) Handles chkUseSSL.Click
        My.Settings.useSSL = chkUseSSL.Checked
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDecodeFromScreenShot.Click
        If My.Settings.boolShowScreenshotTip Then
            Dim tipWindow As New Tip With {.Icon = Me.Icon, .StartPosition = FormStartPosition.CenterScreen}
            tipWindow.ShowDialog()
        End If

        Dim imgScreenShot As Image = SnippingTool.Snip()

        Dim decoder As New ZXing.BarcodeReader
        With decoder
            .Options.TryHarder = True
            .TryInverted = True
            .AutoRotate = True
        End With

        If imgScreenShot IsNot Nothing Then
            Dim result As ZXing.Result = decoder.Decode(imgScreenShot)

            If result Is Nothing Then
                MsgBox("There was an error while decoding your selected QRCode image.", MsgBoxStyle.Critical, Me.Text)
            Else
                Dim results As New frmDecoded With {.Icon = Me.Icon}
                With results
                    .txtResults.Text = result.Text
                    .StartPosition = FormStartPosition.CenterParent
                End With
                results.ShowDialog()
            End If

            imgScreenShot.Dispose()
        End If
    End Sub

    Private Sub btnQRCodeBuilder_Click(sender As Object, e As EventArgs) Handles btnQRCodeBuilder.Click
        Using QRCodeBuilderInstance As New QRCode_Builder With {.StartPosition = FormStartPosition.CenterParent, .Icon = Me.Icon}
            QRCodeBuilderInstance.ShowDialog()
            If Not String.IsNullOrWhiteSpace(QRCodeBuilderInstance.strQRCodeData) Then txtTextToEncode.Text = QRCodeBuilderInstance.strQRCodeData
        End Using
    End Sub

    Private Sub ContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip.Opening
        If qrCodeImage.Image Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub menuItemShowBiggerImage_Click(sender As Object, e As EventArgs) Handles menuItemShowBiggerImage.Click
        Using biggerImage As New bigImage With {.textToEncode = txtTextToEncode.Text, .Icon = Me.Icon}
            biggerImage.ShowDialog()
        End Using
    End Sub

    Private Sub txtTextToEncode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTextToEncode.KeyUp
        If e.KeyCode = Keys.Back And String.IsNullOrWhiteSpace(txtTextToEncode.Text) Then Media.SystemSounds.Exclamation.Play()
    End Sub

    Private Sub btnDecodeFromClipboard_Click(sender As Object, e As EventArgs) Handles btnDecodeFromClipboard.Click
        Using possibleQRCodeImage As Image = Clipboard.GetImage()
            If possibleQRCodeImage IsNot Nothing Then decodeFromImage(possibleQRCodeImage)
        End Using
    End Sub

    Private Sub decodeFromImage(ByRef image As Bitmap)
        Dim decoder As New ZXing.BarcodeReader

        With decoder
            .Options.TryHarder = True
            .Options.UseCode39ExtendedMode = True
            .Options.UseCode39RelaxedExtendedMode = True
            .Options.PureBarcode = True
            .TryInverted = True
            .AutoRotate = True
        End With

        If image IsNot Nothing Then
            Dim result As ZXing.Result = decoder.Decode(image)

            If result Is Nothing Then
                MsgBox("There was an error while decoding your selected QRCode image.", MsgBoxStyle.Critical, Me.Text)
            Else
                Dim results As New frmDecoded With {.Icon = Me.Icon}

                With results
                    .txtResults.Text = result.Text
                    .StartPosition = FormStartPosition.CenterParent
                End With

                results.ShowDialog()
            End If
        End If
    End Sub
End Class