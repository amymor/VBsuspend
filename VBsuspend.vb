Imports System.Diagnostics
Imports System.Runtime.InteropServices

Module Module1
    <DllImport("ntdll.dll")>
    Private Function NtSuspendProcess(ByVal ProcessHandle As IntPtr) As Integer
    End Function

    <DllImport("ntdll.dll")>
    Private Function NtResumeProcess(ByVal ProcessHandle As IntPtr) As Integer
    End Function

    Sub Main(args As String())
        If args.Length = 0 Then
            Console.WriteLine("Please provide a process name without '.exe'.")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("Usage")
            Console.WriteLine("")
            Console.WriteLine("To suspend:")
            Console.WriteLine("VBsuspend.exe ""Process_Name_Without_exe"" ")
            Console.WriteLine("")
            Console.WriteLine("To resume:")
            Console.WriteLine("VBsuspend.exe ""Process_Name_Without_exe"" /r")
            Return
        End If

        Dim processName = args(0)
        Dim resumeFlag = args.Length > 1 AndAlso args(1) = "/r"

        Dim processes = Process.GetProcessesByName(processName)

        If processes.Length = 0 Then
            Console.WriteLine("No process found")
            Return
        End If

        For Each process As Process In processes
            If resumeFlag Then
                NtResumeProcess(process.Handle)
            Else
                NtSuspendProcess(process.Handle)
            End If
        Next
    End Sub
End Module
