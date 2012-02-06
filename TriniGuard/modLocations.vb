Option Strict On
Option Explicit On

Imports MySql.Data.MySqlClient

Module ModLocations

    Public Function GetMapLoc(ByVal str As String) As String
        Dim sqlConn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBCharacters1, SqlPort)
        Dim sqlQuery = "SELECT `map` FROM `characters` WHERE `name`='" & str & "'"

        Dim mapLocation As String

        'establish sql connection
        sqlConn = New MySqlConnection
        sqlConn.ConnectionString = sqlConnString
        sqlConn.Open()

        'set query
        sqlCommand.Connection = sqlConn
        sqlCommand.CommandText = sqlQuery
        sqlReader = sqlCommand.ExecuteReader

        'read data
        While sqlReader.Read
            Application.DoEvents()
        End While

        mapLocation = sqlReader(0).ToString

        sqlConn.Close()
        sqlConn.Dispose()

        Return ObjIniFile.GetString("MapLocations", mapLocation, "(none)")
    End Function

    Public Function GetZoneLoc(ByVal str As String) As String
        Dim sqlConn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim sqlReader As MySqlDataReader
        Dim sqlConnString As String = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false", SqlHost, SqlUser, SqlPass, DBCharacters1, SqlPort)
        Dim sqlQuery = "SELECT `zone` FROM `characters` WHERE `name`='" & str & "'"

        Dim zoneLocation As String

        'establish sql connection
        sqlConn = New MySqlConnection
        sqlConn.ConnectionString = sqlConnString
        sqlConn.Open()

        'set query
        sqlCommand.Connection = sqlConn
        sqlCommand.CommandText = sqlQuery
        sqlReader = sqlCommand.ExecuteReader

        'read data
        While sqlReader.Read
            Application.DoEvents()
        End While

        zoneLocation = sqlReader(0).ToString

        sqlConn.Close()
        sqlConn.Dispose()

        Return ObjIniFile.GetString("ZoneLocations", zoneLocation, "(none)")
    End Function
End Module
