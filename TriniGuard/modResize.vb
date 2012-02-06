Module modResize
    Public Sub SetWindowSize(ByVal intRealms As Integer)
        Dim intExpand As Integer = 120

        For i = 1 To intRealms
            'main page
            FrmMain.Height = FrmMain.Height - intExpand
            FrmMain.TabControl1.Height = FrmMain.TabControl1.Height - intExpand
            FrmMain.gbBackupTimers.Top = FrmMain.gbBackupTimers.Top - intExpand
            FrmMain.gbSystemPerf.Top = FrmMain.gbSystemPerf.Top - intExpand
            FrmMain.gbToolBar.Top = FrmMain.gbToolBar.Top - intExpand
            Select Case i
                Case 1
                    FrmMain.gbCore2.Visible = False
                    FrmMain.gbCore3.Visible = False
                Case 2
                    FrmMain.gbCore2.Visible = True
                    FrmMain.gbCore3.Visible = False
                Case 3
                    FrmMain.gbCore2.Visible = True
                    FrmMain.gbCore3.Visible = True
            End Select
            FrmMain.pbTGCPU.Top = FrmMain.pbTGCPU.Top - intExpand
            FrmMain.lblTGCPU.Top = FrmMain.lblTGCPU.Top - intExpand
            FrmMain.Label35.Top = FrmMain.Label35.Top - intExpand

            'accounts page
            FrmMain.lvAccounts.Height = FrmMain.lvAccounts.Height - intExpand
            FrmMain.ListView1.Height = FrmMain.ListView1.Height - intExpand
            FrmMain.lvCharacters.Height = FrmMain.lvCharacters.Height - intExpand
            FrmMain.ListView2.Height = FrmMain.ListView2.Height - intExpand
            FrmMain.cmdAddUser.Top = FrmMain.cmdAddUser.Top - intExpand
            FrmMain.cmdDeleteUser.Top = FrmMain.cmdDeleteUser.Top - intExpand
            FrmMain.cmdBan.Top = FrmMain.cmdBan.Top - intExpand
            FrmMain.cmdExpLvl.Top = FrmMain.cmdExpLvl.Top - intExpand
            FrmMain.cmdGMLvl.Top = FrmMain.cmdGMLvl.Top - intExpand
            FrmMain.cmdReload.Top = FrmMain.cmdReload.Top - intExpand
            FrmMain.cmdKick.Top = FrmMain.cmdKick.Top - intExpand

            'IM
            FrmMain.lvIMChar.Height = FrmMain.lvIMChar.Height - intExpand
            FrmMain.ListView3.Height = FrmMain.ListView3.Height - intExpand

            intExpand = -60
        Next
    End Sub
End Module
