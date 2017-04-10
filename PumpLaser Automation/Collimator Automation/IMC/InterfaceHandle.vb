Public Interface InterfaceHandle
    ReadOnly Property _IMCCardInformation As List(Of IMCCardInforMation)
    Property _IsPauseThread As Boolean
    Property _NetCardInformation As List(Of NetCardInforMation)
    Function SearchNet() As Boolean
    Sub OpenDev()
    Sub SearchDev(Inde As Int32)
    Function InitalCard(AxisIndex As Integer) As Boolean
    Sub SetVelDown(AxisIndex As Integer)
    Sub SetVeldef(AxisIndex As Integer)
    Sub SetVelAcc(AxisIndex As Integer)
    Function MoveDone(AixsIndex As Integer) As Boolean
    Function JOG(ByVal AxisNo As Integer, ByVal VelSpeed As Double, ByVal Pos As Integer, ByVal JogMode As Integer) As Boolean
    Function StopJog(ByVal AxisNo As Integer, ByVal JogMode As Integer) As Boolean
    Function MoveVel(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal IntialVel As Integer = 100000, Optional ByVal MaxVel As Integer = 10, Optional ByVal Timeout As Integer = 100) As Integer
    Function MoveVelPlus(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal IntialVel As Integer = 100000, Optional ByVal MaxVel As Integer = 10, Optional ByVal Timeout As Integer = 100) As Integer
    Function MoveAbs(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal Timeout As Integer = 100) As Integer
    WriteOnly Property HandleHome(ByVal obj As HomeParameter) As Boolean
    Function Home(ByVal obj As HomeParameter) As Boolean
    Function GetCurrentPos(ByVal AxisNo As Integer) As Double
    Function GetPos(ByVal AxisNo As Integer) As Double
    Function ORG(ByVal AxisNo As Integer) As Boolean
    Function PLM(ByVal AxisNo As Integer) As Boolean
    Function NLM(ByVal AxisNo As Integer) As Boolean
    Function ErrorValue(ByVal AxisNo As Int16) As String
    Property WriteOut(ByVal Index As Integer, Optional ByVal AxisNo As Int16 = 0) As Boolean
    ReadOnly Property ReadIn(ByVal Index As Integer, Optional ByVal AxisNo As Int16 = 0) As Boolean
    Sub CloseCard()
    Property EMS(ByVal AxisNo As Integer, Optional ByVal IsEMS As Boolean = False) As Boolean
End Interface
