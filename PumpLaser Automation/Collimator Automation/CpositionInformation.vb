Imports System.ComponentModel

<Serializable> _
Public Class BasepositionInformation
    Public Property AxisIndx As Integer
    Public Property OderPosition As Double
    Public Property IsUsedThisPosition As Boolean = False

    Public Property StartOrder As Integer
End Class
'
' 轴的定位信息{轴号、定位位置、是否使用（周轴|位置）、 执行顺序}
' 包含了六个轴
'
Public Class PositionInformation
    Public AxisPostion(5) As BasepositionInformation
    Sub New()
        For i As Int16 = 0 To 5
            AxisPostion(i) = New BasepositionInformation
        Next
    End Sub
End Class
