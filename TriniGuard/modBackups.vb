Option Strict On

Module ModBackups
    'Backup Checks
    Dim RealmBackupInProgress As Boolean = False
    Dim WorldBackupInProgress As Boolean = False
    Dim CharBackupInProgress As Boolean = False
    Dim TableBackupInProgress As Boolean = False

    'MySQL Settings
    Dim MySqlPath As String = PathName(MySqlDump)
    Dim MySqlFile As String = FileName(MySqlDump)

    Dim MySqlCheckPath As String = PathName(MySqlCheck)
    Dim MySqlCheckFile As String = FileName(MySqlCheck)


    Public Sub BakWorld()
        If Not WorldBackupInProgress Then
            WorldBackupInProgress = True

            For i = 0 To NumWorldDB - 1
                Dim CurrentDatabase As String = "$NEXT"
                Select Case i
                    Case 0
                        If Not DBWorld1 = "" Then CurrentDatabase = DBWorld1
                    Case 1
                        If Not DBWorld2 = "" Then CurrentDatabase = DBWorld2
                    Case 2
                        If Not DBWorld3 = "" Then CurrentDatabase = DBWorld3
                End Select

                If Not CurrentDatabase = "$NEXT" Then
                    If BackupWorldDB And Not CurrentDatabase = "" Then
                        Log("Backing up World Database for Realm: " & Realms(i).strName, "DEBUG")
                        FrmMain.lblStatus.Text = "Backing up World Database for Realm: " & Realms(i).strName
                        FrmMain.tmrSaveIcon.Enabled = True
                        WorldBackupInProgress = True
                        While Not StartBackup(CurrentDatabase, "")
                            Application.DoEvents()
                        End While
                        FrmMain.tmrSaveIcon.Enabled = False
                        FrmMain.lblStatus.Text = "Backup complete."
                    End If
                End If
            Next

            CheckServerStatus()
            WorldBackupInProgress = False
        End If
    End Sub

    Public Sub BakRealm()
        If BackupRealmDB And Not DBRealm = "" And Not RealmBackupInProgress Then
            Log("Backing up Realm Database.", "DEBUG")
            FrmMain.tmrSaveIcon.Enabled = True
            RealmBackupInProgress = True
            While Not StartBackup(DBRealm, "")
                Application.DoEvents()
            End While
            FrmMain.tmrSaveIcon.Enabled = False
            CheckServerStatus()
            RealmBackupInProgress = False
        End If
    End Sub

    Public Sub BakChar()
        If Not CharBackupInProgress Then
            CharBackupInProgress = True

            For i = 0 To NumCharDB - 1
                Dim CurrentDatabase As String = "$NEXT"
                Select Case i
                    Case 0
                        If Not DBCharacters1 = "" Then CurrentDatabase = DBCharacters1
                    Case 1
                        If Not DBCharacters2 = "" Then CurrentDatabase = DBCharacters2
                    Case 2
                        If Not DBCharacters3 = "" Then CurrentDatabase = DBCharacters3
                End Select

                If Not CurrentDatabase = "$NEXT" Then
                    If BackupCharactersDB And Not CurrentDatabase = "" Then
                        Log("Backing up Characters Database for Realm: " & Realms(i).strName, "DEBUG")
                        FrmMain.lblStatus.Text = "Backing up Characters Database for Realm: " & Realms(i).strName
                        FrmMain.tmrSaveIcon.Enabled = True
                        CharBackupInProgress = True
                        While Not StartBackup(CurrentDatabase, "")
                            Application.DoEvents()
                        End While
                        FrmMain.tmrSaveIcon.Enabled = False
                    End If
                End If
            Next

            CheckServerStatus()
            CharBackupInProgress = False
        End If
    End Sub

    Public Sub BakTables()
        If Not TableBackupInProgress Then
            TableBackupInProgress = True
            FrmMain.tmrSaveIcon.Enabled = True

            For i = 0 To NumWorldDB - 1
                Dim CurrentDatabase As String = "$NEXT"
                Select Case i
                    Case 0
                        If Not DBWorld1 = "" Then CurrentDatabase = DBWorld1
                    Case 1
                        If Not DBWorld2 = "" Then CurrentDatabase = DBWorld2
                    Case 2
                        If Not DBWorld3 = "" Then CurrentDatabase = DBWorld3
                End Select

                If Not CurrentDatabase = "$NEXT" Then
                    If BackupWorldTables And Not TBWorld = "" Then
                        Log("Backing up World Tables for: " & Realms(i).strName, "DEBUG")
                        FrmMain.lblStatus.Text = "Backing up World Tables for: " & Realms(i).strName
                        While Not StartBackup(CurrentDatabase, TBWorld)
                            Application.DoEvents()
                        End While
                    End If
                End If
            Next

            If BackupRealmTables And Not TBRealm = "" Then
                While Not StartBackup(DBRealm, TBRealm)
                    Application.DoEvents()
                End While
                FrmMain.lblStatus.Text = "Backup complete."
            End If

            For i = 0 To NumCharDB - 1
                Dim CurrentDatabase As String = "$NEXT"
                Log("Backing up Character Tables for: " & Realms(i).strName, "DEBUG")
                FrmMain.lblStatus.Text = "Backing up Character Tables for: " & Realms(i).strName
                Select Case i
                    Case 0
                        If Not DBCharacters1 = "" Then CurrentDatabase = DBCharacters1
                    Case 1
                        If Not DBCharacters2 = "" Then CurrentDatabase = DBCharacters2
                    Case 2
                        If Not DBCharacters3 = "" Then CurrentDatabase = DBCharacters3
                End Select

                If Not CurrentDatabase = "$NEXT" Then
                    If BackupCharactersTables And Not TBCharacters = "" Then
                        While Not StartBackup(CurrentDatabase, TBCharacters)
                            Application.DoEvents()
                        End While
                    End If
                End If
            Next

            CheckServerStatus()
            FrmMain.tmrSaveIcon.Enabled = False
            TableBackupInProgress = False
        End If
    End Sub

    Public Sub BackupDatabases()
        Log("BackupDatabases", "DEBUG")
        'Full DB Backups
        BakWorld()
        BakRealm()
        BakChar()

        'Table Backups
        BakTables()
    End Sub

    Public Function StartBackup(ByVal strDB As String, ByVal strTB As String) As Boolean
        Log("StartBackup: " & strDB & strTB, "DEBUG")
        FrmMain.cmdBackupNow.Enabled = False
        If strTB = "" Then
            'FrmMain.lblStatus.Text = "Purging oldest full database backup..."
            Do While Not PurgeOldBackup(strDB, "", DatabaseBackupsToKeep)
                Application.DoEvents()
                Log("LOOP: StartBackup - Purge", "DEBUG")
            Loop

            'FrmMain.lblStatus.Text = "Backing up full " & strDB & " Database..."
            Dim mySqlString As String = " --port=" & SqlPort & " --host=" & SqlHost & " --user=" & SqlUser & " --password=" & SqlPass & " --opt " & strDB & " -r " & Convert.ToChar(34) & BackupPath & "\" & strDB & "_" & strTB & "_BACKUP_1" & ".SQL" & Convert.ToChar(34)
            StartProcess(MySqlPath, MySqlFile, mySqlString)
            mySqlString = Nothing
        Else
            'FrmMain.lblStatus.Text = "Purging oldest table backup..."
            Do While Not PurgeOldBackup(strDB, strTB, TableBackupsToKeep)
                Application.DoEvents()
                Log("LOOP: StartBackup - Purge", "DEBUG")
            Loop

            'FrmMain.lblStatus.Text = "Backing up tables " & strTB & " from " & strDB & "..."
            Dim mySqlString = " --port=" & SqlPort & " --host=" & SqlHost & " --user=" & SqlUser & " --password=" & SqlPass & " --add-drop-table " & strDB & " " & strTB & " -r " & Convert.ToChar(34) & BackupPath & "\" & strDB & "_Tables" & "_BACKUP_1" & ".SQL" & Convert.ToChar(34)
            StartProcess(MySqlPath, MySqlFile, mySqlString)
            mySqlString = Nothing
        End If

        FrmMain.cmdBackupNow.Enabled = True

        Return True
    End Function

    Public Sub CheckDB()
        Log("CheckDB", "DEBUG")

        'Start Database Check Process
        Dim mySqlCheckString = " -o -e -A -P" & SqlPort & " -h" & SqlHost & " -u" & SqlUser & " -p" & SqlPass
        StartProcess(MySqlCheckPath, MySqlCheckFile, mySqlCheckString)
        System.Threading.Thread.Sleep(100)
    End Sub

    Public Function PurgeOldBackup(ByVal db As String, ByVal tb As String, ByVal dbtk As Integer) As Boolean
        Log("PurgeOldBackup: " & db & tb, "DEBUG")
        If Not tb = "" Then tb = "Tables"

        'delete the oldest file if it exists
        Dim fileToDelete = db & "_" & tb & "_BACKUP_" & dbtk & ".SQL"
        If System.IO.File.Exists(BackupPath & "\" & fileToDelete) = True Then System.IO.File.Delete(BackupPath & "\" & fileToDelete)
        fileToDelete = Nothing

        Dim fileToMove As String
        Dim fileToMoveTo As String

        'increment existing files
        For i = (dbtk - 2) To 0 Step -1
            fileToMove = db & "_" & tb & "_BACKUP_" & i + 1 & ".SQL"
            If System.IO.File.Exists(BackupPath & "\" & fileToMove) = True Then
                fileToMoveTo = db & "_" & tb & "_BACKUP_" & i + 2 & ".SQL"
                System.IO.File.Move(BackupPath & "\" & fileToMove, BackupPath & "\" & fileToMoveTo)
            End If
            fileToMove = Nothing
            fileToMoveTo = Nothing
        Next

        tb = Nothing

        Return True
    End Function
End Module
