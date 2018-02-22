Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If My.Application.CommandLineArgs.Count = 1 Then
                Dim commandLineArgument As String = My.Application.CommandLineArgs(0).ToLower.Trim

                If commandLineArgument = "-update" Then
                    Dim currentProcessFileName As String = New IO.FileInfo(Windows.Forms.Application.ExecutablePath).Name

                    If currentProcessFileName.caseInsensitiveContains(".new.exe", True) Then
                        Dim mainEXEName As String = Regex.Replace(currentProcessFileName, Regex.Escape(".new.exe"), "", RegexOptions.IgnoreCase)

                        IO.File.Delete(mainEXEName)
                        IO.File.Copy(currentProcessFileName, mainEXEName)

                        Process.Start(New ProcessStartInfo With {.FileName = mainEXEName})
                        Process.GetCurrentProcess.Kill()
                    Else
                        MsgBox("The environment is not ready for an update. This process will now terminate.", MsgBoxStyle.Critical, "SimpleQR")
                        Process.GetCurrentProcess.Kill()
                    End If
                End If
            End If
        End Sub
        'Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
        '    AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies ' Loads embedded libraries.
        'End Sub

        'Private Function ResolveAssemblies(sender As Object, e As System.ResolveEventArgs) As Reflection.Assembly
        '    Dim desiredAssembly = New Reflection.AssemblyName(e.Name)

        '    'Debug.WriteLine("desiredAssembly.Name = " & desiredAssembly.Name)

        '    ' For each of the DLLs you need to include in your program, you need to add these two lines that look like this.
        '    ' Then add the DLL to your Project as a resource and set the Build Action of it to "Embedded Resource".
        '    If desiredAssembly.Name = "ThoughtWorks.QRCode" Then
        '        'Debug.WriteLine("loaded embedded SmoothProgressBar")
        '        Return Reflection.Assembly.Load(My.Resources.ThoughtWorks_QRCode) ' Replace with your assembly's resource name
        '    Else
        '        Return Nothing
        '    End If
        'End Function
    End Class
End Namespace

