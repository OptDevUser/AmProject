Imports System.ComponentModel
'
' 系统参数： 所有轴的比例参数设定、 以及Sensor最大最小、 马达最高速加速度
' 包含了：8个轴
'
<Serializable()> _
Public Class cSystemParmater
    <Category("轴卡")>
    Public Property 第一轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第二轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第三轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第四轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第五轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第六轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第七轴设定 As New SystemAxisSetting
    <Category("轴卡")>
     Public Property 第八轴设定 As New SystemAxisSetting
    <Category("Sensor")>
    Public Property SensorMax As Single
    <Category("Sensor")>
    Public Property SensorMin As Single
    <Category("马达设定")>
    <Description("马达最高速")>
    Public Property MaxSpeed As Integer
    <Category("马达设定")>
  <Description("马达加速速")>
    Public Property AccSpeed As Integer
End Class
' 系统参数： 实际上轴的比例参数设定、 以及Sensor最大最小、 马达最高速加速度
<Serializable()> _
<TypeConverter(GetType(VersionConverter))> _
Public Class SystemAxisSetting
    Public Property AxisName As String
    Public Property AxisResolution As Double

End Class
Friend Class VersionConverter : Inherits ExpandableObjectConverter
    Public Overloads Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean

        If (destinationType Is GetType(SystemAxisSetting)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, destinationType)
    End Function
    Public Overloads Overrides Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal sourceType As System.Type) As Boolean

        If (sourceType Is GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function
    Public Overloads Overrides Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object

        If TypeOf value Is String Then
            Try
                Dim s As String = CType(value, String)
                Dim versionParts() As String
                Dim VersionString As String = ""
                versionParts = Split(s, ".")
                If Not IsNothing(versionParts) Then
                    Dim _ApplicationVersion As SystemAxisSetting = New SystemAxisSetting()
                    If Not IsNothing(versionParts(0)) Then
                        _ApplicationVersion.AxisName = versionParts(0)
                    End If

                    If Not IsNothing(versionParts(1)) Then
                        _ApplicationVersion.AxisResolution = Convert.ToDouble(versionParts(1))
                    End If
                End If
            Catch ex As Exception
                ' Throw New ArgumentException(("Can not convert '" & value & "' to type ApplicationVersion").ToString)
            End Try
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function
    Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object

        If (destinationType Is GetType(System.String) AndAlso _
                 TypeOf value Is SystemAxisSetting) Then

            Dim _ApplicationVersion As  _
                SystemAxisSetting = CType(value, SystemAxisSetting)
            ' build the string as "Major.Minor.Build.Private"
            Return _ApplicationVersion.AxisName & "." & _ApplicationVersion.AxisResolution

        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

'
' 产品参数 { 最大功率、端口、电压、电流、比较单位、复位流程、起始流程、通道号}
'
<Serializable> _
Public Class ProductParameter
    Public MaxPower As Double   '？ 应该是最低必须满足的功率
    Public ReturnPower As Double
    Public ComPortName As String = "Com1"
    Public ProductCurrent As String = 10
    Public ProductVolte As String = 3
    Public ComparaUnit As Boolean = False
    Public ResetFlowFilw As String    ' 点击复位按钮，要跑的流程  
    Public StartFlow As String        ' 默认的要跑的 第一个流程 || 优先显示在组合框内，目的不要让用户再去选择  
    Public ChannelIndex As Integer    ' 做判断时候 需要的功率通道  |UpDataToFrom JugeTargetValue判断
End Class
