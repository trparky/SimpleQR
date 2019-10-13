Imports System.Runtime.CompilerServices
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Xml

Module ScreenSnipper
    ' PHP like addSlashes and stripSlashes. Call using String.addSlashes() and String.stripSlashes().
    <Extension()>
    Public Function addSlashes(unsafeString As String) As String
        Return Regex.Replace(unsafeString, "([\000\010\011\012\015\032\042\047\134\140])", "\$1")
    End Function

    <Extension()>
    Public Function caseInsensitiveContains(haystack As String, needle As String, Optional boolDoEscaping As Boolean = False) As Boolean
        Try
            If boolDoEscaping Then needle = Regex.Escape(needle)
            Return Regex.IsMatch(haystack, needle, RegexOptions.IgnoreCase)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private ReadOnly versionInfo As String() = Application.ProductVersion.Split(".")
    Private ReadOnly shortBuild As Short = Short.Parse(versionInfo(versionPieces.build).Trim)

    Private ReadOnly versionStringWithoutBuild As String = String.Format("{0}.{1}", versionInfo(versionPieces.major), versionInfo(versionPieces.minor))

    ''' <summary>This parses the XML updata data and determines if an update is needed.</summary>
    ''' <param name="xmlData">The XML data from the web site.</param>
    ''' <returns>A Boolean value indicating if the program has been updated or not.</returns>
    Public Function processUpdateXMLData(ByVal xmlData As String, ByRef remoteVersion As String, ByRef remoteBuild As String) As Boolean
        Try
            Dim xmlDocument As New XmlDocument() ' First we create an XML Document Object.
            xmlDocument.Load(New IO.StringReader(xmlData)) ' Now we try and parse the XML data.

            Dim xmlNode As XmlNode = xmlDocument.SelectSingleNode("/xmlroot")

            remoteVersion = xmlNode.SelectSingleNode("version").InnerText.Trim
            remoteBuild = xmlNode.SelectSingleNode("build").InnerText.Trim
            Dim shortRemoteBuild As Short

            ' This checks to see if current version and the current build matches that of the remote values in the XML document.
            If remoteVersion.Equals(versionStringWithoutBuild) And remoteBuild.Equals(shortBuild.ToString) Then
                ' Both the remoteVersion and the remoteBuild equals that of the current version,
                ' therefore we return a False value indicating no update is required.
                Return False
            Else
                ' First we do a check of the version, if it's not equal we simply return a True value.
                If Not remoteVersion.Equals(versionStringWithoutBuild) Then
                    ' We return a True value indicating that there is a new version to download and install.
                    Return True
                Else
                    ' Now let's do some sanity checks here. 
                    If Short.TryParse(remoteBuild, shortRemoteBuild) Then
                        If shortRemoteBuild < shortBuild Then
                            ' This is weird, the remote build is less than the current build. Something went wrong. So to be safe we're going to return a False value indicating that there is no update to download. Better to be safe.
                            Return False
                        ElseIf shortRemoteBuild.Equals(shortBuild) Then
                            ' The build numbers match, therefore therefore we return a False value.
                            Return False
                        End If
                    Else
                        ' Something went wrong, we couldn't parse the value of the remoteBuild number so we return a False value.
                        Return False
                    End If

                    ' We return a True value indicating that there is a new version to download and install.
                    Return True
                End If
            End If
        Catch ex As Exception
            ' Something went wrong so we return a False value.
            Return False
        End Try
    End Function

    ''' <summary>Checks to see if a Process ID or PID exists on the system.</summary>
    ''' <param name="PID">The PID of the process you are checking the existance of.</param>
    ''' <param name="processObject">If the PID does exist, the function writes back to this argument in a ByRef way a Process Object that can be interacted with outside of this function.</param>
    ''' <returns>Return a Boolean value. If the PID exists, it return a True value. If the PID doesn't exist, it returns a False value.</returns>
    Private Function doesProcessIDExist(ByVal PID As Integer, ByRef processObject As Process) As Boolean
        Try
            processObject = Process.GetProcessById(PID)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub killProcess(processID As Integer)
        Dim processObject As Process = Nothing

        ' First we are going to check if the Process ID exists.
        If doesProcessIDExist(processID, processObject) Then
            Try
                processObject.Kill() ' Yes, it does so let's kill it.
            Catch ex As Exception
                ' Wow, it seems that even with double-checking if a process exists by it's PID number things can still go wrong.
                ' So this Try-Catch block is here to trap any possible errors when trying to kill a process by it's PID number.
            End Try
        End If

        Threading.Thread.Sleep(250) ' We're going to sleep to give the system some time to kill the process.

        '' Now we are going to check again if the Process ID exists and if it does, we're going to attempt to kill it again.
        If doesProcessIDExist(processID, processObject) Then
            Try
                processObject.Kill()
            Catch ex As Exception
                ' Wow, it seems that even with double-checking if a process exists by it's PID number things can still go wrong.
                ' So this Try-Catch block is here to trap any possible errors when trying to kill a process by it's PID number.
            End Try
        End If

        Threading.Thread.Sleep(250) ' We're going to sleep (again) to give the system some time to kill the process.
    End Sub

    Private Function getProcessExecutablePath(processID As Integer) As String
        Dim memoryBuffer As New Text.StringBuilder(1024)
        Dim processHandle As IntPtr = NativeMethod.NativeMethods.OpenProcess(NativeMethod.ProcessAccessFlags.PROCESS_QUERY_LIMITED_INFORMATION, False, processID)

        If processHandle <> IntPtr.Zero Then
            Try
                Dim memoryBufferSize As Integer = memoryBuffer.Capacity

                If NativeMethod.NativeMethods.QueryFullProcessImageName(processHandle, 0, memoryBuffer, memoryBufferSize) Then
                    Return memoryBuffer.ToString()
                End If
            Finally
                NativeMethod.NativeMethods.CloseHandle(processHandle)
            End Try
        End If

        NativeMethod.NativeMethods.CloseHandle(processHandle)
        Return Nothing
    End Function

    Public Sub searchForProcessAndKillIt(strFileName As String, boolFullFilePathPassed As Boolean)
        Dim processExecutablePath As String
        Dim processExecutablePathFileInfo As IO.FileInfo

        For Each process As Process In Process.GetProcesses()
            processExecutablePath = getProcessExecutablePath(process.Id)

            If processExecutablePath IsNot Nothing Then
                Try
                    processExecutablePathFileInfo = New IO.FileInfo(processExecutablePath)

                    If boolFullFilePathPassed Then
                        If strFileName.Equals(processExecutablePathFileInfo.FullName, StringComparison.OrdinalIgnoreCase) Then
                            killProcess(process.Id)
                        End If
                    Else
                        If strFileName.Equals(processExecutablePathFileInfo.Name, StringComparison.OrdinalIgnoreCase) Then
                            killProcess(process.Id)
                        End If
                    End If
                Catch ex As ArgumentException
                End Try
            End If
        Next
    End Sub

    ''' <summary>Creates a User Agent String for this program to be used in HTTP requests.</summary>
    ''' <returns>String type.</returns>
    Private Function createHTTPUserAgentHeaderString() As String
        Dim versionInfo As String() = Application.ProductVersion.Split(".")
        Dim versionString As String = String.Format("{0}.{1} Build {2}", versionInfo(0), versionInfo(1), versionInfo(2))
        Return String.Format("SimpleQR version {0} on {1}", versionString, getFullOSVersionString())
    End Function

    Private Function getFullOSVersionString() As String
        Dim strOSName As String

        Try
            Dim intOSMajorVersion As Integer = Environment.OSVersion.Version.Major
            Dim intOSMinorVersion As Integer = Environment.OSVersion.Version.Minor

            If intOSMajorVersion = 5 And intOSMinorVersion = 0 Then
                strOSName = "Windows 2000"
            ElseIf intOSMajorVersion = 5 And intOSMinorVersion = 1 Then
                strOSName = "Windows XP"
            ElseIf intOSMajorVersion = 6 And intOSMinorVersion = 0 Then
                strOSName = "Windows Vista"
            ElseIf intOSMajorVersion = 6 And intOSMinorVersion = 1 Then
                strOSName = "Windows 7"
            ElseIf intOSMajorVersion = 6 And intOSMinorVersion = 2 Then
                strOSName = "Windows 8"
            ElseIf intOSMajorVersion = 6 And intOSMinorVersion = 3 Then
                strOSName = "Windows 8.1"
            ElseIf intOSMajorVersion = 10 Then
                strOSName = "Windows 10"
            Else
                strOSName = String.Format("Windows NT {0}.{1}", intOSMajorVersion, intOSMinorVersion)
            End If

            If Environment.Is64BitOperatingSystem Then
                strOSName &= " 64-bit"
            Else
                strOSName &= " 32-bit"
            End If
        Catch ex As Exception
            Try
                Return "Unknown Windows Operating System (" & Environment.OSVersion.VersionString & ")"
            Catch ex2 As Exception
                Return "Unknown Windows Operating System"
            End Try
        End Try

        Try
            strOSName &= String.Format(" (Microsoft .NET {0}.{1})", Environment.Version.Major, Environment.Version.Minor)
        Catch ex As Exception
            strOSName &= " (Unknown Microsoft .NET Version)"
        End Try

        Return strOSName
    End Function

    Public Function createNewHTTPHelperObject() As httpHelper
        Dim httpHelper As New httpHelper With {.setUserAgent = createHTTPUserAgentHeaderString()}
        With httpHelper
            .addHTTPHeader("OPERATING_SYSTEM", getFullOSVersionString())
            .useHTTPCompression = True
            .setProxyMode = True
            .setHTTPTimeout = 60
        End With

        httpHelper.setURLPreProcessor = Function(ByVal strURLInput As String) As String
                                            Try
                                                If Not strURLInput.Trim.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then
                                                    Return If(My.Settings.useSSL, "https://", "http://") & strURLInput
                                                Else
                                                    Return strURLInput
                                                End If
                                            Catch ex As Exception
                                                Return strURLInput
                                            End Try
                                        End Function

        httpHelper.setCustomErrorHandler = Function(ex As Exception, classInstance As httpHelper) As Boolean
                                               If TypeOf ex Is Net.WebException Then
                                                   MsgBox("The server responded with an HTTP error.", MsgBoxStyle.Critical, "Restore Point Creator")
                                               Else
                                                   MsgBox("A general HTTP error occured.", MsgBoxStyle.Critical, "Restore Point Creator")
                                               End If

                                               Return True
                                           End Function

        Return httpHelper
    End Function

    Public Function areWeAnAdministrator() As Boolean
        Try
            Dim principal As WindowsPrincipal = New WindowsPrincipal(WindowsIdentity.GetCurrent())
            Return If(principal.IsInRole(WindowsBuiltInRole.Administrator), True, False)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function canIWriteToTheCurrentDirectory() As Boolean
        Return canIWriteThere(New IO.FileInfo(Application.ExecutablePath).DirectoryName)
    End Function

    Private Function randomString(length As Integer) As String
        Dim random As Random = New Random()
        Dim builder As New Text.StringBuilder()
        Dim ch As Char
        Dim legalCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890"

        For cntr As Integer = 0 To length
            ch = legalCharacters.Substring(random.Next(0, legalCharacters.Length), 1)
            builder.Append(ch)
        Next

        Return builder.ToString()
    End Function

    Private Function canIWriteThere(folderPath As String) As Boolean
        ' We make sure we get valid folder path by taking off the leading slash.
        If folderPath.EndsWith("\") Then
            folderPath = folderPath.Substring(0, folderPath.Length - 1)
        End If

        If String.IsNullOrEmpty(folderPath) Or Not IO.Directory.Exists(folderPath) Then
            Return False
        End If

        If checkByFolderACLs(folderPath) Then
            Try
                Dim strRandomFileName As String = randomString(15) & ".txt"
                IO.File.Create(IO.Path.Combine(folderPath, strRandomFileName), 1, IO.FileOptions.DeleteOnClose).Close()
                If IO.File.Exists(IO.Path.Combine(folderPath, strRandomFileName)) Then IO.File.Delete(IO.Path.Combine(folderPath, strRandomFileName))
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Private Function checkByFolderACLs(folderPath As String) As Boolean
        Try
            Dim directoryACLs As DirectorySecurity = IO.Directory.GetAccessControl(folderPath)
            Dim directoryUsers As String = WindowsIdentity.GetCurrent.User.Value
            Dim directoryAccessRights As FileSystemAccessRule
            Dim fileSystemRights As FileSystemRights

            For Each rule As AuthorizationRule In directoryACLs.GetAccessRules(True, True, GetType(SecurityIdentifier))
                If rule.IdentityReference.Value = directoryUsers Then
                    directoryAccessRights = DirectCast(rule, FileSystemAccessRule)

                    If directoryAccessRights.AccessControlType = Security.AccessControl.AccessControlType.Allow Then
                        fileSystemRights = directoryAccessRights.FileSystemRights

                        If fileSystemRights = (FileSystemRights.Read Or FileSystemRights.Modify Or FileSystemRights.Write Or FileSystemRights.FullControl) Then
                            Return True
                        End If
                    End If
                End If
            Next

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module

Public Enum versionPieces As Short
    major = 0
    minor = 1
    build = 2
    revision = 3
End Enum