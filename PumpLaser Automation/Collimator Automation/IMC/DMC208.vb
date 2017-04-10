Imports System.Threading.Thread
Imports System.Threading
Imports PumpLaser_Automation

Public Class cXYZU
    Implements IDisposable
    Implements InterfaceHandle

#Region "DMC"
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                          DMC2410B V1.0 函数列表                           ''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''          初始化函数                      '''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Declare Function d2410_board_init Lib "DMC2410.dll" () As Int16
    Declare Sub d2410_board_close Lib "DMC2410.dll" ()

    '脉冲输入输出配置
    Declare Sub d2410_set_pulse_outmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal outmode As Int16)
    Declare Sub d2410_counter_config Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16)

    '速度设置
    Declare Sub d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2410_set_s_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
    Declare Sub d2410_set_st_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)
    Declare Sub d2410_set_vector_profile Lib "DMC2410.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2410_change_speed Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Curr_Vel As Double)
    Declare Function d2410_read_current_speed Lib "DMC2410.dll" (ByVal axis As Int16) As Double
    Declare Sub d2410_variety_speed_range Lib "DMC2410.dll" (ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)

    '制动函数
    Declare Sub d2410_decel_stop Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Tdec As Double)
    Declare Sub d2410_imd_stop Lib "DMC2410.dll" (ByVal axis As Int16)
    Declare Sub d2410_emg_stop Lib "DMC2410.dll" ()

    '单轴位置控制函数
    Declare Sub d2410_t_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal dir As Int16)
    Declare Sub d2410_s_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal dir As Int16)

    Declare Sub d2410_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_ex_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_ex_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)

    '线性插补
    Declare Sub d2410_t_line2 Lib "DMC2410.dll" (ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_t_line3 Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_t_line4 Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)


    '圆弧插补
    Declare Sub d2410_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
    Declare Sub d2410_rel_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)

    '找原点
    Declare Sub d2410_config_home_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
    Declare Sub d2410_home_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    '手轮运动
    Declare Sub d2410_set_handwheel_inmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
    Declare Sub d2410_handwheel_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal vh As Double)


    '状态检测函数
    Declare Function d2410_check_done Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_prebuff_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_axis_io_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_axis_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_get_rsts Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    '专用信号设置函数
    Declare Sub d2410_config_SD_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
    Declare Sub d2410_config_PCS_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
    Declare Sub d2410_config_INP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
    Declare Sub d2410_config_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
    Declare Sub d2410_config_ALM_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
    Declare Sub d2410_config_EL_MODE Lib "DMC2410.dll" (ByVal axis As Int16, ByVal el_mode As Int16)
    Declare Sub d2410_set_HOME_pin_logic Lib "DMC2410.dll" (ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    Declare Function d2410_read_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_write_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal on_off As Int16)
    Declare Function d2410_read_RDY_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_write_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sel As Int16)
    Declare Sub d2410_config_EMG_PIN Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)

    '位置设置和读取函数
    Declare Function d2410_get_position Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_set_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal current_position As Int32)
    Declare Sub d2410_reset_target_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32)


    '增加位置比较输出功能
    Declare Function d2410_compare_config Lib "DMC2410.dll" (ByVal card As Int16, ByVal enable As Int16, ByVal axis As Int16, ByVal cmp_source As Int16) As Int32
    Declare Function d2410_compare_get_config Lib "DMC2410.dll" (ByVal card As Int16, ByVal enable As Int16, ByVal axis As Int16, ByVal cmp_source As Int16) As Int32
    Declare Function d2410_compare_clear_points Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_compare_add_point Lib "DMC2410.dll" (ByVal card As Int16, ByVal pos As Int32, ByVal dir As Int16, ByVal action As Int16, ByVal actpara As Int32) As Int32
    Declare Function d2410_compare_get_current_point Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_compare_get_points_runned Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_compare_get_points_remained Lib "DMC2410.dll" (ByVal card As Int16) As Int32


    '' 连续插补函数
    Declare Function d2410_conti_lines Lib "DMC2410.dll" (ByVal axisNum As Int16, ByVal piaxisList As Int16, ByVal pPosList As Int32, ByVal posi_mode As Int16) As Int32
    Declare Function d2410_conti_restrain_speed Lib "DMC2410.dll" (ByVal card As Int16, ByVal v As Double) As Int32
    Declare Function d2410_conti_get_current_speed_ratio Lib "DMC2410.dll" (ByVal card As Int16) As Int32

    Declare Function d2410_conti_set_mode Lib "DMC2410.dll" (ByVal card As Int16, ByVal conti_mode As Int16, ByVal conti_vl As Double, ByVal conti_para As Double, ByVal filter As Double) As Int32
    Declare Function d2410_conti_get_mode Lib "DMC2410.dll" (ByVal card As Int16, ByVal conti_mode As Int16, ByVal conti_vl As Double, ByVal conti_para As Double, ByVal filter As Double) As Int32

    Declare Function d2410_conti_open_list Lib "DMC2410.dll" (ByVal axisNum As Int16, ByVal piaxisList As Int16) As Int32
    Declare Function d2410_conti_close_list Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_conti_check_remain_space Lib "DMC2410.dll" (ByVal card As Int16) As Int32

    Declare Function d2410_conti_decel_stop_list Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_conti_sudden_stop_list Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_conti_pause_list Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_conti_start_list Lib "DMC2410.dll" (ByVal card As Int16) As Int32


    '通用输入/输出控制函数
    Declare Function d2410_read_inbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Sub d2410_write_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
    Declare Function d2410_read_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Function d2410_read_inport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_read_outport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Sub d2410_write_outport Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Port_Value As Int32)


    '//---------------------   编码器计数功能PLD  ----------------------//
    Declare Function d2410_get_encoder Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_set_encoder Lib "DMC2410.dll" (ByVal axis As Int16, ByVal encoder_value As Int32)

    Declare Sub d2410_config_LTC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)

    Declare Function d2410_get_latch_value Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    Declare Function d2410_get_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2410_reset_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Declare Function d2410_get_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2410_reset_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Declare Sub d2410_reset_clear_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    '//---------------------   DMC2410编码器计数新加功能 ----------------------//
    Declare Sub d2410_config_EZ_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    Declare Sub d2410_config_latch_mode Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal all_enable As Int16)

    Declare Sub d2410_triger_chunnel Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal num As Int16)

    Declare Sub d2410_set_speaker_logic Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal logic As Int16)


    Declare Sub d2410_config_LTC_filter Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)
    Declare Sub d2410_config_encoder_filter Lib "DMC2410.dll" (ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)

    '//脉冲当量设置
    Declare Function d2410_get_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByRef equiv As Double) As Int32
    Declare Function d2410_set_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByVal new_equiv As Double) As Int32

    Declare Function d2410_get_position_unitmm Lib "DMC2410.dll" (ByVal axis As Int16, ByRef pos_by_mm As Double) As Int32
    Declare Function d2410_set_position_unitmm Lib "DMC2410.dll" (ByVal axis As Int16, ByVal pos_by_mm As Double) As Int32
    Declare Function d2410_read_current_speed_unitmm Lib "DMC2410.dll" (ByVal axis As Int16, ByRef current_speed As Double) As Int32

    Declare Function d2410_get_encoder_unitmm Lib "DMC2410.dll" (ByVal axis As Int16, ByRef encoder_pos_by_mm As Double) As Int32
    Declare Function d2410_set_encoder_unitmm Lib "DMC2410.dll" (ByVal axis As Int16, ByVal encoder_pos_by_mm As Double) As Int32

    Declare Sub d2410_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
    Declare Sub d2410_rel_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)

    Declare Function d2410_pulse_loop Lib "DMC2410.dll" (ByVal axis As Int16) As Int32


    '多卡运行
    Declare Function d2410_set_t_move_all Lib "DMC2410.dll" (ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
    Declare Function d2410_start_move_all Lib "DMC2410.dll" (ByVal FirstAxis As Int16) As Int32
    Declare Sub d2410_simultaneous_stop Lib "DMC2410.dll" (ByVal axis As Int16)
    Declare Function d2410_set_sync_option Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
    Declare Function d2410_set_sync_stop_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
    Declare Function d2410_config_CSTA_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal edge_mode As Int16) As Int32


    ''函数参数必须严格保持一致性

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                          DMC2410B V1.0 end of module                       '''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#End Region
    Private Enum Rst_Do As Integer
        CSD = 4 '表示同时减速信号（CSD）为  ON;0:为 OFF（DMC2410B 没有此功能）
        STA = 5 '表示同时启动信号（STA）为  ON（DMC2410B 没有此功能）
        STP = 6 '表示同时停止信号（STP）为  ON（DMC2410B 没有此功能）
        EMG = 7 '表示紧急停止信号（EMG）为  ON 
        PCS = 8 '表示  PCS  信号为  ON（DMC2410B 没有此功能）
        ERC = 9 '表示误差清除信号（ERC）为  ON
        EZ = 10 '表示索引信号（EZ）为  ON
        PDR = 11 '表示  +DR(PA)  信号为  ON
        MDP = 12 '表示  -DR(PB)  信号为  ON
        SD = 14 '表示  SD  信号为  ON
        INP = 15 '表示到位信号  INP  为  ON
        DIR = 16 '脉冲输出方向(0：表示正方向；1：表示负方向） （DMC2410B 没有此功能)
    End Enum
    Public Enum AxisIO As Integer
        'Do
        EMG = 0 '表示紧急停止信号（EMG）为  ON 
        ERC = 1 '表示误差清除信号（ERC）为  ON
        EZ = 2 '表示索引信号（EZ）为  ON
        PDR = 3 '表示  +DR(PA)  信号为  ON
        MDP = 4 '表示  -DR(PB)  信号为  ON
        Out_SD = 5 '表示  SD  信号为  ON
        INP = 6 '表示到位信号  INP  为  ON
        DIR = 7 '脉冲输出方向(0：表示正方向；1：表示负方向） （DMC2410B 没有此功能)
        'DI
        FU = 8 '正在加速
        FD = 9 '正在减速
        FC = 10 '低速运行中
        ALM = 11 '伺服报警
        PEL = 12 '正限位信号
        MEL = 13 '负限位信号
        ORG = 14 '原点信号
        In_SD = 15 '减速信号
        '伺服 
        MoveDone = 16 '静止
        Sevon = 17
        RDY = 18
    End Enum
    Private _IsPauseThread As Boolean = False
    Private DataRefreshThread As Threading.Thread
    Private _AxIO(3)() As Boolean
    Private OutStatus() As Boolean
    Private InPutSataus() As Boolean
    Public Sub RefreshData()
        While True
            If _IsPauseThread = False Then
                For i As Integer = 0 To 4 - 1
                    Dim ReadIO As Integer = d2410_axis_io_status(i)
                    Dim _ReadIO() As Boolean = Ch10_2(ReadIO)
                    _IMCCardInformation(i).Postion = GetCurrentPos(i)
                    _IMCCardInformation(i).Org = _ReadIO(14)
                    _IMCCardInformation(i).PLM = _ReadIO(12)
                    _IMCCardInformation(i).NLM = _ReadIO(13)
                    _IMCCardInformation(i).ErrorMessage = IIf(_ReadIO(11), "马达报警", "None")
                    _IMCCardInformation(i).MotionDone = MoveDone(i)
                Next
            End If

        End While
    End Sub
    ''' <summary>
    ''' 网卡的讯息
    ''' </summary>
    ''' <remarks></remarks>
    Public _NetCardInformation As New List(Of NetCardInforMation)
    ''' <summary>
    ''' IMC卡的讯息
    ''' </summary>
    ''' <remarks></remarks>
    Public _IMCCardInformation As New List(Of IMCCardInforMation)
    ''' <summary>
    ''' Search NetCard
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchNet() As Boolean Implements InterfaceHandle.SearchNet
        Dim status As Integer
        _NetCardInformation.Clear()
        status = d2410_board_init
        If status = 0 Then MessageBox.Show("没有找到驱动卡！", "Alrm", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning) : Return False
        For i As Integer = 0 To status - 1
            Dim net As New NetCardInforMation
            net.CardInfor = "DMC2410"
            net.CardID = i + 1
            _NetCardInformation.Add(net)
        Next i
        Return True
    End Function
    ''' <summary>
    ''' 打开设备
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenDev() Implements InterfaceHandle.OpenDev
        For i As Int16 = 0 To _NetCardInformation.Count - 1
            SearchDev(_NetCardInformation.Item(i).CardID)
        Next
    End Sub
    ''' <summary>
    ''' 搜索对应网卡的IMC
    ''' </summary>
    ''' <param name="NetCardId"></param>
    ''' <remarks></remarks>
    Private Sub SearchDev(ByVal NetCardId As Integer) Implements InterfaceHandle.SearchDev

        For id As Integer = 0 To 3
            Dim IMCCard As New IMCCardInforMation
            IMCCard.CardID = id
            IMCCard.AxisNo = id
            IMCCard.IsOpen = True
            IMCCard.IsOpen = True
            _IMCCardInformation.Add(IMCCard)
        Next id
        DataRefreshThread = New Threading.Thread(New Threading.ThreadStart(AddressOf RefreshData))
        DataRefreshThread.IsBackground = True
        DataRefreshThread.Start()
    End Sub
    Private WithEvents Trm As New System.Windows.Forms.Timer
    ''' <summary>
    ''' 初始化对应轴的参数
    ''' </summary>
    ''' <param name="Axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InitalCard(ByVal AxisNO As Integer) As Boolean Implements InterfaceHandle.InitalCard
        Try
            d2410_set_pulse_outmode(AxisNO, 5)    '设定脉冲输出模式
            'If AxisInitalPara.AxisInitalParameter(AxisNO).aioctrLoc = 0 Then
            '    d2410_config_EL_MODE(AxisNO, 1)  '限位信号设定（减速停低电平有效）
            'Else
            d2410_config_EL_MODE(AxisNO, 0)  '限位信号设定（减速停低电平有效）
            'End If

            d2410_set_HOME_pin_logic(AxisNO, 0, 0) '原点信号低电平有效，禁止滤波功能
            d2410_config_EMG_PIN(0, 1, 0) '卡号0，设置有效，低电平有效
            'd2410_config_EL_MODE(AxisNO, 2)
            '伺服专用参数设定
            d2410_write_SEVON_PIN(AxisNO, 0) 'sevon信号低电平有效
            'd2410_write_SEVON_PIN(AxisNO, 1) 'sevon信号低电平有效
            d2410_config_ALM_PIN(AxisNO, 0, 0) 'ALM信号高电平有效，立即停
            d2410_config_ERC_PIN(AxisNO, 0, 0, 12, 12) '低电平有效，不自动输出，有效输出宽度12us，关断时间12us
            d2410_config_EZ_PIN(AxisNO, 0, 0) '原点EZ信号低电平有效，EZ信号无效
            d2410_counter_config(AxisNO, 3) '非A/B相脉冲
            d2410_config_INP_PIN(AxisNO, 1, 1) 'INP定位信号高电平有效
            d2410_set_profile(AxisNO, AxisInitalPara.AxisInitalParameter(AxisNO).mcstgposLoc, AxisInitalPara.AxisInitalParameter(AxisNO).vellimLoc, AxisInitalPara.AxisInitalParameter(AxisNO).mcsaccelLoc, AxisInitalPara.AxisInitalParameter(AxisNO).mcsdecelLoc)
            'status = IMC_SetParam32(m_handle, vellimLoc, InitalPara.vellimLoc, Axis, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
            'status = IMC_SetParam32(m_handle, mcsmaxvelLoc, InitalPara.mcsmaxvelLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
            'status = IMC_SetParam32(m_handle, mcsaccelLoc, InitalPara.mcsaccelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
            'status = IMC_SetParam32(m_handle, mcstgposLoc, InitalPara.mcstgposLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
            'status = IMC_SetParam32(m_handle, mcsdecelLoc, InitalPara.mcsdecelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
            Return True
        Catch ex As Exception

            Return False
        End Try

        Return True
    End Function
    Public Sub SetVelDown(ByVal Axis As Integer) Implements InterfaceHandle.SetVelDown
        d2410_change_speed(Axis, 50000)
    End Sub
    Public Sub SetVelAcc(ByVal Axis As Integer) Implements InterfaceHandle.SetVelAcc
        d2410_change_speed(Axis, 500000)
    End Sub
    ''' <summary>
    ''' 检测马达是否处于停滞状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveDone(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.MoveDone
        Try
            Dim DelayTime As Date = Now
            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            If AxisInitalPara.AxisInitalParameter(AxisNo).IsNeedMotionDone = True Then
                Dim a As Short
                a = d2410_check_done(AxisNo)
                Return IIf(a = 1, True, False)
            Else
                While True
                    If Now.Subtract(DelayTime).TotalSeconds > 0.05 Then
                        Exit While
                    End If
                End While
            End If

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' Jog
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="VelSpeed"></param>
    ''' <param name="Pos"></param>
    ''' <param name="JogMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function JOG(ByVal AxisNo As Integer, ByVal VelSpeed As Double, ByVal Pos As Integer, ByVal JogMode As Integer) As Boolean Implements InterfaceHandle.JOG
        'If _IMCCardInformation.Count = 0 Then Return False
        'If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        'Dim status As IMC_STATUS
        'Dim StartReadTime As Date = Now

        'While True
        '    If Now.Subtract(StartReadTime).TotalMilliseconds > 2 Then
        '        Exit While
        '    End If
        'End While
        'If JogMode = JogTpye.Speed Then
        '    status = IMC_MoveVelocity(_IMCCardInformation(AxisNo).CardHandle, VelSpeed, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        'Else
        '    status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, Pos, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        'End If
        'If status <> IMC_STATUS.IMC_OK Then Return False
        Return True
    End Function
    Public Enum JogTpye
        Pos
        Speed
    End Enum
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="JogMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StopJog(ByVal AxisNo As Integer, ByVal JogMode As Integer) As Boolean Implements InterfaceHandle.StopJog
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        d2410_decel_stop(AxisNo, 0.1)
        Return True
    End Function
    '''' <summary>
    '''' 对应轴相对位移
    '''' </summary>
    '''' <param name="AxisNo"></param>
    '''' <param name="pos"></param>
    '''' <param name="IntialVel"></param>
    '''' <param name="MaxVel"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function MoveVel(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal IntialVel As Integer = 10000, Optional ByVal MaxVel As Integer = 200000, Optional ByVal Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveVel
    '    If _IMCCardInformation.Count = 0 Then Return False


    '    Dim t As String = ""
    '    Try
    '        d2410_set_profile(AxisNo, IntialVel, MaxVel, 0.5, 0.1)
    '        If AxisNo = 1 Or AxisNo = 0 Then
    '            d2410_set_profile(2, IntialVel, MaxVel, 0.5, 0.1)
    '            d2410_t_pmove(2, 0, 1)
    '            While True
    '                Application.DoEvents()
    '                If MoveDone(2) = True Then
    '                    Exit While
    '                End If
    '            End While
    '        End If
    '        d2410_t_pmove(AxisNo, pos * _IMCCardInformation(AxisNo).Resoulotion, 0)
    '        While True
    '            Application.DoEvents()
    '            If MoveDone(AxisNo) = True Then
    '                Exit While
    '            End If
    '        End While
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    '    Return 0
    'End Function
    ''' <summary>
    ''' 对应轴绝对位移
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="pos"></param>
    ''' <param name="Timeout"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveAbs(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveAbs
        If _IMCCardInformation.Count = 0 Then Return False
        Try

            ' d2410_set_profile(AxisNo, IntialVel, MaxVel, 0.1, 0.1)
            d2410_t_pmove(AxisNo, pos / _IMCCardInformation(AxisNo).Resoulotion, 1)
            While True
                Application.DoEvents()
                If MoveDone(AxisNo) = True Then
                    Exit While
                End If
            End While
        Catch ex As Exception
            Return -1
        End Try
        Return 0
    End Function
    Enum HomeMode
        正方向
        负方向
    End Enum
    Private HomeThread As System.Threading.Thread
    Public WriteOnly Property HandleHome(ByVal obj As HomeParameter) As Boolean Implements InterfaceHandle.HandleHome
        Set(ByVal value As Boolean)
            If value = False Then
                If HomeThread IsNot Nothing Then
                    HomeThread.Abort()
                End If
            End If
            If value = True Then
                Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf Home)
                HomeThread = New Threading.Thread(s)
                HomeThread.IsBackground = True
                HomeThread.Start(obj)
            End If
        End Set
    End Property
    Private Function Home(ByVal obj As HomeParameter) As Boolean Implements InterfaceHandle.Home
        Dim AxisNo As Integer = obj._AxisNo
        Dim HomeDir As HomeMode = HomeMode.正方向
        Dim HomeSpeed As Double = 1000000
        Dim TimeOut As Double = 20
        If AxisInitalPara.AxisInitalParameter(obj._AxisNo).HomeDir = 0 Then
            HomeDir = HomeMode.正方向
        Else
            HomeDir = HomeMode.负方向
        End If

        MoveVel(2, 1000000)
        MoveVel(2, 1000000)
        d2410_set_HOME_pin_logic(2, 0, 0)
        d2410_config_home_mode(2, 0, 1)
        d2410_set_profile(2, 500, 1000, 0.1, 0.1)
        d2410_home_move(2, 2, 0)
        While True
            If ORG(2) = True Then
                d2410_imd_stop(2)
                d2410_set_position(2, 0)
                d2410_set_position(2, 0)
                Exit While
            End If
        End While

        If obj._AxisNo = 0 Then
            d2410_set_profile(0, 1000, 20000, 0.5, 0.1)
            d2410_t_pmove(0, 1000000, 0)
            While True
                Application.DoEvents()
                If MoveDone(0) = True Then
                    Exit While
                End If
            End While
            d2410_set_profile(0, 100, 2000, 0.5, 0.1)
            d2410_t_pmove(0, -1000000, 0)
            While True
                If _IMCCardInformation(obj._AxisNo).PLM = False Then
                    d2410_imd_stop(0)
                    Exit While
                End If
            End While
            d2410_set_position(0, 0)
            d2410_set_position(0, 0)
        End If
        If obj._AxisNo = 1 Then
            d2410_set_profile(0, 1000, 20000, 0.5, 0.1)
            d2410_t_pmove(1, -1000000, 0)
            While True
                Application.DoEvents()
                If MoveDone(1) = True Then
                    Exit While
                End If
            End While
            d2410_set_profile(1, 100, 2000, 0.5, 0.1)
            d2410_t_pmove(1, 1000000, 0)
            While True
                If _IMCCardInformation(1).NLM = False Then
                    d2410_imd_stop(1)
                    Exit While
                End If
            End While
            d2410_set_position(1, 0)
            d2410_set_position(1, 0)
        End If
        _IMCCardInformation(0).IsHome = True
        _IMCCardInformation(1).IsHome = True
        _IMCCardInformation(2).IsHome = True
        Return True
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Timeout"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HomeAll(Optional ByVal Timeout As Integer = 10, Optional ByVal ID As Int16 = 0) As Boolean
        'Dim status As IMC_STATUS
        'If _IMCCardInformation.Count = 0 Then Return False
        'For i As Integer = 0 To _IMCCardInformation.Count - 1

        '    If _IMCCardInformation(i).IsOpen = False Then Return False
        '    status = IMC_SetParam16(_IMCCardInformation(i).CardHandle, clearLoc, -1, _IMCCardInformation(i).AxisNo, TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
        '    status = IMC_SetParam16(_IMCCardInformation(i).CardHandle, emstopLoc, 0, 0, TYPE_FIFO.SEL_IFIFO)
        '    status = IMC_HomeSwitch1(_IMCCardInformation(i).CardHandle, 0, 0, 1, _IMCCardInformation(i).AxisNo, TYPE_FIFO.SEL_QFIFO)
        'Next
        Return True
    End Function
    ''' <summary>
    ''' 获取对应轴的位置
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentPos(ByVal AxisNo As Integer) As Double Implements InterfaceHandle.GetCurrentPos
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        _IMCCardInformation(AxisNo).Postion = d2410_get_position(AxisNo) * _IMCCardInformation(AxisNo).Resoulotion
        Return _IMCCardInformation(AxisNo).Postion
    End Function
    ''' <summary>
    ''' 读取原点状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ORG(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.ORG
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        'If AxisNo = 2 Then
        '    _IMCCardInformation(AxisNo).Org = Not _IMCCardInformation(AxisNo).Org
        'End If
        Return _IMCCardInformation(AxisNo).Org
    End Function
    ''' <summary>
    ''' 读取正极限状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PLM(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.PLM
        _IMCCardInformation(AxisNo).PLM = False
        Return False
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Return _IMCCardInformation(AxisNo).PLM
    End Function
    ''' <summary>
    ''' 读取负极限状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NLM(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.NLM
        _IMCCardInformation(AxisNo).NLM = False
        Return False
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Return _IMCCardInformation(AxisNo).NLM
    End Function
    Public Function ErrorValue(ByVal AxisNo As Short) As String Implements InterfaceHandle.ErrorValue
        If _IMCCardInformation.Count = 0 Then Return -9
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return -9
        Return _IMCCardInformation(AxisNo).ErrorMessage
    End Function

    ''' <summary>
    ''' 设置输出端口及读取端口
    ''' </summary>
    ''' <param name="Index">端口号</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WriteOut(ByVal Index As Integer, Optional ByVal AxisNo As Short = 0) As Boolean Implements InterfaceHandle.WriteOut

        Set(ByVal value As Boolean)
            If _IMCCardInformation.Count = 0 Then Return
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return
            Dim int As Short = IIf(value = True, 1, 0) '低电平有效
            d2410_write_outbit(_IMCCardInformation(AxisNo).CardID, Index + 1, int)
            'd2410_wirte_output(_IMCCardInformation(AxisNo).CardID, )

        End Set
        Get
            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim Iret As Integer = d2410_read_outbit(_IMCCardInformation(AxisNo).CardID, Index + 1)
            Return IIf(Iret = 1, True, False)
            Return True
        End Get
    End Property

    Public ReadOnly Property ReadIn(ByVal Index As Integer, Optional ByVal AxisNo As Short = 0) As Boolean Implements InterfaceHandle.ReadIn
        Get
            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim Iret As Integer = d2410_read_inbit(_IMCCardInformation(AxisNo).CardID, Index)
            Return IIf(Iret = 1, True, False)
            Return True
            Return True
        End Get
    End Property

    Public Sub CloseCard() '(ByVal AxisNo As Int16)
        If _IMCCardInformation.Count = 0 Then Return
        d2410_board_close()
    End Sub
    Public Property EMS(ByVal AxisNo As Integer, Optional ByVal IsEMS As Boolean = False) As Boolean Implements InterfaceHandle.EMS
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            If _IMCCardInformation.Count = 0 Then Return
            If IsEMS = False Then
                d2410_decel_stop(AxisNo, 0.1)
            Else
                Try
                    If value = True Then d2410_emg_stop()
                Catch ex As Exception

                End Try
            End If
        End Set
    End Property

    Private ReadOnly Property InterfaceHandle__IMCCardInformation As List(Of IMCCardInforMation) Implements InterfaceHandle._IMCCardInformation
        Get
            Return _IMCCardInformation
        End Get
    End Property

    Private Property InterfaceHandle__IsPauseThread As Boolean Implements InterfaceHandle._IsPauseThread
        Get
            Return _IsPauseThread
        End Get
        Set(value As Boolean)
            _IsPauseThread = value
        End Set
    End Property

    Private Property InterfaceHandle__NetCardInformation As List(Of NetCardInforMation) Implements InterfaceHandle._NetCardInformation
        Get
            Return _NetCardInformation
        End Get
        Set(value As List(Of NetCardInforMation))
            _NetCardInformation = value
        End Set
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 處置 Managed 狀態 (Managed 物件)。
            End If

            ' TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下面的 Finalize()。
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: 只有當上面的 Dispose(ByVal disposing As Boolean) 有可釋放 Unmanaged 資源的程式碼時，才覆寫 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 請勿變更此程式碼。在上面的 Dispose(ByVal disposing As Boolean) 中輸入清除程式碼。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        If DataRefreshThread Is Nothing Then
            DataRefreshThread.Abort()
        End If
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub Trm_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Trm.Tick
        Trm.Stop()
        RefreshData()
        Trm.Start()
    End Sub

    Private Function Ch10_2(ByVal V As Int32) As Boolean()
        Dim S As String
        Dim B(31) As Boolean
        S = Convert.ToString(V, 2)
        For i As Integer = 0 To S.Length - 1
            B(i) = (S.Substring(S.Length - i - 1, 1) = "1")
        Next i
        Return B
    End Function

    Public Sub SetVeldef(AxisIndex As Integer) Implements InterfaceHandle.SetVeldef
        'Throw New NotImplementedException()
    End Sub

    Private Function MoveVel(AxisNo As Integer, pos As Double, Optional IntialVel As Integer = 100000, Optional MaxVel As Integer = 10, Optional Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveVel
        If _IMCCardInformation.Count = 0 Then Return False


        Dim t As String = ""
        Try
            'd2410_set_profile(AxisNo, IntialVel, MaxVel, 0.5, 0.1)
            'If AxisNo = 1 Or AxisNo = 0 Then
            '    d2410_set_profile(2, IntialVel, MaxVel, 0.5, 0.1)
            '    d2410_t_pmove(2, 0, 1)
            '    While True
            '        Application.DoEvents()
            '        If MoveDone(2) = True Then
            '            Exit While
            '        End If
            '    End While
            'End If
            d2410_t_pmove(AxisNo, pos / _IMCCardInformation(AxisNo).Resoulotion, 0)
            While True
                Application.DoEvents()
                If MoveDone(AxisNo) = True Then
                    Exit While
                End If
            End While
        Catch ex As Exception
            Return -1
        End Try
        Return 0
    End Function

    Public Function MoveVelPlus(AxisNo As Integer, pos As Double, Optional IntialVel As Integer = 100000, Optional MaxVel As Integer = 10, Optional Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveVelPlus
        '  Throw New NotImplementedException()
    End Function



    Public Function GetPos(AxisNo As Integer) As Double Implements InterfaceHandle.GetPos
        ' Throw New NotImplementedException()
    End Function

    Private Sub InterfaceHandle_CloseCard() Implements InterfaceHandle.CloseCard
        ' Throw New NotImplementedException()
    End Sub
End Class
