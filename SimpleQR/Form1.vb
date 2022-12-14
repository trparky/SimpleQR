Imports System.Text

Public Class Form1
    Private Const strMessageBoxTitle As String = "SimpleQR"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists($"{Application.ExecutablePath}.new.exe") Then
            Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                       SearchForProcessAndKillIt($"{Application.ExecutablePath}.new.exe", True)
                                                       IO.File.Delete($"{Application.ExecutablePath}.new.exe")
                                                   End Sub)
        End If

        Size = My.Settings.windowSize
    End Sub

    Public Overloads Shared Function ResizeImage(SourceImage As Image, TargetWidth As Integer, TargetHeight As Integer) As Bitmap
        Dim bmSource As New Bitmap(SourceImage)
        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
    End Function

    Public Overloads Shared Function ResizeImage(bmSource As Bitmap, TargetWidth As Integer, TargetHeight As Integer) As Bitmap
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

    Private Sub TxtTextToEncode_TextChanged(sender As Object, e As EventArgs) Handles txtTextToEncode.TextChanged
        lblLength.Text = $"Length: {txtTextToEncode.TextLength}"

        If String.IsNullOrWhiteSpace(txtTextToEncode.Text) Then
            qrCodeImage.Image = Nothing
        Else
            Try
                Dim writer As New ZXing.BarcodeWriter
                With writer
                    .Options.Width = 200
                    .Options.Height = 200
                    .Options.PureBarcode = True
                    .Options.Margin = 0
                    .Format = ZXing.BarcodeFormat.QR_CODE
                End With
                qrCodeImage.Image = writer.Write(txtTextToEncode.Text)
            Catch ex As ZXing.WriterException
                MsgBox("An error occurred while generating a QRCode image.", MsgBoxStyle.Critical, strMessageBoxTitle)
            End Try
        End If
    End Sub

    Private Sub MenuItemSaveImage_Click(sender As Object, e As EventArgs) Handles menuItemSaveImage.Click
        With SaveFileDialog1
            .Title = "Save QRCode Image to File"
            .Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|Windows Meta Image File|*.wmf"
            .FileName = ""
            .OverwritePrompt = True
        End With

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileFormat As Imaging.ImageFormat

            If SaveFileDialog1.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) Then
                fileFormat = Imaging.ImageFormat.Png
            ElseIf SaveFileDialog1.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) Then
                fileFormat = Imaging.ImageFormat.Jpeg
            ElseIf SaveFileDialog1.FileName.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) Then
                fileFormat = Imaging.ImageFormat.Bmp
            ElseIf SaveFileDialog1.FileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) Then
                fileFormat = Imaging.ImageFormat.Gif
            ElseIf SaveFileDialog1.FileName.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase) Then
                fileFormat = Imaging.ImageFormat.Wmf
            Else
                MsgBox("Invalid file type.", MsgBoxStyle.Critical, strMessageBoxTitle)
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
            MsgBox("Image Saved.", MsgBoxStyle.Information, strMessageBoxTitle)
        End If
    End Sub

    Private Sub BtnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles btnCheckForUpdates.Click
        Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                   Dim g As New CheckForUpdatesClass(Me)
                                                   g.CheckForUpdates()
                                               End Sub)
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim version() As String = Application.ProductVersion.Split(".".ToCharArray) ' Gets the program version
        Dim stringBuilder As New StringBuilder

        With stringBuilder
            .AppendLine(Text)
            .AppendLine("Written By Tom Parkison")
            .AppendLine("Copyright Thomas Parkison 2012-2023.")
            .AppendLine()
            .AppendFormat("Version {0}.{1} Build {2}", version(0), version(1), version(2))
        End With

        MsgBox(stringBuilder.ToString.Trim, MsgBoxStyle.Information, $"About {Text}")
    End Sub

    Private Sub BtnDecode_Click(sender As Object, e As EventArgs) Handles btnDecode.Click
        With OpenFileDialog1
            .Title = "Open QRCode Image to File"
            .Filter = "All Supported Image Formats|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.wmf|PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif|Windows Meta Image File|*.wmf"
            .FileName = ""
        End With

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using bitMap As New Bitmap(OpenFileDialog1.FileName)
                DecodeFromImage(bitMap)
            End Using
        End If
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim incomingDataArray As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())

        If incomingDataArray.Length = 1 Then
            Dim strFileName As String = incomingDataArray(0)

            If IO.File.Exists(strFileName) Then
                Dim strFileExtension As String = New IO.FileInfo(strFileName).Extension

                If strFileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase) Or
                strFileExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) Or
                strFileExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) Or
                strFileExtension.Equals(".bmp", StringComparison.OrdinalIgnoreCase) Or
                strFileExtension.Equals(".gif", StringComparison.OrdinalIgnoreCase) Or
                strFileExtension.Equals(".wmf", StringComparison.OrdinalIgnoreCase) Then
                    Using bitMap As New Bitmap(strFileName)
                        DecodeFromImage(bitMap)
                    End Using
                Else
                    MsgBox($"Invalid file type provided via Drag Drop event.{vbCrLf}{vbCrLf}The only supported file types are PNG, JPG/JPEG, BMP, GIF, and WMF file types.", MsgBoxStyle.Critical, strMessageBoxTitle)
                End If
            End If
        Else
            MsgBox("Invalid data provided via Drag Drop event.", MsgBoxStyle.Critical, strMessageBoxTitle)
            Exit Sub
        End If
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop), DragDropEffects.All, DragDropEffects.None)
    End Sub

    Private Sub MenuItemCopyImageToWindowsClipboard_Click(sender As Object, e As EventArgs) Handles menuItemCopyImageToWindowsClipboard.Click
        Clipboard.SetImage(qrCodeImage.Image)
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        My.Settings.windowSize = Size
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Width <> 543 Then Width = 543
    End Sub

    Private Sub BtnDecodeFromScreenShot_Click(sender As Object, e As EventArgs) Handles btnDecodeFromScreenShot.Click
        If My.Settings.boolShowScreenshotTip Then
            Dim tipWindow As New Tip With {.Icon = Icon, .StartPosition = FormStartPosition.CenterScreen}
            tipWindow.ShowDialog()
        End If

        Dim imgScreenShot As Image = SnippingTool.Snip()

        Dim decoder As New ZXing.BarcodeReader
        With decoder
            .Options.TryHarder = True
            .Options.TryInverted = True
            .AutoRotate = True
        End With

        If imgScreenShot IsNot Nothing Then
            Dim result As ZXing.Result = decoder.Decode(imgScreenShot)

            If result Is Nothing Then
                MsgBox("There was an error while decoding your selected QRCode image.", MsgBoxStyle.Critical, strMessageBoxTitle)
            Else
                Dim results As New frmDecoded With {.Icon = Icon}
                With results
                    .txtResults.Text = result.Text
                    .StartPosition = FormStartPosition.CenterParent
                End With
                results.ShowDialog()
            End If

            imgScreenShot.Dispose()
        End If
    End Sub

    Private Sub BtnQRCodeBuilder_Click(sender As Object, e As EventArgs) Handles btnQRCodeBuilder.Click
        Using QRCodeBuilderInstance As New QRCode_Builder With {.StartPosition = FormStartPosition.CenterParent, .Icon = Icon}
            QRCodeBuilderInstance.ShowDialog()
            If Not String.IsNullOrWhiteSpace(QRCodeBuilderInstance.StrQRCodeData) Then txtTextToEncode.Text = QRCodeBuilderInstance.StrQRCodeData
        End Using
    End Sub

    Private Sub ContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip.Opening
        If qrCodeImage.Image Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub MenuItemShowBiggerImage_Click(sender As Object, e As EventArgs) Handles menuItemShowBiggerImage.Click
        Using biggerImage As New BigImage With {.textToEncode = txtTextToEncode.Text, .Icon = Icon}
            biggerImage.ShowDialog()
        End Using
    End Sub

    Private Sub TxtTextToEncode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTextToEncode.KeyUp
        If e.KeyCode = Keys.Back And String.IsNullOrWhiteSpace(txtTextToEncode.Text) Then Media.SystemSounds.Exclamation.Play()
    End Sub

    Private Sub BtnDecodeFromClipboard_Click(sender As Object, e As EventArgs) Handles btnDecodeFromClipboard.Click
        Using possibleQRCodeImage As Image = Clipboard.GetImage()
            If possibleQRCodeImage IsNot Nothing Then
                DecodeFromImage(possibleQRCodeImage)
            Else
                MsgBox("Invalid data on Windows clipboard. Make sure you have an image on your clipboard.", MsgBoxStyle.Information, strMessageBoxTitle)
            End If
        End Using
    End Sub

    Private Sub DecodeFromImage(ByRef image As Bitmap)
        Dim decoder As New ZXing.BarcodeReader

        With decoder
            .Options.TryHarder = True
            .Options.UseCode39ExtendedMode = True
            .Options.UseCode39RelaxedExtendedMode = True
            .Options.TryInverted = True
            .AutoRotate = True
        End With

        If image IsNot Nothing Then
            Dim result As ZXing.Result = decoder.Decode(image)

            If result Is Nothing Then
                MsgBox("There was an error while decoding your selected QRCode image.", MsgBoxStyle.Critical, strMessageBoxTitle)
            Else
                Dim results As New frmDecoded With {.Icon = Icon}

                With results
                    .txtResults.Text = result.Text
                    .StartPosition = FormStartPosition.CenterParent
                End With

                results.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' This is to work around a bug in Windows 10 in which the Start Menu doesn't close when launching a .NET program from the Start Menu.
        If Environment.OSVersion.Version.Major = 10 Or Environment.OSVersion.Version.Major = 11 Then
            NativeMethod.NativeMethods.keybd_event(NativeMethod.NativeMethods.ESC, 0, 0, 0)
            NativeMethod.NativeMethods.keybd_event(NativeMethod.NativeMethods.ESC, 0, NativeMethod.NativeMethods.UP, 0)
        End If
    End Sub
End Class