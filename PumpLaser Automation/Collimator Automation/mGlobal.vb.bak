Imports System.IO
Imports System.ComponentModel
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports PumpLaser_Automation.cIMCHandle
Imports PumpLaser_Automation.AxisInfo

Module mGlobal

#Region "Var"
    ' global var
    Public TargetValue() As String = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}  '11个值， 功率值 | 功能：记录异常功率信息，并保存至文件 |UpDataToFrom刷新这个值并保存， 异常选择忽略回刷新这个值， 手动录入会刷新这个值
    Public MySqlStr As New MysqlInfor   ' 产品数据MySqlStr：UI上数据Page里面控件值（产品器件信息）, 以及主要是运行过程中产生的（TargetValue）功率值|也可手动录入   《-》  csv文件
    Public EStop As Boolean             ' 紧急终止标记 '! when set=true?
    Public Ini As New cIniTool          ' INI 《-》Function.ini
    Public IsFlowOver As Boolean = False    '流程是否 已经结束

    Public FinshPower As Single     ' 完成功率， 程序未赋值 ~
    Public FinshPicth As Double     ' 程序未使用 ~
    Public FinshYaw As Double       ' 程序未使用 ~

    Public ILPOWER As Single        ' 程序未使用 ~

    Public productlist As New List(Of PRODUCTINLINEINFO)    ' 包含：生产时间 ,总的花费时间 ,指标, 回损 ，~未用
    Public CurrentProduct As New PRODUCTINLINEINFO

    Public IsTimerRefreshData As Boolean = True         ' 控制Timer1 是否实时刷新DataGraph曲线 | 是则刷新、否则不刷新
    Public TechPoint As New 光谱图坐标       ' 光谱图坐标：盲扫前移动pitch、yaw位置 ， 坐标信息来之与tech文件             
    Public CurVoltTool As New c恒惠                     ' 通过端口连接的电源
    Public MainForm As New MainFrm

    Public Maindir As New IO.DirectoryInfo("c:\OPAUTO_Data\Pumplaser")
    Public IniDir As New IO.DirectoryInfo(Maindir.FullName & "\Setting")
    Public ProductDir As New DirectoryInfo(Maindir.FullName & "\ProductFile") '產品檔放置路徑
    Public DailyReport As New IO.DirectoryInfo(Maindir.FullName & "\Dailylog")
    Public DailyLog As New IO.DirectoryInfo(Maindir.FullName & "\DailyReport")
    ' INI文件 - Function.ini
    Public IniFile As String = Maindir.FullName & "\Setting\" & "Function.ini"      ' INI文件
    Public IOFile As String = Maindir.FullName & "\Setting\" & "IO.ini"
    Public IOSettingfile As String = Maindir.FullName & "\Setting\" & "IO.xml"
    Public IOSetingIni As New IOSetting     ' 气件信息 | 气件控件（行、列），所有气件名、位置
    Public HomeFile As String = Maindir.FullName & "\Setting\" & "Home.xml"
    Public SystemIniFile As String = Maindir.FullName & "\Setting\" & "System.xml"
    Public PostionDir As New DirectoryInfo(Maindir.FullName & "\Pos")           '位置放置路徑 | 保存 流程花费时间： 流程ID，流程名称，花费时间
    Public TestFile As New DirectoryInfo(Maindir.FullName & "\log")             '位置放置路徑 | 日志
    Public Techfile As String = Maindir.FullName & "\Setting\" & "Techfile.xml" ' 光谱图坐标文件

    '界面的Defult | 功能模块的文件、对象
    Public AglinmentParaFile As String = Maindir.FullName & "\Setting\" & "AglinmentPara.xml"
    Public BlindParaFile As String = Maindir.FullName & "\Setting\" & "BlindPara.xml"
    Public InsertGalssParaFile As String = Maindir.FullName & "\Setting\" & "InsertGalssPara.xml"
    Public TouchParaFile As String = Maindir.FullName & "\Setting\" & "lTouchPara.xml"
    Public lTouchParaFile As String = Maindir.FullName & "\Setting\" & "TouchPara.xml"
    Public InserRotaionFile As String = Maindir.FullName & "\Setting\" & "InserRotaion.xml"
    Public ProductParaFile As String = Maindir.FullName & "\Setting\" & "Parameter.xml"
    Public AglinmentPara As New AgilenentPara()
    Public SaAlignmentPara As New SaAligamentPara() ' me
    Public BlindPara As New BlindSearchPara
    Public InsertGalssPara As New InserGalssTubePara
    Public cTouchPara As New TOUCHPARA
    Public clTouchPara As New TOUCHPARA
    Public InserRotaion As New InSertRotationPara

    Public ProductPara As New ProductParameter          ' 产品参数信息：产品参数 { 最大功率、端口、电压、电流、比较单位、复位流程、起始流程、通道号} | 叫系统参数更好
    Public CurrentFlow As New UserFlow  ' 流程
    Public HomeFlow As New cHomeFlow    ' 回原点对象
    Public IMC As InterfaceHandle   ' 运动控制器 借口
    Public ESP300 As New ClsESP300  '   ESP300功率计
    Public AxisInitalPara As New AxisParameter  ' 轴参数值 | 初始化轴、以及程序其它地方
    Public LensPostion As New PositionInformation       ' 轴的排序定位信息  在控制Page
    Public MiorroPosition As New PositionInformation    ' 轴的排序定位信息  在控制Page
    Public SystemIni As New cSystemParmater             ' 系统参数： 所有轴的比例参数设定、 以及Sensor最大最小、 马达最高速加速度  |有赋值但未使用 ~~
    Public AlimParameter As New cAlimParameter  'Alim参数： 功率波动、XZ步、Yaw步、m_YAWPitch   | 未使用~~
    Public CurrentIndex As Integer = 0  ' 当前流程处理的 阵列内 第几个芯片
    Public AxisParameterfile As String = Maindir.FullName & "\Setting\" & "AxisPara.xml"
    Private AutoRunThread As Threading.Thread   ' 流程过程
    Public MathTool As New Tool         'w 工具   ||好像用在 插补函数里 、插补法1函数里

    Public SaveProductInfo As New SaveDataProductInfo                                   ' 保存的产品对象{轴使用否、通道使用否、以及名称和输出名称} | 有赋值、但未见使用
    Public SaveProductInfofile As String = Maindir.FullName & "\Setting\" & "Save.xml"

    ' 未使用~~
    Structure InsertAxisData
        Public Power As Single
        Public DatumAxisPos As Single
        Public MoveAxisPos As Single
    End Structure
    Private FristInsertPostion As InsertAxisData
    Private AlignmentIteration As Int16 = 0 ' 未使用~~
    Private TestIndex As Int16 = 0          ' 未使用~~   
#End Region
    Public _IsPauseThread As Boolean = False ' 没有用到~~

#Region "function"
    ' 实际这段IO代码 未使用~~
    ' IO所有名称=值 | IO.txt
    Private _AirOperateName As New Hashtable
    ' 获取 IO所有名称=值 | IO.txt
    Public Sub AirOperateName()
        _AirOperateName.Clear()
        Try
            Dim SetStr() As String = IO.File.ReadAllLines(IOFile, System.Text.Encoding.Default)
            For i As Int16 = 0 To SetStr.Length - 1
                Dim SplitStr() As String = SetStr(i).Split("=")
                _AirOperateName.Add(SplitStr(1), SplitStr(0))
            Next
            Namelist()
        Catch ex As Exception

        End Try
    End Sub
    Public IsShowData As Boolean = False    ' 有赋值，但未使用~~
    ' 获得IO所有名称 | IO.txt
    Public Function Namelist() As List(Of String)
        Dim tmp As New List(Of String)
        For Each de As DictionaryEntry In _AirOperateName
            tmp.Add(de.Value)
        Next
        Return tmp
    End Function
    ' 获得IO 名称下的值 true|false
    Public Function GetIOIndex(ByVal name As String) As Integer
        '  Return 0
        Dim tmp As String = String.Empty
        For Each de As DictionaryEntry In _AirOperateName
            If de.Value = name Then
                tmp = de.Key
                Return Convert.ToInt32(tmp) - 1
            End If
        Next
        Return Convert.ToInt32(tmp) - 1
    End Function
    '
    ' 全局模块初始化
    '
    Sub New()
        ' init dir
        If IO.Directory.Exists(Maindir.FullName) = False Then IO.Directory.CreateDirectory(Maindir.FullName)
        If IO.Directory.Exists(PostionDir.FullName) = False Then IO.Directory.CreateDirectory(PostionDir.FullName)
        If IO.Directory.Exists(IniDir.FullName) = False Then IO.Directory.CreateDirectory(IniDir.FullName)
        If IO.Directory.Exists(DailyReport.FullName) = False Then IO.Directory.CreateDirectory(DailyReport.FullName)
        If IO.Directory.Exists(DailyLog.FullName) = False Then IO.Directory.CreateDirectory(DailyLog.FullName)
        If IO.Directory.Exists(ProductDir.FullName) = False Then IO.Directory.CreateDirectory(ProductDir.FullName)
        If IO.Directory.Exists(TestFile.FullName) = False Then IO.Directory.CreateDirectory(TestFile.FullName)
        ' load file
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of AxisParameter)(AxisInitalPara, New AxisParameter(), AxisParameterfile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of AxisParameter)(AxisInitalPara, AxisParameterfile)
        End If
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of IOSetting)(IOSetingIni, New IOSetting, IOSettingfile)                     ' 获得IO设定 ' 用的是IO。xml文件
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of AxisParameter)(AxisInitalPara, New AxisParameter(), AxisParameterfile)
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of 光谱图坐标)(TechPoint, New 光谱图坐标, Techfile)        ' 加载光谱图坐标
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of ProductParameter)(ProductPara, New ProductParameter, ProductParaFile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of ProductParameter)(ProductPara, ProductParaFile)
        End If
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of SaveDataProductInfo)(SaveProductInfo, New SaveDataProductInfo, SaveProductInfofile) = False Then
            BrainDll.BrainUserDll.GlobalTool.ToSave(Of SaveDataProductInfo)(SaveProductInfo, SaveProductInfofile)
        End If
        AirOperateName()    '获得所有IO名称、值， 放到_AirOperateName 。 未使用~~

        ' 检测到底是用网卡、还是雷塞卡。 默认网卡
        Dim dmc As New cXYZU
        Dim _IMC As New cIMCHandle
        Dim RV As String = Ini.GetINIValue("CardType", "Type", IniFile)
        Ini.WriteINIValue("CardType", "Note", "Type=0代表使用网络卡，Type=1代表使用雷赛卡", IniFile)
        If RV = "" Then
            Ini.WriteINIValue("CardType", "Type", "0", IniFile)
        End If
        RV = Ini.GetINIValue("CardType", "Type", IniFile)
        Select Case RV
            Case "0"
                IMC = CType(_IMC, InterfaceHandle)
            Case "1"
                IMC = CType(dmc, InterfaceHandle)
        End Select
        ' CurVoltTool.SetParameter(ProductPara.ProductCurrent, ProductPara.ProductVolte)
    End Sub
    ' 启用线程工作 | 芯片组装过程
    Public Sub StatrThread()

        AutoRunThread = New Threading.Thread(New Threading.ThreadStart(AddressOf TestRun))
        AutoRunThread.IsBackground = True
        AutoRunThread.Start()
    End Sub
    ' 终止线程工作 | 不在暂停状态下则终止
    Public Sub AbortThread()
        If AutoRunThread IsNot Nothing Then
            If AutoRunThread.ThreadState <> Threading.ThreadState.Suspended Then
                AutoRunThread.Abort()
            End If

        End If
    End Sub
    ' 暂停线程工作
    Public Sub PauseThread()
        If AutoRunThread IsNot Nothing Then
            AutoRunThread.Suspend()
        End If
    End Sub
    ' 回复线程工作
    Public Sub RePauseThread()
        If AutoRunThread IsNot Nothing Then
            AutoRunThread.Resume()
        End If
    End Sub
    Public MaunTest As Boolean = False                  ' 单独run 标记
    Public MaunObj As FlowFunctionlist.UerFuntion       ' 单独运行的函数
    Public MaunIndex As Int16                           ' 单独运行 第几步
    Private _IsReAuto As Boolean = False        '未使用~~
    ' 
    ' 芯片组装的实际过程
    ' 如果AutoRun and ！MaunTest 则run所有，即组装所有通道，每通道下所有流程步
    ' 如果AutoRun and manuTest=ture 则单独运行指定 MaunIndex， MaunObj， 默认第一个产品|通道
    ' 
    Sub TestRun()
        ' 
        ErrorTimeList.Clear()   ' clear ErrorTimeList
        Dim AsyTime As Date
        IMC.SetVeldef(3)        ' 定义3轴 标准速度模式

        If MainForm.AutoRun = True Then ' AutoRun
            TotalSpanMin = 0
            If MaunTest = False Then    ' 非手动运行标记， 表示接下来要组装 所有通道下所有流程即CurrentFlow
                For j As Integer = 0 To BoxHastable.Count - 1
                    ' 开始组装第j个通道
                    ChangeCheckBox(MainForm.ProductCb(BoxHastable(j)), Color.Green) '把当前通道号的背景色 设置为绿色
                    If CurrentFlow.FunctionList.Count > 0 Then
                        ' 开始跑流程 步
                        AsyTime = Now
                        MainForm.AddTrackMsg("正在组装通道#" & BoxHastable(j).ToString)
                        MainForm.AddTrackMsg("组装通道#" & BoxHastable(j).ToString & "" & "开始时间" & Now.ToString("HH:mm:ss"))
                        CurrentAbort = False
                        CurrentAbortIndex = -99
                        For i As Int16 = 0 To CurrentFlow.FunctionList.Count - 1
                            '
                            ' 如果不 勾选了则 
                            ' 勾选了有错则执行后， 必须上一步骤有错，才执行，否则不执行当前步骤
                            '
                            If CurrentFlow.FunctionList(i).IsErrorRun = False Then ' 没错 则执行
                                ' 正常执行当前步骤
                                StepToStepThread(CurrentFlow.FunctionList(i).FunctionName, i, j)
                            Else    ' 有错 则
                                If CurrentAbort = True Then ' 上一步骤有错了，同时勾中有错则执行，则执行当前步骤
                                    StepToStepThread(CurrentFlow.FunctionList(i).FunctionName, i, j)
                                End If
                            End If

                        Next
                    End If
                    ' 显示已完成的组装通道号， 并把这个通道号的钩去掉
                    System.Threading.Thread.Sleep(10)
                    MainForm.AddTrackMsg("完成组装通道#" & BoxHastable(j).ToString) ' & "" & "花费时间为" & MainForm.InterVal * 60 + MainForm.wh.Elapsed.TotalSeconds)
                    ContorlPerClick(MainForm.ProductCb(BoxHastable(j)), False)

                Next

            Else    ' 手动标记， 要单独运行指定的MaunObj
                StepToStepThread(MaunObj, MaunIndex)
            End If

        End If
        'For n As Int16 = 0 To MainForm.ProductCb.Count - 1
        '    ChangeCheckBox(MainForm.ProductCb(n), Color.Yellow)
        'Next

        MaunTest = False
        Dim totalH As Integer = TotalSpanMin / 3600
        Dim totalM As Integer = (TotalSpanMin - (totalH * 3600)) / 60
        Dim TotalS As Integer = Math.Abs(TotalSpanMin - (totalH * 3600 + totalM * 60))
        AddData("总花费时间", TotalSpanMin, 1)

        AddData("最终指标", FinshPower, 1)

        IsFlowOver = True
        ' ContorlChange(MainForm.lbSpanTime, totalH & ":" & totalM & ":" & TotalS) 'Convert.ToInt32(TotalSpanMin / 60).ToString & " min" & (TotalSpanMin - Convert.ToInt32(TotalSpanMin / 60)).ToString("0.00") & " s")
        ContorlPerClick(MainForm.cmdReset)  'w 

    End Sub

#End Region

#Region "单步测试"
    ' 刷新UI： 轴当前运动的信息
    Public Sub UpdataAxisInfo(ByVal AxisNo As Int16, ByVal Dir As Int16, ByVal Mode As Int16, ByVal pos As Double)
        ChangeTabIndex(MainForm.TabControl2, 4)
        ChangeCbIndex(MainForm.ComboBox8, AxisNo)
        ContorlChange(MainForm.MoveDir, Convert.ToString(IIf(Dir = 1, "正方向", "反方向")))
        ContorlChange(MainForm.moveMode, Convert.ToString(IIf(Mode = 0, "绝对运动", "相对运动")))
        ContorlChange(MainForm.MovePos, pos)
    End Sub
    Public Enum JogTpye
        Pos
        Speed
    End Enum
    Public Enum OpStep
        Ilde
        NextStep
        CurrentStep
    End Enum
    Public _OpStep As OpStep = OpStep.Ilde  ' 空闲 | 当前  | NextStep
    Public TotalSpanTime As Date = Now      ' 用于计算当前步所耗时间的 起始时间
    Public TotalSpanMin As Double = 0       ' 组装所有产品 总花费时间
    Public ErrorTimeList As New List(Of String) ' ~~
    ' 
    ' 刷新UI ListView某个项目醒目提醒，以及更新这个阶段时间  | 函数说明、时间
    Public Sub AddData(name As String, ts As String, index As Integer)

        If MainForm.listView1.InvokeRequired Then
            MainForm.listView1.Invoke(New Action(Of String, String, Integer)(AddressOf AddData), New Object() {name, ts, index})
        Else
            Dim lvitem As ListViewItem
            For Each lvitem In MainForm.listView1.Items
                If lvitem.SubItems.Item(1).Text = name Then
                    lvitem.Checked = True

                    lvitem.SubItems.Item(0).BackColor = Color.Green
                    lvitem.SubItems.Item(1).BackColor = Color.Green
                    lvitem.SubItems.Item(2).BackColor = Color.Green

                    lvitem.SubItems.Item(2).Text = ts & " s"
                    If Val(ts) > 10 AndAlso name <> "总花费时间" Then

                        ErrorTimeList.Add(name & ":" & ts)
                    End If
                Else
                    lvitem.Checked = False
                    lvitem.SubItems.Item(0).BackColor = Color.Gray
                    lvitem.SubItems.Item(1).BackColor = Color.Gray
                    lvitem.SubItems.Item(2).BackColor = Color.Gray
                End If
            Next

        End If
    End Sub
    Public Function ConvertPowerToDbm(unitStr As String, PowerValue As Single) As Single ' ~~
        Dim ReturnValue As Single
        Select Case unitStr.ToUpper
            Case "W"
                ReturnValue = 10 * Math.Log10(PowerValue / (Math.Pow(10, -3)))
            Case "MW"
                ReturnValue = 10 * Math.Log10(PowerValue / 1)
            Case "UW"
                ReturnValue = 10 * Math.Log10(PowerValue / (Math.Pow(10, 3)))
            Case "NW"
                ReturnValue = 10 * Math.Log10(PowerValue / (Math.Pow(10, 6)))
        End Select
        Return ReturnValue
    End Function
    '
    ' dbm转为功率值 | 冥次方转换、mw、KB值
    '
    Public Function ConvertdbmToPower(dbmvalue As Single, ByRef unitstr As String) As Single
        ' 10^{(dbmvalue / 10) - 3}
        Dim ReturnValue As Single = Math.Pow(10, (dbmvalue / 10) - 3)

        Dim index As Integer = 0
        Dim str As String = ReturnValue.ToString
        For i As Integer = 0 To str.Length - 1
            If str.ToString.Substring(i, 1) = "." Then
                index = i + 1
                Exit For
            End If
        Next

        ' w\mw\uw
        ReturnValue = ReturnValue * 1000
        unitstr = "mw"
        If ReturnValue > 1000 Then
            ReturnValue = ReturnValue / 1000
            unitstr = "w"
        Else
            If ReturnValue < 0.1 Then
                ReturnValue = ReturnValue * 1000
                unitstr = "uw"
            End If
        End If

        'kb
        Dim k, b As Double
        Dim rv As String = Ini.GetINIValue("PowerCal", "K", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("PowerCal", "K", "1", IniFile)
            rv = Ini.GetINIValue("PowerCal", "K", IniFile)
        Else
            k = rv
        End If
        rv = Ini.GetINIValue("PowerCal", "B", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("PowerCal", "B", "0", IniFile)
            rv = Ini.GetINIValue("PowerCal", "B", IniFile)
        Else
            b = rv
        End If
        ReturnValue = ReturnValue * k + b
        Return ReturnValue

    End Function
    Public ChirdFlow As New UserFlow
#Region "Auto"
    '
    ' 子流程
    Public Function StepToStepSubThread(ByVal status As FlowFunctionlist.UerFuntion, ByVal Index As Int32) As Boolean
        If EStop = True Then GoTo EStopProcess
        ChangeFlowlb(ChirdFlow.FunctionList.Item(Index).UserInfo)
        '  ChangelistIndex(Index)
        Dim ImcStatus As IMC_STATUS
        Debug.Print(ImcStatus.ToString)
        Dim StartTime As Date = Now
        Dim RepeatCount As Integer = 0
        DelayTime = ChirdFlow.FunctionList.Item(Index).DelayTime
        Select Case status
            Case FlowFunctionlist.UerFuntion.改变气动元件状态

again:
                StartTime = Now
                IsRefreshIOStatus = True
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).AirOp IsNot Nothing Then
                        For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                            If ChirdFlow.FunctionList(Index).AirOp(0).Operateitem = IOSetingIni.IOList(i).IOName Then
                                IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = ChirdFlow.FunctionList(Index).AirOp(0).OperateValue
                                Do
                                    If IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = ChirdFlow.FunctionList(Index).AirOp(0).OperateValue Then
                                        Exit Do
                                    End If
                                Loop
                                Exit For
                            End If
                        Next

                    End If
                    System.Threading.Thread.Sleep(50)
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again
                End If
                IsRefreshIOStatus = False
            Case FlowFunctionlist.UerFuntion.移动轴
again1:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        If ChirdFlow.FunctionList.Item(Index).AxisSetting(0).IsUsedAxis Then
                            If ChirdFlow.FunctionList.Item(Index).AxisSetting(0).ModeSpeed = SpeedMode.SlowSpeed Then
                                IMC.SetVelDown(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                            Else
                                If ChirdFlow.FunctionList.Item(Index).AxisSetting(0).ModeSpeed = SpeedMode.HighSpeed Then
                                    IMC.SetVelAcc(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                                End If
                            End If
                            UpdataAxisInfo(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Dir, ChirdFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            If ChirdFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode = AxisInfo.MoveMode.MoveAbs Then
                                ImcStatus = IMC.MoveAbs(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            Else
                                ImcStatus = IMC.MoveVel(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            End If
                        End If
                        System.Threading.Thread.Sleep(100)

                        Do
                            If IMC._IMCCardInformation(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        While True
                            If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    End If
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1
                End If
            Case FlowFunctionlist.UerFuntion.保存文件
                Try
                    ' MainForm.RefreshData(CurrentIndex)
                Catch ex As Exception

                End Try

            Case FlowFunctionlist.UerFuntion.移动轴使用文件路径
again2:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).IsUseFilePos Then
                        Dim Tmp As New List(Of BasepositionInformation)
                        Tmp = ChirdFlow.FunctionList.Item(Index).FileSetting
                        Dim TmpNew As New List(Of BasepositionInformation)
                        Dim TmpIndex As New List(Of Integer)

                        For i As Int16 = 0 To Tmp.Count - 1
                            If ChirdFlow.FunctionList.Item(Index).FileSetting(i).IsUsedThisPosition Then
                                If ChirdFlow.FunctionList.Item(Index).FileSetting(i).IsUsedThisPosition Then
                                    TmpIndex.Add(ChirdFlow.FunctionList.Item(Index).FileSetting(i).StartOrder)
                                End If

                            End If
                        Next
                        TmpIndex.Sort()

                        For i As Int16 = 0 To TmpIndex.Count - 1

                            For j As Int32 = 0 To Tmp.Count - 1
                                If ChirdFlow.FunctionList.Item(Index).FileSetting(j).IsUsedThisPosition Then
                                    If ChirdFlow.FunctionList.Item(Index).FileSetting(j).StartOrder = TmpIndex(i) Then
                                        ImcStatus = IMC.MoveAbs(ChirdFlow.FunctionList.Item(Index).FileSetting(j).AxisIndx, ChirdFlow.FunctionList.Item(Index).FileSetting(j).OderPosition)
                                        System.Threading.Thread.Sleep(100)

                                        Do
                                            If IMC._IMCCardInformation(ChirdFlow.FunctionList.Item(Index).FileSetting(j).AxisIndx).MotionDone Then
                                                Exit Do
                                            End If
                                        Loop
                                    End If
                                End If

                            Next


                        Next
                        While True
                            If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    End If

                End If
                TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again2
                End If
            Case FlowFunctionlist.UerFuntion.找零界点
again5:
                StartTime = Now
                Try
                    MainForm.ChangeTabIndex("传感器")
                Catch ex As Exception

                End Try
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    System.Threading.Thread.Sleep(15)
                    _SensorTouncStep = TounchStep.Statr
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        UpdataSensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel)

                        SensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again5
                End If
            Case FlowFunctionlist.UerFuntion.盲扫
again7:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    ReNum = 0
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        UpDataBlindSearchInfo(ChirdFlow.FunctionList(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList(Index).AxisSetting(1).AxisNo, ChirdFlow.FunctionList(Index).AxisSetting(0).BlindSearchRang, ChirdFlow.FunctionList(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList(Index).AxisSetting(0).Channel, ChirdFlow.FunctionList(Index).AxisSetting(0).PowerMax)
                        Blind_Search_Alignment(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(1).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).BlindSearchRang, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again7
                End If
            Case FlowFunctionlist.UerFuntion.PD对准
again8:
                Try
                    MainForm.ChangeTabIndex("模拟功率")
                Catch ex As Exception

                End Try
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting.Count = 2 Then
                        Dim AxisNolist As New List(Of Integer)
                        AxisNolist.Clear()
                        AxisNolist.Add(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                        AxisNolist.Add(ChirdFlow.FunctionList.Item(Index).AxisSetting(1).AxisNo)
                        '  AxisNolist.Add(ChirdFlow.FunctionList.Item(Index).AxisSetting(2).AxisNo)
                        Dim _Pitch As String = ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth & "," & ChirdFlow.FunctionList.Item(Index).AxisSetting(1).Picth

                        Dim obj As New AgilenentPara
                        obj._AxisNo = AxisNolist
                        obj._Picth = _Pitch
                        obj._Delta = ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate
                        obj._Channel = ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel
                        obj._PicthCount = ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PicthCount
                        obj._IretCount = ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Recursion
                        For i As Integer = 0 To AxisNolist.Count - 1
                            If ChirdFlow.FunctionList.Item(Index).AxisSetting(i).IsNeedFouseLighr Then
                                obj.IsUseIretCount = obj.IsUseIretCount & "1" & ","
                            Else
                                obj.IsUseIretCount = obj.IsUseIretCount & "0" & ","
                            End If
                        Next
                        obj.IsUseIretCount = obj.IsUseIretCount.Trim(Convert.ToChar(","))
                        简单攀升法(obj)
                    End If
                    System.Threading.Thread.Sleep(200)
                    Dim Tmp As Double
                    GetChannelData(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, Tmp)
                    Dim StrUnit As String = "w"
                    ConvertdbmToPower(Tmp, StrUnit)
                    Select Case StrUnit.ToUpper
                        Case "W"
                            Tmp = Tmp
                        Case "MW"
                            Tmp = Tmp / 1000
                        Case "UW"
                            Tmp = Tmp / 1000000
                    End Select
                    If Tmp < CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax Then
                        Dim rs As DialogResult = MessageBox.Show("指标差距较大，是否要停止机台", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                        If rs = DialogResult.Abort Then
                            MessageBox.Show("机台停止")
                            ContorlPerClick(MainForm.cmdReset)
                        End If
                        If rs = DialogResult.Retry Then
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        If rs = DialogResult.Ignore Then
                            TargetValue(BoxHastable(CurrentIndex)) = Tmp
                        End If
                    End If
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again8
                End If
            Case FlowFunctionlist.UerFuntion.用户提示
                If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
            Case FlowFunctionlist.UerFuntion.SaveReferenceFile
                Try
                    If ChirdFlow.FunctionList(Index).IsUsedReferenceInterface Then
                        If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisXPosition = IMC.GetCurrentPos(0)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisYPosition = IMC.GetCurrentPos(1)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisZPosition = IMC.GetCurrentPos(2)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisRPosition = IMC.GetCurrentPos(3)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisPitchPosition = IMC.GetCurrentPos(4)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisYawPosition = IMC.GetCurrentPos(5)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.AxisM_ZPosition = IMC.GetCurrentPos(6)
                        '  ChirdFlow.FunctionList(Index).ReferenceInterface.AxisXPosition = IMC.GetCurrentPos(7)
                    End If
                    Try
                        ChirdFlow.FunctionList(Index).ReferenceInterface.OutFilePath = ChirdFlow.FunctionList(Index).SaveFilePath ', ChirdFlow.FunctionList(Index).ReferenceInterface.ToString)
                        ChirdFlow.FunctionList(Index).ReferenceInterface.SaveData()
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try
            Case FlowFunctionlist.UerFuntion.GoReferenceFile
                Try
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    If ChirdFlow.FunctionList(Index).IsUsedReferenceInterface Then
                        Dim movepos() As String = File.ReadAllLines(ChirdFlow.FunctionList(Index).SaveFilePath, System.Text.Encoding.Default)
                        For i As Int16 = 0 To movepos.Length - 1
                            Dim data() As String = movepos(i).Split(":")
                            Select Case data(0)
                                Case "AxisXPosition"
                                    IMC.MoveAbs(0, data(1))
                                    While True
                                        If IMC._IMCCardInformation(0).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisYPosition"
                                    IMC.MoveAbs(1, data(1))
                                    While True
                                        If IMC._IMCCardInformation(1).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisZPosition"
                                    IMC.MoveAbs(2, data(1))
                                    While True
                                        If IMC._IMCCardInformation(2).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisRPosition"
                                    IMC.MoveAbs(3, data(1))
                                    While True
                                        If IMC._IMCCardInformation(3).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisPitchPosition"
                                    IMC.MoveAbs(4, data(1))
                                    While True
                                        If IMC._IMCCardInformation(4).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisYawPosition"
                                    IMC.MoveAbs(5, data(1))
                                    While True
                                        If IMC._IMCCardInformation(5).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisM_ZPosition"
                                    IMC.MoveAbs(6, data(1))
                                    While True
                                        If IMC._IMCCardInformation(6).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                            End Select
                        Next
                    End If
                Catch ex As Exception

                End Try
            Case FlowFunctionlist.UerFuntion.JugeTargetValue
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        'UpdataSensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel)
                        Dim TmpPower As Double
                        System.Threading.Thread.Sleep(10)

                        GetChannelData(ProductPara.ChannelIndex, TmpPower)
                        Dim StrUnit As String = "w"
                        ConvertdbmToPower(TmpPower, StrUnit)
                        Select Case StrUnit.ToUpper
                            Case "W"
                                TmpPower = TmpPower
                            Case "MW"
                                TmpPower = TmpPower / 1000
                            Case "UW"
                                TmpPower = TmpPower / 1000000
                        End Select
                        If TmpPower < ProductPara.MaxPower Then
                            Dim Re As DialogResult
                            Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.AbortRetryIgnore)
                            If Re = DialogResult.Abort Then
                                MessageBox.Show("机台停止")
                                ContorlPerClick(MainForm.cmdReset)
                            End If
                            If Re = DialogResult.Retry Then
                                ContorlPerClick(MainForm.cmdRun)
                            End If
                            If Re = DialogResult.Ignore Then
                                TargetValue(BoxHastable(CurrentIndex)) = TmpPower
                            End If
                        End If
                        ' SensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
            Case FlowFunctionlist.UerFuntion.GetCurrentPowerMeterValue
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        'UpdataSensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel)
                        Dim TmpPower As Double
                        System.Threading.Thread.Sleep(10)

                        GetChannelData(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, TmpPower)
                        If TmpPower > ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax Then
                            Dim Re As DialogResult
                            'Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.YesNo)
                            Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.AbortRetryIgnore)
                            If Re = DialogResult.Abort Then
                                MessageBox.Show("机台停止")
                                ContorlPerClick(MainForm.cmdReset)
                            End If
                            If Re = DialogResult.Retry Then
                                ContorlPerClick(MainForm.cmdRun)
                            End If
                            If Re = DialogResult.Ignore Then
                                TargetValue(BoxHastable(CurrentIndex)) = TmpPower
                            End If
                        End If
                        ' SensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    While True
                        If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
            Case FlowFunctionlist.UerFuntion.GoArryBox
again1111:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    If ChirdFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        If ChirdFlow.FunctionList.Item(Index).AxisSetting(0).IsUsedAxis Then
                            UpdataAxisInfo(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Dir, ChirdFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            Dim PicthCountIndex As Int16
                            PicthCountIndex = BoxHastable(CurrentIndex)
                            ImcStatus = IMC.MoveAbs(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth * PicthCountIndex + ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            CurrentIndex = CurrentIndex + 1
                        End If
                        System.Threading.Thread.Sleep(100)

                        Do
                            If IMC._IMCCardInformation(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        While True
                            If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    End If
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(ChirdFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1111
                End If
            Case FlowFunctionlist.UerFuntion.打开电源
again1112:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                System.Threading.Thread.Sleep(10)
                CurVoltTool.CurrentOut = True
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1112
                End If
                While True
                    If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If

            Case FlowFunctionlist.UerFuntion.关闭电源
again1113:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                CurVoltTool.CurrentOut = False
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1113
                End If
                While True
                    If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
            Case FlowFunctionlist.UerFuntion.设定电源参数
again1114:
                StartTime = Now
                If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                CurVoltTool.SetParameter(ChirdFlow.FunctionList.Item(Index).ProductCurrent, ChirdFlow.FunctionList.Item(Index).ProductVolt)
                If RepeatCount < ChirdFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1114
                End If
                While True
                    If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If ChirdFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
            Case FlowFunctionlist.UerFuntion.设定电源输出波形
again1115:
                If ChirdFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                If IO.File.Exists(ChirdFlow.FunctionList(Index).Prompt) = True Then
                    Dim totalList() As String = IO.File.ReadAllLines(ChirdFlow.FunctionList(Index).Prompt)

                    For i As Int16 = 0 To totalList.Length - 1
                        Dim listTotal() As String = totalList(i).Split(",")
                        StartTime = Now
                        CurVoltTool.SetParameter(listTotal(0), listTotal(1))
                        While True
                            If Now.Subtract(StartTime).TotalSeconds > ChirdFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    Next
                End If




                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1115
                End If
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
        End Select
EStopProcess:

    End Function
    Public IsAutoAligment As Boolean = False    ' PD对准标记， 非则刷新Graph
    Public CurrentAbort As Boolean = False          ' 当前组装通道号内： 有错误了 需要终止 标记
    Public CurrentAbortIndex As Integer = -9 '      ’当前组装通道号内： 有错误了 需要终止 通道号
    '
    ' 执行流程中某个功能：  
    '   status 需要执行的功能序列号， Index执行流程的当前步骤号， Product当前的组装通道号
    '
    Public Function StepToStepThread(ByVal status As FlowFunctionlist.UerFuntion, ByVal Index As Int32, Optional ProductNo As Integer = 0) As Boolean

        '  ChangelistIndex(Index)
        Dim StepTime As Date                ' 每一步起始时间， 用于计算当前步的运行时间
        Dim ImcStatus As IMC_STATUS
        Debug.Print(ImcStatus.ToString)
        Dim StartTime As Date = Now         ' 延迟等待开始时间， 一般用于延迟等待
        Dim RepeatCount As Integer = 0      ' 重复执行的计数器
        If EStop = True Then GoTo EstopFlow

        ' 显示函数信息、正在组装的通道号 等
        ChangeFlowlb(CurrentFlow.FunctionList.Item(Index).UserInfo)         ' 函数文字信息
        DelayTime = CurrentFlow.FunctionList.Item(Index).DelayTime          ' 函数指定的延迟时间
        ContorlChange(MainForm.Label77, "通道 " & (BoxHastable(ProductNo) + 1).ToString)  '主界面Label显示： 通道1 - 通道16

        Select Case status

            ' 获取板卡IO输出输入状态  ||
            '  读取IO位值，当《》指定状态则重复执行指定的次数，依然不等则警告提示
            '    当选择忽略则（恢复计时），选择终止（则终止以后需错误就不执行步则不执行、错误才执行则执行）
            '    貌似选择retry则 点击按钮cmdRun，貌似暂停
            '   再循环指定次数, 延迟等待一段时间，是否需要暂停 
            Case FlowFunctionlist.UerFuntion.获取板卡IO输出输入状态   '判断当前IO口实际状态 是否和CurrentFlow.FunctionList(Index).IOStatus 一致， 不一致则弹出 警告提示框

AgainJudg:
                StepTime = Now  '计时开始
                ' （1）有错需终止（CurrentAbort）、（2）属于当前通道、 （3）有错不执行勾中， 则直接跳到底端
                If CurrentAbort = True Then ' （1）有错需终止（CurrentAbort）
                    If ProductNo = CurrentAbortIndex Then ' 属于当前通道    当前传入通道号=需终止通道号
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then ' 有错不执行勾中
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then ' 允许执行才执行
                    ' 第一个通道以后（即第二及以后...  是否要重复执行
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    ' 
                    Select Case CurrentFlow.FunctionList(Index).IOChannel    'IO通道类别：输入通道1、或 输出通道0
                        Case 1     '输入类型
                            If IMC.ReadIn(CurrentFlow.FunctionList(Index).IOIndex, 0) <> CurrentFlow.FunctionList(Index).IOStatus Then  ' 检测指定位置器件状态是否 跟预定状态 一样  | 器件（GIO1）IO 第几位 状态
                                ' 不一致， 则再检测指定的次数
                                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                                    RepeatCount = RepeatCount + 1
                                    GoTo AgainJudg
                                End If

                                MainForm.wh.Stop()
                                Dim rs As DialogResult = MessageBox.Show("信号灯异常！", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                                If rs = DialogResult.Abort Then
                                    'MessageBox.Show("机台停止")
                                    CurrentAbort = True
                                    CurrentAbortIndex = ProductNo
                                End If
                                If rs = DialogResult.Retry Then
                                    ContorlPerClick(MainForm.cmdRun)    'W 
                                End If
                                If rs = DialogResult.Ignore Then
                                    '
                                    MainForm.wh.Start()
                                End If

                            End If
                        Case 0     '输出类型
                            If IMC.WriteOut(CurrentFlow.FunctionList(Index).IOIndex, 0) <> CurrentFlow.FunctionList(Index).IOStatus Then
                                GoTo AgainJudg          'P 无法正常输出状态则重复循环中
                                MainForm.wh.Stop()
                                Dim rs As DialogResult = MessageBox.Show("信号灯异常！", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                                If rs = DialogResult.Abort Then
                                    'MessageBox.Show("机台停止")
                                    CurrentAbort = True
                                    CurrentAbortIndex = ProductNo
                                End If
                                If rs = DialogResult.Retry Then
                                    ContorlPerClick(MainForm.cmdRun)
                                End If
                                If rs = DialogResult.Ignore Then
                                    '
                                    MainForm.wh.Start()
                                End If

                            End If
                    End Select
                    MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
                End If

            ' GetCurrentSpec
            '  获得当前电流判断是否不符合要求； 不符合则重复再读再判断若干次，若都不符合要求则提醒用户做处理 | CurCurrent < ProductCurrent * ProductVolt
            '  处理是否暂停 
            Case FlowFunctionlist.UerFuntion.GetCurrentSpec
againqqqq:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If

                'CurVoltTool.SetParameter(CurrentFlow.FunctionList.Item(Index).ProductCurrent, CurrentFlow.FunctionList.Item(Index).ProductVolt)
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    '
                    '
                    Dim Volt As String = ""
                    Dim Cur As String = ""
                    CurVoltTool.GetOutPutCurentValue(Cur)

                    If Cur = "" Then Cur = -99
                    Dim CurCurrent As Double
                    Try
                        CurCurrent = Convert.ToDouble(Cur)
                    Catch ex As Exception
                        CurCurrent = 0
                    End Try
                    '! CurCurrent < CurrentFlow.FunctionList.Item(Index).ProductCurrent * CurrentFlow.FunctionList.Item(Index).ProductVolt
                    If CurCurrent < CurrentFlow.FunctionList.Item(Index).ProductCurrent * CurrentFlow.FunctionList.Item(Index).ProductVolt Then
                        If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                            RepeatCount = RepeatCount + 1
                            GoTo againqqqq
                        End If

                        MainForm.wh.Stop()
                        Dim rs As DialogResult = MessageBox.Show("电流输出异常，是否要停止机台", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                        If rs = DialogResult.Abort Then
                            'MessageBox.Show("机台停止")
                            CurrentAbort = True
                            CurrentAbortIndex = ProductNo
                        End If
                        If rs = DialogResult.Retry Then
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        If rs = DialogResult.Ignore Then
                            '
                            MainForm.wh.Start()
                        End If

                        ' 暂停执行的
                        If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        'If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                        '    RepeatCount = RepeatCount + 1
                        '    GoTo againqqqq
                        'End If
                    End If

                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 判断电压  ||
            '  读取当前电压，当《ProductCurrent*ProductVolt，警告提示
            '    当选择忽略则（恢复计时），选择终止（则终止以后需错误就不执行步则不执行、错误才执行则执行）
            '  暂停否   
            Case FlowFunctionlist.UerFuntion.判断电压
againqqqqf:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If
                    End If
                End If

                'CurVoltTool.SetParameter(CurrentFlow.FunctionList.Item(Index).ProductCurrent, CurrentFlow.FunctionList.Item(Index).ProductVolt)
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                    Dim Volt As String = ""
                    Dim Cur As String = ""
                    CurVoltTool.GetOutPutVoltValue(Cur)
                    If Cur = "" Then Cur = -99
                    Dim CurCurrent As Double
                    Try
                        CurCurrent = Convert.ToDouble(Cur)
                    Catch ex As Exception
                        CurCurrent = 0
                    End Try
                    If CurCurrent < CurrentFlow.FunctionList.Item(Index).ProductCurrent * CurrentFlow.FunctionList.Item(Index).ProductVolt Then
                        If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                            RepeatCount = RepeatCount + 1
                            GoTo againqqqqf
                        End If

                        MainForm.wh.Stop()
                        Dim rs As DialogResult = MessageBox.Show("电压输出异常，是否要停止机台", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                        If rs = DialogResult.Abort Then
                            'MessageBox.Show("机台停止")
                            CurrentAbort = True
                            CurrentAbortIndex = ProductNo
                        End If
                        If rs = DialogResult.Retry Then
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        If rs = DialogResult.Ignore Then
                            '
                            MainForm.wh.Start()
                        End If
                        If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        'If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                        '    RepeatCount = RepeatCount + 1
                        '    GoTo againqqqqf
                        'End If
                    End If

                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 改变气动元件状态  ||
            '  依次改变状态，每次改再反复读取直到改变位置
            '  延迟等待一段时间，是否需要暂停  ，再循环指定次数, 
            Case FlowFunctionlist.UerFuntion.改变气动元件状态

again:
                IsRefreshIOStatus = True
                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                IsRefreshIOStatus = False
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now

                    If CurrentFlow.FunctionList.Item(Index).AirOp IsNot Nothing Then
                        For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                            If CurrentFlow.FunctionList(Index).AirOp(0).Operateitem = IOSetingIni.IOList(i).IOName Then
                                IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = CurrentFlow.FunctionList(Index).AirOp(0).OperateValue
                                Do
                                    If IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0) = CurrentFlow.FunctionList(Index).AirOp(0).OperateValue Then
                                        Exit Do '? 
                                    End If
                                Loop
                                Exit For
                            End If
                        Next

                    End If
                    System.Threading.Thread.Sleep(50)
                    ' 做延迟处理， 必须让延迟时间》=当前步运行时间+现在要等待的时间 才能进行下一步
                    While True
                        ' StartTime 运行开始时间 | 运行结束后判定 运行时间+ 等 要》 DelayTime
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then

                            Exit While
                        End If
                    End While
                    ' 
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    ' 刷新UI上 醒目ListView中当前项目 这个实际运行时间（更改器件时间+延迟时间）
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    ' 是否需要暂停处理
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                ' 重复指定执行 | 重复设定器件状态若干次数 
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again
                End If
                ' 刷新UI （器件、运行时间） 
                IsRefreshIOStatus = False
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 增加子流程  || Prompt文件
            '  执行子流程所有步
            '   
            Case FlowFunctionlist.UerFuntion.增加子流程

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    ' 依次执行子流程（文件）下 所有流程步骤
                    Dim filePath As String = CurrentFlow.FunctionList.Item(Index).Prompt
                    If File.Exists(filePath) AndAlso BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(ChirdFlow, New UserFlow, filePath) Then
                        If ChirdFlow.FunctionList.Count > 0 Then
                            For i As Int16 = 0 To ChirdFlow.FunctionList.Count - 1
                                ' 步骤名称 第几步
                                StepToStepSubThread(ChirdFlow.FunctionList(i).FunctionName, i)
                            Next
                        End If
                    End If
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 移动轴  || （单次？）
            '  根据自定的方向、速度、位置 移动，等待马达停止
            '  延迟等待一段时间，是否需要暂停，再循环指定次数,  
            Case FlowFunctionlist.UerFuntion.移动轴
again1:
                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If

                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                    TotalSpanTime = Now
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        ' 使用轴情况下，开始移动轴
                        If CurrentFlow.FunctionList.Item(Index).AxisSetting(0).IsUsedAxis Then
                            ' 选择高速模式、 低速模式
                            If CurrentFlow.FunctionList.Item(Index).AxisSetting(0).ModeSpeed = SpeedMode.SlowSpeed Then
                                IMC.SetVelDown(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                            Else
                                If CurrentFlow.FunctionList.Item(Index).AxisSetting(0).ModeSpeed = SpeedMode.HighSpeed Then
                                    IMC.SetVelAcc(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                                End If
                            End If
                            ' 刷新UI 显示为 当前要运动的信息
                            UpdataAxisInfo(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Dir, CurrentFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            ' 移动轴
                            If CurrentFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode = AxisInfo.MoveMode.MoveAbs Then
                                ImcStatus = IMC.MoveAbs(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            Else
                                ImcStatus = IMC.MoveVel(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            End If
                        End If
                        System.Threading.Thread.Sleep(100)
                        ' 等待马达停止
                        Do
                            If IMC._IMCCardInformation(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        ' 刷新UI 当前正在等待延迟时间 | 倒着数，|  这个是实实在在等待时间 等待时间》指定延迟才继续下去
                        StartTime = Now
                        While True
                            ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                            If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    End If
                    '
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    '
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    ' pause 
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                ' 重复执若干次
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1
                End If
                ' 刷新UI
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
            ' 保存文件
            Case FlowFunctionlist.UerFuntion.保存文件
                StepTime = Now
                Try
                    ' MainForm.RefreshData()
                Catch ex As Exception

                End Try
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 移动轴使用文件路径 || 轴位置来之与 排序FileSetting  （文件 | PositionInformation）
            '  当IsUseFilePos=true， 排序FileSetting（orderIndex），按顺序移动轴，每次等待结束
            '  延迟等待一段时间，是否需要暂停 ,再循环指定次数,
            Case FlowFunctionlist.UerFuntion.移动轴使用文件路径
again2:

                StepTime = Now
                StartTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now

                    If CurrentFlow.FunctionList.Item(Index).IsUseFilePos Then
                        Dim Tmp As New List(Of BasepositionInformation)
                        Tmp = CurrentFlow.FunctionList.Item(Index).FileSetting
                        Dim TmpNew As New List(Of BasepositionInformation)
                        Dim TmpIndex As New List(Of Integer)

                        For i As Int16 = 0 To Tmp.Count - 1
                            If CurrentFlow.FunctionList.Item(Index).FileSetting(i).IsUsedThisPosition Then
                                If CurrentFlow.FunctionList.Item(Index).FileSetting(i).IsUsedThisPosition Then
                                    TmpIndex.Add(CurrentFlow.FunctionList.Item(Index).FileSetting(i).StartOrder)
                                End If

                            End If
                        Next
                        TmpIndex.Sort()

                        For i As Int16 = 0 To TmpIndex.Count - 1

                            For j As Int32 = 0 To Tmp.Count - 1
                                If CurrentFlow.FunctionList.Item(Index).FileSetting(j).IsUsedThisPosition Then
                                    If CurrentFlow.FunctionList.Item(Index).FileSetting(j).StartOrder = TmpIndex(i) Then
                                        ImcStatus = IMC.MoveAbs(CurrentFlow.FunctionList.Item(Index).FileSetting(j).AxisIndx, CurrentFlow.FunctionList.Item(Index).FileSetting(j).OderPosition)
                                        System.Threading.Thread.Sleep(100)

                                        Do
                                            If IMC._IMCCardInformation(CurrentFlow.FunctionList.Item(Index).FileSetting(j).AxisIndx).MotionDone Then
                                                Exit Do
                                            End If
                                        Loop
                                    End If
                                End If

                            Next


                        Next
                        StartTime = Now
                        While True
                            ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                            If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    End If

                End If
                TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again2
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 找零界点  ||
            '  SensorTouch 
            '   延迟等待一段时间，是否需要暂停，再循环指定次数  
            Case FlowFunctionlist.UerFuntion.找零界点
again5:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                Try
                    MainForm.ChangeTabIndex("传感器")
                Catch ex As Exception

                End Try
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    '
                    TotalSpanTime = Now
                    System.Threading.Thread.Sleep(15)
                    _SensorTouncStep = TounchStep.Statr
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        ' 
                        UpdataSensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel)
                        ' 
                        SensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again5
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 寻找光的临界点  || 
            '  SearchLightLimit
            ' 
            '  延迟等待一段时间，是否需要暂停  ，再循环指定次数
            Case FlowFunctionlist.UerFuntion.寻找光的临界点
again5s:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                Try
                    MainForm.ChangeTabIndex("模拟功率")
                Catch ex As Exception

                End Try
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    TotalSpanTime = Now
                    System.Threading.Thread.Sleep(15)

                    _SensorTouncStep = TounchStep.Statr
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        UpdataSensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel)

                        SearchLightLimit(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If

                    System.Threading.Thread.Sleep(15)
                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again5s
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 盲扫  || 盲扫前参数会回显示到功能模块的UI控件里面 |其它类似
            '  Blind_Search_Alignment
            '   延迟等待一段时间，是否需要暂停 ，再循环指定次数
            Case FlowFunctionlist.UerFuntion.盲扫
again7:

                StepTime = Now
                StartTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                    ReNum = 0
                    TotalSpanTime = Now
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        UpDataBlindSearchInfo(CurrentFlow.FunctionList(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList(Index).AxisSetting(1).AxisNo, CurrentFlow.FunctionList(Index).AxisSetting(0).BlindSearchRang, CurrentFlow.FunctionList(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList(Index).AxisSetting(0).Channel, CurrentFlow.FunctionList(Index).AxisSetting(0).PowerMax)
                        Blind_Search_Alignment(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(1).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).BlindSearchRang, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s）" & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again7
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' PD对准  || 必须有2轴信息
            '  简单攀升法， 获得当前功率值（如还《CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax）则警告提示
            '   选择ignore 则 TargetValue(BoxHastable(ProductNo)) = Tmp
            '  延迟等待一段时间，是否需要暂停 ，再循环指定次数
            Case FlowFunctionlist.UerFuntion.PD对准
again8:
                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                IsAutoAligment = True   '自动对准
                Try
                    MainForm.ChangeTabIndex("模拟功率")
                Catch ex As Exception

                End Try
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                    TotalSpanTime = Now
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting.Count = 2 Then  '对准必须提供2轴信息
                        Dim AxisNolist As New List(Of Integer)
                        AxisNolist.Clear()
                        AxisNolist.Add(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo)
                        AxisNolist.Add(CurrentFlow.FunctionList.Item(Index).AxisSetting(1).AxisNo)
                        '  AxisNolist.Add(CurrentFlow.FunctionList.Item(Index).AxisSetting(2).AxisNo)
                        Dim _Pitch As String = CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth & "," & CurrentFlow.FunctionList.Item(Index).AxisSetting(1).Picth

                        Dim obj As New AgilenentPara
                        obj._AxisNo = AxisNolist
                        obj._Picth = _Pitch
                        obj._Delta = CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate
                        obj._Channel = CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel
                        obj._PicthCount = CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PicthCount
                        obj._IretCount = CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Recursion
                        For i As Integer = 0 To AxisNolist.Count - 1
                            If CurrentFlow.FunctionList.Item(Index).AxisSetting(i).IsNeedFouseLighr Then '需要聚焦，即要递归
                                obj.IsUseIretCount = obj.IsUseIretCount & "1" & ","
                            Else
                                obj.IsUseIretCount = obj.IsUseIretCount & "0" & ","
                            End If
                        Next
                        obj.IsUseIretCount = obj.IsUseIretCount.Trim(Convert.ToChar(","))
                        简单攀升法(obj)
                    End If
                    System.Threading.Thread.Sleep(200)

                    Dim Tmp As Double
                    GetChannelData(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, Tmp)
                    Dim StrUnit As String = "w"
                    Tmp = ConvertdbmToPower(Tmp, StrUnit)
                    Select Case StrUnit.ToUpper
                        Case "W"
                            Tmp = Tmp
                        Case "MW"
                            Tmp = Tmp / 1000
                        Case "UW"
                            Tmp = Tmp / 1000000
                    End Select

                    If Tmp < CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax Then
                        MainForm.wh.Stop()
                        Dim rs As DialogResult = MessageBox.Show("指标差距较大，是否要停止机台", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                        If rs = DialogResult.Abort Then
                            'MessageBox.Show("机台停止")
                            CurrentAbort = True
                            CurrentAbortIndex = ProductNo
                        End If
                        If rs = DialogResult.Retry Then
                            IsAutoAligment = False
                            ContorlPerClick(MainForm.cmdRun)
                        End If
                        If rs = DialogResult.Ignore Then
                            TargetValue(BoxHastable(ProductNo)) = Tmp
                            MainForm.wh.Start()
                        End If
                    End If

                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)

                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If

                End If
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again8
                End If

                IsAutoAligment = False
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 用户提示  ||
            '  label 显示提示啊
            '   延迟等待一段时间，是否需要暂停 
            Case FlowFunctionlist.UerFuntion.用户提示

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                ' 
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                ' 
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' SaveReferenceFile  ||
            '  当IsUsedReferenceInterface=true， 保存所有轴位置
            '   
            Case FlowFunctionlist.UerFuntion.SaveReferenceFile

                StepTime = Now
                Try
                    If CurrentAbort = True Then
                        If ProductNo = CurrentAbortIndex Then
                            If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                                GoTo EstopFlow
                            End If

                        End If
                    End If
                    '
                    If CurrentFlow.FunctionList(Index).IsUsedReferenceInterface Then
                        If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisXPosition = IMC.GetCurrentPos(0)

                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisYPosition = IMC.GetCurrentPos(1)



                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisYPosition = IMC.GetCurrentPos(1)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisZPosition = IMC.GetCurrentPos(2)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisRPosition = IMC.GetCurrentPos(3)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisPitchPosition = IMC.GetCurrentPos(4)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisYawPosition = IMC.GetCurrentPos(5)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.AxisM_ZPosition = IMC.GetCurrentPos(6)
                        '  CurrentFlow.FunctionList(Index).ReferenceInterface.AxisXPosition = IMC.GetCurrentPos(7)
                    End If
                    Try
                        CurrentFlow.FunctionList(Index).ReferenceInterface.OutFilePath = CurrentFlow.FunctionList(Index).SaveFilePath ', CurrentFlow.FunctionList(Index).ReferenceInterface.ToString)
                        CurrentFlow.FunctionList(Index).ReferenceInterface.SaveData()
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' GoReferenceFile  ||
            '   依次移动轴（每次移动都需要等待移动结束），数据来于文件中坐标
            '   延迟等待一段时间
            Case FlowFunctionlist.UerFuntion.GoReferenceFile

                StepTime = Now
                Try
                    If CurrentAbort = True Then
                        If ProductNo = CurrentAbortIndex Then
                            If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                                GoTo EstopFlow
                            End If

                        End If
                    End If
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    '
                    If CurrentFlow.FunctionList(Index).IsUsedReferenceInterface Then
                        Dim movepos() As String = File.ReadAllLines(CurrentFlow.FunctionList(Index).SaveFilePath, System.Text.Encoding.Default)
                        For i As Int16 = 0 To movepos.Length - 1
                            Dim data() As String = movepos(i).Split(":")
                            Select Case data(0)
                                Case "AxisXPosition"
                                    IMC.MoveAbs(0, data(1))
                                    While True
                                        If IMC._IMCCardInformation(0).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisYPosition"
                                    IMC.MoveAbs(1, data(1))
                                    While True
                                        If IMC._IMCCardInformation(1).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisZPosition"
                                    IMC.MoveAbs(2, data(1))
                                    While True
                                        If IMC._IMCCardInformation(2).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisRPosition"
                                    IMC.MoveAbs(3, data(1))
                                    While True
                                        If IMC._IMCCardInformation(3).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisPitchPosition"
                                    IMC.MoveAbs(4, data(1))
                                    While True
                                        If IMC._IMCCardInformation(4).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisYawPosition"
                                    IMC.MoveAbs(5, data(1))
                                    While True
                                        If IMC._IMCCardInformation(5).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                                Case "AxisM_ZPosition"
                                    IMC.MoveAbs(6, data(1))
                                    While True
                                        If IMC._IMCCardInformation(6).MotionDone Then
                                            Exit While
                                        End If
                                    End While
                                    System.Threading.Thread.Sleep(50)
                            End Select
                        Next
                    End If
                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                Catch ex As Exception

                End Try
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' GetCurrentPowerMeterValue  ||
            '  CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel 》  CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax 时异常警告
            '    当选择忽略则 TargetValue(BoxHastable(ProductNo)) = TmpPower
            '  再循环指定次数, 延迟等待一段时间，是否需要暂停   , 延迟等待一段时间
            Case FlowFunctionlist.UerFuntion.GetCurrentPowerMeterValue

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        'UpdataSensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel)
                        Dim TmpPower As Double
                        System.Threading.Thread.Sleep(10)

                        GetChannelData(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, TmpPower)
                        If TmpPower > CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax Then
                            MainForm.wh.Stop()
                            Dim Re As DialogResult
                            'Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.YesNo)
                            Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.AbortRetryIgnore)
                            If Re = DialogResult.Abort Then
                                MessageBox.Show("机台停止")
                                CurrentAbort = True
                                CurrentAbortIndex = ProductNo
                            End If
                            If Re = DialogResult.Retry Then
                                ContorlPerClick(MainForm.cmdRun)
                            End If
                            If Re = DialogResult.Ignore Then
                                TargetValue(BoxHastable(ProductNo)) = TmpPower
                                MainForm.wh.Start()
                            End If
                        End If
                        ' SensorTouch(ChirdFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Picth, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, ChirdFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)

                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)

                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While

                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 更新UV后数据  || 下标显示内容
            '  刷新UI：右中区域 当前组装通道的 UVRlist 当前功率值+单位 || 通道号是：CurrentFlow.FunctionList(Index).ProductCurrent
            '    
            Case FlowFunctionlist.UerFuntion.更新UV后数据
                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If

                Dim TmpPower As Double
                System.Threading.Thread.Sleep(10)
                GetChannelData(CurrentFlow.FunctionList(Index).ProductCurrent, TmpPower)
                Dim StrUnit As String = "w"
                TmpPower = ConvertdbmToPower(TmpPower, StrUnit)

                ' 设置Cos1-9下Lable， 把获取的功率值单位
                ' ?
                ContorlChange(MainForm.UVRlist(BoxHastable(ProductNo)), TmpPower.ToString("0.000") & StrUnit)

            ' UpDataToFrom  || 获得当前功率值，显示出来和保存到csv文件，| COS文本框值
            '  刷新UI：右中区域 当前组装通道的 RlIST为 当前功率值+单位  ||  通道号是： ProductPara.ChannelIndex
            '  设置TargetValue，并保存COS值（即TargetValue）， 当前功率值+单位    
            Case FlowFunctionlist.UerFuntion.UpDataToFrom 

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                Dim TmpPower As Double
                System.Threading.Thread.Sleep(10)

                GetChannelData(ProductPara.ChannelIndex, TmpPower)
                Dim StrUnit As String = "w"
                TmpPower = ConvertdbmToPower(TmpPower, StrUnit)
                Try
                    IsShowData = True

                    TargetValue(BoxHastable(ProductNo)) = TmpPower & StrUnit    'P & StrUnit
                    'RlIST(BoxHastable(Index)).Text = TargetValue(BoxHastable(Index))

                    ' 数据区 COS值
                    ContorlChange(MainForm.RlIST(BoxHastable(ProductNo)), TmpPower.ToString("0.000") & StrUnit)
                    If TmpPower.ToString("0.000") < ProductPara.MaxPower Then
                        ' ContorlCColor(MainForm.RlIST(BoxHastable(ProductNo)), False)
                    Else
                        '   ContorlCColor(MainForm.RlIST(BoxHastable(ProductNo)), True)
                    End If
                    MainForm.RefreshData(ProductNo)
                Catch ex As Exception

                End Try
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' JugeTargetValue   ||
            '  等待延迟、当前功率< ProductPara.MaxPower时候提醒用户（异常对话框）（当选或略则把当前功率值赋给，即TargetValue(BoxHastable(CurrentIndex)) = TmpPower）
            '   延迟等待一段时间，是否需要暂停 
            Case FlowFunctionlist.UerFuntion.JugeTargetValue

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                ' 延迟等待
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                ' 
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    ' 
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        'UpdataSensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel)
                        Dim TmpPower As Double
                        System.Threading.Thread.Sleep(10)

                        GetChannelData(ProductPara.ChannelIndex, TmpPower)
                        Dim StrUnit As String = "w"
                        ConvertdbmToPower(TmpPower, StrUnit)
                        Select Case StrUnit.ToUpper
                            Case "W"
                                TmpPower = TmpPower
                            Case "MW"
                                TmpPower = TmpPower / 1000
                            Case "UW"
                                TmpPower = TmpPower / 1000000
                        End Select
                        If TmpPower < ProductPara.MaxPower Then
                            Dim Re As DialogResult
                            MainForm.wh.Stop()
                            Re = MessageBox.Show("Power Error!Is Need Pause Flow", "Waring", MessageBoxButtons.AbortRetryIgnore)
                            If Re = DialogResult.Abort Then
                                CurrentAbort = True
                                CurrentAbortIndex = ProductNo
                            End If
                            If Re = DialogResult.Retry Then
                                ContorlPerClick(MainForm.cmdRun)
                            End If
                            If Re = DialogResult.Ignore Then
                                TargetValue(BoxHastable(CurrentIndex)) = TmpPower
                                MainForm.wh.Start()
                            End If
                        End If
                        ' SensorTouch(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerDelate, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Channel, 0, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).PowerMax)
                    End If
                    System.Threading.Thread.Sleep(15)
                    StartTime = Now
                    While True
                        ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                        If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                            Exit While
                        End If
                    End While
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)
                    '
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 渐进组装产品 ||
            ' 将轴移动到指定位置(plus+通道对应的偏移) ，CurrentIndex自加1，
            ' 等待马达停止后延迟指定时间、检测是否暂停、是否重复再执行指定次数
            '  
            Case FlowFunctionlist.UerFuntion.GoArryBox
again1111:
                StepTime = Now      ' 记录时间 | 当前步运行开始时间
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now     ' 记录时间 其实用来延迟等待时间
                If CurrentFlow.FunctionList.Item(Index).IsJumpThisFunction = False Then
                    If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                    ' 
                    TotalSpanTime = Now    ' 记录时间
                    If CurrentFlow.FunctionList.Item(Index).AxisSetting IsNot Nothing Then
                        ' 当轴使用时候， 移动到指定位置，  当前索引加1
                        If CurrentFlow.FunctionList.Item(Index).AxisSetting(0).IsUsedAxis Then
                            ' 刷新轴运动信息 ： 轴号、方向、移动模式、位置
                            UpdataAxisInfo(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Dir, CurrentFlow.FunctionList.Item(Index).AxisSetting(0)._MoveMode, CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus)
                            ' 移动轴
                            Dim PicthCountIndex As Int16
                            PicthCountIndex = BoxHastable(CurrentIndex)
                            '  Dir * Picth  * [PicthCountIndex] + Plus 
                            ImcStatus = IMC.MoveAbs(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo, Convert.ToInt16(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Dir) * CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Picth * PicthCountIndex + CurrentFlow.FunctionList.Item(Index).AxisSetting(0).Plus)

                            ' 当前索引加1
                            CurrentIndex = CurrentIndex + 1  ' 当前选择的组装通道 位置索引[0....选择总数-1] | 相应值[0.....8]即通道号
                        End If
                        System.Threading.Thread.Sleep(100)
                        ' 等待马达停止
                        Do
                            If IMC._IMCCardInformation(CurrentFlow.FunctionList.Item(Index).AxisSetting(0).AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        ' 延迟等待
                        StartTime = Now
                        While True
                            ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                            If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While

                    End If
                    ' refreshui
                    TotalSpanMin = TotalSpanMin + Now.Subtract(TotalSpanTime).TotalSeconds  '累加当前步时间
                    AddData(CurrentFlow.FunctionList.Item(Index).UserInfo, Now.Subtract(TotalSpanTime).TotalSeconds.ToString, Index)    '刷新UI 当前运行时间
                    ' pause
                    If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                        ContorlPerClick(MainForm.cmdRun)
                    End If
                End If
                ' 重复执行到指定数量
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1111
                End If
                ' 刷新ＵＩ，当前运行步　总时间
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))

            ' 打开电源  ||
            '  打开电源
            '  再循环指定次数, 延迟等待一段时间，是否需要暂停 
            Case FlowFunctionlist.UerFuntion.打开电源
again1112:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True

                System.Threading.Thread.Sleep(10)
                CurVoltTool.CurrentOut = True
                '
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1112
                End If
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
            ' 关闭电源||
            '  关电源
            '  再循环指定次数, 延迟等待一段时间，是否需要暂停  
            Case FlowFunctionlist.UerFuntion.关闭电源
again1113:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                '
                CurVoltTool.CurrentOut = False
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1113
                End If
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
            ' 设定电源参数||
            '   设定电流、电压
            '   再循环指定次数, 延迟等待一段时间，是否需要暂停 
            Case FlowFunctionlist.UerFuntion.设定电源参数
again1114:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                StartTime = Now
                If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                CurVoltTool.SetParameter(CurrentFlow.FunctionList.Item(Index).ProductCurrent, CurrentFlow.FunctionList.Item(Index).ProductVolt)
                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1114
                End If
                StartTime = Now
                While True
                    ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                    If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                        Exit While
                    End If
                End While
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
            '
            ' 设定电源输出波形 || 批量性质
            '  读取文件中所有(电流\电压)  依次设定（每次间隔都要延迟指定的时间）
            '  再循环指定次数, 是否需要暂停
            Case FlowFunctionlist.UerFuntion.设定电源输出波形
again1115:

                StepTime = Now
                If CurrentAbort = True Then
                    If ProductNo = CurrentAbortIndex Then
                        If CurrentFlow.FunctionList(Index).IsSkipThisStep = True Then
                            GoTo EstopFlow
                        End If

                    End If
                End If
                If CurrentFlow.FunctionList.Item(Index).IsNeedRepeat = False AndAlso CurrentIndex > 0 Then Return True
                If IO.File.Exists(CurrentFlow.FunctionList(Index).Prompt) = True Then
                    Dim totalList() As String = IO.File.ReadAllLines(CurrentFlow.FunctionList(Index).Prompt)

                    For i As Int16 = 0 To totalList.Length - 1
                        Dim listTotal() As String = totalList(i).Split(",")
                        CurVoltTool.SetParameter(listTotal(0), listTotal(1))
                        StartTime = Now
                        While True
                            ContorlChange(MainForm.CurOperLabel, CurrentFlow.FunctionList.Item(Index).UserInfo & "      等待时间（s） " & IIf(CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds) = 0, " ", (CurrentFlow.FunctionList.Item(Index).DelayTime - Convert.ToInt16(Now.Subtract(StartTime).TotalSeconds)).ToString))
                            If Now.Subtract(StartTime).TotalSeconds > CurrentFlow.FunctionList.Item(Index).DelayTime Then
                                Exit While
                            End If
                        End While
                    Next
                End If

                If RepeatCount < CurrentFlow.FunctionList.Item(Index).RepeatConut Then
                    RepeatCount = RepeatCount + 1
                    GoTo again1115
                End If
                If CurrentFlow.FunctionList.Item(Index).IsNeedPaus Then
                    ContorlPerClick(MainForm.cmdRun)
                End If
                MainForm.AddTrackMsg(CurrentFlow.FunctionList(Index).UserInfo & " 花费时间为" & Now.Subtract(StepTime).TotalSeconds.ToString("0.00"))
        End Select

EstopFlow:
        ' 紧急停止 {输出停止信息， CurVoltTool：关闭}
        If EStop = True Then
            ChangeFlowlb("机台紧急停止！")
            CurVoltTool.CurrentOut = False
        End If

    End Function
#End Region


#Region "Auto Alignment"
    Dim AlignerTime As Date ' 对准起始时间
    '
    ' 手动对准模块 | 
    ' 1.对依次要对准的轴（最多3个），进行扫描对准来寻找最大功率值和对应的坐标... 2.需要递归则减半进行第一步操作 3.是否再次扫描（PD、准直器） 4.UI上显示最大功率值和消耗时间
    ' 期间：禁止图形实时刷新IsTimerRefreshData、禁止IO控制位刷新IsRefreshIOStatus
    '
    Public Sub 简单攀升法(ByVal oBJ As AgilenentPara)

        Dim IterationCount As Int16 = 0         '循环 计时器 变量： 当前计时变量
        Dim _Pitchlist As New List(Of String)   ' 现阶段的步长列表：包含 所有轴的当前步长 | 迭代一次 即减半
        Dim picth() As String = oBJ._Picth.Split(",")   '步长数组：获得传入的所有轴的步长
        Dim MaxPointList As New List(Of String) '最大功率列表：　格式：　最大功率，各轴坐标......
        Dim StartTime As Date = Now
        Dim IsUseIretCount As New List(Of Boolean)  '包含是否递归的数组 ，eg： 【true、true、true】 表示三个轴都需要递归

        ' 只显示DataGraph_DB、计时开始、禁止IO刷新、
        DataGraphChange()                       ' 隐藏 DataGraph_1
        ContorlChange(MainForm.TextBox25, 0)    '  UI: TextBox25  = 0
        IsRefreshIOStatus = False               ' IsRefreshIOStatus = False 禁止刷新IO气件控制  
        ' ContorlPerClick(MainForm.RadioButton1)
        DataGraphChange1()                      '  显示DataGraph_DB
        AlignerTime = Now   ' 计时开始
        ' 决定参与的轴 是否要递归 
        If oBJ.IsUseIretCount = String.Empty Then
            For i As Integer = 0 To oBJ._AxisNo.Count - 1
                IsUseIretCount.Add(True)
            Next
        Else
            Dim Value() As String = oBJ.IsUseIretCount.Split(",")
            For i As Integer = 0 To Value.Length - 1
                If Value(i) = "1" Then
                    IsUseIretCount.Add(True)
                Else
                    IsUseIretCount.Add(False)
                End If
            Next
        End If
        ContorlChange(MainForm.TxtSpanTime, 0)  ' UI: TxtSpanTime = 0
        ' 计算不同轴 不同的步长 | 如果没有 则默认第一个步长
        For i As Int16 = 0 To oBJ._AxisNo.Count - 1
            Try
                _Pitchlist.Add(picth(i))
            Catch ex As Exception
                _Pitchlist.Add(picth(0))
            End Try
        Next

        ' 对所有参与轴扫描
        ' 需要递归的则减半进行
        While True
            ' 紧急终止，则退出
            If EStop = True Then GoTo EndProcess

            For i As Int16 = 0 To oBJ._AxisNo.Count - 1
                ' 紧急终止，则退出
                If EStop = True Then GoTo EndProcess
                ' 扫描一个轴、并把数据放到MaxPointList
                Dim Defultlist As New List(Of String)   '列表： 每一项:功率、坐标值......
                OneAxisAlignment(oBJ._AxisNo(i), _Pitchlist(i), oBJ._PicthCount, oBJ._Delta, oBJ._Channel, , , oBJ._AxisNo, Defultlist) ' 获得最大功率信息（也可能有2条、或1条）
                MaxPointList.AddRange(Defultlist)
            Next
            ' 是否要递归、是则计算当前递归的 步长（同时：当前步长=设置的一半） || 减半递归
            If IterationCount < oBJ._IretCount - 1 Then '？ 貌似少一次
                IterationCount = IterationCount + 1
                For i As Integer = 0 To oBJ._AxisNo.Count - 1
                    If IsUseIretCount(i) = True Then
                        _Pitchlist(i) = _Pitchlist(i) * 0.5
                    End If

                Next
            Else
                Exit While
            End If
        End While

        ' 当前产品类型： 有准直器、PD、PL； 默认PL
        ' 1:准直器，2：PD，3：Pumplaser
        Dim rv As String = Ini.GetINIValue("ProductTypeSetting", "Type", IniFile)
        If rv = "" Then
            Ini.WriteINIValue("ProductTypeSetting", "Type", "3", IniFile)
        End If
        rv = Ini.GetINIValue("ProductTypeSetting", "Type", IniFile)

        Dim MaxPower As Double
        MaxPower = GetMaxPostion(MaxPointList, oBJ._AxisNo)
        ContorlChange(MainForm.lbMaxPower, MaxPower.ToString)   '显示 最大功率指标
        Select Case rv
            Case "1", "2"   '如果是准直器　或者ＰＤ则
                Dim TmpPower As Double = MaxPower
again:
                ' Double check 一次
                DoubleCkeckPower(_Pitchlist, oBJ._AxisNo, oBJ._PicthCount, oBJ._Channel, TmpPower, oBJ._Delta)
                If TmpPower > MaxPower + oBJ._Delta Then
                    MaxPower = TmpPower
                    GoTo again
                End If
                ContorlChange(MainForm.TxtSpanTime, Now.Subtract(StartTime).TotalSeconds)

                ' 再依次搜索一遍
                For i As Int16 = 0 To oBJ._AxisNo.Count - 1
                    If EStop = True Then GoTo EndProcess
                    Dim Defultlist As New List(Of String)
                    OneAxisAlignment(oBJ._AxisNo(i), _Pitchlist(i), oBJ._PicthCount, oBJ._Delta, oBJ._Channel, , , oBJ._AxisNo, Defultlist)
                    MaxPointList.AddRange(Defultlist)
                Next
                ' 获得最大功率值
                MaxPower = GetMaxPostion(MaxPointList, oBJ._AxisNo)
                ContorlChange(MainForm.lbMaxPower, MaxPower.ToString)
            Case "3"
                GoTo EndProcess
        End Select


EndProcess:
        ' 曲线图可以实时刷新 ||  显示 花费时间 ||  IsRefreshIOStatus = True ||可以进行下一手动对准了
        Dim Tmp As Double
        GetChannelData(oBJ._Channel, Tmp)
        IsTimerRefreshData = True
        ContorlChange(MainForm.TextBox25, Now.Subtract(AlignerTime).TotalSeconds)   'TextBox25 当前花费时间（s）
        IsRefreshIOStatus = True
        ContorlChange(MainForm.Button11, "手动对准")

    End Sub
    '
    Public mCyUsb As New ClsCyUsb
    '
    ' 单轴扫描 || 
    '
    Public Sub SingleScanHandleProc(ByVal oBJ As AgilenentPara)

        Dim IterationCount As Int16 = 0
        Dim _Pitchlist As New List(Of String)
        Dim picth() As String = oBJ._Picth.Split(",")
        Dim MaxPointList As New List(Of String)
        Dim StartTime As Date = Now
        Dim IsUseIretCount As New List(Of Boolean)
        DataGraphChange()
        ContorlChange(MainForm.TextBox25, 0)
        IsRefreshIOStatus = False
        ' ContorlPerClick(MainForm.RadioButton1)
        DataGraphChange1()
        AlignerTime = Now
        If oBJ.IsUseIretCount = String.Empty Then
            For i As Integer = 0 To oBJ._AxisNo.Count - 1
                IsUseIretCount.Add(True)
            Next
        Else
            Dim Value() As String = oBJ.IsUseIretCount.Split(",")
            For i As Integer = 0 To Value.Length - 1
                If Value(i) = "1" Then
                    IsUseIretCount.Add(True)
                Else
                    IsUseIretCount.Add(False)
                End If
            Next
        End If
        ContorlChange(MainForm.TxtSpanTime, 0)
        For i As Int16 = 0 To oBJ._AxisNo.Count - 1
            Try
                _Pitchlist.Add(picth(i))
            Catch ex As Exception
                _Pitchlist.Add(picth(0))
            End Try
        Next

        '
        ' single axis scan  proc 
        Dim nDir As Integer = 1
        Dim isPLim As Boolean = False, isNLim As Boolean = False
        Dim nPos As Integer
        Dim nAxis As Integer = oBJ._AxisNo(0)
        Dim dPower As Double, currentPower As Double, maxPowder As Double = -999
        ControlCColor(MainForm.lbMaxPower, Color.Transparent)
        While True
            If EStop = True Then GoTo EndProcess

            isPLim = IMC._IMCCardInformation(nAxis).PLM
            isNLim = IMC._IMCCardInformation(nAxis).NLM
            nPos = IMC._IMCCardInformation(nAxis).Postion
            ' error 
            If isPLim And isNLim Then
                ContorlChange(MainForm.lbMaxPower, "error:pn")
                Exit While
            End If
            ' get max
            currentPower = mCyUsb.ReadADValue()
            If maxPowder < currentPower Then
                maxPowder = currentPower
            End If
            ContorlChange(MainForm.Label77, currentPower.ToString("0.00"))
            Try
                MainForm.DataGraph_DB.AddPointY("Power", currentPower)
            Catch ex As Exception
                MainForm.DataGraph_1.ClearGraph()
            End Try

            If (currentPower > oBJ.Threshoud) Then
                ContorlChange(MainForm.lbMaxPower, currentPower.ToString("0.00"))
                ControlCColor(MainForm.lbMaxPower, Color.Red)
                Exit While
            End If

            ' dir 
            'nDir = IIf(isPLim, -1, 1)
            If isPLim Then
                nDir = -1
            ElseIf isNLim Then
                nDir = 1
            End If
            If nPos + Convert.ToInt32(_Pitchlist(nAxis)) + 50 >= AxisInitalPara.AxisInitalParameter(nAxis).PostionLimitPostion Then
                nDir = -1
            End If
            If nPos <= 0 Then
                nDir = 1
            End If
            IMC.MoveVel(nAxis, nDir * Convert.ToInt32(_Pitchlist(nAxis)))
            '
            Do
                ' moving check 
                If (currentPower > oBJ.Threshoud) Then
                    ContorlChange(MainForm.lbMaxPower, currentPower.ToString("0.00"))
                    ControlCColor(MainForm.lbMaxPower, Color.Red)
                    Exit While
                End If

                If IMC._IMCCardInformation(nAxis).MotionDone Then
                    System.Threading.Thread.Sleep(0)
                    Exit Do
                End If
            Loop

            '
            System.Threading.Thread.Sleep(0)
        End While


EndProcess:
        Dim Tmp As Double
        GetChannelData(oBJ._Channel, Tmp)
        IsTimerRefreshData = True
        ContorlChange(MainForm.TextBox25, Now.Subtract(AlignerTime).TotalSeconds)
        IsRefreshIOStatus = True
        ContorlChange(MainForm.btnsaScan, "单轴对准")

    End Sub
    ' Refresh UI： change lable bg color 
    Public Sub ControlCColor(ByVal control As Windows.Forms.Control, ByVal color As Color)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of Control, Color)(AddressOf ControlCColor), New Object() {control, color})
        Else
            control.BackColor = color
        End If
    End Sub
    ' doublecheck power
    Private Sub DoubleCkeckPower(Pitchlist As List(Of String), AxisList As List(Of Integer), PicthCount As Integer, Channel As AxisInfo.ChannelName, ByRef MaxPower As Double, PowerDelate As Double)
        Dim MaxPointList As New List(Of String)
        For i As Int16 = 0 To AxisList.Count - 1
            Dim Defultlist As New List(Of String)
            If EStop = True Then GoTo EndProcess
            OneAxisAlignment(AxisList(i), Pitchlist(i), PicthCount, PowerDelate, Channel, , , AxisList, Defultlist)
            MaxPointList.AddRange(Defultlist)
        Next
EndProcess:
        MaxPower = GetMaxPostion(MaxPointList, AxisList)
    End Sub
    '
    ' 主要功能：获取最强功率值
    '
    Private Function GetMaxPostion(obj As List(Of String), Axislist As List(Of Integer)) As Double
        Dim MaxValue As Double = -999   '最强功率值
        Dim MaxIndex As Integer = 0     '最强 位置
        Dim Valuelist As New List(Of Double)    '功率值 列表
        Try
            For i As Integer = 0 To obj.Count - 1
                Dim DataString() As String = obj(i).Split(",")
                Valuelist.Add(DataString(0))
            Next
            For i As Integer = 0 To Valuelist.Count - 1
                If Valuelist(i) > MaxValue Then
                    MaxIndex = i
                    MaxValue = Valuelist(i)
                End If
            Next

            Dim Data() As String = obj(MaxIndex).Split(",")
            If Axislist.Count = 1 Then
                ContorlChange(MainForm.TextBox12, Data(0) & "," & Data(1))
            Else
                If Axislist.Count = 2 Then
                    ContorlChange(MainForm.TextBox12, Data(0) & "," & Data(1) & "," & Data(2))
                Else
                    ContorlChange(MainForm.TextBox12, Data(0) & "," & Data(1) & "," & Data(2) & "," & Data(3))
                End If
            End If
            If IO.File.Exists("Test.txt") Then IO.File.Delete("Test.txt")

            ContorlChange(MainForm.Label58, "")
            Dim p As String
            For I As Int16 = 0 To Data.Length - 1
                p &= Data(I) & ","
            Next
            ContorlChange(MainForm.Label58, p)
            For i As Integer = 0 To Axislist.Count - 1
                '  IMC.MoveAbs(Axislist(i), Data(i + 1))
                System.Threading.Thread.Sleep(1)
                System.IO.File.AppendAllText("Test.txt", Axislist(i) & "," & Data(i + 1))   '?
            Next
        Catch ex As Exception

        End Try
        Return MaxValue
        'IMC.MoveAbs(Data(1))
    End Function
#End Region

    Public CurrentBoxIndex As Int64 = 0 ' ~~
    Public BoxHastable As New List(Of Integer)  ' 所有待处理（勾选的部分）的组装通道号 | （0-8） | eg： 1，3，5

#End Region

#Region "MainFormChange"
    ' 刷新UI: ProgressBar
    Public Sub ContorlChange(ByVal bar As System.Windows.Forms.ProgressBar, ByVal Value As Int16)
        If bar.InvokeRequired Then
            bar.BeginInvoke(New Action(Of System.Windows.Forms.ProgressBar, Int16)(AddressOf ContorlChange), New Object() {bar, Value})
        Else
            Try
                bar.Maximum = 100
                If Value > MainForm.ProgressBar1.Maximum Then
                    bar.Value = 0
                End If
                bar.Value = Value
            Catch ex As Exception

            End Try


        End If
    End Sub
    ' 刷新UI: RichTextBox Text
    Public Sub ContorlChange(ByVal contorl As System.Windows.Forms.RichTextBox, ByVal Value As String)
        If contorl.InvokeRequired Then
            contorl.BeginInvoke(New Action(Of System.Windows.Forms.RichTextBox, String)(AddressOf ContorlChange), New Object() {contorl, Value})
        Else
            Return
            Try
                contorl.Text = contorl.Text & Value & vbNewLine
            Catch ex As Exception

            End Try


        End If
    End Sub
    ' 刷新UI: ComboBox SelectedIndex
    Public Sub ChangeCbIndex(ByVal control As Windows.Forms.ComboBox, ByVal index As Int16)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of ComboBox, Int16)(AddressOf ChangeCbIndex), New Object() {control, index})
        Else
            Try
                control.SelectedIndex = index
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' 刷新UI: TabControl，页选择
    Public Sub ChangeTabIndex(ByVal control As Windows.Forms.TabControl, ByVal index As Int16)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of TabControl, Int16)(AddressOf ChangeTabIndex), New Object() {control, index})
        Else
            Try
                control.SelectedIndex = index
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' 刷新UI: TabControl，页选择
    Public Sub ChangeCbIndex(ByVal control As Windows.Forms.TabControl, ByVal index As Int16)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of TabControl, Int16)(AddressOf ChangeCbIndex), New Object() {control, index})
        Else
            Try
                control.SelectedIndex = index
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' 刷新UI: 按钮单击
    Public Sub ContorlPerClick(ByVal control As Windows.Forms.Button)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of Button)(AddressOf ContorlPerClick), New Object() {control})
        Else
            control.PerformClick()
        End If
    End Sub
    ' 刷新UI: control.Checked 
    Public Sub ContorlPerClick(ByVal control As Windows.Forms.RadioButton)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of RadioButton)(AddressOf ContorlPerClick), New Object() {control})
        Else
            control.Checked = True
        End If
    End Sub
    ' 刷新UI: control.Checked 
    Public Sub ContorlPerClick(ByVal control As Windows.Forms.CheckBox, ByVal f As Boolean)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of CheckBox, Boolean)(AddressOf ContorlPerClick), New Object() {control, f})
        Else
            control.Checked = f
        End If
    End Sub
    ' 刷新UI: control.Text = txt
    Public Sub ContorlChange(ByVal control As Windows.Forms.Button, ByVal txt As String)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of Button, String)(AddressOf ContorlChange), New Object() {control, txt})
        Else
            control.Text = txt
        End If
    End Sub
    ' 刷新UI: 
    Public Sub ContorlChange(ByVal control As Windows.Forms.Label, ByVal txt As String)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of Label, String)(AddressOf ContorlChange), New Object() {control, txt})
        Else
            control.Text = txt
        End If
    End Sub
    ' 刷新UI: control.Text = txt
    Public Sub ContorlChange(ByVal control As Windows.Forms.TextBox, ByVal txt As String)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of TextBox, String)(AddressOf ContorlChange), New Object() {control, txt})
        Else
            control.Text = txt
        End If
    End Sub
    ' 刷新UI: control.BackColor
    Public Sub ContorlChange(ByVal control As Windows.Forms.CheckBox, ByVal f As Boolean)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of CheckBox, Boolean)(AddressOf ContorlChange), New Object() {control, f})
        Else
            control.BackColor = IIf(f, Color.Green, Color.Yellow)
        End If
    End Sub
    ' 刷新UI: control.BackColor
    Public Sub ChangeCheckBox(ByVal control As Windows.Forms.CheckBox, col As Color)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of CheckBox, Color)(AddressOf ChangeCheckBox), New Object() {control, col})
        Else
            control.BackColor = col
        End If
    End Sub
    ' 刷新UI: control.BackColor
    Public Sub ContorlCColor(ByVal control As Windows.Forms.TextBox, ByVal f As Boolean)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of TextBox, Boolean)(AddressOf ContorlCColor), New Object() {control, f})
        Else
            control.BackColor = IIf(f, Color.Green, Color.Yellow)
        End If
    End Sub
    ' 刷新UI: lsLog.Items.Add
    Public Sub AddRunLog(ByVal mes As String)
        If MainForm.lsLog.InvokeRequired Then
            MainForm.lsLog.Invoke(New Action(Of String)(AddressOf AddRunLog), New Object() {mes})
        Else
            ' IO.File.AppendAllText(DailyLog.FullName & "/" & Now.ToString("yyyy-MM-dd") & ".log", Now.ToString("yyyy-MM-dd hh:mm:ss") & ">>>" & mes & vbNewLine, System.Text.Encoding.Default)
            If MainForm.lsLog.Items.Count > 50 Then
                MainForm.lsLog.Items.Clear()
            Else
                MainForm.lsLog.Items.Add(Now.ToString("yyyy-MM-dd hh:mm:ss") & ">>>" & mes)
                MainForm.lsLog.SelectedIndex = MainForm.lsLog.Items.Count - 1
            End If
        End If
    End Sub
    ' 刷新UI: control.Items.Add
    Public Sub ContorlChange(ByVal control As Windows.Forms.ListBox, ByVal txt As String)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of ListBox, String)(AddressOf ContorlChange), New Object() {control, txt})
        Else
            control.Items.Add(Now.ToString("mm:ss") & ">>>" & txt)
            control.SelectedIndex = control.Items.Count - 1
        End If
    End Sub
    ' 刷新UI: BackColor
    Public Sub ContorlChange(ByVal control As Windows.Forms.Label, ByVal txt As Boolean)
        If control.InvokeRequired Then
            control.Invoke(New Action(Of Label, Boolean)(AddressOf ContorlChange), New Object() {control, txt})
        Else
            control.BackColor = IIf(txt, Color.Green, Color.Red)
        End If
    End Sub
    ' 刷新UI: CurOperLabel.Text = txt
    Public Sub ChangeFlowlb(ByVal txt As String)
        If MainForm.CurOperLabel.InvokeRequired Then
            MainForm.CurOperLabel.BeginInvoke(New Action(Of String)(AddressOf ChangeFlowlb), txt)
        Else
            MainForm.CurOperLabel.Text = txt
        End If
    End Sub
    ' 刷新UI: ListBox1.SelectedIndex = Index
    Private Sub ChangelistIndex(ByVal Index As Int16)
        If MainForm.ListBox1.InvokeRequired Then
            MainForm.ListBox1.Invoke(New Action(Of Int16)(AddressOf ChangelistIndex), Index)
        Else
            MainForm.ListBox1.SelectedIndex = Index
        End If
    End Sub
#End Region

#Region "Sersor"
    ' 刷新UI： Sensor 模块
    Public Sub UpdataSensorTouch(ByVal axisno As Int16, ByVal delta As Double, ByVal picth As Double, ByVal channel As Int16)
        ChangeTabIndex(MainForm.TabControl2, 2)
        ChangeCbIndex(MainForm.ComboBox6, axisno)
        ChangeCbIndex(MainForm.ComboBox6, axisno)
        ContorlChange(MainForm.TextBox5, delta)
        ContorlChange(MainForm.TextBox4, picth)
        ChangeCbIndex(MainForm.ComboBox7, channel)
    End Sub
    ' 刷新UI： bd 模块
    Public Sub Updatabadu(ByVal Axis As Int16, ByVal dstep As Double, ByVal MaxPowerVlue As Double, ByVal delta As Double, ByVal rang As Double, ByVal channel As Int16)
        ChangeTabIndex(MainForm.TabControl2, 3)
        ChangeCbIndex(MainForm.ComboBox11, Axis)
        ContorlChange(MainForm.TextBox10, dstep)
        ContorlChange(MainForm.TextBox9, delta)
        ChangeCbIndex(MainForm.ComboBox10, channel)
        ContorlChange(MainForm.TextBox8, MaxPowerVlue)
        ContorlChange(MainForm.TextBox11, rang)

    End Sub
    'Edit By Brain in 2016-08-14
    Enum InsertStep
        OneStep
        SecondStep
        ThridStep
    End Enum
    Enum TounchStep
        Statr
        Pos_Move
        GetCurrentPosInfo
        Pos_Compare
        Pos_Detail
        Neg_Start
        Neg_Move
        GetCurrentNegInfo
        Neg_Compare
        Neg_Detail
        DoubleCheck
        DoubleCheck1
        Over
    End Enum
    Public _SensorTouncStep As TounchStep = TounchStep.Statr
    Public DelayTime As Double                      ' 当前延迟时间
    '
    ' Sensor功能模块： ？
    ' Axis: 轴号, dStep:步长  , PowerDelta：Delta , channel：通道号 , MinValue：最小值 （=0）, Optional MaxValue = 0.9：最大值，传入的是1.9（硬代码）

    Public Function SensorTouch(ByVal Axis As Int16, ByVal dStep As Double, ByVal PowerDelta As Single, ByVal channel As Int16, ByVal MinValue As Double, Optional ByVal MaxValue As Double = 0.9) As Boolean
        Dim FrisInfo, CurrentInfo, Maxinfo, MinInfo, DoubleCheckPerInfo As TargetDataOne
        Dim PosStep As Double = -dStep          ' -数值
        Dim NegStep As Double = dStep / dStep   ' =1    || 已经不用1， 用传参数形式了 ，即Dim NegStep As Double = NegPosDef
        Dim CheckCount As Int16 = 5             ' check max num  || 【作废了-》改为2了，即 Dim CheckCount As Int16 = 2】
        Dim Count As Int16 = 0                  ' check var 
        Dim CkPower As Double   ' ~~
        '
        System.Threading.Thread.Sleep(20)
        While True
            If _SensorTouncStep <> TounchStep.Statr Then
                '   IO.File.AppendAllText(TestFile.FullName & Now.ToString("yyyy-MM-DD") & ".CSV", "目前值：" & "，" & CurrentInfo.ToString & vbNewLine)
            End If
            If _OpStep = OpStep.NextStep Then
                Return True
            End If
            '
            Select Case _SensorTouncStep
                Case TounchStep.Statr
                    ' 获得第一次的位置和功率值， 初始化MaxInfo=第一个点， | UI上显第一次位置
                    System.Threading.Thread.Sleep(10)
                    FrisInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    ContorlChange(MainForm.TextBox6, FrisInfo.pos)
                    GetChannelData(channel, FrisInfo.power)
                    Maxinfo = FrisInfo  '记录第一次的最大功率值

                    ' 再次获得功率值、和最大值比较 || 比传入最大值参数还打则提醒用户
                    GetChannelData(channel, Maxinfo.power)
                    If Maxinfo.power > MaxValue Then
                        Dim rs As DialogResult = MessageBox.Show("电压异常，请确认！停止请按NO,手动确认请按OK", "Waring", MessageBoxButtons.YesNo)
                        If rs = DialogResult.Yes Then
                            _SensorTouncStep = TounchStep.Statr
                            ContorlPerClick(MainForm.cmdRun)    'TOD: RUN
                            '   Return False
                        End If
                        If rs = DialogResult.No Then
                            MessageBox.Show("机台停止")
                            _SensorTouncStep = TounchStep.Statr
                            ContorlPerClick(MainForm.cmdReset)  'TOD: RUN
                            '  Return False
                        End If
                    Else    '小于最大功率值 则进行下一步
                        _SensorTouncStep = TounchStep.Pos_Move
                    End If

                Case TounchStep.Pos_Move
                    ' -向移动一个step，等待停止
                    System.Threading.Thread.Sleep(10)
                    IMC.MoveVel(Axis, PosStep)
                    Do
                        If IMC._IMCCardInformation(Axis).MotionDone = True Then
                            Exit Do
                        End If
                    Loop
                    _SensorTouncStep = TounchStep.GetCurrentPosInfo
                Case TounchStep.GetCurrentPosInfo
                    ' 获得当前功率值、位置 -》CurrentInfo
                    System.Threading.Thread.Sleep(10)
                    CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    GetChannelData(channel, CurrentInfo.power)
                    _SensorTouncStep = TounchStep.Pos_Compare
                Case TounchStep.Pos_Compare
                    ' 比较，当前小于则继续-step，大于则进入detail
                    System.Threading.Thread.Sleep(10)
                    If CurrentInfo.power > Maxinfo.power + PowerDelta Then
                        Maxinfo = CurrentInfo
                        _SensorTouncStep = TounchStep.Pos_Detail
                    Else
                        _SensorTouncStep = TounchStep.Pos_Move
                    End If
                Case TounchStep.Pos_Detail
                    '  MinInfo = Maxinfo
                    System.Threading.Thread.Sleep(10)
                    MinInfo = Maxinfo
                    _SensorTouncStep = TounchStep.Neg_Start

                Case TounchStep.Neg_Start
                    ' 获得当前功率、位置 -》MinInfo
                    System.Threading.Thread.Sleep(10)
                    CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    GetChannelData(channel, CurrentInfo.power)
                    MinInfo = CurrentInfo

                    _SensorTouncStep = TounchStep.Neg_Move
                Case TounchStep.Neg_Move
                    ' 往1miu 走
                    System.Threading.Thread.Sleep(10)
                    GetChannelData(channel, CkPower)
                    IMC.MoveVel(Axis, NegStep)
                    Do
                        If IMC._IMCCardInformation(Axis).MotionDone = True Then
                            Exit Do
                        End If
                    Loop
                    _SensorTouncStep = TounchStep.GetCurrentNegInfo
                Case TounchStep.GetCurrentNegInfo
                    ' 
                    System.Threading.Thread.Sleep(10)
                    CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    GetChannelData(channel, CurrentInfo.power)
                    _SensorTouncStep = TounchStep.Neg_Compare
                Case TounchStep.Neg_Compare
                    ' 找出变换大的点
                    Dim Tmp As Double = Convert.ToDouble((MinInfo.power - CurrentInfo.power).ToString("f4"))
                    If Tmp >= 0.0025 Then       ' || 改成：If Math.Abs(Tmp) <= PowerDelta Then
                        MinInfo = CurrentInfo
                        Count = 0
                        _SensorTouncStep = TounchStep.DoubleCheck1
                    Else
                        'If Tmp > 0.0009 Then
                        '    _SensorTouncStep = TounchStep.DoubleCheck
                        'Else
                        '    Count = 0
                        _SensorTouncStep = TounchStep.Neg_Move
                        'End If

                        '? deal loop  || 0330 
                    End If
                Case TounchStep.DoubleCheck1
                    ' 找出变换小的点
                    System.Threading.Thread.Sleep(10)
                    IMC.MoveVel(Axis, NegStep)
                    Do
                        If IMC._IMCCardInformation(Axis).MotionDone = True Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(10)
                    CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    GetChannelData(channel, CurrentInfo.power)
                    Dim Tmp As Double = Convert.ToDouble((MinInfo.power - CurrentInfo.power).ToString("f4"))
                    If Tmp >= 0.0025 Then       '=》If Math.Abs(Tmp) >= 0.003 Then
                        MinInfo = CurrentInfo
                        Count = 0
                        _SensorTouncStep = TounchStep.DoubleCheck1
                    Else
                        If Math.Abs(Tmp) < 0.002 AndAlso Math.Abs(Tmp) > 0.0001 Then    '=》If Math.Abs(Tmp) < 0.004 Then
                            Count = Count + 1
                            If Count > CheckCount Then
                                _SensorTouncStep = TounchStep.Over
                            End If

                        End If
                    End If
                Case TounchStep.Neg_Detail
                    If Count < CheckCount Then
                        Count = Count + 1
                        DoubleCheckPerInfo = MinInfo
                        _SensorTouncStep = TounchStep.DoubleCheck
                    Else
                        _SensorTouncStep = TounchStep.Over
                    End If
                Case TounchStep.DoubleCheck
                    System.Threading.Thread.Sleep(10)
                    IMC.MoveVel(Axis, NegStep)
                    Do
                        If IMC._IMCCardInformation(Axis).MotionDone = True Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(10)
                    DoubleCheckPerInfo.pos = IMC._IMCCardInformation(Axis).Postion
                    GetChannelData(channel, DoubleCheckPerInfo.power)
                    Dim Tmp As Double = Convert.ToDouble((CurrentInfo.power - DoubleCheckPerInfo.power).ToString("f4"))
                    If Tmp > 0.0002 AndAlso Tmp < 0.0005 Then '0.259

                        _SensorTouncStep = TounchStep.Over

                    Else

                        Count = Count + 1
                        If Count >= CheckCount Then
                            _SensorTouncStep = TounchStep.Over
                        Else
                            _SensorTouncStep = TounchStep.Neg_Move
                        End If

                    End If

                Case TounchStep.Over
                    ' IO.File.AppendAllText(TestFile.FullName & Now.ToString("yyyy-MM-DD") & ".CSV", "目标值：" & "，" & MinInfo.ToString & vbNewLine)
                    IMC.MoveAbs(Axis, MinInfo.pos)
                    Do
                        If IMC._IMCCardInformation(Axis).MotionDone = True Then
                            Exit Do
                        End If
                    Loop
                    ContorlChange(MainForm.TextBox7, -MinInfo.pos + FrisInfo.pos)
                    GetChannelData(channel, CurrentInfo.power)

                    _SensorTouncStep = TounchStep.Statr
                    IsTimerRefreshData = True
                    ContorlChange(MainForm.Button9, "测试")
                    Exit While
            End Select
        End While
        '
        IsTimerRefreshData = True
        ContorlChange(MainForm.Button9, "测试")
        Return False

    End Function
    Enum InsertStatus
        Start
        Go_Z_Max
        GetXinfo_Neg_Per
        Go_X_Neg
        GetXinfo_Neg
        XNeg_Detail
        GetXinfo_Pos_Per
        Go_X_Pos
        GetXinfo_Pos
        XPos_Detail
        Over
    End Enum
    Public StartRecode As Boolean = False       ' 控制是否实时记录第四个轴（Len_R）的位置，以及功率值
    Public RecodePos As New Hashtable           ' 记录第四个轴（Len_R）的功率、位置
    Public RecodeSensor As New List(Of Double)  ' 记录第四个轴（Len_R）的功率
    Private _InsertStatus As InsertStatus = InsertStatus.Start

    ' 
    ' 8度对准 |  《强制规定：感应轴步长=20， MaxPowerVlue=0.9， IsUsedDoubleCheck=true》
    ' 感应轴号、旋转轴号， 感应轴步长|20， 通道，Delta，角度（范围）|390，pictch |2 ， MaxPowerVlue|0.9， IsUsedDoubleCheck | true
    ' 

    Public Function InsertRotaion(ByVal AxisSensor As Int16, ByVal AxisR As Int16, ByVal AxisSensorSetp As Double, ByVal Channel As Int16, Optional ByVal powerDelta As Double = 0.001, Optional ByVal Rang As Double = 390, Optional ByVal pictch As Double = 2, Optional ByVal MaxPowerVlue As Double = 0.9, Optional ByVal IsUsedDoubleCheck As Boolean = True) As Boolean
        '
        Dim quit_Flag As Int16          ' 退出while标记  1循环 0退出
        Dim dStep As Double = pictch    ' 步长 
        Dim Delta As Double = powerDelta    ' 波动值
        Dim Current_Chkpoint As Integer ' CheckPoint计时器
        Dim PicthCount As Int16 = 3     ' 强制CheckPoint为3
        Dim AxisSensorStep As Double = -AxisSensorSetp  'AxisSensorStep Sensor 、负方向 走20u
        Dim neg_Step As Single = dStep          ' step 
        Dim pos_Step As Single = -dStep         ' -step
        Dim _Iteration As Int16 = 0 ' ~~
        Dim frist_info, current_info, max_info As TargetDataOne
        Dim save_Info As New List(Of TargetDataOne)
        Dim AxisNo As Int16 = AxisR     ' 旋转轴
        quit_Flag = 1
        Dim Index As AglinmentStatus    ' 导航
        Dim MaxValue As Double = MaxPowerVlue           ' 最大功率值

        Dim FristPos As Double = IMC._IMCCardInformation(AxisSensor).Postion    ' 用来IsUsedDoubleCheck = False 时候不能超过150u ~~
        Dim DegRang As Double = Rang + 10                                       ' 400   旋转轴最大旋转范围
        ' 移进Sensor轴，直到功率》MaxValue|0.9
        Do
            IMC.MoveVel(AxisSensor, AxisSensorStep) ' 20
            System.Threading.Thread.Sleep(5)
            frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
            GetChannelData(Channel, frist_info.power)
            Do
                If IMC._IMCCardInformation(AxisSensor).MotionDone Then
                    Exit Do
                End If
            Loop

            If frist_info.power >= MaxValue Then
                Exit Do
            End If
            If IsUsedDoubleCheck = False Then
                If Math.Abs(frist_info.pos - FristPos) < 150 Then
                    Return True
                End If
            End If
        Loop

        ' 准备在旋转过程中 记录功率、位置
        RecodePos.Clear()                   ' 清除Lens_R 的功率、位置信息
        RecodeSensor.Clear()                ' 清除Lens_R 的功率信息
        StartRecode = True                  ' 打开记录标记：Lens_R 的功率值、位置

        ' 旋转快到400度时候，退出当前等待
        current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
        Dim StartR As Date
        StartR = Now
        IMC.MoveVel(AxisNo, DegRang)
        Do
            Dim pos As Double = IMC._IMCCardInformation(AxisNo).Postion
            If Math.Abs(current_info.pos + DegRang - pos) < 1 Then
                Exit Do
            End If
        Loop
        'System.Threading.Thread.Sleep(25)
        'StartR = Now
        'current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
        'IMC.MoveVel(AxisNo, -DegRang * 2)
        'Do
        '    Dim pos As Double = IMC._IMCCardInformation(AxisNo).Postion
        '    If Math.Abs(current_info.pos - DegRang * 2 - pos) < 1 Then
        '        StartRecode = False
        '        Exit Do
        '    End If
        'Loop

        ' 找出此次旋转过程中最小的功率、位置（》180要减去360）  | 并移到这个位置上，然后一直等待直到位置差0.05
        '
        ' Lens_R最小功率值的位置，如果》180（则减去360），然后把3轴已到这个位置上，并记录下这个位置
        RecodeSensor.Sort()
        Dim TargetPos As Double = -9999999999999
        For Each de As DictionaryEntry In RecodePos
            If de.Key = RecodeSensor(0) Then
                Dim pos As Double = de.Value
                If AxisNo = 3 Then
                    If de.Value > 180 Then
                        pos = de.Value - 360
                    Else
                        pos = de.Value
                    End If
                End If

                IMC.MoveAbs(AxisNo, pos)
                TargetPos = pos
            End If
        Next
        If TargetPos <> -9999999999999 Then
            Do

                Dim pos As Double = IMC._IMCCardInformation(AxisNo).Postion
                If IMC._IMCCardInformation(AxisNo).MotionDone AndAlso Math.Abs(pos - TargetPos) < 0.05 Then
                    Exit Do
                End If
            Loop
        End If

        ' 是否要check =False 直接退出当前函数
        ' 
        Dim DefaultValue As Double = RecodeSensor(0)
        Dim DefaultPos As Double = TargetPos
        System.Threading.Thread.Sleep(20)
        Dim _Tmp As String = Ini.GetINIValue("插玻璃管", "是否要check", IniFile)
        If _Tmp = "" Then
            Ini.WriteINIValue("插玻璃管", "是否要check", "1", IniFile)
        End If
        _Tmp = Ini.GetINIValue("插玻璃管", "是否要check", IniFile)
        If Val(_Tmp) = 1 Then
            IsUsedDoubleCheck = True
        Else
            IsUsedDoubleCheck = False
        End If
        If IsUsedDoubleCheck = False Then
            Return False
        End If

        ' 需要Check时候， 在对旋转轴爬山一次， 目的无限靠近最小值（不能大于上面找的最小值）
        System.Threading.Thread.Sleep(25)
        IMC.SetVelAcc(AxisNo)
        quit_Flag = 1
        While quit_Flag = 1
            Select Case Index
                Case AglinmentStatus.start

                    frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, frist_info.power)
                    max_info = frist_info
                    Current_Chkpoint = 0
                    Index = AglinmentStatus.pos_move
                Case AglinmentStatus.pos_move
                    IMC.MoveVel(AxisNo, pos_Step)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.pos_get_info
                Case AglinmentStatus.pos_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.pos_compare
                Case AglinmentStatus.pos_compare
                    If (current_info.power < max_info.power + Delta) Then
                        Index = AglinmentStatus.pos_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.pos_detail
                    End If
                Case AglinmentStatus.pos_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.pos_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.pos_go_max
                    End If
                Case AglinmentStatus.pos_go_max
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.max_frist_compare
                Case AglinmentStatus.max_frist_compare
                    If max_info.pos - frist_info.pos > PicthCount * dStep Then
                        Index = AglinmentStatus.over
                    Else
                        current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                        GetChannelData(Channel, current_info.power)
                        max_info = current_info
                        Current_Chkpoint = 0
                        Index = AglinmentStatus.neg_move
                    End If
                Case AglinmentStatus.neg_move
                    IMC.MoveVel(AxisNo, neg_Step)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.neg_get_info
                Case AglinmentStatus.neg_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.neg_compare
                Case AglinmentStatus.neg_compare
                    If (current_info.power < max_info.power + Delta) Then
                        Index = AglinmentStatus.neg_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.neg_detail
                    End If
                Case AglinmentStatus.neg_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.neg_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.neg_go_max
                    End If
                Case AglinmentStatus.neg_go_max
                    ' 确保轴不能移到大于DefaultValue 外
                    If max_info.power < DefaultValue Then
                        IMC.MoveAbs(AxisNo, max_info.pos)
                        System.Threading.Thread.Sleep(5)
                        Do
                            If IMC._IMCCardInformation(AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        Index = AglinmentStatus.over
                    End If
                    If max_info.power > DefaultValue Then
                        IMC.MoveAbs(AxisNo, TargetPos)
                        System.Threading.Thread.Sleep(5)
                        Do
                            If IMC._IMCCardInformation(AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        Index = AglinmentStatus.over
                    End If
                Case AglinmentStatus.over

                    For i As Int16 = 0 To save_Info.Count - 1
                        System.IO.File.AppendAllText(TestFile.FullName & "\AxisAlignment1.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
                    Next
                    Try
                        'MainForm.DataGraph_1.AddPointY("Power", max_info.power)
                    Catch ex As Exception
                        ' MainForm.DataGraph_1.ClearGraph()
                    End Try


                    '  MessageBox.Show(max_info.pos & "," & max_info.power)
                    quit_Flag = 0


                Case Else
                    quit_Flag = 0
            End Select

        End While
        '  System.Threading.Thread.Sleep(100)
        '  IMC.SetVeldef(AxisNo) '  SetVeldef
        IsTimerRefreshData = True
    End Function

    'Public Sub InsertPigtalToLens(ByVal Axis As List(Of AxisInfo), ByVal StepEnum As InsertStep)
    '    Dim quit_Flag As Int16
    '    Dim Channel As AxisInfo.ChannelName = Axis(0).Channel
    '    Dim AxisNo As Integer = Axis(0).AxisNo
    '    Dim Current_Chkpoint As Integer
    '    Dim dStep As Double = Axis(0).Picth
    '    Dim Delta As Double = Axis(0).PowerDelate
    '    Dim PicthCount As Int16 = Axis(0).PicthCount
    '    Dim neg_Step As Long = -dStep
    '    Dim SensorValu_Max As Single = SystemIni.SensorMax
    '    Dim SensorVlue_Min As Single = SystemIni.SensorMin
    '    Dim JogSpeed As Int16 = Axis(1).Speed
    '    Dim pos_Step As Long = dStep
    '    Dim _Iteration As Int16 = 0
    '    Dim frist_info, current_info, max_info As TargetDataOne
    '    Dim save_Info As New List(Of TargetDataOne)
    '    quit_Flag = 1
    '    Dim Index As AglinmentStatus
    '    While quit_Flag = 1
    '        Select Case Index
    '            Case AglinmentStatus.start
    '                If StepEnum = InsertStep.ThridStep Then
    '                    IMC.MoveAbs(Axis(0).AxisNo, FristInsertPostion.DatumAxisPos)
    '                End If
    '                frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
    '                GetChannelData(Channel, frist_info.power)
    '                max_info = frist_info
    '                Current_Chkpoint = 0
    '                Index = AglinmentStatus.pos_move
    '            Case AglinmentStatus.pos_move
    '                IMC.MoveVel(AxisNo, pos_Step)
    '                System.Threading.Thread.Sleep(10)
    '                Do
    '                    If IMC._IMCCardInformation(AxisNo).MotionDone Then
    '                        Exit Do
    '                    End If
    '                Loop
    '                Index = AglinmentStatus.pos_get_info
    '            Case AglinmentStatus.pos_get_info
    '                System.Threading.Thread.Sleep(10)
    '                current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
    '                GetChannelData(Channel, current_info.power)
    '                'Dim Tmp As TargetDataOne
    '                'Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
    '                'Tmp.power = current_info.power
    '                'save_Info.Add(Tmp)
    '                Index = AglinmentStatus.pos_compare
    '            Case AglinmentStatus.pos_compare
    '                If (current_info.power > max_info.power + Delta) Then
    '                    Index = AglinmentStatus.pos_detail
    '                Else
    '                    If current_info.power < max_info.power + Delta Then
    '                        '''Add Code
    '                    End If
    '                    Index = AglinmentStatus.pos_move
    '                    max_info = current_info
    '                    Current_Chkpoint = 0

    '                End If
    '            Case AglinmentStatus.pos_detail
    '                If Current_Chkpoint < PicthCount Then
    '                    Index = AglinmentStatus.pos_move
    '                    Current_Chkpoint += 1
    '                Else
    '                    Index = AglinmentStatus.pos_go_max
    '                End If
    '            Case AglinmentStatus.pos_go_max
    '                IMC.MoveAbs(AxisNo, max_info.pos)
    '                System.Threading.Thread.Sleep(10)
    '                Do
    '                    If IMC._IMCCardInformation(AxisNo).MotionDone Then
    '                        Exit Do
    '                    End If
    '                Loop
    '                Index = AglinmentStatus.max_frist_compare
    '            Case AglinmentStatus.max_frist_compare
    '                If max_info.pos - frist_info.pos > PicthCount * dStep Then
    '                    Index = AglinmentStatus.over
    '                Else
    '                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
    '                    GetChannelData(Channel, current_info.power)
    '                    max_info = current_info
    '                    Current_Chkpoint = 0
    '                    Index = AglinmentStatus.neg_move
    '                End If
    '            Case AglinmentStatus.neg_move
    '                IMC.MoveVel(AxisNo, neg_Step)
    '                System.Threading.Thread.Sleep(10)
    '                Do
    '                    If IMC._IMCCardInformation(AxisNo).MotionDone Then
    '                        Exit Do
    '                    End If
    '                Loop
    '                Index = AglinmentStatus.neg_get_info
    '            Case AglinmentStatus.neg_get_info
    '                System.Threading.Thread.Sleep(100)
    '                current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
    '                GetChannelData(Channel, current_info.power)
    '                Dim Tmp As TargetDataOne
    '                Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
    '                Tmp.power = current_info.power
    '                save_Info.Add(Tmp)
    '                Index = AglinmentStatus.neg_compare
    '            Case AglinmentStatus.neg_compare
    '                If (current_info.power > max_info.power + Delta) Then
    '                    Index = AglinmentStatus.neg_detail
    '                Else
    '                    If current_info.power < max_info.power + Delta Then
    '                        '''Add Code
    '                    End If
    '                    Index = AglinmentStatus.neg_move
    '                    max_info = current_info
    '                    Current_Chkpoint = 0

    '                End If
    '            Case AglinmentStatus.neg_detail
    '                If Current_Chkpoint < PicthCount Then
    '                    Index = AglinmentStatus.neg_move
    '                    Current_Chkpoint += 1
    '                Else
    '                    Index = AglinmentStatus.neg_go_max
    '                End If
    '            Case AglinmentStatus.neg_go_max
    '                IMC.MoveAbs(AxisNo, max_info.pos)
    '                System.Threading.Thread.Sleep(10)
    '                Do
    '                    If IMC._IMCCardInformation(AxisNo).MotionDone Then
    '                        Exit Do
    '                    End If
    '                Loop
    '                Index = AglinmentStatus.over
    '            Case AglinmentStatus.over
    '                If StepEnum = InsertStep.OneStep Then
    '                    FristInsertPostion.DatumAxisPos = max_info.pos
    '                    FristInsertPostion.MoveAxisPos = IMC._IMCCardInformation(Axis(1).AxisNo).Postion
    '                    FristInsertPostion.Power = max_info.power
    '                End If
    '                For i As Int16 = 0 To save_Info.Count - 1
    '                    '  System.IO.File.AppendAllText("c:a.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
    '                Next

    '                quit_Flag = 0
    '            Case Else
    '                quit_Flag = 0
    '        End Select

    '    End While
    'End Sub
#End Region

#Region "测试校准"
    '
    ' 目标数据一：  位置1、位置、功率
    Structure TargetDataOne
        Public Pos1 As String   '位置2信息：如果有的话
        Public pos As String    '位置1信息
        Public power As Double
        Public Overrides Function ToString() As String
            Return pos & "," & power
        End Function
    End Structure
    Dim m_current_x As Long = 3200
    Dim m_current_y As Long = 3100
    'w 
    Public Sub OneAxisAlignmentTest(ByVal AxisNo As Integer, ByVal Iteration As Integer, ByVal dStep As Double, ByVal PicthCount As Int16, ByVal Delta As Single, ByVal Channel As AxisInfo.ChannelName, Optional ByVal f As Int16 = 0)
        Dim quit_Flag As Int16
        Dim Current_Chkpoint As Integer
        Dim neg_Step As Long = 0 - dStep
        Dim pos_Step As Long = dStep
        Dim frist_info, current_info, max_info As TargetDataOne
        Dim save_Info As New List(Of TargetDataOne)
        quit_Flag = 1
        Dim Index As AglinmentStatus
        While quit_Flag = 1
            Select Case Index
                Case AglinmentStatus.start
                    frist_info.pos = IIf(f = 1, m_current_x, m_current_y)
                    ' frist_info.power = GetDataValueTest(m_current_x, m_current_y)
                    max_info = frist_info
                    Current_Chkpoint = 0
                    Dim Tmp As TargetDataOne
                    Tmp.pos = m_current_x & "," & m_current_y
                    Tmp.power = frist_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.pos_move

                Case AglinmentStatus.pos_move
                    If f = 1 Then
                        m_current_x += pos_Step
                    Else
                        m_current_y += pos_Step
                    End If
                    Index = AglinmentStatus.pos_get_info
                Case AglinmentStatus.pos_get_info
                    current_info.pos = IIf(f = 1, m_current_x, m_current_y)
                    ' current_info.power = GetDataValueTest(m_current_x, m_current_y)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = m_current_x & "," & m_current_y
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.pos_compare
                Case AglinmentStatus.pos_compare
                    If (current_info.power > max_info.power + Delta) Then
                        Index = AglinmentStatus.pos_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.pos_detail
                    End If
                Case AglinmentStatus.pos_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.pos_move
                        Current_Chkpoint = Current_Chkpoint + 1
                    Else
                        Index = AglinmentStatus.pos_go_max
                    End If
                Case AglinmentStatus.pos_go_max
                    If f = 1 Then
                        m_current_x = max_info.pos
                    Else
                        m_current_y = max_info.pos
                    End If

                    Dim Tmp As TargetDataOne
                    Tmp.pos = m_current_x & "," & m_current_y
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.max_frist_compare
                Case AglinmentStatus.max_frist_compare
                    If max_info.pos - frist_info.pos > PicthCount * dStep Then
                        Index = AglinmentStatus.over
                    Else
                        current_info.pos = IIf(f = 1, m_current_x, m_current_y)
                        ' current_info.power = GetDataValueTest(m_current_x, m_current_y)
                        max_info = current_info
                        Current_Chkpoint = 0
                        Index = AglinmentStatus.neg_move
                    End If
                Case AglinmentStatus.neg_move
                    If f = 1 Then
                        m_current_x = m_current_x + neg_Step
                    Else
                        m_current_y = m_current_y + neg_Step
                    End If
                    Index = AglinmentStatus.neg_get_info
                Case AglinmentStatus.neg_get_info
                    current_info.pos = IIf(f = 1, m_current_x, m_current_y)
                    '  current_info.power = GetDataValueTest(m_current_x, m_current_y)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = m_current_x & "," & m_current_y
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.neg_compare
                Case AglinmentStatus.neg_compare
                    If (current_info.power > max_info.power + Delta) Then
                        Index = AglinmentStatus.neg_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.neg_detail
                    End If
                Case AglinmentStatus.neg_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.neg_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.neg_go_max
                    End If
                Case AglinmentStatus.neg_go_max
                    If f = 1 Then
                        m_current_x = max_info.pos
                    Else
                        m_current_y = max_info.pos
                    End If

                    Dim Tmp As TargetDataOne
                    Tmp.pos = m_current_x & "," & m_current_y
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.over
                Case AglinmentStatus.over
                    For i As Int16 = 0 To save_Info.Count - 1
                        'System.IO.File.AppendAllText("c:a.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
                    Next

                    quit_Flag = 0
                Case Else
                    quit_Flag = 0
            End Select

        End While
    End Sub
#End Region

#Region "单轴对准"
    'ww
    Public Sub 三轴爬山(ByVal obj As AgilenentPara)
        Dim AlignementTime As Date = Now
        Dim posstr() As String
        Dim MaxPower As Double = -9999
        ContorlChange(MainForm.TxtSpanTime, 0)
        Dim IterationCount As Int16 = 0
        AddRunLog("开始对准")

        SearchMaxPower.Clear()
        MaxPowerForPos.Clear()
        StartReacodeAilgnment = False
        Dim PerPowerValue, AfterPowerValue As Double
        Dim _Pitchlist As New List(Of String)
        Dim picth() As String = obj._Picth.Split(",")
        For i As Int16 = 0 To obj._AxisNo.Count - 1
            Try
                _Pitchlist.Add(picth(i))
            Catch ex As Exception
                _Pitchlist.Add(picth(0))
            End Try
        Next
        ContorlChange(MainForm.TextBox12, 0)
        Dim DelayTime As Double = 5
        AddRunLog("对准 递归次数" & IterationCount)
        While True
Again:
            'SearchMaxPower.Clear()
            'MaxPowerForPos.Clear()
            If _OpStep = OpStep.NextStep Then
                Return
            End If
            GetChannelData(0, PerPowerValue)
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                AddRunLog("对准参数：" & obj._AxisNo(i) & "," & _Pitchlist(i) & "," & obj._PicthCount & "," & obj._Delta & "," & obj._Channel)
                If IterationCount = 2 Then
                    Dim StartLightTime As Date = Now
                    AddRunLog("开始做" & obj._AxisNo(i) & "爬山（长滤波）")
                    OneAxisAlignment(obj._AxisNo(i), _Pitchlist(i), obj._PicthCount, obj._Delta, obj._Channel, DelayTime, True, obj._AxisNo)
                    AddRunLog(obj._AxisNo(i) & "爬山，总共花费" & Now.Subtract(StartLightTime).TotalSeconds)
                Else
                    Dim StartLightTime As Date = Now
                    AddRunLog("开始做" & obj._AxisNo(i) & "爬山（无长滤波）")
                    OneAxisAlignment(obj._AxisNo(i), _Pitchlist(i), obj._PicthCount, obj._Delta, obj._Channel, DelayTime, False, obj._AxisNo)
                    AddRunLog(obj._AxisNo(i) & "爬山，总共花费" & Now.Subtract(StartLightTime).TotalSeconds)
                End If

            Next
            System.Threading.Thread.Sleep(10)
            StartReacodeAilgnment = False
            ' 获取SearchMaxPower里面比MaxPower还大的值，赋值给MaxPower
            SearchMaxPower.Sort()
            For i As Int16 = 0 To SearchMaxPower.Count - 1
                If SearchMaxPower(i) > MaxPower Then
                    MaxPower = SearchMaxPower(i)
                End If
            Next
            For Each de As DictionaryEntry In MaxPowerForPos
                AddRunLog("寻找过程中的Power,及坐标：" & de.Key & "," & de.Value)
            Next
            System.Threading.Thread.Sleep(10)
            ContorlChange(MainForm.TextBox12, MaxPower)
            System.Threading.Thread.Sleep(20)
            GetChannelData(0, AfterPowerValue)
            If Math.Abs(AfterPowerValue - PerPowerValue) > 0.1 AndAlso IterationCount = 0 Then
                GoTo Again
            End If
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                For i As Int16 = 0 To obj._AxisNo.Count - 1
                    If obj._AxisNo.Count > 2 Then
                        If i <> 0 Then
                            _Pitchlist(i) = _Pitchlist(i) * 0.5
                        End If
                    Else
                        _Pitchlist(i) = _Pitchlist(i) * 0.5
                    End If


                Next
            Else
                Exit While
            End If
        End While
        'For Each de As DictionaryEntry In MaxPowerForPos

        '    If Math.Abs(de.Key - MaxPower) < 0.001 Then
        '        Dim pos As String = de.Value
        '        System.Threading.Thread.Sleep(10)
        '        AddRunLog("寻找过程中的MaxPower,及坐标：" & MaxPower & "," & de.Value)
        '        posstr = de.Value.ToString.Split(",")
        '        For i As Int16 = 0 To obj._AxisNo.Count - 1
        '            AddRunLog("停止时坐标：" & obj._AxisNo(i) & "轴坐标：" & "," & IMC._IMCCardInformation(obj._AxisNo(i)).Postion)
        '        Next
        '        Try
        '            System.Threading.Thread.Sleep(10)
        '            Dim Dis As Double = posstr(2) - IMC._IMCCardInformation(obj._AxisNo(1)).Postion
        '            System.Threading.Thread.Sleep(10)
        '            Dim Dis1 As Double = posstr(3) - IMC._IMCCardInformation(obj._AxisNo(2)).Postion
        '            System.Threading.Thread.Sleep(10)
        '            Dim Dis2 As Double = posstr(1) - IMC._IMCCardInformation(obj._AxisNo(0)).Postion
        '            Try
        '                System.Threading.Thread.Sleep(10)
        '                IMC.MoveVel(obj._AxisNo(0), Dis2)
        '                Do
        '                    If IMC._IMCCardInformation(2).MotionDone Then
        '                        Exit Do
        '                    End If

        '                Loop
        '                AddRunLog("补偿4轴相对差距为：" & Dis)
        '                System.Threading.Thread.Sleep(10)
        '                IMC.MoveVel(obj._AxisNo(1), Dis)
        '                Do
        '                    If IMC._IMCCardInformation(obj._AxisNo(obj._AxisNo(0))).MotionDone Then
        '                        Exit Do
        '                    End If

        '                Loop
        '                AddRunLog("补偿5轴相对差距为：" & Dis1)
        '                System.Threading.Thread.Sleep(10)
        '                IMC.MoveVel(obj._AxisNo(2), Dis1)
        '                Do
        '                    If IMC._IMCCardInformation(obj._AxisNo(2)).MotionDone Then
        '                        Exit Do
        '                    End If

        '                Loop
        '            Catch ex As Exception

        '            End Try
        '        Catch ex As Exception

        '        End Try



        '        Exit For
        '    End If
        'Next

        '        Dim Power As Double
        'Errorlb:
        '        System.Threading.Thread.Sleep(30)
        '        GetChannelData(obj._Channel, Power)
        '        AddRunLog("当前Power=" & Power)

        '        If Math.Abs(Power - MaxPower) > 0.06 AndAlso IterationCount = obj._IretCount - 1 Then
        '            If Power < MaxPower Then
        '                For i As Int16 = 0 To obj._AxisNo.Count - 1
        '                    If posstr(0) = obj._AxisNo(i) Then
        '                        _Pitchlist.Clear()
        '                        picth = obj._Picth.Split(",")
        '                        For j As Int16 = 0 To obj._AxisNo.Count - 1
        '                            Try
        '                                _Pitchlist.Add(picth(j) * 0.5)
        '                            Catch ex As Exception
        '                                _Pitchlist.Add(picth(0))
        '                            End Try
        '                        Next

        '                        AddRunLog("开始对" & posstr(0) & "轴进行对准")
        '                        AddRunLog("对准参数：" & _Pitchlist(i))
        '                        OneAxisAlignment(posstr(0), _Pitchlist(i), obj._PicthCount, obj._Delta, obj._Channel)
        '                        GetChannelData(obj._Channel, Power)
        '                        If Math.Abs(Power - MaxPower) > 0.06 AndAlso IterationCount = obj._IretCount - 1 Then
        '                            If Power < MaxPower Then
        '                                GoTo Errorlb
        '                            End If

        '                        End If
        '                        AddRunLog("结束对" & posstr(0) & "轴进行对准")
        '                        Exit For
        '                    End If
        '                Next
        '            End If


        '        End If
        _Pitchlist.Clear()
        picth = obj._Picth.Split(",")
        For j As Int16 = 0 To obj._AxisNo.Count - 1
            Try
                _Pitchlist.Add(picth(j) * 0.1)
            Catch ex As Exception
                _Pitchlist.Add(picth(0) * 0.1)
            End Try
        Next
        For i As Int16 = 0 To obj._AxisNo.Count - 1
            AddRunLog("对准参数：" & obj._AxisNo(i) & "," & _Pitchlist(i) & "," & obj._PicthCount & "," & obj._Delta & "," & obj._Channel)
            Dim StartLightTime As Date = Now
            AddRunLog("开始做" & obj._AxisNo(i) & "爬山（长滤波）")
            OneAxisAlignment(obj._AxisNo(i), _Pitchlist(i), obj._PicthCount, obj._Delta, obj._Channel, DelayTime, True, obj._AxisNo)
            AddRunLog(obj._AxisNo(i) & "爬山，总共花费" & Now.Subtract(StartLightTime).TotalSeconds)
        Next


        System.Threading.Thread.Sleep(20)
        OneAxisAlignment(obj._AxisNo(0), 2, obj._PicthCount, obj._Delta, obj._Channel, DelayTime, True, obj._AxisNo)
        System.Threading.Thread.Sleep(20)
        IterationCount = 0
        obj._Picth = 0.005
        While True
            If _OpStep = OpStep.NextStep Then
                Return
            End If
            For i As Int16 = 1 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel, , , obj._AxisNo)
            Next

            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        ContorlChange(MainForm.TxtSpanTime, Now.Subtract(AlignementTime).TotalSeconds)
        ContorlChange(MainForm.Button7, "三轴爬山手动对准")
        IsTimerRefreshData = True
    End Sub
    Enum AglinmentStatus
        start
        pos_move
        pos_get_info
        pos_compare
        pos_detail
        pos_go_max
        max_frist_compare
        neg_move
        neg_get_info
        neg_compare
        neg_detail
        neg_go_max
        over
    End Enum
    Public Sub UpdataAlihnment(ByVal AxisNo As List(Of Integer), ByVal dStep As Single, ByVal PicthCount As Int16, ByVal Delta As Single, ByVal Channel As AxisInfo.ChannelName, ByVal Iret As Int16)
        Dim cblist As New List(Of ComboBox)
        cblist.Add(MainForm.cbAxisName)
        cblist.Add(MainForm.ComboBox1)
        cblist.Add(MainForm.ComboBox2)
        Dim cklist As New List(Of CheckBox)
        cklist.Add(MainForm.CheckBox1)
        cklist.Add(MainForm.CheckBox2)
        cklist.Add(MainForm.CheckBox3)
        For index As Int16 = 0 To cklist.Count - 1
            ContorlPerClick(cklist(index), False)
        Next
        For index As Int16 = 0 To AxisNo.Count - 1
            ContorlPerClick(cklist(index), True)
            ChangeCbIndex(cblist(index), AxisNo(index))
        Next
        ChangeCbIndex(MainForm.cbChannel, Channel)
        ContorlChange(MainForm.TxtDelta, Delta)
        ContorlChange(MainForm.TxtStep, dStep)
        ContorlChange(MainForm.TxtPicth, PicthCount)
        ContorlChange(MainForm.TxtIlret, Iret)
        ChangeCbIndex(MainForm.TabControl2, 0)
        ChangeTabIndex(MainForm.TabControl2, 0)
    End Sub
    Public SearchMaxPower As New List(Of String)    ' Z,P,Y轴 最大功率
    Public MaxPowerForPos As New Hashtable          ' 最大功率、 Z,P,Y轴位置
    Public StartReacodeAilgnment As Boolean = False ' 控制是否实时记录Z,P,Y轴位置
    'w 
    Public Sub OneAxisAlignmentTest1(ByVal AxisNo As Integer, ByVal dStep As Single, ByVal PicthCount As Int16, ByVal Delta As Single, ByVal Channel As AxisInfo.ChannelName, Optional ByVal _DelayTime As Double = 1, Optional ByVal IsClearNosiy As Boolean = True, Optional ByVal Axislist As List(Of Int16) = Nothing, Optional ByRef MaxInfoMation As List(Of String) = Nothing)
        Dim quit_Flag As Int16
        Dim Current_Chkpoint As Integer
        Dim neg_Step As Single = dStep
        Dim pos_Step As Single = -dStep
        Dim MaxInfoRe As String
        Dim _Iteration As Int16 = 0
        Dim DelayTime As Int16 = _DelayTime
        Dim frist_info, current_info, max_info As TargetDataOne
        Dim save_Info As New List(Of TargetDataOne)
        quit_Flag = 1
        Dim Index As AglinmentStatus
        AddRunLog("准备开始对准")
        Dim StartAlignment As Date

        Dim Index1 As Int16 = 0
        While quit_Flag = 1
            If Index1 = 100 Then Index1 = 0
            ContorlChange(MainForm.ProgressBar1, Index1)
            Index1 = Index1 + 0.5
            If _OpStep = OpStep.NextStep Then
                Return
            End If

            Select Case Index
                Case AglinmentStatus.start
                    StartAlignment = Now
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "开始" & AxisNo & "轴爬山" & Now.Subtract(Now).TotalMilliseconds)
                    frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, frist_info.power, IsClearNosiy)
                    max_info = frist_info
                    Current_Chkpoint = 0

                    Index = AglinmentStatus.pos_move
                Case AglinmentStatus.pos_move
                    StartAlignment = Now
                    IMC.MoveVel(AxisNo, pos_Step)
                    '   MessageBox.Show(Now.Subtract(StartAlignment).TotalMilliseconds)
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "移动" & AxisNo & "距离" & "：" & pos_Step & "," & Now.Subtract(StartAlignment).TotalMilliseconds)
                    StartAlignment = Now
                    Index = AglinmentStatus.pos_get_info
                Case AglinmentStatus.pos_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power, IsClearNosiy)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    StartAlignment = Now
                    Index = AglinmentStatus.pos_compare
                Case AglinmentStatus.pos_compare
                    ' ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "进行比较" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    If (current_info.power > max_info.power + Delta) Then
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "继续爬山" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.pos_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else

                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "进行判断" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.pos_detail
                    End If
                Case AglinmentStatus.pos_detail
                    '  StartAlignment = Now
                    If Current_Chkpoint < PicthCount - 1 Then
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "比较后，继续爬山" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.pos_move
                        Current_Chkpoint += 1
                    Else
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "比较后，走最大位置" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.pos_go_max
                    End If
                Case AglinmentStatus.pos_go_max
                    '  StartAlignment = Now
                    If Axislist.Count = 2 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1))
                        Catch ex As Exception

                        End Try
                    End If
                    If Axislist.Count = 3 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If
                    MaxInfoMation.Add(MaxInfoRe)
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "比较后，走完最大位置" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    Index = AglinmentStatus.max_frist_compare
                Case AglinmentStatus.max_frist_compare
                    If max_info.pos - frist_info.pos > PicthCount * dStep Then
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "结束" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.over
                    Else
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "往负方向进行爬山" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                        GetChannelData(Channel, current_info.power, IsClearNosiy)
                        max_info = current_info
                        Current_Chkpoint = 0
                        StartAlignment = Now
                        Index = AglinmentStatus.neg_move
                    End If
                Case AglinmentStatus.neg_move
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "开始往负方向移动位置" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    IMC.MoveVel(AxisNo, neg_Step)
                    StartAlignment = Now
                    Index = AglinmentStatus.neg_get_info
                Case AglinmentStatus.neg_get_info
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "往负方向获取咨询" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power, IsClearNosiy)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.neg_compare
                Case AglinmentStatus.neg_compare
                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "往负方向进行比较" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    If (current_info.power > max_info.power + Delta) Then
                        Index = AglinmentStatus.neg_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.neg_detail
                    End If
                Case AglinmentStatus.neg_detail
                    StartAlignment = Now
                    If Current_Chkpoint < PicthCount Then
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "继续往负方向进行爬山" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.neg_move
                        Current_Chkpoint += 1
                    Else
                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "往负方向走到最大值" & Now.Subtract(StartAlignment).TotalMilliseconds)
                        StartAlignment = Now
                        Index = AglinmentStatus.neg_go_max
                    End If
                Case AglinmentStatus.neg_go_max

                    If Axislist.Count = 2 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1))
                        Catch ex As Exception

                        End Try
                    End If
                    If Axislist.Count = 3 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If
                    MaxInfoMation.Add(MaxInfoRe)
                    StartAlignment = Now
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    Try

                        ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "往负方向走完最大值" & Now.Subtract(StartAlignment).TotalMilliseconds)
                    Catch ex As Exception

                    End Try

                    Index = AglinmentStatus.over
                Case AglinmentStatus.over

                    For i As Int16 = 0 To save_Info.Count - 1
                        System.IO.File.AppendAllText(TestFile.FullName & "\AxisAlignment.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
                    Next
                    Try
                        'MainForm.DataGraph_1.AddPointY("Power", max_info.power)
                    Catch ex As Exception
                        ' MainForm.DataGraph_1.ClearGraph()
                    End Try


                    '  MessageBox.Show(max_info.pos & "," & max_info.power)
                    quit_Flag = 0

                    ContorlChange(MainForm.RichTextBox1, Now.ToString("yyyy-MM-dd HH:mm:ss.ms") & ">>" & "结束" & Now.Subtract(StartAlignment).TotalMilliseconds)
                Case Else
                    quit_Flag = 0
            End Select

        End While
    End Sub
    '
    ' 单轴扫描 ： 轴号、步长、checkpoint、delta、通道号、延时时间、IsClearNosiy、 所有轴列表、|| 待返回的最大信息（+方向和-方向的最大信息 | +最大方向的功率信息）
    ' 
    Public Sub OneAxisAlignment(ByVal AxisNo As Integer, ByVal dStep As Single, ByVal PicthCount As Int16, ByVal Delta As Single, ByVal Channel As AxisInfo.ChannelName, Optional ByVal _DelayTime As Double = 1, Optional ByVal IsClearNosiy As Boolean = True, Optional ByVal Axislist As List(Of Integer) = Nothing, Optional ByRef MaxInfoMation As List(Of String) = Nothing)

        Dim quit_Flag As Int16          ' 1循环、 0退出
        Dim Current_Chkpoint As Integer ' CheckPoint计数器
        Dim neg_Step As Single = dStep  '   +
        Dim pos_Step As Single = -dStep '   -
        Dim MaxInfoRe As String         ' 最大功率，所有轴位置...
        Dim _Iteration As Int16 = 0     ' ~~
        Dim DelayTime As Int16 = _DelayTime                         '
        Dim frist_info, current_info, max_info As TargetDataOne     '
        Dim save_Info As New List(Of TargetDataOne)                 '
        quit_Flag = 1
        Dim Index As AglinmentStatus
        AddRunLog("准备开始对准")         '保存LOG
        Dim Index1 As Int16 = 0

        While quit_Flag = 1
            ' 让进度条 动起来
            If Index1 = 100 Then Index1 = 0
            ContorlChange(MainForm.ProgressBar1, Index1)
            Index1 = Index1 + 0.5
            ' 如果下一步则退出
            If _OpStep = OpStep.NextStep Then
                Return
            End If
            ' 紧急停止 则退出
            If EStop = True Then Exit While : GoTo EndProcess

            ' 顺序执行
            Select Case Index
                Case AglinmentStatus.start
                    ' 第一步： 保存第一次所在的当前位置、功率
                    frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, frist_info.power, IsClearNosiy)
                    max_info = frist_info   '假设最大值，以便进一步比较

                    Current_Chkpoint = 0    'checkpoint 置为0
                    Index = AglinmentStatus.pos_move
                Case AglinmentStatus.pos_move
                    ' 向-方向尝试 
                    IMC.MoveVel(AxisNo, pos_Step)
                    System.Threading.Thread.Sleep(DelayTime)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.pos_get_info
                Case AglinmentStatus.pos_get_info
                    ' 获得pos、power信息
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power, IsClearNosiy)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.pos_compare
                Case AglinmentStatus.pos_compare
                    ' 位置比较： 当前的和 已存在最大值比较来决定： 继续向前、还是detail
                    If (current_info.power > max_info.power + Delta) Then
                        Index = AglinmentStatus.pos_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.pos_detail
                    End If
                Case AglinmentStatus.pos_detail
                    ' 极大值分析：如果还是《CheckPoint则继续， 否则认为已搜索到max
                    If Current_Chkpoint < PicthCount - 1 Then
                        Index = AglinmentStatus.pos_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.pos_go_max
                    End If
                Case AglinmentStatus.pos_go_max
                    ' 保存所有参与轴的 信息
                    System.Threading.Thread.Sleep(1)
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    If Axislist.Count = 2 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1))
                        Catch ex As Exception

                        End Try
                    End If
                    If Axislist.Count = 3 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            'MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If

                    If Axislist.Count = 1 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) ' & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            'MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If
                    Try
                        MaxInfoMation.Add(MaxInfoRe)
                    Catch ex As Exception

                    End Try

                    System.Threading.Thread.Sleep(DelayTime)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.max_frist_compare
                Case AglinmentStatus.max_frist_compare
                    '  判断是否爬坡还是下坡检查， 用于决定是否-方向检查
                    If max_info.pos - frist_info.pos > PicthCount * dStep Then '是上坡
                        Index = AglinmentStatus.over
                    Else    '这个是下坡， 还需要反方向检查
                        current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                        GetChannelData(Channel, current_info.power, IsClearNosiy)
                        max_info = current_info
                        Current_Chkpoint = 0
                        Index = AglinmentStatus.neg_move
                    End If
                Case AglinmentStatus.neg_move
                    IMC.MoveVel(AxisNo, neg_Step)
                    System.Threading.Thread.Sleep(DelayTime)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.neg_get_info
                Case AglinmentStatus.neg_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power, IsClearNosiy)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.neg_compare
                Case AglinmentStatus.neg_compare
                    If (current_info.power > max_info.power + Delta) Then
                        Index = AglinmentStatus.neg_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.neg_detail
                    End If
                Case AglinmentStatus.neg_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.neg_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.neg_go_max
                    End If
                Case AglinmentStatus.neg_go_max
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    If Axislist.Count = 2 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1))
                        Catch ex As Exception

                        End Try
                    End If
                    If Axislist.Count = 3 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            ' MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If
                    If Axislist.Count = 1 Then
                        Try
                            MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0)) ' & "," & IMC.GetCurrentPos(Axislist(1)) & "," & IMC.GetCurrentPos(Axislist(2))
                        Catch ewx As Exception
                            'MaxInfoRe = max_info.power & "," & IMC.GetCurrentPos(Axislist(0))
                        End Try
                    End If
                    Try
                        MaxInfoMation.Add(MaxInfoRe)
                    Catch ex As Exception

                    End Try

                    System.Threading.Thread.Sleep(DelayTime)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(DelayTime + 5)
                    Try
                        SearchMaxPower.Add(max_info.power)      ' SearchMaxPower添加 ：最大的功率
                        If Axislist IsNot Nothing Then
                            Dim Tmp As String = String.Empty
                            For i As Int16 = 0 To Axislist.Count - 1
                                Tmp &= IMC._IMCCardInformation(Axislist(i)).Postion & ","
                            Next
                            Tmp = Tmp.Trim(",")
                            MaxPowerForPos.Add(max_info.power, AxisNo & "," & Tmp)      'MaxPowerForPos添加： 最大功率、轴号, 轴坐标...
                            AddRunLog("对准过程中最大功率：" & max_info.power)
                            AddRunLog("对准过程中最大功率时坐标：" & AxisNo & "," & Tmp)
                        End If

                    Catch ex As Exception

                    End Try

                    Index = AglinmentStatus.over
                Case AglinmentStatus.over

                    For i As Int16 = 0 To save_Info.Count - 1
                        ' System.IO.File.AppendAllText(TestFile.FullName & "\AxisAlignment.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
                    Next
                    Try
                        'MainForm.DataGraph_1.AddPointY("Power", max_info.power)
                    Catch ex As Exception
                        ' MainForm.DataGraph_1.ClearGraph()
                    End Try


                    '  MessageBox.Show(max_info.pos & "," & max_info.power)
                    quit_Flag = 0


                Case Else
                    quit_Flag = 0
            End Select

        End While
EndProcess:
        quit_Flag = 0
    End Sub
    '
#End Region

#Region "盲扫"
    ' 刷新ＵＩ盲扫　模块
    Public Sub UpDataBlindSearchInfo(ByVal Axis1 As Int16, ByVal Axis2 As Int16, ByVal Rang As Double, ByVal dStep As Double, ByVal Channel As Int16, ByVal MaxPowerValue As Double)
        ChangeTabIndex(MainForm.TabControl2, 1)
        ChangeCbIndex(MainForm.ComboBox5, Axis1)
        ChangeCbIndex(MainForm.ComboBox3, Axis2)
        ContorlChange(MainForm.TextBox1, dStep)
        ContorlChange(MainForm.TextBox2, Rang)
        ContorlChange(MainForm.TextBox3, MaxPowerValue)
        ChangeCbIndex(MainForm.ComboBox4, Channel)
        ChangeCbIndex(MainForm.TabControl2, 1)
    End Sub
    Public ReNum As Integer = 0
    'w
    Public Sub Blind_Search_Alignment_New(ByVal Axis1 As Int16, ByVal Axis2 As Int16, ByVal Rang As Double, ByVal dStep As Double, ByVal Channel As Int16, ByVal MaxPowerValue As Double)
        Dim ScanX As Int32
        ScanX = (Rang) / dStep
        Dim MaxPosInfo As TargetDataOne
        Dim n As Int16 = 1
        Dim IsSearchOK As Boolean = False
        Dim i As Int16
        '清除位置信息.0
        cIMCHandle.IMC_SetParam16(IMC._IMCCardInformation(Axis1).CardHandle, cIMCHandle.clearLoc, -1, IMC._IMCCardInformation(Axis1).AxisNo, cIMCHandle.TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一

        cIMCHandle.IMC_SetParam16(IMC._IMCCardInformation(Axis2).CardHandle, cIMCHandle.clearLoc, -1, IMC._IMCCardInformation(Axis2).AxisNo, cIMCHandle.TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一


        MaxPosInfo.power = -99999
        MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
        MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
        GetChannelData(Channel, MaxPosInfo.power)
        If MaxPosInfo.power >= MaxPowerValue Then
            Exit Sub
        End If
        IMC.MoveAbs(Axis1, Rang / 2)
        IMC.MoveAbs(Axis2, Rang / 2)
        Dim xSTEP As Double = Rang / 2
        While True
            For n = 1 To ScanX

                IMC.MoveAbs(Axis1, xSTEP)
                While True
                    GetChannelData(Channel, MaxPosInfo.power)
                    If MaxPosInfo.power >= MaxPowerValue Then
                        IMC.StopJog(Axis1, JogTpye.Pos)
                        IMC.StopJog(Axis1, JogTpye.Speed)
                        GoTo ERRORMES
                    End If
                    If Math.Abs(IMC._IMCCardInformation(Axis1).Postion - xSTEP) < 1 Then
                        Exit While
                    End If
                End While
                System.Threading.Thread.Sleep(20)
                IMC.MoveVel(Axis2, -dStep)
                xSTEP = -xSTEP
            Next
            Exit Sub
        End While

ERRORMES:
        System.Threading.Thread.Sleep(10)
        ContorlPerClick(MainForm.Button10)
        System.Threading.Thread.Sleep(500)
        GetChannelDataForTime(Channel, MaxPosInfo.power)
        If MaxPosInfo.power >= MaxPowerValue Then
            IMC.StopJog(Axis1, JogTpye.Pos)
            IMC.StopJog(Axis1, JogTpye.Speed)
            Exit Sub
        End If
        IMC.MoveAbs(Axis1, Rang / 2)
        System.Threading.Thread.Sleep(100)
        While True
            IMC.MoveVel(Axis1, -0.1)
            System.Threading.Thread.Sleep(100)
            GetChannelDataForTime(Channel, MaxPosInfo.power)
            If MaxPosInfo.power >= MaxPowerValue Then
                IMC.StopJog(Axis1, JogTpye.Pos)
                IMC.StopJog(Axis1, JogTpye.Speed)
                Exit Sub
            End If

        End While



    End Sub
    ' 
    ' 光谱坐标 ，  
    Public StartGo光谱图 As Boolean = False    '控制是否实时记录 P,Y轴位置
    Public powerlist As New List(Of Double)     ' 光谱时候，记录功率
    Public Blind光谱图坐标 As New Hashtable     ' 光谱时候，记录功率、位置（Pitch、Yaw)
    '
    ' 按照光谱图坐标文件里面坐标，依次移动4、5轴（mirror）
    ' 
    Public Sub BlindSearch光谱(ByVal Channel As Int16)
        StartGo光谱图 = True
        powerlist.Clear()
        Blind光谱图坐标.Clear()
        For i As Int16 = 0 To TechPoint._光谱坐标.Count - 1
            IMC.MoveAbs(4, TechPoint._光谱坐标(i).X)
            While True
                If Math.Abs(IMC._IMCCardInformation(4).Postion - TechPoint._光谱坐标(i).X) < 0.1 Then
                    Exit While
                End If
            End While
            IMC.MoveAbs(5, TechPoint._光谱坐标(i).Y)
            While True
                If Math.Abs(IMC._IMCCardInformation(5).Postion - TechPoint._光谱坐标(i).Y) < 0.1 Then
                    Exit While
                End If
            End While
        Next
        System.Threading.Thread.Sleep(100)
        StartGo光谱图 = False
        Try
            'Dim temp As Double = -99999
            'Dim Index As Int16 = 0
            'For i As Int16 = 0 To TechPoint._光谱坐标.Count - 1
            '    If temp < powerlist(i) Then
            '        temp = powerlist(i)
            '        Index = i
            '    End If
            'Next
            powerlist.Sort()

            For Each de As DictionaryEntry In Blind光谱图坐标
                If Math.Abs(powerlist(powerlist.Count - 1) - de.Key) < 0.1 Then
                    Dim TargetPos() As String = de.Value.ToString.Split(",")
                    IMC.MoveAbs(4, TargetPos(0))
                    While True
                        If Math.Abs(IMC._IMCCardInformation(4).Postion - TargetPos(0)) < 0.1 Then
                            Exit While
                        End If
                    End While
                    IMC.MoveAbs(5, TargetPos(1))
                    While True
                        If Math.Abs(IMC._IMCCardInformation(5).Postion - TargetPos(1)) < 0.1 Then
                            Exit While
                        End If
                    End While

                    Exit For
                End If
            Next


            System.Threading.Thread.Sleep(100)
        Catch ex As Exception

        End Try

    End Sub
    '
    ' 盲扫功能模块： 由内到外以当前点为中心成正方形式扫描， 直到扫描的功率值大于指定阈值的那个点（尽可能大于）则停止 | Rang最大扫描范围（极左-极右）、阈值（需要扫描最大功率值）
    ' 结果： 两个轴移动（>阈值）功率值位置
    '
    Public Sub Blind_Search_Alignment(ByVal Axis1 As Int16, ByVal Axis2 As Int16, ByVal Rang As Double, ByVal dStep As Double, ByVal Channel As Int16, ByVal MaxPowerValue As Double)
        Dim ScanX As Int32
        ScanX = (Rang) / dStep          ' 扫描次数=  范围/步长
        Dim CurrentPower As Single
        Dim MaxPosInfo As TargetDataOne ' 最大功率、位置
        Dim CurrentPosX, CurrentPosY As String
        Dim n As Int16 = 1
        Dim IsSearchOK As Boolean = False
        Dim i As Int16
        Dim _Tmp As String = Ini.GetINIValue("光谱", "是否要check", IniFile)
        If _Tmp = "" Then
            Ini.WriteINIValue("光谱", "是否要check", "0", IniFile)
        End If
        _Tmp = Ini.GetINIValue("光谱", "是否要check", IniFile)

        IsTimerRefreshData = True       ' 可以实时刷新图形 | '?
        MaxPosInfo.power = -99999       ' 最大功率值 ， 初始是很小的
        MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion     ' 第一个轴位置
        MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion    ' 第二个轴位置
        GetChannelData(Channel, MaxPosInfo.power)   '获得当前功率值
        ReNum = 0
        'ass _Tmp = 0 || 0329
        _Tmp = 0 ' 假设不需要盲扫光谱
        If MaxPosInfo.power >= MaxPowerValue Then   ' 如果已大于阈值则 调到最后判断
            GoTo EndProcess
        End If
        If _Tmp = "1" Then              '需要盲扫光谱
            BlindSearch光谱(Channel)

        End If
Repeat:
        ContorlChange(MainForm.ProgressBar1, 0)     ' 刷新UI ProgressBar1
        GetChannelData(Channel, MaxPosInfo.power)   ' 获得当前功率值
        If MaxPosInfo.power >= MaxPowerValue Then   ' 如果已大于阈值则 调到最后判断
            GoTo EndProcess
        End If

        Dim Index As Int16 = 0
        While (True)
            If EStop = True Then Exit While : GoTo EstopFlow ' 紧急停止
            ' 动画进度条
            If Index = 100 Then Index = 0
            ContorlChange(MainForm.ProgressBar1, Index)
            Index = Index + 0.5
            If _OpStep = OpStep.NextStep Then
                ' JUSTIN 0405
                GoTo EndProcess
                Return
            End If
            ' 
            ' 当前步， 第一轴扫描
            If IsSearchOK = False Then
                For i = 1 To n
                    If EStop = True Then Exit While : GoTo EstopFlow ' 紧急停止=
                    System.Threading.Thread.Sleep(100)
                    ' 相对 移动dstep步
                    IMC.MoveVel(Axis1, dStep)
                    Do
                        ' 记录尽可能的极大功率值
                        GetChannelData(Channel, CurrentPower)
                        If CurrentPower > MaxPosInfo.power Then
                            MaxPosInfo.power = CurrentPower
                            MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                            MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                        End If
                        ' 如果扫到了（》阈值），则停止马达并再检查功率值（变大了则算扫描到了， 变得更小了则再回扫一次）
                        '没有扫到，进行下一步扫描
                        If CurrentPower > MaxPowerValue Then ' 如果扫到了（》阈值），则停止马达）
                            IsSearchOK = True
                            IMC.StopJog(Axis1, JogTpye.Pos)
                            IMC.StopJog(Axis1, JogTpye.Speed)
                            System.Threading.Thread.Sleep(100)
                            GetChannelData(Channel, CurrentPower)
                            If CurrentPower > MaxPowerValue Then
                                MaxPosInfo.power = CurrentPower
                                MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                                MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                            Else
                                While True
                                    IMC.MoveVel(Axis1, -dStep)
                                    Do
                                        If IMC._IMCCardInformation(Axis1).MotionDone Then
                                            Exit Do
                                        End If
                                    Loop
                                    System.Threading.Thread.Sleep(100)
                                    GetChannelData(Channel, CurrentPower)
                                    If CurrentPower > MaxPowerValue Then
                                        IsTimerRefreshData = True
                                        Exit Sub  '? Exit Sub
                                    End If
                                End While

                            End If
                            MaxPosInfo.power = CurrentPower
                            MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                            MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                            Exit For
                        Else    ' 如果没扫到了（》阈值），则进行更长一步扫描
                            Exit Do
                        End If
                    Loop
                    Do
                        If IMC._IMCCardInformation(Axis1).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(5)
                    CurrentPosX = IMC._IMCCardInformation(Axis1).Postion
                    CurrentPosY = IMC._IMCCardInformation(Axis2).Postion
                    '    IO.File.AppendAllText(TestFile.FullName & "\BlindSearch.csv", CurrentPosX & "," & CurrentPosY & vbNewLine)
                Next
            End If
            ' 当前步， 第二轴扫描
            If IsSearchOK = False Then
                For i = 1 To n
                    If EStop = True Then Exit While : GoTo EstopFlow ' 紧急停止
                    System.Threading.Thread.Sleep(100)
                    IMC.MoveVel(Axis2, dStep)
                    Do
                        GetChannelData(Channel, CurrentPower)
                        If CurrentPower > MaxPosInfo.power Then
                            MaxPosInfo.power = CurrentPower
                            MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                            MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                        End If
                        If CurrentPower > MaxPowerValue Then
                            IsSearchOK = True
                            IMC.StopJog(Axis2, JogTpye.Pos)
                            IMC.StopJog(Axis2, JogTpye.Speed)
                            System.Threading.Thread.Sleep(100)
                            GetChannelData(Channel, CurrentPower)
                            If CurrentPower > MaxPowerValue Then
                                MaxPosInfo.power = CurrentPower
                                MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                                MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                            Else
                                While True
                                    IMC.MoveVel(Axis2, -dStep)
                                    Do
                                        If IMC._IMCCardInformation(Axis2).MotionDone Then
                                            Exit Do
                                        End If
                                    Loop
                                    System.Threading.Thread.Sleep(100)
                                    GetChannelData(Channel, CurrentPower)
                                    If CurrentPower > MaxPowerValue Then
                                        IsTimerRefreshData = True
                                        Exit Sub '? Exit Sub
                                    End If
                                End While
                            End If
                            MaxPosInfo.power = CurrentPower
                            MaxPosInfo.pos = IMC._IMCCardInformation(Axis1).Postion
                            MaxPosInfo.Pos1 = IMC._IMCCardInformation(Axis2).Postion
                            Exit For
                        Else
                            Exit Do
                        End If
                    Loop
                    Do
                        If IMC._IMCCardInformation(Axis2).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(5)
                    CurrentPosX = IMC._IMCCardInformation(Axis1).Postion
                    CurrentPosY = IMC._IMCCardInformation(Axis2).Postion
                    IO.File.AppendAllText(TestFile.FullName & "\BlindSearch.csv", CurrentPosX & "," & CurrentPosY & vbNewLine)
                Next
            End If
            ' 已搜索到，退出while
            If IsSearchOK = True Then
                Exit While
            End If
            ' 大于扫描次数，退出while
            n = n + 1
            If n > ScanX Then
                Exit While
            End If
            ' 反向 step
            dStep = -dStep

        End While

        '如果没有搜索到， 也要移动最强功率值得位置
        If IsSearchOK = False Then
            If EStop = True Then GoTo EstopFlow ' 紧急停止
            System.Threading.Thread.Sleep(20)
            AddRunLog(MaxPosInfo.power & "," & MaxPosInfo.pos & "," & MaxPosInfo.Pos1)
            ContorlChange(MainForm.TextBox12, MaxPosInfo.power)
            IMC.MoveAbs(Axis1, MaxPosInfo.pos)
            System.Threading.Thread.Sleep(200)
            IMC.MoveAbs(Axis2, MaxPosInfo.Pos1)
        End If

EndProcess:
        Dim a As Date = Now
        System.Threading.Thread.Sleep(200)
        GetChannelData(Channel, MaxPosInfo.power)
        If MaxPosInfo.power < MaxPowerValue AndAlso ReNum < 2 Then  ' 如果还是扫描不到则再循环2次大循环，总共3次大循环  ||不得低于2次的 扫描
            ReNum = ReNum + 1
            GoTo Repeat
        End If

        System.Threading.Thread.Sleep(50)
        IsTimerRefreshData = True
EstopFlow:
        IsTimerRefreshData = True
        'fix || 0329
        ContorlChange(MainForm.Button8, "盲扫")

    End Sub
    Public StartBlindRecode As Boolean      ' 控制是否实时记录Lens_R位置信息
    Public BlindRecodePos As New Hashtable  ' 记录Lens_R功率、位置
    Public BlindRecodePower As New List(Of String) ' 记录Lens_R功率
    Public Sub Blind_Search_Alignment1(ByVal Axis1 As Int16, ByVal Axis2 As Int16, ByVal Rang As Double, ByVal dStep As Double, ByVal Channel As Int16, ByVal MaxPowerValue As Double)
        Dim ScanX As Int32
        ScanX = (Rang) / dStep
        Dim CurrentPower As Single
        Dim MaxPos, MaxPos1 As Double
        Dim CurrentPosX, CurrentPosY As String
        Dim n As Int16 = 1
        Dim i As Int16
        While (True)
            For i = 1 To n
                System.Threading.Thread.Sleep(10)
                If n > 5 Then
                    BlindRecodePos.Clear()  '清除Lens_r位置、轴（下一句）
                    BlindRecodePower.Clear()
                    StartRecode = True        ' 打开记录标记：Lens_R 的功率值、位置
                    IMC.MoveVel(Axis1, dStep * n)
                    System.Threading.Thread.Sleep(10)
                    Do
                        If IMC._IMCCardInformation(Axis1).MotionDone Then
                            StartBlindRecode = False
                            Exit Do
                        End If
                    Loop

                    ' 如果记录的Lens_R里面最大功率值》指定的MaxPowerValue，则把Axis1移到这个位置
                    BlindRecodePower.Sort()
                    Dim MaxPower As Single
                    Dim Power As Single = BlindRecodePower(BlindRecodePower.Count - 1)
                    If Power > MaxPowerValue Then
                        MaxPower = Power
                        For Each de As DictionaryEntry In BlindRecodePos
                            If de.Key = Power Then
                                Dim pos As Double = de.Value
                                IMC.MoveAbs(Axis1, pos)
                                Do
                                    If IMC._IMCCardInformation(Axis1).MotionDone Then
                                        Exit Do
                                    End If
                                Loop
                            End If
                        Next

                        Exit While
                    End If

                    'Do
                    '    GetChannelData(Channel, CurrentPower)

                    '    If CurrentPower > MaxPowerValue Then
                    '        MaxPower = CurrentPower
                    '        Do
                    '            If IMC._IMCCardInformation(Axis1).MotionDone Then
                    '                Exit Do
                    '            End If
                    '        Loop
                    '        For Index As Int16 = 0 To n
                    '            IMC.MoveVel(Axis1, -dStep)
                    '            Do
                    '                GetChannelData(Channel, CurrentPower)
                    '                If CurrentPower > MaxPowerValue Then
                    '                    MaxPos = IMC._IMCCardInformation(Axis1).Postion
                    '                    MaxPos1 = IMC._IMCCardInformation(Axis2).Postion
                    '                    Exit While
                    '                Else
                    '                    Exit Do
                    '                End If
                    '            Loop

                    '            Do
                    '                If IMC._IMCCardInformation(Axis1).MotionDone Then
                    '                    Exit Do
                    '                End If
                    '            Loop
                    '        Next


                    '        Exit While
                    '    Else
                    '        Exit Do
                    '    End If
                    'Loop

                    'Do
                    '    If IMC._IMCCardInformation(Axis1).MotionDone Then
                    '        Exit Do
                    '    End If
                    'Loop
                Else
                    IMC.MoveVel(Axis1, dStep)
                    Do
                        GetChannelData(Channel, CurrentPower)
                        If CurrentPower > MaxPowerValue Then
                            Exit While
                        Else
                            Exit Do
                        End If
                    Loop

                    Do
                        If IMC._IMCCardInformation(Axis1).MotionDone Then
                            Exit Do
                        End If
                    Loop
                End If

                System.Threading.Thread.Sleep(5)
                CurrentPosX = IMC._IMCCardInformation(Axis1).Postion
                CurrentPosY = IMC._IMCCardInformation(Axis2).Postion
                IO.File.AppendAllText(TestFile.FullName & "\BlindSearch.csv", CurrentPosX & "," & CurrentPosY & vbNewLine)
            Next
            For i = 1 To n
                System.Threading.Thread.Sleep(10)
                If n > 5 Then
                    BlindRecodePos.Clear()
                    BlindRecodePower.Clear()
                    StartBlindRecode = True
                    IMC.MoveVel(Axis2, dStep * n)
                    Do
                        If IMC._IMCCardInformation(Axis2).MotionDone Then
                            StartBlindRecode = False
                            Exit Do
                        End If
                    Loop
                    BlindRecodePower.Sort()
                    Dim MaxPower As Single
                    Dim Power As Single = BlindRecodePower(BlindRecodePower.Count - 1)
                    If Power > MaxPowerValue Then
                        MaxPower = Power
                        For Each de As DictionaryEntry In BlindRecodePos
                            If de.Key = Power Then
                                Dim pos As Double = de.Value
                                IMC.MoveAbs(Axis2, pos)
                                Do
                                    If IMC._IMCCardInformation(Axis2).MotionDone Then
                                        Exit Do
                                    End If
                                Loop
                            End If
                        Next

                        Exit While
                    End If
                Else
                    IMC.MoveVel(Axis2, dStep)
                    Do
                        GetChannelData(Channel, CurrentPower)
                        If CurrentPower > MaxPowerValue Then
                            Exit While
                        Else
                            Exit Do
                        End If
                    Loop
                    Do
                        If IMC._IMCCardInformation(Axis2).MotionDone Then
                            Exit Do
                        End If
                    Loop
                End If

                System.Threading.Thread.Sleep(5)
                CurrentPosX = IMC._IMCCardInformation(Axis1).Postion
                CurrentPosY = IMC._IMCCardInformation(Axis2).Postion
                IO.File.AppendAllText(TestFile.FullName & "\BlindSearch.csv", CurrentPosX & "," & CurrentPosY & vbNewLine)
            Next
            n = n + 1
            If n > ScanX Then
                Exit While
            End If
            dStep = -dStep
        End While

        'IMC.MoveAbs(Axis1, MaxPos)
        'Do
        '    If IMC._IMCCardInformation(Axis1).MotionDone Then
        '        Exit Do
        '    End If
        'Loop

        'IMC.MoveAbs(Axis2, MaxPos1)
        'Do
        '    If IMC._IMCCardInformation(Axis2).MotionDone Then
        '        Exit Do
        '    End If
        'Loop



        ContorlChange(MainForm.Button8, "盲扫")
    End Sub

#End Region

#Region "Read PowerValue"
    ' DataGraphChange 隐藏DataGraph_1
    Public Sub DataGraphChange()
        If MainForm.DataGraph_1.InvokeRequired Then
            MainForm.DataGraph_1.Invoke(New Action(AddressOf DataGraphChange))
        Else
            MainForm.DataGraph_1.Visible = False
            MainForm.DataGraph_1.Dock = DockStyle.None
        End If
    End Sub
    ' DataGraphChange 显示DataGraph_DB
    Public Sub DataGraphChange1()
        If MainForm.DataGraph_DB.InvokeRequired Then
            MainForm.DataGraph_DB.Invoke(New Action(AddressOf DataGraphChange1))
        Else
            MainForm.DataGraph_DB.Visible = True

            MainForm.DataGraph_DB.Dock = DockStyle.Fill
        End If

    End Sub
    'Private Indexa As Int16 = -1
    'Private Indexa As Int16 = -1
    '
    ' 获得指定通道号 功率值 | IsClearNosiy（去毛刺，取20次安全平均值）
    '
    Public Sub GetChannelData(ByVal strIO As AxisInfo.ChannelName, ByRef power As Double, Optional ByVal IsClearNosiy As Boolean = True)
        'Dim a() As String = File.ReadAllLines("C:\OPAUTO_Data\Test\SensorTouch.csv")
        'If Indexa = a.Length Then

        '    power = a(a.Length - 1)
        '    MainForm.DataGraph.AddPointY("Sensor", power)
        '    Return
        'End If
        'Indexa = Indexa + 1
        'power = a(Indexa)
        'MainForm.DataGraph.AddPointY("Sensor", power)
        'Return

        System.Threading.Thread.Sleep(5)

        Select Case strIO
            Case AxisInfo.ChannelName.PowerChA
                ' 显示模拟功率Page
                ChangeTabIndex(MainForm.TabControl3, 0)
                '   ContorlPerClick(MainForm.PowerGraRadioBtn)
                ChangeTabIndex(MainForm.TabControl3, 0)
                If IsClearNosiy Then
                    Dim tmp As Double = 0
                    Dim Reslutlist As New List(Of Double)
                    Reslutlist.Clear()
                    For i As Int16 = 0 To 20
                        tmp = ESP300.ChALightPower
                        Reslutlist.Add(tmp)
                    Next
                    Reslutlist.Sort()
                    Reslutlist.Remove(0)
                    Reslutlist.Remove(0)
                    Reslutlist.Remove(Reslutlist.Count - 1)
                    Reslutlist.Remove(Reslutlist.Count - 1)
                    tmp = 0
                    For i As Int16 = 0 To Reslutlist.Count - 1
                        tmp = tmp + Reslutlist(i)
                    Next
                    tmp = tmp / Reslutlist.Count
                    power = tmp
                    Try

                        MainForm.DataGraph_DB.AddPointY("Power", power)
                    Catch ex As Exception
                        MainForm.DataGraph_1.ClearGraph()
                    End Try
                Else
                    power = ESP300.ChALightPower
                    Try
                        MainForm.DataGraph_DB.AddPointY("Power", power)
                    Catch ex As Exception
                        MainForm.DataGraph_1.ClearGraph()
                    End Try
                End If


            Case AxisInfo.ChannelName.PowerChB
                'ChangeTabIndex(MainForm.TabControl3, 0)
                '' ContorlPerClick(MainForm.PowerGraRadioBtn)
                'ChangeTabIndex(MainForm.TabControl3, 0)
                'Dim tmp As Double = 0
                'tmp = ESP300.ChBlightPower
                'power = tmp
                'Try
                '    MainForm.DataGraph_DB.AddPointY("Power", power)
                'Catch ex As Exception
                '    MainForm.DataGraph_DB.ClearGraph()
                'End Try

                ' Sample USB POWER2's Value || 0329 
                ChangeTabIndex(MainForm.TabControl3, 0)
                ' ContorlPerClick(MainForm.PowerGraRadioBtn)
                ChangeTabIndex(MainForm.TabControl3, 0)

                'Dim tmp As Double = 0
                'tmp = mCyUsb.ReadADValue()
                'power = tmp
                'Try
                '    MainForm.DataGraph_DB.AddPointY("Power", power)
                'Catch ex As Exception
                '    MainForm.DataGraph_DB.ClearGraph()
                'End Try
                '
                Dim tmp As Double = 0
                Dim Reslutlist As New List(Of Double)
                Reslutlist.Clear()
                For i As Int16 = 0 To 20
                    tmp = mCyUsb.ReadADValue()
                    Reslutlist.Add(tmp)
                Next
                Reslutlist.Sort()
                Reslutlist.Remove(0)
                Reslutlist.Remove(0)
                Reslutlist.Remove(Reslutlist.Count - 1)
                Reslutlist.Remove(Reslutlist.Count - 1)
                tmp = 0
                For i As Int16 = 0 To Reslutlist.Count - 1
                    tmp = tmp + Reslutlist(i)
                Next
                tmp = tmp / Reslutlist.Count
                power = tmp
                Try

                    MainForm.DataGraph_DB.AddPointY("Power", power)
                Catch ex As Exception
                    MainForm.DataGraph_1.ClearGraph()
                End Try



            Case AxisInfo.ChannelName.SensorChA
                'ChangeTabIndex(MainForm.TabControl3, 1)
                'ContorlPerClick(MainForm.TouchRadioBtn)
                ChangeTabIndex(MainForm.TabControl3, 1)
                Dim tmp As Single = 0
                Dim Reslut As New List(Of Double)

                power = ESP300.ChASeneor.ToString("0.0000")
                'For i As Int16 = 0 To 20
                '    power = ESP300.ChASeneor.ToString("0.0000")
                '    Reslut.Add(power)
                'Next
                'ClearPower(Reslut, power)
                Dim Tmp1 As Double = Convert.ToDouble(power).ToString("f4") '? 
                power = Tmp1
                Try
                    MainForm.DataGraph.AddPointY("Sensor", power)
                Catch ex As Exception
                    MainForm.DataGraph.ClearGraph()
                End Try

            Case AxisInfo.ChannelName.SensorChB
                ChangeTabIndex(MainForm.TabControl3, 1)
                ' ContorlPerClick(MainForm.TouchRadioBtn)
                Dim tmp As Single = 0
                Dim Reslut As New List(Of Double)
                For i As Int16 = 0 To 4
                    power = ESP300.ChASeneor.ToString("0.0000")
                    Reslut.Add(power)
                Next
                Reslut.Sort()

                power = (Reslut(1) + Reslut(2) + Reslut(3)) / 3
                ' Dim Tmp1 As Double = Convert.ToDouble(power).ToString("f4")

                Dim Tmp1 As Double = Convert.ToDouble(power).ToString("f4")
                power = Tmp1
                Try
                    ' MainForm.DataGraph.AddPointY("Sensor", power)
                Catch ex As Exception
                    ' MainForm.DataGraph.ClearGraph()
                End Try
                ' MainForm.DataGraph.AddPointY("Sensor", power)
        End Select
        '  ContorlChange(MainForm.lblAPower, power.ToString("0.00"))
    End Sub
    Public IsRefreshIOStatus As Boolean = True
    '
    ' 获得通道值（从变量中去值） ： IsClearNosiy 是否去毛刺（即去掉2个最小、2个最大，取平均）
    Public Sub GetChannelDataForTime(ByVal strIO As AxisInfo.ChannelName, ByRef power As Double, Optional ByVal IsClearNosiy As Boolean = True, Optional IsOffSet As Boolean = True)
        'Dim a() As String = File.ReadAllLines("C:\OPAUTO_Data\Test\SensorTouch.csv")
        'If Indexa = a.Length Then

        '    power = a(a.Length - 1)
        '    MainForm.DataGraph.AddPointY("Sensor", power)
        '    Return
        'End If
        'Indexa = Indexa + 1
        'power = a(Indexa)
        'MainForm.DataGraph.AddPointY("Sensor", power)
        'Return

        System.Threading.Thread.Sleep(5)
        Select Case strIO
            Case AxisInfo.ChannelName.PowerChA
                ' ChangeTabIndex(MainForm.TabControl3, 0)
                If IsClearNosiy Then
                    Dim tmp As Double = 0
                    Dim Reslutlist As New List(Of Double)
                    Reslutlist.Clear()
                    For i As Int16 = 0 To 20

                        tmp = ESP300.ChALightPower

                        Reslutlist.Add(tmp)
                    Next
                    Reslutlist.Sort()
                    Reslutlist.Remove(0)
                    Reslutlist.Remove(0)
                    Reslutlist.Remove(Reslutlist.Count - 1)
                    Reslutlist.Remove(Reslutlist.Count - 1)
                    tmp = 0
                    For i As Int16 = 0 To Reslutlist.Count - 1
                        tmp = tmp + Reslutlist(i)
                    Next
                    tmp = tmp / Reslutlist.Count
                    power = tmp
                Else
                    power = ESP300.ChALightPower
                End If


            Case AxisInfo.ChannelName.PowerChB

                'Dim tmp As Double = 0
                'tmp = ESP300.ChBlightPower
                'power = tmp

                '''''''''''
                ' Sample USB POWER2's Value || 0329 
                'Dim dP2 = mCyUsb.ReadADValue()
                'power = dP2

                ''''''''''''''''''''''''''
                Dim tmp As Double = 0
                Dim Reslutlist As New List(Of Double)
                Reslutlist.Clear()
                For i As Int16 = 0 To 20
                    ''tmp = ESP300.ChALightPower
                    tmp = mCyUsb.ReadADValue()
                    Reslutlist.Add(tmp)
                Next
                Reslutlist.Sort()
                Reslutlist.Remove(0)
                Reslutlist.Remove(0)
                Reslutlist.Remove(Reslutlist.Count - 1)
                Reslutlist.Remove(Reslutlist.Count - 1)
                tmp = 0
                For i As Int16 = 0 To Reslutlist.Count - 1
                    tmp = tmp + Reslutlist(i)
                Next
                tmp = tmp / Reslutlist.Count
                power = tmp
                Try

                    MainForm.DataGraph_DB.AddPointY("Power", power)
                Catch ex As Exception
                    MainForm.DataGraph_1.ClearGraph()
                End Try



                '''''''''''
            Case AxisInfo.ChannelName.SensorChA
                Dim tmp As Single = 0
                Dim Reslut As New List(Of Double)
                power = ESP300.ChASeneor.ToString("0.0000")

                If MainForm.CheckBox7.Checked = True Then
                    For i As Int16 = 0 To 10000
                        power = ESP300.ChASeneor.ToString("0.0000")
                        Reslut.Add(power)
                    Next
                    ClearPower(Reslut, power)
                End If

                Dim Tmp1 As Double = Convert.ToDouble(power).ToString("f4")
                power = Tmp1
            Case AxisInfo.ChannelName.SensorChB

                Dim tmp As Single = 0
                Dim Reslut As New List(Of Double)
                For i As Int16 = 0 To 4
                    power = ESP300.ChBSensor.ToString("0.0000")
                    Reslut.Add(power)
                Next
                Reslut.Sort()
                power = (Reslut(1) + Reslut(2) + Reslut(3)) / 3
                Dim Tmp1 As Double = Convert.ToDouble(power).ToString("f4")
                power = Tmp1
        End Select
    End Sub

    ' 去毛刺功率值
    Public Sub ClearPower(Reslutlist As List(Of Double), ByRef power As Double, Optional ByVal Number As Int16 = 20)
        Dim Tmp As Double = 0
        Reslutlist.Sort()
        Reslutlist.Remove(0)
        Reslutlist.Remove(0)
        Reslutlist.Remove(Reslutlist.Count - 1)
        Reslutlist.Remove(Reslutlist.Count - 1)
        Tmp = 0
        For i As Int16 = 0 To Reslutlist.Count - 1
            Tmp = Tmp + Reslutlist(i)
        Next
        Tmp = Tmp / Reslutlist.Count
        power = Tmp
    End Sub
#End Region

#Region "插玻璃管"

    Enum GlassStep
        Start
        X_Move
        AnglizeInfoX
        Y_Move
        AnglizeInfoY
        DataDetail
        Z_Move
        Z_Detail
        Over
    End Enum
    Private MaxPos_X As Double
    Private MinPos_X As Double
    Private MaxPos_Y As Double
    Private MinPos_Y As Double
    Private RecodePowerAxisX As New List(Of String)
    Private RecodePowerAxisY As New List(Of String)
    Private RecodePosHastableAxisX As New Hashtable
    Private RecodePosHastableAxisY As New Hashtable
    Private MoveMindAxis As Int16
    ' 【插玻璃管】
    ' AxisSensor=2
    ' 对X、Y盲扫式，每一步对Z轴进行插入尝试（以及再前行50u）若小于指定阈值则算找到，否则继续
    '
    Public Sub InsertGlassToLens(ByVal obj As InserGalssTubePara) 'ByVal Axis0 As Int16, ByVal Axis1 As Int16, ByVal Axis2 As Int16, ByVal AxisR As Int16,channel as Int16)
        Dim ScanX As Int32                  ' 待扫描的总数 = 1轴最大偏移/1轴步长
        Dim dStep As Double = obj.Axis1MoveStep                 ' obj：轴1步长
        ScanX = (obj.Axis1MaxMoveOffSet) / obj.Axis1MoveStep    ' obj：轴1要扫描的总数
        Dim CurrentPower As Single
        Dim CheckPoint As Int16 = 2 ' ~~
        Dim n As Int16 = 1      ' 当前扫描次，最大的步数
        Dim Count As Int16 = 0  ' ~~
        Dim ZeroSensorValue As Double = obj.ZeroSenserValue     ' obj：0感应阈值       |Z轴不能大于的阈值
        Dim ZeroSensordstep As Double = obj.SenserInsertOffSet  ' obj：感应插入的距离  |Z轴插入的距离
        Dim Axis1 As Int16 = obj.Axis1                          ' obj：轴1
        Dim Axis2 As Int16 = obj.Axis2                          ' obj：轴2
        Dim AxisSensor As Int16 = obj.AxisSensor                ' obj：  感应轴|应该是2
        Dim AxisSensorMaxPos As String = obj.SensorMaxPostion   ' obj：  Z轴安全距离， 用于首次判断|即首先Z的距离必须 <= AxisSensorMaxPos + 300
        Dim DelayTime As Double = 10

        '‘Dim FristInfo, CurentInfo, MaxInfo, TargetInfo As TargetDataOne
        ' 记录X、Y、Z轴的起始位置， 
        Dim StartPosX As Double = IMC._IMCCardInformation(Axis1).Postion
        System.Threading.Thread.Sleep(200)
        Dim StartPosY As Double = IMC._IMCCardInformation(Axis2).Postion
        System.Threading.Thread.Sleep(200)
        Dim StartPosZ As Double = IMC._IMCCardInformation(2).Postion

        Dim IsSearchOK As Boolean = False
        ContorlChange(MainForm.Label42, False)
        System.Threading.Thread.Sleep(20)

        ' Z轴的安全距离， 不能小于（Z轴安全距离+300）小于则退出函数
        Dim Maxpos As Double = IMC._IMCCardInformation(AxisSensor).Postion
        System.Threading.Thread.Sleep(10)
        Dim Index As Int16 = 0
        ContorlChange(MainForm.ProgressBar1, Index)
        If Maxpos <= AxisSensorMaxPos + 300 Then
            Return
        End If
        'If Maxpos < AxisSensorMaxPos - 10 Then
        '    Return
        'End If

        ' Z轴插入指定距离（ZeroSensordstep）（-方向）后，并等待（《0.1）误差范围内退出当前等待
        ' 判断当前功率值如果小于《指定阈值（ZeroSensorValue）则再前行50u 如果还是小于则算找到了
        '  否则原路返回并等待马达停止
        Dim pos12 As Double = IMC._IMCCardInformation(AxisSensor).Postion
        IMC.MoveVel(AxisSensor, -ZeroSensordstep)
        Do
            Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
            If IMC._IMCCardInformation(AxisSensor).MotionDone AndAlso Math.Abs(Math.Abs(pos12 - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                Exit Do
            End If
        Loop
        System.Threading.Thread.Sleep(DelayTime + 10)
        System.Threading.Thread.Sleep(DelayTime + 10)
        GetChannelData(2, CurrentPower)
        If CurrentPower <= ZeroSensorValue Then ' And CurentInfo.power < ZeroSensordstep + 0.3 Then
            IMC.MoveVel(AxisSensor, -50)
            Do
                If IMC._IMCCardInformation(AxisSensor).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime + 10)
            System.Threading.Thread.Sleep(DelayTime + 10)
            GetChannelData(AxisSensor, CurrentPower)
            If CurrentPower <= ZeroSensorValue Then
                ContorlChange(MainForm.Label42, True)
                IsSearchOK = True
            End If
        Else
            System.Threading.Thread.Sleep(DelayTime + 10)
            IMC.MoveVel(AxisSensor, ZeroSensordstep)
            System.Threading.Thread.Sleep(500)
            Do
                If IMC._IMCCardInformation(AxisSensor).MotionDone Then
                    Exit Do
                End If
            Loop
        End If

        ' 以上未成功，继续
        ' 
        ' 对X、Y盲扫式，每一步对Z轴进行插入尝试（以及再前行50u）若小于指定阈值则算找到，否则继续
        '
        If IsSearchOK = False Then
            While (True)
                ' 动画
                If Index = 100 Then Index = 0
                ContorlChange(MainForm.ProgressBar1, Index)
                Index = Index + 0.5
                If _OpStep = OpStep.NextStep Then
                    Return
                End If

                For i As Integer = 1 To n
                    ' 动画
                    If Index = 100 Then Index = 0
                    ContorlChange(MainForm.ProgressBar1, Index)
                    Index = Index + 0.5
                    System.Threading.Thread.Sleep(10)
                    '
                    ' X轴移动步（dstep）， 等待马达结束后; 
                    ' Z轴插入指定距离（-),等待马达停止并在0.1误差范围内退出当前等待试着判断当前功率是否小于指定阈值，若小于再前行50u如还小则成功，退出当前大循环；否则Z轴回原来位置
                    '
                    IMC.MoveVel(Axis1, dStep)   ' 移动X后 等停止
                    Do
                        If IMC._IMCCardInformation(Axis1).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Dim pos As Double = IMC._IMCCardInformation(AxisSensor).Postion '移动Z 等停止并指定0.1内
                    IMC.MoveVel(AxisSensor, -ZeroSensordstep)
                    Do
                        Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
                        If IMC._IMCCardInformation(AxisSensor).MotionDone AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    GetChannelData(2, CurrentPower)
                    AddRunLog("当前Power值：" & CurrentPower)
                    If CurrentPower <= ZeroSensorValue Then ' And CurentInfo.power < ZeroSensordstep + 0.3 Then
                        IMC.MoveVel(AxisSensor, -50)
                        Do
                            If IMC._IMCCardInformation(AxisSensor).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        System.Threading.Thread.Sleep(DelayTime + 10)
                        System.Threading.Thread.Sleep(DelayTime + 10)
                        GetChannelData(AxisSensor, CurrentPower)
                        If CurrentPower <= ZeroSensorValue Then
                            ContorlChange(MainForm.Label42, True)
                            IsSearchOK = True
                            Exit While
                        End If
                    End If
                    ' Z轴回
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    GetChannelData(AxisSensor, CurrentPower)
                    pos = IMC._IMCCardInformation(AxisSensor).Postion
                    IMC.MoveVel(AxisSensor, ZeroSensordstep)            '? 50会累积下去
                    Do
                        Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
                        If IMC._IMCCardInformation(AxisSensor).MotionDone AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(5)
                Next
                For i As Integer = 1 To n
                    ' Y轴尝试
                    System.Threading.Thread.Sleep(10)
                    If Index = 100 Then Index = 0
                    ContorlChange(MainForm.ProgressBar1, Index)
                    Index = Index + 0.5

                    IMC.MoveVel(Axis2, dStep)
                    Do
                        If IMC._IMCCardInformation(Axis2).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Dim pos As Double = IMC._IMCCardInformation(AxisSensor).Postion
                    IMC.MoveVel(AxisSensor, -ZeroSensordstep)
                    Do
                        Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
                        If IMC._IMCCardInformation(AxisSensor).MotionDone AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                            Exit Do
                        End If
                    Loop
                    System.Threading.Thread.Sleep(DelayTime)
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    GetChannelData(2, CurrentPower)

                    AddRunLog("当前Power值：" & CurrentPower)
                    If CurrentPower <= ZeroSensorValue Then
                        pos = IMC._IMCCardInformation(2).Postion
                        IMC.MoveVel(AxisSensor, -50)
                        Do
                            Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
                            If IMC._IMCCardInformation(AxisSensor).MotionDone Then 'AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                                Exit Do
                            End If
                        Loop
                        System.Threading.Thread.Sleep(DelayTime + 10)
                        System.Threading.Thread.Sleep(DelayTime + 10)
                        GetChannelData(2, CurrentPower)
                        If CurrentPower <= ZeroSensorValue Then
                            ContorlChange(MainForm.Label42, True)
                            IsSearchOK = True
                            Exit While
                        End If
                    End If
                    System.Threading.Thread.Sleep(DelayTime + 10)
                    pos = IMC._IMCCardInformation(2).Postion
                    IMC.MoveVel(AxisSensor, ZeroSensordstep)
                    Do
                        Dim pos1 As Double = IMC._IMCCardInformation(AxisSensor).Postion
                        If IMC._IMCCardInformation(AxisSensor).MotionDone AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
                            Exit Do
                        End If
                    Loop
                Next
                '' 下一个for
                n = n + 1
                If n > ScanX Then
                    Exit While
                End If
                dStep = -dStep  ' 反方向
            End While
        End If

        ''
        If IsSearchOK = False Then
            IMC.MoveAbs(Axis1, StartPosX)
            System.Threading.Thread.Sleep(200)
            IMC.MoveAbs(Axis2, StartPosY)
            System.Threading.Thread.Sleep(200)
            IMC.MoveAbs(AxisSensor, StartPosZ)
        Else
            'dStep = 10
            'ScanX = 100 / dStep

            'Dim pos As Double = IMC._IMCCardInformation(2).Postion
            'IMC.MoveVel(2, -ZeroSensordstep)
            'Do
            '    Dim pos1 As Double = IMC._IMCCardInformation(2).Postion
            '    If IMC._IMCCardInformation(2).MotionDone AndAlso Math.Abs(Math.Abs(pos - pos1) - Math.Abs(ZeroSensordstep)) < 0.1 Then
            '        Exit Do
            '    End If
            'Loop
            'While (True)
            '    For i = 1 To n
            '        System.Threading.Thread.Sleep(10)
            '        IMC.MoveVel(Axis1, dStep)
            '        Do
            '            If IMC._IMCCardInformation(Axis1).MotionDone Then
            '                Exit Do
            '            End If
            '            If CurrentPower <= ZeroSensorValue Then
            '                ContorlChange(MainForm.Label42, True)
            '                Exit While
            '            End If
            '        Loop
            '        System.Threading.Thread.Sleep(5)
            '    Next
            '    For i = 1 To n
            '        System.Threading.Thread.Sleep(10)

            '        IMC.MoveVel(Axis2, dStep)
            '        Do
            '            If IMC._IMCCardInformation(Axis2).MotionDone Then
            '                Exit Do
            '            End If
            '        Loop
            '        System.Threading.Thread.Sleep(DelayTime + 10)
            '        GetChannelData(2, CurrentPower)
            '        System.Threading.Thread.Sleep(DelayTime + 10)
            '        AddRunLog("当前Power值：" & CurrentPower)
            '        If CurrentPower <= ZeroSensorValue Then
            '            ContorlChange(MainForm.Label42, True)
            '            Exit While
            '        End If
            '        System.Threading.Thread.Sleep(DelayTime + 10)
            '    Next
            '    n = n + 1
            '    If n > ScanX Then
            '        Exit While
            '    End If
            '    dStep = -dStep
            'End While
        End If

        IsTimerRefreshData = True

    End Sub
    'w
    Public Function 爬山法(ByVal AxisR As Int16, ByVal Channel As Int16, Optional ByVal powerDelta As Double = 0.001, Optional ByVal Rang As Double = 390, Optional ByVal pictch As Double = 2, Optional ByVal MaxPowerVlue As Double = 0.9, Optional ByVal IsUsedDoubleCheck As Boolean = True) As Boolean
        Dim quit_Flag As Int16
        Dim dStep As Double = 5
        Dim Delta As Double = powerDelta
        Dim Current_Chkpoint As Integer
        Dim PicthCount As Int16 = 1
        Dim neg_Step As Single = dStep
        Dim pos_Step As Single = -dStep
        Dim _Iteration As Int16 = 0
        Dim frist_info, current_info, max_info As TargetDataOne
        Dim save_Info As New List(Of TargetDataOne)
        Dim AxisNo As Int16 = AxisR
        quit_Flag = 1
        Dim Index As AglinmentStatus
        Dim MaxValue As Double = MaxPowerVlue
        quit_Flag = 1
        While quit_Flag = 1
            Select Case Index
                Case AglinmentStatus.start

                    frist_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, frist_info.power)
                    max_info = frist_info
                    Current_Chkpoint = 0
                    Index = AglinmentStatus.pos_move
                Case AglinmentStatus.pos_move
                    Dim pos As Double = IMC._IMCCardInformation(AxisNo).Postion
                    If Math.Abs(pos - frist_info.pos) > 30 Then
                        Index = AglinmentStatus.over
                    Else
                        IMC.MoveVel(AxisNo, pos_Step)
                        System.Threading.Thread.Sleep(5)
                        Do
                            If IMC._IMCCardInformation(AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        Index = AglinmentStatus.pos_get_info
                    End If

                Case AglinmentStatus.pos_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.pos_compare
                Case AglinmentStatus.pos_compare
                    If (current_info.power < max_info.power + Delta) Then
                        Index = AglinmentStatus.pos_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.pos_detail
                    End If
                Case AglinmentStatus.pos_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.pos_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.pos_go_max
                    End If
                Case AglinmentStatus.pos_go_max
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.max_frist_compare
                Case AglinmentStatus.max_frist_compare
                    If max_info.pos - frist_info.pos > PicthCount * dStep Then
                        Index = AglinmentStatus.over
                    Else
                        current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                        GetChannelData(Channel, current_info.power)
                        max_info = current_info
                        Current_Chkpoint = 0
                        Index = AglinmentStatus.neg_move
                    End If
                Case AglinmentStatus.neg_move
                    Dim pos As Double = IMC._IMCCardInformation(AxisNo).Postion
                    If Math.Abs(pos - frist_info.pos) > 30 Then
                        Index = AglinmentStatus.over
                    Else
                        IMC.MoveVel(AxisNo, neg_Step)
                        System.Threading.Thread.Sleep(5)
                        Do
                            If IMC._IMCCardInformation(AxisNo).MotionDone Then
                                Exit Do
                            End If
                        Loop
                        Index = AglinmentStatus.neg_get_info
                    End If

                Case AglinmentStatus.neg_get_info
                    current_info.pos = IMC._IMCCardInformation(AxisNo).Postion
                    GetChannelData(Channel, current_info.power)
                    Dim Tmp As TargetDataOne
                    Tmp.pos = IMC._IMCCardInformation(0).Postion & "," & IMC._IMCCardInformation(1).Postion
                    Tmp.power = current_info.power
                    save_Info.Add(Tmp)
                    Index = AglinmentStatus.neg_compare
                Case AglinmentStatus.neg_compare
                    If (current_info.power < max_info.power + Delta) Then
                        Index = AglinmentStatus.neg_move
                        max_info = current_info
                        Current_Chkpoint = 0
                    Else
                        Index = AglinmentStatus.neg_detail
                    End If
                Case AglinmentStatus.neg_detail
                    If Current_Chkpoint < PicthCount Then
                        Index = AglinmentStatus.neg_move
                        Current_Chkpoint += 1
                    Else
                        Index = AglinmentStatus.neg_go_max
                    End If
                Case AglinmentStatus.neg_go_max
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    Index = AglinmentStatus.over


                Case AglinmentStatus.over
                    IMC.MoveAbs(AxisNo, max_info.pos)
                    System.Threading.Thread.Sleep(5)
                    Do
                        If IMC._IMCCardInformation(AxisNo).MotionDone Then
                            Exit Do
                        End If
                    Loop
                    For i As Int16 = 0 To save_Info.Count - 1
                        System.IO.File.AppendAllText(TestFile.FullName & "\AxisAlignment1.csv", save_Info(i).pos & "," & save_Info(i).power & vbNewLine)
                    Next
                    Try
                        'MainForm.DataGraph_1.AddPointY("Power", max_info.power)
                    Catch ex As Exception
                        ' MainForm.DataGraph_1.ClearGraph()
                    End Try
                    quit_Flag = 0
                Case Else
                    quit_Flag = 0
            End Select

        End While


    End Function

#End Region
    'w
#Region "插补"
    Public IsXNeedAddOffset As Boolean = True
    Public IsYNeedAddOffset As Boolean = True
    Public Sub 插补法1(ByVal obj As AgilenentPara)
        Dim StartPos, SecondPos, LastPos, TargetPos, MaxPos As Tool.ToolPoint
        Dim ZMoveMaxPower As Double
        Dim StartJump As Boolean = False
        Dim JumpZCount As Int16 = 0
        Dim AlignementTime As Date = Now
        ContorlChange(MainForm.TxtSpanTime, 0)
        Dim IterationCount As Int16 = 0
        '寻找空间坐标第一个点
        AddRunLog("开始第一次爬山")
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        AddRunLog("第一次爬山结束")
        StartPos.X = IMC._IMCCardInformation(0).Postion
        StartPos.Y = IMC._IMCCardInformation(1).Postion
        'OneAxisSearch(0, StartPos.X, 0)
        'OneAxisSearch(1, StartPos.Y, 0)
        StartPos.Z = IMC._IMCCardInformation(2).Postion
        '已找到空间直线第一个点 StartPos
        AddRunLog("第一个值：" & StartPos.ToString)
        AddRunLog("Z轴往前推100um")
        'Z轴往前推100um，然后寻找空间直线第二点
        Dim ZStep As Double = -100
        Dim PerPowerValue As Double = 0
        Dim AfterPowerValue As Double = 0
        Dim PowerDelta As Double = 0.6
        Dim DelayTime As Double = 20
        IMC.MoveVel(2, ZStep)
        Do
            If IMC._IMCCardInformation(2).MotionDone Then
                Exit Do
            End If
        Loop
        AddRunLog("Z轴完成动作")
        AddRunLog("第二次爬山开始")
        obj._Picth = 4
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        SecondPos.X = IMC._IMCCardInformation(0).Postion
        SecondPos.Y = IMC._IMCCardInformation(1).Postion
        SecondPos.Z = IMC._IMCCardInformation(2).Postion
        AddRunLog("第二次爬山结束")
        AddRunLog("第二个值：" & SecondPos.ToString)
        '已找到第二点
        '创建第一个坐标系
        MathTool.CreatTool(StartPos, SecondPos)
        AddRunLog("KX：" & MathTool.KX)
        AddRunLog("KY;" & MathTool.kY)
        AddRunLog("开始寻找第三个点")
        '寻找第三个点
        ZStep = -5
        Do
            GetChannelData(0, PerPowerValue)
            AddRunLog("开始动Z轴Step为-5um之前的光亮为：" & PerPowerValue)
            IMC.MoveVel(2, ZStep)
            Dim CurrentPos As Tool.ToolPoint
            MathTool.OffSetXY(ZStep, CurrentPos)
            AddRunLog("开始动Z轴Step为-5um,X补偿为：" & CurrentPos.X & "Y补偿为：" & CurrentPos.Y)
            IMC.MoveVel(1, CurrentPos.Y)
            IMC.MoveVel(0, CurrentPos.X)
            Do
                If IMC._IMCCardInformation(2).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(0, AfterPowerValue)
            AddRunLog("开始动Z轴Step为-5um之后的光亮为：" & AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                If StartJump = False Then

                    ZMoveMaxPower = PerPowerValue
                    AddRunLog("开始动Z轴Step为-5um,第一次出现下降，此时功率最大为" & ZMoveMaxPower)
                End If
                StartJump = True
            Else
                System.Threading.Thread.Sleep(DelayTime)

                ZMoveMaxPower = AfterPowerValue
                AddRunLog("开始动Z轴Step为-5um,上升，此时功率最大为" & ZMoveMaxPower)
                StartJump = False
            End If

            If AfterPowerValue <= ZMoveMaxPower - PowerDelta Then
                AddRunLog("开始动Z轴Step为-5um,下降，此时功率最大为" & ZMoveMaxPower)
                AddRunLog("开始动Z轴Step为-5um,下降，此时功率最小为" & AfterPowerValue)

                StartJump = True
                Exit Do
            End If
        Loop
        StartJump = False
        AddRunLog("开始爬山")
        obj._Picth = 4
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        AddRunLog("结束爬山")
        LastPos.X = IMC._IMCCardInformation(0).Postion
        LastPos.Y = IMC._IMCCardInformation(1).Postion
        LastPos.Z = IMC._IMCCardInformation(2).Postion
        AddRunLog("第三次值" & LastPos.ToString)
        MathTool.CreatTool(StartPos, LastPos)
        AddRunLog("KX:" & MathTool.KX)
        AddRunLog("KY:" & MathTool.kY)


        ZStep = -2
        Dim CkCount As Int16 = 0
        GetChannelData(0, MaxPos.Power)
        MaxPos.X = IMC._IMCCardInformation(0).Postion
        MaxPos.Y = IMC._IMCCardInformation(1).Postion
        MaxPos.Z = IMC._IMCCardInformation(2).Postion
        Do
            GetChannelData(0, PerPowerValue)

            TargetPos.X = IMC._IMCCardInformation(0).Postion
            TargetPos.Y = IMC._IMCCardInformation(1).Postion
            TargetPos.Z = IMC._IMCCardInformation(2).Postion
            IMC.MoveVel(2, ZStep)
            Dim CurrentPos As Tool.ToolPoint
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                If StartJump = False Then
                    System.Threading.Thread.Sleep(10)

                    ZMoveMaxPower = PerPowerValue
                    AddRunLog("开始动Z轴Step为-2um,第一次出现下降，此时功率最大为" & ZMoveMaxPower)
                    TargetPos.Z = IMC._IMCCardInformation(2).Postion
                End If
                StartJump = True
            Else
                System.Threading.Thread.Sleep(DelayTime)
                ZMoveMaxPower = AfterPowerValue
                AddRunLog("开始动Z轴Step为-2um,上升，此时功率最大为" & ZMoveMaxPower)
                StartJump = False
            End If

            If AfterPowerValue <= ZMoveMaxPower - 0.05 Then

                Do
                    If IMC._IMCCardInformation(2).MotionDone Then
                        Exit Do
                    End If
                Loop
                AddRunLog("开始动Z轴Step为-2um,下降，此时功率最大为" & ZMoveMaxPower)
                'IMC.MoveAbs(2, TargetPos.Z)
                AddRunLog("开始动Z轴Step为-2um,下降，此时功率最小为" & AfterPowerValue)
                'IMC.MoveAbs(2, TargetPos.Z)
                Exit Do
            End If


            '
            GetChannelData(0, PerPowerValue)
            MathTool.OffSetXY(ZStep, CurrentPos)
            IMC.MoveVel(0, CurrentPos.X)
            Do
                If IMC._IMCCardInformation(0).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsXNeedAddOffset = False
            Else
                IsXNeedAddOffset = True
            End If

            '
            GetChannelData(0, PerPowerValue)
            IMC.MoveVel(1, CurrentPos.Y)
            Do
                If IMC._IMCCardInformation(1).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsYNeedAddOffset = False
            Else
                IsYNeedAddOffset = True
            End If

            Do
                If IMC._IMCCardInformation(2).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(0, AfterPowerValue)


        Loop

        StartJump = False
        AddRunLog("开始再次校准")
        AddRunLog("寻找第四个点")
        obj._Picth = 3
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        MaxPos.X = IMC._IMCCardInformation(0).Postion
        MaxPos.Y = IMC._IMCCardInformation(1).Postion
        MaxPos.Z = IMC._IMCCardInformation(2).Postion

        MathTool.CreatTool(StartPos, MaxPos)
        AddRunLog("KX：" & MathTool.KX)
        AddRunLog("KY;" & MathTool.kY)

        ZStep = -2

        GetChannelData(0, MaxPos.Power)
        MaxPos.X = IMC._IMCCardInformation(0).Postion
        MaxPos.Y = IMC._IMCCardInformation(1).Postion
        MaxPos.Z = IMC._IMCCardInformation(2).Postion
        Do
            GetChannelData(0, PerPowerValue)

            TargetPos.X = IMC._IMCCardInformation(0).Postion
            TargetPos.Y = IMC._IMCCardInformation(1).Postion
            TargetPos.Z = IMC._IMCCardInformation(2).Postion
            IMC.MoveVel(2, ZStep)
            Dim CurrentPos As Tool.ToolPoint
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                If StartJump = False Then
                    System.Threading.Thread.Sleep(10)

                    ZMoveMaxPower = PerPowerValue
                    AddRunLog("开始动Z轴Step为-1um,第一次出现下降，此时功率最大为" & ZMoveMaxPower)
                    TargetPos.Z = IMC._IMCCardInformation(2).Postion
                End If
                StartJump = True
            Else
                System.Threading.Thread.Sleep(DelayTime)
                ZMoveMaxPower = AfterPowerValue
                AddRunLog("开始动Z轴Step为-1um,上升，此时功率最大为" & ZMoveMaxPower)
                StartJump = False
            End If

            If AfterPowerValue <= ZMoveMaxPower - 0.05 Then

                Do
                    If IMC._IMCCardInformation(2).MotionDone Then
                        Exit Do
                    End If
                Loop
                AddRunLog("开始动Z轴Step为-1um,下降，此时功率最大为" & ZMoveMaxPower)
                'IMC.MoveAbs(2, TargetPos.Z)
                AddRunLog("开始动Z轴Step为-1um,下降，此时功率最小为" & AfterPowerValue)
                AddRunLog("回到最高点")
                IMC.MoveAbs(2, TargetPos.Z)
                Exit Do
            End If


            '
            GetChannelData(0, PerPowerValue)
            MathTool.OffSetXY(ZStep, CurrentPos)
            IMC.MoveVel(0, CurrentPos.X)
            Do
                If IMC._IMCCardInformation(0).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsXNeedAddOffset = False
            Else
                IsXNeedAddOffset = True
            End If

            '
            GetChannelData(0, PerPowerValue)
            IMC.MoveVel(1, CurrentPos.Y)
            Do
                If IMC._IMCCardInformation(1).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsYNeedAddOffset = False
            Else
                IsYNeedAddOffset = True
            End If

            Do
                If IMC._IMCCardInformation(2).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(0, AfterPowerValue)


        Loop


        StartJump = False



        StartJump = False
        AddRunLog("开始再次校准")
        AddRunLog("寻找第五个个点")
        obj._Picth = 3
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        MaxPos.X = IMC._IMCCardInformation(0).Postion
        MaxPos.Y = IMC._IMCCardInformation(1).Postion
        MaxPos.Z = IMC._IMCCardInformation(2).Postion

        MathTool.CreatTool(StartPos, MaxPos)
        AddRunLog("KX：" & MathTool.KX)
        AddRunLog("KY;" & MathTool.kY)

        ZStep = -2

        GetChannelData(0, MaxPos.Power)
        MaxPos.X = IMC._IMCCardInformation(0).Postion
        MaxPos.Y = IMC._IMCCardInformation(1).Postion
        MaxPos.Z = IMC._IMCCardInformation(2).Postion
        Do
            GetChannelData(0, PerPowerValue)

            TargetPos.X = IMC._IMCCardInformation(0).Postion
            TargetPos.Y = IMC._IMCCardInformation(1).Postion
            TargetPos.Z = IMC._IMCCardInformation(2).Postion
            IMC.MoveVel(2, ZStep)
            Dim CurrentPos As Tool.ToolPoint
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                If StartJump = False Then
                    System.Threading.Thread.Sleep(10)

                    ZMoveMaxPower = PerPowerValue
                    AddRunLog("开始动Z轴Step为-1um,第一次出现下降，此时功率最大为" & ZMoveMaxPower)
                    TargetPos.Z = IMC._IMCCardInformation(2).Postion
                End If
                StartJump = True
            Else
                System.Threading.Thread.Sleep(DelayTime)
                ZMoveMaxPower = AfterPowerValue
                AddRunLog("开始动Z轴Step为-1um,上升，此时功率最大为" & ZMoveMaxPower)
                StartJump = False
            End If

            If AfterPowerValue <= ZMoveMaxPower - 0.05 Then

                Do
                    If IMC._IMCCardInformation(2).MotionDone Then
                        Exit Do
                    End If
                Loop
                AddRunLog("开始动Z轴Step为-1um,下降，此时功率最大为" & ZMoveMaxPower)
                'IMC.MoveAbs(2, TargetPos.Z)
                AddRunLog("开始动Z轴Step为-1um,下降，此时功率最小为" & AfterPowerValue)
                AddRunLog("回到最高点")
                IMC.MoveAbs(2, TargetPos.Z)
                Exit Do
            End If


            '
            GetChannelData(0, PerPowerValue)
            MathTool.OffSetXY(ZStep, CurrentPos)
            IMC.MoveVel(0, CurrentPos.X)
            Do
                If IMC._IMCCardInformation(0).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsXNeedAddOffset = False
            Else
                IsXNeedAddOffset = True
            End If

            '
            GetChannelData(0, PerPowerValue)
            IMC.MoveVel(1, CurrentPos.Y)
            Do
                If IMC._IMCCardInformation(1).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(0, AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                IsYNeedAddOffset = False
            Else
                IsYNeedAddOffset = True
            End If

            Do
                If IMC._IMCCardInformation(2).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(0, AfterPowerValue)


        Loop


        StartJump = False
        'ZStep = -1
        'Dim Count As Int16 = 5

        'While True
        '    GetChannelData(0, PerPowerValue)
        '    IMC.MoveVel(2, ZStep)
        '    Count = Count - 1
        '    System.Threading.Thread.Sleep(DelayTime)
        '    GetChannelData(0, AfterPowerValue)
        '    If AfterPowerValue < PerPowerValue Then
        '        obj._Picth = 0.6
        '        While True
        '            For i As Int16 = 0 To obj._AxisNo.Count - 1
        '                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
        '            Next
        '            If IterationCount < obj._IretCount - 1 Then
        '                IterationCount = IterationCount + 1
        '                obj._Picth = obj._Picth * 0.5
        '            Else
        '                Exit While
        '            End If
        '        End While
        '        Dim Power As Double
        '        GetChannelData(0, Power)

        '    End If
        '    If Count = 0 Then
        '        Exit While
        '    End If
        'End While

        ContorlChange(MainForm.TxtSpanTime, Now.Subtract(AlignementTime).TotalSeconds)
    End Sub

    Private ZeroPoint As Double = -14596
    Public Sub 插补法(ByVal obj As AgilenentPara)
        Dim StartPos, SecondPos, LastPos, TargetPos, MaxPos As Tool.ToolPoint
        Dim ZMoveMaxPower As Double
        Dim StartJump As Boolean = False
        Dim JumpZCount As Int16 = 0
        Dim AlignementTime As Date = Now
        ContorlChange(MainForm.TxtSpanTime, 0)
        Dim IterationCount As Int16 = 0
        '寻找空间坐标第一个点
        AddRunLog("开始第一次爬山")
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        AddRunLog("第一次爬山结束")
        StartPos.X = IMC._IMCCardInformation(0).Postion
        StartPos.Y = IMC._IMCCardInformation(1).Postion
        'OneAxisSearch(0, StartPos.X, 0)
        'OneAxisSearch(1, StartPos.Y, 0)
        StartPos.Z = IMC._IMCCardInformation(2).Postion
        '已找到空间直线第一个点 StartPos
        AddRunLog("第一个值：" & StartPos.ToString)
        AddRunLog("Z轴往前推100um")
        'Z轴往前推100um，然后寻找空间直线第二点
        Dim ZStep As Double = -100
        Dim PerPowerValue As Double = 0
        Dim AfterPowerValue As Double = 0
        Dim PowerDelta As Double = 0.6
        Dim DelayTime As Double = 5
        IMC.MoveVel(2, ZStep)
        Do
            If IMC._IMCCardInformation(2).MotionDone Then
                Exit Do
            End If
        Loop
        AddRunLog("Z轴完成动作")
        AddRunLog("第二次爬山开始")
        obj._Picth = 4
        IterationCount = 0
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        SecondPos.X = IMC._IMCCardInformation(0).Postion
        SecondPos.Y = IMC._IMCCardInformation(1).Postion
        SecondPos.Z = IMC._IMCCardInformation(2).Postion
        AddRunLog("第二次爬山结束")
        AddRunLog("第二个值：" & SecondPos.ToString)
        '已找到第二点
        '创建第一个坐标系
        MathTool.CreatTool(StartPos, SecondPos)
        AddRunLog("KX：" & MathTool.KX)
        AddRunLog("KY;" & MathTool.kY)
        AddRunLog("开始寻找第三个点")
        '寻找第三个点
        ZStep = -5
        Do
            GetChannelData(0, PerPowerValue)
            AddRunLog("开始动Z轴Step为-5um之前的光亮为：" & PerPowerValue)
            IMC.MoveVel(2, ZStep)
            Dim CurrentPos As Tool.ToolPoint
            MathTool.OffSetXY(ZStep, CurrentPos)
            AddRunLog("开始动Z轴Step为-5um,X补偿为：" & CurrentPos.X & "Y补偿为：" & CurrentPos.Y)
            IMC.MoveVel(1, CurrentPos.Y)
            IMC.MoveVel(0, CurrentPos.X)
            Do
                If IMC._IMCCardInformation(2).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(0, AfterPowerValue)
            AddRunLog("开始动Z轴Step为-5um之后的光亮为：" & AfterPowerValue)
            If AfterPowerValue < PerPowerValue Then
                If StartJump = False Then

                    ZMoveMaxPower = PerPowerValue
                    AddRunLog("开始动Z轴Step为-5um,第一次出现下降，此时功率最大为" & ZMoveMaxPower)
                End If
                StartJump = True
            Else
                System.Threading.Thread.Sleep(DelayTime)

                ZMoveMaxPower = AfterPowerValue
                AddRunLog("开始动Z轴Step为-5um,上升，此时功率最大为" & ZMoveMaxPower)
                StartJump = False
            End If
            Dim Pos As Double = IMC._IMCCardInformation(2).Postion
            If Pos < ZeroPoint Then
                If AfterPowerValue <= -20 Then
                    AddRunLog("开始动Z轴Step为-5um,下降，此时功率最大为" & ZMoveMaxPower)
                    AddRunLog("开始动Z轴Step为-5um,下降，此时功率最小为" & AfterPowerValue)
                    StartJump = True
                    Exit Do
                End If
            Else
                Exit Do
            End If

        Loop
        StartJump = False
        AddRunLog("开始爬山")
        obj._Picth = 4
        IterationCount = 0
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        AddRunLog("结束爬山")
        LastPos.X = IMC._IMCCardInformation(0).Postion
        LastPos.Y = IMC._IMCCardInformation(1).Postion
        LastPos.Z = IMC._IMCCardInformation(2).Postion
        AddRunLog("第三次值" & LastPos.ToString)
        MathTool.CreatTool(StartPos, LastPos)
        AddRunLog("KX:" & MathTool.KX)
        AddRunLog("KY:" & MathTool.kY)

        System.Threading.Thread.Sleep(DelayTime)
        Dim ZCurrentPos As Double = IMC._IMCCardInformation(2).Postion
        ZStep = ZeroPoint - ZCurrentPos
        AddRunLog("Z轴开始走" & ZStep)
        Dim CurrentPos1 As Tool.ToolPoint
        IMC.MoveVel(2, ZStep)
        MathTool.OffSetXY(ZStep, CurrentPos1)
        AddRunLog("开始动Z轴Step为-5um,X补偿为：" & CurrentPos1.X & "Y补偿为：" & CurrentPos1.Y)
        IMC.MoveVel(1, CurrentPos1.Y)
        IMC.MoveVel(0, CurrentPos1.X)
        System.Threading.Thread.Sleep(DelayTime)
        Dim power As Double
        GetChannelData(0, power)
        AddRunLog("Power：" & power)
        AddRunLog("开始最后一次爬山")
        System.Threading.Thread.Sleep(DelayTime)
        obj._Picth = 4
        IterationCount = 0
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While

        IterationCount = 0
        System.Threading.Thread.Sleep(DelayTime)
        Dim Xpicth As Double = 0.1
        Dim Ypicth As Double = 0.1
        Dim Zpicth As Double = 1
        While True
            AddRunLog("开始第一次三周")
again:
            obj._AxisNo.Clear()
            obj._AxisNo.Add(2)
            obj._AxisNo.Add(0)
            obj._AxisNo.Add(1)

            For i As Int16 = 0 To obj._AxisNo.Count - 1
                If i = 0 Then
                    obj._Picth = Zpicth
                End If
                If i = 1 Then
                    obj._Picth = Xpicth
                End If
                If i = 2 Then
                    obj._Picth = Xpicth
                End If
                System.Threading.Thread.Sleep(DelayTime)
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
                System.Threading.Thread.Sleep(DelayTime)
            Next
            If CheckAxisIsSetOK(2, 0) = False Then
                GoTo again
            End If
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While
        obj._Picth = 0.8
        IterationCount = 0
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While

        If CheckAxisIsSetOK(2, 0) = False Then
            AddRunLog("开始第er次三周")
            obj._AxisNo.Clear()
            obj._AxisNo.Add(2)
            obj._AxisNo.Add(0)
            obj._AxisNo.Add(1)
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                If i = 0 Then
                    obj._Picth = 1
                End If
                If i = 1 Then
                    obj._Picth = 0.1
                End If
                If i = 2 Then
                    obj._Picth = 0.1
                End If
                System.Threading.Thread.Sleep(DelayTime)
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
                System.Threading.Thread.Sleep(DelayTime)
            Next
        End If

        CheckAxisIsSetOK(2, 0)
        'ContorlChange(MainForm.ListBox1, "开始第er次三周")
        'obj._AxisNo.Clear()
        'obj._AxisNo.Add(2)
        'obj._AxisNo.Add(0)
        'obj._AxisNo.Add(1)
        'For i As Int16 = 0 To obj._AxisNo.Count - 1
        '    If i = 0 Then
        '        obj._Picth = 1
        '    End If
        '    If i = 1 Then
        '        obj._Picth = 0.1
        '    End If
        '    If i = 2 Then
        '        obj._Picth = 0.1
        '    End If
        '    System.Threading.Thread.Sleep(DelayTime)
        '    OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
        '    System.Threading.Thread.Sleep(DelayTime)
        'Next
        Dim a As Double = IMC._IMCCardInformation(2).Postion

        AddRunLog("Z轴当前位置：" & a)
        obj._Picth = 0.8
        obj._AxisNo.Clear()
        obj._AxisNo.Add(0)
        obj._AxisNo.Add(1)
        IterationCount = 0
        While True
            For i As Int16 = 0 To obj._AxisNo.Count - 1
                OneAxisAlignment(obj._AxisNo(i), obj._Picth, obj._PicthCount, obj._Delta, obj._Channel)
            Next
            If IterationCount < obj._IretCount - 1 Then
                IterationCount = IterationCount + 1
                obj._Picth = obj._Picth * 0.5
            Else
                Exit While
            End If
        End While

        'ClearMotoGap(0, 0)
        'ClearMotoGap(1, 0)
        AddRunLog("结束最后一次爬山")

        ContorlChange(MainForm.TxtSpanTime, Now.Subtract(AlignementTime).TotalSeconds)
        IsTimerRefreshData = True
    End Sub
    ' 
    ' 用于插补函数
    ' 
    Public Function CheckAxisIsSetOK(ByVal AxisIndex As Int16, ByVal Channel As Int16) As Boolean
        Dim DelayTime As Double = 5
        System.Threading.Thread.Sleep(DelayTime)
        Dim AxisStep As Double = -1
        Dim PerPowerValue, AfterPowerValue, MaxPower As TargetDataOne
        Dim JumpCount As Int16 = 0
        Dim Falg As Boolean = False
        Dim CheckCount As Int16 = 4
        Dim CheckCountRaise As Int16 = 4
        Dim RaiseCount As Int16 = 0
        GetChannelData(Channel, MaxPower.power)
        MaxPower.pos = IMC._IMCCardInformation(AxisIndex).Postion
        Do

            GetChannelData(Channel, PerPowerValue.power)
            PerPowerValue.pos = IMC._IMCCardInformation(AxisIndex).Postion
            IMC.MoveVel(AxisIndex, AxisStep)
            Do
                If IMC._IMCCardInformation(AxisIndex).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(DelayTime)
            GetChannelData(Channel, AfterPowerValue.power)
            AfterPowerValue.pos = IMC._IMCCardInformation(AxisIndex).Postion
            If AfterPowerValue.power > PerPowerValue.power Then
                If AfterPowerValue.power > MaxPower.power Then
                    AddRunLog("Z轴最大值Pos：" & MaxPower.pos)
                    MaxPower = AfterPowerValue
                End If

            End If
            If Math.Abs(AfterPowerValue.power - MaxPower.power) < 0.02 Then
                JumpCount = 0
                RaiseCount = RaiseCount + 1
                If RaiseCount > CheckCountRaise Then
                    Exit Do
                End If
                Falg = False
            Else
                JumpCount = JumpCount + 1
                RaiseCount = 0
                If JumpCount > CheckCount Then
                    Falg = True
                    System.Threading.Thread.Sleep(0)
                    Exit Do
                End If
            End If
        Loop

        System.Threading.Thread.Sleep(1)
again:
        Dim Staus As IMC_STATUS = IMC.MoveAbs(AxisIndex, MaxPower.pos)
        Do
            If IMC._IMCCardInformation(AxisIndex).MotionDone Then
                Exit Do
            End If
        Loop
        System.Threading.Thread.Sleep(0)
        AddRunLog(Staus.ToString)
        If Staus <> IMC_STATUS.IMC_OK Then
            AddRunLog(Staus.ToString)
            GoTo again
        End If
        AddRunLog("Z轴最小值Pos：" & AfterPowerValue.pos)
        AddRunLog("Z轴停止时最大值：" & MaxPower.power)
        AddRunLog("Z轴停止时最小值：" & AfterPowerValue.power)


        Return Falg
    End Function

    '
    ' 
    '
    Public Sub OneAxisSearch(ByVal Axis As Int16, ByRef MaxValuePos As Double, ByVal Channel As Int16)
        Dim CurrentInfo, TargetInfo, MaxInfo As TargetDataOne
        Dim Index As Int16
        Dim DelayTime As Double = 5
        CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
        GetChannelData(Channel, CurrentInfo.power)
        MaxInfo = CurrentInfo
        For i As Int16 = 1 To 5
            IMC.MoveVel(Axis, 1)
            Do
                If IMC._IMCCardInformation(Axis).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(Channel, CurrentInfo.power)
            If CurrentInfo.power > MaxInfo.power Then
                Index = i
                MaxInfo = CurrentInfo
            End If
        Next
        For i As Int16 = 1 To 10
            IMC.MoveVel(Axis, -1)
            Do
                If IMC._IMCCardInformation(Axis).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(Channel, CurrentInfo.power)
            If CurrentInfo.power > MaxInfo.power Then
                Index = i
                MaxInfo = CurrentInfo
            End If
        Next
        For i As Int16 = 1 To Index
            IMC.MoveVel(Axis, 1)
            Do
                If IMC._IMCCardInformation(Axis).MotionDone Then
                    Exit Do
                End If
            Loop
        Next
        System.Threading.Thread.Sleep(DelayTime)
        MaxValuePos = IMC._IMCCardInformation(Axis).Postion
    End Sub

    '
    '
    '
    Public Sub ClearMotoGap(ByVal AxisIndex As Int16, ByVal Channel As Int16)
        Dim CurrentInfo, TargetInfo, MaxInfo_Pos, MaxInfo_Neg As TargetDataOne
        Dim index, direc As Int16
        Dim dstep As Double = -0.1
        GetChannelData(Channel, CurrentInfo.power)
        MaxInfo_Pos.power = CurrentInfo.power
        CurrentInfo.pos = IMC._IMCCardInformation(AxisIndex).Postion
        direc = 1
again:
        For i As Int16 = 1 To 10
            IMC.MoveVel(AxisIndex, dstep)
            Do
                If IMC._IMCCardInformation(AxisIndex).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(Channel, CurrentInfo.power)
            If CurrentInfo.power > MaxInfo_Pos.power Then
                MaxInfo_Pos.power = CurrentInfo.power
                i = 1
                AddRunLog(MaxInfo_Pos.power)
            End If
        Next

        For i As Int16 = 1 To 20
            IMC.MoveVel(AxisIndex, -dstep)
            Do
                If IMC._IMCCardInformation(AxisIndex).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(Channel, CurrentInfo.power)
            If CurrentInfo.power > MaxInfo_Neg.power Then
                MaxInfo_Neg = CurrentInfo
                AddRunLog(MaxInfo_Pos.power)
                i = 1
            End If
        Next

        For i As Int16 = 1 To 20
            IMC.MoveVel(AxisIndex, dstep)
            Do
                If IMC._IMCCardInformation(AxisIndex).MotionDone Then
                    Exit Do
                End If
            Loop
            GetChannelData(Channel, CurrentInfo.power)
            If Math.Abs(CurrentInfo.power - MaxInfo_Neg.power) < 0.02 OrElse Math.Abs(CurrentInfo.power - MaxInfo_Pos.power) < 0.02 Then
                Exit Sub

            End If
        Next
        dstep = -dstep
        GoTo again

        '精确找X的位置
    End Sub
#End Region
    'w 
#Region "转胶水"
    Public Sub 转胶水(AxisRoation As Integer, AxisSensor As Integer, AxisSensorStartPos As Double, AxisRoationSpeed As SpeedMode, AxisSensorDeltaPos As Double, AxisSensorPicth As Double)
        Dim CurrentInfo As TargetDataOne
        Dim dstep As Integer = 180

        Dim AbsStep As Integer = 180
        CurrentInfo.pos = IMC._IMCCardInformation(AxisRoation).Postion

        If AxisRoationSpeed = SpeedMode.SlowSpeed Then
            IMC.SetVelDown(AxisRoation)
        Else
            IMC.SetVelAcc(AxisRoation)
        End If
        IMC.MoveAbs(AxisSensor, AxisSensorStartPos)
        System.Threading.Thread.Sleep(10)
        While True
            CurrentInfo.Pos1 = IMC._IMCCardInformation(AxisSensor).Postion
            If Math.Abs(Math.Abs(Val(CurrentInfo.Pos1)) - Math.Abs(AxisSensorStartPos)) < 1 Then
                Exit While
            End If
        End While
        System.Threading.Thread.Sleep(10)
        CurrentInfo.Pos1 = IMC._IMCCardInformation(AxisSensor).Postion
        Do
            Dim Pos As String = IMC._IMCCardInformation(AxisSensor).Postion
            If AxisSensorStartPos - Val(IMC._IMCCardInformation(AxisSensor).Postion) > AxisSensorDeltaPos Then
                Exit Do
            End If
            IMC.MoveVel(AxisSensor, -AxisSensorPicth)
            IMC.MoveVel(AxisRoation, AbsStep)
            While True
                System.Threading.Thread.Sleep(2)
                If IMC._IMCCardInformation(AxisRoation).MotionDone Then
                    Exit While
                End If
            End While
            System.Threading.Thread.Sleep(2)
            IMC.MoveAbs(AxisRoation, CurrentInfo.pos)
            While True
                System.Threading.Thread.Sleep(2)
                If IMC._IMCCardInformation(AxisRoation).MotionDone Then
                    Exit While
                End If
            End While
            AbsStep = -AbsStep
        Loop
        IMC.MoveAbs(AxisRoation, CurrentInfo.pos)
        While True
            System.Threading.Thread.Sleep(20)
            If IMC._IMCCardInformation(AxisRoation).MotionDone Then
                Exit While
            End If
        End While
    End Sub
#End Region

#Region "复位流程"
    ' 
    '  按照复位流程开始执行
    ' 
    Public Sub ResetFlowRun()
        If ProductPara.ResetFlowFilw = "" Then MessageBox.Show("无复位流程") : Return
        If IO.File.Exists(ProductPara.ResetFlowFilw) = False Then MessageBox.Show("无复位流程") : Return
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(CurrentFlow, New UserFlow, ProductPara.ResetFlowFilw) = False Then Return
        If CurrentFlow.FunctionList.Count > 0 Then
            For i As Int16 = 0 To CurrentFlow.FunctionList.Count - 1
                StepToStepThread(CurrentFlow.FunctionList(i).FunctionName, i)
            Next
        End If
        CurrentFlow = New UserFlow
    End Sub
#End Region

#Region "寻找光的零界点"
    Public Sub SaveLogFile(Msg As String)
        Dim SaveFile As Boolean = False
        IO.File.AppendAllText(Application.StartupPath & "\log.txt", Msg)
    End Sub
    '
    ' 功能模块： 测试 LightTest
    ' 寻找光点的零界点
    ' min = 补偿offset、 max=最大偏移
    Public Function SearchLightLimit(ByVal Axis As Int16, ByVal dStep As Double, ByVal PowerDelta As Single, ByVal channel As Int16, ByVal MinValue As Double, Optional ByVal MaxValue As Double = 0.9) As Boolean
        Dim FrisInfo, CurrentInfo, Maxinfo, MinInfo, DoubleCheckPerInfo As TargetDataOne
        Dim PosStep As Double = -dStep
        Dim NegStep As Double = dStep / dStep   ' un
        Dim CheckCount As Int16 = 5
        Dim Count As Int16 = 0                  ' un
        Dim CkPower As Double                   ' un
        FrisInfo.pos = IMC._IMCCardInformation(Axis).Postion
        ContorlChange(MainForm.TextBox24, FrisInfo.pos)
        ContorlChange(MainForm.TextBox23, 0)
        GetChannelData(channel, FrisInfo.power)

        Dim str As String = ""
        FrisInfo.power = ConvertdbmToPower(FrisInfo.power, str)
        Select Case str.ToUpper
            Case "W"
                FrisInfo.power = FrisInfo.power * 1000
            Case "UW"
                FrisInfo.power = FrisInfo.power / 1000
        End Select
        MainForm.AddTrackMsg("光临界点开始功率：" & FrisInfo.power)
        While True
            If EStop = True Then GoTo EStopFlow
            '++++++++++++++++++++++++++++++++++++++++++++++

            '++++++++++++++++++++++++
            '判断Power是否达标
            System.Threading.Thread.Sleep(100)
            GetChannelData(channel, CurrentInfo.power)

            CurrentInfo.power = ConvertdbmToPower(CurrentInfo.power, str)
            Select Case str.ToUpper
                Case "W"
                    CurrentInfo.power = CurrentInfo.power * 1000
                Case "UW"
                    CurrentInfo.power = CurrentInfo.power / 1000
            End Select
            If (FrisInfo.power - CurrentInfo.power) >= PowerDelta Then
                MainForm.AddTrackMsg("光临界点结束功率：" & CurrentInfo.power)
                If EStop = True Then GoTo EStopFlow
                System.Threading.Thread.Sleep(10)
                Do
                    If IMC._IMCCardInformation(Axis).MotionDone Then
                        Exit Do
                    End If
                Loop
                System.Threading.Thread.Sleep(10)
                CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                'ContorlChange(MainForm.Button23, "测试")
                IsTimerRefreshData = True

                If (FrisInfo.power - CurrentInfo.power) >= PowerDelta * 2 Then
                    While True
                        System.Threading.Thread.Sleep(100)
                        GetChannelData(channel, CurrentInfo.power)
                        CurrentInfo.power = ConvertdbmToPower(CurrentInfo.power, str)
                        Select Case str.ToUpper
                            Case "W"
                                FrisInfo.power = CurrentInfo.power * 1000
                            Case "UW"
                                FrisInfo.power = CurrentInfo.power / 1000
                        End Select
                        If (FrisInfo.power - CurrentInfo.power) >= PowerDelta * 0.9 AndAlso (FrisInfo.power - CurrentInfo.power) < PowerDelta * 1.2 Then
                            GoTo EStopFlow
                            Exit While
                        End If
                        '++++++++++++++++++++++++++++++++++++++++++==
                        '安全保护
                        CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion
                        If Math.Abs(CurrentInfo.pos - FrisInfo.pos) > MaxValue Then
                            IMC.MoveAbs(Axis, FrisInfo.pos + MinValue)
                            MainForm.AddTrackMsg("超出偏移行程")
                            System.Threading.Thread.Sleep(25)
                            Do
                                If IMC._IMCCardInformation(Axis).MotionDone Then
                                    Exit Do
                                End If
                            Loop
                            System.Threading.Thread.Sleep(10)
                            GoTo EStopFlow
                            Exit While

                        End If
                        '+++++++++++++++++++++++++++++++++++
                        IMC.MoveVel(Axis, -PosStep)
                        System.Threading.Thread.Sleep(10)
                        Do
                            If IMC._IMCCardInformation(Axis).MotionDone Then
                                Exit Do
                            End If
                        Loop
                    End While

                End If
                GoTo EStopFlow
                Exit While
            End If
            '++++++++++++++++++++++++
            '+++++++++++++++++++++++++++++++++++++++++
            '往下走PosStep
            IMC.MoveVel(Axis, PosStep)
            System.Threading.Thread.Sleep(10)
            Do
                If IMC._IMCCardInformation(Axis).MotionDone Then
                    Exit Do
                End If
            Loop
            System.Threading.Thread.Sleep(10)
            CurrentInfo.pos = IMC._IMCCardInformation(Axis).Postion


            '++++++++++++++++++++++++++++++++++++++++++==
            '安全保护
            If Math.Abs(CurrentInfo.pos - FrisInfo.pos) > MaxValue Then
                IMC.MoveAbs(Axis, FrisInfo.pos + MinValue)
                MainForm.AddTrackMsg("超出偏移行程")
                System.Threading.Thread.Sleep(10)
                Do
                    If IMC._IMCCardInformation(Axis).MotionDone Then
                        Exit Do
                    End If
                Loop
                System.Threading.Thread.Sleep(10)
                GoTo EStopFlow
                Exit While

            End If
            '+++++++++++++++++++++++++++++++++++
        End While
EStopFlow:
        System.Threading.Thread.Sleep(10)
        ContorlChange(MainForm.TextBox23, CurrentInfo.pos - FrisInfo.pos)
        ContorlChange(MainForm.Button23, "测试")
        IsTimerRefreshData = True
    End Function
#End Region

End Module
'
' 产线耗时信息 {生产时间、花费实际那、指标、回损、 错误消息}
Public Class PRODUCTINLINEINFO
    Public Property 生产时间 As Date
    Public Property 总的花费时间 As String
    Public Property 指标 As String
    Public Property 回损 As String
    Public Property ErrorMessage As String
    Public Overrides Function ToString() As String
        Return 生产时间 & "," & 总的花费时间 & "," & 指标 & "," & 回损 & "," & ErrorMessage & vbNewLine
    End Function
End Class
Public Class MysqlInfor

    Public _器件序列号 As String = ""    '器件序列号 | 组装通道号？
    Public 反射镜批次 As String = ""
    Public 胶水批次 As String = ""
    Public 胶水型号 As String = ""
    Public 胶水打开时间 As String = ""
    Public 烘烤开始时间 As String = ""
    Public 烘烤结束时间 As String = ""
    Public COSValue As String = ""
    Public 操作者 As String = ""
    Public 操作时间 As String = ""
    Public 不良类型 As String = ""
    Public 工序状态 As String = ""
    Public 工位机台号 As String = ""
    Public 备注 As String = ""

    ' 带cos值得数据行 记录
    Public Function FormatToString()
        Return _器件序列号 & "," & 反射镜批次 & "," & 胶水批次 & "," & 胶水型号 & "," & 胶水打开时间 & "," & 烘烤开始时间 & "," & 烘烤结束时间 & "," & COSValue & "," & 操作者 & "," & 操作时间 & "," & 不良类型 & "," & 工序状态 & "," & 工位机台号 & "," & 备注
    End Function
    ' 列头1
    Public Function FormatNameToString1()
        Return "器件序列号" & "," & "反射镜批次" & "," & "胶水批次" & "," & "胶水型号" & "," & "胶水打开时间" & "," & "烘烤开始时间" & "," & "烘烤结束时间"
    End Function
    ' 列头2
    Public Function FormatNameToStrin2()
        Return "操作者" & "," & "操作时间" & "," & "不良类型" & "," & "工序状态" & "," & "工位机台号" & "," & "备注"
    End Function
End Class