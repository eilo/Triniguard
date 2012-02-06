Option Strict On

Public Class IniFile
    ' API functions
    Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpDefault As String, _
      ByVal lpReturned As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer
    Private Declare Ansi Function WritePrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lp As String, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt _
      Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal nDefault As Integer, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As Integer, _
      ByVal lpKeyName As Integer, ByVal lpString As Integer, _
      ByVal lpFileName As String) As Integer
    Dim strFilename As String

    ' Constructor, accepting a filename
    Public Sub New(ByVal filename As String)
        strFilename = filename
    End Sub

    ' Read-only filename property
    ReadOnly Property FileName() As String
        Get
            Return strFilename
        End Get
    End Property

    Public Function GetString(ByVal section As String, _
      ByVal key As String, ByVal default1 As String) As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(section, key, _
           default1, objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then
            GetString = Left(objResult.ToString, intCharCount)
        Else
            GetString = Nothing
        End If
    End Function

    Public Function GetInteger(ByVal section As String, _
      ByVal key As String, ByVal default1 As Integer) As Integer
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(section, key, _
           default1, strFilename)
    End Function

    Public Function GetBoolean(ByVal section As String, _
      ByVal key As String, ByVal default1 As Boolean) As Boolean
        ' Returns a boolean from your INI file
        Return (GetPrivateProfileInt(section, key, _
           CInt(default1), strFilename) = 1)
    End Function

    Public Sub WriteString(ByVal section As String, _
      ByVal key As String, ByVal value As String)
        ' Writes a string to your INI file
        WritePrivateProfileString(section, key, value, strFilename)
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal section As String, _
      ByVal key As String, ByVal value As Integer)
        ' Writes an integer to your INI file
        WriteString(section, key, CStr(value))
        Flush()
    End Sub

    Public Sub WriteBoolean(ByVal section As String, _
      ByVal key As String, ByVal value As Boolean)
        ' Writes a boolean to your INI file
        WriteString(section, key, CStr(CInt(value)))
        Flush()
    End Sub

    Private Sub Flush()
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub
End Class
