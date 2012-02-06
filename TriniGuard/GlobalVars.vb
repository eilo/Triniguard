Option Strict On

Module GlobalVars
    Public DebugModeLog As Boolean

    '-----------------------------------------------------------------------
    'INI Vars
    '-----------------------------------------------------------------------
    Public ObjIniFile As New IniFile(Application.StartupPath & "\TriniGuard.conf")
    Public ObjLogFile As New IniFile(Application.StartupPath & "\TriniGuard.Log")
    '
    'TRINITY
    
    'Public StrCoreServer As String

    Public TrinityRealmFile As String
    Public TrinityRealmURL As String
    Public TrinityRealmPort As Integer

    Public IntCheckPortInterval As Integer
    Public LaunchTrinityHidden As Boolean
    Public TerminateTrinityOnExit As Boolean

    'MYSQL
    Public MySqlDump As String
    Public SqlHost As String
    Public SqlPort As Integer
    Public SqlUser As String
    Public SqlPass As String

    Public MySqlCheck As String

    'BACKUP
    Public BackupPath As String
    Public DatabaseBackupsToKeep As Integer
    Public TableBackupInterval As Integer
    Public TableBackupsToKeep As Integer

    Public NumWorldDB As Integer = 0
    Public BackupWorldDB As Boolean
    Public DBWorld1 As String
    Public DBWorld2 As String
    Public DBWorld3 As String
    Public WorldDatabaseBackupInterval As Integer
    Public BackupWorldTables As Boolean
    Public TBWorld As String

    Public BackupRealmDB As Boolean
    Public DBRealm As String
    Public RealmDatabaseBackupInterval As Integer
    Public BackupRealmTables As Boolean
    Public TBRealm As String

    Public NumCharDB As Integer = 0
    Public BackupCharactersDB As Boolean
    Public DBCharacters1 As String
    Public DBCharacters2 As String
    Public DBCharacters3 As String
    Public CharacterDatabaseBackupInterval As Integer
    Public BackupCharactersTables As Boolean
    Public TBCharacters As String

    'ALERTS
    Public EmailAlert As Boolean
    Public EmailTo As String
    Public EmailFrom As String
    Public EmailServer As String
    Public EmailAuthenticate As Boolean
    Public EmailUsername As String
    Public EmailDomain As String
    Public EmailPassword As String

    'SCHEDULER
    Public SchedulerEnabled As Boolean

    'ADMIN, GM, MOD ONLINE ANNOUNCE
    Public AdminOnlineMessage As String
    Public GMOnlineMessage As String
    Public ModOnlineMessage As String
    '-----------------------------------------------------------------------


    'Define portchecker class
    Public CPtcChecker As ClsPortChecker

    Public AllCoresUp As Boolean = True
    Public Core1Up As Boolean = False
    Public Core2Up As Boolean = False
    Public Core3Up As Boolean = False
    Public RealmUp As Boolean = False
    Public ServerUp As Boolean = False
    Public WaitForCore1 As Boolean = False
    Public WaitForCore2 As Boolean = False
    Public WaitForCore3 As Boolean = False
    Public WaitForRealm As Boolean = False

    Public WorldCount As Integer = 0

    'Process Settings
    Public Core1ProcessName As String
    Public Core2ProcessName As String
    Public Core3ProcessName As String
    Public RealmProcessName As String

    Public Core1File As String
    Public Core2File As String
    Public Core3File As String
    Public RealmFile As String

    Public Core1Path As String
    Public Core2Path As String
    Public Core3Path As String
    Public RealmPath As String

    Public ClosePending As Boolean = False

    Public IntLastIcon As Integer = 0

    Public IntCore1DownCount As Integer = 1
    Public IntCore2DownCount As Integer = 1
    Public IntCore3DownCount As Integer = 1
    Public IntRealmDownCount As Integer = 1

    Public RetryRealm As Boolean = False
    Public RetryCore1 As Boolean = False
    Public RetryCore2 As Boolean = False
    Public RetryCore3 As Boolean = False

    Public TGPID As Integer
    Public Core1PID As Integer
    Public Core2PID As Integer
    Public Core3PID As Integer
    Public RealmPID As Integer
    Public Core1LastPID As Integer
    Public Core2LastPID As Integer
    Public Core3LastPID As Integer
    Public RealmLastPID As Integer

    Public GetNewRealmPID As Boolean = True
    Public GetNewCore1PID As Boolean = True
    Public GetNewCore2PID As Boolean = True
    Public GetNewCore3PID As Boolean = True

    Public Usage_RealmCPU As Integer
    Public Usage_Core1CPU As Integer
    Public Usage_Core2CPU As Integer
    Public Usage_Core3CPU As Integer
    Public Usage_TGCPU As Integer


    Public IsUpdatingStatus As Boolean = False
    Public AccountsOnline As Integer = -1
    Public Accounts As Integer = -1

    Public NumCharacters As Integer = 0

    Public Exiting As Boolean = False

    'Scheduling
    Public ArySchedRecords()() As String
    Public ArySchedHourCount() As Long
    Public ObjScheduleIniFile As New IniFile(Application.StartupPath & "\TriniGuardSchedules.conf")
    Public ScheduleItemIndex As Integer = Nothing

    Public WaitingForInitialAccountLoad As Boolean = True
    Public AccountsDone As Boolean

    Public Logindex As Long = 0

    Public RealmCrashCount As Integer = 0
    Public Core1CrashCount As Integer = 0
    Public Core2CrashCount As Integer = 0
    Public Core3CrashCount As Integer = 0

    Public HaltRealm As Boolean = False
    Public HaltCore1 As Boolean = False
    Public HaltCore2 As Boolean = False
    Public HaltCore3 As Boolean = False

    Public Structure AryVersion
        Public Core As String
        Public CoreRev As String
        Public DB As String
        Public Script As String

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure AryAccount
        Public ID As Integer
        Public Name As String
        Public Online As Integer
        Public GMLvl As Integer
        Public Banned As Boolean
        Public ExpLvl As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Structure aryRealms
        Public strName As String
        Public dbCharacters As String
        Public dbWorld As String
        Public intPort As Integer
        Public strCoreFile As String
        Public Active As Boolean
    End Structure

    Public Structure aryAllCharacters
        Public Name As String
        Public GUID As Integer
        Public RealmName As String
        Public RealmID As Integer
    End Structure

    Public Structure aryCharacter
        Public Name As String
        Public Online As Integer
        Public GUID As Integer
        Public RealmName As String
        Public RealmID As Integer

        Public Overloads Overrides Function GetHashCode() As Integer
            Throw New NotImplementedException()
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As [Object]) As Boolean
            Throw New NotImplementedException()
        End Function
    End Structure

    Public Realms() As aryRealms

    Public AllCharacters() As aryAllCharacters
    Public InfoCharacter() As aryCharacter
    Public InfoOnlineCharacter() As aryCharacter
    Public InfoAccount() As AryAccount
    Public InfoVersion As AryVersion

    Public REBuildAccountList As Boolean = False 'Build Accounts list on first run

    Public GenAccBusy As Boolean = False

    Public GeneratingAccountInfo As Boolean = True

    Public ProcessAccountsNow As Boolean


    Public Sub LoadSettings()
        If System.IO.File.Exists(Application.StartupPath & "\debug.me") Then DebugModeLog = True

        If System.IO.File.Exists(Application.StartupPath & "\TriniGuard.conf") Then
            'TRINITY
            TrinityRealmFile = ObjIniFile.GetString("TRINITY", "TrinityRealmFile", "")
            TrinityRealmURL = ObjIniFile.GetString("TRINITY", "TrinityRealmURL", "")
            Try
                TrinityRealmPort = Convert.ToInt16(ObjIniFile.GetString("TRINITY", "TrinityRealmPort", ""))
            Catch
                MsgBox("Error loading TrinityRealmPort, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading TrinityRealmPort, please check your config.", "ERROR")
            End Try

            Try
                IntCheckPortInterval = Convert.ToInt16(ObjIniFile.GetString("TRINITY", "PortCheckInterval", ""))
            Catch
                MsgBox("Error loading PortCheckInterval, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading PortCheckInterval, please check your config.", "ERROR")
            End Try
            LaunchTrinityHidden = Convert.ToBoolean(ObjIniFile.GetString("TRINITY", "LaunchTrinityHidden", ""))
            TerminateTrinityOnExit = Convert.ToBoolean(ObjIniFile.GetString("TRINITY", "ShutdownTrinityOnExit", ""))


            'MYSQL
            MySqlDump = ObjIniFile.GetString("MYSQL", "MySQLDumpFile", "")
            SqlHost = ObjIniFile.GetString("MYSQL", "SQLServer", "")
            Try
                SqlPort = Convert.ToInt16(ObjIniFile.GetString("MYSQL", "SQLPort", "3306"))
            Catch
                MsgBox("Error loading SQLPort, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading SQLPort, please check your config.", "ERROR")
            End Try
            SqlUser = ObjIniFile.GetString("MYSQL", "SQLUser", "")
            SqlPass = ObjIniFile.GetString("MYSQL", "SQLPass", "")

            MySqlCheck = ObjIniFile.GetString("MYSQL", "MySQLCheckFile", "")


            'BACKUP
            BackupPath = ObjIniFile.GetString("BACKUP", "BackupPath", "")
            Try
                DatabaseBackupsToKeep = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "DBBackupsToKeep", ""))
            Catch
                MsgBox("Error loading DBBackupsToKeep, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading DBBackupsToKeep, please check your config.", "ERROR")
            End Try
            Try
                TableBackupInterval = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "TableBackupInterval", "")) * 60
            Catch
                MsgBox("Error loading TableBackupInterval, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading TableBackupInterval, please check your config.", "ERROR")
            End Try
            Try
                TableBackupsToKeep = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "TableBackupsToKeep", ""))
            Catch
                MsgBox("Error loading TableBackupsToKeep, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading TableBackupsToKeep, please check your config.", "ERROR")
            End Try

            BackupWorldDB = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupWorldDB", ""))
            DBWorld1 = ObjIniFile.GetString("BACKUP", "WorldDB1", "")
            DBWorld2 = ObjIniFile.GetString("BACKUP", "WorldDB2", "")
            DBWorld3 = ObjIniFile.GetString("BACKUP", "WorldDB3", "")
            CountWorldDB()
            Try
                WorldDatabaseBackupInterval = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "WorldDBInterval", "")) * 60
            Catch
                MsgBox("Error loading WorldDBInterval, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading WorldDBInterval, please check your config.", "ERROR")
            End Try
            BackupWorldTables = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupWorldTables", ""))
            TBWorld = ObjIniFile.GetString("BACKUP", "WorldTables", "")

            BackupRealmDB = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupRealmDB", ""))
            DBRealm = ObjIniFile.GetString("BACKUP", "RealmDB", "")
            Try
                RealmDatabaseBackupInterval = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "RealmDBInterval", "")) * 60
            Catch
                MsgBox("Error loading RealmDBInterval, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading RealmDBInterval, please check your config.", "ERROR")
            End Try
            BackupRealmTables = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupRealmTables", ""))
            TBRealm = ObjIniFile.GetString("BACKUP", "RealmTables", "")

            BackupCharactersDB = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupCharactersDB", ""))
            DBCharacters1 = ObjIniFile.GetString("BACKUP", "CharactersDB1", "")
            DBCharacters2 = ObjIniFile.GetString("BACKUP", "CharactersDB2", "")
            DBCharacters3 = ObjIniFile.GetString("BACKUP", "CharactersDB3", "")
            CountCharDB()
            Try
                CharacterDatabaseBackupInterval = Convert.ToInt16(ObjIniFile.GetString("BACKUP", "CharactersDBInterval", "")) * 60
            Catch
                MsgBox("Error loading CharactersDBInterval, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading CharactersDBInterval, please check your config.", "ERROR")
            End Try
            BackupCharactersTables = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupCharactersTables", ""))
            TBCharacters = ObjIniFile.GetString("BACKUP", "CharactersTables", "")


            'REALMS
            ReDim Preserve Realms(0)
            Realms(0).strName = ObjIniFile.GetString("REALM1", "Realm1_Name", "")
            Realms(0).strCoreFile = ObjIniFile.GetString("REALM1", "Realm1_CoreFile", "")
            Try
                Realms(0).intPort = Convert.ToInt16(ObjIniFile.GetString("REALM1", "Realm1_CorePort", ""))
            Catch
                MsgBox("Error loading Realm1_CorePort, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading Realm1_CorePort, please check your config.", "ERROR")
            End Try
            If Not DBWorld1 = "" Then Realms(0).dbWorld = DBWorld1
            If Not DBCharacters1 = "" Then Realms(0).dbCharacters = DBCharacters1

            ReDim Preserve Realms(1)
            Realms(1).strName = ObjIniFile.GetString("REALM2", "Realm2_Name", "")
            Realms(1).strCoreFile = ObjIniFile.GetString("REALM2", "Realm2_CoreFile", "")
            Try
                Realms(1).intPort = Convert.ToInt16(ObjIniFile.GetString("REALM2", "Realm2_CorePort", ""))
            Catch
                MsgBox("Error loading Realm2_CorePort, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading Realm2_CorePort, please check your config.", "ERROR")
            End Try
            If Not DBWorld2 = "" Then Realms(1).dbWorld = DBWorld2
            If Not DBCharacters2 = "" Then Realms(1).dbCharacters = DBCharacters2

            ReDim Preserve Realms(2)
            Realms(2).strName = ObjIniFile.GetString("REALM3", "Realm3_Name", "")
            Realms(2).strCoreFile = ObjIniFile.GetString("REALM3", "Realm3_CoreFile", "")
            Try
                Realms(2).intPort = Convert.ToInt16(ObjIniFile.GetString("REALM3", "Realm3_CorePort", ""))
            Catch
                MsgBox("Error loading Realm3_CorePort, please check your config.", MsgBoxStyle.Critical, "Error")
                Log("Error loading Realm3_CorePort, please check your config.", "ERROR")
            End Try
            If Not DBWorld3 = "" Then Realms(2).dbWorld = DBWorld3
            If Not DBCharacters3 = "" Then Realms(2).dbCharacters = DBCharacters3


            'ALERTS
            EmailAlert = Convert.ToBoolean(ObjIniFile.GetString("ALERTS", "EnableEmailAlerts", ""))
            EmailTo = ObjIniFile.GetString("ALERTS", "MailTo", "")
            EmailFrom = ObjIniFile.GetString("ALERTS", "MailFrom", "")
            EmailServer = ObjIniFile.GetString("ALERTS", "MailServer", "")
            EmailAuthenticate = Convert.ToBoolean(ObjIniFile.GetString("ALERTS", "MailRequiresAuth", ""))
            EmailUsername = ObjIniFile.GetString("ALERTS", "MailUser", "")
            EmailDomain = ObjIniFile.GetString("ALERTS", "MailDomain", "")
            EmailPassword = ObjIniFile.GetString("ALERTS", "MailPass", "")

            'Scheduler settings
            SchedulerEnabled = Convert.ToBoolean(ObjIniFile.GetString("SCHEDULER", "SchedulerEnabled", "False"))

            'Process Settings
            RealmProcessName = FileNameWithoutExtension(TrinityRealmFile)
            RealmFile = FileName(TrinityRealmFile)
            RealmPath = PathName(TrinityRealmFile)

            Core1ProcessName = FileNameWithoutExtension(Realms(0).strCoreFile)
            Core1File = FileName(Realms(0).strCoreFile)
            Core1Path = PathName(Realms(0).strCoreFile)

            Core2ProcessName = FileNameWithoutExtension(Realms(1).strCoreFile)
            Core2File = FileName(Realms(1).strCoreFile)
            Core2Path = PathName(Realms(1).strCoreFile)

            Core3ProcessName = FileNameWithoutExtension(Realms(2).strCoreFile)
            Core3File = FileName(Realms(2).strCoreFile)
            Core3Path = PathName(Realms(2).strCoreFile)


            'Auto-Announcements
            FrmMain.chkModOnline.Checked = Convert.ToBoolean(ObjIniFile.GetString("AUTO-ANNOUNCE", "MODERATOR", "False"))
            If FrmMain.chkModOnline.Checked Then
                FrmMain.txtModOnline.Enabled = True
            Else
                FrmMain.txtModOnline.Enabled = False
            End If

            FrmMain.chkGMOnline.Checked = Convert.ToBoolean(ObjIniFile.GetString("AUTO-ANNOUNCE", "GAME MASTER", "False"))
            If FrmMain.chkGMOnline.Checked Then
                FrmMain.txtGMOnline.Enabled = True
            Else
                FrmMain.txtGMOnline.Enabled = False
            End If

            FrmMain.chkAdminOnline.Checked = Convert.ToBoolean(ObjIniFile.GetString("AUTO-ANNOUNCE", "ADMINISTRATOR", "False"))
            If FrmMain.chkAdminOnline.Checked Then
                FrmMain.txtAdminOnline.Enabled = True
            Else
                FrmMain.txtAdminOnline.Enabled = False
            End If

            AdminOnlineMessage = ObjIniFile.GetString("AUTO-ANNOUNCE", "AdminOnlineMessage", "")
            FrmMain.txtAdminOnline.Text = AdminOnlineMessage
            GMOnlineMessage = ObjIniFile.GetString("AUTO-ANNOUNCE", "GMOnlineMessage", "")
            FrmMain.txtGMOnline.Text = GMOnlineMessage
            ModOnlineMessage = ObjIniFile.GetString("AUTO-ANNOUNCE", "ModOnlineMessage", "")
            FrmMain.txtModOnline.Text = ModOnlineMessage

            'check if realms are active - do they have all the needed detais?
            If Not Realms(0).strName = "" And Not Realms(0).strCoreFile = "" And Not Realms(0).intPort = Nothing Then Realms(0).Active = True
            If Not Realms(1).strName = "" And Not Realms(1).strCoreFile = "" And Not Realms(1).intPort = Nothing Then Realms(1).Active = True
            If Not Realms(2).strName = "" And Not Realms(2).strCoreFile = "" And Not Realms(2).intPort = Nothing Then Realms(2).Active = True

            WorldCount = CountWorlds()
        Else
            MsgBox("Error: TriniGuard Configurtation file: " & Application.StartupPath & "\TriniGuard.conf is missing.", MsgBoxStyle.Critical, "Error - Configuration missing")
            End
        End If
    End Sub

    Private Sub CountWorldDB()
        Dim DBCount As Integer = 0

        If Not DBWorld1 = "" Then DBCount = DBCount + 1
        If Not DBWorld1 = "" Then DBCount = DBCount + 1
        If Not DBWorld1 = "" Then DBCount = DBCount + 1

        NumWorldDB = DBCount
    End Sub

    Private Sub CountCharDB()
        Dim DBCount As Integer = 0

        If Not DBCharacters1 = "" Then DBCount = DBCount + 1
        If Not DBCharacters2 = "" Then DBCount = DBCount + 1
        If Not DBCharacters3 = "" Then DBCount = DBCount + 1

        NumCharDB = DBCount
    End Sub

    Private Function CountWorlds() As Integer
        Dim WorldCount As Integer = 0

        If Realms(0).Active Then WorldCount = WorldCount + 1
        If Realms(1).Active Then WorldCount = WorldCount + 1
        If Realms(2).Active Then WorldCount = WorldCount + 1

        Return WorldCount
    End Function
End Module
