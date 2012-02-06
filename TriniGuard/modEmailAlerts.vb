Option Strict On

Module ModEmailAlerts

    Public Sub SendEmail(ByVal strSubject As String, ByVal strBody As String)
        If EmailAlert Then
            Dim emailThread As System.Threading.Thread
            Dim email As New ClsMail

            email.MailTo = EmailTo
            email.MailFrom = EmailFrom
            email.MailServer = EmailServer
            email.Subject = strSubject
            email.Body = strBody
            If EmailAuthenticate Then
                email.Authenticate = True
                email.Username = EmailUsername
                email.UserDomain = EmailDomain
                email.Password = EmailPassword
            End If
            emailThread = New System.Threading.Thread(AddressOf email.SendMail)

            Call emailThread.Start()
        End If
    End Sub
End Module
