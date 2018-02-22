Imports System.IO
Imports System.Management

Module Search_for_Process_and_Kill_it
    Private Function doesPIDExist(PID As Integer) As Boolean
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", String.Format("SELECT * FROM Win32_Process WHERE ProcessId={0}", PID))

        If searcher.Get.Count = 0 Then
            searcher.Dispose()
            Return False
        Else
            searcher.Dispose()
            Return True
        End If
    End Function

    Private Sub killProcess(PID As Integer)
        Dim processDetail As Process

        Debug.Write(String.Format("Killing PID {0}...", PID))

        processDetail = Process.GetProcessById(PID)
        processDetail.Kill()

        Threading.Thread.Sleep(100)

        If doesPIDExist(PID) Then
            Debug.WriteLine(" Process still running.  Attempting to kill process again.")
            killProcess(PID)
        Else
            Debug.WriteLine(" Process Killed.")
        End If
    End Sub

    Private Sub searchForProcessAndKillIt(fileName As String)
        Dim fullFileName As String = New FileInfo(fileName).FullName
        'Dim PID As Integer

        Debug.WriteLine("Killing all processes that belong to parent executable file.  Please Wait.")
        'Console.WriteLine(String.Format("SELECT * FROM Win32_Process WHERE ExecutablePath = '{0}'", fullFileName.Replace("\", "\\")))

        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process")

        Try
            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("ExecutablePath") IsNot Nothing Then
                    If queryObj("ExecutablePath") = fullFileName Then
                        killProcess(Integer.Parse(queryObj("ProcessId").ToString))
                    End If
                End If
            Next

            Debug.WriteLine("All processes killed... Update process can continue.")
        Catch err As ManagementException
            ' Does nothing
        End Try
    End Sub

    Sub lookForFileKillItAndDeleteIt(file As String)
        If System.IO.File.Exists(file) = True Then
            searchForProcessAndKillIt(file)
            System.IO.File.Delete(file)
        End If
    End Sub
End Module
