Option Strict On
Option Explicit On

Imports MySql.Data.MySqlClient

Module ModCommonFunctions
    Public Declare Function DestroyIcon Lib "user32.dll" (ByVal hIcon As IntPtr) As Int32
    Public ExecutingCommand As Boolean


#Region "Messaging"
    Public Sub Notify(ByVal strMessage As String, ByVal intRealmID As Integer)
        Try
            Dim LockCount As Integer = 0
            Do While ExecutingCommand
                If LockCount > 1000 Then Exit Do
                Application.DoEvents()
                LockCount = LockCount + 1
            Loop
            ExecutingCommand = True

            Log("Nofify: " & strMessage, "DEBUG")

            Dim windowState As Integer = GetWindowState(Realms(intRealmID).strCoreFile)
            SetWindowState(Realms(intRealmID).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(intRealmID).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(intRealmID).strCoreFile))
            End Try
            System.Threading.Thread.Sleep(100)
            SendKeys.SendWait(".NOTIFY " & strMessage & " {ENTER}")
            System.Threading.Thread.Sleep(100)
            SetWindowState(Realms(intRealmID).strCoreFile, windowState)
            FrmMain.Activate()
            ExecutingCommand = False
        Catch
            ExecutingCommand = False
            Log("Error sending notification: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
        End Try
    End Sub

    Public Sub Announce(ByVal strMessage As String, ByVal intRealmID As Integer)
        Try
            Dim LockCount As Integer = 0
            Do While ExecutingCommand
                If LockCount > 2000 Then Exit Do
                Application.DoEvents()
                LockCount = LockCount + 1
            Loop
            ExecutingCommand = True

            Log("Announce: " & strMessage, "DEBUG")

            Dim windowState As Integer = GetWindowState(Realms(intRealmID).strCoreFile)
            SetWindowState(Realms(intRealmID).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(intRealmID).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(intRealmID).strCoreFile))
            End Try
            System.Threading.Thread.Sleep(100)
            SendKeys.SendWait(".ANNOUNCE " & strMessage & " {ENTER}")
            System.Threading.Thread.Sleep(100)
            SetWindowState(Realms(intRealmID).strCoreFile, windowState)
            FrmMain.Activate()
            ExecutingCommand = False
        Catch
            ExecutingCommand = False
            Log("Error sending announcement: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
        End Try
    End Sub

    Public Sub SendMail(ByVal strPlayer As String, ByVal intRealmID As Integer, ByVal strSubject As String, ByVal strMessage As String, ByVal strMoney As String, ByVal strItems As String)
        Do While ExecutingCommand
            Application.DoEvents()
        Loop
        ExecutingCommand = True

        Log("SendMail: " & strPlayer, "DEBUG")
        Try
            Dim windowState As Integer = GetWindowState(Realms(intRealmID).strCoreFile)
            SetWindowState(Realms(intRealmID).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(intRealmID).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(intRealmID).strCoreFile))
            End Try

            'Send mail
            If strMoney.Length < 1 And strItems.Length < 1 Then SendKeys.SendWait(".SEND MAIL " & strPlayer & " " & Convert.ToChar(34) & strSubject & Convert.ToChar(34) & " " & Convert.ToChar(34) & strMessage & Convert.ToChar(34) & " {ENTER}")
            System.Threading.Thread.Sleep(50)

            'Send Money
            If strMoney.Length > 0 Then SendKeys.SendWait(".SEND MONEY " & strPlayer & " " & Convert.ToChar(34) & strSubject & Convert.ToChar(34) & " " & Convert.ToChar(34) & strMessage & Convert.ToChar(34) & " " & strMoney & " {ENTER}")
            System.Threading.Thread.Sleep(50)

            'Send Items
            If strItems.Length > 0 Then SendKeys.SendWait(".SEND ITEM " & strPlayer & " " & Convert.ToChar(34) & strSubject & Convert.ToChar(34) & " " & Convert.ToChar(34) & strMessage & Convert.ToChar(34) & " " & strItems & " {ENTER}")

            System.Threading.Thread.Sleep(50)
            SetWindowState(Realms(intRealmID).strCoreFile, windowState)
            FrmMain.Activate()
        Catch
            ExecutingCommand = False
            Log("Error sending mail: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
            MsgBox("Error sending mail: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try

        ExecutingCommand = False
    End Sub
#End Region

#Region "Account Management"
    Public Sub BanUser(ByVal strUser As String, ByVal strTime As String, ByVal strReason As String)
        Log("BanUser: " & strUser, "DEBUG")
        Try
            Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
            SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(0).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
            End Try
            SendKeys.SendWait(".BAN ACCOUNT " & strUser & " " & strTime & " " & strReason & " {ENTER}")
            SetWindowState(Realms(0).strCoreFile, windowState)
            FrmMain.Activate()
        Catch
            Log("Error setting ban: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
            MsgBox("Error setting ban: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub UNBanUser(ByVal strUser As String)
        Log("UNBanUser: " & strUser, "DEBUG")
        Try
            Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
            SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(0).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
            End Try
            SendKeys.SendWait(".UNBAN ACCOUNT " & strUser & " {ENTER}")
            SetWindowState(Realms(0).strCoreFile, windowState)
            FrmMain.Activate()
        Catch
            Log("Error removing ban: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
            MsgBox("Error removing ban: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub AddUser(ByVal strUser As String, ByVal strPassword As String, ByVal strGMLevel As String, ByVal strExpansionLevel As Integer)
        Log("AddUser: " & strUser, "DEBUG")
        If Not strUser = "" And Not strPassword = "" And Not strGMLevel = "" Then
            Try
                Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
                SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(0).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
                End Try
                SendKeys.SendWait(".ACCOUNT CREATE " & strUser & " " & strPassword & " " & strGMLevel & " {ENTER}")
                System.Threading.Thread.Sleep(100)
                SendKeys.SendWait(".ACCOUNT SET GMLEVEL " & strUser & " " & strGMLevel & " {ENTER}")
                System.Threading.Thread.Sleep(100)
                SendKeys.SendWait(".ACCOUNT SET ADDON " & strUser & " " & strExpansionLevel & " {ENTER}")
                SetWindowState(Realms(0).strCoreFile, windowState)
                FrmMain.Activate()

            Catch
                Log("Error creating account: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
                MsgBox("Error creating account: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
            End Try

            MsgBox("Account with username " & strUser & " created with a password of " & strPassword & ", GM level of " & strGMLevel & " and Expansion level of " & strExpansionLevel, MsgBoxStyle.Information, "Account created")
        End If
    End Sub

    Public Sub DeleteUser(ByVal strUser As String)
        Log("DeleteUser: " & strUser, "DEBUG")
        If Not strUser = "" Then
            Try
                Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
                SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(0).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
                End Try
                SendKeys.SendWait(".ACCOUNT DELETE " & strUser & " {ENTER}")
                SetWindowState(Realms(0).strCoreFile, windowState)
                FrmMain.Activate()

            Catch
                Log("Error deleting account: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
                MsgBox("Error deleting account: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
            End Try

            MsgBox("Account with username " & strUser & " deleted.", MsgBoxStyle.Information, "Account delete")
        End If
    End Sub

    Public Sub DeleteCharacterData()
        'Define character table array
        Dim aryCharacterTables(19) As String
        aryCharacterTables(0) = "characters"
        aryCharacterTables(1) = "character_achievement"
        aryCharacterTables(2) = "character_achievement_progress"
        aryCharacterTables(3) = "character_action"
        aryCharacterTables(4) = "character_aura"
        aryCharacterTables(5) = "character_declinedname"
        aryCharacterTables(6) = "character_gifts"
        aryCharacterTables(7) = "character_homebind"
        aryCharacterTables(8) = "character_instance"
        aryCharacterTables(9) = "character_inventory"
        aryCharacterTables(10) = "character_pet"
        aryCharacterTables(11) = "character_pet_declinedname"
        aryCharacterTables(12) = "character_queststatus"
        aryCharacterTables(13) = "character_queststatus_daily"
        aryCharacterTables(15) = "character_reputation"
        aryCharacterTables(15) = "character_social"
        aryCharacterTables(16) = "character_spell"
        aryCharacterTables(17) = "character_spell_cooldown"
        aryCharacterTables(18) = "character_tutorial"


        For i = 0 To FrmMain.lvCharacters.Items.Count - 1

            'Obtain correct character database
            Dim CurrentCharDatabase As String = ""
            For j = 0 To 2
                If FrmMain.lvCharacters.Items.Item(i).SubItems(1).Text = Realms(j).strName Then CurrentCharDatabase = Realms(j).dbCharacters
            Next

            'Check if correct database was chosen
            If CurrentCharDatabase = "" Then
                MsgBox("Error obtaining character database.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            'Connect to character database
            Try
                Dim connStr As String = "Database=" & CurrentCharDatabase & ";" & _
                        "Data Source=" & SqlHost & ";" & _
                        "User Id=" & SqlUser & ";Password=" & SqlPass

                Dim myConnection As New MySqlConnection(connStr)
                For c = 0 To aryCharacterTables.Count - 1
                    Dim myInsertQuery As String = "DELETE FROM " & aryCharacterTables(c) & " WHERE guid = " & FrmMain.lvCharacters.Items.Item(i).SubItems(2).Text
                    Log("EXECUTED: " & "DELETE FROM " & aryCharacterTables(c) & " WHERE guid = " & FrmMain.lvCharacters.Items.Item(i).SubItems(2).Text, "DEBUG")
                    Dim myCommand As New MySqlCommand(myInsertQuery)

                    myCommand.Connection = myConnection
                    myConnection.Open()
                    myCommand.ExecuteNonQuery()
                    myCommand.Connection.Close()
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub

    Public Sub DeleteAllChars()
        Try
            Dim Realm1Chars(0) As String
            Dim Realm1CharsCount As Integer = -1

            Dim Realm2Chars(0) As String
            Dim Realm2CharsCount As Integer = -1

            Dim Realm3Chars(0) As String
            Dim Realm3CharsCount As Integer = -1

            Dim CharCount As Integer = FrmMain.lvCharacters.Items.Count

            'fill arrays for each realm with characters for selected account
            For charNum = 0 To CharCount - 1
                Dim CurrentRealmName As String = FrmMain.lvCharacters.Items.Item(charNum).SubItems(1).Text
                Select Case CurrentRealmName
                    Case Realms(0).strName
                        Realm1CharsCount = Realm1CharsCount + 1
                        ReDim Preserve Realm1Chars(Realm1CharsCount)
                        Realm1Chars(Realm1CharsCount) = FrmMain.lvCharacters.Items.Item(charNum).Text
                    Case Realms(1).strName
                        Realm2CharsCount = Realm2CharsCount + 1
                        ReDim Preserve Realm2Chars(Realm2CharsCount)
                        Realm2Chars(Realm2CharsCount) = FrmMain.lvCharacters.Items.Item(charNum).Text
                    Case Realms(2).strName
                        Realm3CharsCount = Realm3CharsCount + 1
                        ReDim Preserve Realm3Chars(Realm3CharsCount)
                        Realm3Chars(Realm3CharsCount) = FrmMain.lvCharacters.Items.Item(charNum).Text
                End Select
            Next

            'delete each character from realm 1
            If Realm1CharsCount > -1 Then
                Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
                SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(0).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
                End Try

                For Each Character In Realm1Chars
                    SendKeys.SendWait(".CHARDELETE " & Character & " {ENTER}")
                Next
                SetWindowState(Realms(0).strCoreFile, windowState)
            End If

            'delete each character from realm 2
            If Realm2CharsCount > -1 Then
                Dim windowState As Integer = GetWindowState(Realms(1).strCoreFile)
                SetWindowState(Realms(1).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(1).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(1).strCoreFile))
                End Try

                For Each Character In Realm2Chars
                    SendKeys.SendWait(".CHARDELETE " & Character & " {ENTER}")
                Next
                SetWindowState(Realms(1).strCoreFile, windowState)
            End If

            'delete each character from realm 3
            If Realm3CharsCount > -1 Then
                Dim windowState As Integer = GetWindowState(Realms(2).strCoreFile)
                SetWindowState(Realms(2).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(2).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(2).strCoreFile))
                End Try

                For Each Character In Realm3Chars
                    SendKeys.SendWait(".CHARDELETE " & Character & " {ENTER}")
                Next
                SetWindowState(Realms(2).strCoreFile, windowState)
            End If

            FrmMain.Activate()

        Catch
            Log("Error deleting characters. - " & Err.Description, "ERROR")
        End Try
    End Sub

    Public Sub SetGMLevel(ByVal strUser As String, ByVal GMLvl As String)
        Log("SetGMLevel: " & strUser, "DEBUG")
        Try
            Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
            SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(0).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
            End Try
            SendKeys.SendWait(".ACCOUNT SET GMLEVEL " & strUser & " " & GMLvl & " {ENTER}")
            SetWindowState(Realms(0).strCoreFile, windowState)
            FrmMain.Activate()
        Catch
            Log("Error setting GM Level: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
            MsgBox("Error setting GM Level: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub SetExpLevel(ByVal strUser As String, ByVal intExpLvl As String)
        Log("SetEXPLevel: " & strUser, "DEBUG")
        Try
            Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
            SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
            Try
                AppActivate(GetPid(Realms(0).strCoreFile))
            Catch
                AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
            End Try
            SendKeys.SendWait(".ACCOUNT SET ADDON " & strUser & " " & intExpLvl & " {ENTER}")
            SetWindowState(Realms(0).strCoreFile, windowState)
            FrmMain.Activate()
        Catch
            Log("Error setting Expansion Level: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
            MsgBox("Error setting Expansion Level: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
#End Region

#Region "Character Management"
    Public Sub KickChar(ByVal str As String)
        Log("KickChar: " & str, "DEBUG")
        If Not str = "" Then
            Try
                Dim windowState As Integer = GetWindowState(Realms(0).strCoreFile)
                SetWindowState(Realms(0).strCoreFile, SWShownoactivate)
                Try
                    AppActivate(GetPid(Realms(0).strCoreFile))
                Catch
                    AppActivate(FileNameWithoutExtension(Realms(0).strCoreFile))
                End Try
                SendKeys.SendWait(".KICK " & str & " {ENTER}")
                SetWindowState(Realms(0).strCoreFile, windowState)
                FrmMain.Activate()

            Catch
                Log("Error kicking character: " & vbNewLine & vbNewLine & Err.Description, "ERROR")
                MsgBox("Error kicking character: " & vbNewLine & vbNewLine & Err.Description, MsgBoxStyle.Critical, "Error")
            End Try

            MsgBox(str & " has been kicked.", MsgBoxStyle.Information, "Kick character")
        End If
    End Sub
#End Region

#Region "Account Array Functions"
    Public Function GetGMByName(ByVal strAccount As String) As Integer
        For i = 0 To InfoAccount.Length - 1
            If InfoAccount(i).Name = strAccount Then
                Return InfoAccount(i).GMLvl
            End If
        Next

        Return 0
    End Function

    Public Function GetExpByName(ByVal strAccount As String) As Integer
        For i = 0 To InfoAccount.Length - 1
            If InfoAccount(i).Name = strAccount Then
                Return InfoAccount(i).ExpLvl
            End If
        Next

        Return 0
    End Function

    Public Function GetArrayIndexByName(ByVal strAccount As String) As Integer
        For i = 0 To InfoAccount.Length - 1
            If InfoAccount(i).Name = strAccount Then
                Return i
            End If
        Next

        Return -1
    End Function
#End Region

#Region "Logging and Error Handling"
    Public Sub Log(ByVal str As String, ByVal strType As String)
        Select Case strType
            Case "ERROR"
                ObjLogFile.WriteString("LOG", Logindex.ToString, Now & ":  " & str)
                System.Threading.Interlocked.Increment(Logindex)
                'Logindex = Logindex + 1
            Case "DEBUG"
                If DebugModeLog Then
                    ObjLogFile.WriteString("LOG", Logindex.ToString, Now & ":  " & str)
                    'Logindex = Logindex + 1
                    System.Threading.Interlocked.Increment(Logindex)
                End If
        End Select

        If DebugModeLog Then FrmMain.lblDebug.Text = str
    End Sub

#End Region

#Region "File Functions"
    Public Function PathName(ByVal strFile As String) As String
        Return System.IO.Path.GetDirectoryName(strFile)
    End Function

    Public Function FileName(ByVal strFile As String) As String
        Return System.IO.Path.GetFileName(strFile)
    End Function

    Public Function FileNameWithoutExtension(ByVal strFile As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(strFile)
    End Function

#End Region

#Region "Counter Functions"
    Public Function FormatTimeSpan(ByVal timeSpan As  _
TimeSpan, Optional ByVal wholeSeconds As Boolean = _
True) As String
        Dim txt As String = ""
        Try
            If timeSpan.Days > 0 Then
                txt &= ", " & timeSpan.Days.ToString() & " day(s)"
                timeSpan = timeSpan.Subtract(New  _
                    TimeSpan(timeSpan.Days, 0, 0, 0))
            End If
            If timeSpan.Hours > 0 Then
                txt &= ", " & timeSpan.Hours.ToString() & " hour(s)"
                timeSpan = timeSpan.Subtract(New TimeSpan(0, _
                    timeSpan.Hours, 0, 0))
            End If
            If timeSpan.Minutes > 0 Then
                txt &= ", " & timeSpan.Minutes.ToString() & " " & _
                    "minute(s)"
                timeSpan = timeSpan.Subtract(New TimeSpan(0, 0, _
                    timeSpan.Minutes, 0))
            End If

            If wholeSeconds Then
                ' Display only whole seconds.
                If timeSpan.Seconds > 0 Then
                    txt &= ", " & timeSpan.Seconds.ToString() & " " & _
                        "second(s)"
                End If
            Else
                ' Display fractional seconds.
                txt &= ", " & timeSpan.TotalSeconds.ToString() & " " & _
                    "second(s)"
            End If

            ' Remove the leading ", ".
            If txt.Length > 0 Then txt = txt.Substring(2)
        Catch ex As Exception
            txt = "Error calculating uptime"
        End Try

        timeSpan = Nothing

        ' Return the result.
        Return txt
    End Function
#End Region

End Module
