Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form1
    Private Const programFileZIPURL = "www.toms-world.org/download/SimpleQR.zip"
    Private Const programFileZIPSHA1URL = "www.toms-world.org/download/SimpleQR.zip.sha1"
    Private Const programFileNameInZIP As String = "SimpleQR.exe"
    Private Const programUpdateCheckerXMLFile As String = "www.toms-world.org/updates/simpleqr_update.xml"
    Private boolWinXP As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(Application.ExecutablePath & ".new.exe") Then
            Dim newFileDeleterThread As New Threading.Thread(Sub()
                                                                 searchForProcessAndKillIt(Application.ExecutablePath & ".new.exe", False)
                                                                 IO.File.Delete(Application.ExecutablePath & ".new.exe")
                                                             End Sub)
            newFileDeleterThread.Start()
        End If

        If Environment.OSVersion.ToString.Contains("5.1") Or Environment.OSVersion.ToString.Contains("5.2") Then boolWinXP = True

        If Not boolWinXP Then
            chkUseSSL.Checked = My.Settings.useSSL
        Else
            chkUseSSL.Visible = False
        End If

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
            btnSave.Enabled = False
            btnShowBigger.Enabled = False
        Else
            Try
                generateQRCodeImage(txtTextToEncode.Text)
                btnSave.Enabled = True
                btnShowBigger.Enabled = True
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

    Private Function checkForInternetConnection() As Boolean
        Return My.Computer.Network.IsAvailable
    End Function

    Function convertLineFeeds(input As String) As String
        ' Checks to see if the file is in Windows linefeed format or UNIX linefeed format.
        If input.Contains(vbCrLf) Then
            Return input ' It's in Windows linefeed format so we return the output as is.
        Else
            Return input.Replace(vbLf, vbCrLf) ' It's in UNIX linefeed format so we have to convert it to Windows before we return the output.
        End If
    End Function

    Private Function verifyChecksum(ByVal urlOfChecksumFile As String, ByRef memoryStream As IO.MemoryStream, ByVal boolGiveUserAnErrorMessage As Boolean) As Boolean
        Dim checksumFromWeb As String = Nothing

        Dim httpHelper As httpHelper = createNewHTTPHelperObject()

        If Not httpHelper.getWebData(urlOfChecksumFile, checksumFromWeb, False) Then
            If boolGiveUserAnErrorMessage Then MsgBox("There was an error downloading the checksum verification file. Update process aborted.", MsgBoxStyle.Critical, "Restore Point Creator")
            Return False
        Else
            Dim regexObject As New Regex("([a-zA-Z0-9]{40})")

            ' Checks to see if we have a valid SHA1 file.
            If regexObject.IsMatch(checksumFromWeb) Then
                ' Now that we have a valid SHA1 file we need to parse out what we want.
                checksumFromWeb = regexObject.Match(checksumFromWeb).Groups(1).Value().ToLower.Trim()

                ' Now we do the actual checksum verification by passing the name of the file to the SHA160() function
                ' which calculates the checksum of the file on disk. We then compare it to the checksum from the web.
                If SHA160(memoryStream).Equals(checksumFromWeb, StringComparison.OrdinalIgnoreCase) Then
                    Return True ' OK, things are good; the file passed checksum verification so we return True.
                Else
                    ' The checksums don't match. Oops.
                    If boolGiveUserAnErrorMessage Then MsgBox("There was an error in the download, checksums don't match. Update process aborted.", MsgBoxStyle.Critical, "Restore Point Creator")
                    Return False
                End If
            Else
                If boolGiveUserAnErrorMessage Then MsgBox("Invalid SHA1 file detected. Update process aborted.", MsgBoxStyle.Critical, "Restore Point Creator")
                Return False
            End If
        End If
    End Function

    Private Function SHA160(ByRef memoryStream As IO.MemoryStream) As String
        Dim Output As Byte() = (New Security.Cryptography.SHA1CryptoServiceProvider).ComputeHash(memoryStream)
        Return BitConverter.ToString(Output).ToLower().Replace("-", "").Trim
    End Function

    Private Sub downloadAndPerformUpdate()
        Try
            Dim fileInfo As New IO.FileInfo(Application.ExecutablePath)
            Dim newExecutableName As String = fileInfo.Name & ".new.exe"
            Dim httpHelper As httpHelper = createNewHTTPHelperObject()

            Using memoryStream As New IO.MemoryStream
                If Not httpHelper.downloadFile(programFileZIPURL, memoryStream, False) Then
                    MsgBox("There was an error while downloading required files.", MsgBoxStyle.Critical, "SimpleQR")
                    Exit Sub
                End If

                If Not verifyChecksum(programFileZIPSHA1URL, memoryStream, True) Then Exit Sub

                fileInfo = Nothing
                memoryStream.Position = 0

                Using zipFileObject As New IO.Compression.ZipArchive(memoryStream)
                    extractFileFromZIPFile(zipFileObject, programFileNameInZIP, newExecutableName)
                End Using
            End Using

            If boolWinXP Then
                Process.Start(newExecutableName, "-update")
            Else
                Dim startInfo As New ProcessStartInfo With {.FileName = newExecutableName, .Arguments = "-update"}
                If Not canIWriteToTheCurrentDirectory() Then startInfo.Verb = "runas"
                Process.Start(startInfo)
                Process.GetCurrentProcess.Kill()
            End If

            Me.Close()
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub extractFileFromZIPFile(ByRef zipFileObject As IO.Compression.ZipArchive, fileToExtract As String, fileToWriteExtractedFileTo As String)
        Dim zipFileEntryObject As IO.Compression.ZipArchiveEntry = zipFileObject.GetEntry(fileToExtract)

        If zipFileEntryObject IsNot Nothing Then
            Using fileStream As New IO.FileStream(fileToWriteExtractedFileTo, IO.FileMode.Create)
                zipFileEntryObject.Open.CopyTo(fileStream)
            End Using
        End If
    End Sub

    Private Sub btnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles btnCheckForUpdates.Click
        Dim userInitiatedCheckForUpdatesThread As New Threading.Thread(AddressOf userInitiatedCheckForUpdates) With {
            .Name = "User Initiated Check For Updates Thread",
            .Priority = Threading.ThreadPriority.Lowest
        }
        userInitiatedCheckForUpdatesThread.Start()
    End Sub

    ''' <summary>Converts a Dictionary of Strings into a String ready to be POSTed to a URL.</summary>
    ''' <param name="postData">A Dictionary(Of String, String) containing the data needed to by POSTed to a web server.</param>
    ''' <returns>Returns a String value containing the POST data.</returns>
    Function getPostDataString(postData As Dictionary(Of String, String)) As String
        Dim postDataString As String = ""
        For Each entry As KeyValuePair(Of String, String) In postData
            postDataString &= entry.Key.Trim & "=" & Web.HttpUtility.UrlEncode(entry.Value.Trim) & "&"
        Next

        If postDataString.EndsWith("&") Then
            postDataString = postDataString.Substring(0, postDataString.Length - 1)
        End If

        Return postDataString
    End Function

    Sub userInitiatedCheckForUpdates()
        Invoke(Sub() btnCheckForUpdates.Enabled = False)

        If Not checkForInternetConnection() Then
            MsgBox("No Internet connection detected.", MsgBoxStyle.Information, Me.Text)
        Else
            Try
                Dim version() As String = Application.ProductVersion.Split(".".ToCharArray) ' Gets the program version

                Dim majorVersion As Short = Short.Parse(version(0))
                Dim minorVersion As Short = Short.Parse(version(1))
                Dim buildVersion As Short = Short.Parse(version(2))
                Dim remoteVersion As String = Nothing
                Dim remoteBuild As String = Nothing

                Dim httpHelper As httpHelper = createNewHTTPHelperObject()

                Dim xmlData As String = Nothing

                If httpHelper.getWebData(programUpdateCheckerXMLFile, xmlData, False) = True Then
                    If processUpdateXMLData(xmlData, remoteVersion, remoteBuild) Then
                        If MsgBox("Are you sure you want to download the newest version of " & Me.Text & "?" & vbCrLf & vbCrLf & "The new version is " & remoteVersion & " Build " & remoteBuild & ".", MsgBoxStyle.Question + vbYesNo, Me.Text) = MsgBoxResult.Yes Then
                            createPleaseWaitWindow("Downloading update... Please Wait.")
                            downloadAndPerformUpdate()
                            openPleaseWaitWindow()
                        Else
                            MsgBox("You have chosen not to update to the newest version.", MsgBoxStyle.Information, Me.Text)
                        End If
                    Else
                        MsgBox("You already have the latest version.", MsgBoxStyle.Information, Me.Text)
                    End If
                Else
                    Invoke(Sub() btnCheckForUpdates.Enabled = True)
                    MsgBox("There was an error checking for updates.", MsgBoxStyle.Information, Me.Text)
                End If
            Catch ex As Exception
                ' Ok, we crashed but who cares.  We give an error message.
            Finally
                Invoke(Sub() btnCheckForUpdates.Enabled = True)
            End Try
        End If
    End Sub

    Private frmPleaseWait As Please_Wait
    Private pleaseWaitWindowThread As Threading.Thread

    Private Sub openPleaseWaitWindow()
        Try
            frmPleaseWait.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub createPleaseWaitWindow(message As String, Optional ByVal openDialog As Boolean = False)
        Try
            frmPleaseWait = New Please_Wait With {.StartPosition = FormStartPosition.CenterParent}
            With frmPleaseWait
                .lblLabel.Text = message
                .lblLabelText = message
                .Icon = Me.Icon
                .TopMost = True
            End With

            If openDialog Then
                pleaseWaitWindowThread = New Threading.Thread(AddressOf openPleaseWaitWindow)
                pleaseWaitWindowThread.Start()
            End If
        Catch ex As Exception
        End Try
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
            Dim decoder As New ZXing.BarcodeReader

            With decoder
                .Options.TryHarder = True
                .Options.UseCode39ExtendedMode = True
                .Options.UseCode39RelaxedExtendedMode = True
                .Options.PureBarcode = True
                .TryInverted = True
                .AutoRotate = True
            End With

            Dim bitMap As New Bitmap(OpenFileDialog1.FileName)

            If bitMap IsNot Nothing Then
                Dim result As ZXing.Result = decoder.Decode(bitMap)
                qrCodeImage.Image = bitMap

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

                bitMap.Dispose()
            End If
        End If
    End Sub

    Private Sub btnClipboard_Click(sender As Object, e As EventArgs) Handles btnClipboard.Click
        Clipboard.SetImage(qrCodeImage.Image)
    End Sub

    Private Sub btnShowBigger_Click(sender As Object, e As EventArgs) Handles btnShowBigger.Click
        Dim biggerImage As New bigImage With {.textToEncode = txtTextToEncode.Text, .Icon = Me.Icon}
        biggerImage.Show()
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
        Dim QRCodeBuilderInstance As New QRCode_Builder With {.StartPosition = FormStartPosition.CenterParent, .Icon = Me.Icon}
        QRCodeBuilderInstance.ShowDialog()
        If QRCodeBuilderInstance.boolCreateQRCode Then txtTextToEncode.Text = QRCodeBuilderInstance.strQRCodeData
    End Sub
End Class