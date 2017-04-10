Imports System.Text

Public Class c恒惠
    Private WithEvents HSPPort As System.IO.Ports.SerialPort
    Public Event RespondingMsg(msg As String)
    Private _IsOpen As Boolean = False
    ''' <summary>
    ''' 判断端口是否打开
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOpen As Boolean
        Get
            Return _IsOpen
        End Get
        Set(value As Boolean)
            _IsOpen = value
        End Set
    End Property

    ' 打开指定的端口 | PortName 端口名称
    Public Sub Connect(PortName As String)
        Try
            HSPPort = New IO.Ports.SerialPort(PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
            HSPPort.Open()
            Dim Str As Date = Now
            'GetIDN()
            'While True
            '    If Now.Subtract(Str).TotalSeconds > 5 Then
            '        Throw New Exception("连接电流源超时！")
            '    End If
            '    If _IDN <> String.Empty Then
            '        Exit While
            '    End If
            'End While
            IsOpen = True
        Catch ex As Exception
            IsOpen = False
        End Try
    End Sub
    Private _IDN As String = String.Empty
    ' 打开或关闭电源
    Public WriteOnly Property CurrentOut() As Boolean
        Set(value As Boolean)

            '输出格式如 :OUTP ON|OFF 回车
            System.Threading.Thread.Sleep(10)
            If value = True Then
Onlb:

                HSPPort.Write(":OUTP ON" & vbNewLine)
            Else
offlb:
                HSPPort.Write(":OUTP OFF" & vbNewLine)
                '  HSPPort.Write(" :OUTP?" & vbNewLine)
            End If
            System.Threading.Thread.Sleep(10)

            HSPPort.DiscardInBuffer()
            '
            '输出格式如 :OUTP? 回车
            ' 查询是否设置正确,不正确则重复尝试
            '? Problem: 响应异常时候 怎么退出?
            '
            HSPPort.Write(":OUTP?" & vbNewLine)
            System.Threading.Thread.Sleep(50)
            Dim status As String = HSPPort.ReadExisting
            If value = False Then
                If status.Trim.ToLower <> "off" Then
                    GoTo offlb
                End If
            Else
                If value = True Then
                    If status.Trim.ToLower <> "on" Then
                        GoTo Onlb
                    End If
                End If
            End If

        End Set
    End Property
    ' 设定电流、电压， 格式例如：APPL 2.0，1.0
    Public Sub SetParameter(Cur As Double, Volt As Double)
        HSPPort.Write(":APPL " & Volt.ToString & "," & Cur.ToString & vbNewLine)
    End Sub
    'Private Sub HSPPort_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles HSPPort.DataReceived
    '    System.Threading.Thread.Sleep(4)
    '    _IDN = HSPPort.ReadExisting
    '    RaiseEvent RespondingMsg(_IDN)
    'End Sub
    Public Sub GetIDN()
        HSPPort.Write("*IDN" & vbNewLine)
    End Sub
    ' 读取当前电流
    Public Sub GetOutPutCurentValue(ByRef Curr As String)
        Dim v, a As String
        a = ""
        Dim Count As Integer = 0
        v = ""
Again:
        If Count > 50 Then MessageBox.Show("电流读取失败！") : Curr = 0 : Return
        System.Threading.Thread.Sleep(10)
        HSPPort.DiscardInBuffer()
        HSPPort.Write(":MEAS:CURR?" & vbNewLine)
        System.Threading.Thread.Sleep(50)
        Curr = HSPPort.ReadExisting
        If Curr.Trim = "" Then
            Count = Count + 1
            GoTo Again
        End If
errorla:

    End Sub
    ' 读取当前电压
    Public Sub GetOutPutVoltValue(ByRef Curr As String)
        Dim v, a As String
        a = ""
        v = ""
        Dim Count As Integer = 0
Again:
        If Count > 50 Then MessageBox.Show("电压读取失败！") : Curr = 0 : Return
        System.Threading.Thread.Sleep(10)
        HSPPort.DiscardInBuffer()
        HSPPort.Write(":MEAS:Volt?" & vbNewLine)
        System.Threading.Thread.Sleep(50)
        Curr = HSPPort.ReadExisting
        If Curr.Trim = "" Then
            'Fix: 需要累积加一
            Count += 1
            GoTo Again
        End If

errorla:

    End Sub
    Public Sub Disconnect()
        Try
            HSPPort.Close()
            IsOpen = False
        Catch ex As Exception

        End Try
    End Sub
End Class
