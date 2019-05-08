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
            If boolDoEscaping = True Then needle = Regex.Escape(needle)
            Return Regex.IsMatch(haystack, needle, RegexOptions.IgnoreCase)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function doesPIDExist(PID As Integer) As Boolean
        Try
            Dim searcher As New Management.ManagementObjectSearcher("root\CIMV2", String.Format("Select * FROM Win32_Process WHERE ProcessId={0}", PID))

            If searcher.Get.Count = 0 Then
                searcher.Dispose()
                Return False
            Else
                searcher.Dispose()
                Return True
            End If
        Catch ex3 As Runtime.InteropServices.COMException
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private versionInfo As String() = Application.ProductVersion.Split(".")
    Private shortMajor As Short = Short.Parse(versionInfo(versionPieces.major).Trim)
    Private shortMinor As Short = Short.Parse(versionInfo(versionPieces.minor).Trim)
    Private shortBuild As Short = Short.Parse(versionInfo(versionPieces.build).Trim)

    Private versionStringWithoutBuild As String = String.Format("{0}.{1}", versionInfo(versionPieces.major), versionInfo(versionPieces.minor))

    ''' <summary>This parses the XML updata data and determines if an update is needed.</summary>
    ''' <param name="xmlData">The XML data from the web site.</param>
    ''' <returns>A Boolean value indicating if the program has been updated or not.</returns>
    Public Function processUpdateXMLData(ByVal xmlData As String) As Boolean
        Try
            Dim xmlDocument As New XmlDocument() ' First we create an XML Document Object.
            xmlDocument.Load(New IO.StringReader(xmlData)) ' Now we try and parse the XML data.

            Dim xmlNode As XmlNode = xmlDocument.SelectSingleNode("/xmlroot")

            Dim remoteVersion As String = xmlNode.SelectSingleNode("version").InnerText.Trim
            Dim remoteBuild As String = xmlNode.SelectSingleNode("build").InnerText.Trim
            Dim shortRemoteBuild As Short

            ' This checks to see if current version and the current build matches that of the remote values in the XML document.
            If remoteVersion.Equals(versionStringWithoutBuild) And remoteBuild.Equals(shortBuild.ToString) Then
                If Short.TryParse(remoteBuild, shortRemoteBuild) And remoteVersion.Equals(versionStringWithoutBuild) Then
                    If shortRemoteBuild < shortBuild Then
                        ' This is weird, the remote build is less than the current build. Something went wrong. So to be safe we're going to return a False value indicating that there is no update to download. Better to be safe.
                        Return False
                    End If
                End If

                ' OK, they match so there's no update to download and update to therefore we return a False value.
                Return False
            Else
                ' We return a True value indicating that there is a new version to download and install.
                Return True
            End If
        Catch ex As XPath.XPathException
            ' Something went wrong so we return a False value.
            Return False
        Catch ex As XmlException
            ' Something went wrong so we return a False value.
            Return False
        Catch ex As Exception
            ' Something went wrong so we return a False value.
            Return False
        End Try
    End Function

    Private Sub killProcess(PID As Integer)
        Debug.Write(String.Format("Killing PID {0}...", PID))

        If doesPIDExist(PID) Then
            Process.GetProcessById(PID).Kill()
        End If

        If doesPIDExist(PID) Then
            killProcess(PID)
            'Else
            'debug.writeline(" Process Killed.")
        End If
    End Sub

    Public Sub searchForProcessAndKillIt(strFileName As String, boolFullFilePathPassed As Boolean)
        Dim fullFileName As String

        If boolFullFilePathPassed = True Then
            fullFileName = strFileName
        Else
            fullFileName = New IO.FileInfo(strFileName).FullName
        End If

        Dim wmiQuery As String = String.Format("Select ExecutablePath, ProcessId FROM Win32_Process WHERE ExecutablePath = '{0}'", fullFileName.addSlashes())
        Dim searcher As New Management.ManagementObjectSearcher("root\CIMV2", wmiQuery)

        Try
            For Each queryObj As Management.ManagementObject In searcher.Get()
                killProcess(Integer.Parse(queryObj("ProcessId").ToString))
            Next

            'debug.writeline("All processes killed... Update process can continue.")
        Catch ex3 As Runtime.InteropServices.COMException
        Catch err As Management.ManagementException
            ' Does nothing
        End Try
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
        httpHelper.addHTTPHeader("OPERATING_SYSTEM", getFullOSVersionString())
        httpHelper.useHTTPCompression = True
        httpHelper.setProxyMode = True
        httpHelper.setHTTPTimeout = 60

        httpHelper.setURLPreProcessor = Function(ByVal strURLInput As String) As String
                                            Try
                                                If strURLInput.Trim.ToLower.StartsWith("http") = False Then
                                                    If My.Settings.useSSL = True Then
                                                        Debug.WriteLine("The setURLPreProcessor code transformed """ & strURLInput & """ to ""https://" & strURLInput & """.")
                                                        Return "https://" & strURLInput
                                                    Else
                                                        Debug.WriteLine("The setURLPreProcessor code transformed """ & strURLInput & """ to ""http://" & strURLInput & """.")
                                                        Return "http://" & strURLInput
                                                    End If
                                                Else
                                                    Debug.WriteLine("The setURLPreProcessor code didn't have to do anything to the input """ & strURLInput & """.")
                                                    Return strURLInput
                                                End If
                                            Catch ex As Exception
                                                Debug.WriteLine("The setURLPreProcessor code errored out with an input of """ & strURLInput & """.")
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

        If String.IsNullOrEmpty(folderPath) = True Or IO.Directory.Exists(folderPath) = False Then
            Return False
        End If

        If checkByFolderACLs(folderPath) = True Then
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