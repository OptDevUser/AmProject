<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Timer3 As System.Windows.Forms.Timer
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.系统ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.回原点流程编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetLightPowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.流程编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.结束ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.手动控制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.系统设定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.控制器ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.校准轴比列ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.校正光谱ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.电源测试ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开监控ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.历史数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GBoxPower = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAPower = New System.Windows.Forms.Label()
        Me.lblBPower = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GBoxFlow = New System.Windows.Forms.GroupBox()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.listView1 = New System.Windows.Forms.ListView()
        Me.cbCmdStatus = New System.Windows.Forms.ComboBox()
        Me.BtnCmdStep = New System.Windows.Forms.Button()
        Me.BtnNextStep = New System.Windows.Forms.Button()
        Me.btnPerStep = New System.Windows.Forms.Button()
        Me.flowPartGBox1 = New System.Windows.Forms.GroupBox()
        Me.lsLog = New System.Windows.Forms.ListBox()
        Me.cmbFlowChart = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CurOperLabel = New System.Windows.Forms.Label()
        Me.ChangFlowBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.StateGBox = New System.Windows.Forms.GroupBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl5 = New System.Windows.Forms.TabControl()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Axis_6 = New PumpLaser_Automation.AxisContorl()
        Me.btnReadMiorrfile = New System.Windows.Forms.Button()
        Me.BtnSaveMiorrfile = New System.Windows.Forms.Button()
        Me.btnGoMirrorPos = New System.Windows.Forms.Button()
        Me.Axis_5 = New PumpLaser_Automation.AxisContorl()
        Me.Axis_4 = New PumpLaser_Automation.AxisContorl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Axis_2 = New PumpLaser_Automation.AxisContorl()
        Me.btnReadLensfile = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.BtnSaveLensfile = New System.Windows.Forms.Button()
        Me.btnGoLensPos = New System.Windows.Forms.Button()
        Me.Axis_1 = New PumpLaser_Automation.AxisContorl()
        Me.Axis_3 = New PumpLaser_Automation.AxisContorl()
        Me.Axis_0 = New PumpLaser_Automation.AxisContorl()
        Me.TabPage14 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.DataRemake = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.MeachineNo = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.cbWorkSatus = New System.Windows.Forms.ComboBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.cbErrorType = New System.Windows.Forms.ComboBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.DpOpenTime2 = New System.Windows.Forms.DateTimePicker()
        Me.HotEndTime = New System.Windows.Forms.DateTimePicker()
        Me.HotStartTime = New System.Windows.Forms.DateTimePicker()
        Me.OpWorkData2 = New System.Windows.Forms.DateTimePicker()
        Me.OpWokeData1 = New System.Windows.Forms.DateTimePicker()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.DpOpenTime1 = New System.Windows.Forms.DateTimePicker()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.DpTypeNo = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.DpLotNo = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.MirrorLotNo = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.OpeterNo = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.SN = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.r_9 = New System.Windows.Forms.TextBox()
        Me.r_8 = New System.Windows.Forms.TextBox()
        Me.r_7 = New System.Windows.Forms.TextBox()
        Me.r_6 = New System.Windows.Forms.TextBox()
        Me.r_5 = New System.Windows.Forms.TextBox()
        Me.r_4 = New System.Windows.Forms.TextBox()
        Me.r_3 = New System.Windows.Forms.TextBox()
        Me.r_2 = New System.Windows.Forms.TextBox()
        Me.R_1 = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.TabPage17 = New System.Windows.Forms.TabPage()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtSpanTime = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.btnsaScan = New System.Windows.Forms.Button()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.TxtIlret = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtDelta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtPicth = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtStep = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAxisName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.MoveDir = New System.Windows.Forms.TextBox()
        Me.moveMode = New System.Windows.Forms.TextBox()
        Me.MovePos = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtSensorInsertOffSet = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TxtZeroSensorValue = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TxtAxis1MaxOffSet = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtMove2Step = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.ComboBox13 = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ComboBox12 = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.ComboBox15 = New System.Windows.Forms.ComboBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.ComboBox14 = New System.Windows.Forms.ComboBox()
        Me.运动轴 = New System.Windows.Forms.Label()
        Me.TabPage18 = New System.Windows.Forms.TabPage()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.txtsaThreshold = New System.Windows.Forms.TextBox()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.cbsaIsIRet = New System.Windows.Forms.CheckBox()
        Me.btnsaAlign = New System.Windows.Forms.Button()
        Me.txtsaIRetCount = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.cksaIsCheck = New System.Windows.Forms.CheckBox()
        Me.cbsaChannel = New System.Windows.Forms.ComboBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.txtsaDelta = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.txtsaCP = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txtsaStep = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.cbsaAxis = New System.Windows.Forms.ComboBox()
        Me.GBoxPowerGra = New System.Windows.Forms.GroupBox()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.DataGraph_DB = New BrainDll.ZedGraphPanel()
        Me.lbMaxPower = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.DataGraph_1 = New BrainDll.ZedGraphPanel()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.DataGraph = New BrainDll.ZedGraphPanel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.Camra1 = New PumpLaser_Automation.Camra()
        Me.TabPage15 = New System.Windows.Forms.TabPage()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.CheckBox17 = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.IoControl11 = New PumpLaser_Automation.IOControl1()
        Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.GBoxFlow.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.flowPartGBox1.SuspendLayout()
        Me.StateGBox.SuspendLayout()
        Me.TabControl5.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage14.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage17.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        Me.TabPage18.SuspendLayout()
        Me.GBoxPowerGra.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TabPage13.SuspendLayout()
        Me.TabPage15.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer3
        '
        Timer3.Interval = 2000
        AddHandler Timer3.Tick, AddressOf Me.Timer3_Tick
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.系统ToolStripMenuItem, Me.设置ToolStripMenuItem, Me.打开监控ToolStripMenuItem, Me.历史数据ToolStripMenuItem, Me.帮助ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1120, 32)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "系统"
        '
        '系统ToolStripMenuItem
        '
        Me.系统ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.回原点流程编辑ToolStripMenuItem, Me.ResetLightPowerToolStripMenuItem, Me.流程编辑ToolStripMenuItem, Me.结束ToolStripMenuItem})
        Me.系统ToolStripMenuItem.Image = CType(resources.GetObject("系统ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem"
        Me.系统ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.系统ToolStripMenuItem.Text = "系统"
        '
        '回原点流程编辑ToolStripMenuItem
        '
        Me.回原点流程编辑ToolStripMenuItem.Name = "回原点流程编辑ToolStripMenuItem"
        Me.回原点流程编辑ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.回原点流程编辑ToolStripMenuItem.Text = "回原点流程编辑"
        Me.回原点流程编辑ToolStripMenuItem.Visible = False
        '
        'ResetLightPowerToolStripMenuItem
        '
        Me.ResetLightPowerToolStripMenuItem.Image = Global.PumpLaser_Automation.My.Resources.Resources.中斷_48
        Me.ResetLightPowerToolStripMenuItem.Name = "ResetLightPowerToolStripMenuItem"
        Me.ResetLightPowerToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ResetLightPowerToolStripMenuItem.Text = "复位功率计"
        '
        '流程编辑ToolStripMenuItem
        '
        Me.流程编辑ToolStripMenuItem.Image = CType(resources.GetObject("流程编辑ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.流程编辑ToolStripMenuItem.Name = "流程编辑ToolStripMenuItem"
        Me.流程编辑ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.流程编辑ToolStripMenuItem.Text = "流程编辑"
        '
        '结束ToolStripMenuItem
        '
        Me.结束ToolStripMenuItem.Image = CType(resources.GetObject("结束ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem"
        Me.结束ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.结束ToolStripMenuItem.Text = "结束"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.手动控制ToolStripMenuItem, Me.系统设定ToolStripMenuItem, Me.IOToolStripMenuItem, Me.控制器ToolStripMenuItem, Me.校正光谱ToolStripMenuItem, Me.电源测试ToolStripMenuItem})
        Me.设置ToolStripMenuItem.Image = CType(resources.GetObject("设置ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.设置ToolStripMenuItem.Text = "设置"
        '
        '手动控制ToolStripMenuItem
        '
        Me.手动控制ToolStripMenuItem.Image = CType(resources.GetObject("手动控制ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.手动控制ToolStripMenuItem.Name = "手动控制ToolStripMenuItem"
        Me.手动控制ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.手动控制ToolStripMenuItem.Text = "手动控制"
        '
        '系统设定ToolStripMenuItem
        '
        Me.系统设定ToolStripMenuItem.Name = "系统设定ToolStripMenuItem"
        Me.系统设定ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.系统设定ToolStripMenuItem.Text = "系统设定"
        Me.系统设定ToolStripMenuItem.Visible = False
        '
        'IOToolStripMenuItem
        '
        Me.IOToolStripMenuItem.Name = "IOToolStripMenuItem"
        Me.IOToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.IOToolStripMenuItem.Text = "IO"
        '
        '控制器ToolStripMenuItem
        '
        Me.控制器ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.校准轴比列ToolStripMenuItem, Me.配置ToolStripMenuItem})
        Me.控制器ToolStripMenuItem.Name = "控制器ToolStripMenuItem"
        Me.控制器ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.控制器ToolStripMenuItem.Text = "控制器配置"
        '
        '校准轴比列ToolStripMenuItem
        '
        Me.校准轴比列ToolStripMenuItem.Name = "校准轴比列ToolStripMenuItem"
        Me.校准轴比列ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.校准轴比列ToolStripMenuItem.Text = "校准轴比列"
        '
        '配置ToolStripMenuItem
        '
        Me.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem"
        Me.配置ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.配置ToolStripMenuItem.Text = "配置"
        '
        '校正光谱ToolStripMenuItem
        '
        Me.校正光谱ToolStripMenuItem.Name = "校正光谱ToolStripMenuItem"
        Me.校正光谱ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.校正光谱ToolStripMenuItem.Text = "校正光谱"
        Me.校正光谱ToolStripMenuItem.Visible = False
        '
        '电源测试ToolStripMenuItem
        '
        Me.电源测试ToolStripMenuItem.Name = "电源测试ToolStripMenuItem"
        Me.电源测试ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.电源测试ToolStripMenuItem.Text = "电源测试"
        '
        '打开监控ToolStripMenuItem
        '
        Me.打开监控ToolStripMenuItem.Name = "打开监控ToolStripMenuItem"
        Me.打开监控ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.打开监控ToolStripMenuItem.Text = "打开监控"
        Me.打开监控ToolStripMenuItem.Visible = False
        '
        '历史数据ToolStripMenuItem
        '
        Me.历史数据ToolStripMenuItem.Image = CType(resources.GetObject("历史数据ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.历史数据ToolStripMenuItem.Name = "历史数据ToolStripMenuItem"
        Me.历史数据ToolStripMenuItem.Size = New System.Drawing.Size(92, 28)
        Me.历史数据ToolStripMenuItem.Text = "历史数据"
        Me.历史数据ToolStripMenuItem.Visible = False
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.帮助ToolStripMenuItem.Text = "语言选择"
        Me.帮助ToolStripMenuItem.Visible = False
        '
        'GBoxPower
        '
        Me.GBoxPower.Location = New System.Drawing.Point(581, 33)
        Me.GBoxPower.Name = "GBoxPower"
        Me.GBoxPower.Size = New System.Drawing.Size(11, 10)
        Me.GBoxPower.TabIndex = 126
        Me.GBoxPower.TabStop = False
        Me.GBoxPower.Text = "功率值"
        Me.GBoxPower.Visible = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(273, 111)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton3.TabIndex = 105
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Org"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(273, 89)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(29, 16)
        Me.RadioButton2.TabIndex = 104
        Me.RadioButton2.Text = "w"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(273, 69)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton1.TabIndex = 103
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "dbm"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(500, 34)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 16)
        Me.Label22.TabIndex = 102
        Me.Label22.Text = "mA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(147, 34)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 16)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "dBm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(80, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "通道A"
        '
        'lblAPower
        '
        Me.lblAPower.BackColor = System.Drawing.SystemColors.Control
        Me.lblAPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAPower.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAPower.Font = New System.Drawing.Font("宋体", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblAPower.ForeColor = System.Drawing.Color.Blue
        Me.lblAPower.Location = New System.Drawing.Point(23, 50)
        Me.lblAPower.Name = "lblAPower"
        Me.lblAPower.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAPower.Size = New System.Drawing.Size(244, 92)
        Me.lblAPower.TabIndex = 66
        Me.lblAPower.Text = "asdasd"
        Me.lblAPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBPower
        '
        Me.lblBPower.BackColor = System.Drawing.SystemColors.Control
        Me.lblBPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBPower.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBPower.Font = New System.Drawing.Font("宋体", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblBPower.ForeColor = System.Drawing.Color.Red
        Me.lblBPower.Location = New System.Drawing.Point(320, 51)
        Me.lblBPower.Name = "lblBPower"
        Me.lblBPower.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBPower.Size = New System.Drawing.Size(248, 92)
        Me.lblBPower.TabIndex = 68
        Me.lblBPower.Text = "ddddd"
        Me.lblBPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(425, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 18)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "通道B"
        '
        'GBoxFlow
        '
        Me.GBoxFlow.Controls.Add(Me.TabControl4)
        Me.GBoxFlow.Controls.Add(Me.cbCmdStatus)
        Me.GBoxFlow.Controls.Add(Me.BtnCmdStep)
        Me.GBoxFlow.Controls.Add(Me.BtnNextStep)
        Me.GBoxFlow.Controls.Add(Me.btnPerStep)
        Me.GBoxFlow.Controls.Add(Me.flowPartGBox1)
        Me.GBoxFlow.Location = New System.Drawing.Point(12, 501)
        Me.GBoxFlow.Name = "GBoxFlow"
        Me.GBoxFlow.Size = New System.Drawing.Size(581, 241)
        Me.GBoxFlow.TabIndex = 130
        Me.GBoxFlow.TabStop = False
        Me.GBoxFlow.Text = "流程"
        '
        'TabControl4
        '
        Me.TabControl4.Controls.Add(Me.TabPage10)
        Me.TabControl4.Location = New System.Drawing.Point(7, 98)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(547, 128)
        Me.TabControl4.TabIndex = 124
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.listView1)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(539, 102)
        Me.TabPage10.TabIndex = 0
        Me.TabPage10.Text = "流程"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'listView1
        '
        Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView1.FullRowSelect = True
        Me.listView1.GridLines = True
        Me.listView1.Location = New System.Drawing.Point(3, 3)
        Me.listView1.MultiSelect = False
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(533, 96)
        Me.listView1.TabIndex = 45
        Me.listView1.UseCompatibleStateImageBehavior = False
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'cbCmdStatus
        '
        Me.cbCmdStatus.FormattingEnabled = True
        Me.cbCmdStatus.Location = New System.Drawing.Point(321, 182)
        Me.cbCmdStatus.Name = "cbCmdStatus"
        Me.cbCmdStatus.Size = New System.Drawing.Size(150, 20)
        Me.cbCmdStatus.TabIndex = 123
        '
        'BtnCmdStep
        '
        Me.BtnCmdStep.Location = New System.Drawing.Point(240, 176)
        Me.BtnCmdStep.Name = "BtnCmdStep"
        Me.BtnCmdStep.Size = New System.Drawing.Size(75, 30)
        Me.BtnCmdStep.TabIndex = 122
        Me.BtnCmdStep.Text = "命令指令"
        Me.BtnCmdStep.UseVisualStyleBackColor = True
        '
        'BtnNextStep
        '
        Me.BtnNextStep.Location = New System.Drawing.Point(117, 176)
        Me.BtnNextStep.Name = "BtnNextStep"
        Me.BtnNextStep.Size = New System.Drawing.Size(65, 30)
        Me.BtnNextStep.TabIndex = 121
        Me.BtnNextStep.Text = "上一步"
        Me.BtnNextStep.UseVisualStyleBackColor = True
        '
        'btnPerStep
        '
        Me.btnPerStep.Location = New System.Drawing.Point(25, 176)
        Me.btnPerStep.Name = "btnPerStep"
        Me.btnPerStep.Size = New System.Drawing.Size(65, 30)
        Me.btnPerStep.TabIndex = 120
        Me.btnPerStep.Text = "上一步"
        Me.btnPerStep.UseVisualStyleBackColor = True
        '
        'flowPartGBox1
        '
        Me.flowPartGBox1.Controls.Add(Me.lsLog)
        Me.flowPartGBox1.Controls.Add(Me.cmbFlowChart)
        Me.flowPartGBox1.Controls.Add(Me.Label18)
        Me.flowPartGBox1.Controls.Add(Me.CurOperLabel)
        Me.flowPartGBox1.Controls.Add(Me.ChangFlowBtn)
        Me.flowPartGBox1.Controls.Add(Me.Label4)
        Me.flowPartGBox1.Controls.Add(Me.ListBox1)
        Me.flowPartGBox1.Location = New System.Drawing.Point(8, 13)
        Me.flowPartGBox1.Name = "flowPartGBox1"
        Me.flowPartGBox1.Size = New System.Drawing.Size(560, 85)
        Me.flowPartGBox1.TabIndex = 118
        Me.flowPartGBox1.TabStop = False
        '
        'lsLog
        '
        Me.lsLog.FormattingEnabled = True
        Me.lsLog.ItemHeight = 12
        Me.lsLog.Location = New System.Drawing.Point(330, 58)
        Me.lsLog.Name = "lsLog"
        Me.lsLog.Size = New System.Drawing.Size(119, 28)
        Me.lsLog.TabIndex = 0
        Me.lsLog.Visible = False
        '
        'cmbFlowChart
        '
        Me.cmbFlowChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlowChart.FormattingEnabled = True
        Me.cmbFlowChart.Location = New System.Drawing.Point(112, 11)
        Me.cmbFlowChart.Name = "cmbFlowChart"
        Me.cmbFlowChart.Size = New System.Drawing.Size(351, 20)
        Me.cmbFlowChart.TabIndex = 105
        Me.cmbFlowChart.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 43)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 14)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "当前操作"
        '
        'CurOperLabel
        '
        Me.CurOperLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CurOperLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CurOperLabel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurOperLabel.ForeColor = System.Drawing.Color.Blue
        Me.CurOperLabel.Location = New System.Drawing.Point(114, 40)
        Me.CurOperLabel.Name = "CurOperLabel"
        Me.CurOperLabel.Size = New System.Drawing.Size(390, 32)
        Me.CurOperLabel.TabIndex = 116
        Me.CurOperLabel.Text = "..................................."
        Me.CurOperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChangFlowBtn
        '
        Me.ChangFlowBtn.Location = New System.Drawing.Point(488, 11)
        Me.ChangFlowBtn.Name = "ChangFlowBtn"
        Me.ChangFlowBtn.Size = New System.Drawing.Size(66, 23)
        Me.ChangFlowBtn.TabIndex = 114
        Me.ChangFlowBtn.Text = "导入流程"
        Me.ChangFlowBtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "操作流程"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(388, 9)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(175, 16)
        Me.ListBox1.TabIndex = 119
        Me.ListBox1.Visible = False
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(-20, 148)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(75, 23)
        Me.Button20.TabIndex = 142
        Me.Button20.UseVisualStyleBackColor = True
        Me.Button20.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(93, 147)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(147, 23)
        Me.ProgressBar1.TabIndex = 117
        Me.ProgressBar1.Visible = False
        '
        'StateGBox
        '
        Me.StateGBox.Controls.Add(Me.CheckBox7)
        Me.StateGBox.Controls.Add(Me.RichTextBox1)
        Me.StateGBox.Controls.Add(Me.Button5)
        Me.StateGBox.Controls.Add(Me.Button4)
        Me.StateGBox.Controls.Add(Me.Button3)
        Me.StateGBox.Controls.Add(Me.Button2)
        Me.StateGBox.Location = New System.Drawing.Point(2, 126)
        Me.StateGBox.Name = "StateGBox"
        Me.StateGBox.Size = New System.Drawing.Size(503, 513)
        Me.StateGBox.TabIndex = 133
        Me.StateGBox.TabStop = False
        Me.StateGBox.Text = "Status"
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(57, 448)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox7.TabIndex = 178
        Me.CheckBox7.UseVisualStyleBackColor = True
        Me.CheckBox7.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(300, 417)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(21, 12)
        Me.RichTextBox1.TabIndex = 140
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(158, 388)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(21, 18)
        Me.Button5.TabIndex = 139
        Me.Button5.Text = "UV"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(50, 400)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 29)
        Me.Button4.TabIndex = 138
        Me.Button4.Text = "点胶机"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 417)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(12, 16)
        Me.Button3.TabIndex = 137
        Me.Button3.Text = "点胶针头"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(34, 419)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(10, 10)
        Me.Button2.TabIndex = 136
        Me.Button2.Text = "PD"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TabControl5
        '
        Me.TabControl5.Controls.Add(Me.TabPage11)
        Me.TabControl5.Controls.Add(Me.TabPage14)
        Me.TabControl5.Controls.Add(Me.TabPage17)
        Me.TabControl5.Location = New System.Drawing.Point(599, 131)
        Me.TabControl5.Name = "TabControl5"
        Me.TabControl5.SelectedIndex = 0
        Me.TabControl5.Size = New System.Drawing.Size(497, 440)
        Me.TabControl5.TabIndex = 142
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.GroupBox1)
        Me.TabPage11.Controls.Add(Me.GroupBox3)
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(489, 414)
        Me.TabPage11.TabIndex = 0
        Me.TabPage11.Text = "控制"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Axis_6)
        Me.GroupBox1.Controls.Add(Me.Button20)
        Me.GroupBox1.Controls.Add(Me.btnReadMiorrfile)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.BtnSaveMiorrfile)
        Me.GroupBox1.Controls.Add(Me.btnGoMirrorPos)
        Me.GroupBox1.Controls.Add(Me.Axis_5)
        Me.GroupBox1.Controls.Add(Me.Axis_4)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 190)
        Me.GroupBox1.TabIndex = 180
        Me.GroupBox1.TabStop = False
        '
        'Axis_6
        '
        Me.Axis_6.AxisIndex = 0
        Me.Axis_6.AxisName = "0"
        Me.Axis_6.cbstatus = False
        Me.Axis_6.Location = New System.Drawing.Point(5, 104)
        Me.Axis_6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_6.Name = "Axis_6"
        Me.Axis_6.OrderIndex = 0
        Me.Axis_6.SetCbtxt = "0"
        Me.Axis_6.Size = New System.Drawing.Size(487, 45)
        Me.Axis_6.TabIndex = 1
        '
        'btnReadMiorrfile
        '
        Me.btnReadMiorrfile.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadMiorrfile.Location = New System.Drawing.Point(246, 149)
        Me.btnReadMiorrfile.Name = "btnReadMiorrfile"
        Me.btnReadMiorrfile.Size = New System.Drawing.Size(74, 34)
        Me.btnReadMiorrfile.TabIndex = 137
        Me.btnReadMiorrfile.Text = "读文件"
        Me.btnReadMiorrfile.UseVisualStyleBackColor = True
        '
        'BtnSaveMiorrfile
        '
        Me.BtnSaveMiorrfile.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveMiorrfile.Location = New System.Drawing.Point(326, 149)
        Me.BtnSaveMiorrfile.Name = "BtnSaveMiorrfile"
        Me.BtnSaveMiorrfile.Size = New System.Drawing.Size(74, 34)
        Me.BtnSaveMiorrfile.TabIndex = 136
        Me.BtnSaveMiorrfile.Text = "保存"
        Me.BtnSaveMiorrfile.UseVisualStyleBackColor = True
        '
        'btnGoMirrorPos
        '
        Me.btnGoMirrorPos.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoMirrorPos.Location = New System.Drawing.Point(407, 149)
        Me.btnGoMirrorPos.Name = "btnGoMirrorPos"
        Me.btnGoMirrorPos.Size = New System.Drawing.Size(73, 34)
        Me.btnGoMirrorPos.TabIndex = 135
        Me.btnGoMirrorPos.Text = "Go"
        Me.btnGoMirrorPos.UseVisualStyleBackColor = True
        '
        'Axis_5
        '
        Me.Axis_5.AxisIndex = 0
        Me.Axis_5.AxisName = "0"
        Me.Axis_5.cbstatus = False
        Me.Axis_5.Location = New System.Drawing.Point(5, 58)
        Me.Axis_5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_5.Name = "Axis_5"
        Me.Axis_5.OrderIndex = 0
        Me.Axis_5.SetCbtxt = "0"
        Me.Axis_5.Size = New System.Drawing.Size(479, 51)
        Me.Axis_5.TabIndex = 4
        '
        'Axis_4
        '
        Me.Axis_4.AxisIndex = 0
        Me.Axis_4.AxisName = "0"
        Me.Axis_4.cbstatus = False
        Me.Axis_4.Location = New System.Drawing.Point(2, 14)
        Me.Axis_4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_4.Name = "Axis_4"
        Me.Axis_4.OrderIndex = 0
        Me.Axis_4.SetCbtxt = "0"
        Me.Axis_4.Size = New System.Drawing.Size(483, 46)
        Me.Axis_4.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Axis_2)
        Me.GroupBox3.Controls.Add(Me.btnReadLensfile)
        Me.GroupBox3.Controls.Add(Me.Button10)
        Me.GroupBox3.Controls.Add(Me.BtnSaveLensfile)
        Me.GroupBox3.Controls.Add(Me.btnGoLensPos)
        Me.GroupBox3.Controls.Add(Me.Axis_1)
        Me.GroupBox3.Controls.Add(Me.Axis_3)
        Me.GroupBox3.Controls.Add(Me.Axis_0)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(491, 205)
        Me.GroupBox3.TabIndex = 134
        Me.GroupBox3.TabStop = False
        '
        'Axis_2
        '
        Me.Axis_2.AxisIndex = 0
        Me.Axis_2.AxisName = "0"
        Me.Axis_2.cbstatus = False
        Me.Axis_2.Location = New System.Drawing.Point(4, 99)
        Me.Axis_2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_2.Name = "Axis_2"
        Me.Axis_2.OrderIndex = 0
        Me.Axis_2.SetCbtxt = "0"
        Me.Axis_2.Size = New System.Drawing.Size(487, 45)
        Me.Axis_2.TabIndex = 1
        '
        'btnReadLensfile
        '
        Me.btnReadLensfile.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadLensfile.Location = New System.Drawing.Point(225, 154)
        Me.btnReadLensfile.Name = "btnReadLensfile"
        Me.btnReadLensfile.Size = New System.Drawing.Size(74, 34)
        Me.btnReadLensfile.TabIndex = 137
        Me.btnReadLensfile.Text = "读文件"
        Me.btnReadLensfile.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(26, 146)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(73, 28)
        Me.Button10.TabIndex = 141
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'BtnSaveLensfile
        '
        Me.BtnSaveLensfile.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveLensfile.Location = New System.Drawing.Point(305, 154)
        Me.BtnSaveLensfile.Name = "BtnSaveLensfile"
        Me.BtnSaveLensfile.Size = New System.Drawing.Size(74, 34)
        Me.BtnSaveLensfile.TabIndex = 136
        Me.BtnSaveLensfile.Text = "保存"
        Me.BtnSaveLensfile.UseVisualStyleBackColor = True
        '
        'btnGoLensPos
        '
        Me.btnGoLensPos.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoLensPos.Location = New System.Drawing.Point(385, 153)
        Me.btnGoLensPos.Name = "btnGoLensPos"
        Me.btnGoLensPos.Size = New System.Drawing.Size(73, 34)
        Me.btnGoLensPos.TabIndex = 135
        Me.btnGoLensPos.Text = "Go"
        Me.btnGoLensPos.UseVisualStyleBackColor = True
        '
        'Axis_1
        '
        Me.Axis_1.AxisIndex = 0
        Me.Axis_1.AxisName = "0"
        Me.Axis_1.cbstatus = False
        Me.Axis_1.Location = New System.Drawing.Point(3, 56)
        Me.Axis_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_1.Name = "Axis_1"
        Me.Axis_1.OrderIndex = 0
        Me.Axis_1.SetCbtxt = "0"
        Me.Axis_1.Size = New System.Drawing.Size(479, 51)
        Me.Axis_1.TabIndex = 4
        '
        'Axis_3
        '
        Me.Axis_3.AxisIndex = 0
        Me.Axis_3.AxisName = "0"
        Me.Axis_3.cbstatus = False
        Me.Axis_3.Location = New System.Drawing.Point(474, 143)
        Me.Axis_3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_3.Name = "Axis_3"
        Me.Axis_3.OrderIndex = 0
        Me.Axis_3.SetCbtxt = "0"
        Me.Axis_3.Size = New System.Drawing.Size(10, 44)
        Me.Axis_3.TabIndex = 3
        Me.Axis_3.Visible = False
        '
        'Axis_0
        '
        Me.Axis_0.AxisIndex = 0
        Me.Axis_0.AxisName = "0"
        Me.Axis_0.cbstatus = False
        Me.Axis_0.Location = New System.Drawing.Point(2, 14)
        Me.Axis_0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Axis_0.Name = "Axis_0"
        Me.Axis_0.OrderIndex = 0
        Me.Axis_0.SetCbtxt = "0"
        Me.Axis_0.Size = New System.Drawing.Size(483, 46)
        Me.Axis_0.TabIndex = 0
        '
        'TabPage14
        '
        Me.TabPage14.Controls.Add(Me.GroupBox4)
        Me.TabPage14.Location = New System.Drawing.Point(4, 22)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage14.Size = New System.Drawing.Size(489, 414)
        Me.TabPage14.TabIndex = 1
        Me.TabPage14.Text = "数据"
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label101)
        Me.GroupBox4.Controls.Add(Me.Label100)
        Me.GroupBox4.Controls.Add(Me.Label99)
        Me.GroupBox4.Controls.Add(Me.Label98)
        Me.GroupBox4.Controls.Add(Me.Label97)
        Me.GroupBox4.Controls.Add(Me.Label96)
        Me.GroupBox4.Controls.Add(Me.Label95)
        Me.GroupBox4.Controls.Add(Me.Label94)
        Me.GroupBox4.Controls.Add(Me.Label61)
        Me.GroupBox4.Controls.Add(Me.Button24)
        Me.GroupBox4.Controls.Add(Me.DataRemake)
        Me.GroupBox4.Controls.Add(Me.Label91)
        Me.GroupBox4.Controls.Add(Me.MeachineNo)
        Me.GroupBox4.Controls.Add(Me.Label90)
        Me.GroupBox4.Controls.Add(Me.cbWorkSatus)
        Me.GroupBox4.Controls.Add(Me.Label89)
        Me.GroupBox4.Controls.Add(Me.cbErrorType)
        Me.GroupBox4.Controls.Add(Me.Label88)
        Me.GroupBox4.Controls.Add(Me.DpOpenTime2)
        Me.GroupBox4.Controls.Add(Me.HotEndTime)
        Me.GroupBox4.Controls.Add(Me.HotStartTime)
        Me.GroupBox4.Controls.Add(Me.OpWorkData2)
        Me.GroupBox4.Controls.Add(Me.OpWokeData1)
        Me.GroupBox4.Controls.Add(Me.Label70)
        Me.GroupBox4.Controls.Add(Me.Label69)
        Me.GroupBox4.Controls.Add(Me.Label68)
        Me.GroupBox4.Controls.Add(Me.Label67)
        Me.GroupBox4.Controls.Add(Me.Label66)
        Me.GroupBox4.Controls.Add(Me.Label65)
        Me.GroupBox4.Controls.Add(Me.Label64)
        Me.GroupBox4.Controls.Add(Me.Label87)
        Me.GroupBox4.Controls.Add(Me.Label63)
        Me.GroupBox4.Controls.Add(Me.Label86)
        Me.GroupBox4.Controls.Add(Me.Label85)
        Me.GroupBox4.Controls.Add(Me.DpOpenTime1)
        Me.GroupBox4.Controls.Add(Me.Label84)
        Me.GroupBox4.Controls.Add(Me.DpTypeNo)
        Me.GroupBox4.Controls.Add(Me.Label83)
        Me.GroupBox4.Controls.Add(Me.DpLotNo)
        Me.GroupBox4.Controls.Add(Me.Label82)
        Me.GroupBox4.Controls.Add(Me.MirrorLotNo)
        Me.GroupBox4.Controls.Add(Me.Label73)
        Me.GroupBox4.Controls.Add(Me.OpeterNo)
        Me.GroupBox4.Controls.Add(Me.Label72)
        Me.GroupBox4.Controls.Add(Me.SN)
        Me.GroupBox4.Controls.Add(Me.Label71)
        Me.GroupBox4.Controls.Add(Me.r_9)
        Me.GroupBox4.Controls.Add(Me.r_8)
        Me.GroupBox4.Controls.Add(Me.r_7)
        Me.GroupBox4.Controls.Add(Me.r_6)
        Me.GroupBox4.Controls.Add(Me.r_5)
        Me.GroupBox4.Controls.Add(Me.r_4)
        Me.GroupBox4.Controls.Add(Me.r_3)
        Me.GroupBox4.Controls.Add(Me.r_2)
        Me.GroupBox4.Controls.Add(Me.R_1)
        Me.GroupBox4.Controls.Add(Me.Label62)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(483, 408)
        Me.GroupBox4.TabIndex = 141
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "数据"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label101.Location = New System.Drawing.Point(362, 273)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(53, 12)
        Me.Label101.TabIndex = 66
        Me.Label101.Text = "Label101"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label100.Location = New System.Drawing.Point(221, 276)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(53, 12)
        Me.Label100.TabIndex = 65
        Me.Label100.Text = "Label100"
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label99.Location = New System.Drawing.Point(67, 276)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(47, 12)
        Me.Label99.TabIndex = 64
        Me.Label99.Text = "Label99"
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label98.Location = New System.Drawing.Point(362, 233)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(47, 12)
        Me.Label98.TabIndex = 63
        Me.Label98.Text = "Label98"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label97.Location = New System.Drawing.Point(225, 235)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(47, 12)
        Me.Label97.TabIndex = 62
        Me.Label97.Text = "Label97"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label96.Location = New System.Drawing.Point(67, 235)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(47, 12)
        Me.Label96.TabIndex = 61
        Me.Label96.Text = "Label96"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label95.Location = New System.Drawing.Point(362, 193)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(47, 12)
        Me.Label95.TabIndex = 60
        Me.Label95.Text = "Label95"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label94.Location = New System.Drawing.Point(225, 193)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(47, 12)
        Me.Label94.TabIndex = 59
        Me.Label94.Text = "Label94"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label61.Location = New System.Drawing.Point(67, 193)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(47, 12)
        Me.Label61.TabIndex = 58
        Me.Label61.Text = "Label61"
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(356, 377)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(110, 29)
        Me.Button24.TabIndex = 57
        Me.Button24.Text = "手动录入"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'DataRemake
        '
        Me.DataRemake.Location = New System.Drawing.Point(321, 326)
        Me.DataRemake.Multiline = True
        Me.DataRemake.Name = "DataRemake"
        Me.DataRemake.Size = New System.Drawing.Size(147, 47)
        Me.DataRemake.TabIndex = 56
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label91.Location = New System.Drawing.Point(270, 335)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(56, 16)
        Me.Label91.TabIndex = 55
        Me.Label91.Text = "备注："
        '
        'MeachineNo
        '
        Me.MeachineNo.BackColor = System.Drawing.Color.White
        Me.MeachineNo.Enabled = False
        Me.MeachineNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MeachineNo.Location = New System.Drawing.Point(114, 420)
        Me.MeachineNo.Name = "MeachineNo"
        Me.MeachineNo.Size = New System.Drawing.Size(220, 26)
        Me.MeachineNo.TabIndex = 54
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label90.Location = New System.Drawing.Point(14, 423)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(96, 16)
        Me.Label90.TabIndex = 53
        Me.Label90.Text = "工作机台号:"
        '
        'cbWorkSatus
        '
        Me.cbWorkSatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWorkSatus.FormattingEnabled = True
        Me.cbWorkSatus.Location = New System.Drawing.Point(100, 377)
        Me.cbWorkSatus.Name = "cbWorkSatus"
        Me.cbWorkSatus.Size = New System.Drawing.Size(154, 29)
        Me.cbWorkSatus.TabIndex = 52
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label89.Location = New System.Drawing.Point(14, 384)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(80, 16)
        Me.Label89.TabIndex = 51
        Me.Label89.Text = "工作状态:"
        '
        'cbErrorType
        '
        Me.cbErrorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbErrorType.FormattingEnabled = True
        Me.cbErrorType.Location = New System.Drawing.Point(100, 335)
        Me.cbErrorType.Name = "cbErrorType"
        Me.cbErrorType.Size = New System.Drawing.Size(154, 29)
        Me.cbErrorType.TabIndex = 50
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label88.Location = New System.Drawing.Point(14, 342)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(80, 16)
        Me.Label88.TabIndex = 49
        Me.Label88.Text = "不良类型:"
        '
        'DpOpenTime2
        '
        Me.DpOpenTime2.CustomFormat = "HH:mm:ss"
        Me.DpOpenTime2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DpOpenTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpOpenTime2.Location = New System.Drawing.Point(215, 102)
        Me.DpOpenTime2.Name = "DpOpenTime2"
        Me.DpOpenTime2.ShowUpDown = True
        Me.DpOpenTime2.Size = New System.Drawing.Size(71, 21)
        Me.DpOpenTime2.TabIndex = 48
        '
        'HotEndTime
        '
        Me.HotEndTime.CustomFormat = "HH:mm:ss"
        Me.HotEndTime.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.HotEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HotEndTime.Location = New System.Drawing.Point(363, 135)
        Me.HotEndTime.Name = "HotEndTime"
        Me.HotEndTime.ShowUpDown = True
        Me.HotEndTime.Size = New System.Drawing.Size(71, 21)
        Me.HotEndTime.TabIndex = 47
        '
        'HotStartTime
        '
        Me.HotStartTime.CustomFormat = "HH:mm:ss"
        Me.HotStartTime.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.HotStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HotStartTime.Location = New System.Drawing.Point(124, 136)
        Me.HotStartTime.Name = "HotStartTime"
        Me.HotStartTime.ShowUpDown = True
        Me.HotStartTime.Size = New System.Drawing.Size(71, 21)
        Me.HotStartTime.TabIndex = 46
        '
        'OpWorkData2
        '
        Me.OpWorkData2.CustomFormat = "HH:mm:ss"
        Me.OpWorkData2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpWorkData2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.OpWorkData2.Location = New System.Drawing.Point(397, 295)
        Me.OpWorkData2.Name = "OpWorkData2"
        Me.OpWorkData2.ShowUpDown = True
        Me.OpWorkData2.Size = New System.Drawing.Size(71, 21)
        Me.OpWorkData2.TabIndex = 45
        '
        'OpWokeData1
        '
        Me.OpWokeData1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpWokeData1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.OpWokeData1.Location = New System.Drawing.Point(312, 295)
        Me.OpWokeData1.Name = "OpWokeData1"
        Me.OpWokeData1.Size = New System.Drawing.Size(79, 21)
        Me.OpWokeData1.TabIndex = 44
        Me.OpWokeData1.Value = New Date(2017, 2, 25, 16, 43, 0, 0)
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label70.Location = New System.Drawing.Point(212, 297)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(88, 16)
        Me.Label70.TabIndex = 43
        Me.Label70.Text = "操作时间："
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label69.Location = New System.Drawing.Point(311, 253)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(49, 14)
        Me.Label69.TabIndex = 42
        Me.Label69.Text = "COS9："
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label68.Location = New System.Drawing.Point(12, 216)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(49, 14)
        Me.Label68.TabIndex = 41
        Me.Label68.Text = "COS4："
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label67.Location = New System.Drawing.Point(161, 213)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(49, 14)
        Me.Label67.TabIndex = 40
        Me.Label67.Text = "COS5："
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label66.Location = New System.Drawing.Point(312, 213)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(49, 14)
        Me.Label66.TabIndex = 39
        Me.Label66.Text = "COS6："
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label65.Location = New System.Drawing.Point(11, 255)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(49, 14)
        Me.Label65.TabIndex = 38
        Me.Label65.Text = "COS7："
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label64.Location = New System.Drawing.Point(161, 251)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(49, 14)
        Me.Label64.TabIndex = 37
        Me.Label64.Text = "COS8："
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label87.Location = New System.Drawing.Point(309, 173)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(49, 14)
        Me.Label87.TabIndex = 36
        Me.Label87.Text = "COS3："
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label63.Location = New System.Drawing.Point(160, 173)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(49, 14)
        Me.Label63.TabIndex = 35
        Me.Label63.Text = "COS2："
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label86.Location = New System.Drawing.Point(246, 137)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(120, 16)
        Me.Label86.TabIndex = 33
        Me.Label86.Text = "烘烤结束时间："
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label85.Location = New System.Drawing.Point(8, 138)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(120, 16)
        Me.Label85.TabIndex = 31
        Me.Label85.Text = "烘烤开始时间："
        '
        'DpOpenTime1
        '
        Me.DpOpenTime1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DpOpenTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DpOpenTime1.Location = New System.Drawing.Point(123, 103)
        Me.DpOpenTime1.Name = "DpOpenTime1"
        Me.DpOpenTime1.Size = New System.Drawing.Size(79, 21)
        Me.DpOpenTime1.TabIndex = 29
        Me.DpOpenTime1.Value = New Date(2017, 2, 25, 16, 43, 0, 0)
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label84.Location = New System.Drawing.Point(8, 106)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(120, 16)
        Me.Label84.TabIndex = 28
        Me.Label84.Text = "胶水打开时间："
        '
        'DpTypeNo
        '
        Me.DpTypeNo.BackColor = System.Drawing.Color.White
        Me.DpTypeNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DpTypeNo.Location = New System.Drawing.Point(322, 62)
        Me.DpTypeNo.Multiline = True
        Me.DpTypeNo.Name = "DpTypeNo"
        Me.DpTypeNo.Size = New System.Drawing.Size(123, 28)
        Me.DpTypeNo.TabIndex = 27
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label83.Location = New System.Drawing.Point(230, 65)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(80, 16)
        Me.Label83.TabIndex = 26
        Me.Label83.Text = "胶水型号:"
        '
        'DpLotNo
        '
        Me.DpLotNo.BackColor = System.Drawing.Color.White
        Me.DpLotNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DpLotNo.Location = New System.Drawing.Point(99, 62)
        Me.DpLotNo.Multiline = True
        Me.DpLotNo.Name = "DpLotNo"
        Me.DpLotNo.Size = New System.Drawing.Size(105, 28)
        Me.DpLotNo.TabIndex = 25
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label82.Location = New System.Drawing.Point(7, 67)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(80, 16)
        Me.Label82.TabIndex = 24
        Me.Label82.Text = "胶水批次:"
        '
        'MirrorLotNo
        '
        Me.MirrorLotNo.BackColor = System.Drawing.Color.White
        Me.MirrorLotNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MirrorLotNo.Location = New System.Drawing.Point(322, 19)
        Me.MirrorLotNo.Multiline = True
        Me.MirrorLotNo.Name = "MirrorLotNo"
        Me.MirrorLotNo.Size = New System.Drawing.Size(123, 31)
        Me.MirrorLotNo.TabIndex = 23
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label73.Location = New System.Drawing.Point(220, 26)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(96, 16)
        Me.Label73.TabIndex = 22
        Me.Label73.Text = "反射镜批次:"
        '
        'OpeterNo
        '
        Me.OpeterNo.BackColor = System.Drawing.Color.White
        Me.OpeterNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpeterNo.Location = New System.Drawing.Point(76, 291)
        Me.OpeterNo.Name = "OpeterNo"
        Me.OpeterNo.Size = New System.Drawing.Size(109, 26)
        Me.OpeterNo.TabIndex = 21
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label72.Location = New System.Drawing.Point(11, 298)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(64, 16)
        Me.Label72.TabIndex = 20
        Me.Label72.Text = "操作者:"
        '
        'SN
        '
        Me.SN.BackColor = System.Drawing.Color.White
        Me.SN.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SN.Location = New System.Drawing.Point(100, 19)
        Me.SN.Multiline = True
        Me.SN.Name = "SN"
        Me.SN.Size = New System.Drawing.Size(104, 31)
        Me.SN.TabIndex = 19
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label71.Location = New System.Drawing.Point(6, 29)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(96, 16)
        Me.Label71.TabIndex = 18
        Me.Label71.Text = "器件序列号:"
        '
        'r_9
        '
        Me.r_9.BackColor = System.Drawing.Color.Lime
        Me.r_9.Enabled = False
        Me.r_9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_9.Location = New System.Drawing.Point(363, 248)
        Me.r_9.Multiline = True
        Me.r_9.Name = "r_9"
        Me.r_9.Size = New System.Drawing.Size(94, 21)
        Me.r_9.TabIndex = 17
        '
        'r_8
        '
        Me.r_8.BackColor = System.Drawing.Color.Lime
        Me.r_8.Enabled = False
        Me.r_8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_8.Location = New System.Drawing.Point(216, 250)
        Me.r_8.Multiline = True
        Me.r_8.Name = "r_8"
        Me.r_8.Size = New System.Drawing.Size(94, 21)
        Me.r_8.TabIndex = 16
        '
        'r_7
        '
        Me.r_7.BackColor = System.Drawing.Color.Lime
        Me.r_7.Enabled = False
        Me.r_7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_7.Location = New System.Drawing.Point(60, 250)
        Me.r_7.Multiline = True
        Me.r_7.Name = "r_7"
        Me.r_7.Size = New System.Drawing.Size(94, 21)
        Me.r_7.TabIndex = 15
        '
        'r_6
        '
        Me.r_6.BackColor = System.Drawing.Color.Lime
        Me.r_6.Enabled = False
        Me.r_6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_6.Location = New System.Drawing.Point(364, 209)
        Me.r_6.Multiline = True
        Me.r_6.Name = "r_6"
        Me.r_6.Size = New System.Drawing.Size(94, 21)
        Me.r_6.TabIndex = 14
        '
        'r_5
        '
        Me.r_5.BackColor = System.Drawing.Color.Lime
        Me.r_5.Enabled = False
        Me.r_5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_5.Location = New System.Drawing.Point(217, 209)
        Me.r_5.Multiline = True
        Me.r_5.Name = "r_5"
        Me.r_5.Size = New System.Drawing.Size(94, 21)
        Me.r_5.TabIndex = 13
        '
        'r_4
        '
        Me.r_4.BackColor = System.Drawing.Color.Lime
        Me.r_4.Enabled = False
        Me.r_4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_4.Location = New System.Drawing.Point(61, 208)
        Me.r_4.Multiline = True
        Me.r_4.Name = "r_4"
        Me.r_4.Size = New System.Drawing.Size(94, 21)
        Me.r_4.TabIndex = 12
        '
        'r_3
        '
        Me.r_3.BackColor = System.Drawing.Color.Lime
        Me.r_3.Enabled = False
        Me.r_3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_3.Location = New System.Drawing.Point(364, 168)
        Me.r_3.Multiline = True
        Me.r_3.Name = "r_3"
        Me.r_3.Size = New System.Drawing.Size(94, 21)
        Me.r_3.TabIndex = 11
        '
        'r_2
        '
        Me.r_2.BackColor = System.Drawing.Color.Lime
        Me.r_2.Enabled = False
        Me.r_2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.r_2.Location = New System.Drawing.Point(215, 169)
        Me.r_2.Multiline = True
        Me.r_2.Name = "r_2"
        Me.r_2.Size = New System.Drawing.Size(94, 21)
        Me.r_2.TabIndex = 10
        '
        'R_1
        '
        Me.R_1.BackColor = System.Drawing.Color.Lime
        Me.R_1.Enabled = False
        Me.R_1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.R_1.Location = New System.Drawing.Point(60, 169)
        Me.R_1.Multiline = True
        Me.R_1.Name = "R_1"
        Me.R_1.Size = New System.Drawing.Size(94, 21)
        Me.R_1.TabIndex = 9
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label62.Location = New System.Drawing.Point(11, 171)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(49, 14)
        Me.Label62.TabIndex = 0
        Me.Label62.Text = "COS1："
        '
        'TabPage17
        '
        Me.TabPage17.Controls.Add(Me.ListBox2)
        Me.TabPage17.Location = New System.Drawing.Point(4, 22)
        Me.TabPage17.Name = "TabPage17"
        Me.TabPage17.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage17.Size = New System.Drawing.Size(489, 414)
        Me.TabPage17.TabIndex = 2
        Me.TabPage17.Text = "追踪日志"
        Me.TabPage17.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(3, 3)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(483, 408)
        Me.ListBox2.TabIndex = 25
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Off.jpg")
        Me.ImageList1.Images.SetKeyName(1, "On.jpg")
        Me.ImageList1.Images.SetKeyName(2, "yellow.jpg")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cmdRun)
        Me.GroupBox2.Controls.Add(Me.cmdReset)
        Me.GroupBox2.Controls.Add(Me.cmdNext)
        Me.GroupBox2.Controls.Add(Me.StateGBox)
        Me.GroupBox2.Location = New System.Drawing.Point(599, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 105)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "操作"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = Global.PumpLaser_Automation.My.Resources.Resources.原点1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(353, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 72)
        Me.Button1.TabIndex = 138
        Me.Button1.Text = "原点"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdRun
        '
        Me.cmdRun.BackColor = System.Drawing.Color.White
        Me.cmdRun.Image = Global.PumpLaser_Automation.My.Resources.Resources.开始2
        Me.cmdRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRun.Location = New System.Drawing.Point(6, 28)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(102, 72)
        Me.cmdRun.TabIndex = 58
        Me.cmdRun.Text = "运行"
        Me.cmdRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRun.UseVisualStyleBackColor = False
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.Color.White
        Me.cmdReset.Image = Global.PumpLaser_Automation.My.Resources.Resources.结束
        Me.cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReset.Location = New System.Drawing.Point(119, 28)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(103, 72)
        Me.cmdReset.TabIndex = 60
        Me.cmdReset.Text = "结束"
        Me.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdReset.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.White
        Me.cmdNext.Image = Global.PumpLaser_Automation.My.Resources.Resources.复位
        Me.cmdNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNext.Location = New System.Drawing.Point(234, 28)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(107, 72)
        Me.cmdNext.TabIndex = 57
        Me.cmdNext.Text = "复位"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "xml"
        Me.OpenFile.Filter = "程序檔|*.xml"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "xml"
        Me.SaveFile.Filter = "程序檔|*.xml"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(355, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Time："
        Me.Label13.Visible = False
        '
        'TxtSpanTime
        '
        Me.TxtSpanTime.Location = New System.Drawing.Point(399, 87)
        Me.TxtSpanTime.Name = "TxtSpanTime"
        Me.TxtSpanTime.Size = New System.Drawing.Size(85, 21)
        Me.TxtSpanTime.TabIndex = 136
        Me.TxtSpanTime.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage13)
        Me.TabControl1.Controls.Add(Me.TabPage15)
        Me.TabControl1.Location = New System.Drawing.Point(10, 169)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(585, 343)
        Me.TabControl1.TabIndex = 137
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label48)
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.GBoxPowerGra)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(577, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(19, 122)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(47, 12)
        Me.Label48.TabIndex = 138
        Me.Label48.Text = "Label48"
        Me.Label48.Visible = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage12)
        Me.TabControl2.Controls.Add(Me.TabPage16)
        Me.TabControl2.Controls.Add(Me.TabPage18)
        Me.TabControl2.Location = New System.Drawing.Point(3, 191)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(561, 116)
        Me.TabControl2.TabIndex = 137
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox26)
        Me.TabPage3.Controls.Add(Me.Label110)
        Me.TabPage3.Controls.Add(Me.btnsaScan)
        Me.TabPage3.Controls.Add(Me.TextBox25)
        Me.TabPage3.Controls.Add(Me.CheckBox6)
        Me.TabPage3.Controls.Add(Me.CheckBox5)
        Me.TabPage3.Controls.Add(Me.CheckBox4)
        Me.TabPage3.Controls.Add(Me.Label47)
        Me.TabPage3.Controls.Add(Me.Button11)
        Me.TabPage3.Controls.Add(Me.TxtIlret)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.CheckBox3)
        Me.TabPage3.Controls.Add(Me.CheckBox2)
        Me.TabPage3.Controls.Add(Me.CheckBox1)
        Me.TabPage3.Controls.Add(Me.ComboBox2)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.ComboBox1)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.cbChannel)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.TxtDelta)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.TxtPicth)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.TxtStep)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.cbAxisName)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Button7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(553, 90)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "对准"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(487, 33)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(52, 21)
        Me.TextBox26.TabIndex = 193
        Me.TextBox26.Text = "100"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(414, 36)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(41, 12)
        Me.Label110.TabIndex = 182
        Me.Label110.Text = "阈值："
        '
        'btnsaScan
        '
        Me.btnsaScan.Location = New System.Drawing.Point(482, 51)
        Me.btnsaScan.Name = "btnsaScan"
        Me.btnsaScan.Size = New System.Drawing.Size(63, 34)
        Me.btnsaScan.TabIndex = 180
        Me.btnsaScan.Text = "单轴对准"
        Me.btnsaScan.UseVisualStyleBackColor = True
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(413, 17)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(127, 21)
        Me.TextBox25.TabIndex = 178
        '
        'CheckBox6
        '
        Me.CheckBox6.Checked = True
        Me.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox6.Location = New System.Drawing.Point(378, 16)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(26, 24)
        Me.CheckBox6.TabIndex = 177
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.Checked = True
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.Location = New System.Drawing.Point(349, 16)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(26, 24)
        Me.CheckBox5.TabIndex = 176
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(317, 16)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(26, 24)
        Me.CheckBox4.TabIndex = 175
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(337, 3)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(53, 12)
        Me.Label47.TabIndex = 174
        Me.Label47.Text = "递归选择"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(413, 51)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(63, 34)
        Me.Button11.TabIndex = 173
        Me.Button11.Text = "手动对准"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'TxtIlret
        '
        Me.TxtIlret.Location = New System.Drawing.Point(184, 64)
        Me.TxtIlret.Name = "TxtIlret"
        Me.TxtIlret.Size = New System.Drawing.Size(52, 21)
        Me.TxtIlret.TabIndex = 172
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(195, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "递归："
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(281, 21)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 170
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(182, 21)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 169
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(86, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 168
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(205, 18)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox2.TabIndex = 167
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(214, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "对准轴："
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(106, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox1.TabIndex = 165
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "对准轴："
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(302, 64)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(93, 20)
        Me.cbChannel.TabIndex = 163
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(325, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "通道："
        '
        'TxtDelta
        '
        Me.TxtDelta.Location = New System.Drawing.Point(244, 63)
        Me.TxtDelta.Name = "TxtDelta"
        Me.TxtDelta.Size = New System.Drawing.Size(52, 21)
        Me.TxtDelta.TabIndex = 161
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(248, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "增量："
        '
        'TxtPicth
        '
        Me.TxtPicth.Location = New System.Drawing.Point(129, 64)
        Me.TxtPicth.Name = "TxtPicth"
        Me.TxtPicth.Size = New System.Drawing.Size(36, 21)
        Me.TxtPicth.TabIndex = 159
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(106, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 158
        Me.Label8.Text = "ChechPoint："
        '
        'TxtStep
        '
        Me.TxtStep.Location = New System.Drawing.Point(11, 64)
        Me.TxtStep.Name = "TxtStep"
        Me.TxtStep.Size = New System.Drawing.Size(100, 21)
        Me.TxtStep.TabIndex = 157
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Step："
        '
        'cbAxisName
        '
        Me.cbAxisName.FormattingEnabled = True
        Me.cbAxisName.Location = New System.Drawing.Point(11, 18)
        Me.cbAxisName.Name = "cbAxisName"
        Me.cbAxisName.Size = New System.Drawing.Size(72, 20)
        Me.cbAxisName.TabIndex = 155
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "对准轴："
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(413, 6)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(62, 32)
        Me.Button7.TabIndex = 153
        Me.Button7.Text = "三轴爬山手动对准"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button8)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Controls.Add(Me.TextBox3)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.TextBox2)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Controls.Add(Me.ComboBox3)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.ComboBox4)
        Me.TabPage4.Controls.Add(Me.TextBox1)
        Me.TabPage4.Controls.Add(Me.ComboBox5)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(553, 90)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "盲扫"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(386, 15)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 58)
        Me.Button8.TabIndex = 178
        Me.Button8.Text = "盲扫"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(295, 41)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 12)
        Me.Label20.TabIndex = 177
        Me.Label20.Text = "阈值："
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(285, 60)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(59, 21)
        Me.TextBox3.TabIndex = 176
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(209, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 12)
        Me.Label19.TabIndex = 175
        Me.Label19.Text = "长度："
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(199, 60)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(59, 21)
        Me.TextBox2.TabIndex = 174
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(113, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "通道："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 12)
        Me.Label17.TabIndex = 172
        Me.Label17.Text = "Step："
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(103, 15)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox3.TabIndex = 171
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(115, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 170
        Me.Label14.Text = "对准轴："
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(73, 61)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(120, 20)
        Me.ComboBox4.TabIndex = 169
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(11, 61)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(59, 21)
        Me.TextBox1.TabIndex = 168
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(9, 19)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox5.TabIndex = 167
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 166
        Me.Label15.Text = "对准轴："
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TextBox7)
        Me.TabPage5.Controls.Add(Me.Label27)
        Me.TabPage5.Controls.Add(Me.TextBox6)
        Me.TabPage5.Controls.Add(Me.Label26)
        Me.TabPage5.Controls.Add(Me.TextBox5)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Controls.Add(Me.TextBox4)
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.ComboBox7)
        Me.TabPage5.Controls.Add(Me.ComboBox6)
        Me.TabPage5.Controls.Add(Me.Label23)
        Me.TabPage5.Controls.Add(Me.Label21)
        Me.TabPage5.Controls.Add(Me.Button9)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(553, 90)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Sensor"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(190, 60)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(72, 21)
        Me.TextBox7.TabIndex = 178
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(197, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 12)
        Me.Label27.TabIndex = 177
        Me.Label27.Text = "差值："
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(190, 18)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(72, 21)
        Me.TextBox6.TabIndex = 176
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(197, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 12)
        Me.Label26.TabIndex = 175
        Me.Label26.Text = "开始Pos："
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(99, 57)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(72, 21)
        Me.TextBox5.TabIndex = 174
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(114, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 12)
        Me.Label25.TabIndex = 173
        Me.Label25.Text = "Delta："
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(13, 60)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 21)
        Me.TextBox4.TabIndex = 172
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(28, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(41, 12)
        Me.Label24.TabIndex = 171
        Me.Label24.Text = "Step："
        '
        'ComboBox7
        '
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(102, 19)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox7.TabIndex = 170
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(13, 22)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox6.TabIndex = 169
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(25, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 168
        Me.Label23.Text = "Senser轴："
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(114, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "通道："
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(397, 6)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 75)
        Me.Button9.TabIndex = 0
        Me.Button9.Text = "测试"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ComboBox9)
        Me.TabPage6.Controls.Add(Me.Label38)
        Me.TabPage6.Controls.Add(Me.TextBox11)
        Me.TabPage6.Controls.Add(Me.Label35)
        Me.TabPage6.Controls.Add(Me.Button6)
        Me.TabPage6.Controls.Add(Me.Label32)
        Me.TabPage6.Controls.Add(Me.Label33)
        Me.TabPage6.Controls.Add(Me.Label34)
        Me.TabPage6.Controls.Add(Me.TextBox8)
        Me.TabPage6.Controls.Add(Me.Label30)
        Me.TabPage6.Controls.Add(Me.TextBox9)
        Me.TabPage6.Controls.Add(Me.TextBox10)
        Me.TabPage6.Controls.Add(Me.ComboBox10)
        Me.TabPage6.Controls.Add(Me.ComboBox11)
        Me.TabPage6.Controls.Add(Me.Label31)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(553, 90)
        Me.TabPage6.TabIndex = 3
        Me.TabPage6.Text = "摆渡角"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ComboBox9
        '
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(95, 21)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox9.TabIndex = 193
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(107, 5)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 12)
        Me.Label38.TabIndex = 192
        Me.Label38.Text = "Senser轴："
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(284, 58)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(72, 21)
        Me.TextBox11.TabIndex = 191
        Me.TextBox11.Text = "1"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(291, 40)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(41, 12)
        Me.Label35.TabIndex = 190
        Me.Label35.Text = "角度："
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(362, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(103, 72)
        Me.Button6.TabIndex = 189
        Me.Button6.Text = "对准"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(13, 43)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(47, 12)
        Me.Label32.TabIndex = 188
        Me.Label32.Text = "Delta："
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(193, 4)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 12)
        Me.Label33.TabIndex = 187
        Me.Label33.Text = "Step："
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(104, 44)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 12)
        Me.Label34.TabIndex = 186
        Me.Label34.Text = "通道："
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(286, 19)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(72, 21)
        Me.TextBox8.TabIndex = 185
        Me.TextBox8.Text = "1"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(293, 4)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 12)
        Me.Label30.TabIndex = 184
        Me.Label30.Text = "最大值："
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(10, 58)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(72, 21)
        Me.TextBox9.TabIndex = 183
        Me.TextBox9.Text = "0.001"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(190, 20)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(72, 21)
        Me.TextBox10.TabIndex = 182
        Me.TextBox10.Text = "2"
        '
        'ComboBox10
        '
        Me.ComboBox10.FormattingEnabled = True
        Me.ComboBox10.Location = New System.Drawing.Point(104, 64)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(106, 20)
        Me.ComboBox10.TabIndex = 181
        '
        'ComboBox11
        '
        Me.ComboBox11.FormattingEnabled = True
        Me.ComboBox11.Location = New System.Drawing.Point(10, 20)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox11.TabIndex = 180
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(22, 4)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 12)
        Me.Label31.TabIndex = 179
        Me.Label31.Text = "旋转轴："
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Button14)
        Me.TabPage7.Controls.Add(Me.Button13)
        Me.TabPage7.Controls.Add(Me.MoveDir)
        Me.TabPage7.Controls.Add(Me.moveMode)
        Me.TabPage7.Controls.Add(Me.MovePos)
        Me.TabPage7.Controls.Add(Me.Label28)
        Me.TabPage7.Controls.Add(Me.Label29)
        Me.TabPage7.Controls.Add(Me.Label36)
        Me.TabPage7.Controls.Add(Me.Label37)
        Me.TabPage7.Controls.Add(Me.ComboBox8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(553, 90)
        Me.TabPage7.TabIndex = 4
        Me.TabPage7.Text = "运动轴信息"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(397, 39)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 27)
        Me.Button14.TabIndex = 180
        Me.Button14.Text = "高速"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(397, 6)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 27)
        Me.Button13.TabIndex = 179
        Me.Button13.Text = "低速"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'MoveDir
        '
        Me.MoveDir.Location = New System.Drawing.Point(73, 53)
        Me.MoveDir.Name = "MoveDir"
        Me.MoveDir.Size = New System.Drawing.Size(100, 21)
        Me.MoveDir.TabIndex = 21
        '
        'moveMode
        '
        Me.moveMode.Location = New System.Drawing.Point(283, 10)
        Me.moveMode.Name = "moveMode"
        Me.moveMode.Size = New System.Drawing.Size(81, 21)
        Me.moveMode.TabIndex = 20
        '
        'MovePos
        '
        Me.MovePos.Location = New System.Drawing.Point(286, 53)
        Me.MovePos.Name = "MovePos"
        Me.MovePos.Size = New System.Drawing.Size(65, 21)
        Me.MovePos.TabIndex = 19
        Me.MovePos.Text = "0"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(215, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 12)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "移动位置："
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 57)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 12)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "移动方向："
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(212, 13)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 12)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "移动方式："
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(8, 13)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(53, 12)
        Me.Label37.TabIndex = 13
        Me.Label37.Text = "轴名称："
        '
        'ComboBox8
        '
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Location = New System.Drawing.Point(74, 13)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox8.TabIndex = 12
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.TextBox13)
        Me.TabPage12.Controls.Add(Me.Label44)
        Me.TabPage12.Controls.Add(Me.Label42)
        Me.TabPage12.Controls.Add(Me.TxtSensorInsertOffSet)
        Me.TabPage12.Controls.Add(Me.Label46)
        Me.TabPage12.Controls.Add(Me.TxtZeroSensorValue)
        Me.TabPage12.Controls.Add(Me.Label45)
        Me.TabPage12.Controls.Add(Me.TxtAxis1MaxOffSet)
        Me.TabPage12.Controls.Add(Me.Label43)
        Me.TabPage12.Controls.Add(Me.TxtMove2Step)
        Me.TabPage12.Controls.Add(Me.Label41)
        Me.TabPage12.Controls.Add(Me.ComboBox13)
        Me.TabPage12.Controls.Add(Me.Label40)
        Me.TabPage12.Controls.Add(Me.ComboBox12)
        Me.TabPage12.Controls.Add(Me.Label39)
        Me.TabPage12.Controls.Add(Me.Button12)
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(553, 90)
        Me.TabPage12.TabIndex = 5
        Me.TabPage12.Text = "插玻璃管"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(274, 25)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(59, 21)
        Me.TextBox13.TabIndex = 187
        Me.TextBox13.Text = "0.1"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(277, 9)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(71, 12)
        Me.Label44.TabIndex = 186
        Me.Label44.Text = "Z轴安全距离"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Red
        Me.Label42.Location = New System.Drawing.Point(425, 20)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(51, 41)
        Me.Label42.TabIndex = 185
        '
        'TxtSensorInsertOffSet
        '
        Me.TxtSensorInsertOffSet.Location = New System.Drawing.Point(174, 65)
        Me.TxtSensorInsertOffSet.Name = "TxtSensorInsertOffSet"
        Me.TxtSensorInsertOffSet.Size = New System.Drawing.Size(59, 21)
        Me.TxtSensorInsertOffSet.TabIndex = 184
        Me.TxtSensorInsertOffSet.Text = "0.1"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(177, 49)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(113, 12)
        Me.Label46.TabIndex = 183
        Me.Label46.Text = "Sensor插入的距离："
        '
        'TxtZeroSensorValue
        '
        Me.TxtZeroSensorValue.Location = New System.Drawing.Point(174, 25)
        Me.TxtZeroSensorValue.Name = "TxtZeroSensorValue"
        Me.TxtZeroSensorValue.Size = New System.Drawing.Size(59, 21)
        Me.TxtZeroSensorValue.TabIndex = 182
        Me.TxtZeroSensorValue.Text = "0.1"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(177, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(107, 12)
        Me.Label45.TabIndex = 181
        Me.Label45.Text = "ZeroSenserValue："
        '
        'TxtAxis1MaxOffSet
        '
        Me.TxtAxis1MaxOffSet.Location = New System.Drawing.Point(91, 62)
        Me.TxtAxis1MaxOffSet.Name = "TxtAxis1MaxOffSet"
        Me.TxtAxis1MaxOffSet.Size = New System.Drawing.Size(59, 21)
        Me.TxtAxis1MaxOffSet.TabIndex = 179
        Me.TxtAxis1MaxOffSet.Text = "0.1"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(94, 46)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(65, 12)
        Me.Label43.TabIndex = 177
        Me.Label43.Text = "最大偏移："
        '
        'TxtMove2Step
        '
        Me.TxtMove2Step.Location = New System.Drawing.Point(91, 25)
        Me.TxtMove2Step.Name = "TxtMove2Step"
        Me.TxtMove2Step.Size = New System.Drawing.Size(59, 21)
        Me.TxtMove2Step.TabIndex = 175
        Me.TxtMove2Step.Text = "0.1"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(109, 10)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(41, 12)
        Me.Label41.TabIndex = 173
        Me.Label41.Text = "Step："
        '
        'ComboBox13
        '
        Me.ComboBox13.FormattingEnabled = True
        Me.ComboBox13.Location = New System.Drawing.Point(6, 61)
        Me.ComboBox13.Name = "ComboBox13"
        Me.ComboBox13.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox13.TabIndex = 172
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(18, 45)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(53, 12)
        Me.Label40.TabIndex = 171
        Me.Label40.Text = "对准轴："
        '
        'ComboBox12
        '
        Me.ComboBox12.FormattingEnabled = True
        Me.ComboBox12.Location = New System.Drawing.Point(5, 23)
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox12.TabIndex = 170
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(17, 7)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(53, 12)
        Me.Label39.TabIndex = 169
        Me.Label39.Text = "对准轴："
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(348, 7)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(71, 74)
        Me.Button12.TabIndex = 0
        Me.Button12.Text = "开始"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.Controls.Add(Me.TextBox20)
        Me.TabPage16.Controls.Add(Me.Label93)
        Me.TabPage16.Controls.Add(Me.TextBox19)
        Me.TabPage16.Controls.Add(Me.Label92)
        Me.TabPage16.Controls.Add(Me.TextBox23)
        Me.TabPage16.Controls.Add(Me.Label80)
        Me.TabPage16.Controls.Add(Me.TextBox24)
        Me.TabPage16.Controls.Add(Me.Label81)
        Me.TabPage16.Controls.Add(Me.Button23)
        Me.TabPage16.Controls.Add(Me.TextBox21)
        Me.TabPage16.Controls.Add(Me.Label76)
        Me.TabPage16.Controls.Add(Me.TextBox22)
        Me.TabPage16.Controls.Add(Me.Label78)
        Me.TabPage16.Controls.Add(Me.ComboBox15)
        Me.TabPage16.Controls.Add(Me.Label79)
        Me.TabPage16.Controls.Add(Me.ComboBox14)
        Me.TabPage16.Controls.Add(Me.运动轴)
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage16.Size = New System.Drawing.Size(553, 90)
        Me.TabPage16.TabIndex = 6
        Me.TabPage16.Text = "寻找光点的零界点"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(171, 63)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(72, 21)
        Me.TextBox20.TabIndex = 189
        Me.TextBox20.Text = "50"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(166, 47)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(77, 12)
        Me.Label93.TabIndex = 188
        Me.Label93.Text = "补偿OffSet："
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(171, 23)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(72, 21)
        Me.TextBox19.TabIndex = 187
        Me.TextBox19.Text = "500"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(178, 9)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(65, 12)
        Me.Label92.TabIndex = 186
        Me.Label92.Text = "最大偏移："
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(252, 62)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(72, 21)
        Me.TextBox23.TabIndex = 185
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(256, 47)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(41, 12)
        Me.Label80.TabIndex = 184
        Me.Label80.Text = "差值："
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(250, 23)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(72, 21)
        Me.TextBox24.TabIndex = 183
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(256, 9)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(59, 12)
        Me.Label81.TabIndex = 182
        Me.Label81.Text = "开始Pos："
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(336, 14)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(75, 56)
        Me.Button23.TabIndex = 181
        Me.Button23.Text = "测试"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(87, 63)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(72, 21)
        Me.TextBox21.TabIndex = 180
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(96, 47)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(47, 12)
        Me.Label76.TabIndex = 179
        Me.Label76.Text = "Delta："
        '
        'TextBox22
        '
        Me.TextBox22.Location = New System.Drawing.Point(9, 63)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(72, 21)
        Me.TextBox22.TabIndex = 178
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(12, 47)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(41, 12)
        Me.Label78.TabIndex = 177
        Me.Label78.Text = "Step："
        '
        'ComboBox15
        '
        Me.ComboBox15.FormattingEnabled = True
        Me.ComboBox15.Location = New System.Drawing.Point(86, 24)
        Me.ComboBox15.Name = "ComboBox15"
        Me.ComboBox15.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox15.TabIndex = 176
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(96, 9)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(41, 12)
        Me.Label79.TabIndex = 175
        Me.Label79.Text = "通道："
        '
        'ComboBox14
        '
        Me.ComboBox14.FormattingEnabled = True
        Me.ComboBox14.Location = New System.Drawing.Point(6, 24)
        Me.ComboBox14.Name = "ComboBox14"
        Me.ComboBox14.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox14.TabIndex = 171
        '
        '运动轴
        '
        Me.运动轴.AutoSize = True
        Me.运动轴.Location = New System.Drawing.Point(15, 9)
        Me.运动轴.Name = "运动轴"
        Me.运动轴.Size = New System.Drawing.Size(65, 12)
        Me.运动轴.TabIndex = 170
        Me.运动轴.Text = "Senser轴："
        '
        'TabPage18
        '
        Me.TabPage18.Controls.Add(Me.Label109)
        Me.TabPage18.Controls.Add(Me.txtsaThreshold)
        Me.TabPage18.Controls.Add(Me.Label108)
        Me.TabPage18.Controls.Add(Me.Label107)
        Me.TabPage18.Controls.Add(Me.cbsaIsIRet)
        Me.TabPage18.Controls.Add(Me.btnsaAlign)
        Me.TabPage18.Controls.Add(Me.txtsaIRetCount)
        Me.TabPage18.Controls.Add(Me.Label102)
        Me.TabPage18.Controls.Add(Me.cksaIsCheck)
        Me.TabPage18.Controls.Add(Me.cbsaChannel)
        Me.TabPage18.Controls.Add(Me.Label103)
        Me.TabPage18.Controls.Add(Me.txtsaDelta)
        Me.TabPage18.Controls.Add(Me.Label104)
        Me.TabPage18.Controls.Add(Me.txtsaCP)
        Me.TabPage18.Controls.Add(Me.Label105)
        Me.TabPage18.Controls.Add(Me.txtsaStep)
        Me.TabPage18.Controls.Add(Me.Label106)
        Me.TabPage18.Controls.Add(Me.cbsaAxis)
        Me.TabPage18.Location = New System.Drawing.Point(4, 22)
        Me.TabPage18.Name = "TabPage18"
        Me.TabPage18.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage18.Size = New System.Drawing.Size(553, 90)
        Me.TabPage18.TabIndex = 7
        Me.TabPage18.Text = "单扫"
        Me.TabPage18.UseVisualStyleBackColor = True
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(235, 2)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(41, 12)
        Me.Label109.TabIndex = 193
        Me.Label109.Text = "阈值："
        '
        'txtsaThreshold
        '
        Me.txtsaThreshold.Location = New System.Drawing.Point(237, 16)
        Me.txtsaThreshold.Name = "txtsaThreshold"
        Me.txtsaThreshold.Size = New System.Drawing.Size(52, 21)
        Me.txtsaThreshold.TabIndex = 192
        Me.txtsaThreshold.Text = "3"
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(127, 7)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(53, 12)
        Me.Label108.TabIndex = 191
        Me.Label108.Text = "递归选择"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(6, 2)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(53, 12)
        Me.Label107.TabIndex = 190
        Me.Label107.Text = "对准轴："
        '
        'cbsaIsIRet
        '
        Me.cbsaIsIRet.Checked = True
        Me.cbsaIsIRet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbsaIsIRet.Location = New System.Drawing.Point(132, 17)
        Me.cbsaIsIRet.Name = "cbsaIsIRet"
        Me.cbsaIsIRet.Size = New System.Drawing.Size(26, 24)
        Me.cbsaIsIRet.TabIndex = 189
        Me.cbsaIsIRet.UseVisualStyleBackColor = True
        '
        'btnsaAlign
        '
        Me.btnsaAlign.Location = New System.Drawing.Point(406, 48)
        Me.btnsaAlign.Name = "btnsaAlign"
        Me.btnsaAlign.Size = New System.Drawing.Size(63, 34)
        Me.btnsaAlign.TabIndex = 188
        Me.btnsaAlign.Text = "手动盲扫"
        Me.btnsaAlign.UseVisualStyleBackColor = True
        '
        'txtsaIRetCount
        '
        Me.txtsaIRetCount.Location = New System.Drawing.Point(177, 61)
        Me.txtsaIRetCount.Name = "txtsaIRetCount"
        Me.txtsaIRetCount.Size = New System.Drawing.Size(52, 21)
        Me.txtsaIRetCount.TabIndex = 187
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(188, 41)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(41, 12)
        Me.Label102.TabIndex = 186
        Me.Label102.Text = "递归："
        '
        'cksaIsCheck
        '
        Me.cksaIsCheck.AutoSize = True
        Me.cksaIsCheck.Location = New System.Drawing.Point(79, 23)
        Me.cksaIsCheck.Name = "cksaIsCheck"
        Me.cksaIsCheck.Size = New System.Drawing.Size(15, 14)
        Me.cksaIsCheck.TabIndex = 185
        Me.cksaIsCheck.UseVisualStyleBackColor = True
        '
        'cbsaChannel
        '
        Me.cbsaChannel.FormattingEnabled = True
        Me.cbsaChannel.Location = New System.Drawing.Point(295, 61)
        Me.cbsaChannel.Name = "cbsaChannel"
        Me.cbsaChannel.Size = New System.Drawing.Size(93, 20)
        Me.cbsaChannel.TabIndex = 184
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(318, 41)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(41, 12)
        Me.Label103.TabIndex = 183
        Me.Label103.Text = "通道："
        '
        'txtsaDelta
        '
        Me.txtsaDelta.Location = New System.Drawing.Point(237, 60)
        Me.txtsaDelta.Name = "txtsaDelta"
        Me.txtsaDelta.Size = New System.Drawing.Size(52, 21)
        Me.txtsaDelta.TabIndex = 182
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(241, 41)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(41, 12)
        Me.Label104.TabIndex = 181
        Me.Label104.Text = "增量："
        '
        'txtsaCP
        '
        Me.txtsaCP.Location = New System.Drawing.Point(122, 61)
        Me.txtsaCP.Name = "txtsaCP"
        Me.txtsaCP.Size = New System.Drawing.Size(36, 21)
        Me.txtsaCP.TabIndex = 180
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(99, 41)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(77, 12)
        Me.Label105.TabIndex = 179
        Me.Label105.Text = "ChechPoint："
        '
        'txtsaStep
        '
        Me.txtsaStep.Location = New System.Drawing.Point(4, 61)
        Me.txtsaStep.Name = "txtsaStep"
        Me.txtsaStep.Size = New System.Drawing.Size(100, 21)
        Me.txtsaStep.TabIndex = 178
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(18, 41)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(41, 12)
        Me.Label106.TabIndex = 177
        Me.Label106.Text = "Step："
        '
        'cbsaAxis
        '
        Me.cbsaAxis.FormattingEnabled = True
        Me.cbsaAxis.Location = New System.Drawing.Point(4, 19)
        Me.cbsaAxis.Name = "cbsaAxis"
        Me.cbsaAxis.Size = New System.Drawing.Size(72, 20)
        Me.cbsaAxis.TabIndex = 176
        '
        'GBoxPowerGra
        '
        Me.GBoxPowerGra.Controls.Add(Me.TabControl3)
        Me.GBoxPowerGra.Location = New System.Drawing.Point(-6, -8)
        Me.GBoxPowerGra.Name = "GBoxPowerGra"
        Me.GBoxPowerGra.Size = New System.Drawing.Size(572, 199)
        Me.GBoxPowerGra.TabIndex = 136
        Me.GBoxPowerGra.TabStop = False
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage8)
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Location = New System.Drawing.Point(9, 11)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(553, 182)
        Me.TabControl3.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.DataGraph_DB)
        Me.TabPage8.Controls.Add(Me.lbMaxPower)
        Me.TabPage8.Controls.Add(Me.Label50)
        Me.TabPage8.Controls.Add(Me.DataGraph_1)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(545, 156)
        Me.TabPage8.TabIndex = 0
        Me.TabPage8.Text = "模拟功率"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'DataGraph_DB
        '
        Me.DataGraph_DB.Location = New System.Drawing.Point(110, 36)
        Me.DataGraph_DB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGraph_DB.Name = "DataGraph_DB"
        Me.DataGraph_DB.ReferenceCount = CType(0, Short)
        Me.DataGraph_DB.RefreshRateInMs = "250"
        Me.DataGraph_DB.Size = New System.Drawing.Size(324, 85)
        Me.DataGraph_DB.TabIndex = 141
        Me.DataGraph_DB.TitlAxis = "X Axis"
        Me.DataGraph_DB.Title = ""
        Me.DataGraph_DB.TitleX2Axis = ""
        Me.DataGraph_DB.TitleY2Axis = ""
        Me.DataGraph_DB.TitleYAxis = "Y Axis"
        '
        'lbMaxPower
        '
        Me.lbMaxPower.AutoSize = True
        Me.lbMaxPower.Location = New System.Drawing.Point(335, 16)
        Me.lbMaxPower.Name = "lbMaxPower"
        Me.lbMaxPower.Size = New System.Drawing.Size(11, 12)
        Me.lbMaxPower.TabIndex = 140
        Me.lbMaxPower.Text = "0"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(259, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(65, 12)
        Me.Label50.TabIndex = 139
        Me.Label50.Text = "最大指标："
        '
        'DataGraph_1
        '
        Me.DataGraph_1.Location = New System.Drawing.Point(218, 68)
        Me.DataGraph_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGraph_1.Name = "DataGraph_1"
        Me.DataGraph_1.ReferenceCount = CType(0, Short)
        Me.DataGraph_1.RefreshRateInMs = "250"
        Me.DataGraph_1.Size = New System.Drawing.Size(324, 85)
        Me.DataGraph_1.TabIndex = 0
        Me.DataGraph_1.TitlAxis = "X Axis"
        Me.DataGraph_1.Title = ""
        Me.DataGraph_1.TitleX2Axis = ""
        Me.DataGraph_1.TitleY2Axis = ""
        Me.DataGraph_1.TitleYAxis = "Y Axis"
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.DataGraph)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(545, 156)
        Me.TabPage9.TabIndex = 1
        Me.TabPage9.Text = "传感器"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'DataGraph
        '
        Me.DataGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGraph.Location = New System.Drawing.Point(3, 3)
        Me.DataGraph.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGraph.Name = "DataGraph"
        Me.DataGraph.ReferenceCount = CType(0, Short)
        Me.DataGraph.RefreshRateInMs = "250"
        Me.DataGraph.Size = New System.Drawing.Size(539, 150)
        Me.DataGraph.TabIndex = 0
        Me.DataGraph.TitlAxis = "X Axis"
        Me.DataGraph.Title = ""
        Me.DataGraph.TitleX2Axis = ""
        Me.DataGraph.TitleY2Axis = ""
        Me.DataGraph.TitleYAxis = "Y Axis"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(577, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "影像（1）"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage13
        '
        Me.TabPage13.Controls.Add(Me.Camra1)
        Me.TabPage13.Location = New System.Drawing.Point(4, 22)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage13.Size = New System.Drawing.Size(577, 317)
        Me.TabPage13.TabIndex = 2
        Me.TabPage13.Text = "影像（2）"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'Camra1
        '
        Me.Camra1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Camra1.Location = New System.Drawing.Point(3, 3)
        Me.Camra1.Name = "Camra1"
        Me.Camra1.Size = New System.Drawing.Size(571, 311)
        Me.Camra1.TabIndex = 0
        '
        'TabPage15
        '
        Me.TabPage15.Controls.Add(Me.Label74)
        Me.TabPage15.Controls.Add(Me.Label75)
        Me.TabPage15.Controls.Add(Me.Label59)
        Me.TabPage15.Controls.Add(Me.TextBox18)
        Me.TabPage15.Controls.Add(Me.Label60)
        Me.TabPage15.Controls.Add(Me.CheckBox17)
        Me.TabPage15.Controls.Add(Me.GroupBox5)
        Me.TabPage15.Controls.Add(Me.Label57)
        Me.TabPage15.Controls.Add(Me.Label56)
        Me.TabPage15.Controls.Add(Me.TextBox15)
        Me.TabPage15.Controls.Add(Me.Label52)
        Me.TabPage15.Controls.Add(Me.TextBox14)
        Me.TabPage15.Controls.Add(Me.Label51)
        Me.TabPage15.Controls.Add(Me.Button16)
        Me.TabPage15.Location = New System.Drawing.Point(4, 22)
        Me.TabPage15.Name = "TabPage15"
        Me.TabPage15.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage15.Size = New System.Drawing.Size(577, 317)
        Me.TabPage15.TabIndex = 3
        Me.TabPage15.Text = "ProductSetting"
        Me.TabPage15.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label74.Location = New System.Drawing.Point(11, 71)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(115, 21)
        Me.Label74.TabIndex = 20
        Me.Label74.Text = "启动流程："
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label75.Enabled = False
        Me.Label75.Location = New System.Drawing.Point(12, 99)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(347, 26)
        Me.Label75.TabIndex = 19
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label59.Location = New System.Drawing.Point(11, 13)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(115, 21)
        Me.Label59.TabIndex = 18
        Me.Label59.Text = "复位流程："
        '
        'TextBox18
        '
        Me.TextBox18.Enabled = False
        Me.TextBox18.Location = New System.Drawing.Point(498, 77)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(59, 21)
        Me.TextBox18.TabIndex = 17
        Me.TextBox18.Text = "0"
        Me.TextBox18.Visible = False
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Enabled = False
        Me.Label60.Location = New System.Drawing.Point(12, 36)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(347, 26)
        Me.Label60.TabIndex = 16
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox17
        '
        Me.CheckBox17.AutoSize = True
        Me.CheckBox17.Checked = True
        Me.CheckBox17.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox17.Location = New System.Drawing.Point(499, 105)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(30, 16)
        Me.CheckBox17.TabIndex = 14
        Me.CheckBox17.Text = ">"
        Me.CheckBox17.UseVisualStyleBackColor = True
        Me.CheckBox17.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button22)
        Me.GroupBox5.Controls.Add(Me.Button21)
        Me.GroupBox5.Controls.Add(Me.Button15)
        Me.GroupBox5.Controls.Add(Me.Button19)
        Me.GroupBox5.Controls.Add(Me.Button18)
        Me.GroupBox5.Controls.Add(Me.Button17)
        Me.GroupBox5.Controls.Add(Me.TextBox17)
        Me.GroupBox5.Controls.Add(Me.TextBox16)
        Me.GroupBox5.Controls.Add(Me.Label55)
        Me.GroupBox5.Controls.Add(Me.Label54)
        Me.GroupBox5.Controls.Add(Me.Label53)
        Me.GroupBox5.Controls.Add(Me.CheckBox16)
        Me.GroupBox5.Controls.Add(Me.CheckBox15)
        Me.GroupBox5.Controls.Add(Me.CheckBox14)
        Me.GroupBox5.Controls.Add(Me.CheckBox13)
        Me.GroupBox5.Controls.Add(Me.CheckBox12)
        Me.GroupBox5.Controls.Add(Me.CheckBox11)
        Me.GroupBox5.Controls.Add(Me.CheckBox10)
        Me.GroupBox5.Controls.Add(Me.CheckBox9)
        Me.GroupBox5.Controls.Add(Me.CheckBox8)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 144)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(550, 197)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(162, 125)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(75, 33)
        Me.Button22.TabIndex = 19
        Me.Button22.Text = "全部取消"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(17, 127)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(75, 34)
        Me.Button21.TabIndex = 18
        Me.Button21.Text = "全选"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(458, 41)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(80, 29)
        Me.Button15.TabIndex = 17
        Me.Button15.Text = "Read"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(458, 76)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(80, 29)
        Me.Button19.TabIndex = 16
        Me.Button19.Text = "PowerOff"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(350, 74)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(80, 31)
        Me.Button18.TabIndex = 15
        Me.Button18.Text = "PowerOn"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(350, 41)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(80, 29)
        Me.Button17.TabIndex = 14
        Me.Button17.Text = "Set"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(480, 14)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(58, 21)
        Me.TextBox17.TabIndex = 13
        Me.TextBox17.Text = "2"
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(372, 14)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(58, 21)
        Me.TextBox16.TabIndex = 12
        Me.TextBox16.Text = "1"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(438, 16)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(41, 12)
        Me.Label55.TabIndex = 11
        Me.Label55.Text = "Volt::"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(313, 16)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(53, 12)
        Me.Label54.TabIndex = 10
        Me.Label54.Text = "Current:"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Red
        Me.Label53.Location = New System.Drawing.Point(478, 123)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(58, 38)
        Me.Label53.TabIndex = 9
        '
        'CheckBox16
        '
        Me.CheckBox16.AutoSize = True
        Me.CheckBox16.Location = New System.Drawing.Point(220, 93)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox16.TabIndex = 8
        Me.CheckBox16.Text = "Channel_1"
        Me.CheckBox16.UseVisualStyleBackColor = True
        '
        'CheckBox15
        '
        Me.CheckBox15.AutoSize = True
        Me.CheckBox15.Location = New System.Drawing.Point(110, 93)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox15.TabIndex = 7
        Me.CheckBox15.Text = "Channel_1"
        Me.CheckBox15.UseVisualStyleBackColor = True
        '
        'CheckBox14
        '
        Me.CheckBox14.AutoSize = True
        Me.CheckBox14.Location = New System.Drawing.Point(8, 89)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox14.TabIndex = 6
        Me.CheckBox14.Text = "Channel_1"
        Me.CheckBox14.UseVisualStyleBackColor = True
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(220, 54)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox13.TabIndex = 5
        Me.CheckBox13.Text = "Channel_1"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(110, 54)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox12.TabIndex = 4
        Me.CheckBox12.Text = "Channel_1"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(8, 54)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox11.TabIndex = 3
        Me.CheckBox11.Text = "Channel_1"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(220, 19)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox10.TabIndex = 2
        Me.CheckBox10.Text = "Channel_1"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(110, 19)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox9.TabIndex = 1
        Me.CheckBox9.Text = "Channel_1"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(8, 20)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox8.TabIndex = 0
        Me.CheckBox8.Text = "Channel_1"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(8, 131)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(567, 10)
        Me.Label57.TabIndex = 11
        Me.Label57.Text = "Label57"
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label56.Enabled = False
        Me.Label56.Location = New System.Drawing.Point(499, 51)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(53, 23)
        Me.Label56.TabIndex = 10
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label56.Visible = False
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBox15.Enabled = False
        Me.TextBox15.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox15.ForeColor = System.Drawing.Color.Lime
        Me.TextBox15.Location = New System.Drawing.Point(456, 57)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(121, 35)
        Me.TextBox15.TabIndex = 3
        Me.TextBox15.Text = "0"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox15.Visible = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label52.Location = New System.Drawing.Point(494, 124)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(73, 21)
        Me.Label52.TabIndex = 2
        Me.Label52.Text = "回损："
        Me.Label52.Visible = False
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBox14.Enabled = False
        Me.TextBox14.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox14.ForeColor = System.Drawing.Color.Lime
        Me.TextBox14.Location = New System.Drawing.Point(453, 45)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(121, 35)
        Me.TextBox14.TabIndex = 1
        Me.TextBox14.Text = "0"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox14.Visible = False
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label51.Location = New System.Drawing.Point(488, 20)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(73, 21)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "指标："
        Me.Label51.Visible = False
        '
        'Button16
        '
        Me.Button16.Image = Global.PumpLaser_Automation.My.Resources.Resources.ooopic_1488014774
        Me.Button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button16.Location = New System.Drawing.Point(365, 13)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(180, 109)
        Me.Button16.TabIndex = 13
        Me.Button16.Text = "登入"
        Me.Button16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button16.UseVisualStyleBackColor = True
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(320, 86)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(22, 21)
        Me.TextBox12.TabIndex = 138
        Me.TextBox12.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(9, 145)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(319, 23)
        Me.ProgressBar2.TabIndex = 139
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Lime
        Me.Label49.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label49.Location = New System.Drawing.Point(449, 143)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(129, 28)
        Me.Label49.TabIndex = 140
        Me.Label49.Text = "0 s"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(36, 94)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(47, 12)
        Me.Label58.TabIndex = 141
        Me.Label58.Text = "Label58"
        Me.Label58.Visible = False
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.Lime
        Me.Label77.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label77.Location = New System.Drawing.Point(328, 143)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(124, 28)
        Me.Label77.TabIndex = 143
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IoControl11
        '
        Me.IoControl11.Location = New System.Drawing.Point(603, 574)
        Me.IoControl11.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.IoControl11.Name = "IoControl11"
        Me.IoControl11.Size = New System.Drawing.Size(501, 153)
        Me.IoControl11.TabIndex = 179
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 733)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.IoControl11)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.TabControl5)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.lblAPower)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblBPower)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GBoxFlow)
        Me.Controls.Add(Me.TxtSpanTime)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GBoxPower)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "········"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GBoxFlow.ResumeLayout(False)
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage10.ResumeLayout(False)
        Me.flowPartGBox1.ResumeLayout(False)
        Me.flowPartGBox1.PerformLayout()
        Me.StateGBox.ResumeLayout(False)
        Me.StateGBox.PerformLayout()
        Me.TabControl5.ResumeLayout(False)
        Me.TabPage11.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TabPage14.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage17.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage12.ResumeLayout(False)
        Me.TabPage12.PerformLayout()
        Me.TabPage16.ResumeLayout(False)
        Me.TabPage16.PerformLayout()
        Me.TabPage18.ResumeLayout(False)
        Me.TabPage18.PerformLayout()
        Me.GBoxPowerGra.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage13.ResumeLayout(False)
        Me.TabPage15.ResumeLayout(False)
        Me.TabPage15.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 系统ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 流程编辑ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 结束ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 历史数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GBoxPower As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lblAPower As System.Windows.Forms.Label
    Public WithEvents lblBPower As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GBoxFlow As System.Windows.Forms.GroupBox
    Friend WithEvents flowPartGBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFlowChart As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CurOperLabel As System.Windows.Forms.Label
    Friend WithEvents ChangFlowBtn As System.Windows.Forms.Button
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents StateGBox As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents 手动控制ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Axis_3 As PumpLaser_Automation.AxisContorl
    Friend WithEvents Axis_2 As PumpLaser_Automation.AxisContorl
    Friend WithEvents Axis_0 As PumpLaser_Automation.AxisContorl
    Friend WithEvents 回原点流程编辑ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnReadLensfile As System.Windows.Forms.Button
    Friend WithEvents BtnSaveLensfile As System.Windows.Forms.Button
    Friend WithEvents btnGoLensPos As System.Windows.Forms.Button
    Friend WithEvents Axis_1 As PumpLaser_Automation.AxisContorl
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents 系统设定ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbCmdStatus As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCmdStep As System.Windows.Forms.Button
    Friend WithEvents BtnNextStep As System.Windows.Forms.Button
    Friend WithEvents btnPerStep As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtSpanTime As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TxtIlret As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtDelta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtPicth As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtStep As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbAxisName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents MoveDir As System.Windows.Forms.TextBox
    Friend WithEvents moveMode As System.Windows.Forms.TextBox
    Friend WithEvents MovePos As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents GBoxPowerGra As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents DataGraph_1 As BrainDll.ZedGraphPanel
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents DataGraph As BrainDll.ZedGraphPanel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents 打开监控ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetLightPowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents TabControl4 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents lsLog As System.Windows.Forms.ListBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ComboBox13 As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TxtMove2Step As System.Windows.Forms.TextBox
    Friend WithEvents TxtSensorInsertOffSet As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TxtZeroSensorValue As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TxtAxis1MaxOffSet As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents IOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IoControl11 As PumpLaser_Automation.IOControl1
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReadMiorrfile As System.Windows.Forms.Button
    Friend WithEvents BtnSaveMiorrfile As System.Windows.Forms.Button
    Friend WithEvents btnGoMirrorPos As System.Windows.Forms.Button
    Friend WithEvents Axis_5 As PumpLaser_Automation.AxisContorl
    Friend WithEvents Axis_6 As PumpLaser_Automation.AxisContorl
    Friend WithEvents Axis_4 As PumpLaser_Automation.AxisContorl
    Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
    Friend WithEvents Camra1 As PumpLaser_Automation.Camra
    Friend WithEvents listView1 As System.Windows.Forms.ListView
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbMaxPower As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents 控制器ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents 校正光谱ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl5 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage14 As System.Windows.Forms.TabPage
    Friend WithEvents 校准轴比列ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage15 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents CheckBox16 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox14 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox13 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents 电源测试ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Button17 As Button
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Button19 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Label58 As Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents CheckBox17 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents r_9 As System.Windows.Forms.TextBox
    Friend WithEvents r_8 As System.Windows.Forms.TextBox
    Friend WithEvents r_7 As System.Windows.Forms.TextBox
    Friend WithEvents r_6 As System.Windows.Forms.TextBox
    Friend WithEvents r_5 As System.Windows.Forms.TextBox
    Friend WithEvents r_4 As System.Windows.Forms.TextBox
    Friend WithEvents r_3 As System.Windows.Forms.TextBox
    Friend WithEvents r_2 As System.Windows.Forms.TextBox
    Friend WithEvents R_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents SN As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents OpeterNo As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents ComboBox15 As System.Windows.Forms.ComboBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents ComboBox14 As System.Windows.Forms.ComboBox
    Friend WithEvents 运动轴 As System.Windows.Forms.Label
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents DataGraph_DB As BrainDll.ZedGraphPanel
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage17 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents OpWorkData2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents OpWokeData1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents DpOpenTime1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents DpTypeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents DpLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents MirrorLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents DataRemake As System.Windows.Forms.TextBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents MeachineNo As System.Windows.Forms.TextBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents cbWorkSatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents cbErrorType As System.Windows.Forms.ComboBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents DpOpenTime2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents HotEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents HotStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TabPage18 As TabPage
    Friend WithEvents Label108 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents cbsaIsIRet As CheckBox
    Friend WithEvents btnsaAlign As Button
    Friend WithEvents txtsaIRetCount As TextBox
    Friend WithEvents Label102 As Label
    Friend WithEvents cksaIsCheck As CheckBox
    Friend WithEvents cbsaChannel As ComboBox
    Friend WithEvents Label103 As Label
    Friend WithEvents txtsaDelta As TextBox
    Friend WithEvents Label104 As Label
    Friend WithEvents txtsaCP As TextBox
    Friend WithEvents Label105 As Label
    Friend WithEvents txtsaStep As TextBox
    Friend WithEvents Label106 As Label
    Friend WithEvents cbsaAxis As ComboBox
    Friend WithEvents txtsaThreshold As TextBox
    Friend WithEvents Label109 As Label
    Friend WithEvents Label110 As Label
    Friend WithEvents btnsaScan As Button
    Friend WithEvents TextBox26 As TextBox
    ' Friend WithEvents DxMediaControl11 As cDxMediaDll.DxMediaControl1
    ' Friend WithEvents Camera1 As EmguCvDll.Camera
    ' Friend WithEvents Camera1 As EmguCvDll.Camera
    'Friend WithEvents Camera1 As Collimator_Automation.Camera

End Class
