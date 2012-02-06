'Option Strict On

Public Class ClsPortChecker

#Region "PRIVATE VARIABLES"
    Private cStrHost As String
    Private cIntPort As Integer
    Private cBlnBusy As Boolean
    Private cFrmMain As FrmMain
#End Region

#Region "CLASS EVENTS"
    Public Sub New(ByRef iCaller As Form, ByVal iHost As String, ByVal iPort As Integer)
        cFrmMain = iCaller
        Host = iHost
        Port = iPort
    End Sub
#End Region

#Region "PROPERTIES"
    Public Property Host()
        Get
            Host = cStrHost
        End Get
        Set(ByVal Value)
            cStrHost = Value
        End Set
    End Property
    Public Property Port()
        Get
            Port = cIntPort
        End Get
        Set(ByVal Value)
            cIntPort = Value
        End Set
    End Property
    Public ReadOnly Property Busy()
        Get
            Busy = cBlnBusy
        End Get
    End Property
#End Region

#Region "MAIN INTERFACE"
    Public Sub CheckPort()

        Do
            Dim sock As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
            cBlnBusy = True
            Log("Checking port: " & Port, "DEBUG")
            Try
                sock.Connect(Host, Port)
                If Not sock.Connected Then
                    Log(Err.Description, "DEBUG")
                    Call ReportPort(Port, False)
                Else
                    sock.Close()
                    Call ReportPort(Port, True)
                End If
            Catch
                Log(Err.Description, "DEBUG")
                Call ReportPort(Port, False)
            End Try

            sock = Nothing
            System.Threading.Thread.Sleep(IntCheckPortInterval * 1000)
        Loop
    End Sub
#End Region
End Class
