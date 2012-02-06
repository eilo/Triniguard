Option Strict On
Option Explicit On

Imports MySql.Data.MySqlClient


Public Class TrinityDB
    Dim IAmBusy As Boolean

    Dim FirstCharLoad As Boolean = True

    Dim WAITINGFOR As String = ""

    Public Event EventFinishedGetCharactersForAccount()
    Public Event EventFinishedAccInfo()
    Public Event EventFinishedGetCharactersList()
    Public Event EventFinishedCountingOnlineAccounts(ByVal numberOnline As Integer)
    Public Event EventFinishedCountingAccounts(ByVal numberOnline As Integer)
    Public Event EventFinishedCountingCharacters(ByVal numChars As Integer)


    Public Sub GetNumOnline()
        Log("START: GetNumOnline", "DEBUG")

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder
        Dim sqlDataTable As New DataTable

        Do
            If ServerUp Then
                Do While IAmBusy
                    Application.DoEvents()
                    Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
                    System.Threading.Thread.Sleep(2000)
                Loop

                IAmBusy = True
                WAITINGFOR = "getnumonline"
                sqlDataTable.Clear()

                Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBRealm, SqlPort)
                If Not sqlConn Is Nothing Then sqlConn.Close()
                Try
                    sqlConn = New MySqlConnection(sqlConnString)
                    sqlConn.Open()

                    sqlDA = New MySqlDataAdapter("SELECT `online` FROM `account` WHERE `online`=1", sqlConn)
                    sqlCB = New MySqlCommandBuilder(sqlDA)

                    sqlDA.Fill(sqlDataTable)
                    IAmBusy = False
                    Log("END: GetNumOnline", "DEBUG")
                    RaiseEvent EventFinishedCountingOnlineAccounts(sqlDataTable.Rows.Count)

                    'clean up
                    sqlDA.Dispose()
                    sqlCB.Dispose()
                    sqlDataTable.Dispose()
                    sqlConn.Close()
                    sqlConn.Dispose()

                Catch ex As Exception
                    Log("MySQL Error: " + SqlHost & " - " _
                    & "Error Message: " + ex.Message & " - " _
                    & "Error Source: " + ex.Source & " - " _
                    & "Stack Trace: " + ex.StackTrace, "ERROR")
                    IAmBusy = False
                End Try
            End If

            System.Threading.Thread.Sleep(5000)
        Loop
    End Sub

    Public Sub GetNumAccounts()
        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder
        Dim sqlDataTable As New DataTable

        Do
            Log("START: GetNumAccounts", "DEBUG")
            If ServerUp Then
                WAITINGFOR = "getnumaccounts"
                IAmBusy = True
                sqlDataTable.Clear()

                Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBRealm, SqlPort)
                If Not sqlConn Is Nothing Then sqlConn.Close()
                Try
                    sqlConn = New MySqlConnection(sqlConnString)
                    sqlConn.Open()

                    sqlDA = New MySqlDataAdapter("SELECT `online` FROM `account`", sqlConn)
                    sqlCB = New MySqlCommandBuilder(sqlDA)

                    sqlDA.Fill(sqlDataTable)
                    IAmBusy = False
                    Log("END: GetNumAccounts", "DEBUG")
                    RaiseEvent EventFinishedCountingAccounts(sqlDataTable.Rows.Count)

                    'clean up
                    sqlDataTable.Dispose()
                    sqlConn.Close()
                    sqlConn.Dispose()
                    sqlDA.Dispose()
                    sqlCB.Dispose()

                Catch ex As Exception
                    Log("MySQL Error: " + SqlHost & " - " _
                    & "Error Message: " + ex.Message & " - " _
                    & "Error Source: " + ex.Source & " - " _
                    & "Stack Trace: " + ex.StackTrace, "ERROR")
                    IAmBusy = False
                End Try
            End If

            System.Threading.Thread.Sleep(9000)
        Loop
    End Sub

    Public Sub GetNumCharacters()
        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder
        Dim sqlDataTable As New DataTable

        Do
            Log("START: GetNumCharacters", "DEBUG")
            If ServerUp Then
                WAITINGFOR = "GetNumCharacters"
                IAmBusy = True
                sqlDataTable.Clear()

                Dim CharCount As Integer = 0

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

                        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, CurrentDatabase, SqlPort)
                        If Not sqlConn Is Nothing Then sqlConn.Close()
                        Try
                            sqlConn = New MySqlConnection(sqlConnString)
                            sqlConn.Open()

                            sqlDA = New MySqlDataAdapter("SELECT `name` FROM `characters`", sqlConn)
                            sqlCB = New MySqlCommandBuilder(sqlDA)

                            sqlDA.Fill(sqlDataTable)
                            CharCount = CharCount + sqlDataTable.Rows.Count
                            IAmBusy = False
                            Log("END: GetNumCharacters", "DEBUG")


                            'clean up
                            sqlDataTable.Dispose()
                            sqlConn.Close()
                            sqlConn.Dispose()
                            sqlDA.Dispose()
                            sqlCB.Dispose()

                        Catch ex As Exception
                            Log("MySQL Error: " + SqlHost & " - " _
                            & "Error Message: " + ex.Message & " - " _
                            & "Error Source: " + ex.Source & " - " _
                            & "Stack Trace: " + ex.StackTrace, "ERROR")
                            IAmBusy = False
                        End Try
                    End If
                Next

                'send result
                RaiseEvent EventFinishedCountingCharacters(CharCount)
                'System.Threading.Thread.Sleep(60000)
            End If

            If FirstCharLoad Then
                System.Threading.Thread.Sleep(1000)
                FirstCharLoad = False
            Else
                System.Threading.Thread.Sleep(60000)
            End If
        Loop
    End Sub

    Public Sub GetAccounts()
        Log("START: GetAccounts", "DEBUG")
        'If ServerUp = False Then Exit Sub

        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop

        GeneratingAccountInfo = True

        WAITINGFOR = "getaccounts"
        IAmBusy = True

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtAccounts As New DataTable
        dtAccounts.Clear()

        Do While Not dtAccounts.IsInitialized
            Application.DoEvents()
            Log("LOOP: GetAccounts", "DEBUG")
        Loop

        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBRealm, SqlPort)

        If Not sqlConn Is Nothing Then sqlConn.Close()
        Try
            sqlConn = New MySqlConnection(sqlConnString)
            sqlConn.Open()

            'ITEM BELOW CHANGED DUE TO CHANGES IN CORE
            'sqlDA = New MySqlDataAdapter("SELECT `id`, `username`, `online`, `gmlevel`, `expansion` FROM `account`  ORDER BY `username`", sqlConn)
            sqlDA = New MySqlDataAdapter("SELECT account.id, account.username, account.online, account.expansion, account_access.gmlevel FROM account LEFT JOIN account_access on account.id = account_access.id ORDER BY `username`;", sqlConn)
            sqlCB = New MySqlCommandBuilder(sqlDA)

            sqlDA.Fill(dtAccounts)

            For CurrentAccount = 0 To dtAccounts.Rows.Count - 1
                Log("GetAccounts: Adding to array: " & CurrentAccount, "DEBUG")
                Dim accountID As Integer = Convert.ToInt16(dtAccounts.Rows(CurrentAccount)("ID"))
                Dim accountName As String = dtAccounts.Rows(CurrentAccount)("Username").ToString
                Dim accountOnline As Integer = Convert.ToInt16(dtAccounts.Rows(CurrentAccount)("Online"))

                Dim accountGMLvl As Integer = 0
                Try
                    accountGMLvl = Convert.ToInt16(dtAccounts.Rows(CurrentAccount)("gmlevel"))
                Catch ex As Exception
                    'must be null value, leave accountGMLvl as 0
                End Try

                Dim accountExpLvl As Integer = Convert.ToInt16(dtAccounts.Rows(CurrentAccount)("expansion"))

                If Not Trim(accountName) = "" Or Not Trim(accountName) = Nothing Then
                    Log("Adding account to array: '" & accountName & "'", "DEBUG")
                    ReDim Preserve InfoAccount(CurrentAccount)
                    InfoAccount(CurrentAccount).ID = accountID
                    InfoAccount(CurrentAccount).Name = accountName
                    InfoAccount(CurrentAccount).Online = accountOnline
                    InfoAccount(CurrentAccount).GMLvl = accountGMLvl
                    InfoAccount(CurrentAccount).ExpLvl = accountExpLvl
                End If

                Application.DoEvents()
            Next

            GeneratingAccountInfo = False

            IAmBusy = False
            GeneratingAccountInfo = False
            Log("END: GetAccounts", "DEBUG")
            RaiseEvent EventFinishedAccInfo()

            sqlConn.Close()
            sqlConn.Dispose()
            sqlDA.Dispose()
            sqlCB.Dispose()

        Catch ex As Exception
            Log("MySQL Error: " + SqlHost & " - " _
            & "Error Message: " + ex.Message & " - " _
            & "Error Source: " + ex.Source & " - " _
            & "Stack Trace: " + ex.StackTrace, "ERROR")

            IAmBusy = False
            GeneratingAccountInfo = False
        End Try
    End Sub

    Public Sub GetCharactersForAccount(ByVal strUserName As String)
        Log("START: GetCharactersForAccount: " & strUserName, "DEBUG")

        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop
        WAITINGFOR = "GetCharactersForAccount: " & strUserName
        IAmBusy = True

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtCharacters As New DataTable
        Dim CharCounter As Integer = 0

        ReDim InfoCharacter(0)

        For i = 0 To Realms.Count - 1
            Log("START: GetCharactersForAccount - Realm: " & i & " - " & strUserName, "DEBUG")
            If Not Realms(i).dbCharacters = Nothing Then
                Dim CurrentDatabase As String = Realms(i).dbCharacters

                If Not CurrentDatabase = "$NEXT" Then
                    Dim CurrentRealmCharDB As String = Realms(i).dbCharacters

                    Do While Not dtCharacters.IsInitialized
                        Application.DoEvents()
                        Log("LOOP: GetCharactersForAccount", "DEBUG")
                    Loop

                    Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, CurrentDatabase, SqlPort)

                    If Not sqlConn Is Nothing Then sqlConn.Close()
                    Try
                        sqlConn = New MySqlConnection(sqlConnString)
                        sqlConn.Open()

                        sqlDA = New MySqlDataAdapter("SELECT `name`, `online`, `guid` FROM `characters` WHERE `account` IN (SELECT `id` FROM " & DBRealm & ".account WHERE `username` = '" & strUserName & "');", sqlConn)
                        sqlCB = New MySqlCommandBuilder(sqlDA)

                        sqlDA.Fill(dtCharacters)

                        For CurrentCharacter = 0 To dtCharacters.Rows.Count - 1
                            Log("START: GetCharactersForAccount - Filling Arrays " & strUserName, "DEBUG")
                            Dim characterName As String = dtCharacters.Rows(CurrentCharacter)("Name").ToString
                            Dim characterOnline As Integer = Convert.ToInt16(dtCharacters.Rows(CurrentCharacter)("Online"))
                            Dim characterGUID As Integer = Convert.ToInt16(dtCharacters.Rows(CurrentCharacter)("guid"))

                            If Not Trim(characterName) = "" Or Not Trim(characterName) = Nothing Then
                                ReDim Preserve InfoCharacter(CharCounter)
                                InfoCharacter(CharCounter).Name = characterName
                                InfoCharacter(CharCounter).Online = characterOnline
                                InfoCharacter(CharCounter).RealmName = Realms(i).strName
                                InfoCharacter(CharCounter).RealmID = i

                                CharCounter = CharCounter + 1
                            End If

                            Application.DoEvents()
                        Next

                        dtCharacters.Clear()

                        sqlConn.Close()
                        sqlConn.Dispose()
                        sqlDA.Dispose()
                        sqlCB.Dispose()

                    Catch ex As Exception
                        Log("MySQL Error: " + SqlHost & " - " _
                        & "Error Message: " + ex.Message & " - " _
                        & "Error Source: " + ex.Source & " - " _
                        & "Stack Trace: " + ex.StackTrace, "ERROR")
                        IAmBusy = False
                    End Try
                End If
            End If
        Next

        IAmBusy = False
        Log("END: GetCharactersForAccount: " & strUserName, "DEBUG")
        RaiseEvent EventFinishedGetCharactersForAccount()
    End Sub

    Public Function GetOnlineCharForAccount(ByVal strUserName As String) As String
        Log("START: GetOnlineCharForAccount: " & strUserName, "DEBUG")

        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop
        WAITINGFOR = "GetOnlineCharForAccount: " & strUserName
        IAmBusy = True

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtCharacters As New DataTable
        dtCharacters.Clear()

        Do While Not dtCharacters.IsInitialized
            Application.DoEvents()
            Log("LOOP: GetOnlineCharForAccount", "DEBUG")
        Loop

        Dim CharCounter As Integer = 0

        For i = 0 To Realms.Count - 1
            If Not Realms(i).dbCharacters = Nothing Then
                Dim CurrentDatabase As String = Realms(i).dbCharacters

                If Not CurrentDatabase = "$NEXT" Then

                    Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, CurrentDatabase, SqlPort)

                    If Not sqlConn Is Nothing Then sqlConn.Close()
                    Try
                        sqlConn = New MySqlConnection(sqlConnString)
                        sqlConn.Open()

                        sqlDA = New MySqlDataAdapter("SELECT `name`, `online` FROM `characters` WHERE `online` = 1 AND `account` IN (SELECT `id` FROM " & DBRealm & ".account WHERE `username` = '" & strUserName & "');", sqlConn)
                        sqlCB = New MySqlCommandBuilder(sqlDA)

                        sqlDA.Fill(dtCharacters)

                        If CharCounter < 1 And dtCharacters.Rows.Count > 0 Then
                            For CurrentCharacter = 0 To dtCharacters.Rows.Count - 1
                                Log("START: GetOnlineCharForAccount - Filling arrays... " & strUserName, "DEBUG")
                                Dim characterName As String = dtCharacters.Rows(CurrentCharacter)("Name").ToString
                                Dim characterOnline As Integer = Convert.ToInt16(dtCharacters.Rows(CurrentCharacter)("Online"))

                                If Not Trim(characterName) = "" Or Not Trim(characterName) = Nothing Then
                                    ReDim Preserve InfoOnlineCharacter(CharCounter)
                                    InfoOnlineCharacter(CharCounter).Name = characterName
                                    InfoOnlineCharacter(CharCounter).Online = characterOnline
                                    InfoOnlineCharacter(CharCounter).RealmName = Realms(i).strName
                                    InfoOnlineCharacter(CharCounter).RealmID = i

                                    CharCounter = CharCounter + 1
                                End If

                                Application.DoEvents()
                            Next
                        End If

                        sqlConn.Close()
                        sqlConn.Dispose()
                        sqlDA.Dispose()
                        sqlCB.Dispose()

                    Catch ex As Exception
                        Log("MySQL Error: " + SqlHost & " - " _
                        & "Error Message: " + ex.Message & " - " _
                        & "Error Source: " + ex.Source & " - " _
                        & "Stack Trace: " + ex.StackTrace, "ERROR")
                        IAmBusy = False
                        Return ""
                    End Try
                End If

                Log("END: GetOnlineCharForAccount: " & strUserName, "DEBUG")
            End If
        Next

        If dtCharacters.Rows.Count = 0 Then
            IAmBusy = False
            Return ""
            Exit Function
        Else
            IAmBusy = False
            Return InfoOnlineCharacter(0).Name & ";" & InfoOnlineCharacter(0).RealmID
        End If

        IAmBusy = False
    End Function

    Public Sub CheckIfBanned()
        Log("START: CheckIfBanned", "DEBUG")

        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop

        WAITINGFOR = "CheckIfBanned"
        IAmBusy = True


        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtBans As New DataTable

        Do While Not dtBans.IsInitialized
            Application.DoEvents()
            Log("LOOP: CheckIfBanned", "DEBUG")
        Loop

        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBRealm, SqlPort)

        If Not sqlConn Is Nothing Then sqlConn.Close()
        Try
            sqlConn = New MySqlConnection(sqlConnString)
            sqlConn.Open()

            For intAccount = 0 To InfoAccount.Length - 1
                Log("START: CheckIfBanned - for loop", "DEBUG")
                sqlDA = New MySqlDataAdapter("SELECT `username` FROM `account` WHERE `id` IN (SELECT `id` FROM " & DBRealm & ".account_banned WHERE `active` = 1) AND `username` = '" & InfoAccount(intAccount).Name & "';", sqlConn)
                sqlCB = New MySqlCommandBuilder(sqlDA)

                sqlDA.Fill(dtBans)

                If dtBans.Rows.Count = 0 Then
                    dtBans.Clear()
                    Log("END: CheckIfBanned: " & InfoAccount(intAccount).Name & " = False", "DEBUG")
                    IAmBusy = False
                    InfoAccount(intAccount).Banned = False
                Else
                    dtBans.Clear()
                    Log("END: CheckIfBanned: " & InfoAccount(intAccount).Name & " = True", "DEBUG")
                    IAmBusy = False
                    InfoAccount(intAccount).Banned = True
                End If

                sqlDA.Dispose()
                sqlCB.Dispose()

                Application.DoEvents()
            Next

            sqlConn.Close()
            sqlConn.Dispose()


        Catch ex As Exception
            Log("MySQL Error: " + SqlHost & " - " _
            & "Error Message: " + ex.Message & " - " _
            & "Error Source: " + ex.Source & " - " _
            & "Stack Trace: " + ex.StackTrace, "ERROR")
            IAmBusy = False
        End Try
    End Sub

    Public Sub GetCharactersList()
        Log("START: GetCharactersList", "DEBUG")
        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop
        WAITINGFOR = "GetCharactersList"
        IAmBusy = True

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtCharacters As New DataTable
        Dim CharCounter As Integer = 0

        ReDim AllCharacters(0)

        For i = 0 To Realms.Count - 1
            If Not Realms(i).dbCharacters = Nothing Then
                Dim CurrentDatabase As String = Realms(i).dbCharacters
                Dim CurrentRealmName As String = Realms(i).strName
                Dim CurrentRealmCharDB As String = Realms(i).dbCharacters

                Do While Not dtCharacters.IsInitialized
                    Application.DoEvents()
                    Log("GetCharactersList: Waiting for dtCharacters", "DEBUG")
                Loop

                Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, CurrentDatabase, SqlPort)

                If Not sqlConn Is Nothing Then sqlConn.Close()
                Try
                    Log("GetCharactersList: Open SQL Connection", "DEBUG")
                    sqlConn = New MySqlConnection(sqlConnString)
                    sqlConn.Open()

                    Log("GetCharactersList: SQL DA CB", "DEBUG")
                    sqlDA = New MySqlDataAdapter("SELECT `name`, `GUID` FROM `characters` ;", sqlConn)
                    sqlCB = New MySqlCommandBuilder(sqlDA)

                    Log("GetCharactersList: Fill", "DEBUG")
                    sqlDA.Fill(dtCharacters)

                    For CurrentCharacter = 0 To dtCharacters.Rows.Count - 1
                        Log("GetCharactersList: Set array for: " & CurrentCharacter, "DEBUG")
                        Dim characterName As String = dtCharacters.Rows(CurrentCharacter)("Name").ToString
                        Dim characterGUID As Integer = Convert.ToInt16(dtCharacters.Rows(CurrentCharacter)("guid"))

                        If Not Trim(characterName) = "" Or Not Trim(characterName) = Nothing Then
                            ReDim Preserve AllCharacters(CharCounter)
                            AllCharacters(CharCounter).Name = characterName
                            AllCharacters(CharCounter).GUID = characterGUID
                            AllCharacters(CharCounter).RealmName = CurrentRealmName
                            AllCharacters(CharCounter).RealmID = i

                            CharCounter = CharCounter + 1
                        End If

                        Application.DoEvents()
                    Next

                    dtCharacters.Clear()

                    Log("GetCharactersList: Clean", "DEBUG")
                    sqlConn.Close()
                    sqlConn.Dispose()
                    sqlDA.Dispose()
                    sqlCB.Dispose()

                Catch ex As Exception
                    Log("MySQL Error: " + SqlHost & " - " _
                    & "Error Message: " + ex.Message & " - " _
                    & "Error Source: " + ex.Source & " - " _
                    & "Stack Trace: " + ex.StackTrace, "ERROR")
                    IAmBusy = False
                End Try
            End If
        Next

        IAmBusy = False
        Log("END: GetCharactersList", "DEBUG")
        RaiseEvent EventFinishedGetCharactersList()
    End Sub

    Public Sub GetVersions()
        Log("START: GetVersions", "DEBUG")

        Do While IAmBusy
            Application.DoEvents()
            Log("-- WAITING FOR: " & WAITINGFOR, "DEBUG")
            System.Threading.Thread.Sleep(2000)
        Loop
        WAITINGFOR = "GetVersions"
        IAmBusy = True

        Dim sqlConn As MySqlConnection = Nothing
        Dim sqlDA As MySqlDataAdapter
        Dim sqlCB As MySqlCommandBuilder

        Dim dtVersions As New DataTable
        dtVersions.Clear()

        Do While Not dtVersions.IsInitialized
            Application.DoEvents()
            Log("LOOP: GetVersions", "DEBUG")
        Loop

        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBWorld1, SqlPort)

        If Not sqlConn Is Nothing Then sqlConn.Close()
        Try
            sqlConn = New MySqlConnection(sqlConnString)
            sqlConn.Open()

            sqlDA = New MySqlDataAdapter("SELECT `core_version`, `core_revision`, `db_version` FROM `version`;", sqlConn)
            sqlCB = New MySqlCommandBuilder(sqlDA)

            sqlDA.Fill(dtVersions)

            InfoVersion.Core = dtVersions.Rows(0)("core_version").ToString
            InfoVersion.CoreRev = dtVersions.Rows(0)("core_revision").ToString
            InfoVersion.DB = dtVersions.Rows(0)("db_version").ToString

            sqlConn.Close()
            sqlConn.Dispose()
            sqlDA.Dispose()
            sqlCB.Dispose()

        Catch ex As Exception
            Log("MySQL Error: " + SqlHost & " - " _
            & "Error Message: " + ex.Message & " - " _
            & "Error Source: " + ex.Source & " - " _
            & "Stack Trace: " + ex.StackTrace, "ERROR")
            IAmBusy = False
        End Try

        Log("END: GetVersions", "DEBUG")
        IAmBusy = False
    End Sub
End Class
