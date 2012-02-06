<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Loading...")
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Online", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Offline", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Banned", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Loading...")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Loading...")
        Me.niStatus = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.imglstIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrSaveIcon = New System.Windows.Forms.Timer(Me.components)
        Me.tmrUpdateStatus = New System.Windows.Forms.Timer(Me.components)
        Me.imglstImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrCoreCheck = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRealmCheck = New System.Windows.Forms.Timer(Me.components)
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrUpTime = New System.Windows.Forms.Timer(Me.components)
        Me.gbToolBar = New System.Windows.Forms.GroupBox()
        Me.cmdInfo = New System.Windows.Forms.Button()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.lblNumOnline = New System.Windows.Forms.Label()
        Me.btnHideTrinity = New System.Windows.Forms.Button()
        Me.btnShowTrinity = New System.Windows.Forms.Button()
        Me.cmdBackupNow = New System.Windows.Forms.Button()
        Me.btnConfigure = New System.Windows.Forms.Button()
        Me.cmdRestartTrinity = New System.Windows.Forms.Button()
        Me.cmdHide = New System.Windows.Forms.Button()
        Me.tmrBackup = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.imglstAccList = New System.Windows.Forms.ImageList(Me.components)
        Me.ilTabs = New System.Windows.Forms.ImageList(Me.components)
        Me.tabBroadcast = New System.Windows.Forms.TabPage()
        Me.cbCoreMessage = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdSaveOnlineAlerts = New System.Windows.Forms.Button()
        Me.txtModOnline = New System.Windows.Forms.TextBox()
        Me.txtGMOnline = New System.Windows.Forms.TextBox()
        Me.txtAdminOnline = New System.Windows.Forms.TextBox()
        Me.chkModOnline = New System.Windows.Forms.CheckBox()
        Me.chkGMOnline = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkAdminOnline = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAnnounce = New System.Windows.Forms.Button()
        Me.cmdNotify = New System.Windows.Forms.Button()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tabAccounts = New System.Windows.Forms.TabPage()
        Me.cmdExpLvl = New System.Windows.Forms.Button()
        Me.cmdGMLvl = New System.Windows.Forms.Button()
        Me.cmdReload = New System.Windows.Forms.Button()
        Me.cmdKick = New System.Windows.Forms.Button()
        Me.cmdDeleteUser = New System.Windows.Forms.Button()
        Me.cmdAddUser = New System.Windows.Forms.Button()
        Me.cmdBan = New System.Windows.Forms.Button()
        Me.lvCharacters = New System.Windows.Forms.ListView()
        Me.colCharacter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRealm = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAccounts = New System.Windows.Forms.ListView()
        Me.colAccounts = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tabServerStatus = New System.Windows.Forms.TabPage()
        Me.gbSystemPerf = New System.Windows.Forms.GroupBox()
        Me.pbSystemCPU = New TriniGuard3.SmoothProgressBar()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblSystemCPU = New System.Windows.Forms.Label()
        Me.pbCoreRAM = New TriniGuard3.SmoothProgressBar()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCoreRAM = New System.Windows.Forms.Label()
        Me.gbCore3 = New System.Windows.Forms.GroupBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.lblCore3Crashes = New System.Windows.Forms.Label()
        Me.pbCore3CPU = New TriniGuard3.SmoothProgressBar()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblCore3CPU = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cmdRestartCore3 = New System.Windows.Forms.Button()
        Me.lblCore3UpTime = New System.Windows.Forms.Label()
        Me.pbCore3 = New System.Windows.Forms.PictureBox()
        Me.lblCore3Title = New System.Windows.Forms.Label()
        Me.gbBackupTimers = New System.Windows.Forms.GroupBox()
        Me.lblTableBak = New System.Windows.Forms.Label()
        Me.lblCharBak = New System.Windows.Forms.Label()
        Me.lblRealmBak = New System.Windows.Forms.Label()
        Me.lblWorldBak = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblCoreRev = New System.Windows.Forms.Label()
        Me.lblBaseAuthor = New System.Windows.Forms.Label()
        Me.lblDBVer = New System.Windows.Forms.Label()
        Me.lblCoreVer = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbRealm = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblRealmCrashes = New System.Windows.Forms.Label()
        Me.pbRealmCPU = New TriniGuard3.SmoothProgressBar()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblRealmCPU = New System.Windows.Forms.Label()
        Me.cmdRestartRealm = New System.Windows.Forms.Button()
        Me.lblRealmUpTime = New System.Windows.Forms.Label()
        Me.pbRealm = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbCore1 = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblCore1Crashes = New System.Windows.Forms.Label()
        Me.pbCore1CPU = New TriniGuard3.SmoothProgressBar()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCore1CPU = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmdRestartCore1 = New System.Windows.Forms.Button()
        Me.lblCore1UpTime = New System.Windows.Forms.Label()
        Me.pbCore1 = New System.Windows.Forms.PictureBox()
        Me.lblCore1Title = New System.Windows.Forms.Label()
        Me.gbCore2 = New System.Windows.Forms.GroupBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblCore2Crashes = New System.Windows.Forms.Label()
        Me.pbCore2CPU = New TriniGuard3.SmoothProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCore2CPU = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmdRestartCore2 = New System.Windows.Forms.Button()
        Me.lblCore2UpTime = New System.Windows.Forms.Label()
        Me.pbCore2 = New System.Windows.Forms.PictureBox()
        Me.lblCore2Title = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMail = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIMMessage = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIMItems = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIMMoney = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIMSubject = New System.Windows.Forms.TextBox()
        Me.cmdMail = New System.Windows.Forms.Button()
        Me.lvIMChar = New System.Windows.Forms.ListView()
        Me.colCharacterList = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRealmList = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tabSchedules = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmdSchedRemove = New System.Windows.Forms.Button()
        Me.lstScheduleLog = New System.Windows.Forms.ListBox()
        Me.cmdSchedAdd = New System.Windows.Forms.Button()
        Me.cmdSchedSave = New System.Windows.Forms.Button()
        Me.gbSchedHourly = New System.Windows.Forms.GroupBox()
        Me.txtSchedHours = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtScheduleMessage = New System.Windows.Forms.TextBox()
        Me.cbSchedules = New System.Windows.Forms.ComboBox()
        Me.gbSchedDaily = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpSchedDailyTime = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.gbSchedFreq = New System.Windows.Forms.GroupBox()
        Me.rbSchedHourly = New System.Windows.Forms.RadioButton()
        Me.rbSchedMonthly = New System.Windows.Forms.RadioButton()
        Me.rbSchedWeekly = New System.Windows.Forms.RadioButton()
        Me.rbSchedDaily = New System.Windows.Forms.RadioButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbSchedCommand = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.gbSchedMonthly = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpSched = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpSchedMonthlyTime = New System.Windows.Forms.DateTimePicker()
        Me.gbSchedWeekly = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpSchedWeeklyTime = New System.Windows.Forms.DateTimePicker()
        Me.chkSchedSun = New System.Windows.Forms.CheckBox()
        Me.chkSchedSat = New System.Windows.Forms.CheckBox()
        Me.chkSchedFri = New System.Windows.Forms.CheckBox()
        Me.chkSchedThu = New System.Windows.Forms.CheckBox()
        Me.chkSchedWed = New System.Windows.Forms.CheckBox()
        Me.chkSchedTue = New System.Windows.Forms.CheckBox()
        Me.chkSchedMon = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmrScheduler = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPerf = New System.Windows.Forms.Timer(Me.components)
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblTGCPU = New System.Windows.Forms.Label()
        Me.pbTGCPU = New TriniGuard3.SmoothProgressBar()
        Me.ssStatus.SuspendLayout()
        Me.gbToolBar.SuspendLayout()
        Me.tabBroadcast.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tabAccounts.SuspendLayout()
        Me.tabServerStatus.SuspendLayout()
        Me.gbSystemPerf.SuspendLayout()
        Me.gbCore3.SuspendLayout()
        CType(Me.pbCore3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBackupTimers.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbRealm.SuspendLayout()
        CType(Me.pbRealm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCore1.SuspendLayout()
        CType(Me.pbCore1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCore2.SuspendLayout()
        CType(Me.pbCore2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabMail.SuspendLayout()
        Me.tabSchedules.SuspendLayout()
        Me.gbSchedHourly.SuspendLayout()
        Me.gbSchedDaily.SuspendLayout()
        Me.gbSchedFreq.SuspendLayout()
        Me.gbSchedMonthly.SuspendLayout()
        Me.gbSchedWeekly.SuspendLayout()
        Me.SuspendLayout()
        '
        'niStatus
        '
        Me.niStatus.Text = "TrinityRestarter 2.0"
        '
        'imglstIcons
        '
        Me.imglstIcons.ImageStream = CType(resources.GetObject("imglstIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstIcons.Images.SetKeyName(0, "01.png")
        Me.imglstIcons.Images.SetKeyName(1, "02.png")
        Me.imglstIcons.Images.SetKeyName(2, "save_col.ico")
        Me.imglstIcons.Images.SetKeyName(3, "save_grey.ico")
        Me.imglstIcons.Images.SetKeyName(4, "50.png")
        '
        'tmrSaveIcon
        '
        Me.tmrSaveIcon.Interval = 250
        '
        'tmrUpdateStatus
        '
        Me.tmrUpdateStatus.Interval = 1000
        '
        'imglstImages
        '
        Me.imglstImages.ImageStream = CType(resources.GetObject("imglstImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstImages.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstImages.Images.SetKeyName(0, "happy.png")
        Me.imglstImages.Images.SetKeyName(1, "sad.png")
        Me.imglstImages.Images.SetKeyName(2, "oops.png")
        Me.imglstImages.Images.SetKeyName(3, "no.png")
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.ssStatus.Location = New System.Drawing.Point(0, 543)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(536, 22)
        Me.ssStatus.SizingGrip = False
        Me.ssStatus.TabIndex = 11
        Me.ssStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 17)
        Me.lblStatus.Text = "Status:"
        '
        'tmrUpTime
        '
        Me.tmrUpTime.Interval = 1000
        '
        'gbToolBar
        '
        Me.gbToolBar.Controls.Add(Me.cmdInfo)
        Me.gbToolBar.Controls.Add(Me.lblDebug)
        Me.gbToolBar.Controls.Add(Me.lblNumOnline)
        Me.gbToolBar.Controls.Add(Me.btnHideTrinity)
        Me.gbToolBar.Controls.Add(Me.btnShowTrinity)
        Me.gbToolBar.Controls.Add(Me.cmdBackupNow)
        Me.gbToolBar.Controls.Add(Me.btnConfigure)
        Me.gbToolBar.Controls.Add(Me.cmdRestartTrinity)
        Me.gbToolBar.Controls.Add(Me.cmdHide)
        Me.gbToolBar.Location = New System.Drawing.Point(6, 488)
        Me.gbToolBar.Name = "gbToolBar"
        Me.gbToolBar.Size = New System.Drawing.Size(523, 48)
        Me.gbToolBar.TabIndex = 28
        Me.gbToolBar.TabStop = False
        '
        'cmdInfo
        '
        Me.cmdInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdInfo.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdInfo.Image = CType(resources.GetObject("cmdInfo.Image"), System.Drawing.Image)
        Me.cmdInfo.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.cmdInfo.Location = New System.Drawing.Point(488, 12)
        Me.cmdInfo.Name = "cmdInfo"
        Me.cmdInfo.Size = New System.Drawing.Size(28, 28)
        Me.cmdInfo.TabIndex = 40
        Me.cmdInfo.UseVisualStyleBackColor = True
        '
        'lblDebug
        '
        Me.lblDebug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebug.Location = New System.Drawing.Point(183, 19)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(122, 13)
        Me.lblDebug.TabIndex = 39
        '
        'lblNumOnline
        '
        Me.lblNumOnline.Location = New System.Drawing.Point(335, 20)
        Me.lblNumOnline.Name = "lblNumOnline"
        Me.lblNumOnline.Size = New System.Drawing.Size(113, 13)
        Me.lblNumOnline.TabIndex = 37
        Me.lblNumOnline.Text = "-"
        Me.lblNumOnline.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnHideTrinity
        '
        Me.btnHideTrinity.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnHideTrinity.Image = CType(resources.GetObject("btnHideTrinity.Image"), System.Drawing.Image)
        Me.btnHideTrinity.Location = New System.Drawing.Point(108, 12)
        Me.btnHideTrinity.Name = "btnHideTrinity"
        Me.btnHideTrinity.Size = New System.Drawing.Size(28, 28)
        Me.btnHideTrinity.TabIndex = 8
        Me.btnHideTrinity.UseVisualStyleBackColor = True
        '
        'btnShowTrinity
        '
        Me.btnShowTrinity.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnShowTrinity.Image = CType(resources.GetObject("btnShowTrinity.Image"), System.Drawing.Image)
        Me.btnShowTrinity.Location = New System.Drawing.Point(74, 12)
        Me.btnShowTrinity.Name = "btnShowTrinity"
        Me.btnShowTrinity.Size = New System.Drawing.Size(28, 28)
        Me.btnShowTrinity.TabIndex = 7
        Me.btnShowTrinity.UseVisualStyleBackColor = True
        '
        'cmdBackupNow
        '
        Me.cmdBackupNow.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdBackupNow.Image = CType(resources.GetObject("cmdBackupNow.Image"), System.Drawing.Image)
        Me.cmdBackupNow.Location = New System.Drawing.Point(6, 12)
        Me.cmdBackupNow.Name = "cmdBackupNow"
        Me.cmdBackupNow.Size = New System.Drawing.Size(28, 28)
        Me.cmdBackupNow.TabIndex = 5
        Me.cmdBackupNow.UseVisualStyleBackColor = True
        '
        'btnConfigure
        '
        Me.btnConfigure.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnConfigure.Image = CType(resources.GetObject("btnConfigure.Image"), System.Drawing.Image)
        Me.btnConfigure.Location = New System.Drawing.Point(40, 12)
        Me.btnConfigure.Name = "btnConfigure"
        Me.btnConfigure.Size = New System.Drawing.Size(28, 28)
        Me.btnConfigure.TabIndex = 6
        Me.btnConfigure.UseVisualStyleBackColor = True
        '
        'cmdRestartTrinity
        '
        Me.cmdRestartTrinity.Image = CType(resources.GetObject("cmdRestartTrinity.Image"), System.Drawing.Image)
        Me.cmdRestartTrinity.Location = New System.Drawing.Point(148, 13)
        Me.cmdRestartTrinity.Name = "cmdRestartTrinity"
        Me.cmdRestartTrinity.Size = New System.Drawing.Size(29, 27)
        Me.cmdRestartTrinity.TabIndex = 9
        Me.cmdRestartTrinity.UseVisualStyleBackColor = True
        '
        'cmdHide
        '
        Me.cmdHide.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdHide.Image = CType(resources.GetObject("cmdHide.Image"), System.Drawing.Image)
        Me.cmdHide.Location = New System.Drawing.Point(454, 12)
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Size = New System.Drawing.Size(28, 28)
        Me.cmdHide.TabIndex = 10
        Me.cmdHide.UseVisualStyleBackColor = True
        '
        'tmrBackup
        '
        Me.tmrBackup.Interval = 1000
        '
        'imglstAccList
        '
        Me.imglstAccList.ImageStream = CType(resources.GetObject("imglstAccList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstAccList.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstAccList.Images.SetKeyName(0, "user_grey.gif")
        Me.imglstAccList.Images.SetKeyName(1, "user_col.gif")
        Me.imglstAccList.Images.SetKeyName(2, "13.png")
        Me.imglstAccList.Images.SetKeyName(3, "14.png")
        Me.imglstAccList.Images.SetKeyName(4, "03.png")
        Me.imglstAccList.Images.SetKeyName(5, "51.png")
        Me.imglstAccList.Images.SetKeyName(6, "01.png")
        Me.imglstAccList.Images.SetKeyName(7, "disconnect_co_16x16.gif")
        Me.imglstAccList.Images.SetKeyName(8, "25.png")
        '
        'ilTabs
        '
        Me.ilTabs.ImageStream = CType(resources.GetObject("ilTabs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTabs.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTabs.Images.SetKeyName(0, "utilities_system_monitor.png")
        Me.ilTabs.Images.SetKeyName(1, "Login Manager.png")
        Me.ilTabs.Images.SetKeyName(2, "email.png")
        Me.ilTabs.Images.SetKeyName(3, "konv_message2.png")
        Me.ilTabs.Images.SetKeyName(4, "date.png")
        '
        'tabBroadcast
        '
        Me.tabBroadcast.Controls.Add(Me.cbCoreMessage)
        Me.tabBroadcast.Controls.Add(Me.GroupBox3)
        Me.tabBroadcast.Controls.Add(Me.Label3)
        Me.tabBroadcast.Controls.Add(Me.cmdAnnounce)
        Me.tabBroadcast.Controls.Add(Me.cmdNotify)
        Me.tabBroadcast.Controls.Add(Me.txtSend)
        Me.tabBroadcast.Controls.Add(Me.Panel2)
        Me.tabBroadcast.ImageIndex = 3
        Me.tabBroadcast.Location = New System.Drawing.Point(4, 39)
        Me.tabBroadcast.Name = "tabBroadcast"
        Me.tabBroadcast.Size = New System.Drawing.Size(515, 435)
        Me.tabBroadcast.TabIndex = 3
        Me.tabBroadcast.Text = "Broadcast"
        Me.tabBroadcast.UseVisualStyleBackColor = True
        '
        'cbCoreMessage
        '
        Me.cbCoreMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCoreMessage.FormattingEnabled = True
        Me.cbCoreMessage.Items.AddRange(New Object() {"Core 1", "Core 2", "Core 3", "All Cores"})
        Me.cbCoreMessage.Location = New System.Drawing.Point(251, 83)
        Me.cbCoreMessage.Name = "cbCoreMessage"
        Me.cbCoreMessage.Size = New System.Drawing.Size(96, 21)
        Me.cbCoreMessage.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdSaveOnlineAlerts)
        Me.GroupBox3.Controls.Add(Me.txtModOnline)
        Me.GroupBox3.Controls.Add(Me.txtGMOnline)
        Me.GroupBox3.Controls.Add(Me.txtAdminOnline)
        Me.GroupBox3.Controls.Add(Me.chkModOnline)
        Me.GroupBox3.Controls.Add(Me.chkGMOnline)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.chkAdminOnline)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 116)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(506, 142)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GM Online Alerts"
        '
        'cmdSaveOnlineAlerts
        '
        Me.cmdSaveOnlineAlerts.Enabled = False
        Me.cmdSaveOnlineAlerts.Location = New System.Drawing.Point(425, 111)
        Me.cmdSaveOnlineAlerts.Name = "cmdSaveOnlineAlerts"
        Me.cmdSaveOnlineAlerts.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveOnlineAlerts.TabIndex = 10
        Me.cmdSaveOnlineAlerts.Text = "Save"
        Me.cmdSaveOnlineAlerts.UseVisualStyleBackColor = True
        '
        'txtModOnline
        '
        Me.txtModOnline.Location = New System.Drawing.Point(116, 85)
        Me.txtModOnline.Name = "txtModOnline"
        Me.txtModOnline.Size = New System.Drawing.Size(384, 20)
        Me.txtModOnline.TabIndex = 9
        '
        'txtGMOnline
        '
        Me.txtGMOnline.Location = New System.Drawing.Point(116, 60)
        Me.txtGMOnline.Name = "txtGMOnline"
        Me.txtGMOnline.Size = New System.Drawing.Size(385, 20)
        Me.txtGMOnline.TabIndex = 7
        '
        'txtAdminOnline
        '
        Me.txtAdminOnline.Location = New System.Drawing.Point(116, 34)
        Me.txtAdminOnline.Name = "txtAdminOnline"
        Me.txtAdminOnline.Size = New System.Drawing.Size(384, 20)
        Me.txtAdminOnline.TabIndex = 5
        '
        'chkModOnline
        '
        Me.chkModOnline.AutoSize = True
        Me.chkModOnline.Location = New System.Drawing.Point(21, 87)
        Me.chkModOnline.Name = "chkModOnline"
        Me.chkModOnline.Size = New System.Drawing.Size(74, 17)
        Me.chkModOnline.TabIndex = 8
        Me.chkModOnline.Text = "Moderator"
        Me.chkModOnline.UseVisualStyleBackColor = True
        '
        'chkGMOnline
        '
        Me.chkGMOnline.AutoSize = True
        Me.chkGMOnline.Location = New System.Drawing.Point(21, 62)
        Me.chkGMOnline.Name = "chkGMOnline"
        Me.chkGMOnline.Size = New System.Drawing.Size(89, 17)
        Me.chkGMOnline.TabIndex = 6
        Me.chkGMOnline.Text = "Game Master"
        Me.chkGMOnline.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Announce when online:"
        '
        'chkAdminOnline
        '
        Me.chkAdminOnline.AutoSize = True
        Me.chkAdminOnline.Location = New System.Drawing.Point(21, 36)
        Me.chkAdminOnline.Name = "chkAdminOnline"
        Me.chkAdminOnline.Size = New System.Drawing.Size(86, 17)
        Me.chkAdminOnline.TabIndex = 4
        Me.chkAdminOnline.Text = "Administrator"
        Me.chkAdminOnline.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Message to send:"
        '
        'cmdAnnounce
        '
        Me.cmdAnnounce.Enabled = False
        Me.cmdAnnounce.Location = New System.Drawing.Point(353, 81)
        Me.cmdAnnounce.Name = "cmdAnnounce"
        Me.cmdAnnounce.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnnounce.TabIndex = 2
        Me.cmdAnnounce.Text = "Announce"
        Me.cmdAnnounce.UseVisualStyleBackColor = True
        '
        'cmdNotify
        '
        Me.cmdNotify.Enabled = False
        Me.cmdNotify.Location = New System.Drawing.Point(434, 81)
        Me.cmdNotify.Name = "cmdNotify"
        Me.cmdNotify.Size = New System.Drawing.Size(75, 23)
        Me.cmdNotify.TabIndex = 3
        Me.cmdNotify.Text = "Notify"
        Me.cmdNotify.UseVisualStyleBackColor = True
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(3, 21)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(506, 54)
        Me.txtSend.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Green
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(509, 307)
        Me.Panel2.TabIndex = 52
        Me.Panel2.Visible = False
        '
        'tabAccounts
        '
        Me.tabAccounts.Controls.Add(Me.cmdExpLvl)
        Me.tabAccounts.Controls.Add(Me.cmdGMLvl)
        Me.tabAccounts.Controls.Add(Me.cmdReload)
        Me.tabAccounts.Controls.Add(Me.cmdKick)
        Me.tabAccounts.Controls.Add(Me.cmdDeleteUser)
        Me.tabAccounts.Controls.Add(Me.cmdAddUser)
        Me.tabAccounts.Controls.Add(Me.cmdBan)
        Me.tabAccounts.Controls.Add(Me.lvCharacters)
        Me.tabAccounts.Controls.Add(Me.ListView2)
        Me.tabAccounts.Controls.Add(Me.lvAccounts)
        Me.tabAccounts.Controls.Add(Me.ListView1)
        Me.tabAccounts.Controls.Add(Me.Panel4)
        Me.tabAccounts.ImageIndex = 1
        Me.tabAccounts.Location = New System.Drawing.Point(4, 39)
        Me.tabAccounts.Name = "tabAccounts"
        Me.tabAccounts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAccounts.Size = New System.Drawing.Size(515, 435)
        Me.tabAccounts.TabIndex = 1
        Me.tabAccounts.Text = "Accounts"
        Me.tabAccounts.UseVisualStyleBackColor = True
        '
        'cmdExpLvl
        '
        Me.cmdExpLvl.Enabled = False
        Me.cmdExpLvl.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExpLvl.ImageList = Me.imglstAccList
        Me.cmdExpLvl.Location = New System.Drawing.Point(156, 401)
        Me.cmdExpLvl.Name = "cmdExpLvl"
        Me.cmdExpLvl.Size = New System.Drawing.Size(28, 28)
        Me.cmdExpLvl.TabIndex = 6
        Me.cmdExpLvl.Text = "EX"
        Me.cmdExpLvl.UseVisualStyleBackColor = True
        '
        'cmdGMLvl
        '
        Me.cmdGMLvl.Enabled = False
        Me.cmdGMLvl.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGMLvl.ImageList = Me.imglstAccList
        Me.cmdGMLvl.Location = New System.Drawing.Point(122, 401)
        Me.cmdGMLvl.Name = "cmdGMLvl"
        Me.cmdGMLvl.Size = New System.Drawing.Size(28, 28)
        Me.cmdGMLvl.TabIndex = 5
        Me.cmdGMLvl.Text = "GM"
        Me.cmdGMLvl.UseVisualStyleBackColor = True
        '
        'cmdReload
        '
        Me.cmdReload.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdReload.ImageIndex = 8
        Me.cmdReload.ImageList = Me.imglstAccList
        Me.cmdReload.Location = New System.Drawing.Point(221, 401)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(28, 28)
        Me.cmdReload.TabIndex = 7
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'cmdKick
        '
        Me.cmdKick.Enabled = False
        Me.cmdKick.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdKick.ImageIndex = 7
        Me.cmdKick.ImageList = Me.imglstAccList
        Me.cmdKick.Location = New System.Drawing.Point(470, 401)
        Me.cmdKick.Name = "cmdKick"
        Me.cmdKick.Size = New System.Drawing.Size(28, 28)
        Me.cmdKick.TabIndex = 9
        Me.cmdKick.UseVisualStyleBackColor = True
        '
        'cmdDeleteUser
        '
        Me.cmdDeleteUser.Enabled = False
        Me.cmdDeleteUser.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdDeleteUser.ImageIndex = 5
        Me.cmdDeleteUser.ImageList = Me.imglstAccList
        Me.cmdDeleteUser.Location = New System.Drawing.Point(38, 401)
        Me.cmdDeleteUser.Name = "cmdDeleteUser"
        Me.cmdDeleteUser.Size = New System.Drawing.Size(28, 28)
        Me.cmdDeleteUser.TabIndex = 3
        Me.cmdDeleteUser.UseVisualStyleBackColor = True
        '
        'cmdAddUser
        '
        Me.cmdAddUser.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdAddUser.ImageIndex = 4
        Me.cmdAddUser.ImageList = Me.imglstAccList
        Me.cmdAddUser.Location = New System.Drawing.Point(4, 401)
        Me.cmdAddUser.Name = "cmdAddUser"
        Me.cmdAddUser.Size = New System.Drawing.Size(28, 28)
        Me.cmdAddUser.TabIndex = 2
        Me.cmdAddUser.UseVisualStyleBackColor = True
        '
        'cmdBan
        '
        Me.cmdBan.Enabled = False
        Me.cmdBan.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdBan.ImageIndex = 2
        Me.cmdBan.ImageList = Me.imglstAccList
        Me.cmdBan.Location = New System.Drawing.Point(80, 401)
        Me.cmdBan.Name = "cmdBan"
        Me.cmdBan.Size = New System.Drawing.Size(28, 28)
        Me.cmdBan.TabIndex = 4
        Me.cmdBan.UseVisualStyleBackColor = True
        '
        'lvCharacters
        '
        Me.lvCharacters.AutoArrange = False
        Me.lvCharacters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCharacters.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCharacter, Me.colRealm})
        Me.lvCharacters.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCharacters.FullRowSelect = True
        Me.lvCharacters.LabelWrap = False
        Me.lvCharacters.LargeImageList = Me.imglstAccList
        Me.lvCharacters.Location = New System.Drawing.Point(264, 6)
        Me.lvCharacters.MultiSelect = False
        Me.lvCharacters.Name = "lvCharacters"
        Me.lvCharacters.ShowItemToolTips = True
        Me.lvCharacters.Size = New System.Drawing.Size(245, 389)
        Me.lvCharacters.SmallImageList = Me.imglstAccList
        Me.lvCharacters.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCharacters.TabIndex = 8
        Me.lvCharacters.UseCompatibleStateImageBehavior = False
        Me.lvCharacters.View = System.Windows.Forms.View.Details
        '
        'colCharacter
        '
        Me.colCharacter.Text = "Character"
        Me.colCharacter.Width = 153
        '
        'colRealm
        '
        Me.colRealm.Text = "Realm"
        Me.colRealm.Width = 90
        '
        'ListView2
        '
        Me.ListView2.AutoArrange = False
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.ListView2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView2.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListView2.LabelWrap = False
        Me.ListView2.LargeImageList = Me.imglstAccList
        Me.ListView2.Location = New System.Drawing.Point(264, 6)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(245, 217)
        Me.ListView2.SmallImageList = Me.imglstAccList
        Me.ListView2.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView2.TabIndex = 41
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Characters"
        Me.ColumnHeader5.Width = 220
        '
        'lvAccounts
        '
        Me.lvAccounts.AutoArrange = False
        Me.lvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAccounts})
        Me.lvAccounts.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAccounts.FullRowSelect = True
        ListViewGroup1.Header = "Online"
        ListViewGroup1.Name = "Online"
        ListViewGroup2.Header = "Offline"
        ListViewGroup2.Name = "Offline"
        ListViewGroup3.Header = "Banned"
        ListViewGroup3.Name = "Banned"
        Me.lvAccounts.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lvAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvAccounts.LabelWrap = False
        Me.lvAccounts.LargeImageList = Me.imglstAccList
        Me.lvAccounts.Location = New System.Drawing.Point(3, 6)
        Me.lvAccounts.MultiSelect = False
        Me.lvAccounts.Name = "lvAccounts"
        Me.lvAccounts.ShowItemToolTips = True
        Me.lvAccounts.Size = New System.Drawing.Size(245, 389)
        Me.lvAccounts.SmallImageList = Me.imglstAccList
        Me.lvAccounts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvAccounts.TabIndex = 1
        Me.lvAccounts.UseCompatibleStateImageBehavior = False
        Me.lvAccounts.View = System.Windows.Forms.View.Details
        Me.lvAccounts.Visible = False
        '
        'colAccounts
        '
        Me.colAccounts.Text = "Accounts"
        Me.colAccounts.Width = 220
        '
        'ListView1
        '
        Me.ListView1.AutoArrange = False
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.ListView1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.ListView1.LabelWrap = False
        Me.ListView1.LargeImageList = Me.imglstAccList
        Me.ListView1.Location = New System.Drawing.Point(3, 6)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(245, 389)
        Me.ListView1.SmallImageList = Me.imglstAccList
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 40
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Accounts"
        Me.ColumnHeader4.Width = 220
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Green
        Me.Panel4.Location = New System.Drawing.Point(3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(509, 307)
        Me.Panel4.TabIndex = 52
        Me.Panel4.Visible = False
        '
        'tabServerStatus
        '
        Me.tabServerStatus.Controls.Add(Me.gbSystemPerf)
        Me.tabServerStatus.Controls.Add(Me.gbCore3)
        Me.tabServerStatus.Controls.Add(Me.gbBackupTimers)
        Me.tabServerStatus.Controls.Add(Me.GroupBox2)
        Me.tabServerStatus.Controls.Add(Me.gbRealm)
        Me.tabServerStatus.Controls.Add(Me.gbCore1)
        Me.tabServerStatus.Controls.Add(Me.gbCore2)
        Me.tabServerStatus.Controls.Add(Me.Panel5)
        Me.tabServerStatus.ImageIndex = 0
        Me.tabServerStatus.Location = New System.Drawing.Point(4, 39)
        Me.tabServerStatus.Name = "tabServerStatus"
        Me.tabServerStatus.Size = New System.Drawing.Size(515, 435)
        Me.tabServerStatus.TabIndex = 2
        Me.tabServerStatus.Text = "Server Status"
        Me.tabServerStatus.UseVisualStyleBackColor = True
        '
        'gbSystemPerf
        '
        Me.gbSystemPerf.Controls.Add(Me.pbSystemCPU)
        Me.gbSystemPerf.Controls.Add(Me.Label17)
        Me.gbSystemPerf.Controls.Add(Me.lblSystemCPU)
        Me.gbSystemPerf.Controls.Add(Me.pbCoreRAM)
        Me.gbSystemPerf.Controls.Add(Me.Label13)
        Me.gbSystemPerf.Controls.Add(Me.lblCoreRAM)
        Me.gbSystemPerf.Location = New System.Drawing.Point(10, 339)
        Me.gbSystemPerf.Name = "gbSystemPerf"
        Me.gbSystemPerf.Size = New System.Drawing.Size(186, 93)
        Me.gbSystemPerf.TabIndex = 37
        Me.gbSystemPerf.TabStop = False
        Me.gbSystemPerf.Text = "System Performance"
        '
        'pbSystemCPU
        '
        Me.pbSystemCPU.BackColor1 = System.Drawing.Color.Black
        Me.pbSystemCPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbSystemCPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbSystemCPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbSystemCPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbSystemCPU.BarColor1 = System.Drawing.Color.Green
        Me.pbSystemCPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbSystemCPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbSystemCPU.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbSystemCPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbSystemCPU.Location = New System.Drawing.Point(85, 19)
        Me.pbSystemCPU.Name = "pbSystemCPU"
        Me.pbSystemCPU.Size = New System.Drawing.Size(85, 14)
        Me.pbSystemCPU.TabIndex = 65
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 12)
        Me.Label17.TabIndex = 67
        Me.Label17.Text = "SYSTEM CPU:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSystemCPU
        '
        Me.lblSystemCPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemCPU.Location = New System.Drawing.Point(84, 32)
        Me.lblSystemCPU.Name = "lblSystemCPU"
        Me.lblSystemCPU.Size = New System.Drawing.Size(86, 12)
        Me.lblSystemCPU.TabIndex = 66
        Me.lblSystemCPU.Text = "-"
        Me.lblSystemCPU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbCoreRAM
        '
        Me.pbCoreRAM.BackColor1 = System.Drawing.Color.Black
        Me.pbCoreRAM.BackColor2 = System.Drawing.Color.Gray
        Me.pbCoreRAM.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCoreRAM.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCoreRAM.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCoreRAM.BarColor1 = System.Drawing.Color.Navy
        Me.pbCoreRAM.BarColor2 = System.Drawing.Color.CornflowerBlue
        Me.pbCoreRAM.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCoreRAM.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCoreRAM.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCoreRAM.Location = New System.Drawing.Point(86, 55)
        Me.pbCoreRAM.Name = "pbCoreRAM"
        Me.pbCoreRAM.Size = New System.Drawing.Size(85, 14)
        Me.pbCoreRAM.TabIndex = 57
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 12)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "SYSTEM RAM:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoreRAM
        '
        Me.lblCoreRAM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoreRAM.Location = New System.Drawing.Point(84, 68)
        Me.lblCoreRAM.Name = "lblCoreRAM"
        Me.lblCoreRAM.Size = New System.Drawing.Size(86, 12)
        Me.lblCoreRAM.TabIndex = 60
        Me.lblCoreRAM.Text = "-"
        Me.lblCoreRAM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbCore3
        '
        Me.gbCore3.Controls.Add(Me.Label44)
        Me.gbCore3.Controls.Add(Me.lblCore3Crashes)
        Me.gbCore3.Controls.Add(Me.pbCore3CPU)
        Me.gbCore3.Controls.Add(Me.Label36)
        Me.gbCore3.Controls.Add(Me.lblCore3CPU)
        Me.gbCore3.Controls.Add(Me.Label37)
        Me.gbCore3.Controls.Add(Me.cmdRestartCore3)
        Me.gbCore3.Controls.Add(Me.lblCore3UpTime)
        Me.gbCore3.Controls.Add(Me.pbCore3)
        Me.gbCore3.Controls.Add(Me.lblCore3Title)
        Me.gbCore3.Location = New System.Drawing.Point(10, 276)
        Me.gbCore3.Name = "gbCore3"
        Me.gbCore3.Size = New System.Drawing.Size(499, 59)
        Me.gbCore3.TabIndex = 4
        Me.gbCore3.TabStop = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(47, 41)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(47, 12)
        Me.Label44.TabIndex = 77
        Me.Label44.Text = "Crashes:"
        '
        'lblCore3Crashes
        '
        Me.lblCore3Crashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore3Crashes.Location = New System.Drawing.Point(95, 41)
        Me.lblCore3Crashes.Name = "lblCore3Crashes"
        Me.lblCore3Crashes.Size = New System.Drawing.Size(269, 13)
        Me.lblCore3Crashes.TabIndex = 76
        Me.lblCore3Crashes.Text = "Not available"
        '
        'pbCore3CPU
        '
        Me.pbCore3CPU.BackColor1 = System.Drawing.Color.Black
        Me.pbCore3CPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbCore3CPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore3CPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore3CPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore3CPU.BarColor1 = System.Drawing.Color.Green
        Me.pbCore3CPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbCore3CPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore3CPU.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore3CPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore3CPU.Location = New System.Drawing.Point(388, 25)
        Me.pbCore3CPU.Name = "pbCore3CPU"
        Me.pbCore3CPU.Size = New System.Drawing.Size(61, 14)
        Me.pbCore3CPU.TabIndex = 73
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(388, 11)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(63, 12)
        Me.Label36.TabIndex = 75
        Me.Label36.Text = "CORE CPU"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCore3CPU
        '
        Me.lblCore3CPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore3CPU.Location = New System.Drawing.Point(388, 39)
        Me.lblCore3CPU.Name = "lblCore3CPU"
        Me.lblCore3CPU.Size = New System.Drawing.Size(63, 15)
        Me.lblCore3CPU.TabIndex = 74
        Me.lblCore3CPU.Text = "-"
        Me.lblCore3CPU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(47, 27)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(45, 12)
        Me.Label37.TabIndex = 69
        Me.Label37.Text = "Uptime:"
        '
        'cmdRestartCore3
        '
        Me.cmdRestartCore3.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdRestartCore3.Image = CType(resources.GetObject("cmdRestartCore3.Image"), System.Drawing.Image)
        Me.cmdRestartCore3.Location = New System.Drawing.Point(460, 18)
        Me.cmdRestartCore3.Name = "cmdRestartCore3"
        Me.cmdRestartCore3.Size = New System.Drawing.Size(28, 28)
        Me.cmdRestartCore3.TabIndex = 4
        Me.cmdRestartCore3.UseVisualStyleBackColor = True
        '
        'lblCore3UpTime
        '
        Me.lblCore3UpTime.AutoSize = True
        Me.lblCore3UpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore3UpTime.Location = New System.Drawing.Point(95, 27)
        Me.lblCore3UpTime.Name = "lblCore3UpTime"
        Me.lblCore3UpTime.Size = New System.Drawing.Size(59, 12)
        Me.lblCore3UpTime.TabIndex = 26
        Me.lblCore3UpTime.Text = "Not available"
        '
        'pbCore3
        '
        Me.pbCore3.InitialImage = Nothing
        Me.pbCore3.Location = New System.Drawing.Point(6, 16)
        Me.pbCore3.Name = "pbCore3"
        Me.pbCore3.Size = New System.Drawing.Size(32, 32)
        Me.pbCore3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCore3.TabIndex = 25
        Me.pbCore3.TabStop = False
        '
        'lblCore3Title
        '
        Me.lblCore3Title.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore3Title.Location = New System.Drawing.Point(44, 9)
        Me.lblCore3Title.Name = "lblCore3Title"
        Me.lblCore3Title.Size = New System.Drawing.Size(299, 14)
        Me.lblCore3Title.TabIndex = 24
        Me.lblCore3Title.Text = "Core: Realm 3"
        '
        'gbBackupTimers
        '
        Me.gbBackupTimers.Controls.Add(Me.lblTableBak)
        Me.gbBackupTimers.Controls.Add(Me.lblCharBak)
        Me.gbBackupTimers.Controls.Add(Me.lblRealmBak)
        Me.gbBackupTimers.Controls.Add(Me.lblWorldBak)
        Me.gbBackupTimers.Controls.Add(Me.Label31)
        Me.gbBackupTimers.Controls.Add(Me.Label30)
        Me.gbBackupTimers.Controls.Add(Me.Label29)
        Me.gbBackupTimers.Controls.Add(Me.Label28)
        Me.gbBackupTimers.Location = New System.Drawing.Point(204, 339)
        Me.gbBackupTimers.Name = "gbBackupTimers"
        Me.gbBackupTimers.Size = New System.Drawing.Size(305, 93)
        Me.gbBackupTimers.TabIndex = 38
        Me.gbBackupTimers.TabStop = False
        Me.gbBackupTimers.Text = "Backup Timers"
        '
        'lblTableBak
        '
        Me.lblTableBak.AutoSize = True
        Me.lblTableBak.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableBak.Location = New System.Drawing.Point(68, 73)
        Me.lblTableBak.Name = "lblTableBak"
        Me.lblTableBak.Size = New System.Drawing.Size(62, 12)
        Me.lblTableBak.TabIndex = 7
        Me.lblTableBak.Text = "Please wait..."
        '
        'lblCharBak
        '
        Me.lblCharBak.AutoSize = True
        Me.lblCharBak.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharBak.Location = New System.Drawing.Point(68, 55)
        Me.lblCharBak.Name = "lblCharBak"
        Me.lblCharBak.Size = New System.Drawing.Size(62, 12)
        Me.lblCharBak.TabIndex = 6
        Me.lblCharBak.Text = "Please wait..."
        '
        'lblRealmBak
        '
        Me.lblRealmBak.AutoSize = True
        Me.lblRealmBak.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealmBak.Location = New System.Drawing.Point(68, 37)
        Me.lblRealmBak.Name = "lblRealmBak"
        Me.lblRealmBak.Size = New System.Drawing.Size(62, 12)
        Me.lblRealmBak.TabIndex = 5
        Me.lblRealmBak.Text = "Please wait..."
        '
        'lblWorldBak
        '
        Me.lblWorldBak.AutoSize = True
        Me.lblWorldBak.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorldBak.Location = New System.Drawing.Point(68, 19)
        Me.lblWorldBak.Name = "lblWorldBak"
        Me.lblWorldBak.Size = New System.Drawing.Size(62, 12)
        Me.lblWorldBak.TabIndex = 4
        Me.lblWorldBak.Text = "Please wait..."
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(12, 73)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 12)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "TABLES:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(12, 55)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(50, 12)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "CHAR:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(12, 37)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(50, 12)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "REALM:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(12, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 12)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "WORLD:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.lblCoreRev)
        Me.GroupBox2.Controls.Add(Me.lblBaseAuthor)
        Me.GroupBox2.Controls.Add(Me.lblDBVer)
        Me.GroupBox2.Controls.Add(Me.lblCoreVer)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(499, 96)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Server Versions"
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Label39.Location = New System.Drawing.Point(321, 73)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(174, 13)
        Me.Label39.TabIndex = 47
        Me.Label39.Text = "Eilo (eilo2518@gmail.com)"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(245, 72)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(70, 15)
        Me.Label41.TabIndex = 46
        Me.Label41.Text = "Actual por:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCoreRev
        '
        Me.lblCoreRev.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCoreRev.Location = New System.Drawing.Point(82, 39)
        Me.lblCoreRev.Name = "lblCoreRev"
        Me.lblCoreRev.Size = New System.Drawing.Size(411, 13)
        Me.lblCoreRev.TabIndex = 45
        Me.lblCoreRev.Text = "0"
        Me.lblCoreRev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBaseAuthor
        '
        Me.lblBaseAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblBaseAuthor.Location = New System.Drawing.Point(82, 73)
        Me.lblBaseAuthor.Name = "lblBaseAuthor"
        Me.lblBaseAuthor.Size = New System.Drawing.Size(174, 13)
        Me.lblBaseAuthor.TabIndex = 43
        Me.lblBaseAuthor.Text = "Mikec1981 (MCarter1981@gmail.com)"
        Me.lblBaseAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDBVer
        '
        Me.lblDBVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblDBVer.Location = New System.Drawing.Point(82, 56)
        Me.lblDBVer.Name = "lblDBVer"
        Me.lblDBVer.Size = New System.Drawing.Size(411, 13)
        Me.lblDBVer.TabIndex = 41
        Me.lblDBVer.Text = "0"
        Me.lblDBVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCoreVer
        '
        Me.lblCoreVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCoreVer.Location = New System.Drawing.Point(82, 22)
        Me.lblCoreVer.Name = "lblCoreVer"
        Me.lblCoreVer.Size = New System.Drawing.Size(411, 13)
        Me.lblCoreVer.TabIndex = 37
        Me.lblCoreVer.Text = "0"
        Me.lblCoreVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(6, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 15)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Core Rev:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(6, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 15)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "DB Ver:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(6, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Core Ver:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(6, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 15)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Base por:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbRealm
        '
        Me.gbRealm.Controls.Add(Me.Label38)
        Me.gbRealm.Controls.Add(Me.lblRealmCrashes)
        Me.gbRealm.Controls.Add(Me.pbRealmCPU)
        Me.gbRealm.Controls.Add(Me.Label15)
        Me.gbRealm.Controls.Add(Me.Label32)
        Me.gbRealm.Controls.Add(Me.lblRealmCPU)
        Me.gbRealm.Controls.Add(Me.cmdRestartRealm)
        Me.gbRealm.Controls.Add(Me.lblRealmUpTime)
        Me.gbRealm.Controls.Add(Me.pbRealm)
        Me.gbRealm.Controls.Add(Me.Label2)
        Me.gbRealm.Location = New System.Drawing.Point(10, 99)
        Me.gbRealm.Name = "gbRealm"
        Me.gbRealm.Size = New System.Drawing.Size(499, 59)
        Me.gbRealm.TabIndex = 1
        Me.gbRealm.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(47, 41)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(47, 12)
        Me.Label38.TabIndex = 75
        Me.Label38.Text = "Crashes:"
        '
        'lblRealmCrashes
        '
        Me.lblRealmCrashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblRealmCrashes.Location = New System.Drawing.Point(95, 41)
        Me.lblRealmCrashes.Name = "lblRealmCrashes"
        Me.lblRealmCrashes.Size = New System.Drawing.Size(269, 13)
        Me.lblRealmCrashes.TabIndex = 74
        Me.lblRealmCrashes.Text = "Not available"
        '
        'pbRealmCPU
        '
        Me.pbRealmCPU.BackColor1 = System.Drawing.Color.Black
        Me.pbRealmCPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbRealmCPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbRealmCPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbRealmCPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbRealmCPU.BarColor1 = System.Drawing.Color.Green
        Me.pbRealmCPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbRealmCPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbRealmCPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbRealmCPU.Location = New System.Drawing.Point(389, 25)
        Me.pbRealmCPU.Name = "pbRealmCPU"
        Me.pbRealmCPU.Size = New System.Drawing.Size(61, 14)
        Me.pbRealmCPU.TabIndex = 71
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(388, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 12)
        Me.Label15.TabIndex = 73
        Me.Label15.Text = "REALM CPU"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label32.Location = New System.Drawing.Point(47, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(45, 12)
        Me.Label32.TabIndex = 68
        Me.Label32.Text = "Uptime:"
        '
        'lblRealmCPU
        '
        Me.lblRealmCPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealmCPU.Location = New System.Drawing.Point(387, 39)
        Me.lblRealmCPU.Name = "lblRealmCPU"
        Me.lblRealmCPU.Size = New System.Drawing.Size(63, 15)
        Me.lblRealmCPU.TabIndex = 72
        Me.lblRealmCPU.Text = "-"
        Me.lblRealmCPU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRestartRealm
        '
        Me.cmdRestartRealm.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdRestartRealm.Image = CType(resources.GetObject("cmdRestartRealm.Image"), System.Drawing.Image)
        Me.cmdRestartRealm.Location = New System.Drawing.Point(460, 18)
        Me.cmdRestartRealm.Name = "cmdRestartRealm"
        Me.cmdRestartRealm.Size = New System.Drawing.Size(28, 28)
        Me.cmdRestartRealm.TabIndex = 1
        Me.cmdRestartRealm.UseVisualStyleBackColor = True
        '
        'lblRealmUpTime
        '
        Me.lblRealmUpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblRealmUpTime.Location = New System.Drawing.Point(95, 27)
        Me.lblRealmUpTime.Name = "lblRealmUpTime"
        Me.lblRealmUpTime.Size = New System.Drawing.Size(269, 13)
        Me.lblRealmUpTime.TabIndex = 27
        Me.lblRealmUpTime.Text = "Not available"
        '
        'pbRealm
        '
        Me.pbRealm.InitialImage = Nothing
        Me.pbRealm.Location = New System.Drawing.Point(6, 16)
        Me.pbRealm.Name = "pbRealm"
        Me.pbRealm.Size = New System.Drawing.Size(32, 32)
        Me.pbRealm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRealm.TabIndex = 26
        Me.pbRealm.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.Location = New System.Drawing.Point(44, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(299, 18)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Realm Server"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbCore1
        '
        Me.gbCore1.Controls.Add(Me.Label40)
        Me.gbCore1.Controls.Add(Me.lblCore1Crashes)
        Me.gbCore1.Controls.Add(Me.pbCore1CPU)
        Me.gbCore1.Controls.Add(Me.Label14)
        Me.gbCore1.Controls.Add(Me.lblCore1CPU)
        Me.gbCore1.Controls.Add(Me.Label33)
        Me.gbCore1.Controls.Add(Me.cmdRestartCore1)
        Me.gbCore1.Controls.Add(Me.lblCore1UpTime)
        Me.gbCore1.Controls.Add(Me.pbCore1)
        Me.gbCore1.Controls.Add(Me.lblCore1Title)
        Me.gbCore1.Location = New System.Drawing.Point(10, 158)
        Me.gbCore1.Name = "gbCore1"
        Me.gbCore1.Size = New System.Drawing.Size(499, 59)
        Me.gbCore1.TabIndex = 2
        Me.gbCore1.TabStop = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(47, 41)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(47, 12)
        Me.Label40.TabIndex = 77
        Me.Label40.Text = "Crashes:"
        '
        'lblCore1Crashes
        '
        Me.lblCore1Crashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore1Crashes.Location = New System.Drawing.Point(95, 41)
        Me.lblCore1Crashes.Name = "lblCore1Crashes"
        Me.lblCore1Crashes.Size = New System.Drawing.Size(269, 13)
        Me.lblCore1Crashes.TabIndex = 76
        Me.lblCore1Crashes.Text = "Not available"
        '
        'pbCore1CPU
        '
        Me.pbCore1CPU.BackColor1 = System.Drawing.Color.Black
        Me.pbCore1CPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbCore1CPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore1CPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore1CPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore1CPU.BarColor1 = System.Drawing.Color.Green
        Me.pbCore1CPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbCore1CPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore1CPU.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore1CPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore1CPU.Location = New System.Drawing.Point(389, 25)
        Me.pbCore1CPU.Name = "pbCore1CPU"
        Me.pbCore1CPU.Size = New System.Drawing.Size(61, 14)
        Me.pbCore1CPU.TabIndex = 70
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(388, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 12)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "CORE CPU"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCore1CPU
        '
        Me.lblCore1CPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore1CPU.Location = New System.Drawing.Point(387, 39)
        Me.lblCore1CPU.Name = "lblCore1CPU"
        Me.lblCore1CPU.Size = New System.Drawing.Size(63, 15)
        Me.lblCore1CPU.TabIndex = 71
        Me.lblCore1CPU.Text = "-"
        Me.lblCore1CPU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label33.Location = New System.Drawing.Point(47, 27)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 12)
        Me.Label33.TabIndex = 69
        Me.Label33.Text = "Uptime:"
        '
        'cmdRestartCore1
        '
        Me.cmdRestartCore1.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdRestartCore1.Image = CType(resources.GetObject("cmdRestartCore1.Image"), System.Drawing.Image)
        Me.cmdRestartCore1.Location = New System.Drawing.Point(460, 18)
        Me.cmdRestartCore1.Name = "cmdRestartCore1"
        Me.cmdRestartCore1.Size = New System.Drawing.Size(28, 28)
        Me.cmdRestartCore1.TabIndex = 2
        Me.cmdRestartCore1.UseVisualStyleBackColor = True
        '
        'lblCore1UpTime
        '
        Me.lblCore1UpTime.AutoSize = True
        Me.lblCore1UpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore1UpTime.Location = New System.Drawing.Point(95, 27)
        Me.lblCore1UpTime.Name = "lblCore1UpTime"
        Me.lblCore1UpTime.Size = New System.Drawing.Size(59, 12)
        Me.lblCore1UpTime.TabIndex = 26
        Me.lblCore1UpTime.Text = "Not available"
        '
        'pbCore1
        '
        Me.pbCore1.InitialImage = Nothing
        Me.pbCore1.Location = New System.Drawing.Point(6, 16)
        Me.pbCore1.Name = "pbCore1"
        Me.pbCore1.Size = New System.Drawing.Size(32, 32)
        Me.pbCore1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCore1.TabIndex = 25
        Me.pbCore1.TabStop = False
        '
        'lblCore1Title
        '
        Me.lblCore1Title.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore1Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblCore1Title.Location = New System.Drawing.Point(44, 9)
        Me.lblCore1Title.Name = "lblCore1Title"
        Me.lblCore1Title.Size = New System.Drawing.Size(299, 14)
        Me.lblCore1Title.TabIndex = 24
        Me.lblCore1Title.Text = "Core: Realm 1"
        Me.lblCore1Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbCore2
        '
        Me.gbCore2.Controls.Add(Me.Label42)
        Me.gbCore2.Controls.Add(Me.lblCore2Crashes)
        Me.gbCore2.Controls.Add(Me.pbCore2CPU)
        Me.gbCore2.Controls.Add(Me.Label1)
        Me.gbCore2.Controls.Add(Me.lblCore2CPU)
        Me.gbCore2.Controls.Add(Me.Label34)
        Me.gbCore2.Controls.Add(Me.cmdRestartCore2)
        Me.gbCore2.Controls.Add(Me.lblCore2UpTime)
        Me.gbCore2.Controls.Add(Me.pbCore2)
        Me.gbCore2.Controls.Add(Me.lblCore2Title)
        Me.gbCore2.Location = New System.Drawing.Point(10, 217)
        Me.gbCore2.Name = "gbCore2"
        Me.gbCore2.Size = New System.Drawing.Size(499, 59)
        Me.gbCore2.TabIndex = 3
        Me.gbCore2.TabStop = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label42.Location = New System.Drawing.Point(47, 41)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(47, 12)
        Me.Label42.TabIndex = 77
        Me.Label42.Text = "Crashes:"
        '
        'lblCore2Crashes
        '
        Me.lblCore2Crashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore2Crashes.Location = New System.Drawing.Point(95, 41)
        Me.lblCore2Crashes.Name = "lblCore2Crashes"
        Me.lblCore2Crashes.Size = New System.Drawing.Size(269, 13)
        Me.lblCore2Crashes.TabIndex = 76
        Me.lblCore2Crashes.Text = "Not available"
        '
        'pbCore2CPU
        '
        Me.pbCore2CPU.BackColor1 = System.Drawing.Color.Black
        Me.pbCore2CPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbCore2CPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore2CPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore2CPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore2CPU.BarColor1 = System.Drawing.Color.Green
        Me.pbCore2CPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbCore2CPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbCore2CPU.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbCore2CPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbCore2CPU.Location = New System.Drawing.Point(388, 25)
        Me.pbCore2CPU.Name = "pbCore2CPU"
        Me.pbCore2CPU.Size = New System.Drawing.Size(61, 14)
        Me.pbCore2CPU.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 12)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "CORE CPU"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCore2CPU
        '
        Me.lblCore2CPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore2CPU.Location = New System.Drawing.Point(388, 39)
        Me.lblCore2CPU.Name = "lblCore2CPU"
        Me.lblCore2CPU.Size = New System.Drawing.Size(63, 15)
        Me.lblCore2CPU.TabIndex = 74
        Me.lblCore2CPU.Text = "-"
        Me.lblCore2CPU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label34.Location = New System.Drawing.Point(47, 27)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(45, 12)
        Me.Label34.TabIndex = 69
        Me.Label34.Text = "Uptime:"
        '
        'cmdRestartCore2
        '
        Me.cmdRestartCore2.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.cmdRestartCore2.Image = CType(resources.GetObject("cmdRestartCore2.Image"), System.Drawing.Image)
        Me.cmdRestartCore2.Location = New System.Drawing.Point(460, 18)
        Me.cmdRestartCore2.Name = "cmdRestartCore2"
        Me.cmdRestartCore2.Size = New System.Drawing.Size(28, 28)
        Me.cmdRestartCore2.TabIndex = 3
        Me.cmdRestartCore2.UseVisualStyleBackColor = True
        '
        'lblCore2UpTime
        '
        Me.lblCore2UpTime.AutoSize = True
        Me.lblCore2UpTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblCore2UpTime.Location = New System.Drawing.Point(95, 27)
        Me.lblCore2UpTime.Name = "lblCore2UpTime"
        Me.lblCore2UpTime.Size = New System.Drawing.Size(59, 12)
        Me.lblCore2UpTime.TabIndex = 26
        Me.lblCore2UpTime.Text = "Not available"
        '
        'pbCore2
        '
        Me.pbCore2.InitialImage = Nothing
        Me.pbCore2.Location = New System.Drawing.Point(6, 16)
        Me.pbCore2.Name = "pbCore2"
        Me.pbCore2.Size = New System.Drawing.Size(32, 32)
        Me.pbCore2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCore2.TabIndex = 25
        Me.pbCore2.TabStop = False
        '
        'lblCore2Title
        '
        Me.lblCore2Title.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCore2Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblCore2Title.Location = New System.Drawing.Point(44, 9)
        Me.lblCore2Title.Name = "lblCore2Title"
        Me.lblCore2Title.Size = New System.Drawing.Size(299, 14)
        Me.lblCore2Title.TabIndex = 24
        Me.lblCore2Title.Text = "Core: Realm 2"
        Me.lblCore2Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Green
        Me.Panel5.Location = New System.Drawing.Point(3, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(509, 307)
        Me.Panel5.TabIndex = 52
        Me.Panel5.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabServerStatus)
        Me.TabControl1.Controls.Add(Me.tabAccounts)
        Me.TabControl1.Controls.Add(Me.tabMail)
        Me.TabControl1.Controls.Add(Me.tabBroadcast)
        Me.TabControl1.Controls.Add(Me.tabSchedules)
        Me.TabControl1.HotTrack = True
        Me.TabControl1.ImageList = Me.ilTabs
        Me.TabControl1.Location = New System.Drawing.Point(6, 8)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(523, 478)
        Me.TabControl1.TabIndex = 1
        '
        'tabMail
        '
        Me.tabMail.Controls.Add(Me.Label7)
        Me.tabMail.Controls.Add(Me.txtIMMessage)
        Me.tabMail.Controls.Add(Me.Label6)
        Me.tabMail.Controls.Add(Me.txtIMItems)
        Me.tabMail.Controls.Add(Me.Label5)
        Me.tabMail.Controls.Add(Me.txtIMMoney)
        Me.tabMail.Controls.Add(Me.Label4)
        Me.tabMail.Controls.Add(Me.txtIMSubject)
        Me.tabMail.Controls.Add(Me.cmdMail)
        Me.tabMail.Controls.Add(Me.lvIMChar)
        Me.tabMail.Controls.Add(Me.ListView3)
        Me.tabMail.Controls.Add(Me.Panel3)
        Me.tabMail.ImageIndex = 2
        Me.tabMail.Location = New System.Drawing.Point(4, 39)
        Me.tabMail.Name = "tabMail"
        Me.tabMail.Size = New System.Drawing.Size(515, 435)
        Me.tabMail.TabIndex = 4
        Me.tabMail.Text = "Ingame Mail"
        Me.tabMail.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(250, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Message to send:"
        '
        'txtIMMessage
        '
        Me.txtIMMessage.Location = New System.Drawing.Point(253, 66)
        Me.txtIMMessage.Multiline = True
        Me.txtIMMessage.Name = "txtIMMessage"
        Me.txtIMMessage.Size = New System.Drawing.Size(256, 68)
        Me.txtIMMessage.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(250, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Items to send:"
        '
        'txtIMItems
        '
        Me.txtIMItems.Location = New System.Drawing.Point(253, 202)
        Me.txtIMItems.Name = "txtIMItems"
        Me.txtIMItems.Size = New System.Drawing.Size(256, 20)
        Me.txtIMItems.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(250, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Money to send:"
        '
        'txtIMMoney
        '
        Me.txtIMMoney.Location = New System.Drawing.Point(253, 159)
        Me.txtIMMoney.Name = "txtIMMoney"
        Me.txtIMMoney.Size = New System.Drawing.Size(256, 20)
        Me.txtIMMoney.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(250, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Subject:"
        '
        'txtIMSubject
        '
        Me.txtIMSubject.Location = New System.Drawing.Point(253, 22)
        Me.txtIMSubject.Name = "txtIMSubject"
        Me.txtIMSubject.Size = New System.Drawing.Size(256, 20)
        Me.txtIMSubject.TabIndex = 2
        '
        'cmdMail
        '
        Me.cmdMail.Location = New System.Drawing.Point(434, 235)
        Me.cmdMail.Name = "cmdMail"
        Me.cmdMail.Size = New System.Drawing.Size(75, 23)
        Me.cmdMail.TabIndex = 6
        Me.cmdMail.Text = "Mail"
        Me.cmdMail.UseVisualStyleBackColor = True
        '
        'lvIMChar
        '
        Me.lvIMChar.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvIMChar.AutoArrange = False
        Me.lvIMChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvIMChar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCharacterList, Me.colRealmList})
        Me.lvIMChar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIMChar.FullRowSelect = True
        Me.lvIMChar.LabelWrap = False
        Me.lvIMChar.LargeImageList = Me.imglstAccList
        Me.lvIMChar.Location = New System.Drawing.Point(3, 6)
        Me.lvIMChar.Name = "lvIMChar"
        Me.lvIMChar.Size = New System.Drawing.Size(244, 426)
        Me.lvIMChar.SmallImageList = Me.imglstAccList
        Me.lvIMChar.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvIMChar.TabIndex = 1
        Me.lvIMChar.UseCompatibleStateImageBehavior = False
        Me.lvIMChar.View = System.Windows.Forms.View.Details
        Me.lvIMChar.Visible = False
        '
        'colCharacterList
        '
        Me.colCharacterList.Text = "Characters"
        Me.colCharacterList.Width = 137
        '
        'colRealmList
        '
        Me.colRealmList.Text = "Realm"
        Me.colRealmList.Width = 90
        '
        'ListView3
        '
        Me.ListView3.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView3.AutoArrange = False
        Me.ListView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6})
        Me.ListView3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.FullRowSelect = True
        Me.ListView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView3.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
        Me.ListView3.LabelWrap = False
        Me.ListView3.LargeImageList = Me.imglstAccList
        Me.ListView3.Location = New System.Drawing.Point(3, 6)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(244, 426)
        Me.ListView3.SmallImageList = Me.imglstAccList
        Me.ListView3.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView3.TabIndex = 26
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Characters"
        Me.ColumnHeader6.Width = 220
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Green
        Me.Panel3.Location = New System.Drawing.Point(3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(509, 307)
        Me.Panel3.TabIndex = 52
        Me.Panel3.Visible = False
        '
        'tabSchedules
        '
        Me.tabSchedules.Controls.Add(Me.Label21)
        Me.tabSchedules.Controls.Add(Me.cmdSchedRemove)
        Me.tabSchedules.Controls.Add(Me.lstScheduleLog)
        Me.tabSchedules.Controls.Add(Me.cmdSchedAdd)
        Me.tabSchedules.Controls.Add(Me.cmdSchedSave)
        Me.tabSchedules.Controls.Add(Me.gbSchedHourly)
        Me.tabSchedules.Controls.Add(Me.Label22)
        Me.tabSchedules.Controls.Add(Me.txtScheduleMessage)
        Me.tabSchedules.Controls.Add(Me.cbSchedules)
        Me.tabSchedules.Controls.Add(Me.gbSchedDaily)
        Me.tabSchedules.Controls.Add(Me.Label23)
        Me.tabSchedules.Controls.Add(Me.lblTime)
        Me.tabSchedules.Controls.Add(Me.gbSchedFreq)
        Me.tabSchedules.Controls.Add(Me.Label26)
        Me.tabSchedules.Controls.Add(Me.cbSchedCommand)
        Me.tabSchedules.Controls.Add(Me.Label27)
        Me.tabSchedules.Controls.Add(Me.gbSchedMonthly)
        Me.tabSchedules.Controls.Add(Me.gbSchedWeekly)
        Me.tabSchedules.Controls.Add(Me.Panel1)
        Me.tabSchedules.ImageIndex = 4
        Me.tabSchedules.Location = New System.Drawing.Point(4, 39)
        Me.tabSchedules.Name = "tabSchedules"
        Me.tabSchedules.Size = New System.Drawing.Size(515, 435)
        Me.tabSchedules.TabIndex = 5
        Me.tabSchedules.Text = "Schedules"
        Me.tabSchedules.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 217)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Schedule Log:"
        '
        'cmdSchedRemove
        '
        Me.cmdSchedRemove.Location = New System.Drawing.Point(432, 282)
        Me.cmdSchedRemove.Name = "cmdSchedRemove"
        Me.cmdSchedRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdSchedRemove.TabIndex = 53
        Me.cmdSchedRemove.Text = "Remove"
        Me.cmdSchedRemove.UseVisualStyleBackColor = True
        '
        'lstScheduleLog
        '
        Me.lstScheduleLog.FormattingEnabled = True
        Me.lstScheduleLog.Location = New System.Drawing.Point(6, 233)
        Me.lstScheduleLog.Name = "lstScheduleLog"
        Me.lstScheduleLog.Size = New System.Drawing.Size(503, 43)
        Me.lstScheduleLog.TabIndex = 32
        '
        'cmdSchedAdd
        '
        Me.cmdSchedAdd.Location = New System.Drawing.Point(351, 282)
        Me.cmdSchedAdd.Name = "cmdSchedAdd"
        Me.cmdSchedAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdSchedAdd.TabIndex = 52
        Me.cmdSchedAdd.Text = "Add as new"
        Me.cmdSchedAdd.UseVisualStyleBackColor = True
        '
        'cmdSchedSave
        '
        Me.cmdSchedSave.Location = New System.Drawing.Point(270, 282)
        Me.cmdSchedSave.Name = "cmdSchedSave"
        Me.cmdSchedSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSchedSave.TabIndex = 54
        Me.cmdSchedSave.Text = "Save"
        Me.cmdSchedSave.UseVisualStyleBackColor = True
        '
        'gbSchedHourly
        '
        Me.gbSchedHourly.Controls.Add(Me.txtSchedHours)
        Me.gbSchedHourly.Controls.Add(Me.Label16)
        Me.gbSchedHourly.Controls.Add(Me.Label18)
        Me.gbSchedHourly.Location = New System.Drawing.Point(158, 104)
        Me.gbSchedHourly.Name = "gbSchedHourly"
        Me.gbSchedHourly.Size = New System.Drawing.Size(307, 109)
        Me.gbSchedHourly.TabIndex = 47
        Me.gbSchedHourly.TabStop = False
        Me.gbSchedHourly.Text = "Hourly"
        '
        'txtSchedHours
        '
        Me.txtSchedHours.Location = New System.Drawing.Point(128, 46)
        Me.txtSchedHours.Name = "txtSchedHours"
        Me.txtSchedHours.Size = New System.Drawing.Size(51, 20)
        Me.txtSchedHours.TabIndex = 24
        Me.txtSchedHours.Text = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(185, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "hour(s)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(83, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Every:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 76)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Message:"
        '
        'txtScheduleMessage
        '
        Me.txtScheduleMessage.Location = New System.Drawing.Point(72, 73)
        Me.txtScheduleMessage.Name = "txtScheduleMessage"
        Me.txtScheduleMessage.Size = New System.Drawing.Size(437, 20)
        Me.txtScheduleMessage.TabIndex = 43
        '
        'cbSchedules
        '
        Me.cbSchedules.FormattingEnabled = True
        Me.cbSchedules.Location = New System.Drawing.Point(13, 45)
        Me.cbSchedules.Name = "cbSchedules"
        Me.cbSchedules.Size = New System.Drawing.Size(237, 21)
        Me.cbSchedules.TabIndex = 41
        '
        'gbSchedDaily
        '
        Me.gbSchedDaily.Controls.Add(Me.Label19)
        Me.gbSchedDaily.Controls.Add(Me.dtpSchedDailyTime)
        Me.gbSchedDaily.Location = New System.Drawing.Point(158, 104)
        Me.gbSchedDaily.Name = "gbSchedDaily"
        Me.gbSchedDaily.Size = New System.Drawing.Size(307, 109)
        Me.gbSchedDaily.TabIndex = 38
        Me.gbSchedDaily.TabStop = False
        Me.gbSchedDaily.Text = "Daily"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(65, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Choose a time:"
        '
        'dtpSchedDailyTime
        '
        Me.dtpSchedDailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpSchedDailyTime.Location = New System.Drawing.Point(148, 44)
        Me.dtpSchedDailyTime.MinDate = New Date(2001, 1, 1, 0, 0, 0, 0)
        Me.dtpSchedDailyTime.Name = "dtpSchedDailyTime"
        Me.dtpSchedDailyTime.ShowUpDown = True
        Me.dtpSchedDailyTime.Size = New System.Drawing.Size(94, 20)
        Me.dtpSchedDailyTime.TabIndex = 18
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(183, 18)
        Me.Label23.TabIndex = 30
        Me.Label23.Text = "Schedule Configuration"
        '
        'lblTime
        '
        Me.lblTime.Location = New System.Drawing.Point(273, 4)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(236, 23)
        Me.lblTime.TabIndex = 48
        Me.lblTime.Text = "SCHEDULER DISABLED"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbSchedFreq
        '
        Me.gbSchedFreq.Controls.Add(Me.rbSchedHourly)
        Me.gbSchedFreq.Controls.Add(Me.rbSchedMonthly)
        Me.gbSchedFreq.Controls.Add(Me.rbSchedWeekly)
        Me.gbSchedFreq.Controls.Add(Me.rbSchedDaily)
        Me.gbSchedFreq.Location = New System.Drawing.Point(50, 104)
        Me.gbSchedFreq.Name = "gbSchedFreq"
        Me.gbSchedFreq.Size = New System.Drawing.Size(102, 109)
        Me.gbSchedFreq.TabIndex = 36
        Me.gbSchedFreq.TabStop = False
        Me.gbSchedFreq.Text = "Perform this task"
        '
        'rbSchedHourly
        '
        Me.rbSchedHourly.AutoSize = True
        Me.rbSchedHourly.Location = New System.Drawing.Point(20, 21)
        Me.rbSchedHourly.Name = "rbSchedHourly"
        Me.rbSchedHourly.Size = New System.Drawing.Size(55, 17)
        Me.rbSchedHourly.TabIndex = 20
        Me.rbSchedHourly.Text = "Hourly"
        Me.rbSchedHourly.UseVisualStyleBackColor = True
        '
        'rbSchedMonthly
        '
        Me.rbSchedMonthly.AutoSize = True
        Me.rbSchedMonthly.Location = New System.Drawing.Point(20, 84)
        Me.rbSchedMonthly.Name = "rbSchedMonthly"
        Me.rbSchedMonthly.Size = New System.Drawing.Size(62, 17)
        Me.rbSchedMonthly.TabIndex = 19
        Me.rbSchedMonthly.Text = "Monthly"
        Me.rbSchedMonthly.UseVisualStyleBackColor = True
        '
        'rbSchedWeekly
        '
        Me.rbSchedWeekly.AutoSize = True
        Me.rbSchedWeekly.Location = New System.Drawing.Point(20, 63)
        Me.rbSchedWeekly.Name = "rbSchedWeekly"
        Me.rbSchedWeekly.Size = New System.Drawing.Size(61, 17)
        Me.rbSchedWeekly.TabIndex = 18
        Me.rbSchedWeekly.Text = "Weekly"
        Me.rbSchedWeekly.UseVisualStyleBackColor = True
        '
        'rbSchedDaily
        '
        Me.rbSchedDaily.AutoSize = True
        Me.rbSchedDaily.Checked = True
        Me.rbSchedDaily.Location = New System.Drawing.Point(20, 42)
        Me.rbSchedDaily.Name = "rbSchedDaily"
        Me.rbSchedDaily.Size = New System.Drawing.Size(48, 17)
        Me.rbSchedDaily.TabIndex = 17
        Me.rbSchedDaily.TabStop = True
        Me.rbSchedDaily.Text = "Daily"
        Me.rbSchedDaily.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(284, 29)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 13)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "Command:"
        '
        'cbSchedCommand
        '
        Me.cbSchedCommand.FormattingEnabled = True
        Me.cbSchedCommand.Location = New System.Drawing.Point(287, 45)
        Me.cbSchedCommand.Name = "cbSchedCommand"
        Me.cbSchedCommand.Size = New System.Drawing.Size(222, 21)
        Me.cbSchedCommand.TabIndex = 33
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 29)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 13)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Schedule Name:"
        '
        'gbSchedMonthly
        '
        Me.gbSchedMonthly.Controls.Add(Me.Label24)
        Me.gbSchedMonthly.Controls.Add(Me.dtpSched)
        Me.gbSchedMonthly.Controls.Add(Me.Label25)
        Me.gbSchedMonthly.Controls.Add(Me.dtpSchedMonthlyTime)
        Me.gbSchedMonthly.Enabled = False
        Me.gbSchedMonthly.Location = New System.Drawing.Point(158, 104)
        Me.gbSchedMonthly.Name = "gbSchedMonthly"
        Me.gbSchedMonthly.Size = New System.Drawing.Size(307, 109)
        Me.gbSchedMonthly.TabIndex = 35
        Me.gbSchedMonthly.TabStop = False
        Me.gbSchedMonthly.Text = "Monthly Schedule"
        Me.gbSchedMonthly.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Choose a date:"
        '
        'dtpSched
        '
        Me.dtpSched.Location = New System.Drawing.Point(96, 31)
        Me.dtpSched.Name = "dtpSched"
        Me.dtpSched.Size = New System.Drawing.Size(200, 20)
        Me.dtpSched.TabIndex = 25
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 61)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 13)
        Me.Label25.TabIndex = 24
        Me.Label25.Text = "Choose a time:"
        '
        'dtpSchedMonthlyTime
        '
        Me.dtpSchedMonthlyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpSchedMonthlyTime.Location = New System.Drawing.Point(96, 57)
        Me.dtpSchedMonthlyTime.MinDate = New Date(2001, 1, 1, 0, 0, 0, 0)
        Me.dtpSchedMonthlyTime.Name = "dtpSchedMonthlyTime"
        Me.dtpSchedMonthlyTime.ShowUpDown = True
        Me.dtpSchedMonthlyTime.Size = New System.Drawing.Size(94, 20)
        Me.dtpSchedMonthlyTime.TabIndex = 23
        '
        'gbSchedWeekly
        '
        Me.gbSchedWeekly.Controls.Add(Me.Label20)
        Me.gbSchedWeekly.Controls.Add(Me.dtpSchedWeeklyTime)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedSun)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedSat)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedFri)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedThu)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedWed)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedTue)
        Me.gbSchedWeekly.Controls.Add(Me.chkSchedMon)
        Me.gbSchedWeekly.Enabled = False
        Me.gbSchedWeekly.Location = New System.Drawing.Point(158, 104)
        Me.gbSchedWeekly.Name = "gbSchedWeekly"
        Me.gbSchedWeekly.Size = New System.Drawing.Size(307, 109)
        Me.gbSchedWeekly.TabIndex = 37
        Me.gbSchedWeekly.TabStop = False
        Me.gbSchedWeekly.Text = "Weekly Schedule"
        Me.gbSchedWeekly.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(65, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Choose a time:"
        '
        'dtpSchedWeeklyTime
        '
        Me.dtpSchedWeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpSchedWeeklyTime.Location = New System.Drawing.Point(148, 69)
        Me.dtpSchedWeeklyTime.Name = "dtpSchedWeeklyTime"
        Me.dtpSchedWeeklyTime.ShowUpDown = True
        Me.dtpSchedWeeklyTime.Size = New System.Drawing.Size(94, 20)
        Me.dtpSchedWeeklyTime.TabIndex = 16
        '
        'chkSchedSun
        '
        Me.chkSchedSun.AutoSize = True
        Me.chkSchedSun.Location = New System.Drawing.Point(76, 46)
        Me.chkSchedSun.Name = "chkSchedSun"
        Me.chkSchedSun.Size = New System.Drawing.Size(45, 17)
        Me.chkSchedSun.TabIndex = 15
        Me.chkSchedSun.Text = "Sun"
        Me.chkSchedSun.UseVisualStyleBackColor = True
        '
        'chkSchedSat
        '
        Me.chkSchedSat.AutoSize = True
        Me.chkSchedSat.Location = New System.Drawing.Point(23, 46)
        Me.chkSchedSat.Name = "chkSchedSat"
        Me.chkSchedSat.Size = New System.Drawing.Size(42, 17)
        Me.chkSchedSat.TabIndex = 14
        Me.chkSchedSat.Text = "Sat"
        Me.chkSchedSat.UseVisualStyleBackColor = True
        '
        'chkSchedFri
        '
        Me.chkSchedFri.AutoSize = True
        Me.chkSchedFri.Location = New System.Drawing.Point(233, 23)
        Me.chkSchedFri.Name = "chkSchedFri"
        Me.chkSchedFri.Size = New System.Drawing.Size(37, 17)
        Me.chkSchedFri.TabIndex = 13
        Me.chkSchedFri.Text = "Fri"
        Me.chkSchedFri.UseVisualStyleBackColor = True
        '
        'chkSchedThu
        '
        Me.chkSchedThu.AutoSize = True
        Me.chkSchedThu.Location = New System.Drawing.Point(182, 23)
        Me.chkSchedThu.Name = "chkSchedThu"
        Me.chkSchedThu.Size = New System.Drawing.Size(45, 17)
        Me.chkSchedThu.TabIndex = 12
        Me.chkSchedThu.Text = "Thu"
        Me.chkSchedThu.UseVisualStyleBackColor = True
        '
        'chkSchedWed
        '
        Me.chkSchedWed.AutoSize = True
        Me.chkSchedWed.Location = New System.Drawing.Point(127, 23)
        Me.chkSchedWed.Name = "chkSchedWed"
        Me.chkSchedWed.Size = New System.Drawing.Size(49, 17)
        Me.chkSchedWed.TabIndex = 11
        Me.chkSchedWed.Text = "Wed"
        Me.chkSchedWed.UseVisualStyleBackColor = True
        '
        'chkSchedTue
        '
        Me.chkSchedTue.AutoSize = True
        Me.chkSchedTue.Location = New System.Drawing.Point(76, 23)
        Me.chkSchedTue.Name = "chkSchedTue"
        Me.chkSchedTue.Size = New System.Drawing.Size(45, 17)
        Me.chkSchedTue.TabIndex = 10
        Me.chkSchedTue.Text = "Tue"
        Me.chkSchedTue.UseVisualStyleBackColor = True
        '
        'chkSchedMon
        '
        Me.chkSchedMon.AutoSize = True
        Me.chkSchedMon.Location = New System.Drawing.Point(23, 23)
        Me.chkSchedMon.Name = "chkSchedMon"
        Me.chkSchedMon.Size = New System.Drawing.Size(47, 17)
        Me.chkSchedMon.TabIndex = 9
        Me.chkSchedMon.Text = "Mon"
        Me.chkSchedMon.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Green
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 307)
        Me.Panel1.TabIndex = 51
        Me.Panel1.Visible = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Characters"
        Me.ColumnHeader2.Width = 220
        '
        'tmrScheduler
        '
        Me.tmrScheduler.Interval = 1000
        '
        'tmrPerf
        '
        Me.tmrPerf.Interval = 1000
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label35.Location = New System.Drawing.Point(319, 548)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(84, 13)
        Me.Label35.TabIndex = 75
        Me.Label35.Text = "TriniGuard CPU:"
        '
        'lblTGCPU
        '
        Me.lblTGCPU.AutoSize = True
        Me.lblTGCPU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTGCPU.Location = New System.Drawing.Point(500, 548)
        Me.lblTGCPU.Name = "lblTGCPU"
        Me.lblTGCPU.Size = New System.Drawing.Size(33, 13)
        Me.lblTGCPU.TabIndex = 76
        Me.lblTGCPU.Text = "100%"
        '
        'pbTGCPU
        '
        Me.pbTGCPU.BackColor1 = System.Drawing.Color.Black
        Me.pbTGCPU.BackColor2 = System.Drawing.Color.Gray
        Me.pbTGCPU.BackColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbTGCPU.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbTGCPU.BackSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbTGCPU.BarColor1 = System.Drawing.Color.Green
        Me.pbTGCPU.BarColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbTGCPU.BarColorStyle = TriniGuard3.SmoothProgressBar.ColorStyle.Gradient
        Me.pbTGCPU.BarGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pbTGCPU.BarSigmaMode = TriniGuard3.SmoothProgressBar.SigmaMode.SigmaBell
        Me.pbTGCPU.Location = New System.Drawing.Point(405, 548)
        Me.pbTGCPU.Name = "pbTGCPU"
        Me.pbTGCPU.Size = New System.Drawing.Size(94, 14)
        Me.pbTGCPU.TabIndex = 74
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 565)
        Me.Controls.Add(Me.lblTGCPU)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.pbTGCPU)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbToolBar)
        Me.Controls.Add(Me.ssStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "TriniGuard v3 - WoWRean"
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.gbToolBar.ResumeLayout(False)
        Me.tabBroadcast.ResumeLayout(False)
        Me.tabBroadcast.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tabAccounts.ResumeLayout(False)
        Me.tabServerStatus.ResumeLayout(False)
        Me.gbSystemPerf.ResumeLayout(False)
        Me.gbCore3.ResumeLayout(False)
        Me.gbCore3.PerformLayout()
        CType(Me.pbCore3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBackupTimers.ResumeLayout(False)
        Me.gbBackupTimers.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.gbRealm.ResumeLayout(False)
        Me.gbRealm.PerformLayout()
        CType(Me.pbRealm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCore1.ResumeLayout(False)
        Me.gbCore1.PerformLayout()
        CType(Me.pbCore1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCore2.ResumeLayout(False)
        Me.gbCore2.PerformLayout()
        CType(Me.pbCore2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabMail.ResumeLayout(False)
        Me.tabMail.PerformLayout()
        Me.tabSchedules.ResumeLayout(False)
        Me.tabSchedules.PerformLayout()
        Me.gbSchedHourly.ResumeLayout(False)
        Me.gbSchedHourly.PerformLayout()
        Me.gbSchedDaily.ResumeLayout(False)
        Me.gbSchedDaily.PerformLayout()
        Me.gbSchedFreq.ResumeLayout(False)
        Me.gbSchedFreq.PerformLayout()
        Me.gbSchedMonthly.ResumeLayout(False)
        Me.gbSchedMonthly.PerformLayout()
        Me.gbSchedWeekly.ResumeLayout(False)
        Me.gbSchedWeekly.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents niStatus As System.Windows.Forms.NotifyIcon
    Friend WithEvents imglstIcons As System.Windows.Forms.ImageList
    Friend WithEvents tmrSaveIcon As System.Windows.Forms.Timer
    Friend WithEvents tmrUpdateStatus As System.Windows.Forms.Timer
    Friend WithEvents imglstImages As System.Windows.Forms.ImageList
    Friend WithEvents tmrCoreCheck As System.Windows.Forms.Timer
    Friend WithEvents tmrRealmCheck As System.Windows.Forms.Timer
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tmrUpTime As System.Windows.Forms.Timer
    Friend WithEvents gbToolBar As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBackupNow As System.Windows.Forms.Button
    Friend WithEvents btnConfigure As System.Windows.Forms.Button
    Friend WithEvents cmdHide As System.Windows.Forms.Button
    Friend WithEvents tmrBackup As System.Windows.Forms.Timer
    Friend WithEvents btnShowTrinity As System.Windows.Forms.Button
    Friend WithEvents btnHideTrinity As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ilTabs As System.Windows.Forms.ImageList
    Friend WithEvents imglstAccList As System.Windows.Forms.ImageList
    Friend WithEvents tabBroadcast As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAnnounce As System.Windows.Forms.Button
    Friend WithEvents cmdNotify As System.Windows.Forms.Button
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents tabAccounts As System.Windows.Forms.TabPage
    Friend WithEvents lvAccounts As System.Windows.Forms.ListView
    Friend WithEvents colAccounts As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabServerStatus As System.Windows.Forms.TabPage
    Friend WithEvents cmdRestartTrinity As System.Windows.Forms.Button
    Friend WithEvents gbRealm As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRestartRealm As System.Windows.Forms.Button
    Friend WithEvents lblRealmUpTime As System.Windows.Forms.Label
    Friend WithEvents pbRealm As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbCore1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRestartCore1 As System.Windows.Forms.Button
    Friend WithEvents lblCore1UpTime As System.Windows.Forms.Label
    Friend WithEvents pbCore1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCore1Title As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents lvCharacters As System.Windows.Forms.ListView
    Friend WithEvents colCharacter As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdBan As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteUser As System.Windows.Forms.Button
    Friend WithEvents cmdAddUser As System.Windows.Forms.Button
    Friend WithEvents cmdKick As System.Windows.Forms.Button
    Friend WithEvents cmdReload As System.Windows.Forms.Button
    Friend WithEvents lblNumOnline As System.Windows.Forms.Label
    Friend WithEvents tabMail As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIMMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIMItems As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIMMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIMSubject As System.Windows.Forms.TextBox
    Friend WithEvents lvIMChar As System.Windows.Forms.ListView
    Friend WithEvents colCharacterList As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdMail As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDBVer As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCoreVer As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblBaseAuthor As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCoreRev As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAdminOnline As System.Windows.Forms.CheckBox
    Friend WithEvents chkModOnline As System.Windows.Forms.CheckBox
    Friend WithEvents chkGMOnline As System.Windows.Forms.CheckBox
    Friend WithEvents tmrScheduler As System.Windows.Forms.Timer
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDebug As System.Windows.Forms.Label
    Friend WithEvents cmdExpLvl As System.Windows.Forms.Button
    Friend WithEvents cmdGMLvl As System.Windows.Forms.Button
    Friend WithEvents tmrPerf As System.Windows.Forms.Timer
    Friend WithEvents gbSystemPerf As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblCoreRAM As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblSystemCPU As System.Windows.Forms.Label
    Friend WithEvents gbBackupTimers As System.Windows.Forms.GroupBox
    Friend WithEvents tabSchedules As System.Windows.Forms.TabPage
    Friend WithEvents gbSchedHourly As System.Windows.Forms.GroupBox
    Friend WithEvents txtSchedHours As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleMessage As System.Windows.Forms.TextBox
    Friend WithEvents cbSchedules As System.Windows.Forms.ComboBox
    Friend WithEvents gbSchedDaily As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpSchedDailyTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents gbSchedFreq As System.Windows.Forms.GroupBox
    Friend WithEvents rbSchedHourly As System.Windows.Forms.RadioButton
    Friend WithEvents rbSchedMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rbSchedWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents rbSchedDaily As System.Windows.Forms.RadioButton
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbSchedCommand As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents gbSchedMonthly As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpSched As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpSchedMonthlyTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbSchedWeekly As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtpSchedWeeklyTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSchedSun As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedSat As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedFri As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedThu As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedWed As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedTue As System.Windows.Forms.CheckBox
    Friend WithEvents chkSchedMon As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblTableBak As System.Windows.Forms.Label
    Friend WithEvents lblCharBak As System.Windows.Forms.Label
    Friend WithEvents lblRealmBak As System.Windows.Forms.Label
    Friend WithEvents lblWorldBak As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtModOnline As System.Windows.Forms.TextBox
    Friend WithEvents txtGMOnline As System.Windows.Forms.TextBox
    Friend WithEvents txtAdminOnline As System.Windows.Forms.TextBox
    Friend WithEvents cmdSaveOnlineAlerts As System.Windows.Forms.Button
    Friend WithEvents colRealmList As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRealm As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents gbCore3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cmdRestartCore3 As System.Windows.Forms.Button
    Friend WithEvents lblCore3UpTime As System.Windows.Forms.Label
    Friend WithEvents pbCore3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCore3Title As System.Windows.Forms.Label
    Friend WithEvents gbCore2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmdRestartCore2 As System.Windows.Forms.Button
    Friend WithEvents lblCore2UpTime As System.Windows.Forms.Label
    Friend WithEvents pbCore2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCore2Title As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblRealmCPU As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblCore1CPU As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblCore3CPU As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCore2CPU As System.Windows.Forms.Label
    Friend WithEvents pbSystemCPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbCoreRAM As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbCore3CPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbCore2CPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbRealmCPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbCore1CPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents pbTGCPU As TriniGuard3.SmoothProgressBar
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblTGCPU As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbCoreMessage As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstScheduleLog As System.Windows.Forms.ListBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdSchedRemove As System.Windows.Forms.Button
    Friend WithEvents cmdSchedAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSchedSave As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblRealmCrashes As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblCore1Crashes As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents lblCore3Crashes As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents lblCore2Crashes As System.Windows.Forms.Label
    Friend WithEvents cmdInfo As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label

End Class
