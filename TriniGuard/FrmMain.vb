Option Strict On

Imports System.Net.Sockets

Public Class FrmMain
#Region "Vars"
    Dim sortColumn As Integer = -1

    Dim Core1LastStatus As Boolean
    Dim Core2LastStatus As Boolean
    Dim Core3LastStatus As Boolean
    Dim RealmLastStatus As Boolean
    Dim ServerLastStatus As Boolean

    Dim FirstLaunch As Boolean = True
    Dim FirstBackup As Boolean = True

    Dim Core1UpTime As DateTime
    Dim Core2UpTime As DateTime
    Dim Core3UpTime As DateTime
    Dim RealmUpTime As DateTime

    Dim GotNewRealmPID As Boolean
    Dim GotNewCore1PID As Boolean
    Dim GotNewCore2PID As Boolean
    Dim GotNewCore3PID As Boolean

    'Backup Counters
    Dim intCharDBCount As Integer = 0
    Dim intTableCount As Integer = 0
    Dim intWorldDBCount As Integer = 0
    Dim intRealmDBCount As Integer = 0

    'Accounts page
    Dim TrinityDB As New TrinityDB
    Dim thOnlineAccountCounter As New System.Threading.Thread(AddressOf TrinityDB.GetNumOnline)
    Dim thAccountCounter As New System.Threading.Thread(AddressOf TrinityDB.GetNumAccounts)
    Dim thCharacterCounter As New System.Threading.Thread(AddressOf TrinityDB.GetNumCharacters)
    Dim thCheckAccountUpdateStatus As New System.Threading.Thread(AddressOf CheckAccountUpdateStatus)

    Dim objAccountInfo As New TrinityDB

    Dim BackupTimer As Integer = 0

    'Backup Counters
    Private WorldBakCountDown As DateTime
    Private WorldBakSpan As Integer = 1
    Private RealmBakCountDown As DateTime
    Private RealmBakSpan As Integer = 1
    Private CharBakCountDown As DateTime
    Private CharBakSpan As Integer = 1
    Private TableBakCountDown As DateTime
    Private TableBakSpan As Integer = 1

#End Region

#Region "Main Form Functions"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Delete Log File if it exists
        If System.IO.File.Exists(Application.StartupPath & "\TriniGuard.Log") Then System.IO.File.Delete(Application.StartupPath & "\TriniGuard.Log")
        If DebugModeLog Then lblDebug.Visible = True

        'Load Program Settings
        LoadSettings()

        'Disable inactive realms
        If Not Realms(0).Active Then
            gbCore1.Enabled = False
            pbCore1.Image = imglstImages.Images(3)
        End If
        If Not Realms(1).Active Then
            gbCore2.Enabled = False
            pbCore2.Image = imglstImages.Images(3)
        End If
        If Not Realms(2).Active Then
            gbCore3.Enabled = False
            pbCore3.Image = imglstImages.Images(3)
        End If

        'Set task tray icon
        Me.Icon = My.Resources.TriniGuardIcon
        niStatus.Visible = True
        UpdateSystemTray(4, "Initializing...")

        'Load the names of the realms
        LoadRealmNames()

        'set size of window
        If Realms(2).Active Then
            SetWindowSize(3)
        ElseIf Realms(1).Active Then
            SetWindowSize(2)
        ElseIf Realms(0).Active Then
            SetWindowSize(1)
        End If

        'Check if all needed files exist
        Dim CoreExists As Boolean = True
        If Realms(0).Active And Not System.IO.File.Exists(Realms(0).strCoreFile) Then CoreExists = False
        If Realms(1).Active And Not System.IO.File.Exists(Realms(1).strCoreFile) Then CoreExists = False
        If Realms(2).Active And Not System.IO.File.Exists(Realms(2).strCoreFile) Then CoreExists = False
        Dim realmExists As Boolean = System.IO.File.Exists(TrinityRealmFile)
        Dim mySqlExists As Boolean = System.IO.File.Exists(MySqlDump)
        Dim mySqlCheckExists As Boolean = System.IO.File.Exists(MySqlCheck)
        Dim backupExists As Boolean = System.IO.Directory.Exists(BackupPath)

        If Not CoreExists Or Not realmExists Or Not mySqlExists Or Not mySqlCheckExists Or Not backupExists Then
            MsgBox("One or more of your file locations is wrong, please correct." & vbNewLine & vbNewLine & "Setup will now start.", MsgBoxStyle.Critical, "Configuration Error")
            Me.Enabled = False
            DlgConfig.ShowDialog()
            End
        End If

        'Start processes if they are not running
        If Not IsProcessRunning(RealmProcessName) Then
            WaitForRealm = True
            'RealmCrashCount = RealmCrashCount + 1
            StartProcess(RealmPath, RealmFile, "")
        End If
        If Realms(0).Active Then
            If Not IsProcessRunning(Core1ProcessName) Then
                WaitForCore1 = True
                'Core1CrashCount = Core1CrashCount + 1
                StartProcess(Core1Path, Core1File, "")
            End If
        End If
        If Realms(1).Active Then
            If Not IsProcessRunning(Core2ProcessName) Then
                WaitForCore2 = True
                'Core2CrashCount = Core2CrashCount + 1
                StartProcess(Core2Path, Core2File, "")
            End If
        End If
        If Realms(2).Active Then
            If Not IsProcessRunning(Core3ProcessName) Then
                WaitForCore3 = True
                'Core3CrashCount = Core3CrashCount + 1
                StartProcess(Core3Path, Core3File, "")
            End If
        End If

        'Get server versions
        GetServerVersions()

        'Start port checking threads
        If Realms(0).Active Then GetCorePortStatus(TrinityRealmURL, 0)
        If Realms(1).Active Then GetCorePortStatus(TrinityRealmURL, 1)
        If Realms(2).Active Then GetCorePortStatus(TrinityRealmURL, 2)
        GetRealmPortStatus(TrinityRealmURL)

        'track changes on number of Accounts
        AddHandler TrinityDB.EventFinishedCountingAccounts, AddressOf EventFinishedCountingAccounts
        thAccountCounter.Start()

        'track changes on number of Characters
        AddHandler TrinityDB.EventFinishedCountingCharacters, AddressOf EventFinishedCountingCharacters
        thCharacterCounter.Start()

        'track changes on number of online Accounts
        AddHandler TrinityDB.EventFinishedCountingOnlineAccounts, AddressOf EventFinishedCountingOnlineAccounts
        thOnlineAccountCounter.Start()

        'start backups
        tmrBackup.Enabled = True

        'Start status timer
        tmrUpdateStatus.Interval = 500
        tmrUpdateStatus.Enabled = True

        'Start uptime timer
        tmrUpTime.Enabled = True

        'Load Schedules
        LoadScheduleCommands()
        LoadSchedules()
        If SchedulerEnabled Then tmrScheduler.Enabled = True

        'This thread checks if the account list needs to be reloaded
        thCheckAccountUpdateStatus.Start()

        'Enable performance counters
        Dim thRealmPerformance As New System.Threading.Thread(AddressOf PerformanceCounter.GetRealmCPU)
        thRealmPerformance.Start()

        Dim thCore1Performance As New System.Threading.Thread(AddressOf PerformanceCounter.GetCore1CPU)
        thCore1Performance.Start()

        Dim thCore2Performance As New System.Threading.Thread(AddressOf PerformanceCounter.GetCore2CPU)
        thCore2Performance.Start()

        Dim thCore3Performance As New System.Threading.Thread(AddressOf PerformanceCounter.GetCore3CPU)
        thCore3Performance.Start()

        Dim thTGPerformance As New System.Threading.Thread(AddressOf PerformanceCounter.GetTGCPU)
        thTGPerformance.Start()

        tmrPerf.Enabled = True

        'set broadcast direction to core 1
        cbCoreMessage.SelectedIndex = 0
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Exiting = True

        niStatus.Visible = False

        'Close trinity processes if requested
        If TerminateTrinityOnExit Then
            If Realms(0).Active Then KillNicely(Realms(0).strCoreFile)
            If Realms(1).Active Then KillNicely(Realms(1).strCoreFile)
            If Realms(2).Active Then KillNicely(Realms(2).strCoreFile)
            KillNicely(TrinityRealmFile)
        Else
            If Realms(0).Active Then SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
            If Realms(1).Active Then SetWindowState(Realms(1).strCoreFile, SWShownoactivate)
            If Realms(2).Active Then SetWindowState(Realms(2).strCoreFile, SWShownoactivate)
            SetWindowState(TrinityRealmFile, SWShownoactivate)
        End If
        End
    End Sub

    Private Sub niStatus_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles niStatus.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub cmdHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHide.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub

    Private Sub btnConfigure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigure.Click
        Me.Enabled = False
        DlgConfig.Show()
    End Sub

    Private Sub LoadRealmNames()
        Try
            If Realms(0).Active Then
                lblCore1Title.Text = "Core: " & Realms(0).strName
            Else
                lblCore1Title.Text = "Core: No realm active"
            End If
        Catch ex As Exception
            lblCore1Title.Text = "Core: No realm active"
        End Try


        Try
            If Realms(1).Active Then
                lblCore2Title.Text = "Core: " & Realms(1).strName
            Else
                lblCore2Title.Text = "Core: No realm active"
            End If
        Catch ex As Exception
            lblCore2Title.Text = "Core: No realm active"
        End Try

        Try
            If Realms(2).Active Then
                lblCore3Title.Text = "Core: " & Realms(2).strName
            Else
                lblCore3Title.Text = "Core: No realm active"
            End If
        Catch ex As Exception
            lblCore3Title.Text = "Core: No realm active"
        End Try
    End Sub
#End Region

#Region "Backup Functions"
    Private Sub cmdBackupNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBackupNow.Click
        BackupDatabases()
    End Sub
#End Region

#Region "TrinityDB"

    Private Sub EventFinishedCountingAccounts(ByVal count As Integer)
        Log("START: EventFinishedCountingAccounts: " & Accounts & ":" & count, "DEBUG")
        If Not Accounts = count Then
            Dim thLoadAccounts As New System.Threading.Thread(AddressOf TrinityDB.GetAccounts)
            AddHandler TrinityDB.EventFinishedAccInfo, AddressOf EventFinishedAccInfo
            If Not WaitingForInitialAccountLoad Then thLoadAccounts.Start()

            While thLoadAccounts.IsAlive
                Application.DoEvents()
            End While

            Accounts = count

            Log("EventFinishedCountingAccounts: SET REBuildAccountList = True", "DEBUG")
            REBuildAccountList = True 'rebuild account list
        End If
        Log("END: EventFinishedCountingAccounts: " & Accounts & ":" & count, "DEBUG")
    End Sub

    Private Sub EventFinishedCountingCharacters(ByVal count As Integer)
        Log("START: EventFinishedCountingCharacters: " & NumCharacters & ":" & count, "DEBUG")
        If Not NumCharacters = count Then
            Dim thGetCharList As New System.Threading.Thread(AddressOf TrinityDB.GetCharactersList)
            AddHandler TrinityDB.EventFinishedGetCharactersList, AddressOf EventFinishedGetCharactersList
            thGetCharList.Start()

            While thGetCharList.IsAlive
                Application.DoEvents()
            End While

            NumCharacters = count
        End If
        Log("END: EventFinishedCountingCharacters: " & NumCharacters & ":" & count, "DEBUG")
    End Sub

    Private Sub EventFinishedCountingOnlineAccounts(ByVal count As Integer)
        Log("START: EventFinishedCountingOnlineAccounts", "DEBUG")

        If Not AccountsOnline = count Then
            Log("EventFinishedCountingOnlineAccounts: Difference in accounts detected.", "DEBUG")

            'Update account array
            Dim thLoadAccounts As New System.Threading.Thread(AddressOf TrinityDB.GetAccounts)
            AddHandler TrinityDB.EventFinishedAccInfo, AddressOf EventFinishedAccInfo
            thLoadAccounts.Start()

            'update online counter
            AccountsOnline = count

            'Wait while account information arrays are being updated
            While thLoadAccounts.IsAlive
                Application.DoEvents()
            End While

            'shows the number of online players on status screen
            UpdateOnlineAccounts()

            'Update account list to show new online status
            UpdateOnlineAccountStatus()
        End If

        WaitingForInitialAccountLoad = False
        Log("END: EventFinishedCountingOnlineAccounts", "DEBUG")
    End Sub

    Public Sub CheckAccountUpdateStatus()
        Do While True
            If REBuildAccountList Then
                Log("CheckAccountUpdateStatus: REBuildAccountList Requested.", "DEBUG")
                GenerateAccountList()
                REBuildAccountList = False
            End If

            System.Threading.Thread.Sleep(500)
        Loop
    End Sub

    Private Sub EventFinishedAccInfo()
        'nothing to do
    End Sub

    Private Sub EventFinishedGetCharactersForAccount()
        Log("START: EventFinishedGetCharactersForAccount", "DEBUG")
        GenerateCharactersList()
        Log("END: EventFinishedGetCharactersForAccount", "DEBUG")
    End Sub

    Private Sub EventFinishedGetCharactersList()
        Log("START: EventFinishedGetCharactersList", "DEBUG")
        GenerateAllCharactersList()
        Log("END: EventFinishedGetCharactersList", "DEBUG")
    End Sub

    Private Sub UpdateOnlineAccounts()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateOnlineAccounts))
        Else
            Dim strAccountsOnline As String
            Select Case AccountsOnline
                Case 1
                    strAccountsOnline = ""
                Case Else
                    strAccountsOnline = "s"
            End Select
            lblNumOnline.Text = AccountsOnline & " Account" & strAccountsOnline & " online."
        End If
    End Sub

    Private Sub GenerateAccountList()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf GenerateAccountList))
        Else
            If GenAccBusy Then
                Log("GererateAccountList: SUB BUSY--------------------------!!!", "DEBUG")
                Do While GenAccBusy
                    Application.DoEvents()
                Loop
            Else
                Log("START: GenerateAccountList", "DEBUG")
                GenAccBusy = True

                'wait until account information is gathered
                Do While GeneratingAccountInfo
                    Application.DoEvents()
                Loop

                Dim currentAccount As Integer = 0

                Dim itemList As New List(Of System.Windows.Forms.ListViewItem)
                lvAccounts.Visible = False
                lvAccounts.Items.Clear()

                TrinityDB.CheckIfBanned()

                Try
                    For currentAccount = 0 To InfoAccount.Length - 1
                        'set account status
                        Dim accountStatus As Integer = Nothing
                        If InfoAccount(currentAccount).Banned Then
                            accountStatus = 2
                        Else
                            accountStatus = InfoAccount(currentAccount).Online
                        End If

                        'set status group
                        Dim accountGroup As ListViewGroup = Nothing
                        Select Case accountStatus
                            Case 0
                                'account online
                                accountGroup = lvAccounts.Groups(1)
                            Case 1
                                'account online
                                accountGroup = lvAccounts.Groups(0)
                            Case 2
                                'account banned
                                accountGroup = lvAccounts.Groups(2)
                            Case Else
                                'account unknown, so offline
                                accountGroup = lvAccounts.Groups(1)
                        End Select

                        Dim lvItemAccount As New ListViewItem(InfoAccount(currentAccount).Name, accountStatus, accountGroup)
                        itemList.Add(lvItemAccount)
                        lvItemAccount = Nothing

                        Application.DoEvents()
                    Next

                    lvAccounts.Items.AddRange(itemList.ToArray)
                    lvAccounts.Visible = True

                    SetAccountLevel()

                Catch ex As Exception
                    Log("GenerateAccountList: " & Err.Description, "ERROR")
                    lvAccounts.Visible = True
                    cmdReload.Enabled = True
                    GenAccBusy = False
                End Try
            End If
        End If
        cmdReload.Enabled = True
        GenAccBusy = False

        Log("END: GenerateAccountList", "DEBUG")
    End Sub

    Private Sub SetAccountLevel()
        Log("START: SetAccountLevel", "DEBUG")
        For currentAccount = 0 To InfoAccount.Length - 1
            'set gm level colours
            Select Case InfoAccount(currentAccount).GMLvl
                Case 0
                    'Player
                    lvAccounts.Items.Item(currentAccount).ToolTipText = "This user is a standard player"
                Case 1
                    'Moderator
                    lvAccounts.Items.Item(currentAccount).ForeColor = Color.Blue
                    lvAccounts.Items.Item(currentAccount).ToolTipText = "This user is a Moderator"
                Case 2
                    'Game Master
                    lvAccounts.Items.Item(currentAccount).ForeColor = Color.Green
                    lvAccounts.Items.Item(currentAccount).ToolTipText = "This user is a Game Master"
                Case 3
                    'Administrator
                    lvAccounts.Items.Item(currentAccount).ForeColor = Color.Red
                    lvAccounts.Items.Item(currentAccount).ToolTipText = "This user is an Administrator"
            End Select
            Application.DoEvents()
        Next
        Log("END: SetAccountLevel", "DEBUG")
    End Sub

    Private Sub GenerateAllCharactersList()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf GenerateAllCharactersList))
        Else
            Log("START: GenerateAllCharactersList", "DEBUG")

            lvIMChar.Visible = False
            lvIMChar.Items.Clear()

            Dim currentCharacter As Integer = 0
            Dim itemList As New List(Of System.Windows.Forms.ListViewItem)

            Try
                For currentCharacter = 0 To AllCharacters.Length - 1
                    Dim infCharacters As New ListViewItem(AllCharacters(currentCharacter).Name)
                    infCharacters.ToolTipText = "GUID: " & AllCharacters(currentCharacter).GUID
                    infCharacters.SubItems.Add(AllCharacters(currentCharacter).RealmName)
                    infCharacters.SubItems.Add(AllCharacters(currentCharacter).RealmID.ToString)
                    If Not AllCharacters(currentCharacter).RealmName = Nothing Then itemList.Add(infCharacters)

                    Application.DoEvents()
                Next
            Catch ex As Exception
                Log("GenerateAllCharactersList: " & Err.Description, "ERROR")
                cmdReload.Enabled = True
            End Try

            lvIMChar.Items.AddRange(itemList.ToArray)
            lvIMChar.Visible = True
            Log("END: GenerateAllCharactersList", "DEBUG")
        End If

        cmdReload.Enabled = True
    End Sub

    Private Sub GenerateCharactersList()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf GenerateAccountList))
        Else
            Log("START: GenerateCharactersList", "DEBUG")

            lvCharacters.Visible = False
            lvCharacters.Items.Clear()

            Dim currentCharacter As Integer = 0
            Dim itemList As New List(Of System.Windows.Forms.ListViewItem)

            For currentCharacter = 0 To InfoCharacter.Length - 1
                Dim infCharacter As New ListViewItem(InfoCharacter(currentCharacter).Name, InfoCharacter(currentCharacter).Online)
                infCharacter.ToolTipText = "GUID: " & InfoCharacter(currentCharacter).GUID
                infCharacter.SubItems.Add(InfoCharacter(currentCharacter).RealmName)
                infCharacter.SubItems.Add(InfoCharacter(currentCharacter).GUID.ToString.ToString)
                If Not InfoCharacter(currentCharacter).RealmName = Nothing Then itemList.Add(infCharacter)

                Application.DoEvents()
            Next

            lvCharacters.Items.AddRange(itemList.ToArray)
            lvCharacters.Visible = True
            Log("START: GenerateCharactersList", "DEBUG")
        End If
    End Sub

    Private Sub UpdateOnlineAccountStatus()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateOnlineAccountStatus))
        Else
            If Not IsUpdatingStatus And Not REBuildAccountList And AccountsDone Then
                Log("START: UpdateOnlineAccountStatus", "DEBUG")
                IsUpdatingStatus = True

                Try
                    For intAccount = 0 To lvAccounts.Items.Count - 1
                        Dim accountOnline As Integer = 0

                        'Check if account is banned
                        If InfoAccount(intAccount).Banned Then
                            accountOnline = 2
                        Else
                            accountOnline = InfoAccount(intAccount).Online
                        End If

                        'set online status
                        If Not lvAccounts.Items.Item(intAccount).ImageIndex = accountOnline Then
                            lvAccounts.Items.Item(intAccount).ImageIndex = accountOnline
                            Select Case accountOnline
                                Case 0
                                    lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Offline")
                                Case 1
                                    lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Online")

                                    'Announce online status
                                    Select Case InfoAccount(intAccount).GMLvl
                                        Case 1 'moderator
                                            If chkModOnline.Checked Then
                                                'Announce("A Moderator has just logged on, user: " & objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name))
                                                Dim CharInf() As String = objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name).Split(Convert.ToChar(";"))
                                                Dim CharName As String = CharInf(0)
                                                Dim CharRealm As Integer = Convert.ToInt16(CharInf(1))
                                                Dim NewMsg As String = ModOnlineMessage.Replace("[name]", CharName)
                                                Announce(NewMsg, CharRealm)
                                            End If
                                        Case 2 'gm
                                            If chkGMOnline.Checked Then
                                                'Announce("A Game Master has just logged on, user: " & objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name))
                                                Dim CharInf() As String = objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name).Split(Convert.ToChar(";"))
                                                Dim CharName As String = CharInf(0)
                                                Dim CharRealm As Integer = Convert.ToInt16(CharInf(1))
                                                Dim NewMsg As String = GMOnlineMessage.Replace("[name]", CharName)
                                                Announce(NewMsg, CharRealm)
                                            End If
                                        Case 3 'admin
                                            If chkAdminOnline.Checked Then
                                                'Announce("An Administrator has just logged on, user: " & objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name))
                                                Dim CharInf() As String = objAccountInfo.GetOnlineCharForAccount(InfoAccount(intAccount).Name).Split(Convert.ToChar(";"))
                                                Dim CharName As String = CharInf(0)
                                                Dim CharRealm As Integer = Convert.ToInt16(CharInf(1))
                                                Dim NewMsg As String = AdminOnlineMessage.Replace("[name]", CharName)
                                                Announce(NewMsg, CharRealm)
                                            End If
                                    End Select
                                Case 2
                                    lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Banned")
                            End Select
                        End If
                        Application.DoEvents()
                    Next

                    'update characters
                    If lvAccounts.SelectedItems.Count > 0 Then
                        AddHandler TrinityDB.EventFinishedGetCharactersForAccount, AddressOf EventFinishedGetCharactersForAccount
                        TrinityDB.GetCharactersForAccount(lvAccounts.SelectedItems(0).Text)
                    End If
                Catch
                    IsUpdatingStatus = False
                    lvCharacters.Items.Clear()
                    Log(Err.Description, "ERROR")
                End Try

                IsUpdatingStatus = False
            End If
            AccountsDone = True
            Log("END: UpdateOnlineAccountStatus", "DEBUG")
        End If
    End Sub

    Private Sub UpdateListAccount(ByVal strAccount As String)
        Try
            For intAccount = 0 To InfoAccount.Length - 1
                Log("START: UpdateListAccount: " & InfoAccount(intAccount).Name & " : " & strAccount, "DEBUG")
                If InfoAccount(intAccount).Name = strAccount Then
                    Log("ACCOUNT MATCH: UpdateListAccount: " & strAccount, "DEBUG")
                    'Check if account is banned
                    Dim accountOnline As Integer = 0
                    If InfoAccount(intAccount).Banned Then
                        accountOnline = 2
                    Else
                        accountOnline = InfoAccount(intAccount).Online
                    End If

                    If Not lvAccounts.Items.Item(intAccount).ImageIndex = accountOnline Then
                        lvAccounts.Items.Item(intAccount).ImageIndex = accountOnline
                        Select Case accountOnline
                            Case 0
                                lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Offline")
                            Case 1
                                lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Online")
                            Case 2
                                lvAccounts.Items.Item(intAccount).Group = lvAccounts.Groups("Banned")
                        End Select

                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
            Log("UpdateListAccount: " & Err.Description, "DEBUG")
        End Try
    End Sub
#End Region

#Region "Trinity Windows"
    Private Sub btnShowTrinity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTrinity.Click
        If Realms(0).Active Then SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
        If Realms(1).Active Then SetWindowState(Realms(1).strCoreFile, SWShownoactivate)
        If Realms(2).Active Then SetWindowState(Realms(2).strCoreFile, SWShownoactivate)
        SetWindowState(TrinityRealmFile, SWShownoactivate)
    End Sub

    Private Sub bthHideTrinity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHideTrinity.Click
        If Realms(0).Active Then SetWindowState(Realms(0).strCoreFile, SWHide)
        If Realms(1).Active Then SetWindowState(Realms(1).strCoreFile, SWHide)
        If Realms(2).Active Then SetWindowState(Realms(2).strCoreFile, SWHide)
        SetWindowState(TrinityRealmFile, SWHide)
    End Sub
#End Region

#Region "Restart Functions"
    Private Sub cmdRestartCore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartCore1.Click
        KillNicely(Realms(0).strCoreFile)
    End Sub

    Private Sub cmdRestartCore2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartCore2.Click
        KillNicely(Realms(1).strCoreFile)
    End Sub

    Private Sub cmdRestartCore3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartCore3.Click
        KillNicely(Realms(2).strCoreFile)
    End Sub

    Private Sub cmdRestartRealm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartRealm.Click
        KillNicely(TrinityRealmFile)
    End Sub

    Private Sub cmdRestartTrinity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestartTrinity.Click
        If MsgBox("Are you sure you want to restart both Realm and all Core processes?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            KillNicely(TrinityRealmFile)
            System.Threading.Thread.Sleep(500)
            KillNicely(Realms(0).strCoreFile)
            System.Threading.Thread.Sleep(500)
            KillNicely(Realms(1).strCoreFile)
            System.Threading.Thread.Sleep(500)
            KillNicely(Realms(2).strCoreFile)
        End If
    End Sub


#End Region

#Region "Timers"
    Private Sub tmrBackup_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBackup.Tick
        'wait for 10 seconds
        If BackupTimer < 10 Then
            BackupTimer = BackupTimer + 1
            Exit Sub
        End If

        'Check World DB counter
        If BackupWorldDB Then
            If (intWorldDBCount = WorldDatabaseBackupInterval) Or FirstBackup Then
                BakWorld()
                intWorldDBCount = 0
                WorldBakCountDown = Now.AddMinutes(WorldDatabaseBackupInterval / 60)
            Else
                intWorldDBCount = intWorldDBCount + 1
            End If
            Dim wts As TimeSpan = WorldBakCountDown.Subtract(Now)
            lblWorldBak.Text = FormatTimeSpan(wts)
        Else
            lblWorldBak.Text = "Backup disabled"
        End If

        'Check Realm DB Counter
        If BackupRealmDB Then
            If (intRealmDBCount = RealmDatabaseBackupInterval) Or FirstBackup Then
                BakRealm()
                intRealmDBCount = 0
                RealmBakCountDown = Now.AddMinutes(RealmDatabaseBackupInterval / 60)
            Else
                intRealmDBCount = intRealmDBCount + 1
            End If
            Dim rts As TimeSpan = RealmBakCountDown.Subtract(Now)
            lblRealmBak.Text = FormatTimeSpan(rts)
        Else
            lblRealmBak.Text = "Backup disabled"
        End If

        'Check Character DB Counter
        If BackupCharactersDB Then
            If (intCharDBCount = CharacterDatabaseBackupInterval) Or FirstBackup Then
                BakChar()
                intCharDBCount = 0
                CharBakCountDown = Now.AddMinutes(CharacterDatabaseBackupInterval / 60)
            Else
                intCharDBCount = intCharDBCount + 1
            End If
            Dim cts As TimeSpan = CharBakCountDown.Subtract(Now)
            lblCharBak.Text = FormatTimeSpan(cts)
        Else
            lblCharBak.Text = "Backup disabled"
        End If

        'Check Table Counter
        If BackupWorldTables Or BackupCharactersTables Or BackupRealmTables Then
            If intTableCount = TableBackupInterval Or FirstBackup Then
                BakTables()
                intTableCount = 0
                TableBakCountDown = Now.AddMinutes(TableBackupInterval / 60)
            Else
                intTableCount = intTableCount + 1
            End If
            Dim tts As TimeSpan = TableBakCountDown.Subtract(Now)
            lblTableBak.Text = FormatTimeSpan(tts)
        Else
            lblTableBak.Text = "Backup disabled"
        End If

        FirstBackup = False

        If Not BackupCharactersDB And Not BackupCharactersTables And Not BackupRealmDB And Not BackupRealmTables And Not BackupWorldDB And Not BackupWorldTables Then tmrBackup.Enabled = False

    End Sub

    Private Sub tmrUpTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpTime.Tick
        If Realms(0).Active Then
            If HaltCore1 Then
                lblCore1UpTime.Text = "Halted for other operations..."
            Else
                If Core1Up Then
                    GetNewCore1PID = False
                    GotNewCore1PID = False
                    Dim coreElapsedUptime As TimeSpan
                    coreElapsedUptime = Now.Subtract(Core1UpTime)
                    If Not RetryCore1 Then lblCore1UpTime.Text = FormatTimeSpan(coreElapsedUptime)
                Else
                    If WaitForCore1 Then
                        If Not GotNewCore1PID Then
                            Log("GetNewCore1PID=True, GotNewCore1PID = True", "DEBUG")
                            GetNewCore1PID = True
                            If Not Core1LastPID = Core1PID And Not Core1PID = 0 Then
                                GotNewCore1PID = True
                                Core1LastPID = Core1PID
                            End If
                        Else
                            Log("GetNewCore1PID=False", "DEBUG")
                            GetNewCore1PID = False
                        End If
                        lblCore1UpTime.Text = "Restarting Core 1: Please wait..."
                    Else
                        lblCore1UpTime.Text = "Core 1 down."
                    End If
                End If

                If RetryCore1 Then
                    lblCore1UpTime.Text = "Waiting for Core 1 response... " & IntCore1DownCount & "/3"
                    pbCore1.Image = imglstImages.Images(2)
                End If
            End If
        End If

        If Realms(1).Active Then
            If HaltCore2 Then
                lblCore2UpTime.Text = "Halted for other operations..."
            Else
                If Core2Up Then
                    GetNewCore2PID = False
                    GotNewCore2PID = False
                    Dim coreElapsedUptime As TimeSpan
                    coreElapsedUptime = Now.Subtract(Core2UpTime)
                    If Not RetryCore2 Then lblCore2UpTime.Text = FormatTimeSpan(coreElapsedUptime)
                Else
                    If WaitForCore2 Then
                        If Not GotNewCore2PID Then
                            Log("GetNewCore2PID=True, GotNewCore2PID = True", "DEBUG")
                            GetNewCore2PID = True
                            If Not Core2LastPID = Core2PID And Not Core2PID = 0 Then
                                GotNewCore2PID = True
                                Core2LastPID = Core3PID
                            End If
                        Else
                            Log("GetNewCore2PID=False", "DEBUG")
                            GetNewCore2PID = False
                        End If
                        lblCore2UpTime.Text = "Restarting Core 2: Please wait..."
                    Else
                        lblCore2UpTime.Text = "Core 2 down."
                    End If
                End If

                If RetryCore2 Then
                    lblCore2UpTime.Text = "Waiting for Core 2 response... " & IntCore2DownCount & "/3"
                    pbCore2.Image = imglstImages.Images(2)
                End If
            End If
        End If

        If Realms(2).Active Then
            If HaltCore3 Then
                lblCore3UpTime.Text = "Halted for other operations..."
            Else
                If Core3Up Then
                    GetNewCore3PID = False
                    GotNewCore3PID = False
                    Dim coreElapsedUptime As TimeSpan
                    coreElapsedUptime = Now.Subtract(Core3UpTime)
                    If Not RetryCore3 Then lblCore3UpTime.Text = FormatTimeSpan(coreElapsedUptime)
                Else
                    If WaitForCore3 Then
                        If Not GotNewCore3PID Then
                            Log("GetNewCore3PID=True, GotNewCore3PID = True", "DEBUG")
                            GetNewCore3PID = True
                            If Not Core3LastPID = Core3PID And Not Core3PID = 0 Then
                                GotNewCore3PID = True
                                Core3LastPID = Core3PID
                            End If
                        Else
                            Log("GetNewCore3PID=False", "DEBUG")
                            GetNewCore3PID = False
                        End If
                        lblCore3UpTime.Text = "Restarting Core 3: Please wait..."
                    Else
                        lblCore3UpTime.Text = "Core 3 down."
                    End If
                End If

                If RetryCore3 Then
                    lblCore3UpTime.Text = "Waiting for Core 3 response... " & IntCore3DownCount & "/3"
                    pbCore3.Image = imglstImages.Images(2)
                End If
            End If
        End If

        If HaltRealm Then
            lblRealmUpTime.Text = "Halted for other operations..."
        Else
            If RealmUp Then
                GetNewRealmPID = False
                GotNewRealmPID = False
                Dim realmElapsedUptime As TimeSpan
                realmElapsedUptime = Now.Subtract(RealmUpTime)
                If Not RetryRealm Then lblRealmUpTime.Text = FormatTimeSpan(realmElapsedUptime)
            Else
                If WaitForRealm Then
                    If Not GotNewRealmPID Then
                        Log("GetNewRealmPID=True, GotNewRealmPID = True", "DEBUG")
                        GetNewRealmPID = True
                        If Not RealmLastPID = RealmPID And Not RealmPID = 0 Then
                            GotNewRealmPID = True
                            RealmLastPID = RealmPID
                        End If
                    Else
                        Log("GetNewRealmPID=False", "DEBUG")
                        GetNewRealmPID = False
                    End If
                    lblRealmUpTime.Text = "Restarting Realm: Please wait..."
                Else
                    lblRealmUpTime.Text = "Realm down."
                End If
            End If

            If RetryRealm Then
                lblRealmUpTime.Text = "Waiting for Realm response... " & IntRealmDownCount & "/3"
                pbRealm.Image = imglstImages.Images(2)
            End If
        End If
    End Sub

    Private Sub tmrUpdateStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateStatus.Tick
        If ClosePending Then
            niStatus.Visible = False
            Me.Close()
        End If

        Try
            'Test Realm
            If Not RealmUp = RealmLastStatus Or FirstLaunch Then
                Select Case RealmUp
                    Case True
                        RealmUpTime = Now
                        If Not RetryRealm Then pbRealm.Image = imglstImages.Images(0)
                    Case False
                        If Not RetryRealm Then pbRealm.Image = imglstImages.Images(1)
                End Select
            End If
            RealmLastStatus = RealmUp
            lblRealmCrashes.Text = RealmCrashCount.ToString
            ''CHECK FOP LOOP
            'Test Core
            If Realms(0).Active Then
                If Not Core1Up = Core1LastStatus Or FirstLaunch Then
                    Select Case Core1Up
                        Case True
                            Core1UpTime = Now
                            If Not RetryCore1 Then pbCore1.Image = imglstImages.Images(0)
                        Case False
                            If Not RetryCore1 Then pbCore1.Image = imglstImages.Images(1)
                    End Select
                End If
                Core1LastStatus = Core1Up
                lblCore1Crashes.Text = Core1CrashCount.ToString
            End If

            If Realms(1).Active Then
                If Not Core2Up = Core2LastStatus Or FirstLaunch Then
                    Select Case Core2Up
                        Case True
                            Core2UpTime = Now
                            If Not RetryCore2 Then pbCore2.Image = imglstImages.Images(0)
                        Case False
                            If Not RetryCore2 Then pbCore2.Image = imglstImages.Images(1)
                    End Select
                End If
                Core2LastStatus = Core2Up
                lblCore2Crashes.Text = Core2CrashCount.ToString
            End If

            If Realms(2).Active Then
                If Not Core3Up = Core3LastStatus Or FirstLaunch Then
                    Select Case Core3Up
                        Case True
                            Core3UpTime = Now
                            If Not RetryCore3 Then pbCore3.Image = imglstImages.Images(0)
                        Case False
                            If Not RetryCore3 Then pbCore3.Image = imglstImages.Images(1)
                    End Select
                End If
                Core3LastStatus = Core3Up
                lblCore3Crashes.Text = Core3CrashCount.ToString
            End If
        Catch
            'do nothing
        End Try

        'Check server status
        AllCoresUp = True
        If Realms(0).Active And Not Core1Up Then AllCoresUp = False
        If Realms(1).Active And Not Core2Up Then AllCoresUp = False
        If Realms(2).Active And Not Core3Up Then AllCoresUp = False

        If AllCoresUp And RealmUp Then
            ServerUp = True
            If Not ServerUp = ServerLastStatus Or FirstLaunch Then
                UpdateSystemTray(1, "Server up.")
            End If
            ServerLastStatus = ServerUp
        Else
            ServerUp = False
            If Not ServerUp = ServerLastStatus Or FirstLaunch Then
                UpdateSystemTray(0, "Server down.")
            End If
            ServerLastStatus = ServerUp
        End If

        FirstLaunch = False
    End Sub

    Private Sub tmrSaveIcon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSaveIcon.Tick
        Select Case IntLastIcon
            Case 0
                UpdateSystemTray(2, "")
            Case 1
                UpdateSystemTray(2, "")
            Case 2
                UpdateSystemTray(3, "")
            Case 3
                UpdateSystemTray(2, "")
            Case Else
                UpdateSystemTray(2, "")
        End Select
    End Sub

#End Region

#Region "Broadcasts and Messaging"
    Private Sub cmdNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotify.Click
        Select Case cbCoreMessage.Text
            Case "Core 1"
                If Realms(0).Active Then Notify(txtSend.Text, 0)
            Case "Core 2"
                If Realms(1).Active Then Notify(txtSend.Text, 1)
            Case "Core 3"
                If Realms(2).Active Then Notify(txtSend.Text, 2)
            Case "All Cores"
                If Realms(0).Active Then Notify(txtSend.Text, 0)
                If Realms(1).Active Then Notify(txtSend.Text, 1)
                If Realms(2).Active Then Notify(txtSend.Text, 2)
        End Select
    End Sub

    Private Sub cmdAnnounce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnounce.Click
        Select Case cbCoreMessage.Text
            Case "Core 1"
                If Realms(0).Active Then Announce(txtSend.Text, 0)
            Case "Core 2"
                If Realms(1).Active Then Announce(txtSend.Text, 1)
            Case "Core 3"
                If Realms(2).Active Then Announce(txtSend.Text, 2)
            Case "All Cores"
                If Realms(0).Active Then Announce(txtSend.Text, 0)
                If Realms(1).Active Then Announce(txtSend.Text, 1)
                If Realms(2).Active Then Announce(txtSend.Text, 2)
        End Select
    End Sub

    Private Sub cmdMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMail.Click
        If lvIMChar.Items.Count > 0 Then
            If lvIMChar.SelectedItems.Count > 0 Then
                For Each item As ListViewItem In lvIMChar.SelectedItems
                    SendMail(item.Text, Convert.ToInt16(item.SubItems(2).Text), txtIMSubject.Text, txtIMMessage.Text, txtIMMoney.Text, txtIMItems.Text)
                Next
            End If
        End If
    End Sub

    Private Sub txtSend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSend.KeyPress
        If e.KeyChar = vbCr Then
            MsgBox("New lines are not supported.", MsgBoxStyle.Information, "Not supported")
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtSend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSend.TextChanged
        If txtSend.TextLength > 0 Then
            cmdAnnounce.Enabled = True
            cmdNotify.Enabled = True
        Else
            cmdAnnounce.Enabled = False
            cmdNotify.Enabled = False
        End If
    End Sub

    Private Sub cmdSaveOnlineAlerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveOnlineAlerts.Click
        AdminOnlineMessage = txtAdminOnline.Text
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "AdminOnlineMessage", txtAdminOnline.Text)

        GMOnlineMessage = txtGMOnline.Text
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "GMOnlineMessage", txtGMOnline.Text)

        ModOnlineMessage = txtModOnline.Text
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "ModOnlineMessage", txtModOnline.Text)

        cmdSaveOnlineAlerts.Enabled = False
    End Sub

    Private Sub txtAdminOnline_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdminOnline.TextChanged
        If cmdSaveOnlineAlerts.Enabled = False Then cmdSaveOnlineAlerts.Enabled = True
    End Sub

    Private Sub txtGMOnline_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGMOnline.TextChanged
        If cmdSaveOnlineAlerts.Enabled = False Then cmdSaveOnlineAlerts.Enabled = True
    End Sub

    Private Sub txtModOnline_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModOnline.TextChanged
        If cmdSaveOnlineAlerts.Enabled = False Then cmdSaveOnlineAlerts.Enabled = True
    End Sub

    Private Sub chkAdminOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdminOnline.CheckedChanged
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "ADMINISTRATOR", chkAdminOnline.Checked.ToString)
        If chkAdminOnline.Checked Then
            txtAdminOnline.Enabled = True
        Else
            txtAdminOnline.Enabled = False
        End If
    End Sub

    Private Sub chkGMOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGMOnline.CheckedChanged
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "GAME MASTER", chkGMOnline.Checked.ToString)
        If chkGMOnline.Checked Then
            txtGMOnline.Enabled = True
        Else
            txtGMOnline.Enabled = False
        End If
    End Sub

    Private Sub chkModOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModOnline.CheckedChanged
        ObjIniFile.WriteString("AUTO-ANNOUNCE", "MODERATOR", chkModOnline.Checked.ToString)
        If chkModOnline.Checked Then
            txtModOnline.Enabled = True
        Else
            txtModOnline.Enabled = False
        End If
    End Sub

    Private Sub txtIMMessage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIMMessage.KeyPress
        If e.KeyChar = vbCr Then
            MsgBox("New lines are not supported.", MsgBoxStyle.Information, "Not supported")
            e.KeyChar = Nothing
        End If
    End Sub
#End Region

#Region "Button ToolTips"
    Private Sub btnHideTrinity_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHideTrinity.MouseHover
        ToolTip.SetToolTip(btnHideTrinity, "Hide the Trinity windows")
    End Sub

    Private Sub btnShowTrinity_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowTrinity.MouseHover
        ToolTip.SetToolTip(btnShowTrinity, "Show the Trinity windows")
    End Sub

    Private Sub cmdHide_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHide.MouseHover
        ToolTip.SetToolTip(cmdHide, "Minimize TriniGuard to tray")
    End Sub

    Private Sub btnConfigure_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfigure.MouseHover
        ToolTip.SetToolTip(btnConfigure, "Configuration")
    End Sub

    Private Sub cmdBackupNow_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBackupNow.MouseHover
        ToolTip.SetToolTip(cmdBackupNow, "Run backup now")
    End Sub

    Private Sub cmdNotify_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNotify.MouseHover
        ToolTip.SetToolTip(cmdNotify, "Sends a message to all online users.  Message appears in middle of screen.")
    End Sub

    Private Sub cmdAnnounce_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAnnounce.MouseHover
        ToolTip.SetToolTip(cmdAnnounce, "Sends a message to all online users.  Message appears in the chat window.")
    End Sub

    Private Sub cmdBan_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBan.MouseHover
        If cmdBan.ImageIndex = 2 Then
            ToolTip.SetToolTip(cmdBan, "Ban account")
        Else
            ToolTip.SetToolTip(cmdBan, "Unban account")
        End If
    End Sub

    Private Sub cmdAddUser_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddUser.MouseHover
        ToolTip.SetToolTip(cmdAddUser, "Create an account")
    End Sub

    Private Sub cmdDeleteUser_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeleteUser.MouseHover
        ToolTip.SetToolTip(cmdDeleteUser, "Delete the selected account")
    End Sub

    Private Sub cmdKick_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdKick.MouseHover
        ToolTip.SetToolTip(cmdKick, "Kick the selected character")
    End Sub

    Private Sub cmdRestartCore1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestartCore1.MouseHover
        ToolTip.SetToolTip(cmdRestartCore1, "Restart Core Server 1")
    End Sub

    Private Sub cmdRestartCore2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestartCore2.MouseHover
        ToolTip.SetToolTip(cmdRestartCore2, "Restart Core Server 2")
    End Sub

    Private Sub cmdRestartCore3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestartCore3.MouseHover
        ToolTip.SetToolTip(cmdRestartCore3, "Restart Core Server 3")
    End Sub

    Private Sub cmdRestartRealm_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestartRealm.MouseHover
        ToolTip.SetToolTip(cmdRestartRealm, "Restart Realm Server")
    End Sub

    Private Sub cmdRestartTrinity_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestartTrinity.MouseHover
        ToolTip.SetToolTip(cmdRestartTrinity, "Restart both Core and Realm processes.")
    End Sub

    Private Sub cmdReload_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReload.MouseHover
        ToolTip.SetToolTip(cmdReload, "Reload account list.")
    End Sub

    Private Sub cmdGMLvl_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGMLvl.MouseHover
        ToolTip.SetToolTip(cmdGMLvl, "Set GM Level")
    End Sub

    Private Sub cmdExpLvl_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExpLvl.MouseHover
        ToolTip.SetToolTip(cmdExpLvl, "Set Expansion Level")
    End Sub

    Private Sub lvIMChar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvIMChar.MouseHover
        ToolTip.SetToolTip(lvIMChar, "You can choose multiple characters to send mail to using the CTRL or SHIFT key.")
    End Sub
#End Region

#Region "Server Info Functions"
    Private Sub GetServerVersions()
        Log("GetServerVersions", "DEBUG")
        TrinityDB.GetVersions()
        lblCoreVer.Text = InfoVersion.Core
        lblCoreRev.Text = InfoVersion.CoreRev
        lblDBVer.Text = InfoVersion.DB
    End Sub

#End Region

#Region "Accounts Functions"
    Private Sub lvAccounts_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles lvAccounts.HelpRequested
        MsgBox("There are " & lvAccounts.Items.Count.ToString & " accounts.")
    End Sub

    Private Sub lvAccounts_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvAccounts.MouseClick
        'If e.Button = Windows.Forms.MouseButtons.Left Then
        SetBanButton()
        If lvAccounts.Items.Count > 0 And AllCoresUp Then
            cmdDeleteUser.Enabled = True
            cmdGMLvl.Enabled = True
            cmdExpLvl.Enabled = True
        Else
            cmdDeleteUser.Enabled = False
            cmdGMLvl.Enabled = False
            cmdExpLvl.Enabled = False
        End If
        'Else
        'nothing to do yet, menu will go here.
        'End If
    End Sub

    Private Sub lvAccounts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAccounts.SelectedIndexChanged
        If lvAccounts.SelectedItems.Count > 0 Then
            'get character info
            AddHandler TrinityDB.EventFinishedGetCharactersForAccount, AddressOf EventFinishedGetCharactersForAccount
            TrinityDB.GetCharactersForAccount(lvAccounts.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub cmdAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUser.Click
        Dim strUserName As String = InputBox("Please enter username", "Username", "")
        If strUserName = "" Then Exit Sub
        Dim strPassword As String = InputBox("Please enter password", "Password", "")
        If strPassword = "" Then Exit Sub
        Dim strGMLevel As String = InputBox("Please enter GM Level", "GM Level", "0")
        Dim intExpansionLevel As Integer = Convert.ToInt16(InputBox("Please enter an expansion level", "Expansion", "2"))

        AddUser(strUserName, strPassword, strGMLevel, intExpansionLevel)

        ProcessAccountsNow = True
    End Sub

    Private Sub cmdDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteUser.Click
        If lvAccounts.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure you want to delete " & lvAccounts.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo, "Delete account") = vbYes Then
                DeleteAllChars()
                DeleteUser(lvAccounts.SelectedItems(0).Text)

                ProcessAccountsNow = True
            End If
        End If
        cmdDeleteUser.Enabled = False
    End Sub

    Private Sub cmdBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBan.Click
        If lvAccounts.SelectedItems.Count > 0 Then
            Dim strUser As String = lvAccounts.SelectedItems(0).Text

            Select Case cmdBan.ImageIndex
                Case 2
                    If MsgBox("Are you sure you want to ban " & lvAccounts.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo, "Ban account") = vbYes Then
                        Dim strTime As String = InputBox("How long is the user being banned for?", "Ban duration", "1d2h4s")
                        Dim strReason As String = InputBox("Why is the user being banned?", "Ban reason", "Breach of rules")

                        If strTime = " " Or strReason = "" Then Exit Sub

                        BanUser(strUser, strTime, Convert.ToChar(34) & strReason & Convert.ToChar(34))
                        InfoAccount(GetArrayIndexByName(lvAccounts.SelectedItems(0).Text)).Banned = True
                        UpdateListAccount(strUser)
                    End If
                Case 3
                    If MsgBox("Are you sure you want to unban " & lvAccounts.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo, "Unban account") = vbYes Then
                        UNBanUser(lvAccounts.SelectedItems(0).Text)
                        InfoAccount(GetArrayIndexByName(lvAccounts.SelectedItems(0).Text)).Banned = False
                        UpdateListAccount(strUser)
                    End If
            End Select

            SelectAccountItem(strUser)
            SetBanButton()
        End If
    End Sub

    Private Sub cmdKick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKick.Click
        If lvCharacters.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure you want to kick " & lvCharacters.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo, "Kick character") = vbYes Then
                KickChar(lvCharacters.SelectedItems(0).Text)
            End If
        End If
        cmdKick.Enabled = False
    End Sub

    Private Sub cmdReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReload.Click
        cmdReload.Enabled = False

        Dim thLoadAccounts As New System.Threading.Thread(AddressOf TrinityDB.GetAccounts)
        AddHandler TrinityDB.EventFinishedAccInfo, AddressOf EventFinishedAccInfo
        If Not WaitingForInitialAccountLoad Then thLoadAccounts.Start()

        While thLoadAccounts.IsAlive
            Application.DoEvents()
        End While

        REBuildAccountList = True
    End Sub

    Private Sub cmdGMLvl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGMLvl.Click
        If lvAccounts.SelectedItems.Count > 0 Then
            Dim response As String = InputBox("Please enter a GM Level (0-4) for " & lvAccounts.SelectedItems(0).Text, "Change GM Level", GetGMByName(lvAccounts.SelectedItems(0).Text).ToString)

            If response = Nothing Then
                Exit Sub
            ElseIf CInt(response) > 3 Then
                MsgBox("You cannot enter any level higer than 3", MsgBoxStyle.Critical, "Error")
            Else
                'Apply the gm level
                SetGMLevel(lvAccounts.SelectedItems(0).Text, response)

                'Update the array
                InfoAccount(GetArrayIndexByName(lvAccounts.SelectedItems(0).Text)).GMLvl = CInt(response)

                'Update the accounts list
                Select Case CInt(response)
                    Case 0
                        'Player
                        lvAccounts.SelectedItems(0).ForeColor = Color.Black
                        lvAccounts.SelectedItems(0).ToolTipText = "This user is a standard player"
                    Case 1
                        'Moderator
                        lvAccounts.SelectedItems(0).ForeColor = Color.Blue
                        lvAccounts.SelectedItems(0).ToolTipText = "This user is a Moderator"
                    Case 2
                        'Game Master
                        lvAccounts.SelectedItems(0).ForeColor = Color.Green
                        lvAccounts.SelectedItems(0).ToolTipText = "This user is a Game Master"
                    Case 3
                        'Administrator
                        lvAccounts.SelectedItems(0).ForeColor = Color.Red
                        lvAccounts.SelectedItems(0).ToolTipText = "This user is an Administrator"
                End Select
            End If
        End If
    End Sub

    Private Sub cmdExpLvl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpLvl.Click
        If lvAccounts.SelectedItems.Count > 0 Then
            Dim response As String = InputBox("Please enter an Expansion Level for " & lvAccounts.SelectedItems(0).Text, "Change Expansion Level", GetExpByName(lvAccounts.SelectedItems(0).Text).ToString)

            If response = Nothing Then
                Exit Sub
            Else
                SetExpLevel(lvAccounts.SelectedItems(0).Text, response)
            End If
        End If
    End Sub

    Private Sub SelectAccountItem(ByVal strUser As String)
        lvAccounts.Focus()
        Dim idxCurrentItem As Integer = lvAccounts.FindItemWithText(strUser).Index
        lvAccounts.Items.Item(idxCurrentItem).EnsureVisible()
    End Sub

    Private Sub SetBanButton()
        Try
            'set ban buttons
            If lvAccounts.Items.Count > 0 Then
                If AllCoresUp Then cmdBan.Enabled = True

                Select Case lvAccounts.SelectedItems(0).ImageIndex
                    Case 2
                        cmdBan.ImageIndex = 3
                    Case Else
                        cmdBan.ImageIndex = 2
                End Select
            Else
                cmdBan.Enabled = False
            End If
        Catch
            Log("Error with SetBanButton: " & Err.Description, "ERROR")
        End Try
    End Sub

#End Region

#Region "Characters Functions"

    Private Sub lvCharacters_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCharacters.ColumnClick
        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            lvCharacters.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If lvCharacters.Sorting = SortOrder.Ascending Then
                lvCharacters.Sorting = SortOrder.Descending
            Else
                lvCharacters.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        lvCharacters.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        lvCharacters.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         lvCharacters.Sorting)
    End Sub

    Private Sub lvIMChar_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvIMChar.ColumnClick
        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            lvIMChar.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If lvIMChar.Sorting = SortOrder.Ascending Then
                lvIMChar.Sorting = SortOrder.Descending
            Else
                lvIMChar.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        lvIMChar.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        lvIMChar.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         lvIMChar.Sorting)
    End Sub

    Private Sub lvCharacters_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCharacters.MouseClick
        If lvCharacters.SelectedItems.Count > 0 Then
            If lvCharacters.SelectedItems(0).ImageIndex = 1 Then
                cmdKick.Enabled = True
            Else
                cmdKick.Enabled = False
            End If
        Else
            cmdKick.Enabled = False
        End If
    End Sub
#End Region

#Region "Performance Counters"
    Private System_CPUCounter As New System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total")
    Private Core_RAMCounter As New System.Diagnostics.PerformanceCounter("Memory", "% Committed Bytes In Use")
    Private CoreCount As Integer = System.Environment.ProcessorCount

    Private Sub tmrPerf_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPerf.Tick
        Try
            pbRealmCPU.Value = Usage_RealmCPU
            lblRealmCPU.Text = Usage_RealmCPU & "%"

            pbCore1CPU.Value = Usage_Core1CPU
            lblCore1CPU.Text = Usage_Core1CPU & "%"

            pbCore2CPU.Value = Usage_Core2CPU
            lblCore2CPU.Text = Usage_Core2CPU & "%"

            pbCore3CPU.Value = Usage_Core3CPU
            lblCore3CPU.Text = Usage_Core3CPU & "%"

            pbTGCPU.Value = Usage_TGCPU
            lblTGCPU.Text = Usage_TGCPU & "%"
        Catch
            'do nothing
        End Try

        Try
            Dim ProcessorValue As Integer = CInt(System_CPUCounter.NextValue)
            pbSystemCPU.Value = ProcessorValue
            lblSystemCPU.Text = ProcessorValue & "%"
            Log("Processor: " & ProcessorValue, "DEBUG")
            ProcessorValue = Nothing
        Catch
            pbSystemCPU.Value = 0
            lblSystemCPU.Text = "-"
            Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
        End Try

        Try
            Dim RAMValue As Integer = CInt(Core_RAMCounter.NextValue)
            pbCoreRAM.Value = RAMValue
            lblCoreRAM.Text = RAMValue & "%"
            RAMValue = Nothing
        Catch
            pbCoreRAM.Value = 0
            lblCoreRAM.Text = "-"
            Log("Error gathering performance data: " & Err.GetException.InnerException.ToString, "ERROR")
        End Try

    End Sub
#End Region

#Region "Schedule Module"
    Private Sub tmrScheduler_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScheduler.Tick
        CheckSchedules()
        lblTime.Text = Date.Now.ToString
    End Sub

    Private Sub rbSchedDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSchedDaily.CheckedChanged
        gbSchedHourly.Enabled = False
        gbSchedHourly.Visible = False

        gbSchedDaily.Enabled = True
        gbSchedDaily.Visible = True

        gbSchedMonthly.Enabled = False
        gbSchedMonthly.Visible = False '

        gbSchedWeekly.Enabled = False
        gbSchedWeekly.Visible = False
    End Sub

    Private Sub rbSchedHourly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSchedHourly.CheckedChanged
        gbSchedHourly.Enabled = True
        gbSchedHourly.Visible = True

        gbSchedDaily.Enabled = False
        gbSchedDaily.Visible = False

        gbSchedMonthly.Enabled = False
        gbSchedMonthly.Visible = False '

        gbSchedWeekly.Enabled = False
        gbSchedWeekly.Visible = False
    End Sub

    Private Sub rbSchedWeekly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSchedWeekly.CheckedChanged
        gbSchedHourly.Enabled = False
        gbSchedHourly.Visible = False

        gbSchedDaily.Enabled = False
        gbSchedDaily.Visible = False

        gbSchedMonthly.Enabled = False
        gbSchedMonthly.Visible = False '

        gbSchedWeekly.Enabled = True
        gbSchedWeekly.Visible = True
    End Sub

    Private Sub rbSchedMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSchedMonthly.CheckedChanged
        gbSchedHourly.Enabled = False
        gbSchedHourly.Visible = False

        gbSchedDaily.Enabled = False
        gbSchedDaily.Visible = False

        gbSchedMonthly.Enabled = True
        gbSchedMonthly.Visible = True '

        gbSchedWeekly.Enabled = False
        gbSchedWeekly.Visible = False
    End Sub

    Private Sub cbSchedules_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSchedules.SelectedIndexChanged
        'used to preserve correct index when schedule name is modified
        If Not cbSchedules.SelectedIndex = -1 Then
            ScheduleItemIndex = cbSchedules.SelectedIndex
        End If

        'load schedule detail
        LoadSelectedSchedule(cbSchedules.SelectedIndex)
    End Sub

    Private Sub cmdSchedSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedSave.Click
        Dim currentSchedule As String = cbSchedules.Text
        SaveSchedule("Save")
        LoadSchedules()
        cbSchedules.Text = currentSchedule
    End Sub

    Private Sub cmdSchedRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedRemove.Click
        ObjScheduleIniFile.WriteString("SCHEDULES", cbSchedules.SelectedIndex.ToString, "Schedule deleted|||||")
        LoadSchedules()
    End Sub

    Private Sub cbSchedCommand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSchedCommand.SelectedIndexChanged
        If cbSchedCommand.Text = "Announce Core 1" Or cbSchedCommand.Text = "Annouce Core 2" Or cbSchedCommand.Text = "Annouce Core 3" Or cbSchedCommand.Text = "Announce All" _
        Or cbSchedCommand.Text = "Notify Core 1" Or cbSchedCommand.Text = "Notify Core 2" Or cbSchedCommand.Text = "Notify Core 3" Or cbSchedCommand.Text = "Notify All" Then
            txtScheduleMessage.Enabled = True
        Else
            txtScheduleMessage.Enabled = False
        End If
    End Sub

    Public Sub LoadSelectedSchedule(ByVal selectedSchedule As Integer)
        Log("LoadSelectedSchedule: " & selectedSchedule, "DEBUG")
        If selectedSchedule < 0 Then Exit Sub

        Dim schedItemName As String = ArySchedRecords(selectedSchedule)(0)
        Dim schedItemFreq As String = ArySchedRecords(selectedSchedule)(1)
        Dim schedItemDays As String = ArySchedRecords(selectedSchedule)(2)
        Dim schedItemDateTime As String = ArySchedRecords(selectedSchedule)(3)
        Dim schedItemCommand As String = ArySchedRecords(selectedSchedule)(4)
        Dim schedItemMessage As String = ArySchedRecords(selectedSchedule)(5)

        chkSchedMon.Checked = False
        chkSchedTue.Checked = False
        chkSchedWed.Checked = False
        chkSchedThu.Checked = False
        chkSchedFri.Checked = False
        chkSchedSat.Checked = False
        chkSchedSun.Checked = False

        'Load schedule name
        cbSchedules.Text = schedItemName

        Select Case schedItemFreq
            Case "Hourly"
                rbSchedHourly.Checked = True
                txtSchedHours.Text = schedItemDateTime

            Case "Daily"
                rbSchedDaily.Checked = True
                dtpSchedDailyTime.Value = Convert.ToDateTime(schedItemDateTime)

            Case "Weekly"
                rbSchedWeekly.Checked = True

                Dim arySchedItemDays() As String = schedItemDays.Split(Convert.ToChar(" "))
                For Each CurrentDay In arySchedItemDays
                    If CurrentDay = "Mon" Then chkSchedMon.Checked = True
                    If CurrentDay = "Tue" Then chkSchedTue.Checked = True
                    If CurrentDay = "Wed" Then chkSchedWed.Checked = True
                    If CurrentDay = "Thu" Then chkSchedThu.Checked = True
                    If CurrentDay = "Fri" Then chkSchedFri.Checked = True
                    If CurrentDay = "Sat" Then chkSchedSat.Checked = True
                    If CurrentDay = "Sun" Then chkSchedSun.Checked = True
                Next
                dtpSchedWeeklyTime.Value = Convert.ToDateTime(schedItemDateTime)

            Case "Monthly"
                rbSchedMonthly.Checked = True
                dtpSched.Value = Convert.ToDateTime(schedItemDateTime)
                dtpSchedMonthlyTime.Value = Convert.ToDateTime(schedItemDateTime)
        End Select

        'Load command
        cbSchedCommand.Text = schedItemCommand

        'Load message
        If schedItemCommand = "Announce Core 1" Or schedItemCommand = "Annouce Core 2" Or schedItemCommand = "Annouce Core 3" Or schedItemCommand = "Announce All" _
        Or schedItemCommand = "Notify Core 1" Or schedItemCommand = "Notify Core 2" Or schedItemCommand = "Notify Core 3" Or schedItemCommand = "Notify All" Then
            txtScheduleMessage.Text = schedItemMessage
        Else
            txtScheduleMessage.Text = ""
        End If
    End Sub

    Private Sub SaveSchedule(ByVal strAdd As String)
        Dim scheduleData As String = Nothing
        Dim scheduleDays As String = Nothing

        If rbSchedHourly.Checked Then
            scheduleData = cbSchedules.Text & "|Hourly||" & txtSchedHours.Text & "|" & cbSchedCommand.Text & "|" & txtScheduleMessage.Text
        End If

        If rbSchedDaily.Checked Then
            scheduleData = cbSchedules.Text & "|Daily||" & dtpSchedDailyTime.Value & "|" & cbSchedCommand.Text & "|" & txtScheduleMessage.Text
        End If

        If rbSchedWeekly.Checked Then
            If chkSchedMon.Checked Then scheduleDays = "Mon"
            If chkSchedTue.Checked Then scheduleDays = scheduleDays & " Tue"
            If chkSchedWed.Checked Then scheduleDays = scheduleDays & " Wed"
            If chkSchedThu.Checked Then scheduleDays = scheduleDays & " Thu"
            If chkSchedFri.Checked Then scheduleDays = scheduleDays & " Fri"
            If chkSchedSat.Checked Then scheduleDays = scheduleDays & " Sat"
            If chkSchedSun.Checked Then scheduleDays = scheduleDays & " Sun"

            scheduleData = cbSchedules.Text & "|Weekly|" & Trim(scheduleDays) & "|" & dtpSchedWeeklyTime.Value & "|" & cbSchedCommand.Text & "|" & txtScheduleMessage.Text
        End If

        If rbSchedMonthly.Checked Then
            Dim schedMonthlyTime As String = Nothing
            schedMonthlyTime = dtpSched.Value.ToString("dd/MM/yyyy") & " " & dtpSchedMonthlyTime.Value.ToString("h:mm:ss tt")
            scheduleData = cbSchedules.Text & "|Monthly||" & schedMonthlyTime & "|" & cbSchedCommand.Text & "|" & txtScheduleMessage.Text
        End If

        If ScheduleItemIndex = -1 Then
            MsgBox("Bad item index")
        Else
            If strAdd = "Add" Then
                ObjScheduleIniFile.WriteString("SCHEDULES", cbSchedules.Items.Count.ToString, scheduleData)
            Else
                ObjScheduleIniFile.WriteString("SCHEDULES", ScheduleItemIndex.ToString, scheduleData)
            End If
        End If
    End Sub

    Private Sub cmdSchedAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedAdd.Click
        Dim currentSchedule As String = cbSchedules.Text
        SaveSchedule("Add")
        LoadSchedules()
        cbSchedules.Text = currentSchedule
    End Sub

#End Region

    Private Sub cmdInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInfo.Click
        AboutBox1.Show()
    End Sub
End Class
