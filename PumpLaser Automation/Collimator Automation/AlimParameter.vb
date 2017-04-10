
Imports System.ComponentModel
'
' Alim参数： 功率波动、XZ步、Yaw步、m_YAWPitch
'
'
<Serializable()> _
Public Class cAlimParameter
    <Category("Parameter")>
    Public Property DeltaPower As Double = 0.1
    <Category("Parameter")>
    Public Property StepXZ As Double = 2
    <Category("Parameter")>
    Public Property StepYAWPitch As Double = 10
    <Category("Parameter")>
    Public Property m_YAWPitch As Double = -20
End Class
