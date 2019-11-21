Imports System.IO
Imports System.Management

Module Search_for_Process_and_Kill_it
    Private Function doesPIDExist(PID As Integer) As Boolean
        Using searcher As New ManagementObjectSearcher("root\CIMV2", String.Format("SELECT * FROM Win32_Process WHERE ProcessId={0}", PID))
            Return If(searcher.Get.Count = 0, False, True)
        End Using
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

    Public Sub searchForProcessAndKillIt(fileName As String)
        Dim fullFileName As String = New FileInfo(fileName).FullName

        Using searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process")
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
            End Try
        End Using
    End Sub
End Module