Option Strict On

Module ModSchedules

    Public Sub LoadScheduleCommands()
        Log("LoadScheduleCommands", "DEBUG")
        FrmMain.cbSchedCommand.Items.Add("Restart Realm")
        FrmMain.cbSchedCommand.Items.Add("Restart Core 1")
        FrmMain.cbSchedCommand.Items.Add("Restart Core 2")
        FrmMain.cbSchedCommand.Items.Add("Restart Core 3")
        FrmMain.cbSchedCommand.Items.Add("Restart Realm and all Cores")

        FrmMain.cbSchedCommand.Items.Add("Shutdown Realm")
        FrmMain.cbSchedCommand.Items.Add("Shutdown Core 1")
        FrmMain.cbSchedCommand.Items.Add("Shutdown Core 2")
        FrmMain.cbSchedCommand.Items.Add("Shutdown Core 3")
        FrmMain.cbSchedCommand.Items.Add("Shutdown Realm and all Cores")

        FrmMain.cbSchedCommand.Items.Add("Start Realm")
        FrmMain.cbSchedCommand.Items.Add("Start Core 1")
        FrmMain.cbSchedCommand.Items.Add("Start Core 2")
        FrmMain.cbSchedCommand.Items.Add("Start Core 3")
        FrmMain.cbSchedCommand.Items.Add("Start Realm and all Cores")

        FrmMain.cbSchedCommand.Items.Add("Full Backup")
        FrmMain.cbSchedCommand.Items.Add("Optimize Database")
        FrmMain.cbSchedCommand.Items.Add("Announce Core 1")
        FrmMain.cbSchedCommand.Items.Add("Announce Core 2")
        FrmMain.cbSchedCommand.Items.Add("Announce Core 3")
        FrmMain.cbSchedCommand.Items.Add("Announce All")
        FrmMain.cbSchedCommand.Items.Add("Notify Core 1")
        FrmMain.cbSchedCommand.Items.Add("Notify Core 2")
        FrmMain.cbSchedCommand.Items.Add("Notify Core 3")
        FrmMain.cbSchedCommand.Items.Add("Notify All")
        FrmMain.cbSchedCommand.Items.Add("Exit TriniGuard")
    End Sub

    Public Sub LoadSchedules()
        Log("LoadSchedules", "DEBUG")
        Try
            Dim schedEnd As Boolean = False
            Dim schedID As Integer = 0
            Dim schedRecord As String = Nothing

            FrmMain.cbSchedules.Items.Clear()

            Do Until schedEnd
                schedRecord = ObjScheduleIniFile.GetString("SCHEDULES", schedID.ToString, "")

                If Not schedRecord = "" Then
                    ReDim Preserve ArySchedRecords(schedID)
                    ArySchedRecords(schedID) = schedRecord.Split(Convert.ToChar("|"))
                    ReDim Preserve ArySchedHourCount(schedID)
                    Dim schedItemName As String = ArySchedRecords(schedID)(0)
                    FrmMain.cbSchedules.Items.Add(schedItemName)
                    schedID = schedID + 1
                Else
                    schedEnd = True
                End If
                Application.DoEvents()
            Loop
            schedEnd = False

            If FrmMain.cbSchedules.Items.Count > 0 Then FrmMain.cbSchedules.SelectedIndex = 0

            schedRecord = Nothing

        Catch ex As Exception
            MsgBox("Error loading schedules: " & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub CheckSchedules()
        Log("CheckSchedules", "DEBUG")
        Try
            'exit check if no schedules exisit
            If FrmMain.cbSchedules.Items.Count < 1 Then Exit Sub

            For i As Integer = 0 To UBound(ArySchedRecords, 1)
                Dim taskName As String = Trim(ArySchedRecords(i)(0))
                If taskName = "Schedule deleted" Then Exit Sub
                Dim taskFreq As String = Trim(ArySchedRecords(i)(1))
                Dim taskCommand As String = Trim(ArySchedRecords(i)(4))
                Dim taskMessage As String = Trim(ArySchedRecords(i)(5))

                'set hour counter to zero
                If ArySchedHourCount(i) = Nothing Then ArySchedHourCount(i) = 0

                Select Case taskFreq
                    Case "Hourly"
                        If ArySchedHourCount(i) >= Convert.ToDouble(ArySchedRecords(i)(3)) * 60 * 60 Then
                            ArySchedHourCount(i) = 0 'clear var
                            Log("Execute Schedule: " & taskName & " - " & ArySchedHourCount(i) & " - " & Convert.ToDouble(ArySchedRecords(i)(3)) * 60 * 60, "DEBUG")
                            Dim itemLog As String = "Task: " & taskName & " executed: " & taskCommand & " every " & ArySchedRecords(i)(3) & " hour(s)."
                            FrmMain.lstScheduleLog.Items.Add(itemLog)
                            ExecuteSchedule(taskCommand, taskMessage)
                        Else
                            ArySchedHourCount(i) = ArySchedHourCount(i) + 1
                        End If

                    Case "Daily"
                        Dim taskTimeDaily As DateTime = Convert.ToDateTime(Trim(ArySchedRecords(i)(3)))
                        If DateTime.Now.ToString("h:mm:ss tt") = taskTimeDaily.ToString("h:mm:ss tt") Then
                            Log("Execute Schedule: " & taskName, "DEBUG")
                            FrmMain.lstScheduleLog.Items.Add("Task: " & taskName & " executed: " & taskCommand & " at " & taskTimeDaily.ToString("h:mm:ss tt"))
                            ExecuteSchedule(taskCommand, taskMessage)
                        End If

                    Case "Monthly"
                        Dim taskTimeMonthly As DateTime = Convert.ToDateTime(Trim(ArySchedRecords(i)(3)))
                        If DateTime.Now < taskTimeMonthly.AddSeconds(1) AndAlso DateTime.Now > taskTimeMonthly Then
                            Log("Execute Schedule: " & taskName, "DEBUG")
                            FrmMain.lstScheduleLog.Items.Add("Task: " & taskName & " executed: " & taskCommand & " at " & taskTimeMonthly)
                            ExecuteSchedule(taskCommand, taskMessage)
                        End If

                    Case "Weekly"
                        Dim taskTimeWeekly As DateTime = Convert.ToDateTime(Trim(ArySchedRecords(i)(3)))
                        If DateTime.Now.ToString("h:mm:ss tt") = taskTimeWeekly.ToString("h:mm:ss tt") Then
                            Dim taskDays As String() = ArySchedRecords(i)(2).Split(Convert.ToChar(" "))

                            For Each CurrentDay In taskDays
                                If Trim(CurrentDay) = DateTime.Now.ToString("ddd") Then
                                    Log("Execute Schedule: " & taskName, "DEBUG")
                                    FrmMain.lstScheduleLog.Items.Add("Task: " & taskName & " executed: " & taskCommand & " at " & CurrentDay & " " & taskTimeWeekly.ToString("h:mm:ss tt"))
                                    ExecuteSchedule(taskCommand, taskMessage)
                                End If
                            Next
                        End If
                End Select
                'Application.DoEvents()
            Next

        Catch ex As Exception
            MsgBox("Error checking schedules: " & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ExecuteSchedule(ByVal strCommand As String, ByVal strMessage As String)
        Log("ExecuteSchedule: " & strCommand, "DEBUG")
        Select Case strCommand
            Case "Restart Realm"
                KillNicely(TrinityRealmFile)

            Case "Restart Core 1"
                If Realms(0).Active Then KillNicely(Realms(0).strCoreFile)

            Case "Restart Core 2"
                If Realms(1).Active Then KillNicely(Realms(1).strCoreFile)

            Case "Restart Core 3"
                If Realms(2).Active Then KillNicely(Realms(2).strCoreFile)

            Case "Restart Realm and all Cores"
                KillNicely(TrinityRealmFile)
                System.Threading.Thread.Sleep(500)
                If Realms(0).Active Then KillNicely(Realms(0).strCoreFile)
                System.Threading.Thread.Sleep(500)
                If Realms(1).Active Then KillNicely(Realms(1).strCoreFile)
                System.Threading.Thread.Sleep(500)
                If Realms(2).Active Then KillNicely(Realms(2).strCoreFile)

            Case "Shutdown Realm"
                HaltRealm = True
                RealmUp = False
                KillNicely(TrinityRealmFile)

            Case "Shutdown Core 1"
                HaltCore1 = True
                Core1Up = False
                If Realms(0).Active Then KillNicely(Realms(0).strCoreFile)

            Case "Shutdown Core 2"
                HaltCore2 = True
                Core2Up = False
                If Realms(1).Active Then KillNicely(Realms(1).strCoreFile)

            Case "Shutdown Core 3"
                HaltCore3 = True
                Core3Up = False
                If Realms(2).Active Then KillNicely(Realms(2).strCoreFile)

            Case "Shutdown Realm and all Cores"
                HaltRealm = True
                RealmUp = False
                KillNicely(TrinityRealmFile)

                If Realms(0).Active Then
                    System.Threading.Thread.Sleep(500)
                    HaltCore1 = True
                    Core1Up = False
                    KillNicely(Realms(0).strCoreFile)
                End If

                If Realms(1).Active Then
                    System.Threading.Thread.Sleep(500)
                    HaltCore2 = True
                    Core2Up = False
                    KillNicely(Realms(1).strCoreFile)
                End If

                If Realms(2).Active Then
                    System.Threading.Thread.Sleep(500)
                    HaltCore3 = True
                    Core3Up = False
                    KillNicely(Realms(2).strCoreFile)
                End If


            Case "Start Realm"
                StartProcess(RealmPath, RealmFile, "")
                WaitForRealm = True
                HaltRealm = False
                GetNewRealmPID = True

            Case "Start Core 1"
                If Realms(0).Active Then
                    StartProcess(Core1Path, Core1File, "")
                    WaitForCore1 = True
                    HaltCore1 = False
                    GetNewCore1PID = True
                End If


            Case "Start Core 2"
                If Realms(1).Active Then
                    StartProcess(Core2Path, Core2File, "")
                    WaitForCore2 = True
                    HaltCore2 = False
                    GetNewCore2PID = True
                End If

            Case "Start Core 3"
                If Realms(2).Active Then
                    StartProcess(Core3Path, Core3File, "")
                    WaitForCore3 = True
                    HaltCore3 = False
                    GetNewCore3PID = True
                End If

            Case "Start Realm and all Cores"
                StartProcess(RealmPath, RealmFile, "")
                WaitForRealm = True
                HaltRealm = False
                GetNewRealmPID = True

                If Realms(0).Active Then
                    StartProcess(Core1Path, Core1File, "")
                    WaitForCore1 = True
                    HaltCore1 = False
                    GetNewCore1PID = True
                End If

                If Realms(1).Active Then
                    StartProcess(Core2Path, Core2File, "")
                    WaitForCore2 = True
                    HaltCore2 = False
                    GetNewCore2PID = True
                End If

                If Realms(2).Active Then
                    StartProcess(Core3Path, Core3File, "")
                    WaitForCore3 = True
                    HaltCore3 = False
                    GetNewCore3PID = True
                End If


            Case "Full Backup"
                BakWorld()
                BakRealm()
                BakChar()

            Case "Optimize Database"
                Dim threadCheckDB As System.Threading.Thread
                threadCheckDB = New System.Threading.Thread(AddressOf ModBackups.CheckDB)
                threadCheckDB.Start()

                Do While threadCheckDB.IsAlive
                    Application.DoEvents()
                    Log("LOOP: ExecuteSchedule- Optimize DB", "DEBUG")
                Loop

                threadCheckDB = Nothing

            Case "Announce Core 1"
                If Realms(0).Active Then Announce(strMessage, 0)

            Case "Announce Core 2"
                If Realms(2).Active Then Announce(strMessage, 1)

            Case "Announce Core 3"
                If Realms(2).Active Then Announce(strMessage, 2)

            Case "Announce All"
                If Realms(0).Active Then Announce(strMessage, 0)
                If Realms(1).Active Then Announce(strMessage, 1)
                If Realms(2).Active Then Announce(strMessage, 2)

            Case "Notify Core 1"
                If Realms(0).Active Then Notify(strMessage, 0)

            Case "Notify Core 2"
                If Realms(1).Active Then Notify(strMessage, 1)

            Case "Notify Core 3"
                If Realms(2).Active Then Notify(strMessage, 2)

            Case "Notify All"
                If Realms(0).Active Then Notify(strMessage, 0)
                If Realms(1).Active Then Notify(strMessage, 1)
                If Realms(2).Active Then Notify(strMessage, 2)

            Case "Exit TriniGuard"
                End
        End Select
    End Sub
End Module
