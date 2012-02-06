Option Strict On

Imports System.Runtime.InteropServices
Imports System.Diagnostics

Module ModProcessControl
    Private Declare Function IsWindowVisible Lib "user32" Alias "IsWindowVisible" (ByVal hWnd As Int32) As Integer

    <DllImport("User32")> Private Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
Private Function FindWindow( _
 ByVal lpClassName As String, _
 ByVal lpWindowName As String) As IntPtr
    End Function

    Public Const SWHide As Integer = 0
    Public Const SWShownormal As Integer = 1
    Public Const SWNormal As Integer = 1
    Public Const SWShowminimized As Integer = 2
    Public Const SWShowmaximized As Integer = 3
    Public Const SWMaximize As Integer = 3
    Public Const SWShownoactivate As Integer = 4
    Public Const SWShow As Integer = 5
    Public Const SWMinimize As Integer = 6
    Public Const SWShowminnoactive As Integer = 7
    Public Const SWShowna As Integer = 8
    Public Const SWRestore As Integer = 9
    Public Const SWShowdefault As Integer = 10
    Public Const SWMax as Integer = 10

    Private hWnd As Integer = 0

    Public Sub StartProcess(ByVal strPath As String, ByVal strFile As String, ByVal strArgs As String)
        Log("StartOrocess: " & strFile, "DEBUG")
        Try
            If Not FrmMain.tmrSaveIcon.Enabled Then FrmMain.lblStatus.Text = "Starting: " & strFile & " at " & strPath

            Dim proc As New Process()

            proc.StartInfo.WorkingDirectory = strPath
            proc.StartInfo.FileName = strFile
            proc.StartInfo.Arguments = strArgs

            'Hide the process if it is a backup window or if user
            'has chosen to hide Trinity Processes.
            If LaunchTrinityHidden Or FrmMain.tmrSaveIcon.Enabled Then
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Else
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            End If

            proc.Start()

            'if process is a backup or check, run low priority.
            'If strFile.ToLower = "mysqldump.exe" Then proc.PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal
            'If strFile.ToLower = "mysqlcheck.exe" Then proc.PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal

            If FrmMain.tmrSaveIcon.Enabled Then
                While Not proc.HasExited
                    Application.DoEvents()
                End While
            End If

            proc.Dispose()
            proc.Close()
        Catch
            MsgBox(Err.Description & vbCrLf & vbCrLf & strFile & " at " & strPath & vbCrLf & vbCrLf & "Please check your configuration, TriniGuard will now exit.", MsgBoxStyle.Critical, "Critical Error")
            ClosePending = True
        End Try
    End Sub

    Public Function TerminateProcess(ByVal strProcess As String) As Boolean
        Log("TerminateProcess: " & strProcess, "DEBUG")
        Dim local As Process() = Process.GetProcesses
        Dim i As Integer
        FrmMain.lblStatus.Text = "Killing process: " & strProcess
        For i = 0 To local.Length - 1
            Log("TerminateProcess - Enumerating... " & strProcess, "DEBUG")
            If Strings.UCase(local(i).ProcessName) = Strings.UCase(FileNameWithoutExtension(strProcess)) Then
                If local(i).Id = GetPid(strProcess) Then local(i).Kill()
                FrmMain.lblStatus.Text = "Killed process: " & strProcess
            End If
        Next

        Return True
    End Function

    Public Sub SetWindowState(ByVal strProcess As String, ByVal windowState As Integer)
        Log("SetWindowState: " & strProcess, "DEBUG")
        Dim ceroIntPtr As New IntPtr(0)

        hWnd = GetHandle(strProcess).ToInt32
        If hWnd.Equals(ceroIntPtr) Then
            'no handle - not running?
        Else
            ShowWindow(hWnd, windowState)
        End If
    End Sub

    Public Function GetWindowState(ByVal strProcess As String) As Integer
        Log("GetWindowState: " & strProcess, "DEBUG")
        Dim ceroIntPtr As New IntPtr(0)

        hWnd = GetHandle(strProcess).ToInt32
        If hWnd.Equals(ceroIntPtr) Then
            'no handle - not running?
            Return -1
        Else
            Return IsWindowVisible(hWnd)
        End If
    End Function

    Public Function GetHandle(ByVal strProcess As String) As IntPtr
        Log("GetHandle: " & strProcess, "DEBUG")
        Try
            Dim wHandle As IntPtr

            'try to get window handle
            wHandle = FindWindow("ConsoleWindowClass", strProcess)

            'if window handle is invalid, try another method
            If wHandle.ToInt32 = 0 Then
                Log("GetHandle - STAGE 2 " & strProcess, "DEBUG")
                Dim prList() As Process
                prList = Process.GetProcessesByName(FileNameWithoutExtension(strProcess))
                For Each pr As Process In prList
                    Log("GetHandle - STAGE 2 - Enumerating... " & strProcess, "DEBUG")
                    wHandle = pr.MainWindowHandle
                Next
            End If

            'if window handle is invalid, try another method
            If wHandle.ToInt32 = 0 Then
                Log("GetHandle - STAGE 3 " & strProcess, "DEBUG")
                Dim enumerator As New WindowsEnumerator()
                For Each top As ApiWindow In enumerator.GetTopLevelWindows()
                    Log("GetHandle - STAGE 3 - Enumerating... " & strProcess, "DEBUG")
                    If top.MainWindowTitle = strProcess Or top.MainWindowTitle = FileNameWithoutExtension(strProcess) Then
                        Dim x = New IntPtr(top.HWnd)
                        wHandle = x
                        Exit For
                    End If
                Next top
            End If

            'if window handle is invalid, give up
            If wHandle.ToInt32 = 0 Then
                If Not Exiting Then Log("Error: There was a problem getting the window handle of: " & strProcess & ", you may need to restart this process.", "ERROR")
            End If

            Return wHandle

        Catch ex As Exception
            Log("Error getting handle: " & Err.Description, "ERROR")
        End Try
    End Function

    Public Function GetPid(ByVal strProcess As String) As Integer
        Log("GetPID: " & strProcess, "DEBUG")
        Dim pid As Integer = Nothing
        Dim prList() As Process = Nothing

        Try
            prList = Process.GetProcessesByName(FileNameWithoutExtension(strProcess))
            For Each pr As Process In prList
                For Each m As ProcessModule In pr.Modules
                    Log("GetPID - Enumerating... " & m.FileName, "DEBUG")
                    If strProcess.ToLower = m.FileName.ToLower Then
                        pid = pr.Id
                        'prList = Nothing
                        'pr.Dispose()
                        Return pid
                    End If
                    Application.DoEvents()
                Next
                Application.DoEvents()
            Next

            'Return pid

        Catch
            prList = Nothing
            Log("GetPID Error: " & Err.Description, "ERROR")
            Return 0
        End Try
    End Function

    Public Function IsProcessRunning(ByVal strProcess As String) As Boolean
        'THIS FUNCTION NEEDS FIXING!!!
        Log("IsProcessRunning: " & strProcess, "DEBUG")
        Dim processRunning As Boolean = False

        For Each Process In System.Diagnostics.Process.GetProcesses
            Log("IsProcessRunning - Enumerating... " & strProcess, "DEBUG")
            If Process.ProcessName = strProcess Then
                processRunning = True
                Return processRunning
            End If
        Next

        Return processRunning
    End Function

    Public Sub KillNicely(ByVal strProcess As String)
        If strProcess = Nothing Then Exit Sub

        Log("KillNicely: " & strProcess, "DEBUG")

        Try
            SetWindowState(strProcess, SWShownoactivate)
            AppActivate(GetPid(strProcess))
            System.Threading.Thread.Sleep(100)
            SendKeys.SendWait(".SERVER SHUTDOWN 0")
            System.Threading.Thread.Sleep(50)
            SendKeys.SendWait("^C")

            System.Threading.Thread.Sleep(200)
            'SendKeys.SendWait(".SERVER SHUTDOWN 0")
            'System.Threading.Thread.Sleep(500)
        Catch
            Log("Error killing process " & strProcess & ".  -   Description: " & Err.Description, "ERROR")
        End Try
    End Sub
End Module

