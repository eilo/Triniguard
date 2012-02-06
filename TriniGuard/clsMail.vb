
'Option Strict On

Imports System.Net.Mail

Public Class ClsMail
#Region "PRIVATE VARIABLES"
    Private cStrUsername As String
    Private cStrPassword As String
    Private cStrUserDomain As String
    Private cStrMailServer As String
    Private cStrMailTo As String
    Private cStrMailFrom As String
    Private cStrMailSubject As String
    Private cStrMailBody As String
    Private cBolAuthenticate As Boolean
#End Region

#Region "PROPERTIES"
    Public Property Username()
        Get
            Username = cStrUsername
        End Get
        Set(ByVal Value)
            cStrUsername = Value
        End Set
    End Property
    Public Property Password()
        Get
            Password = cStrPassword
        End Get
        Set(ByVal Value)
            cStrPassword = Value
        End Set
    End Property
    Public Property UserDomain()
        Get
            UserDomain = cStrUserDomain
        End Get
        Set(ByVal Value)
            cStrUserDomain = Value
        End Set
    End Property
    Public Property MailServer()
        Get
            MailServer = cStrMailServer
        End Get
        Set(ByVal Value)
            cStrMailServer = Value
        End Set
    End Property
    Public Property MailTo()
        Get
            MailTo = cStrMailTo
        End Get
        Set(ByVal Value)
            cStrMailTo = Value
        End Set
    End Property
    Public Property MailFrom()
        Get
            MailFrom = cStrMailFrom
        End Get
        Set(ByVal Value)
            cStrMailFrom = Value
        End Set
    End Property
    Public Property Subject()
        Get
            Subject = cStrMailSubject
        End Get
        Set(ByVal Value)
            cStrMailSubject = Value
        End Set
    End Property
    Public Property Body()
        Get
            Body = cStrMailBody
        End Get
        Set(ByVal Value)
            cStrMailBody = Value
        End Set
    End Property
    Public Property Authenticate()
        Get
            Authenticate = cBolAuthenticate
        End Get
        Set(ByVal Value)
            cBolAuthenticate = Value
        End Set
    End Property
#End Region

    Public Sub SendMail()
        Dim message As MailMessage = New MailMessage()
        Dim smtp As New SmtpClient()
        Dim smtpUser As New System.Net.NetworkCredential()

        '-- Build Message
        message.From = New MailAddress(cStrMailFrom, "TriniGuard")
        message.To.Add(New MailAddress(cStrMailTo))
        message.IsBodyHtml = False
        message.Subject = cStrMailSubject
        message.Body = cStrMailBody

        '-- Define Authenticated User
        smtpUser.UserName = cStrUsername
        smtpUser.Password = cStrPassword
        smtpUser.Domain = cStrUserDomain

        '-- Send Message
        If cBolAuthenticate Then
            smtp.UseDefaultCredentials = False
            smtp.Credentials = smtpUser
        End If
        smtp.Host = cStrMailServer
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        Try
            smtp.Send(message)
        Catch ex As Exception
            'do nothing
        End Try
    End Sub
End Class
