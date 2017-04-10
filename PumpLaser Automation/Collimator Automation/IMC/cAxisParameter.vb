Imports System.ComponentModel
<Serializable()> _
Public Class cAxisParameter

    <Description("轴的ID")>
    Public Property AxisNo As Int32 = -1
    <Description(" 清楚所有状态")>
    Public Property clearLoc As Long = -1
    <Category("速度调整")>
    <Description("加速度极限")>
    Public Property accellimLoc As Long = 50000000
    <Category("速度调整")>
    <Description("速度极限")>
    Public Property vellimLoc As Long = 500000000
    <Category("速度调整")>
    <Description("速度极限")>
    Public Property mcsmaxvelLoc As Long = 10000000
    <Category("速度调整")>
    <Description("加速度")>
    Public Property mcsaccelLoc As Long = 1000000
    <Category("速度调整")>
    <Description("起始速度")>
    Public Property mcstgposLoc As Long = 5000000
    <Category("速度调整")>
    <Description("减速度极限")>
     Public Property mcsdecelLoc As Long = 1000000
    Public Property enaLoc As Short = -1
    <Description("当正负极限没有的话此值为0")>
    Public Property aioctrLoc As Short = 191
    Public Property homeseqLoc As Short = &H14
    Public Property lowvelLoc As Long = 83646
    Public Property highvelLoc As Long = 83646
    Public Property exitfiltLoc As Long = 0
    Public Property stopfiltLoc As Long = -1
    Public Property gout1Loc As Long = -1
    Public Property runLoc As Long = -1
    Public Property emstopLoc As Long = 0
    <Description("是否使用软正限位")>
    Public Property IsUseSoftLimitPostion As Boolean = False
    <Description("是否使用软负限位")>
    Public Property IsUseSoftLimitNeg As Boolean = False
    <Description("软正限位的位置")>
    Public Property PostionLimitPostion As String = 0
    <Description("软负限位的位置")>
    Public Property NegLimitPostion As String = 0
    <Description("回原点模式，0为先走到正极限然后往负方向找原点，1为先走到负极限然后往正方向找原点，3只找正极限的下降沿，4只招负极限的下降沿")>
    Public Property HomeDir As Integer = 0
    <Description("是否等待马达完成信号")>
    Public Property IsNeedMotionDone As Boolean = False
    <Description("是否使用传感器")>
    Public Property IsUseSensor As Boolean = False
    <Description("传感器Channel")>
    Public Property SensorChanel As Double = 2
    <Description("传感器安全Value")>
    Public Property SafeSensorValue As Double = 12
    ''status = IMC_SetParam32(m_handle, accellimLoc, 50000000, Axis, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
    ''status = IMC_SetParam32(m_handle, vellimLoc, 500000000, Axis, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
    ''status = IMC_SetParam32(m_handle, mcsmaxvelLoc, 10000000, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
    ''status = IMC_SetParam32(m_handle, mcsaccelLoc, 1000000, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
    ''status = IMC_SetParam32(m_handle, mcstgposLoc, 5000000, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
    ''status = IMC_SetParam32(m_handle, mcsdecelLoc, 1000000, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
    ''status = IMC_SetParam16(m_handle, enaLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '使能该轴，同时也输出电平使能驱动器（低电平）
    ''status = IMC_SetParam16(m_handle, aioctrLoc, 191, Axis, TYPE_FIFO.SEL_IFIFO)  '设置各轴IO的功能, AIO0、AIO1为限位开关输入（应接入限位开关，且低电平有效；若无限位开关，请去掉该语句）191
    ''status = IMC_SetParam16(m_handle, homeseqLoc, &H14, Axis, TYPE_FIFO.SEL_IFIFO)   '搜寻原点方式：仅使用原点开关，正方向出发
    ''status = IMC_SetParam32(m_handle, lowvelLoc, 83646, Axis, TYPE_FIFO.SEL_IFIFO)   '低速搜寻原点的速度
    ''status = IMC_SetParam32(m_handle, highvelLoc, 83646, Axis, TYPE_FIFO.SEL_IFIFO)  '高速搜寻原点的速度
    '        status = IMC_SetParam16(m_handle, exitfiltLoc, 0, Axis, TYPE_FIFO.SEL_IFIFO)     '发送错误时(error寄存器置位时)不退出控制器运行
    '        status = IMC_SetParam16(m_handle, stopfiltLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)    '发送错误时(error寄存器置位时)停止运动
    '        status = IMC_SetParam16(m_handle, gout1Loc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '16个全局IO的方向全部设为输出
    '        status = IMC_SetParam16(m_handle, runLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '运行该轴
    '        status = IMC_SetParam16(m_handle, emstopLoc, 0, 0, TYPE_FIFO.SEL_IFIFO)
End Class
<Serializable()> _
Public Class AxisParameter
    Public AxisInitalParameter(8) As cAxisParameter
    Sub New()
        For i As Int16 = 0 To AxisInitalParameter.Length - 1
            AxisInitalParameter(i) = New cAxisParameter

        Next
    End Sub
End Class
