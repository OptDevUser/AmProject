Imports System.IO
Imports WebCam_Capture
Imports System.Windows.Forms

Public Class MainFrm
    '6个轴控制的 列表， 用于左进 右进 回原点 原点捕获和定位 还可以保存和读取信息
    Private AxisContorl As New List(Of AxisContorl) '当前定义 7  个轴 | 2块板卡（Lens：0-2有 3不用， Mirror：4-6 7没有

    ' IO Label控制与否 || 点击IO Label， 红色背景则设置true， 并显示成绿色的表示控制为true || 反之 也然
    Public Sub lbClick(sender As Object, e As EventArgs)
        Dim lb As Button = CType(sender, Button)
        Dim Index As Integer = IOSetingIni.IOList(lb.Tag).IOIndex
        System.Threading.Thread.Sleep(1)
        If lb.BackColor = Color.Red Then
            IMC.WriteOut(Convert.ToInt32(Index), 0) = True
            lb.BackColor = Color.Green
        Else
            IMC.WriteOut(Convert.ToInt32(Index), 0) = False
            lb.BackColor = Color.Red
        End If
    End Sub

    ' 聚合所有轴号、配置轴号名称、打开轴功能 , 读取并设置功能模块内组件
    Sub InitalFrm()
        '
        ' 获得所有轴 || 把所有轴放到 集合里去  || 设置轴号、轴名称（文件中读取）、打开轴控制
        '
        AxisContorl.Add(Axis_0)
        AxisContorl.Add(Axis_1)
        AxisContorl.Add(Axis_2)
        AxisContorl.Add(Axis_3)
        AxisContorl.Add(Axis_4)
        AxisContorl.Add(Axis_5)
        AxisContorl.Add(Axis_6)
        For i As Integer = 0 To 6
            AxisContorl(i).AxisName = Ini.GetINIValue("Axis", "Axis" & i, IniFile)
            AxisContorl(i).AxisIndex = i
            AxisContorl(i).ContorlEnable = True
            '  IMC.Home(i)
        Next

        '
        ' 从相应文件中 加载AglinmentPara ||  InserRotaion || InsertGalssPara || BlindPara || cTouchPara|| clTouchPara || 
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of AgilenentPara)(AglinmentPara, New AgilenentPara, AglinmentParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of AgilenentPara)(AglinmentPara, AglinmentParaFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of InSertRotationPara)(InserRotaion, New InSertRotationPara, InserRotaionFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of InSertRotationPara)(InserRotaion, InserRotaionFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of InserGalssTubePara)(InsertGalssPara, New InserGalssTubePara, InsertGalssParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of InserGalssTubePara)(InsertGalssPara, InsertGalssParaFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of BlindSearchPara)(BlindPara, New BlindSearchPara, BlindParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of BlindSearchPara)(BlindPara, BlindParaFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of TOUCHPARA)(cTouchPara, New TOUCHPARA, TouchParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of TOUCHPARA)(cTouchPara, TouchParaFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of TOUCHPARA)(clTouchPara, New TOUCHPARA, lTouchParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of TOUCHPARA)(clTouchPara, lTouchParaFile)
        End If

        ' 《》AglinmentPara
        ' 对准模块 ：UI设置  {参与轴号、step{picth，picthcount}、增量、递归、通道号、递归选择}
        ' Step、CheckPont 对应Picth、PicthCount
        Dim AxisList As New List(Of Integer)    'AglinmentPara中所有轴号 ： eg 0 1 2 
        Dim cbAxislist As New List(Of ComboBox) '对准模块 三个ComboBox
        Dim ckAxislist As New List(Of CheckBox) '对准模块 三个ComboBox右边的 CheckBox
        cbAxislist.Add(cbAxisName)
        ckAxislist.Add(CheckBox1)
        cbAxislist.Add(ComboBox1)
        cbAxislist.Add(ComboBox2)
        ckAxislist.Add(CheckBox2)
        ckAxislist.Add(CheckBox3)
        AxisList = AglinmentPara._AxisNo
        TxtStep.Text = AglinmentPara._Picth         'Step文本框 《《《《 Pitch （eg：100,100）
        TxtDelta.Text = AglinmentPara._Delta        '增量文本框 《《《《 Delta
        cbChannel.SelectedIndex = AglinmentPara._Channel    '通道选择列表框combo
        TxtPicth.Text = AglinmentPara._PicthCount           'CheckPoint文本框 
        TxtIlret.Text = AglinmentPara._IretCount            '递归文本框 ： 递归数量
        Try
            '依次设置组合框选择， 第一选择X 第二选择Y 第三选择Z || 右边打上勾
            For i As Int16 = 0 To AxisList.Count - 1
                cbAxislist(i).SelectedIndex = AxisList(i)
                ckAxislist(i).Checked = True
            Next
        Catch ex As Exception

        End Try


        ' 《》BlindPara
        ' 盲扫模块 ：UI设置 {哪2个轴号、step、长度、阈值、通道号}
        Try
            ComboBox5.SelectedIndex = BlindPara.Axis0   '对准轴 ： 哪个轴号
            ComboBox3.SelectedIndex = BlindPara.Axis1   '对准轴 ： 哪个轴号
        Catch ex As Exception

        End Try
        TextBox2.Text = BlindPara.Rang      '长度
        TextBox1.Text = BlindPara.dStep     '步长
        TextBox3.Text = BlindPara.MaxValue  '阈值
        ComboBox4.SelectedIndex = BlindPara.Channel '通道号

        ' TouchPara 《-》 Sensor模块
        ' Sensor模块 ： UI 设置  {轴号、dstep、detal、通道号 ，开始和差值没有对应？？？}
        Try
            ComboBox6.SelectedIndex = cTouchPara.Axis0  '轴号
        Catch ex As Exception

        End Try
        TextBox5.Text = cTouchPara.powerdetal       'detal 《《《powerdetal
        TextBox4.Text = cTouchPara.dStep            'dstep
        ComboBox7.SelectedIndex = cTouchPara.Channel    '通道号

        '   《-》  clTouchPara
        ' 寻找光点的临界点模块 ： UI 设置  {senser轴、最大偏移、step、delta、补偿offset、开始pos、差值、通道号 } 开始pos、差值
        Try
            ComboBox14.SelectedIndex = clTouchPara.Axis0    '轴号
            TextBox21.Text = clTouchPara.powerdetal         'delta  《《《powerdetal
            TextBox22.Text = clTouchPara.dStep              'step
            ComboBox15.SelectedIndex = clTouchPara.Channel  '通道号
            TextBox19.Text = clTouchPara.MinValue           '最大偏移
            TextBox20.Text = clTouchPara.OffSet             '补偿 《《OffSet
        Catch ex As Exception

        End Try

        '   《-》  InserRotaion
        ' 8度模块 ： UI 设置  {旋转轴、Senser轴、Step 最大值、delta、角度、通道号 }
        Try
            ComboBox11.SelectedIndex = InserRotaion.Axis0       '旋转轴号
            ComboBox9.SelectedIndex = InserRotaion.Axis1        'Senser轴号
        Catch ex As Exception

        End Try
        TextBox10.Text = InserRotaion.dStep     'Step
        TextBox8.Text = InserRotaion.MinValue   '最大值
        TextBox9.Text = InserRotaion.powerdetal 'Delta值 《《《powerdetal
        TextBox11.Text = InserRotaion.Rang      '角度
        ComboBox10.SelectedIndex = InserRotaion.Channel '通道号

        '   《-》  InsertGalssPara {哪两个轴号、最大偏移、step、插入距离、ZeroSensorValue}
        '  插玻璃管
        Try
            ComboBox12.SelectedIndex = InsertGalssPara.Axis1    '轴号
            ComboBox13.SelectedIndex = InsertGalssPara.Axis2    '轴号
        Catch ex As Exception

        End Try
        TxtAxis1MaxOffSet.Text = InsertGalssPara.Axis1MaxMoveOffSet '最大偏移
        'OBJ.Axis2MaxMoveOffSet = TxtAxis2MaxOffSet.Text
        TxtMove2Step.Text = InsertGalssPara.Axis1MoveStep           'step
        '
        TxtSensorInsertOffSet.Text = InsertGalssPara.SenserInsertOffSet '插入的距离
        TxtZeroSensorValue.Text = InsertGalssPara.ZeroSenserValue   'ZeroSensorValue


    End Sub
    'Private webcam As WebCamCapture
    '’Private _FrameImage As System.Windows.Forms.PictureBox
    '’Private FrameNumber As Integer = 30
    Public ProductCb As New List(Of CheckBox)                           ' 16个（通道|）产品的CheckBox 列表 
    'Private Sub InitalProduct(productCount As Integer)
    '    'GroupBox5.Controls.Clear()
    '    'cb.Clear()
    '    'For i As Int32 = 0 To productCount - 1
    '    '    Dim tmp As New CheckBox
    '    '    tmp.Text = "Product_" & i
    '    '    tmp.Size = New Size(50, 50)
    '    '    tmp.Parent = GroupBox5
    '    '    tmp.Location(20 + i*2
    '    'Next
    'End Sub

    ' TabControl 显示哪个Table ， 程序中根据需要切换哪个tab
    Public Sub ShowTable(tab As System.Windows.Forms.TabControl, page As System.Windows.Forms.TabPage)
        If tab.InvokeRequired Then
            Me.BeginInvoke(New Action(Of TabControl, TabPage)(AddressOf ShowTable), {tab, page})
        Else
            tab.SelectedTab = page
        End If
    End Sub
    '
    ' 根据需要显示哪个页面  ||| TabControl 显示哪个Table ， 程序中根据需要切换哪个tab | 用名称来切换
    '  页面 || 主：TabControl1， 功能模块： TabControl2  ，控制&数据&追踪日志：TabControl5
    Public Sub ChangeTabIndex(tablename As String)
        Select Case tablename
            Case "模拟功率"
                ShowTable(TabControl1, TabPage1)
                ShowTable(TabControl3, TabPage8)

            Case "传感器"
                ShowTable(TabControl1, TabPage1)
                ShowTable(TabControl3, TabPage9)

            Case "系统配置"                         '产品设置 页面
                ShowTable(TabControl1, TabPage15)

            Case "影像"
                ShowTable(TabControl1, TabPage2)
                ' TabControl1.SelectedTab = TabPage2
            Case "数据"                               'data 页面
                ShowTable(TabControl1, TabPage1)
                'TabControl1.SelectedTab = TabPage1
            Case "控制"
                ShowTable(TabControl5, TabPage11)      '轴控制 页面
                ' TabControl5.SelectedTab = TabPage11
            Case "数据1"
                '  ShowTable(TabControl5, TabPage15)
                ' TabControl5.SelectedTab = TabPage15
        End Select
    End Sub
    ' 切换Label前景色 | 选择则前景色为绿色、 不选中为黄色
    Public Sub Chkbox(sender As Object, e As System.EventArgs)
        Dim ck As CheckBox = CType(sender, CheckBox)
        ck.ForeColor = IIf(ck.Checked, Color.Green, Color.Yellow)
    End Sub

    ' 登录的用户信息： 名称、pwd、权限、登录时间
    Public UserInfo As BrainDll.BrainUserDll.GlobalTool.UserInfo

    ' Form_Load 功能：
    '初始化全局变量： MainForm、各个功能模块对象（从文件中抓取）、HomeList（归为用）、HomeFlow（Home.xml）、SystemIni、显示单位（单位.xml）
    '   打开功率计（ESP300 PowerUsb）、打开板卡、
    '   聚合所有通道、
    '   c恒惠 | 恒惠电源  CurVoltTool.Connect(ProductPara.ComPortName)

    '   根据配置是否去掉一些 控件

    '控件的普通初始化：DataGraph、所有轴、所有通道、运行数据页面初始化、流程相关组件初始化、功能模块Page内组件 、 。。。。
    '  提示是否要归为： IO控制位、轴回Home点
    '  权限设置
    '  打开Timer1：

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainForm = Me

        'If False Then  '暂时关闭
        '    Dim LoginFor As New BrainDll.FrmLogin
        '    If LoginFor.ShowDialog <> DialogResult.OK Then
        '        Me.Close()
        '        Return
        '    End If
        '    UserInfo = BrainDll.BrainUserDll.GlobalTool.UserInfoData
        'End If

        ' Set Title
        BrainDll.BrainUserDll.GlobalTool.DisableCloseButton(Me.Handle) 'disable close button
        Me.Text = "PumpLaser Automation"
        Me.Text &= BrainDll.BrainUserDll.GlobalTool.SetTitleVersion & " 登入用户：" & UserInfo.User
        '
        ' ESP300 | 打开功率计外部设备 
        ESP300.HanldeDevice = True  '打开，如果不能打开则报错
        ESP300.WhiteLight = True
        '
        ' IMC and Init（7个轴）
        IMC.SearchNet()
        IMC.OpenDev()
        For i As Integer = 0 To 6 'Init（7个轴
            IMC.InitalCard(i)
        Next
        ' 聚集所有通道号组件
        ProductCb.Add(CheckBox8)
        ProductCb.Add(CheckBox9)
        ProductCb.Add(CheckBox10)
        ProductCb.Add(CheckBox11)
        ProductCb.Add(CheckBox12)
        ProductCb.Add(CheckBox13)
        ProductCb.Add(CheckBox14)
        ProductCb.Add(CheckBox15)
        ProductCb.Add(CheckBox16)
        ShowTable(TabControl1, TabPage15)
        ' 所有通道号CheckBox， 显示Cos1-16、黑色背景、黄色文字， 增加Check与否的事件监控
        For i As Int16 = 0 To ProductCb.Count - 1
            ProductCb(i).Text = "COS" & i + 1
            ProductCb(i).ForeColor = Color.Yellow
            ProductCb(i).BackColor = Color.Black
            AddHandler ProductCb(i).CheckedChanged, AddressOf Chkbox
            ' ChangeCheckBox(MainForm.ProductCb(i), Color.Yellow)
        Next

        ' 加载HomeFlow对象  从Home.xml || Home对象列表（轴号、名、方向、速度、超时） || 好像未使用，待查
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(HomeFlow, New cHomeFlow, HomeFile)
        ' 设置图像参数 （曲线名称、颜色、圆形、大小、最大点数）
        Me.DataGraph.RegisterCurve("Sensor", Color.Red, ZedGraph.SymbolType.Circle, 1, 100)
        Me.DataGraph_1.RegisterCurve("Power", Color.Red, ZedGraph.SymbolType.Circle, 1, 100)
        Me.DataGraph_DB.RegisterCurve("Power", Color.Red, ZedGraph.SymbolType.Circle, 1, 100)
        Me.DataGraph_1.RegisterCurve("MaxPower", Color.Yellow, ZedGraph.SymbolType.Circle, 2, 100)

        ' 加载系统参数SystemIni （最大功率、回损值、端口、电流、电压、是否比较单位、起始流程、复位流程、通道号）
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of cSystemParmater)(SystemIni, New cSystemParmater, SystemIniFile)

        ' 加载所有轴名称 到UI组合框中去 、 代码可合并优化
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            cbAxisName.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox1.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox2.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox5.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox3.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox6.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox8.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox9.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox12.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox13.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox14.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        ' 加载所有通道名称 
        ComboBox15.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        ComboBox7.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        cbChannel.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        ComboBox4.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        'ComboBox2.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox11.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next
        ComboBox10.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())

        ' CurVoltTool打开指定串口  | 电源
        CurVoltTool.Connect(ProductPara.ComPortName)
        If CurVoltTool.IsOpen = False Then MessageBox.Show("电源打开失败！") ': Throw New Exception("电源打开失败!")
        ' 功率单位、 默认配置、文件配置《单位.txt》
        Uitial(0) = "dbm"
        Uitial(1) = "dbm"
        Uitial(2) = "v"
        Uitial(3) = "v"
        If IO.File.Exists(IniDir.FullName & "\单位.txt") = True Then
            Uitial = IO.File.ReadAllLines(IniDir.FullName & "\单位.txt")
        End If

        InitalFrm() ' 聚合所有轴号、配置轴号名称、打开轴功能 , 读取并设置功能模块内组件

        ' 决定4个通道是否 显示。 默认全显示、可在文件中配置
        Dim IsShow As New List(Of String)
        Dim rv As String
        rv = Ini.GetINIValue("ChannelSetting", "ChannelAlight", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("ChannelSetting", "ChannelAlight", "1", IniFile)
        Else
            If rv = "1" Then
                IsShow.Add("ChannelAlight")
            End If
        End If

        rv = Ini.GetINIValue("ChannelSetting", "ChannelBlight", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("ChannelSetting", "ChannelBlight", "1", IniFile)
        Else
            If rv = "1" Then
                IsShow.Add("ChannelBlight")
            End If
        End If

        rv = Ini.GetINIValue("ChannelSetting", "ChannelASensor", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("ChannelSetting", "ChannelASensor", "1", IniFile)
        Else
            If rv = "1" Then
                IsShow.Add("ChannelASensor")
            End If
        End If

        rv = Ini.GetINIValue("ChannelSetting", "ChannelBSensor", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("ChannelSetting", "ChannelBSensor", "1", IniFile)
        Else
            If rv = "1" Then
                IsShow.Add("ChannelBSensor")
            End If
        End If

        ' 是否保留TP2（影像1）、TP13（影像2）、 | 默认保留、 可改配置：1保留，其它不保留
        '
        rv = Ini.GetINIValue("FormSetting", "View", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("FormSetting", "View", "1", IniFile)
        Else
            If rv <> 1 Then
                TabControl1.TabPages.Remove(TabPage2)
            End If
        End If

        rv = Ini.GetINIValue("FormSetting", "View", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("FormSetting", "View", "2", IniFile)
        Else
            If rv <> 1 Then
                TabControl1.TabPages.Remove(TabPage13)
            End If
        End If

        ' 是否保留Button10 | 控制Page内的一个按钮
        '
        rv = Ini.GetINIValue("FormSetting", "Button10", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("FormSetting", "Button10", "1", IniFile)
        Else
            If rv <> 1 Then
                Button10.Visible = False
            End If
        End If

        '+++++++++++++++++++++++++++++++++++++
        'MySql
        '
        ' 运行数据Page
        '
        ' 显示错误类型、工作状态，从配置文件中获取  | 项目个数、实际项目内容
        ' 机台编号
        Dim ErrorTypeCount As String = Ini.GetINIValue("MySqlSetting", "ErrorTypeCount", IniFile)
        If ErrorTypeCount = "" Then
            Ini.WriteINIValue("MySqlSetting", "ErrorTypeCount", "0", IniFile)
        End If
        ErrorTypeCount = Ini.GetINIValue("MySqlSetting", "ErrorTypeCount", IniFile)
        For i As Int16 = 0 To Convert.ToInt16(ErrorTypeCount)
            Dim ErrorType As String = Ini.GetINIValue("MySqlSetting", "ErrorType_" & i.ToString, IniFile)
            If ErrorType <> "" Then
                cbErrorType.Items.Add(ErrorType)
            End If
        Next
        Dim WokeSatusCount As String = Ini.GetINIValue("MySqlSetting", "工作状态个数", IniFile)
        If WokeSatusCount = "" Then
            Ini.WriteINIValue("MySqlSetting", "工作状态个数", "0", IniFile)
        End If
        WokeSatusCount = Ini.GetINIValue("MySqlSetting", "工作状态个数", IniFile)
        For i As Int16 = 0 To Convert.ToInt16(ErrorTypeCount)
            Dim WokeSatus As String = Ini.GetINIValue("MySqlSetting", "工作状态_" & i.ToString, IniFile)
            If WokeSatus <> "" Then
                cbWorkSatus.Items.Add(WokeSatus)
            End If
        Next
        Dim MSN As String = Ini.GetINIValue("MySqlSetting", "机台编号", IniFile)
        If MSN = "" Then
            Ini.WriteINIValue("MySqlSetting", "机台编号", "PumpLaser 1#", IniFile)
        End If
        MSN = Ini.GetINIValue("MySqlSetting", "机台编号", IniFile)
        MeachineNo.Text = MSN       '实际上是隐藏的

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        IntitalData() ' 主要是 RList、UVRlist初始化， 即COS值、下标显示内容
        '
        ShowLabA = IsShow(0) ' ~~
        ShowLabB = IsShow(1) ' ~~

        ' 功能模块： 是否显示Page， 默认显示 | 可在文件中配置， 0去掉显示
        ' 当前去掉了 摆渡角=0 插玻璃管=0
        For Each item As TabPage In TabControl2.TabPages
            Dim Tmp As String = "1"
            Tmp = Ini.GetINIValue("FormSetting", item.Text, IniFile)
            If Tmp = "0" Then
                TabControl2.TabPages.Remove(item)
            End If
            If Tmp = "" Then
                Ini.WriteINIValue("FormSetting", item.Text, "1", IniFile)
            End If
        Next
        '
        ' 流程ListView的列初始化， ID、流程名称 花费时间
        listView1.Columns.Add("ID", 50, HorizontalAlignment.Left)
        listView1.Columns.Add("流程名称", 250, HorizontalAlignment.Left)
        listView1.Columns.Add("花费时间", 250, HorizontalAlignment.Left)

        ' 显示产品设置
        TextBox14.Text = ProductPara.MaxPower
        TextBox15.Text = ProductPara.ReturnPower
        Label60.Text = ProductPara.ResetFlowFilw
        CheckBox17.Checked = ProductPara.ComparaUnit
        TextBox18.Text = ProductPara.ChannelIndex
        Label75.Text = ProductPara.StartFlow
        Label56.Text = ProductParaFile  '显示Maindir.FullName & "\Setting\" & "Parameter.xml"

        ' 从文件中抓取所有流程
        UpdateProductList()

        ' 选择起始流程 
        ' 所有流程中 与起始流程相同名称这个流程 置位选择， 并输出来
        For i As Int16 = 0 To cmbFlowChart.Items.Count - 1
            If ProductPara.StartFlow IsNot Nothing Then
                Dim tmp() As String = ProductPara.StartFlow.Split("\")
                Dim tmp1() As String = tmp(tmp.Length - 1).Split(".")
                If tmp1(0) = cmbFlowChart.Items(i) Then
                    AddTrackMsg("流程为： " & tmp1(0))
                    cmbFlowChart.SelectedIndex = i
                    Exit For
                End If
            End If
        Next

        ' HomeList（配置文件）中轴 || 放的是名称、功能好像是 待回HOME（即机械原点）的轴
        HomeList.Clear()
        For i As Int16 = 0 To AxisContorl.Count - 1
            rv = Ini.GetINIValue("HomeList", "H_" & i.ToString, IniFile)
            If rv = "" Then
                Ini.WriteINIValue("HomeList", "H_" & i.ToString, i, IniFile)
            Else
                HomeList.Add(rv)
            End If
        Next

        ' 提示 是否归零 　？
        'ＩＯ口全置位False , HomeList中轴依次回Home点
        If MessageBox.Show("是否执行归零？", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                    IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = False
                Next
            Catch ex As Exception

            End Try
            '
            '  AxisContorl | 让homeList中的轴 以此（1s间隔）回到机械原点 | 顺序由INI文件中的HomeList区来排定
            '
            For i As Int16 = 0 To HomeList.Count - 1
                For j As Int16 = 0 To AxisContorl.Count - 1
                    If HomeList(i) = AxisContorl(j).AxisName Then
                        AxisContorl(j).Home()
                        System.Threading.Thread.Sleep(1000)
                    End If
                Next
            Next
        End If
        '
        RadioButton2.Checked = True '选择 w单位 
        ' Timer1 ： 颜色显示电源是否打卡、功率计的显示值和单位（配置文件和用户选择）、图表、记录特定坐标值
        Timer1.Enabled = True
        ' UserForm， 设置权限 || 1最高 2关掉一些 3关掉更多的项
        UserForm()

    End Sub
    ' UserForm， 设置权限 || 1最高 2关掉一些 3关掉更多的项
    Public Sub UserForm()
        AddTrackMsg("登入用户为：" & UserInfo.User)
        AddTrackMsg("登入用户等级为：" & UserInfo.power)
        Select Case UserInfo.power
            Case "1"
                设置ToolStripMenuItem.Visible = True
                ResetLightPowerToolStripMenuItem.Visible = True
                流程编辑ToolStripMenuItem.Visible = True
            Case "2"

                设置ToolStripMenuItem.Visible = False
                打开监控ToolStripMenuItem.Visible = False
                帮助ToolStripMenuItem.Visible = False
                历史数据ToolStripMenuItem.Visible = False
                ResetLightPowerToolStripMenuItem.Visible = False
                流程编辑ToolStripMenuItem.Visible = False
            Case "3"
                ChangFlowBtn.Enabled = False
                TabControl5.TabPages.Remove(TabPage11)
                设置ToolStripMenuItem.Visible = False
                打开监控ToolStripMenuItem.Visible = False
                帮助ToolStripMenuItem.Visible = False
                历史数据ToolStripMenuItem.Visible = False
                ResetLightPowerToolStripMenuItem.Visible = False
                流程编辑ToolStripMenuItem.Visible = False
                IoControl11.Enabled = False
                cbAxisName.Enabled = False
                CheckBox1.Enabled = False
                ComboBox1.Enabled = False
                CheckBox2.Enabled = False
                ComboBox2.Enabled = False
                CheckBox3.Enabled = False
                TxtDelta.Enabled = False
                TxtIlret.Enabled = False
                TxtPicth.Enabled = False
                TxtStep.Enabled = False
                cbChannel.Enabled = False
                TabControl2.TabPages.Remove(TabPage4)
                TabControl2.TabPages.Remove(TabPage5)
                TabControl2.TabPages.Remove(TabPage6)
                TabControl2.TabPages.Remove(TabPage7)
                TabControl2.TabPages.Remove(TabPage12)
                TabControl2.TabPages.Remove(TabPage16)
                Button15.Enabled = False
                Button17.Enabled = False
                Button18.Enabled = False
                Button19.Enabled = False
        End Select
    End Sub
    Public HomeList As New List(Of String)  ' 归位轴 列表
    Public RlIST As New List(Of TextBox)    '数据区 Cos1-9→_→文本框：背景黄色，初始为0 | Text || 应该功率和单位 《《《《 ProductPara.ChannelIndex 
    Public UVRlist As New List(Of Label)    '数据区 Cos1-9下的显示值：初始为0 | Label || 应该功率和单位  《《《 CurrentFlow.FunctionList(Index).ProductCurrent 

    ' 数据区Page
    ' 主要是 RList、UVRlist初始化， 即COS值、下标显示内容
    Public Sub IntitalData()

        RlIST.Add(R_1)
        RlIST.Add(r_2)
        RlIST.Add(r_3)
        RlIST.Add(r_4)
        RlIST.Add(r_5)
        RlIST.Add(r_6)
        RlIST.Add(r_7)
        RlIST.Add(r_8)
        RlIST.Add(r_9)
        UVRlist.Add(Label61)
        UVRlist.Add(Label94)
        UVRlist.Add(Label95)
        UVRlist.Add(Label96)
        UVRlist.Add(Label97)
        UVRlist.Add(Label98)
        UVRlist.Add(Label99)
        UVRlist.Add(Label100)
        UVRlist.Add(Label101)
        For i As Int16 = 0 To RlIST.Count - 1
            RlIST(i).BackColor = Color.Yellow
            RlIST(i).Text = 0
            UVRlist(i).Text = 0
        Next
    End Sub
    Public IsSaveSN As Boolean = True ' ~~
    Public SNStr As String = String.Empty  'SN：产品器件序列号 | 默认为：时间

    ' 保存MYySqlStr(里面有TargetValue) 保存到csv文件中 || 第一行：列头  第二行开始：数据 ||   当前通道号、 是否自动（是则最后一个则保存）
    ' 
    ' 列头： ID,生产时间,总的花费时间,指标,回损， 备注
    Public Sub RefreshData(Optional ByRef Index As Int16 = 0, Optional IsnOAuto As Boolean = True)
        Try
            Dim SaveData As String = String.Empty
            Dim SaveNameData As String = String.Empty
            If IsnOAuto Then
                For i As Int16 = 0 To 8
                    SaveNameData = SaveNameData & "," & "COS_" & i + 1
                    SaveData = SaveData & "," & TargetValue(i)
                Next
                SaveData = SaveData.Trim(",")
                SaveNameData = SaveNameData.Trim(",")
                SaveNameData = MySqlStr.FormatNameToString1 & "," & SaveNameData & "," & MySqlStr.FormatNameToStrin2
                MySqlStr.COSValue = SaveData
                SaveData = MySqlStr.FormatToString
                If Index = BoxHastable.Count - 1 Then ' 最后一个通道则， 保存到当前csv文件中去
                    Dim fileName1 As String = Now.ToString("yyyy-MM-dd") & ".csv"
                    If IO.File.Exists(DailyLog.FullName & "\" & fileName1) = False Then
                        IO.File.AppendAllText(DailyLog.FullName & "\" & fileName1, SaveNameData & vbNewLine, System.Text.Encoding.Default)
                    End If
                    IO.File.AppendAllText(DailyLog.FullName & "\" & fileName1, SaveData & vbNewLine, System.Text.Encoding.Default)
                End If
            Else
                For i As Int16 = 0 To 8
                    SaveNameData = SaveNameData & "," & "COS_" & i + 1
                    SaveData = SaveData & "," & TargetValue(i)
                Next
                SaveData = SaveData.Trim(",")
                SaveNameData = SaveNameData.Trim(",")
                SaveNameData = MySqlStr.FormatNameToString1 & "," & SaveNameData & "," & MySqlStr.FormatNameToStrin2
                MySqlStr.COSValue = SaveData
                SaveData = MySqlStr.FormatToString
                Dim fileName1 As String = Now.ToString("yyyy-MM-dd") & ".csv"
                If IO.File.Exists(DailyLog.FullName & "\" & fileName1) = False Then
                    IO.File.AppendAllText(DailyLog.FullName & "\" & fileName1, SaveNameData & vbNewLine, System.Text.Encoding.Default)
                End If
                IO.File.AppendAllText(DailyLog.FullName & "\" & fileName1, SaveData & vbNewLine, System.Text.Encoding.Default)
            End If



            'End If
        Catch ex As Exception

        End Try



    End Sub
    Private IsCamer1aUsed As Boolean = False    ' ~~~
    Private IsCamer2aUsed As Boolean = False    ' ~~
    Private Camera1Index As Int16   ' ~~
    Private Camera2Index As Int32   ' ~~
    Private ShowLabA As String          ' A ：第一个选择通道 名称 ~~
    Private ShowLabB As String          ' B ：第二个选择通道 名称 ~~

    Public InterVal As Single = 0            ' cmdRun运行时可： 分 的数值
    Public wh As New Diagnostics.Stopwatch   ' 用于对运行产品的精确计时  （可以刨除暂停等因素）
    Private IsAdd As Boolean    ' ~~
    Private Uitial(4) As String             '功率显示单位的 数组 | 单位.txt | 例如：mw mdb v v

    '
    '
    ' Timer1 ： 颜色显示电源是否打卡、功率计的显示值和单位（配置文件和用户选择）、刷新图表
    ' 记录特定坐标值
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Stop()        '停止Timer1
        Dim Tmp As Double
        Timer1.Interval = 100

        ' 颜色提示： 当前电源是否打开
        Label53.BackColor = IIf(CurVoltTool.IsOpen, Color.Green, Color.Red)

        ' 显示左边功率值和单位： 由配置文件决定取哪一个通道，数据值取决于（哪个单位（org不补偿、dbm补偿、w补偿且换算）），单位：也要计算
        Dim RV As String = Ini.GetINIValue("ShowData", "通道A", IniFile)
        If RV = "" Then
            Ini.WriteINIValue("ShowData", "通道A", "1,db", IniFile)
        End If
        RV = Ini.GetINIValue("ShowData", "通道A", IniFile)
        Dim TMPrv() As String = RV.Split(",")
        Select Case TMPrv(0)
            Case "0"
                ' 取第一个通道值: org采样值\dbm, dbm经过补偿值\dbm,w补充和转换和KB功率值\w|mw|um
                GetChannelDataForTime(AxisInfo.ChannelName.PowerChA, Tmp)
                Label3.Text = "CHA_L"
                ' MainForm.TabControl3.TabPages(0).Text = Label3.Text

                MainForm.lblAPower.Text = Tmp.ToString("0.00")
                If RadioButton2.Checked = True Then         'w打钩  IsNeedOffset = True
                    ESP300.IsNeedOffset = True
                    MainForm.lblAPower.Text = ConvertdbmToPower(Convert.ToSingle(MainForm.lblAPower.Text), Uitial(0)).ToString("0.000")
                End If
                If RadioButton1.Checked = True Then          'dbm 打钩
                    ESP300.IsNeedOffset = True
                    MainForm.lblAPower.Text = Tmp.ToString("0.00")
                    Uitial(0) = "dbm"
                End If
                If RadioButton3.Checked = True Then         'org打钩 .IsNeedOffset = False
                    ESP300.IsNeedOffset = False
                    MainForm.lblAPower.Text = Tmp.ToString("0.00")
                    Uitial(0) = "dbm"
                End If
                Label7.Text = Uitial(0)
            Case "1"
                GetChannelDataForTime(AxisInfo.ChannelName.PowerChB, Tmp)
                MainForm.lblAPower.Text = Tmp.ToString("0.00")
                Label3.Text = "CHB_L"
                Label7.Text = TMPrv(1)
            Case "2"    'sensorA的值,直接显示数据,头标显示CHA_S,
                GetChannelDataForTime(AxisInfo.ChannelName.SensorChA, Tmp)
                MainForm.lblAPower.Text = Tmp.ToString("0.000")
                Label3.Text = "CHA_S"
                Label7.Text = TMPrv(1)
            Case "3"
                GetChannelDataForTime(AxisInfo.ChannelName.SensorChB, Tmp)
                MainForm.lblAPower.Text = Tmp.ToString("0.000")
                Label3.Text = "CHB_S"
                Label7.Text = TMPrv(1)
        End Select

        ' 显示右边功率值和单位： 由配置文件决定取哪一个通道，数据值取决于（哪个单位（org不补偿、dbm补偿、w补偿且换算）），单位：也要计算
        RV = Ini.GetINIValue("ShowData", "通道B", IniFile)
        If RV = "" Then
            Ini.WriteINIValue("ShowData", "通道B", "1,db", IniFile)
        End If
        RV = Ini.GetINIValue("ShowData", "通道B", IniFile)
        Dim TMPrv1() As String = RV.Split(",")
        Select Case TMPrv1(0)
            Case "0"
                GetChannelDataForTime(AxisInfo.ChannelName.PowerChA, Tmp)
                Label2.Text = "CHA_L"
                ' MainForm.TabControl3.TabPages(0).Text = Label3.Text

                MainForm.lblAPower.Text = Tmp.ToString("0.00")
                If RadioButton2.Checked = True Then
                    ESP300.IsNeedOffset = True
                    MainForm.lblBPower.Text = ConvertdbmToPower(Convert.ToSingle(MainForm.lblBPower.Text), Uitial(0)).ToString("0.000")
                End If
                If RadioButton1.Checked = True Then
                    ESP300.IsNeedOffset = True
                    MainForm.lblAPower.Text = Tmp.ToString("0.00")
                    Uitial(0) = "dbm"
                End If
                If RadioButton3.Checked = True Then
                    ESP300.IsNeedOffset = False
                    MainForm.lblBPower.Text = Tmp.ToString("0.00")
                    Uitial(0) = "dbm"
                End If
                Label22.Text = Uitial(0)
            Case "1"
                GetChannelDataForTime(AxisInfo.ChannelName.PowerChB, Tmp)
                MainForm.lblBPower.Text = Tmp.ToString("0.00")
                Label2.Text = "CHB_L"
                Label22.Text = TMPrv1(1)
            Case "2"
                GetChannelDataForTime(AxisInfo.ChannelName.SensorChA, Tmp)
                MainForm.lblBPower.Text = Tmp.ToString("0.000")
                Label2.Text = "CHA_S"
                Label22.Text = TMPrv1(1)
            Case "3"
                GetChannelDataForTime(AxisInfo.ChannelName.SensorChB, Tmp)
                MainForm.lblBPower.Text = Tmp.ToString("0.000")
                Label2.Text = "CHB_S"
                Label22.Text = TMPrv1(1)
        End Select



        'If ShowLabB = "ChannelAlight" Then
        '    GetChannelDataForTime(AxisInfo.ChannelName.PowerChA, Tmp)
        '    MainForm.lblBPower.Text = Tmp.ToString("0.00")
        '    Label2.Text = "CHA_L"
        '    Label22.Text = Uitial(0)
        '    ' MainForm.TabControl3.TabPages(1).Text = Label2.Text
        'End If
        'If ShowLabB = "ChannelBlight" Then
        '    GetChannelDataForTime(AxisInfo.ChannelName.PowerChB, Tmp)
        '    MainForm.lblBPower.Text = Tmp.ToString("0.00")
        '    Label2.Text = "CHB_L"
        '    Label22.Text = Uitial(1)
        '    ' MainForm.TabControl3.TabPages(1).Text = Label2.Text
        'End If
        'If ShowLabB = "ChannelASensor" Then
        '    GetChannelDataForTime(AxisInfo.ChannelName.SensorChA, Tmp)
        '    MainForm.lblBPower.Text = Tmp.ToString("0.000")
        '    Label2.Text = "CHA_S"
        '    Label22.Text = Uitial(2)
        '    ' MainForm.TabControl3.TabPages(1).Text = Label2.Text
        'End If
        'If ShowLabB = "ChannelBSensor" Then
        '    GetChannelDataForTime(AxisInfo.ChannelName.SensorChB, Tmp)
        '    MainForm.lblBPower.Text = Tmp.ToString("0.000")
        '    Label2.Text = "CHB_S"
        '    Label22.Text = Uitial(3)
        '    ' MainForm.TabControl3.TabPages(1).Text = Label2.Text
        'End If

        '
        ' 如果需要刷新：IsTimerRefreshData = True 且 非对准过程时候(IsAutoAligment = False)下
        ' 刷新DataGraph_1（w选项选中）|DataGraph_DB（dbm、org选择项选中） 图像
        ' org为原始值、dbm为补偿值   都是貌似分贝值| w补偿经换算Pow换算KB换算后数据  是功率值
        If IsTimerRefreshData = True Then
            ' refresh DataGraph
            Try
                Me.DataGraph.AddPointY("Sensor", Convert.ToDouble(MainForm.lblBPower.Text))
            Catch ex As Exception
                Me.DataGraph.ClearGraph()
            End Try
            Try

                If Label7.Text.ToLower.Contains("w") Then
                    ' 非PD对准时候， （1）若dbm或org则刷新DataGraph_DB， 否则（2）w选中的话则刷洗DataGraph_1（自动换位mw单位）
                    If IsAutoAligment = False Then  ' 非PD对准 则刷新DataGraph
                        If RadioButton1.Checked = True Or RadioButton3.Checked = True Then  ' dbm,org
                            DataGraph_DB.Visible = True
                            Me.DataGraph_1.ClearGraph()

                            DataGraph_1.Visible = False
                            DataGraph_1.Dock = DockStyle.None
                            DataGraph_DB.Dock = DockStyle.Fill
                            Me.DataGraph_DB.AddPointY("Power", Convert.ToDouble(MainForm.lblAPower.Text))
                        End If
                        If RadioButton2.Checked = True Then ' w
                            Dim showdata As Double = Convert.ToDouble(MainForm.lblAPower.Text)
                            showdata = Convert.ToDouble(MainForm.lblAPower.Text)
                            showdata = Convert.ToDouble(MainForm.lblAPower.Text)
                            showdata = Convert.ToDouble(MainForm.lblAPower.Text)
                            If Label7.Text.ToLower = "w" Then
                                showdata = showdata * 1000
                            Else
                                If Label7.Text.ToLower = "uw" Then
                                    showdata = showdata / 1000
                                End If
                            End If
                            DataGraph_DB.Visible = False
                            DataGraph_1.Visible = True
                            DataGraph_DB.ClearGraph()
                            DataGraph_DB.Dock = DockStyle.None
                            DataGraph_1.Dock = DockStyle.Fill
                            Me.DataGraph_1.AddPointY("Power", showdata)
                        End If

                    End If

                Else
                    ' 
                    If IsAutoAligment = False Then
                        If RadioButton1.Checked = True Or RadioButton3.Checked = True Then
                            Me.DataGraph_1.ClearGraph()

                            DataGraph_DB.Visible = True
                            DataGraph_1.Visible = False
                            DataGraph_1.Dock = DockStyle.None
                            DataGraph_DB.Dock = DockStyle.Fill
                            Me.DataGraph_DB.AddPointY("Power", Convert.ToDouble(MainForm.lblAPower.Text))
                        End If
                        If RadioButton2.Checked = True Then

                            DataGraph_DB.ClearGraph()
                            DataGraph_DB.Visible = False
                            DataGraph_1.Visible = True

                            DataGraph_DB.Dock = DockStyle.None
                            DataGraph_1.Dock = DockStyle.Fill
                            Me.DataGraph_1.AddPointY("Power", Convert.ToDouble(MainForm.lblAPower.Text))
                        End If

                    End If

                End If

            Catch ex As Exception
                Me.DataGraph_1.ClearGraph()
                DataGraph_DB.ClearGraph()
            End Try
        End If

        ' 如果允许 记录则
        ' 记录特定的功率值、以及对应的轴坐标以便备用
        '
        ' RecodePos（ChASeneor、Lens_R位置），RecodeSensor（ChASeneor）  | ESP300.ChA感应值  | StartRecode = true
        If StartRecode = True Then
            Try
                ' 把 3号轴位置加进去
                RecodePos.Add(ESP300.ChASeneor, AxisContorl(3).lbPos.Text)
            Catch ex As Exception

            End Try
            RecodeSensor.Add(ESP300.ChASeneor)
        End If
        ' BlindRecodePos（ChASeneor、Lens_R位置），BlindRecodePower（ChASeneor）  | ESP300.ChA感应值  | StartBlindRecode = true
        If StartBlindRecode = True Then
            Try
                '把 3轴号 加进去
                BlindRecodePos.Add(ESP300.ChASeneor, AxisContorl(3).lbPos.Text)

            Catch ex As Exception

            End Try
            BlindRecodePower.Add(ESP300.ChASeneor)
        End If
        ' MaxPowerForPos（ChALightPower、Z,P,Y轴位置），SearchMaxPower（ChALightPower）  | ESP300.ChA感应值  | StartReacodeAilgnment = true
        If StartReacodeAilgnment Then
            Try
                SearchMaxPower.Add(ESP300.ChALightPower)
                ' 把 2、4、5号轴位置加进去
                MaxPowerForPos.Add(ESP300.ChALightPower, AxisContorl(2).lbPos.Text & "," & AxisContorl(4).lbPos.Text & "," & AxisContorl(5).lbPos.Text)

            Catch ex As Exception

            End Try

        End If        
        ' Blind光谱图坐标（ChALightPower、P,Y轴位置），powerlist（ChALightPower）  | ESP300.ChA感应值  | StartGo光谱图 = true 《' StartGo光谱图 允许的话， 记录镜子端的  功率值，4、5轴信息
        If StartGo光谱图 = True Then
            powerlist.Add(ESP300.ChALightPower)
            Try
                ' 把 4号、5号轴位置加进去
                Blind光谱图坐标.Add(ESP300.ChALightPower, AxisContorl(4).lbPos.Text & "," & AxisContorl(5).lbPos.Text)
            Catch ex As Exception

            End Try

        End If

        GC.Collect()
        Timer1.Start()

    End Sub


#Region "流程控制"
    Public AutoRun As Boolean = False       ' 自动运行标记 | true表示正在运行中、 false已暂停或停止 | 目的只是用于统计和显示（分）用的

    ' 记录msg消息： 超过50行则保存到文件（2017-03-28_Pumplaser.log）中并 清除 | HH:mm:ss>>文本消息 
    Public Sub AddTrackMsg(Msg As String)
        If ListBox2.InvokeRequired Then
            ListBox2.Invoke(New Action(Of String)(AddressOf AddTrackMsg), Msg)
        Else
            ListBox2.Items.Add(Now.ToString("HH:mm:ss") & ">>" & Msg & vbNewLine)
            ListBox2.SelectedIndex = ListBox2.Items.Count - 1
            If ListBox2.Items.Count > 50 Then
                For i As Int16 = 0 To ListBox2.Items.Count - 1
                    System.IO.File.AppendAllText(DailyReport.FullName & "\" & Now.ToString("yyyy-MM-dd") & "_Pumplaser.log", ListBox2.Items(i).ToString)
                Next
                ListBox2.Items.Clear()
            End If

        End If
    End Sub
    '
    ' 点击： 运行
    '  运行前TargetValue内清空， 运行后就有数据
    '  产品数据MySqlStr：UI上数据Page里面控件值, 以及主要是运行过程中产生的TargetValue功率值
    ' 
    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click

        If cmdRun.Text = "运行" Then
            AddTrackMsg("流程开始")
            IsAutoAligment = False      'IsAutoAligment = false
            BoxHastable.Clear()         '所有通道号，清除
            ChangeTabIndex("数据1")      '切到数据1的Page 

            ' 数据区：COS值为 0 
            For i As Integer = 0 To 8
                RlIST(i).Text = "0"
            Next
            '获得运行数据 到MySqlStr
            MySqlStr._器件序列号 = SN.Text
            MySqlStr.反射镜批次 = MirrorLotNo.Text
            MySqlStr.胶水批次 = DpLotNo.Text
            MySqlStr.胶水型号 = DpTypeNo.Text
            MySqlStr.操作者 = OpeterNo.Text
            MySqlStr.胶水打开时间 = DpOpenTime1.Value.ToString("yyyy-MM-dd") & " " & DpOpenTime2.Value.ToString("HH:mm:ss")
            MySqlStr.烘烤开始时间 = HotStartTime.Value.ToString("HH:mm:ss")
            MySqlStr.烘烤结束时间 = HotEndTime.Value.ToString("HH:mm:ss")
            For i As Int16 = 0 To 8
                TargetValue(i) = RlIST(i).Text
            Next
            MySqlStr.不良类型 = cbErrorType.Text
            MySqlStr.工序状态 = cbWorkSatus.Text
            MySqlStr.工位机台号 = MeachineNo.Text
            MySqlStr.备注 = DataRemake.Text
            For i As Int16 = 0 To RlIST.Count - 1
                RlIST(i).BackColor = Color.Yellow
            Next
            ' 16个通道号全为黑色、 如某个通道打钩则加到BoxHastable中 | （0-8） 
            For i As Int16 = 0 To ProductCb.Count - 1
                ProductCb(i).BackColor = Color.Black
                If ProductCb(i).Checked Then
                    BoxHastable.Add(i)
                End If
            Next
            TargetValue = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

            ' SN：器件序列号 | 默认为：时间
            SNStr = SN.Text
            If SNStr = "" Then SNStr = Now.ToString("HH:mm:ss") : SN.Text = SNStr

            ' check 是否选择通道号、流程
            If BoxHastable.Count = 0 Then MessageBox.Show("请选择产品个数!") : Return
            If cmbFlowChart.Text = "" Then MessageBox.Show("请选择流程后自动！") : Return

            ' 检测一个轴是否打开
            For i As Int16 = 0 To 1
                If AxisContorl(i).lbError.Text = "未开启" Then MessageBox.Show("轴卡未能成功打开，确认后,重新开程式！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error) : Throw New Exception("轴卡未能成功打开，确认后,重新开程式！")
            Next

            _OpStep = OpStep.Ilde   ' 操作状态
            InterVal = 0
            AutoRun = True
            wh.Reset()      'wh Reset、然后Start
            wh.Start()

            CurrentProduct.生产时间 = Now
            System.Threading.Thread.Sleep(100)
            Camra1.LoadDefut()
            Camra1.FullSeree()

            ProgressBar2.Value = 0
            CurrentIndex = 0
            'DataGraph.ClearGraph()
            'DataGraph_1.ClearGraph()
            'TabControl2.Enabled = False
            'GroupBox3.Enabled = False
            'GroupBox4.Enabled = False

            ' 选中那些 可以执行的function， 最后加汇总行 总花费时间,最终指标
            Dim lvitem As ListViewItem
            listView1.Items.Clear()
            For i As Integer = 0 To CurrentFlow.FunctionList.Count - 1
                If CurrentFlow.FunctionList(i).IsJumpThisFunction = False Then
                    lvitem = listView1.Items.Add(i.ToString())
                    lvitem.SubItems.Add(CurrentFlow.FunctionList.Item(i).UserInfo)
                    lvitem.SubItems.Add("")
                End If

            Next
            lvitem = listView1.Items.Add(listView1.Items.Count)
            lvitem.SubItems.Add("总花费时间")
            lvitem.SubItems.Add("")
            lvitem = listView1.Items.Add(listView1.Items.Count)
            lvitem.SubItems.Add("最终指标")
            lvitem.SubItems.Add("")

            IsFlowOver = False
            CurrentBoxIndex = 0     ''~~

            '
            ' start
            StatrThread()

            cmdReset.Enabled = True
            cmdReset.Enabled = True
            cmdRun.Image = Global.PumpLaser_Automation.My.Resources.Resources.暂停
            cmdRun.Text = "暂停"
        Else
            cmdPause_Click()

        End If


    End Sub
    Dim Iret As DialogResult

    ' 暂停|继续 过程
    Private Sub cmdPause_Click()

        If cmdRun.Text = "暂停" Then
            AutoRun = False
            PauseThread()
            cmdRun.Image = Global.PumpLaser_Automation.My.Resources.Resources.开始2
            cmdRun.Text = "继续"
            TabControl2.Enabled = True
            GroupBox3.Enabled = True
            wh.Stop()

        ElseIf cmdRun.Text = "继续" Then

            wh.Start()
            _OpStep = OpStep.CurrentStep
            AutoRun = True
            cmdReset.Enabled = True
            RePauseThread()
            'TabControl2.Enabled = False
            'GroupBox3.Enabled = False
            'GroupBox4.Enabled = False
            cmdRun.Image = Global.PumpLaser_Automation.My.Resources.Resources.暂停
            cmdRun.Text = "暂停"
        End If

    End Sub
    '
    ' 点击 结束按钮
    ' IO口全置为False || HomeList中轴回到0点
    ' 保存运行信息
    ' 停止线程
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        '
        ' 如果流程已经结束了， 则保存listView信息到yyyy-MM-dd_hh-mm-ss.csv
        ' 如果未结束，   则置IsFlowOver，然后退出函数
        '
        If IsFlowOver = True Then
            EStop = False
        Else
            IsFlowOver = True
            Return
        End If
        '
        wh.Stop()
        AutoRun = False
        IsFlowOver = True
        cmdRun.Text = "运行"
        cmdRun.Image = Global.PumpLaser_Automation.My.Resources.Resources.开始2
        If IsFlowOver Then
            '保存： 运行信心
            Dim fileName As String = Now.ToString("yyyy-MM-dd_hh-mm-ss") & ".csv"
            Try
                If IO.File.Exists(TestFile.FullName & "\" & fileName) = False Then
                    IO.File.AppendAllText(TestFile.FullName & "\" & fileName, "流程ID" & "," & "流程名称" & "," & "花费时间" & vbNewLine, System.Text.Encoding.Default)
                End If
                For Each Item As ListViewItem In MainForm.listView1.Items
                    IO.File.AppendAllText(TestFile.FullName & "\" & fileName, Item.SubItems.Item(0).Text & "," & Item.SubItems.Item(1).Text & "," & Item.SubItems.Item(2).Text & vbNewLine, System.Text.Encoding.Default)
                Next
            Catch ex As Exception

            End Try

        End If
        Try
            AbortThread()
        Catch ex As Exception

        End Try

        ' 
        _OpStep = OpStep.Ilde
        cmdRun.Enabled = True

        TabControl2.Enabled = True
        GroupBox3.Enabled = True
        ProgressBar2.Value = 0
        wh.Stop()
        ' IO口全置为False || HomeList中轴回到0点
        Try
            For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = False
            Next

            For i As Int16 = 0 To HomeList.Count - 1
                For j As Int16 = 0 To AxisContorl.Count - 1
                    If HomeList(i) = AxisContorl(j).AxisName Then
                        AxisContorl(j).GoToZero()
                        System.Threading.Thread.Sleep(1000)
                    End If
                Next
            Next

            ' 16个通道号 背景色全为 黑色
            For i As Int16 = 0 To ProductCb.Count - 1
                ProductCb(i).BackColor = Color.Black
            Next

            MainForm.AddTrackMsg("产品已做完")
            ContorlChange(CurOperLabel, "流程已结束！请确认！")
        Catch ex As Exception

        End Try
        '    GroupBox4.Enabled = True

    End Sub
#End Region

#Region "设定档操作"

    ' 初始化UI上cmbFlowChart | 抓取所有流程名称、并显示在cmb里
    Public Sub UpdateProductList()
        cmbFlowChart.Items.Clear()
        For Each _FName As FileInfo In ProductDir.GetFiles
            Dim tmp() As String = _FName.FullName.Split("\")
            Dim tmp1() As String = tmp(tmp.Length - 1).Split(".")
            If tmp1(1).ToUpper = "XML" Then
                cmbFlowChart.Items.Add(tmp1(0))
            End If
        Next
        cmbFlowChart.Enabled = True
    End Sub
    ' 加载用户选择的流程， 到CurrentFlow
    Private Sub cmbFlowChart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFlowChart.SelectedIndexChanged
        If cmbFlowChart.SelectedIndex < 0 Then Return
        cmbFlowChart.Enabled = False
        Dim filePath As String = ProductDir.FullName & "\" & cmbFlowChart.Text & ".xml"
        If File.Exists(filePath) AndAlso BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(CurrentFlow, New UserFlow, ProductDir.FullName & "\" & cmbFlowChart.Text & ".xml") Then
            UpdataFlow()
        Else
            cmbFlowChart.Enabled = True
        End If
    End Sub

    ' 更新listView1  为当前用户流程步 |  cbCmdStatus内容
    Public Sub UpdataFlow()
        ListBox1.Items.Clear()
        listView1.Items.Clear()
        Dim lvitem As ListViewItem
        cbCmdStatus.Items.Clear()
        For i As Integer = 0 To CurrentFlow.FunctionList.Count - 1
            If CurrentFlow.FunctionList(i).IsJumpThisFunction = False Then
                '  ListBox1.Items.Add(CurrentFlow.FunctionList.Item(i).UserInfo)
                cbCmdStatus.Items.Add(CurrentFlow.FunctionList.Item(i).UserInfo)
                lvitem = listView1.Items.Add(i.ToString())
                lvitem.SubItems.Add(CurrentFlow.FunctionList.Item(i).UserInfo)
                lvitem.SubItems.Add("")
            End If

        Next
    End Sub

    ' 点击： 导入流程 |从文件内
    Private Sub ChangFlowBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangFlowBtn.Click

        UpdateProductList()
        'If File.Exists(filePath) AndAlso BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(CurrentFlow, New UserFlow, ProductDir.FullName & "\" & cmbFlowChart.Text & ".xml") Then
        '    UpdataFlow()
        'Else
        '    cmbFlowChart.Enabled = True
        'End If
    End Sub
#End Region

#Region "Menu操作"

    Private Sub 系统设定ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 系统设定ToolStripMenuItem.Click
        Dim f As New SaveDataSetting
        f.ShowDialog()
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New Flow
        a.ShowDialog()
    End Sub
    Private Sub 回原点流程编辑ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回原点流程编辑ToolStripMenuItem.Click
        Dim f As New 回原点编辑
        f.ShowDialog()
    End Sub
    Private Sub 流程编辑ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 流程编辑ToolStripMenuItem.Click
        Dim F As New Flow
        F.Show()
    End Sub
    Private Sub 手动控制ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 手动控制ToolStripMenuItem.Click
        Dim F As New Test()
        F.Show()
    End Sub
    Private Sub 结束ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 结束ToolStripMenuItem.Click
        AddTrackMsg("程式关闭")
        For i As Int16 = 0 To ListBox2.Items.Count - 1
            System.IO.File.AppendAllText(DailyReport.FullName & "\" & Now.ToString("yyyy-MM-dd") & "_Pumplaser.log", ListBox2.Items(i).ToString)
        Next
        For Each i As Process In Process.GetProcesses
            If i.ProcessName = "PumpLaser Automation" Then
                i.Kill()
            End If
        Next
        Try
            '  Camare1.Dispose()
        Catch ex As Exception

        End Try


    End Sub
    'Private Sub webcam_ImageCaptured(ByVal source As Object, ByVal e As WebcamEventArgs)
    '    _FrameImage.Image = e.WebCamImage
    'End Sub
    Private Sub 打开监控ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开监控ToolStripMenuItem.Click
        If 打开监控ToolStripMenuItem.Text = "打开监控" Then
            'Dim Fr As New FrmChooseCamera()
            'Fr.ShowDialog()
            'If Fr.DialogResult = DialogResult.OK Then

            'End If
            '   Camare1 = New cCapture(0, 640, 480, 24, ImageControl, 3)




            打开监控ToolStripMenuItem.Text = "关闭监控"
        Else
            'webcam.[Stop]()
            '  Camare1.Dispose()

            打开监控ToolStripMenuItem.Text = "打开监控"
        End If
    End Sub

#End Region

#Region "轴按钮操作"
    '
    ' 原点按钮：
    ' IO控制位 全部置为False || 按HomeList中轴顺序依次 回到0点
    '
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' IO全置位0 
            For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = False
            Next
            If MessageBox.Show("确认气缸已到安全位置！", "Waring", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                For i As Int16 = 0 To HomeList.Count - 1
                    For j As Int16 = 0 To AxisContorl.Count - 1
                        If HomeList(i) = AxisContorl(j).AxisName Then
                            AxisContorl(j).GoToZero()
                            System.Threading.Thread.Sleep(1000)
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try


    End Sub

    ' 应该是 全部走到0按钮
    Private Sub AllZeroBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 4 To 7
            IMC.HandleHome(New HomeParameter(i)) = True
        Next
    End Sub
    '
    ' 读取镜片|镜头 的信息 （定位位置、是否使用、执行顺序）
    Private Sub btnReadLensfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadLensfile.Click, btnReadMiorrfile.Click
        OpenFile.Filter = "程序檔|*.XML"
        Dim btn As Button = CType(sender, Button)
        If btn.Name.Contains("Lens") Then
            OpenFile.InitialDirectory = PostionDir.FullName
            If Not OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then Return
            BrainDll.BrainUserDll.GlobalTool.ToTryLoad(LensPostion, New PositionInformation, OpenFile.FileName)
            For i As Int16 = 0 To 3
                AxisContorl(i).cbPostion.Visible = True
            Next
            For i As Int16 = 0 To 3
                AxisContorl(i).SetCbtxt = LensPostion.AxisPostion(i).OderPosition
                AxisContorl(i).cbstatus = LensPostion.AxisPostion(i).IsUsedThisPosition
                AxisContorl(i).OrderIndex = LensPostion.AxisPostion(i).StartOrder
            Next
        Else
            OpenFile.InitialDirectory = PostionDir.FullName
            If Not OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then Return
            BrainDll.BrainUserDll.GlobalTool.ToTryLoad(MiorroPosition, New PositionInformation, OpenFile.FileName)
            For i As Int16 = 4 To 6
                AxisContorl(i).cbPostion.Visible = True
            Next
            For i As Int16 = 4 To 6
                AxisContorl(i).SetCbtxt = MiorroPosition.AxisPostion(i - 3).OderPosition
                AxisContorl(i).cbstatus = MiorroPosition.AxisPostion(i - 3).IsUsedThisPosition
                AxisContorl(i).OrderIndex = MiorroPosition.AxisPostion(i - 3).StartOrder
            Next

        End If


    End Sub
    '
    ' 保存镜片|镜头 的相关信息 （允许轴则记录轴位置、轴号、执行顺序、是否使用这个位置、 定位的位置）
    Private Sub BtnSaveLensfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveLensfile.Click, BtnSaveMiorrfile.Click
        Dim btn As Button = CType(sender, Button)

        If btn.Name.Contains("Lens") Then
            SaveFile.InitialDirectory = PostionDir.FullName
            If SaveFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            If System.IO.File.Exists(SaveFile.FileName) Then System.IO.File.Delete(SaveFile.FileName)
            For i As Int16 = 0 To 3
                If AxisContorl(i).cbstatus Then
                    AxisContorl(i).SetCbtxt = AxisContorl(i).lbPos.Text
                End If

                LensPostion.AxisPostion(i).AxisIndx = i
                LensPostion.AxisPostion(i).StartOrder = AxisContorl(i).OrderIndex
                LensPostion.AxisPostion(i).IsUsedThisPosition = AxisContorl(i).cbstatus
                LensPostion.AxisPostion(i).OderPosition = AxisContorl(i).SetCbtxt
            Next

            BrainDll.BrainUserDll.GlobalTool.ToSave(Of PositionInformation)(LensPostion, SaveFile.FileName)
        Else
            SaveFile.InitialDirectory = PostionDir.FullName
            If SaveFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            If System.IO.File.Exists(SaveFile.FileName) Then System.IO.File.Delete(SaveFile.FileName)
            For i As Int16 = 4 To 7
                If i < 7 Then
                    MiorroPosition.AxisPostion(i - 3).AxisIndx = i
                    If AxisContorl(i).cbstatus Then
                        AxisContorl(i).SetCbtxt = AxisContorl(i).lbPos.Text
                    End If
                    MiorroPosition.AxisPostion(i - 3).StartOrder = AxisContorl(i).OrderIndex
                    MiorroPosition.AxisPostion(i - 3).IsUsedThisPosition = AxisContorl(i).cbstatus
                    MiorroPosition.AxisPostion(i - 3).OderPosition = AxisContorl(i).SetCbtxt
                End If


            Next
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of PositionInformation)(MiorroPosition, SaveFile.FileName)
        End If
    End Sub

    ' go按钮： 走到某个位置 （允许轴则记录轴位置、轴号、执行顺序、是否使用这个位置、 定位的位置）
    Private Sub btnGoLensPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoLensPos.Click, btnGoMirrorPos.Click
        Dim btn As Button = CType(sender, Button)
        Dim tmp As New List(Of Integer)
        If btn.Name.Contains("Lens") Then

            For i As Integer = 0 To 3
                tmp.Add(AxisContorl(i).OrderIndex)
            Next
            tmp.Sort()
            For j As Integer = 0 To 3
                For i As Int16 = 0 To 3
                    If AxisContorl(i).cbstatus Then
                        If AxisContorl(i).OrderIndex = tmp(j) Then
                            IMC.MoveAbs(LensPostion.AxisPostion(i).AxisIndx, LensPostion.AxisPostion(i).OderPosition)
                            'While True
                            '    If IMC.MoveDone(LensPostion.AxisPostion(i).AxisIndx) = True Then
                            '        Exit While
                            '    End If
                            'End While
                        End If

                    End If
                Next

            Next
        Else
            '
            ' 按照轴先后顺序（OrderIndex）执行， 让每个允许移动（cbstatus）的轴移到指定的绝对位置（OderPosition）
            ' ~~
            For i As Integer = 4 To 6
                tmp.Add(AxisContorl(i).OrderIndex)
            Next
            tmp.Sort()
            Try
                For j As Integer = 0 To 3
                    For i As Integer = 4 To 6
                        If AxisContorl(i).cbstatus Then
                            If AxisContorl(i).OrderIndex = tmp(j) Then
                                IMC.MoveAbs(MiorroPosition.AxisPostion(i - 3).AxisIndx, MiorroPosition.AxisPostion(i - 3).OderPosition)
                                'While True
                                '    If IMC.MoveDone(MiorroPosition.AxisPostion(i - 3).AxisIndx) Then
                                '        Exit While
                                '    End If
                                'End While
                            End If

                        End If
                    Next
                Next

            Catch ex As Exception

            End Try

        End If

    End Sub
#End Region





#Region "Test Each Mode"
    Private Sub cbCmdStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCmdStatus.SelectedIndexChanged
        Dim IterationCount As Int16 = 0
        Dim Index As Int16 = cbCmdStatus.SelectedIndex
        Dim UserAxis As New List(Of Int32)
        Dim Tmp As FlowFunctionlist.UerFuntion
        [Enum].TryParse(cbCmdStatus.Text, Tmp)
        Select Case Tmp
            'Case FlowFunctionlist.UerFuntion.校准光路
            '    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
            '        For i As Int16 = 0 To CurrentFlow.FunctionList.Item(Index).AxisSetting.Count - 1
            '            If CurrentFlow.FunctionList.Item(Index).AxisSetting(i).IsUsedAxis Then
            '                UserAxis.Add(CurrentFlow.FunctionList(Index).AxisSetting(i).AxisNo)
            '            End If
            '        Next
            '    End If
            '    Dim picth As Double = CurrentFlow.FunctionList(Index).AxisSetting(0).Picth
            '    UpdataAlihnment(UserAxis, picth, CurrentFlow.FunctionList(Index).AxisSetting(0).PicthCount, CurrentFlow.FunctionList(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList(Index).AxisSetting(0).Channel, CurrentFlow.FunctionList(Index).AxisSetting(0).Recursion)
            Case FlowFunctionlist.UerFuntion.盲扫
                UpDataBlindSearchInfo(CurrentFlow.FunctionList(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList(Index).AxisSetting(1).AxisNo, CurrentFlow.FunctionList(Index).AxisSetting(0).BlindSearchRang, CurrentFlow.FunctionList(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList(Index).AxisSetting(0).Channel, CurrentFlow.FunctionList(Index).AxisSetting(0).PowerMax)

        End Select


    End Sub

    ' 点击传感器 | 绿色表示打开\红色未打开
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.BackColor = Color.Red Then
            IMC.WriteOut(GetIOIndex("传感器"), 0) = True
            Button2.BackColor = Color.Green
        Else
            IMC.WriteOut(GetIOIndex("传感器"), 0) = False
            Button2.BackColor = Color.Red
        End If

    End Sub
    ' 点击光纤
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.BackColor = Color.Red Then
            IMC.WriteOut(GetIOIndex("光纤"), 0) = True
            Button3.BackColor = Color.Green
        Else
            IMC.WriteOut(GetIOIndex("光纤"), 0) = False
            Button3.BackColor = Color.Red
        End If
        '  IMC.WriteOut(GetIOIndex("光纤"), 0) = IIf(Button3.BackColor = Color.Red, True, False)
    End Sub
    ' 点击Lens
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.BackColor = Color.Red Then
            IMC.WriteOut(GetIOIndex("Lens"), 0) = True
            Button4.BackColor = Color.Green
        Else
            IMC.WriteOut(GetIOIndex("Lens"), 0) = False
            Button4.BackColor = Color.Red
        End If
        ' IMC.WriteOut(GetIOIndex("Lens"), 0) = IIf(Button4.BackColor = Color.Red, True, False)

    End Sub
    ' 点击玻璃管
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Button5.BackColor = Color.Red Then
            IMC.WriteOut(GetIOIndex("玻璃管"), 0) = True
            Button5.BackColor = Color.Green
        Else
            IMC.WriteOut(GetIOIndex("玻璃管"), 0) = False
            Button5.BackColor = Color.Red
        End If

        '   IMC.WriteOut(GetIOIndex("玻璃管"), 0) = IIf(Button5.BackColor = Color.Red, True, False)
    End Sub

    ' 估计测试用的： run
    Private Sub BtnCmdStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdStep.Click
        Dim Tmp As FlowFunctionlist.UerFuntion
        [Enum].TryParse(cbCmdStatus.Text, Tmp)
        MaunObj = Tmp
        MaunIndex = cbCmdStatus.SelectedIndex
        AutoRun = True
        MaunTest = True     ' 手动开始运行标记
        StatrThread()
    End Sub

    Dim TestIndex As Threading.Thread   ' ~~

    Dim ManualAlignment As Threading.Thread
    Dim InsertTestThread As Threading.Thread
    Dim TouchThread As Threading.Thread
    Dim InsertThread As Threading.Thread
    Dim BlindSearchThread As Threading.Thread
    Dim SaAlignment As Threading.Thread '

    Dim IterationCount As Integer = 0   ' ~~
    '
    ' 盲扫功能模块： | 关键信息 两个轴、范围、步长、通道、要扫描的最大功率值
    '
    Private Sub BlindSearchtTest(ByVal obj As BlindSearchPara)
        Dim AlignementTime As Date = Now
        ContorlChange(TxtSpanTime, 0)

        Blind_Search_Alignment(obj.Axis0, obj.Axis1, obj.Rang, obj.dStep, obj.Channel, obj.MaxValue)
        ContorlChange(TxtSpanTime, Now.Subtract(AlignementTime).TotalSeconds)

    End Sub
    '
    ' Sensor功能模块：  | 轴、步长、Delta、通道、偏移最小值、最大值
    '
    Private Sub TouchTest(ByVal obj As TOUCHPARA)
        Dim AlignementTime As Date = Now
        SensorTouch(obj.Axis0, obj.dStep, obj.powerdetal, obj.Channel, obj.MinValue, 1.9)
    End Sub
    '
    ' 功能模块： 测试 LightTest    | 轴号、步长、Delta， 通道， 偏移，最小值
    ' 寻找光点的零界点
    Private Sub LightTest(ByVal obj As TOUCHPARA)
        Dim AlignementTime As Date = Now
        SearchLightLimit(obj.Axis0, obj.dStep, obj.powerdetal, obj.Channel, obj.OffSet, obj.MinValue)
    End Sub
    'WWWW
    '
    ' 8度功能模块： 
    '
    Private Sub InsertTest(ByVal obj As InSertRotationPara)
        InsertRotaion(obj.Axis1, obj.Axis0, 20, obj.Channel, obj.powerdetal, obj.Rang, obj.dStep)
    End Sub
    'WWWW
    ' 三轴爬山手动
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        If Button7.Text = "三轴爬山手动对准" Then
            IsTimerRefreshData = False
            DataGraph_1.ClearGraph()
            DataGraph_1.ClearGraph()
            Dim AxisList As New List(Of Integer)
            If CheckBox1.Checked Then
                AxisList.Add(cbAxisName.SelectedIndex)
            End If
            If CheckBox2.Checked Then
                AxisList.Add(ComboBox1.SelectedIndex)
            End If
            If CheckBox3.Checked Then
                AxisList.Add(ComboBox2.SelectedIndex)
            End If
            Dim OBJ As New AgilenentPara
            OBJ._AxisNo = AxisList
            OBJ._Picth = TxtStep.Text
            OBJ._Delta = TxtDelta.Text
            OBJ._Channel = cbChannel.SelectedIndex
            OBJ._PicthCount = TxtPicth.Text
            OBJ._IretCount = TxtIlret.Text
            Try
                AglinmentPara = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of AgilenentPara)(AglinmentPara, AglinmentParaFile)
            Catch ex As Exception

            End Try

            'Dim OBJ As New AgilenentPara(AxisList, TxtStep.Text, TxtDelta.Text, cbChannel.SelectedIndex, TxtPicth.Text, TxtIlret.Text)
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf 三轴爬山)
            ManualAlignment = New Threading.Thread(s)
            ManualAlignment.IsBackground = True
            ManualAlignment.Start(OBJ)
            Button7.Text = "三轴爬山手动对准中"
        Else
            If Button7.Text = "三轴爬山手动对准中" Then
                IsTimerRefreshData = True
                If ManualAlignment IsNot Nothing Then
                    ManualAlignment.Abort()
                    ContorlChange(Button7, "三轴爬山手动对准")
                End If
            End If

        End If
    End Sub

    ' 盲扫
    '
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Button8.Text = "盲扫" Then
            IsTimerRefreshData = False
            Dim OBJ As New BlindSearchPara '(AxisList, TxtStep.Text, TxtDelta.Text, cbChannel.SelectedIndex, TxtPicth.Text, TxtIlret.Text)
            OBJ.Axis0 = ComboBox5.SelectedIndex
            OBJ.Axis1 = ComboBox3.SelectedIndex
            OBJ.Rang = TextBox2.Text        ' 盲扫的长度
            OBJ.dStep = TextBox1.Text       '步长
            OBJ.MaxValue = TextBox3.Text    ' 盲扫的阈值
            OBJ.Channel = ComboBox4.SelectedIndex
            Try
                BlindPara = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of BlindSearchPara)(BlindPara, BlindParaFile)
            Catch ex As Exception

            End Try

            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf BlindSearchtTest)
            BlindSearchThread = New Threading.Thread(s)
            BlindSearchThread.IsBackground = True
            BlindSearchThread.Start(OBJ)
            Button8.Text = "盲扫中"
        Else
            If Button8.Text = "盲扫中" Then
                If BlindSearchThread IsNot Nothing Then
                    BlindSearchThread.Abort()
                    ContorlChange(Button8, "盲扫")
                End If
                IsTimerRefreshData = True
            End If

        End If

    End Sub
    '
    ' Sensor功能模块： 测试
    '
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Button9.Text = "测试" Then
            IsTimerRefreshData = False
            Dim obj As New TOUCHPARA
            obj.Axis0 = ComboBox6.SelectedIndex
            obj.powerdetal = TextBox5.Text
            obj.dStep = TextBox4.Text
            obj.Channel = ComboBox7.SelectedIndex
            '  obj.MinValue = TextBox7.Text
            Try
                cTouchPara = obj
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of TOUCHPARA)(cTouchPara, TouchParaFile)
            Catch ex As Exception

            End Try
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf TouchTest)
            TouchThread = New Threading.Thread(s)
            TouchThread.IsBackground = True
            TouchThread.Start(obj)
            _SensorTouncStep = TounchStep.Statr
            Button9.Text = "测试中"
        Else
            If Button9.Text = "测试中" Then
                If TouchThread IsNot Nothing Then
                    TouchThread.Abort()
                    ContorlChange(Button9, "测试")
                End If
                IsTimerRefreshData = True
            End If

        End If

    End Sub
    'WWWW
    ' 8度角对准
    '
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Button6.Text = "对准" Then
            IsTimerRefreshData = False
            IsBaidu = True
            Dim OBJ As New InSertRotationPara '(AxisList, TxtStep.Text, TxtDelta.Text, cbChannel.SelectedIndex, TxtPicth.Text, TxtIlret.Text)
            OBJ.Axis0 = ComboBox11.SelectedIndex
            OBJ.Axis1 = ComboBox9.SelectedIndex
            OBJ.dStep = TextBox10.Text
            OBJ.MinValue = TextBox8.Text    ' 最大值
            OBJ.powerdetal = TextBox9.Text
            OBJ.Rang = TextBox11.Text       ' 角度
            OBJ.Channel = ComboBox10.SelectedIndex
            Try
                InserRotaion = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of InSertRotationPara)(InserRotaion, InserRotaionFile)
            Catch ex As Exception

            End Try
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf InsertTest)
            InsertThread = New Threading.Thread(s)
            InsertThread.IsBackground = True
            InsertThread.Start(OBJ)
            Button6.Text = "对准中"
        Else
            If Button6.Text = "对准中" Then
                If InsertThread IsNot Nothing Then
                    InsertThread.Abort()
                    ContorlChange(Button6, "对准")
                End If
                IsTimerRefreshData = True
            End If

        End If
    End Sub
    Private IsBaidu As Boolean = False
    'Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Button10.Text = "对准1" Then
    '        IsTimerRefreshData = False
    '        IsBaidu = False
    '        Dim OBJ As New InSertRotationPara '(AxisList, TxtStep.Text, TxtDelta.Text, cbChannel.SelectedIndex, TxtPicth.Text, TxtIlret.Text)
    '        OBJ.Axis0 = ComboBox11.SelectedIndex
    '        OBJ.dStep = TextBox10.Text
    '        OBJ.MinValue = TextBox8.Text
    '        OBJ.powerdetal = TextBox9.Text
    '        OBJ.Rang = TextBox11.Text
    '        OBJ.Channel = ComboBox10.SelectedIndex
    '        Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf InsertTest)
    '        InsertThread = New Threading.Thread(s)
    '        InsertThread.IsBackground = True
    '        InsertThread.Start(OBJ)
    '        Button10.Text = "对准1中"
    '    Else
    '        If Button10.Text = "对准1中" Then
    '            IsTimerRefreshData = True
    '            If InsertThread IsNot Nothing Then
    '                InsertThread.Abort()
    '                ContorlChange(Button10, "对准1")
    '            End If
    '        End If

    '    End If
    'End Sub
#End Region




    Private ZeroPower As Single = 0

    Private Sub ResetLightPowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLightPowerToolStripMenuItem.Click
        Dim f As New 归零
        f.ShowDialog()
    End Sub
    '
    ' 插玻璃管
    '
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If Button12.Text = "开始" Then
            IsTimerRefreshData = False
            Dim OBJ As New InserGalssTubePara
            OBJ.Axis1 = ComboBox12.SelectedIndex                ' 对准轴1       
            OBJ.Axis2 = ComboBox13.SelectedIndex                ' 对准轴2  
            OBJ.Axis1MaxMoveOffSet = TxtAxis1MaxOffSet.Text     ' 轴1最大偏移
            'OBJ.Axis2MaxMoveOffSet = TxtAxis2MaxOffSet.Text
            OBJ.Axis1MoveStep = TxtMove2Step.Text               ' 轴1step
            OBJ.AxisSensor = 2
            OBJ.SensorMaxPostion = TextBox13.Text               ' Z轴安全距离
            OBJ.SenserInsertOffSet = TxtSensorInsertOffSet.Text ' Sensor插入的距离
            OBJ.ZeroSenserValue = TxtZeroSensorValue.Text       ' ZeroSensorValue
            Try
                InsertGalssPara = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of InserGalssTubePara)(InsertGalssPara, InsertGalssParaFile)
            Catch ex As Exception

            End Try

            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf InsertGlassToLens)
            InsertTestThread = New Threading.Thread(s)
            InsertTestThread.IsBackground = True
            InsertTestThread.Start(OBJ)
            Button12.Text = "等待结束"
        Else
            If Button12.Text = "等待结束" Then
                If InsertTestThread IsNot Nothing Then
                    InsertTestThread.Abort()
                    ContorlChange(Button12, "开始")
                End If
            End If
        End If
    End Sub
    '
    ' 对准模块：手动对准
    ' 先保存用户信息到文件中 、 手动对准（简单攀升法）{结果:找到最大功率值、要找的轴都到达指定最强位置、显示消耗的时间}
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Button11.Text = "手动对准" Then

            '’暂停图形的实时刷数据
            IsTimerRefreshData = False  '’停止刷新图形曲线 ，准群说IsTimerRefreshDGData | 这个时候不能实时刷新曲线了 | 只有采集到了数据才刷新
            '_IsPauseThread = True
            ' 清除模拟功率计下 2个曲线图形
            DataGraph.ClearGraph()
            DataGraph.ClearGraph()
            DataGraph_1.ClearGraph()
            DataGraph_1.ClearGraph()

            Dim AxisList As New List(Of Integer) '获得打钩即参与的 轴号
            If CheckBox1.Checked Then
                AxisList.Add(cbAxisName.SelectedIndex)
            End If
            If CheckBox2.Checked Then
                AxisList.Add(ComboBox1.SelectedIndex)
            End If
            If CheckBox3.Checked Then
                AxisList.Add(ComboBox2.SelectedIndex)
            End If

            Dim OBJ As New AgilenentPara
            OBJ._AxisNo = AxisList      ' 参与的轴 列表
            OBJ._Picth = TxtStep.Text   ' step
            OBJ._Delta = TxtDelta.Text  ' 增量： 也即波动值****
            OBJ._Channel = cbChannel.SelectedIndex
            OBJ._PicthCount = TxtPicth.Text 'checkpoint
            OBJ._IretCount = TxtIlret.Text  '递归数
            OBJ.IsUseIretCount = IIf(CheckBox4.Checked, 1, 0) & "," & IIf(CheckBox5.Checked, 1, 0) & "," & IIf(CheckBox6.Checked, 1, 0) '各个 是否允许递归
            Try
                AglinmentPara = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of AgilenentPara)(AglinmentPara, AglinmentParaFile)
            Catch ex As Exception

            End Try
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf 简单攀升法)
            ManualAlignment = New Threading.Thread(s)
            ManualAlignment.IsBackground = True
            ManualAlignment.Start(OBJ)
            ' 简单攀升法(OBJ)
            Button11.Text = "对准中"
        Else
            If Button11.Text = "对准中" Then

                If ManualAlignment IsNot Nothing Then

                    ManualAlignment.Abort()

                    IsTimerRefreshData = True
                    _IsPauseThread = False  ' 好像 没有用到~~
                    ContorlChange(Button11, "手动对准")
                End If
                IsTimerRefreshData = True
            End If

        End If
    End Sub
    ''
    '' 单轴扫描
    'Private Sub btnsaAlign_Click(sender As Object, e As EventArgs) Handles btnsaAlign.Click
    '    If btnsaAlign.Text = "手动对准" Then

    '        '’暂停图形的实时刷数据
    '        IsTimerRefreshData = False  '’停止刷新图形曲线 ，准群说IsTimerRefreshDGData | 这个时候不能实时刷新曲线了 | 只有采集到了数据才刷新
    '        '_IsPauseThread = True
    '        ' 清除模拟功率计下 2个曲线图形
    '        DataGraph.ClearGraph()
    '        DataGraph.ClearGraph()
    '        DataGraph_1.ClearGraph()
    '        DataGraph_1.ClearGraph()

    '        Dim AxisList As New List(Of Integer) '获得打钩即参与的 轴号
    '        AxisList.Add(cbsaAxis.SelectedIndex)
    '        'If CheckBox1.Checked Then
    '        '    AxisList.Add(cbAxisName.SelectedIndex)
    '        'End If
    '        'If CheckBox2.Checked Then
    '        '    AxisList.Add(ComboBox1.SelectedIndex)
    '        'End If
    '        'If CheckBox3.Checked Then
    '        '    AxisList.Add(ComboBox2.SelectedIndex)
    '        'End If

    '        Dim OBJ As New SaAligamentPara
    '        OBJ._AxisNo = AxisList          ' 参与的轴 列表
    '        OBJ._Picth = txtsaStep.Text   ' step
    '        OBJ._Delta = txtsaDelta.Text  ' 增量： 也即波动值****
    '        OBJ._Channel = cbsaChannel.SelectedIndex
    '        OBJ._PicthCount = txtsaCP.Text 'checkpoint
    '        OBJ._IretCount = txtsaIRetCount.Text  '递归数
    '        OBJ.minvalue = txtsathreshold.text

    '        OBJ.IsUseIretCount = IIf(CheckBox4.Checked, 1, 0) & "," & IIf(CheckBox5.Checked, 1, 0) & "," & IIf(CheckBox6.Checked, 1, 0) '各个 是否允许递归
    '        Try
    '            SaAlignmentPara = OBJ
    '            ''BrainDll.BrainUserDll.GlobalTool.ToSave(Of AgilenentPara)(AglinmentPara, AglinmentParaFile)
    '        Catch ex As Exception

    '        End Try
    '        Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf saHandleProc)
    '        SaAlignment = New Threading.Thread(s)
    '        SaAlignment.IsBackground = True
    '        SaAlignment.Start(OBJ)
    '        ' 简单攀升法(OBJ)
    '        btnsaAlign.Text = "对准中"
    '    Else
    '        If btnsaAlign.Text = "对准中" Then

    '            If SaAlignment IsNot Nothing Then
    '                SaAlignment.Abort()

    '                IsTimerRefreshData = True
    '                _IsPauseThread = False  '好像 没有用到
    '                ContorlChange(btnsaAlign, "手动对准")
    '            End If
    '            IsTimerRefreshData = True
    '        End If

    '    End If
    'End Sub
    ' 
    ' 复位按钮
    ' 
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        AbortThread()
        ' //  If IsFlowOver = False AndAlso CurrentFlow.FunctionList.Count = 0 Then MessageBox.Show("Plese frist Stop the Flow!") : Return
        EStop = False
        AutoRun = False
        ResetFlowRun()

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GBoxPower_Enter(sender As Object, e As EventArgs) Handles GBoxPower.Enter

    End Sub

    Private Sub StateGBox_Enter(sender As Object, e As EventArgs) Handles StateGBox.Enter

    End Sub

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click, Button20.Click
        IsTimerRefreshData = True
    End Sub

    Private Sub IOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IOToolStripMenuItem.Click
        Dim Frm As New IOSetting1
        Frm.Show()
    End Sub

    '
    ' 只是 设定低速运动 方式
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            IMC.SetVelDown(ComboBox8.SelectedIndex) '参数：轴号
        Catch ex As Exception

        End Try
    End Sub
    '
    ' 只是 高速运动 方式
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            IMC.SetVelAcc(ComboBox8.SelectedIndex)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Try
                ' Camra1.PasueCamer()
                ' Vx1.OpenVIew()
            Catch ex As Exception

            End Try


        End If
        If TabControl1.SelectedIndex = 2 Then
            'Vx1.DisConnect()
            Dim _id As String = Ini.GetINIValue("CameraID", "EmguID", IniFile)
            If _id = "" Then
                Ini.WriteINIValue("CameraID", "EmguID", "0", IniFile)
            End If
            _id = Ini.GetINIValue("CameraID", "EmguID", IniFile)
            ' Camra1.InitalCamera(Val(_id))

        End If
    End Sub

    ' 刷新UI：XX分YY秒用的 |  autorun时： 还需要刷新进度条  
    ' 
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If AutoRun = True Then
            If ProgressBar2.Value = 100 Then
                ProgressBar2.Value = 0
            End If
            ProgressBar2.Value = ProgressBar2.Value + 1
        End If
        If wh.Elapsed.Seconds = 59 Then
            InterVal = InterVal + 1
        End If
        Label49.Text = InterVal & " 分钟" & wh.Elapsed.Seconds & " 秒"
    End Sub

    Private Sub lblAPower_Click(sender As Object, e As EventArgs) Handles lblAPower.Click

    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem.Click
        Dim f As New Form2
        f.Show()
    End Sub

    Private Sub 控制器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 控制器ToolStripMenuItem.Click

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs)
        'Dim a As BrainDll.TranslationHelper
        'a = New BrainDll.TranslationHelper("G:\【高义修改中】\【准直器】\NewDllTest\Collimator Automation20161107\Collimator Automation\bin\Debug\Translation.txt")
        'a._Oldlanguage = BrainDll.TranslationHelper._language.Chinese
        'For Each c As Control In Me.Controls
        '    If TypeOf (c) Is TabControl Then
        '        For Each item As TabPage In CType(c, TabControl).TabPages

        '            item.Text = a.Translate(item.Text, False, BrainDll.TranslationHelper._language.English)
        '            For Each JC As Control In item.Controls
        '                If TypeOf (c) Is TabControl Then

        '                End If
        '            Next
        '        Next
        '    Else
        '        If TypeOf (c) Is MenuStrip Then
        '            For Each item As ToolStripMenuItem In CType(c, MenuStrip).Items
        '                item.Text = a.Translate(item.Text, False, BrainDll.TranslationHelper._language.English)
        '                If item.DropDownItems IsNot Nothing Then
        '                    For Each im As ToolStripMenuItem In item.DropDownItems
        '                        im.Text = a.Translate(im.Text, False, BrainDll.TranslationHelper._language.English)
        '                    Next
        '                End If
        '            Next
        '        Else
        '            a.Translate(c, False, BrainDll.TranslationHelper._language.English)
        '        End If
        '    End If


        'Next
    End Sub

    Private Sub 校正光谱ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 校正光谱ToolStripMenuItem.Click
        Dim f As New 光谱坐标
        f.Show()
    End Sub

    Private Sub 校准轴比列ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 校准轴比列ToolStripMenuItem.Click
        Dim Frm As New 自动校准轴
        Frm.ShowDialog()
    End Sub

    Private Sub 配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 配置ToolStripMenuItem.Click
        Dim Frm As New ContorlSetting
        Frm.ShowDialog()
    End Sub
    ' 
    ' 登录进去后可以保存参数值 || 产品设定： 登录|保存按钮 动作
    ' 
    Private Sub Button16_Click_1(sender As Object, e As EventArgs) Handles Button16.Click
        If Button16.Text = "登入" Then            'Button16 ： 登录大按钮
            Dim flog As New BrainDll.FrmLogin
            Dim Password As String = InputBox("请输入密码！")
            Dim UserPassword As String = Ini.GetINIValue("PassWord", "UserWord", IniFile)
            ' 100 权限高 | 1 权限高 | 其他低 直接返回
            If UserInfo.power <> "100" Then
                ' 1 表示权限高 | 《》1 权限比较低 ，直接返回
                If UserInfo.power <> "1" Then MessageBox.Show("抱歉！当前用户等级较低！") : Return
                If UserPassword = "" Then
                    Ini.WriteINIValue("PassWord", "UserWord", "1234", IniFile)
                End If
                UserPassword = Ini.GetINIValue("PassWord", "UserWord", IniFile)
                If Password <> UserPassword Then Return
            End If

            TextBox14.Enabled = True
            TextBox15.Enabled = True
            Label75.Enabled = True
            Label60.Enabled = True
            TextBox18.Enabled = True
            Button16.Text = "保存"
        Else
            If Button16.Text = "保存" Then
                ' 产品|系统参数： 最大功率、回损值、复位流程、启动流程、是否比较单位、通道号
                ProductPara.MaxPower = Convert.ToDouble(TextBox14.Text)
                ProductPara.ReturnPower = Convert.ToDouble(TextBox15.Text)
                ProductPara.ResetFlowFilw = Label60.Text
                ProductPara.StartFlow = Label75.Text
                ProductPara.ComparaUnit = CheckBox17.Checked
                ProductPara.ChannelIndex = Convert.ToInt16(TextBox18.Text)
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of ProductParameter)(ProductPara, ProductParaFile)
                Button16.Text = "登入"
                'Label75
                TextBox14.Enabled = False
                TextBox15.Enabled = False
                Label75.Enabled = False
                Label60.Enabled = False
                TextBox18.Enabled = False
            End If
        End If
    End Sub

    Private Sub 电源测试ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 电源测试ToolStripMenuItem.Click
        CurVoltTool.Disconnect()
        Dim f As New 恒慧电源测试
        f.ShowDialog()
        CurVoltTool.Connect(ProductPara.ComPortName)
        If CurVoltTool.IsOpen = False Then MessageBox.Show("电源打开失败！") : Throw New Exception("电源打开失败!")
        CurVoltTool.SetParameter(ProductPara.ProductCurrent, ProductPara.ProductVolte)

    End Sub
    ' 设定电流、电压 
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CurVoltTool.SetParameter(TextBox16.Text, TextBox17.Text)
    End Sub
    ' 打开电源
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CurVoltTool.CurrentOut = True
    End Sub
    ' 关闭电源
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CurVoltTool.CurrentOut = False
    End Sub

    ' Timer3 ~~
    Private Sub Timer3_Tick(sender As Object, e As EventArgs)


    End Sub

    ' 选择复位流程
    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.DoubleClick
        Dim _file As New System.Windows.Forms.OpenFileDialog
        _file.InitialDirectory = ProductDir.FullName
        _file.Filter = "*.xml|*.xml"
        If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
        Label60.Text = _file.FileName

    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs)

        ' 让HOMELIST中轴（限定4-6）回到0点 || 也即是M_开头的轴（下面的一个区域）
        For i As Int16 = 0 To HomeList.Count - 1
            For j As Int16 = 4 To 6
                If HomeList(i) = AxisContorl(j).AxisName Then
                    AxisContorl(j).GoToZero()
                    System.Threading.Thread.Sleep(1000)
                End If
            Next
        Next
    End Sub
    ' 读取电流、电压 
    Private Sub Button15_Click_2(sender As Object, e As EventArgs) Handles Button15.Click
        Dim A, V As String
        A = ""
        V = ""
        CurVoltTool.GetOutPutCurentValue(A)
        CurVoltTool.GetOutPutVoltValue(V)
        TextBox16.Text = A
        TextBox17.Text = V
    End Sub
    ' 16个通道号 全选
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        For i As Int16 = 0 To ProductCb.Count - 1
            ProductCb(i).Checked = True
        Next
    End Sub
    ' 16个通道号 全不选
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        For i As Int16 = 0 To ProductCb.Count - 1
            ProductCb(i).Checked = False
        Next
    End Sub
    ' 单击选择启动流程
    Private Sub Label75_Click(sender As Object, e As EventArgs) Handles Label75.DoubleClick
        Dim _file As New System.Windows.Forms.OpenFileDialog
        _file.InitialDirectory = ProductDir.FullName
        _file.Filter = "*.xml|*.xml"
        If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
        Label75.Text = _file.FileName
    End Sub

    ' 功能模块： 测试 LightTest
    ' 寻找光点的零界点
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If Button23.Text = "测试" Then
            '  IsTimerRefreshData = False
            Dim obj As New TOUCHPARA
            obj.Axis0 = ComboBox14.SelectedIndex
            obj.powerdetal = TextBox21.Text     'delta
            obj.dStep = TextBox22.Text          'step
            obj.Channel = ComboBox15.SelectedIndex
            obj.MinValue = TextBox19.Text   '最大偏移
            obj.OffSet = TextBox20.Text     '补偿offset
            '  obj.MinValue = TextBox7.Text
            Try
                clTouchPara = obj
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of TOUCHPARA)(clTouchPara, lTouchParaFile)
            Catch ex As Exception

            End Try
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf LightTest)
            TouchThread = New Threading.Thread(s)
            TouchThread.IsBackground = True
            TouchThread.Start(obj)

            Button23.Text = "测试中"
        Else
            If Button23.Text = "测试中" Then
                If TouchThread IsNot Nothing Then
                    TouchThread.Abort()
                    ContorlChange(Button23, "测试")
                End If
                IsTimerRefreshData = True
            End If

        End If
    End Sub
    '
    ' 点击 则保存MySqlStr信息（包括COS值即TargetValue值、每产品对应的功率值）|| Button24 ： 手动录入
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        MySqlStr._器件序列号 = SN.Text
        MySqlStr.反射镜批次 = MirrorLotNo.Text
        MySqlStr.胶水批次 = DpLotNo.Text
        MySqlStr.胶水型号 = DpTypeNo.Text
        MySqlStr.胶水打开时间 = DpOpenTime1.Value.ToString("yyyy-MM-dd") & " " & DpOpenTime2.Value.ToString("HH:mm:ss")
        MySqlStr.烘烤开始时间 = HotStartTime.Value.ToString("HH:mm:ss")
        MySqlStr.烘烤结束时间 = HotEndTime.Value.ToString("HH:mm:ss")
        MySqlStr.操作者 = OpeterNo.Text
        For i As Int16 = 0 To 8
            TargetValue(i) = RlIST(i).Text
        Next
        MySqlStr.不良类型 = cbErrorType.Text
        MySqlStr.工序状态 = cbWorkSatus.Text
        MySqlStr.工位机台号 = MeachineNo.Text
        MySqlStr.备注 = DataRemake.Text
        RefreshData(, False)

    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged

    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    '
    ' 单轴对准模块：手动对准
    ' 先保存用户信息到文件中 、 手动对准（简单攀升法）
    Private Sub btnsaScan_Click(sender As Object, e As EventArgs) Handles btnsaScan.Click
        If btnsaScan.Text = "单轴对准" Then

            IsTimerRefreshData = False
            '_IsPauseThread = True
            ' 清除模拟功率计图形
            DataGraph.ClearGraph()
            DataGraph.ClearGraph()
            DataGraph_1.ClearGraph()
            DataGraph_1.ClearGraph()
            Dim AxisList As New List(Of Integer) '获得打钩 的轴号
            If CheckBox1.Checked Then
                AxisList.Add(cbAxisName.SelectedIndex)
            End If
            If CheckBox2.Checked Then
                AxisList.Add(ComboBox1.SelectedIndex)
            End If
            If CheckBox3.Checked Then
                AxisList.Add(ComboBox2.SelectedIndex)
            End If

            Dim OBJ As New AgilenentPara
            OBJ._AxisNo = AxisList
            OBJ._Picth = TxtStep.Text
            OBJ._Delta = TxtDelta.Text
            OBJ._Channel = cbChannel.SelectedIndex
            OBJ._PicthCount = TxtPicth.Text
            OBJ._IretCount = TxtIlret.Text
            If IsNumeric(txtsaThreshold.Text) Then OBJ.Threshoud = txtsaThreshold.Text  'check 

            OBJ.IsUseIretCount = IIf(CheckBox4.Checked, 1, 0) & "," & IIf(CheckBox5.Checked, 1, 0) & "," & IIf(CheckBox6.Checked, 1, 0)
            Try
                AglinmentPara = OBJ
                BrainDll.BrainUserDll.GlobalTool.ToSave(Of AgilenentPara)(AglinmentPara, AglinmentParaFile)
            Catch ex As Exception

            End Try
            Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf SingleScanHandleProc)
            ManualAlignment = New Threading.Thread(s)
            ManualAlignment.IsBackground = True
            ManualAlignment.Start(OBJ)
            ' 简单攀升法(OBJ)
            btnsaScan.Text = "对准中"
        Else
            If btnsaScan.Text = "对准中" Then

                If ManualAlignment IsNot Nothing Then

                    ManualAlignment.Abort()

                    IsTimerRefreshData = True
                    _IsPauseThread = False
                    ContorlChange(btnsaScan, "单轴对准")
                End If
                IsTimerRefreshData = True
            End If

        End If
    End Sub
End Class
'
' 光谱图坐标 | 包含一些列（x、y）坐标的 列表
'
Public Class 光谱图坐标
    Public Property _光谱坐标 As New List(Of 光谱XY)
End Class
'
' （x、y）坐标
Public Class 光谱XY
    Public Property X As Double
    Public Property Y As Double
End Class


#Region "ParameterClass"
'
' Insert Rotation | 8度 模块
Public Class InSertRotationPara
    Public Axis0 As Int16
    Public Axis1 As Int16
    Public dStep As Double = 2
    Public powerdetal As Single = 0.04
    Public MinValue As Double   '极大值
    Public Channel As Integer = 0
    Public Rang As Double = 180 '角度
End Class
'
' Sensor模块 
<Serializable> _
Public Class TOUCHPARA
    Public Axis0 As Int16
    Public dStep As Double = 5
    Public powerdetal As Single = 0.004
    Public MinValue As Double           'xxx
    Public Channel As Integer = 0
    Public OffSet As Double = 0         'xxx
End Class
'
' 盲扫模块
Public Class BlindSearchPara
    Public Axis0 As Int16
    Public Axis1 As Int16
    Public Rang As Double = 5           ' 长度
    Public dStep As Double = 0.005
    Public MaxValue As Double = -30     ' 阈值
    Public Channel As Integer = 0
End Class
'
' 对准模块
Public Class AgilenentPara
    Public _AxisNo As New List(Of Integer)          '参与的 所有轴号
    Public _Picth As String = 0.4                   'step， 是个字符串， 记住 不同轴可能有不同步长
    Public _Channel As AxisInfo.ChannelName = AxisInfo.ChannelName.PowerChA '通道号
    Public _PicthCount As Double = 3    ' check point
    Public _Delta As Double = 0.04      ' 增量 ： 当做功率值波动（允许范围内、范围外算另一个数据）
    Public _IretCount As Int16 = 3      ' 递归次数
    Public IsUseIretCount As String     '是否参与递归 信息 ： 格式 1，1，1
    '
    '
    Public Threshoud As Double
End Class
'
Public Class SaAligamentPara
    Public _AxisNo As New List(Of Integer)          '参与的 所有轴号
    Public _Picth As String = 0.4                   'step， 是个字符串， 记住 不同轴可能有不同步长
    Public _Channel As AxisInfo.ChannelName = AxisInfo.ChannelName.PowerChA '通道号
    Public _PicthCount As Double = 3    ' check point
    Public _Delta As Double = 0.04      ' 增量 ： 当做功率值波动（允许范围内、范围外算另一个数据）
    Public _IretCount As Int16 = 3      ' 递归次数
    Public IsUseIretCount As String     '是否参与递归 信息 ： 格式 1，1，1
    Public MinValue As Double      '是否参与递归 信息 ： 格式 1，1，1
End Class

' 插入玻璃管模块
Public Class InserGalssTubePara
    Public ZeroSenserValue As Double = 0.3
    Public Axis1MoveStep As Double = 50
    Public Axis2MoveStep As Double = 50
    Public Axis1MaxMoveOffSet As Double = 500
    Public Axis2MaxMoveOffSet As Double = 500
    Public SenserInsertOffSet As Double = 300
    Public Axis1 As Int16 = 0
    Public Axis2 As Int16 = 1
    Public AxisSensor As Int16 = 2
    Public SensorMaxPostion As String = String.Empty
End Class
#End Region

