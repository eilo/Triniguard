Option Strict On

Imports System.Windows.Forms
Imports MySql.Data.MySqlClient


Public Class DlgConfig

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        SaveConfig()
        MsgBox("Please note that you will need to restart TriniGuard for changes to take affect.", MsgBoxStyle.Information, "Restart TriniGuard")
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgConfig_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMain.Enabled = True
    End Sub

    Private Sub chkWorldDB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWorldDB.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub chkWorldTables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWorldTables.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub chkRealmDB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRealmDB.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub chkRealmTables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRealmTables.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub chkCharDB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCharDB.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub chkCharTables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCharTables.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub CheckEnables()
        If chkCharTables.Checked Then
            lstCharTables.Enabled = True
            cmdCharTableAdd.Enabled = True
            cmdCharTableDelete.Enabled = True
        Else
            lstCharTables.Enabled = False
            cmdCharTableAdd.Enabled = False
            cmdCharTableDelete.Enabled = False
        End If
        If chkCharDB.Checked Then
            txtCharDB1.Enabled = True
            txtCharDB2.Enabled = True
            txtCharDB3.Enabled = True
            txtCharDBInt.Enabled = True
        Else
            txtCharDB1.Enabled = False
            txtCharDB2.Enabled = False
            txtCharDB3.Enabled = False
            txtCharDBInt.Enabled = False
        End If

        If chkRealmTables.Checked Then
            lstRealmTables.Enabled = True
            cmdRealmTableAdd.Enabled = True
            cmdRealmTableDelete.Enabled = True
        Else
            lstRealmTables.Enabled = False
            cmdRealmTableAdd.Enabled = False
            cmdRealmTableDelete.Enabled = False
        End If
        If chkRealmDB.Checked Then
            txtRealmDB.Enabled = True
            txtRealmDBInt.Enabled = True
        Else
            txtRealmDB.Enabled = False
            txtRealmDBInt.Enabled = False
        End If

        If chkWorldTables.Checked Then
            lstWorldTables.Enabled = True
            cmdWorldTableAdd.Enabled = True
            cmdWorldTableDelete.Enabled = True
        Else
            lstWorldTables.Enabled = False
            cmdWorldTableAdd.Enabled = False
            cmdWorldTableDelete.Enabled = False
        End If

        If chkWorldDB.Checked Then
            txtWorldDB1.Enabled = True
            txtWorldDB2.Enabled = True
            txtWorldDB3.Enabled = True
            txtWorldDBInt.Enabled = True

        Else
            txtWorldDB1.Enabled = False
            txtWorldDB2.Enabled = False
            txtWorldDB3.Enabled = False
            txtWorldDBInt.Enabled = False
        End If

        If chkAlerts.Checked Then
            txtMailFrom.Enabled = True
            txtMailTo.Enabled = True
            grpEmail.Enabled = True
        Else
            txtMailFrom.Enabled = False
            txtMailTo.Enabled = False
            grpEmail.Enabled = False
        End If

        If chkRequiresAuth.Checked Then
            txtEmailDomain.Enabled = True
            txtEmailPassword.Enabled = True
            txtEmailUsername.Enabled = True
        Else
            txtEmailDomain.Enabled = False
            txtEmailPassword.Enabled = False
            txtEmailUsername.Enabled = False
        End If
    End Sub

    Private Sub CheckCore1Path()
        If Not System.IO.File.Exists(txtCore1File.Text) Then
            txtCore1File.BackColor = Color.Red
            txtCore1File.ForeColor = Color.White
        Else
            txtCore1File.BackColor = Color.Green
            txtCore1File.ForeColor = Color.White
        End If
    End Sub
    Private Sub CheckCore2Path()
        If Not System.IO.File.Exists(txtCore2File.Text) Then
            txtCore2File.BackColor = Color.Red
            txtCore2File.ForeColor = Color.White
        Else
            txtCore2File.BackColor = Color.Green
            txtCore2File.ForeColor = Color.White
        End If
    End Sub
    Private Sub CheckCore3Path()
        If Not System.IO.File.Exists(txtCore3File.Text) Then
            txtCore3File.BackColor = Color.Red
            txtCore3File.ForeColor = Color.White
        Else
            txtCore3File.BackColor = Color.Green
            txtCore3File.ForeColor = Color.White
        End If
    End Sub

    Public Function CheckRealmPath() As Boolean
        If Not System.IO.File.Exists(txtRealmFile.Text) Then
            txtRealmFile.BackColor = Color.Red
            txtRealmFile.ForeColor = Color.White
            Return False
        Else
            txtRealmFile.BackColor = Color.Green
            txtRealmFile.ForeColor = Color.White
            Return True
        End If
    End Function

    Public Function CheckSqlPath() As Boolean
        If Not System.IO.File.Exists(txtMySQLDumpFile.Text) Then
            txtMySQLDumpFile.BackColor = Color.Red
            txtMySQLDumpFile.ForeColor = Color.White
            Return False
        Else
            txtMySQLDumpFile.BackColor = Color.Green
            txtMySQLDumpFile.ForeColor = Color.White
            Return True
        End If
    End Function

    Public Function CheckSqlCheckPath() As Boolean
        If Not System.IO.File.Exists(txtMySQLCheckFile.Text) Then
            txtMySQLCheckFile.BackColor = Color.Red
            txtMySQLCheckFile.ForeColor = Color.White
            Return False
        Else
            txtMySQLCheckFile.BackColor = Color.Green
            txtMySQLCheckFile.ForeColor = Color.White
            Return True
        End If
    End Function

    Public Function CheckBackupPath() As Boolean
        If Not System.IO.Directory.Exists(txtBackupPath.Text) Then
            txtBackupPath.BackColor = Color.Red
            txtBackupPath.ForeColor = Color.White
            Return False
        Else
            txtBackupPath.BackColor = Color.Green
            txtBackupPath.ForeColor = Color.White
            Return True
        End If
    End Function


    Private Sub btnCoreBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "Trinity Core Realm File"
        fileDialog.InitialDirectory = "C:\"
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCore1File.Text = fileDialog.FileName
        End If
    End Sub

    Private Sub cmdBrowseSQLDump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseSQLDump.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "MySQLDump File"
        fileDialog.InitialDirectory = "C:\"
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMySQLDumpFile.Text = fileDialog.FileName
        End If
    End Sub

    Private Sub cmdBrowseBackupPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseBackupPath.Click
        Dim folderBrowser As New System.Windows.Forms.FolderBrowserDialog

        If folderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBackupPath.Text = folderBrowser.SelectedPath
        End If
    End Sub

    Private Sub cmdWorldTableDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWorldTableDelete.Click
        lstWorldTables.Items.RemoveAt(lstWorldTables.SelectedIndex)
    End Sub

    Private Sub cmdRealmTableDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRealmTableDelete.Click
        lstRealmTables.Items.RemoveAt(lstRealmTables.SelectedIndex)
    End Sub

    Private Sub cmdCharTableDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCharTableDelete.Click
        lstCharTables.Items.RemoveAt(lstCharTables.SelectedIndex)
    End Sub

    Private Sub cmdWorldTableAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWorldTableAdd.Click
        Dim addWorldTable As String = InputBox("Please enter world table name:", "Add World table")
        If addWorldTable <> "" Then
            lstWorldTables.Items.Add(addWorldTable)
        End If
    End Sub

    Private Sub cmdRealmTableAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRealmTableAdd.Click
        Dim addRealmTable As String = InputBox("Please enter realm table name:", "Add World table")
        If addRealmTable <> "" Then
            lstRealmTables.Items.Add(addRealmTable)
        End If
    End Sub

    Private Sub cmdCharTableAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCharTableAdd.Click
        Dim addCharTable As String = InputBox("Please enter character table name:", "Add World table")
        If addCharTable <> "" Then
            lstCharTables.Items.Add(addCharTable)
        End If
    End Sub

    Private Sub SaveWorldTables()
        Dim worldTables As String = Nothing

        For i = 0 To lstWorldTables.Items.Count - 1
            worldTables = worldTables & " " & lstWorldTables.Items.Item(i).ToString
        Next

        ObjIniFile.WriteString("BACKUP", "WorldTables", Trim(worldTables))
    End Sub

    Private Sub SaveRealmTables()
        Dim realmTables As String = Nothing

        For i = 0 To lstRealmTables.Items.Count - 1
            realmTables = realmTables & " " & lstRealmTables.Items.Item(i).ToString
        Next

        ObjIniFile.WriteString("BACKUP", "RealmTables", Trim(realmTables))
    End Sub

    Private Sub SaveCharTables()
        Dim charTables As String = Nothing

        For i = 0 To lstCharTables.Items.Count - 1
            charTables = charTables & " " & lstCharTables.Items.Item(i).ToString
        Next

        ObjIniFile.WriteString("BACKUP", "CharactersTables", Trim(charTables))
    End Sub

    Private Sub LoadWorldTables()
        If Not ObjIniFile.GetString("BACKUP", "WorldTables", "") = "" Then
            Dim worldTables As String() = ObjIniFile.GetString("BACKUP", "WorldTables", "").Split(Convert.ToChar(" "))
            lstWorldTables.Items.AddRange(worldTables)
        End If
    End Sub

    Private Sub LoadRealmTables()
        If Not ObjIniFile.GetString("BACKUP", "RealmTables", "") = "" Then
            Dim realmTables As String() = ObjIniFile.GetString("BACKUP", "RealmTables", "").Split(Convert.ToChar(" "))
            lstRealmTables.Items.AddRange(realmTables)
        End If
    End Sub

    Private Sub LoadCharTables()
        If Not ObjIniFile.GetString("BACKUP", "CharactersTables", "") = "" Then
            Dim charTables As String() = ObjIniFile.GetString("BACKUP", "CharactersTables", "").Split(Convert.ToChar(" "))
            lstCharTables.Items.AddRange(charTables)
        End If
    End Sub

    Private Sub chkAlerts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlerts.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub txtBackupPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBackupPath.TextChanged
        CheckBackupPath()
    End Sub
    Private Sub txtRealmFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRealmFile.TextChanged
        CheckRealmPath()
    End Sub

    Private Sub txtCore1File_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCore1File.TextChanged
        CheckCore1Path()
    End Sub

    Private Sub txtCore2File_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCore2File.TextChanged
        CheckCore2Path()
    End Sub

    Private Sub txtCore3File_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCore3File.TextChanged
        CheckCore3Path()
    End Sub

    Private Sub txtMySQLDumpFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMySQLDumpFile.TextChanged
        CheckSqlPath()
    End Sub

    Private Sub txtMySQLCheckFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMySQLCheckFile.TextChanged
        CheckSqlCheckPath()
    End Sub

    Private Sub chkRequiresAuth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRequiresAuth.CheckedChanged
        CheckEnables()
    End Sub

    Private Sub LoadConfig()
        Try
            'TRINITY
            txtRealmFile.Text = ObjIniFile.GetString("TRINITY", "TrinityRealmFile", "")
            txtRealmURL.Text = ObjIniFile.GetString("TRINITY", "TrinityRealmURL", "")
            txtRealmPort.Text = ObjIniFile.GetString("TRINITY", "TrinityRealmPort", "")

            txtPortInterval.Text = ObjIniFile.GetString("TRINITY", "PortCheckInterval", "")
            chkHideProcesses.Checked = Convert.ToBoolean(ObjIniFile.GetString("TRINITY", "LaunchTrinityHidden", ""))
            chkShutdownTrinity.Checked = Convert.ToBoolean(ObjIniFile.GetString("TRINITY", "ShutdownTrinityOnExit", ""))


            'REALMS
            txtRealm1Name.Text = ObjIniFile.GetString("REALM1", "Realm1_Name", "")
            txtCore1File.Text = ObjIniFile.GetString("REALM1", "Realm1_CoreFile", "")
            txtCore1Port.Text = ObjIniFile.GetString("REALM1", "Realm1_CorePort", "")

            txtRealm2Name.Text = ObjIniFile.GetString("REALM2", "Realm2_Name", "")
            txtCore2File.Text = ObjIniFile.GetString("REALM2", "Realm2_CoreFile", "")
            txtCore2Port.Text = ObjIniFile.GetString("REALM2", "Realm2_CorePort", "")

            txtRealm3Name.Text = ObjIniFile.GetString("REALM3", "Realm3_Name", "")
            txtCore3File.Text = ObjIniFile.GetString("REALM3", "Realm3_CoreFile", "")
            txtCore3Port.Text = ObjIniFile.GetString("REALM3", "Realm3_CorePort", "")


            'MYSQL
            txtMySQLDumpFile.Text = ObjIniFile.GetString("MYSQL", "MySQLDumpFile", "")
            txtMySQLServer.Text = ObjIniFile.GetString("MYSQL", "SQLServer", "")
            txtMySQLPort.Text = ObjIniFile.GetString("MYSQL", "SQLPort", "3306")
            txtMySQLUsername.Text = ObjIniFile.GetString("MYSQL", "SQLUser", "")
            txtMySQLPassword.Text = ObjIniFile.GetString("MYSQL", "SQLPass", "")

            txtMySQLCheckFile.Text = ObjIniFile.GetString("MYSQL", "MySQLCheckFile", "")


            'BACKUP
            txtBackupPath.Text = ObjIniFile.GetString("BACKUP", "BackupPath", "")
            txtDBBackupsKeep.Text = ObjIniFile.GetString("BACKUP", "DBBackupsToKeep", "")
            txtTableInterval.Text = ObjIniFile.GetString("BACKUP", "TableBackupInterval", "")
            txtTableBackupsKeep.Text = ObjIniFile.GetString("BACKUP", "TableBackupsToKeep", "")

            chkWorldDB.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupWorldDB", ""))
            txtWorldDB1.Text = ObjIniFile.GetString("BACKUP", "WorldDB1", "")
            txtWorldDB2.Text = ObjIniFile.GetString("BACKUP", "WorldDB2", "")
            txtWorldDB3.Text = ObjIniFile.GetString("BACKUP", "WorldDB3", "")
            txtWorldDBInt.Text = ObjIniFile.GetString("BACKUP", "WorldDBInterval", "")
            chkWorldTables.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupWorldTables", ""))
            LoadWorldTables()

            chkRealmDB.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupRealmDB", ""))
            txtRealmDB.Text = ObjIniFile.GetString("BACKUP", "RealmDB", "")
            txtRealmDBInt.Text = ObjIniFile.GetString("BACKUP", "RealmDBInterval", "")
            chkRealmTables.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupRealmTables", ""))
            LoadRealmTables()

            chkCharDB.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupCharactersDB", ""))
            txtCharDB1.Text = ObjIniFile.GetString("BACKUP", "CharactersDB1", "")
            txtCharDB2.Text = ObjIniFile.GetString("BACKUP", "CharactersDB2", "")
            txtCharDB3.Text = ObjIniFile.GetString("BACKUP", "CharactersDB3", "")
            txtCharDBInt.Text = ObjIniFile.GetString("BACKUP", "CharactersDBInterval", "")
            chkCharTables.Checked = Convert.ToBoolean(ObjIniFile.GetString("BACKUP", "BackupCharactersTables", ""))
            LoadCharTables()


            'ALERTS
            chkAlerts.Checked = Convert.ToBoolean(ObjIniFile.GetString("ALERTS", "EnableEmailAlerts", ""))
            txtMailTo.Text = ObjIniFile.GetString("ALERTS", "MailTo", "")
            txtMailFrom.Text = ObjIniFile.GetString("ALERTS", "MailFrom", "")
            txtMailServer.Text = ObjIniFile.GetString("ALERTS", "MailServer", "")
            chkRequiresAuth.Checked = Convert.ToBoolean(ObjIniFile.GetString("ALERTS", "MailRequiresAuth", ""))
            txtEmailUsername.Text = ObjIniFile.GetString("ALERTS", "MailUser", "")
            txtEmailDomain.Text = ObjIniFile.GetString("ALERTS", "MailDomain", "")
            txtEmailPassword.Text = ObjIniFile.GetString("ALERTS", "MailPass", "")

            'SCHEDULER
            chkSchedulerEnabled.Checked = Convert.ToBoolean(ObjIniFile.GetString("SCHEDULER", "SchedulerEnabled", "False"))

        Catch
            MsgBox("Error loading config: " & Err.Description, MsgBoxStyle.Critical, "Error")
            Log("Error loading congfig: " & Err.Description, "ERROR")
        End Try
    End Sub

    Private Sub SaveConfig()
        Try
            'TRINITY
            ObjIniFile.WriteString("TRINITY", "TrinityRealmFile", txtRealmFile.Text)
            ObjIniFile.WriteString("TRINITY", "TrinityRealmURL", txtRealmURL.Text)
            ObjIniFile.WriteString("TRINITY", "TrinityRealmPort", txtRealmPort.Text)

            ObjIniFile.WriteString("TRINITY", "PortCheckInterval", txtPortInterval.Text)
            ObjIniFile.WriteString("TRINITY", "LaunchTrinityHidden", chkHideProcesses.Checked.ToString)
            ObjIniFile.WriteString("TRINITY", "ShutdownTrinityOnExit", chkShutdownTrinity.Checked.ToString)


            'REALMS
            ObjIniFile.WriteString("REALM1", "Realm1_Name", txtRealm1Name.Text)
            ObjIniFile.WriteString("REALM1", "Realm1_CoreFile", txtCore1File.Text)
            ObjIniFile.WriteString("REALM1", "Realm1_CorePort", txtCore1Port.Text)

            ObjIniFile.WriteString("REALM2", "Realm2_Name", txtRealm2Name.Text)
            ObjIniFile.WriteString("REALM2", "Realm2_CoreFile", txtCore2File.Text)
            ObjIniFile.WriteString("REALM2", "Realm2_CorePort", txtCore2Port.Text)

            ObjIniFile.WriteString("REALM3", "Realm3_Name", txtRealm3Name.Text)
            ObjIniFile.WriteString("REALM3", "Realm3_CoreFile", txtCore3File.Text)
            ObjIniFile.WriteString("REALM3", "Realm3_CorePort", txtCore3Port.Text)


            'MYSQL
            ObjIniFile.WriteString("MYSQL", "MySQLDumpFile", txtMySQLDumpFile.Text)
            ObjIniFile.WriteString("MYSQL", "SQLServer", txtMySQLServer.Text)
            ObjIniFile.WriteString("MYSQL", "SQLPort", txtMySQLPort.Text)
            ObjIniFile.WriteString("MYSQL", "SQLUser", txtMySQLUsername.Text)
            ObjIniFile.WriteString("MYSQL", "SQLPass", txtMySQLPassword.Text)

            ObjIniFile.WriteString("MYSQL", "MySQLCheckFile", txtMySQLCheckFile.Text)


            'BACKUP
            ObjIniFile.WriteString("BACKUP", "BackupPath", txtBackupPath.Text)
            ObjIniFile.WriteString("BACKUP", "DBBackupsToKeep", txtDBBackupsKeep.Text)
            ObjIniFile.WriteString("BACKUP", "TableBackupInterval", txtTableInterval.Text)
            ObjIniFile.WriteString("BACKUP", "TableBackupsToKeep", txtTableBackupsKeep.Text)

            ObjIniFile.WriteString("BACKUP", "BackupWorldDB", chkWorldDB.Checked.ToString)
            ObjIniFile.WriteString("BACKUP", "WorldDB1", txtWorldDB1.Text)
            ObjIniFile.WriteString("BACKUP", "WorldDB2", txtWorldDB2.Text)
            ObjIniFile.WriteString("BACKUP", "WorldDB3", txtWorldDB3.Text)
            ObjIniFile.WriteString("BACKUP", "WorldDBInterval", txtWorldDBInt.Text)
            ObjIniFile.WriteString("BACKUP", "BackupWorldTables", chkWorldTables.Checked.ToString)
            SaveWorldTables()

            ObjIniFile.WriteString("BACKUP", "BackupRealmDB", chkRealmDB.Checked.ToString)
            ObjIniFile.WriteString("BACKUP", "RealmDB", txtRealmDB.Text)
            ObjIniFile.WriteString("BACKUP", "RealmDBInterval", txtRealmDBInt.Text)
            ObjIniFile.WriteString("BACKUP", "BackupRealmTables", chkRealmTables.Checked.ToString)
            SaveRealmTables()

            ObjIniFile.WriteString("BACKUP", "BackupCharactersDB", chkCharDB.Checked.ToString)
            ObjIniFile.WriteString("BACKUP", "CharactersDB1", txtCharDB1.Text)
            ObjIniFile.WriteString("BACKUP", "CharactersDB2", txtCharDB2.Text)
            ObjIniFile.WriteString("BACKUP", "CharactersDB3", txtCharDB3.Text)
            ObjIniFile.WriteString("BACKUP", "CharactersDBInterval", txtCharDBInt.Text)
            ObjIniFile.WriteString("BACKUP", "BackupCharactersTables", chkCharTables.Checked.ToString)
            SaveCharTables()


            'ALERTS
            ObjIniFile.WriteString("ALERTS", "EnableEmailAlerts", chkAlerts.Checked.ToString)
            ObjIniFile.WriteString("ALERTS", "MailTo", txtMailTo.Text)
            ObjIniFile.WriteString("ALERTS", "MailFrom", txtMailFrom.Text)
            ObjIniFile.WriteString("ALERTS", "MailServer", txtMailServer.Text)
            ObjIniFile.WriteString("ALERTS", "MailRequiresAuth", chkRequiresAuth.Checked.ToString)
            ObjIniFile.WriteString("ALERTS", "MailUser", txtEmailUsername.Text)
            ObjIniFile.WriteString("ALERTS", "MailDomain", txtEmailDomain.Text)
            ObjIniFile.WriteString("ALERTS", "MailPass", txtEmailPassword.Text)

            'SCHEDULER
            ObjIniFile.WriteString("SCHEDULER", "SchedulerEnabled", chkSchedulerEnabled.Checked.ToString)
        Catch
            MsgBox("Error saving config: " & Err.Description, MsgBoxStyle.Critical, "Error")
            Log("Error saving congfig: " & Err.Description, "ERROR")
        End Try
    End Sub


    Private Sub dlgConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadConfig()

        CheckCore1Path()
        CheckCore2Path()
        CheckCore3Path()
        CheckRealmPath()
        CheckSqlPath()
        CheckBackupPath()

        CheckEnables()
    End Sub

    Private Sub cmdBrowseSQLCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseSQLCheck.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "MySQLCheck File"
        fileDialog.InitialDirectory = "C:\"
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMySQLCheckFile.Text = fileDialog.FileName
        End If
    End Sub


    Private Sub btnRealmBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRealmBrowse.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "Trinity Auth File"
        fileDialog.InitialDirectory = Application.ExecutablePath
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtRealmFile.Text = fileDialog.FileName
        End If
    End Sub

    Private Sub btnCore1Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCore1Browse.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "Trinity World File (Realm 1)"
        fileDialog.InitialDirectory = Application.ExecutablePath
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCore1File.Text = fileDialog.FileName
        End If
    End Sub

    Private Sub btnCore2Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCore2Browse.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "Trinity World File (Realm 2)"
        fileDialog.InitialDirectory = Application.ExecutablePath
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCore2File.Text = fileDialog.FileName
        End If
    End Sub

    Private Sub btnCore3Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCore3Browse.Click
        Dim fileDialog As OpenFileDialog = New OpenFileDialog()
        fileDialog.Title = "Trinity World File (Realm 3)"
        fileDialog.InitialDirectory = Application.ExecutablePath
        fileDialog.Filter = "Executable files (*.exe)|*.exe"
        fileDialog.FilterIndex = 1
        fileDialog.RestoreDirectory = True
        If fileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCore3File.Text = fileDialog.FileName
        End If
    End Sub


    Private Sub cmdTestSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestSQL.Click
        cmdTestSQL.Enabled = False
        lblSQLTest.Text = "Testing connection..."

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", txtMySQLServer.Text, txtMySQLUsername.Text, txtMySQLPassword.Text, txtRealmDB.Text, txtMySQLPort.Text)

        If Not sqlConn Is Nothing Then sqlConn.Close()
        Try
            sqlConn = New MySqlConnection(sqlConnString)
            sqlConn.Open()

            If sqlConn.State = ConnectionState.Open Then lblSQLTest.Text = "Connection to: " & txtMySQLServer.Text & " was successful!"
            sqlConn.Close()
        Catch
            lblSQLTest.Text = "Error: " & Err.GetException.Message
            cmdTestSQL.Enabled = True
        End Try
        cmdTestSQL.Enabled = True
    End Sub
End Class
