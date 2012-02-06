Module PerformanceCounter
    Public Event Event_ReportRealmCPU(ByVal intUsage As Integer)
    Public Event Event_ReportCore1CPU(ByVal intUsage As Integer)
    Public Event Event_ReportCore2CPU(ByVal intUsage As Integer)
    Public Event Event_ReportCore3CPU(ByVal intUsage As Integer)

    Private RealmMonitor As New WMIProcessing
    Private Core1Monitor As New WMIProcessing
    Private Core2Monitor As New WMIProcessing
    Private Core3Monitor As New WMIProcessing
    Private TGMonitor As New WMIProcessing

    Public Sub GetRealmCPU()
        Do
            Try
                If RealmPID = 0 Or GetNewRealmPID Then
                    RealmPID = GetPid(TrinityRealmFile)
                    If RealmLastPID = 0 Then RealmLastPID = RealmPID
                    Usage_RealmCPU = 0
                Else
                    Usage_RealmCPU = RealmMonitor.GetProcessorUtilisation(RealmPID)
                End If
            Catch
                RealmPID = GetPid(TrinityRealmFile)
                Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
            End Try

            System.Threading.Thread.Sleep(1500)
        Loop
    End Sub
    Public Sub GetCore1CPU()
        Do
            If Realms(0).Active Then
                Try
                    If Core1PID = 0 Or GetNewCore1PID Then
                        Core1PID = GetPid(Realms(0).strCoreFile)
                        If Core1LastPID = 0 Then Core1LastPID = Core1PID
                        Usage_Core1CPU = 0
                    Else
                        Usage_Core1CPU = Core1Monitor.GetProcessorUtilisation(Core1PID)
                    End If
                Catch
                    Core1PID = GetPid(Realms(0).strCoreFile)
                    Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
                End Try
            End If

            System.Threading.Thread.Sleep(1500)
        Loop
    End Sub

    Public Sub GetCore2CPU()
        Do
            If Realms(1).Active Then
                Try
                    If Core2PID = 0 Or GetNewCore2PID Then
                        Core2PID = GetPid(Realms(1).strCoreFile)
                        If Core2LastPID = 0 Then Core2LastPID = Core2PID
                        Usage_Core2CPU = 0
                    Else
                        Usage_Core2CPU = Core2Monitor.GetProcessorUtilisation(Core2PID)
                    End If
                Catch
                    Core2PID = GetPid(Realms(1).strCoreFile)
                    Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
                End Try
            End If

            System.Threading.Thread.Sleep(1500)
        Loop
    End Sub

    Public Sub GetCore3CPU()
        Do
            If Realms(2).Active Then
                Try
                    If Core3PID = 0 Or GetNewCore3PID Then
                        Core3PID = GetPid(Realms(2).strCoreFile)
                        If Core3LastPID = 0 Then Core3LastPID = Core3PID
                        Usage_Core3CPU = 0
                    Else
                        Usage_Core3CPU = Core3Monitor.GetProcessorUtilisation(Core3PID)
                    End If
                Catch
                    Core3PID = GetPid(Realms(2).strCoreFile)
                    Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
                End Try
            End If

            System.Threading.Thread.Sleep(1500)
        Loop
    End Sub

    Public Sub GetTGCPU()
        Do
            Try
                Dim TGUsage As Integer = Nothing
                If TGPID = 0 Then
                    TGPID = GetPid(Application.ExecutablePath)
                    TGUsage = 0
                Else
                    Usage_TGCPU = TGMonitor.GetProcessorUtilisation(TGPID)
                End If
            Catch
                TGPID = GetPid(Application.ExecutablePath)
                Usage_TGCPU = 0
                Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
            End Try

            System.Threading.Thread.Sleep(1500)
        Loop
    End Sub
End Module
