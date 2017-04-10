'
' 轴Home（归位）  {方向、速度、超时、轴号、名称、}
'
'
Public Class cHome
    Public Enum Mode
        正方向
        负向向
    End Enum
    Public Property AxisIndex As Integer
    Public Property AxisName As String
    Public Property HomeDir As Mode
    Public Property HomeSpeed As Integer
    Public Property HomeTimeOut As Integer
End Class
'
' cHomeFlow 准确说 回原点
' 包含一个列表， 需要归位的轴参数值
'
<Serializable()> _
Public Class cHomeFlow
    Public HomeFlow As New List(Of cHome)
End Class
