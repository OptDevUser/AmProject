Imports System.ComponentModel
Imports System.ComponentModel.TypeConverter
Imports System.ComponentModel.CustomTypeDescriptor
Imports System.Globalization
Imports System.Collections.ObjectModel
Imports System.IO
'
' 流程函数列表 
'  函数信息（说明），函数名、重复数、延迟数、提示、需要暂停否、电流、电压、是否需要重复、跳过
'  气件列表、引用接口、引用接口文件、是否引用接口、错误运行、跳过这个步、IO通道、IO索引、IO状态、保存路径、连接流
'  
' 连接流、IsSkipThisStep、ReferenceInterface(暂存器相关）
<Serializable()> _
Public Class FlowFunctionlist
    Public Enum UerFuntion
        保存文件
        改变气动元件状态
        ' 光纤与Lens对八度角
        找零界点
        把光纤插入玻璃管
        ' 光纤带玻璃管与Lens对位
        '   校准光路
        移动轴
        移动轴使用文件路径
        '三轴对准
        盲扫
        PD对准

        '转胶水
        GoReferenceFile

        SaveReferenceFile
        异常已清除
        GoArryBox

        JugeTargetValue
        用户提示

        打开电源

        关闭电源

        设定电源参数

        GetCurrentPowerMeterValue

        UpDataToFrom 'qu

        获取板卡IO输出输入状态

        GetCurrentSpec

        更新UV后数据
        寻找光的临界点
        判断电压
        设定电源输出波形
        增加子流程
    End Enum
    Public Property UserInfo As String = "New Function"
    Public Property FunctionName As UerFuntion = UerFuntion.用户提示
    Public Property RepeatConut As Integer = 0
    Public Property DelayTime As Double
    Public Property IsUseFilePos As Boolean
    Public Property Prompt As String = ""       '子流程＼电源波形
    Public Property IsNeedPaus As Boolean
    Public Property ProductCurrent As Double
    Public Property ProductVolt As Double
    Public Property IsNeedRepeat As Boolean = False
    Public Property IsJumpThisFunction As Boolean
    Public AirOp As New List(Of cAirOperated)
    Public Property ReferenceInterface As OutDataInfo
    Public Property ReferenceInterfaceFile As String    '暂存器文件
    Public Property IsUsedReferenceInterface As Boolean = False
    Public Property LinkFlow As UerFuntion = UerFuntion.PD对准
    Public Property IsErrorRun As Boolean = False               ' 错误，则运行
    Public Property IsSkipThisStep As Boolean                   ' 是否错误 不执行
    Public Property IOChannel As Integer
    Public Property IOIndex As Double
    Public Property IOStatus As Boolean
    Private _SaveFilePath As String
    Public Property SaveFilePath As String
        Get
            Return _SaveFilePath
        End Get
        Set(value As String)
            Try
                If File.Exists(value) = False Then
                    File.Create(value)
                End If
                _SaveFilePath = value
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public ReadOnly Property FileSetting As List(Of BasepositionInformation)
        Get
            If IsUseFilePos = False Then Return Nothing
            Dim a As New PositionInformation
            Dim Tmp As New List(Of BasepositionInformation)
            BrainDll.BrainUserDll.GlobalTool.ToTryLoad(a, New PositionInformation, Prompt)
            Tmp.Clear()

            For i As Int16 = 0 To a.AxisPostion.Length - 1
                Tmp.Add(a.AxisPostion(i))
            Next
            Return Tmp
        End Get
    End Property

    Public AxisSetting As New List(Of AxisInfo)
    Public ReadOnly Property 轴的设定 As String
        Get
            Dim str As String = String.Empty
            Try

                For i As Int16 = 0 To AxisSetting.Count - 1
                    If AxisSetting(i).IsUsedAxis Then
                        str = str & AxisSetting(i).ToString
                    End If
                Next
                If str Is Nothing Then Return ""
            Catch ex As Exception

            End Try

            Return str.Trim(":")
        End Get
    End Property

    Public ReadOnly Property AirDecspition As String
        Get
            Dim str As String = String.Empty
            Try

                For i As Int16 = 0 To AirOp.Count - 1
                    str = str & AirOp(i).ToString
                Next
                If str Is Nothing Then Return ""
            Catch ex As Exception

            End Try

            Return str.Trim(":")
            Return ""
        End Get
    End Property
    Public ReadOnly Property DetailedPrompt As String
        Get

            Try
                Dim FuntionDescption As String = ""
                Try
                    FuntionDescption = Ini.GetINIValue("函数说明", FunctionName.ToString, IniFile)
                Catch ex As Exception
                    FuntionDescption = "无代码说明"
                End Try

                Return FuntionDescption
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return DetailedPrompt
    End Function
End Class
'
' 轴信息 
' （移动模式、方向、速度模式、盲扫方向、轴的序号（类型）、轴号及名称、Sensor）
'  其它：是否使用轴、位置Plus、速度、步长、checkpoint、递归数、、Delta、最大功率计
'  IsNeedFouseLighr、是否需要盲扫、盲扫范围、
'
<Serializable()> _
Public Class AxisInfo
    Public Enum MoveMode
        MoveAbs = 0
        MoveRel = 1
    End Enum
    Public Enum MoveDir
        正方向 = 1
        负方向 = -1
    End Enum
    Public Enum SpeedMode
        HighSpeed
        SlowSpeed
    End Enum
    Public Enum BlindSearchDir
        向内
        向外
    End Enum
    Enum AxisNoType
        Axis0 = 0
        Axis1 = 1
        Axis2 = 2
        Axis3 = 3
        Axis4 = 4
        Axis5 = 5
        Axis6 = 6
        Axis7 = 7
    End Enum
    Public ReadOnly Property AxisNoName As String
        Get
            Dim FuntionDescption As String = ""
            Try
                FuntionDescption = Ini.GetINIValue("Axis", AxisNo.ToString, IniFile)
            Catch ex As Exception
                FuntionDescption = ""
            End Try
            Return FuntionDescption
        End Get
    End Property
    Public Property AxisNo As AxisNoType=AxisNoType.Axis1
    Public Property IsUsedAxis As Boolean
    Public Property _MoveMode As MoveMode=MoveMode.MoveAbs
    Public Property Dir As MoveDir=MoveDir.负方向
    Public Property Channel As ChannelName = ChannelName.PowerChA
    Public Property ModeSpeed As SpeedMode = SpeedMode.HighSpeed
    Public Property Plus As Double = 0
    Public Property Speed As Double = 0
    Public Property Picth As Double = 0
    Public Property PicthCount As Int16 = 0
    Public Property PowerDelate As Double = 0
    Public Property PowerMax As Double
    Public Property IsNeedFouseLighr As Boolean
    Public Property IsUsedBlindSearch As Boolean
    Public Property BlindSearchRang As Integer = 0
    Public Property Recursion As Int16
    Public Enum ChannelName As Byte
        PowerChA
        PowerChB
        SensorChA
        SensorChB
    End Enum
    Public Overrides Function ToString() As String
        Return "轴名称：" & AxisNoName & ":移动模式：" & _MoveMode.ToString & ":移动方向：" & Dir.ToString & ":移动速度：" & Speed & ":移动位置：" & Plus & ":移动picth:" & Picth & ":"
    End Function
   
End Class
'
' 气件（气动元件） 操作方式
'  名称、开挂否
'
<Serializable()> _
Public Class cAirOperated
    'Public Enum _AirOperateitem
    '    UV
    '    PigtailLock
    '    LensLock
    '    GlassLock
    '    MoveStage
    'End Enum
  
    Public Property Operateitem As String
    Public Property OperateValue As Boolean
    Public Overrides Function ToString() As String
        Return "气动元气件:" & Operateitem.ToString & ":气动方式：" & OperateValue.ToString ' & ":移动方向：" & Dir.ToString & ":移动速度：" & Speed & ":移动位置：" & Plus & ":移动picth:" & Picth & ":"
    End Function
End Class
'
' 用户流程
' 列表 | 包含流程功能列表
'
<Serializable> _
Public Class UserFlow
    <Category("Product")>
    Public Property FunctionList As New List(Of FlowFunctionlist)

End Class
'
' 暂存器 数据
'
'
<Serializable> _
Public Class OutDataInfo
    Public AxisXPosition As String = "AxisXPosition"
    Public AxisYPosition As String = "AxisYPosition"
    Public AxisZPosition As String = "AxisZPosition"
    Public AxisRPosition As String = "AxisRPosition"
    Public AxisPitchPosition As String = "AxisPitchPosition"
    Public AxisYawPosition As String = "AxisYawPosition"
    Public AxisM_ZPosition As String = "AxisM_ZPosition"

    Public AxisXOutName As String = "AxisXPosition"
    Public AxisYOutName As String = "AxisYPosition"
    Public AxisZOutName As String = "AxisZPosition"
    Public AxisROutName As String = "AxisRPosition"
    Public AxisPitchOutName As String = "AxisPitchPosition"
    Public AxisYawOutName As String = "AxisYawPosition"
    Public AxisM_ZOutName As String = "AxisM_ZPosition"

    Public Property IsSaveAxisXPosition As Boolean '= "AxisXPosition"
    Public Property IsSaveAxisYPosition As Boolean ' = "AxisYPosition"
    Public Property IsSaveAxisZPosition As Boolean ' = "AxisZPosition"
    Public Property IsSaveAxisRPosition As Boolean ' = "AxisRPosition"
    Public Property IsSaveAxisPitchPosition As Boolean ' = "AxisPitchPosition"
    Public Property IsSaveAxisYawPosition As Boolean ' = "AxisYawPosition"
    Public Property IsSaveAxisM_ZPosition As Boolean ' = "AxisM_ZPosition"
    Private _OutFilePath As String
    Public Property OutFilePath As String

        Get
            Return _OutFilePath
        End Get
        Set(value As String)
            Try
                If File.Exists(value) = False Then
                    File.Create(value)
                End If
                _OutFilePath = value
            Catch ex As Exception

            End Try

        End Set
    End Property

    Public ChannelPowerA As String = "ChannelPowerA"
    Public ChannelPowerB As String = "ChannelPowerB"
    Public ChannelSensorA As String = "ChannelSensorA"
    Public ChannelSensorB As String = "ChannelSensorB"
    Public Property IsSaveChannelPowerA As Boolean '= "ChannelPowerA"
    Public Property IsSaveChannelPowerB As Boolean ' = "ChannelPowerB"
    Public Property IsSaveChannelSensorA As Boolean ' = "ChannelSensorA"
    Public Property IsSaveChannelSensorB As Boolean ' = "ChannelSensorB"
    Public Sub SaveData()
        Dim OutTxt As String = String.Empty
        If IsSaveAxisXPosition Then
            OutTxt &= "AxisXPosition:" & AxisXPosition & vbNewLine
        End If
        If IsSaveAxisYPosition Then
            OutTxt &= "AxisYPosition:" & AxisYPosition & vbNewLine
        End If
        If IsSaveAxisZPosition Then
            OutTxt &= "AxisZPosition:" & AxisZPosition & vbNewLine
        End If
        If IsSaveAxisRPosition Then
            OutTxt &= "AxisRPosition:" & AxisRPosition & vbNewLine
        End If
        If IsSaveAxisPitchPosition Then
            OutTxt &= "AxisPitchPosition:" & AxisPitchPosition & vbNewLine
        End If
        If IsSaveAxisYawPosition Then
            OutTxt &= "AxisYawPosition:" & AxisYawPosition & vbNewLine
        End If
        If IsSaveAxisM_ZPosition Then
            OutTxt &= "AxisM_ZPosition:" & AxisM_ZPosition & vbNewLine
        End If

        Dim Power As Double
        If IsSaveChannelPowerA Then

            GetChannelData(AxisInfo.ChannelName.PowerChA, Power)
            ChannelPowerA = Power.ToString()
            OutTxt &= "ChannelPowerA:" & ChannelPowerA & vbNewLine
        End If
        If IsSaveChannelPowerB Then
            GetChannelData(AxisInfo.ChannelName.PowerChB, Power)
            ChannelPowerB = Power.ToString()
            OutTxt &= "ChannelPowerb:" & ChannelPowerB & vbNewLine
        End If
        If IsSaveChannelSensorA Then
            GetChannelData(AxisInfo.ChannelName.SensorChA, Power)
            ChannelSensorA = Power.ToString()
            OutTxt &= "ChannelSensorA:" & ChannelSensorA & vbNewLine
        End If
        If IsSaveChannelSensorB Then
            GetChannelData(AxisInfo.ChannelName.SensorChB, Power)
            ChannelSensorB = Power.ToString()
            OutTxt &= "ChannelSensorA:" & ChannelSensorB & vbNewLine
        End If
        If File.Exists(OutFilePath) Then
            File.Delete(OutFilePath)
        End If
        File.AppendAllText(OutFilePath, OutTxt)
    End Sub
End Class
' 用于保存数据的 产品信息 | 是否保存{xyzr pyz}轴位置、 轴名称， 是否保存{pa pb sa sb}通道、通道名称
<Serializable> _
Public Class SaveDataProductInfo
    Public AxisXPosition As String = "AxisXPosition"
    Public AxisYPosition As String = "AxisYPosition"
    Public AxisZPosition As String = "AxisZPosition"
    Public AxisRPosition As String = "AxisRPosition"
    Public AxisPitchPosition As String = "AxisPitchPosition"
    Public AxisYawPosition As String = "AxisYawPosition"
    Public AxisM_ZPosition As String = "AxisM_ZPosition"

    Public AxisXOutName As String = "AxisXPosition"
    Public AxisYOutName As String = "AxisYPosition"
    Public AxisZOutName As String = "AxisZPosition"
    Public AxisROutName As String = "AxisRPosition"
    Public AxisPitchOutName As String = "AxisPitchPosition"
    Public AxisYawOutName As String = "AxisYawPosition"
    Public AxisM_ZOutName As String = "AxisM_ZPosition"

    Public Property IsSaveAxisXPosition As Boolean '= "AxisXPosition"
    Public Property IsSaveAxisYPosition As Boolean ' = "AxisYPosition"
    Public Property IsSaveAxisZPosition As Boolean ' = "AxisZPosition"
    Public Property IsSaveAxisRPosition As Boolean ' = "AxisRPosition"
    Public Property IsSaveAxisPitchPosition As Boolean ' = "AxisPitchPosition"
    Public Property IsSaveAxisYawPosition As Boolean ' = "AxisYawPosition"
    Public Property IsSaveAxisM_ZPosition As Boolean ' = "AxisM_ZPosition"
 
    Public ChannelPowerA As String = "ChannelPowerA"
    Public ChannelPowerB As String = "ChannelPowerB"
    Public ChannelSensorA As String = "ChannelSensorA"
    Public ChannelSensorB As String = "ChannelSensorB"


    Public ChannelPowerAName As String = "ChannelPowerA"
    Public ChannelPowerBName As String = "ChannelPowerB"
    Public ChannelSensorAName As String = "ChannelSensorA"
    Public ChannelSensorBName As String = "ChannelSensorB"

    Public Property IsSaveChannelPowerA As Boolean '= "ChannelPowerA"
    Public Property IsSaveChannelPowerB As Boolean ' = "ChannelPowerB"
    Public Property IsSaveChannelSensorA As Boolean ' = "ChannelSensorA"
    Public Property IsSaveChannelSensorB As Boolean ' = "ChannelSensorB"
   
End Class
