Option Strict On

Module ModSystemTray

    Public Sub UpdateSystemTray(ByVal indexOfIcon As Int16, ByVal notifyText As String)
        Dim objBitmap As Bitmap
        Dim objIcon As Icon
        objBitmap = New Bitmap(FrmMain.imglstIcons.Images(indexOfIcon))
        objIcon = System.Drawing.Icon.FromHandle(objBitmap.GetHicon)

        IntLastIcon = indexOfIcon

        If Not (FrmMain.niStatus.Icon Is Nothing) Then
            DestroyIcon(FrmMain.niStatus.Icon.Handle)
        End If

        FrmMain.niStatus.Icon = objIcon

        Try
            If Not notifyText = "" Then
                FrmMain.niStatus.Text = "TriniGuard" & ": " & notifyText
                FrmMain.lblStatus.Text = FrmMain.niStatus.Text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            objBitmap.Dispose()
            objBitmap = Nothing
            objIcon.Dispose()
            objIcon = Nothing
        End Try
    End Sub
End Module
