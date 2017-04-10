Public Class ClsESP300
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Declare Function OpenDevice Lib "c:\DLL\PowerUsb.dll" () As Integer
    Declare Function CloseDevice Lib "c:\DLL\PowerUsb.dll" () As Short
    Declare Function ReadSingleLightPower Lib "c:\DLL\PowerUsb.dll" (ByVal channel As Byte, ByRef power As Single, ByVal wave As Byte) As Integer
    Declare Function CrtlLight Lib "c:\DLL\PowerUsb.dll" (ByVal button As Byte) As Integer
    Declare Function ReadSensor Lib "c:\DLL\PowerUsb.dll" (ByVal channel As Byte, ByRef power As Single) As Integer
    Private ReadThread As System.Threading.Thread
    Public Property ChALightPower As Single
    Public Property ChBlightPower As Single
    Public Property ChASeneor As Single

    Public IsShouldPaus As Boolean      '是否需要暂停刷新通道值
    Public Property ChBSensor As Single = 0
    Private _ZeroPower As Single

    ' 读取通道号 对应的0时刻功率值
    Public Property ZeroPower(Index As Integer) As Single
        Get

            Try
                _ZeroPower = Convert.ToSingle(Ini.GetINIValue("Power", "ZeroPower_" & Index, IniFile))
            Catch ex As Exception
                _ZeroPower = 0
            End Try
            Return _ZeroPower

        End Get
        Set(ByVal value As Single)
            Ini.WriteINIValue("Power", "ZeroPower_" & Index, value.ToString, IniFile)
            _ZeroPower = value
        End Set
    End Property

    ' New后 实时刷新power\Sensor值
    Sub New()
        IsNeedOffset = True
        ReadThread = New System.Threading.Thread(New Threading.ThreadStart(AddressOf RefreshData))
        ReadThread.IsBackground = True
        ReadThread.Start()
    End Sub
    ' 实时刷新 power\Sensor值
    Private Sub RefreshData()
        While True
            If IsShouldPaus = False Then
                If UsbComuncationStatus = _UsbComuncationStatus.Idle Or UsbComuncationStatus = _UsbComuncationStatus.ContiuneRead Then
                    UsbComuncationStatus = _UsbComuncationStatus.ContiuneRead
                    '
                    ReadSingleLightPower(ClsESP300.ChannelName.ChA, ChALightPower, , , 0)
                    ReadSingleLightPower(ClsESP300.ChannelName.ChB, ChBlightPower, , , 1)
                    ReadSingleLightPower(ClsESP300.ChannelName.ChA, ChASeneor, ClsESP300.PowerTye.Sensor, , 2)
                    ReadSingleLightPower(ClsESP300.ChannelName.ChB, ChBSensor, ClsESP300.PowerTye.Sensor, , 3)
                End If

            End If
            'Fix: sleep(1)
            Threading.Thread.Sleep(1)
        End While
    End Sub
    Public Enum ErrorType As Byte
        NoErro
        ReadDataError
        NoOpen
    End Enum
    Public Enum WaveType
        ShortWave = 1
        LongWave = 2
    End Enum
    Private _IsOpen As Boolean
    Public Property IsOpen As Boolean
        Get
            Return _IsOpen
        End Get
        Set(ByVal value As Boolean)
            _IsOpen = value
        End Set
    End Property
    Public WriteOnly Property WhiteLight As Boolean
        Set(ByVal value As Boolean)
            '   CrtlLight(Convert.ToByte(IIf(value, 1, 0)))
        End Set
    End Property
    Public WriteOnly Property HanldeDevice As Boolean

        Set(ByVal value As Boolean)
            Dim lret As Short = -9
            Try
                'MessageBox.Show(dllVersion.ToString)

                If value = True Then
                    lret = OpenDevice()
                    If lret = -1 Then _IsOpen = False
                    If lret = 0 Then _IsOpen = True
                    UsbComuncationStatus = _UsbComuncationStatus.Idle
                Else
                    If IsOpen = False Then Return
                    lret = CloseDevice()
                End If
            Catch ex As Exception

            End Try
            If IsOpen = False Then
                MessageBox.Show("功率计打开" & IIf(IsOpen, "OK", "NG " & lret))
            End If

        End Set
    End Property
    Public Enum ChannelName As Byte
        ChA = 1
        ChB = 2
        ChAB = 3
    End Enum
    Enum PowerTye
        Light
        Sensor
    End Enum
    '
    ' 读取功率计（power、light）    |直接调用底层函数ReadSingleLightPower, 调用5次取中间值得平均值，如果需要0补偿则还需要减掉0补偿值（ini中是负值，实际效果是+）
    ' 读取sensor                    | 直接调用底层函数ReadSensor
    '
    Public Function ReadSingleLightPower(ByVal channel As ChannelName, ByRef power As Single, Optional ByVal _PowerType As PowerTye = PowerTye.Light, Optional ByVal Wave As WaveType = WaveType.LongWave, Optional Index As Integer = 0, Optional IsOffSet As Boolean = True) As Integer
        ' HanldeDevice = True
        Try
            If IsOpen = False Then Return ErrorType.NoOpen
            Dim Iret As Integer
            Dim Reslutlist As New List(Of Double)
            Reslutlist.Clear()
            If _PowerType = PowerTye.Light Then
                Dim Tmp As Single
                For i As Int16 = 0 To 4
                    Iret = ReadSingleLightPower(channel, Tmp, Convert.ToByte(Wave))
                    Reslutlist.Add(Tmp)
                Next
                Reslutlist.Sort()
                power = Convert.ToSingle((Reslutlist(1) + Reslutlist(2) + Reslutlist(3)) / 3)
                If IsNeedOffset = True Then
                    power = power - ZeroPower(Index)
                Else
                    power = power
                End If
            Else
                Iret = ReadSensor(channel, power)
            End If
            Return Iret
        Catch ex As Exception

        End Try
        Return ErrorType.NoErro

    End Function
    Public Property IsNeedOffset As Boolean
    ' 读没有补偿的channel值
    Public Function ReadSingleLightPowerNoOffSet(ByVal channel As ChannelName, ByRef power As Single, Optional ByVal _PowerType As PowerTye = PowerTye.Light, Optional ByVal Wave As WaveType = WaveType.LongWave, Optional Index As Integer = 0) As Integer
        ' HanldeDevice = True
        Try
            If IsOpen = False Then Return ErrorType.NoOpen
            IsShouldPaus = True
            Dim Iret As Integer
            Dim Reslutlist As New List(Of Double)
            Reslutlist.Clear()
            If _PowerType = PowerTye.Light Then
                Dim Tmp As Single
                For i As Int16 = 0 To 4
                    Iret = ReadSingleLightPower(channel, Tmp, Convert.ToByte(Wave))
                    Reslutlist.Add(Tmp)
                Next
                Reslutlist.Sort()
                power = Convert.ToSingle((Reslutlist(1) + Reslutlist(2) + Reslutlist(3)) / 3)
                power = power

            Else
                Iret = ReadSensor(channel, power)
            End If
            IsShouldPaus = False
            Return Iret
        Catch ex As Exception

        End Try
        Return ErrorType.NoErro

    End Function
    Public Function OpenAddPoint(ByVal channel As Byte, Optional ByVal _PowerType As PowerTye = PowerTye.Light, Optional ByVal Wave As WaveType = WaveType.LongWave) As ErrorType
        'If UsbComuncationStatus = _UsbComuncationStatus.StartRead Then Return 0
        'UsbComuncationStatus = _UsbComuncationStatus.StartRead
        'Dim Iret As Integer = OPTOAUTODAQ_OpenAppoint(_PowerType, channel, Wave)
        'Return Iret
    End Function
    Public Function ReadAddPoint(ByRef MaxPower As Single, ByRef MinPower As Single, ByRef MaxTime As Integer, ByRef MinTime As Integer) As ErrorType
        'Dim Iret As Integer = OPTOAUTODAQ_ReadOutAppoint(MaxPower, MinPower, MaxTime, MinTime)
        'UsbComuncationStatus = _UsbComuncationStatus.StopRead
        'UsbComuncationStatus = _UsbComuncationStatus.Idle
        'Return Iret
    End Function

    Private UsbComuncationStatus As _UsbComuncationStatus = _UsbComuncationStatus.Idle
    Enum _UsbComuncationStatus
        Idle
        ContiuneRead
        StartRead
        StopRead
    End Enum
    Public Sub ReStart()
        If UsbComuncationStatus = _UsbComuncationStatus.StartRead Then
            '   OPTOAUTODAQ_RestartAppoint()
        End If

    End Sub
End Class
