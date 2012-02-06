Option Explicit On

Module ModPortMonitoring
    Private ReportPortBusy As Boolean

    Public Sub GetCorePortStatus(ByVal ipAddress As String, ByVal intRealm As Integer)
        Log("GetCorePortStatus for realm: " & intRealm, "DEBUG")

        If Realms(intRealm).intPort = 0 Then Exit Sub

        Select Case intRealm
            Case 0
                Dim Core1Thread As System.Threading.Thread
                Dim Core1Checker = New ClsPortChecker(FrmMain, ipAddress, Realms(intRealm).intPort)
                Core1Thread = New System.Threading.Thread(AddressOf Core1Checker.CheckPort)
                Call Core1Thread.Start()
            Case 1
                Dim Core2Thread As System.Threading.Thread
                Dim Core2Checker = New ClsPortChecker(FrmMain, ipAddress, Realms(intRealm).intPort)
                Core2Thread = New System.Threading.Thread(AddressOf Core2Checker.CheckPort)
                Call Core2Thread.Start()
            Case 2
                Dim Core3Thread As System.Threading.Thread
                Dim Core3Checker = New ClsPortChecker(FrmMain, ipAddress, Realms(intRealm).intPort)
                Core3Thread = New System.Threading.Thread(AddressOf Core3Checker.CheckPort)
                Call Core3Thread.Start()
        End Select
    End Sub

    Public Sub GetRealmPortStatus(ByVal ipAddress As String)
        Log("GetRealmPortStatus", "DEBUG")
        Dim realmThread As System.Threading.Thread

        Dim RealmChecker = New ClsPortChecker(FrmMain, ipAddress, TrinityRealmPort)
        realmThread = New System.Threading.Thread(AddressOf RealmChecker.CheckPort)
        Call realmThread.Start()
    End Sub

    Public Function InitialPortCheck() As Boolean
        Log("InitialPortCheck", "DEBUG")
        GetRealmPortStatus(TrinityRealmURL)
        If Realms(0).Active Then GetCorePortStatus(TrinityRealmURL, 0)
        If Realms(1).Active Then GetCorePortStatus(TrinityRealmURL, 1)
        If Realms(2).Active Then GetCorePortStatus(TrinityRealmURL, 2)

        Do While CPtcChecker.Busy
            Application.DoEvents()
            Log("LOOP: InitialPortCheck", "DEBUG")
        Loop

        Return True
    End Function

    Public Sub ReportPort(ByVal iPort As Integer, ByVal iOpen As Boolean)
        Log("ReportPort: " & iPort.ToString & " - " & iOpen.ToString, "DEBUG")

        Select Case iPort
            Case TrinityRealmPort
                If Not HaltRealm Then
                    Select Case iOpen
                        Case True
                            RealmUp = True
                            RetryRealm = False
                            If WaitForRealm Then
                                SendEmail("Realm up!", "Realm came back up at: " & Now)
                            End If
                            WaitForRealm = False
                            IntRealmDownCount = 1
                        Case False
                            If IntRealmDownCount = 3 Then
                                If Not WaitForRealm Then FrmMain.lblStatus.Text = "Realm is down!"
                                RealmUp = False
                                RetryRealm = False
                                'RealmCrashCount = RealmCrashCount + 1
                                System.Threading.Interlocked.Increment(RealmCrashCount)
                                SendEmail("Realm down!", "Realm down at: " & Now & vbNewLine & vbNewLine & "Crashes: " & RealmCrashCount.ToString)
                                WaitForRealm = True
                                Do While Not TerminateProcess(TrinityRealmFile)
                                    Application.DoEvents()
                                    Log("ReportPort: TerminateProcess", "DEBUG")
                                Loop
                                StartProcess(RealmPath, RealmFile, "")
                                IntRealmDownCount = 1
                            ElseIf WaitForRealm Then
                                IntRealmDownCount = 1
                            Else
                                RetryRealm = True
                                'IntRealmDownCount = IntRealmDownCount + 1
                                System.Threading.Interlocked.Increment(IntRealmDownCount)
                            End If
                    End Select
                End If

            Case Realms(0).intPort
                If Not HaltCore1 Then
                    Select Case iOpen
                        Case True
                            Core1Up = True
                            RetryCore1 = False
                            If WaitForCore1 Then
                                SendEmail("Core 1 up!", "Core 1 came back up at: " & Now)
                                WaitForCore1 = False
                            End If
                            IntCore1DownCount = 1
                        Case False
                            If IntCore1DownCount = 3 Then
                                RetryCore1 = False
                                If Not WaitForCore1 Then FrmMain.lblStatus.Text = "Core 1 is down!"
                                Core1Up = False
                                'Core1CrashCount = Core1CrashCount + 1
                                System.Threading.Interlocked.Increment(Core1CrashCount)
                                SendEmail("Core 1 down!", "Core 1 down at: " & Now & vbNewLine & vbNewLine & "Crashes: " & Core1CrashCount.ToString)
                                WaitForCore1 = True
                                Do While Not TerminateProcess(Realms(0).strCoreFile)
                                    Application.DoEvents()
                                    Log("reportport:  terminate process", "debug")
                                Loop
                                StartProcess(Core1Path, Core1File, "")
                                IntCore1DownCount = 1
                            ElseIf WaitForCore1 Then
                                IntCore1DownCount = 1
                            Else
                                RetryCore1 = True
                                'IntCore1DownCount = IntCore1DownCount + 1
                                System.Threading.Interlocked.Increment(IntCore1DownCount)
                            End If
                    End Select
                End If

            Case Realms(1).intPort
                If Not HaltCore2 Then
                    Select Case iOpen
                        Case True
                            Core2Up = True
                            RetryCore2 = False
                            If WaitForCore2 Then
                                SendEmail("Core 2 up!", "Core 2 came back up at: " & Now)
                                WaitForCore2 = False
                            End If
                            IntCore2DownCount = 1
                        Case False
                            If IntCore2DownCount = 3 Then
                                RetryCore2 = False
                                If Not WaitForCore2 Then FrmMain.lblStatus.Text = "Core 2 is down!"
                                Core2Up = False
                                'Core2CrashCount = Core2CrashCount + 1
                                System.Threading.Interlocked.Increment(Core2CrashCount)
                                SendEmail("Core 2 down!", "Core 2 down at: " & Now & vbNewLine & vbNewLine & "Crashes: " & Core2CrashCount.ToString)
                                WaitForCore2 = True
                                Do While Not TerminateProcess(Realms(1).strCoreFile)
                                    Application.DoEvents()
                                    Log("reportport:  terminate process", "debug")
                                Loop
                                StartProcess(Core2Path, Core2File, "")
                                IntCore2DownCount = 1
                            ElseIf WaitForCore2 Then
                                IntCore2DownCount = 1
                            Else
                                RetryCore2 = True
                                'IntCore2DownCount = IntCore2DownCount + 1
                                System.Threading.Interlocked.Increment(IntCore2DownCount)
                            End If
                    End Select
                End If

            Case Realms(2).intPort
                If Not HaltCore3 Then
                    Select Case iOpen
                        Case True
                            Core3Up = True
                            RetryCore3 = False
                            If WaitForCore3 Then
                                SendEmail("Core 3 up!", "Core 3 came back up at: " & Now)
                                WaitForCore3 = False
                            End If
                            IntCore3DownCount = 1
                        Case False
                            If IntCore3DownCount = 3 Then
                                RetryCore3 = False
                                If Not WaitForCore3 Then FrmMain.lblStatus.Text = "Core 3 is down!"
                                Core3Up = False
                                'Core3CrashCount = Core3CrashCount + 1
                                System.Threading.Interlocked.Increment(Core3CrashCount)
                                SendEmail("Core 3 down!", "Core 3 down at: " & Now & vbNewLine & vbNewLine & "Crashes: " & Core3CrashCount.ToString)
                                WaitForCore3 = True
                                Do While Not TerminateProcess(Realms(2).strCoreFile)
                                    Application.DoEvents()
                                    Log("ReportPort:  Terminate Process", "DEBUG")
                                Loop
                                StartProcess(Core3Path, Core3File, "")
                                IntCore3DownCount = 1
                            ElseIf WaitForCore3 Then
                                IntCore3DownCount = 1
                            Else
                                RetryCore3 = True
                                'IntCore3DownCount = IntCore3DownCount + 1
                                System.Threading.Interlocked.Increment(IntCore3DownCount)
                            End If
                    End Select
                End If
        End Select
    End Sub

    Public Sub CheckServerStatus()
        Log("CheckServerStatus", "DEBUG")
        'Check server status
        If AllCoresUp And RealmUp Then
            UpdateSystemTray(1, "Server up.")
        Else
            UpdateSystemTray(0, "Server down.")
        End If

        'enable add account button
        If AllCoresUp And FrmMain.cmdAddUser.Enabled = False Then FrmMain.cmdAddUser.Enabled = True
    End Sub
End Module
