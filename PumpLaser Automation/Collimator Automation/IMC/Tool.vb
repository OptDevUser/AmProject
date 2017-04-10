Public Class Tool
    Public Structure ToolPoint
        Public X As Double
        Public Y As Double
        Public Z As Double
        Public Power As Double
        Public Overrides Function ToString() As String
            Return X & "," & Y & "," & Z
        End Function
    End Structure
    Private _KX As Double
    Private _KY As Double
    Public Property KX As Double
        Get
            Return _KX
        End Get
        Set(ByVal value As Double)
            _KX = value
        End Set
    End Property
    Public Property kY As Double
        Get
            Return _KY
        End Get
        Set(ByVal value As Double)
            _KY=value
        End Set
    End Property
    Public Sub CreatTool(ByVal StartPos As ToolPoint, ByVal EndPos As ToolPoint)
        Dim DeltaX As Double
        Dim DeltaY As Double
        Dim DeltaZ As Double
        DeltaX = StartPos.X - EndPos.X
        DeltaY = StartPos.Y - EndPos.Y
        DeltaZ = StartPos.Z - EndPos.Z
        KX = DeltaX / DeltaZ
        kY=DeltaY / DeltaZ
    End Sub
    Public TotalXOffSet As Double = 0
    Public TotalYOffSet As Double = 0
    Public Sub OffSetXY(ByVal TargetZ As Double, ByRef TargetPos As ToolPoint)
        TargetPos.Z = TargetZ
        Dim _OffSetX As Double = KX * TargetZ

        If Math.Abs(_OffSetX) > 0.1 Then
            If IsXNeedAddOffset = True Then
                TargetPos.X = _OffSetX
                TotalXOffSet = 0
            Else
                TargetPos.X = 0
            End If

        Else
            If IsXNeedAddOffset = True Then
                TotalXOffSet = TotalXOffSet + _OffSetX
            End If
            If Math.Abs(TotalXOffSet) > 0.1 Then
                TargetPos.X = TotalXOffSet
                TotalXOffSet = 0
            Else
                TargetPos.X = 0
            End If
        End If
        Dim _OffSetY As Double = kY * TargetZ
        If Math.Abs(_OffSetY) > 0.1 Then

            If IsYNeedAddOffset = True Then
                TargetPos.Y = _OffSetY
                TotalYOffSet = 0
            Else
                TargetPos.Y = 0
            End If
        Else
            If IsYNeedAddOffset Then
                TotalYOffSet = TotalYOffSet + _OffSetY
            End If
            If Math.Abs(TotalYOffSet) > 0.1 Then
                TargetPos.Y = TotalYOffSet
                TotalYOffSet = 0
            Else
                TargetPos.Y = 0
            End If
        End If
    End Sub
End Class
