Public Class BlindSearch
    Dim strIO, strIO2 As String
    Dim nDelay As Integer
    Dim MaxPower, MaxPos As Double
    Dim SocketID As Integer
    Dim analogV() As Double
    Dim MaxX, MaxY, MaxX2, MaxY2, tempY As Double
    Dim TempMax, TempMax2 As Double
    'Dim PosRecord As New NationalInstruments.CWIMAQControls.CWIMAQPoints
    Dim bFindThreshold, bFindThreshold2 As Boolean
    Dim dOldDiff As Double
    Dim dThreshold, dThreshold2 As Double
    Dim bStop As Boolean '停止操作


    '扫描
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim ScanX As Int32
        Dim x0, y0, Xm, Ym, Xm2, Ym2 As Double
        Dim dStepX, dStepY As Double
        Dim power, PowerB As Double
        Dim MaxPower, MaxPower2 As Double

        Dim t1 As Long
        ' Dim oldXCh, oldYCh As Integer
        Dim nDelay As Integer
        Dim nLowVoltage As Integer
        Dim n As Integer
        Dim bXMove As Boolean
        'oldXCh = XChannel
        'oldYCh = YChannel
        bFindThreshold = False
        bFindThreshold2 = False
        'Scan = True
        nDelay = 0 ' CInt(txtDelay.Text)


        txtMaxPower.Text = ""
        txtMaxPower2.Text = ""
        txtYDif.Text = ""
        'If RadioButton1.Checked = True And RadioButton4.Checked = True Then
        '    XChannel = InputX   ' OUTPUT_X_AXIAL
        '    YChannel = InputY  'OUTPUT_Y_AXIAL
        'ElseIf RadioButton1.Checked = True And RadioButton4.Checked = False Then
        '    XChannel = OutputX   ' OUTPUT_X_AXIAL
        '    YChannel = OutputY  'OUTPUT_Y_AXIAL
        'ElseIf RadioButton1.Checked = False And RadioButton4.Checked = True Then
        '    XChannel = InputYAW   ' OUTPUT_X_AXIAL
        '    YChannel = InputPitch  'OUTPUT_Y_AXIAL
        'Else
        '    XChannel = OutputYAW   ' OUTPUT_X_AXIAL
        '    YChannel = OutputPitch  'OUTPUT_Y_AXIAL
        'End If
        'XChannel = OutputX
        'YChannel = OutputY

        strIO = "ChA"
        strIO2 = "ChB"
        dThreshold = CDbl(txtThreshold.Text)
        dThreshold2 = CDbl(txtThresholdB.Text)

        'dBlindSearchThreshold = CDbl(txtThreshold.Text)
        'dBlindSearchThresholdB = CDbl(txtThresholdB.Text)

        't1 = GetTickCount()
        bXMove = False

again:
        'ESP300.ReadPowerAB(power, PowerB)
        ' MsgBox(power)
        'If power > dBlindSearchThreshold And PowerB > dBlindSearchThresholdB Then   '如果大于
        '    ScanLenX.Text = 50
        '    ScanLenY.Text = 50
        'End If
        bFindThreshold = False
        bFindThreshold2 = False
        txtScanTime.Text = ""
        'g_bstop = False 2013-11-06
        bStop = False



        'x0 = CDbl(GetCurrentPos(XChannel))
        'y0 = CDbl(GetCurrentPos(YChannel))
        MaxX = x0
        MaxY = y0
        MaxX2 = x0
        MaxY2 = y0



        MaxPower = -100 'ESP300.ReadPower(strIO)
        MaxPower2 = -100
        TempMax2 = -100
        TempMax = -100

        bFindThreshold = False
        'WaveformGraph1.ClearData()

        dStepX = 0.001 * CDbl(StepSizeX.Text)
        dStepY = 0.001 * CDbl(StepSizeX.Text)
        ScanX = (0.001 * ScanLenX.Text) / dStepX
        Slide1.Maximum = ScanX * ScanX
        Slide1.Value = 0
        txtScanTime.Text = ""

        nLowVoltage = 0
        TempMax = -100
        n = 1

        ''zbh gai
        'Dim nTimers As Integer
        'nTimers = ScanX

        ''扫描一正方形区域，变长为Scanx
        'While (nTimers > 0)
        '    For i = 1 To nTimers
        '        If bStop = True Or g_bPauseFlag = True Then
        '            Exit While
        '        End If
        '        dCurPos = GetCurrentPos(YChannel)
        '        AxisRelativeMove("Y", YChannel, dStepX)
        '        PositionDelay(YChannel, dCurPos + dStepX)
        '        System.Windows.Forms.Application.DoEvents()
        '        ESP300.ReadPowerAB(power, PowerB)

        '        If power > 0.9767 * TempMax Then
        '            TempMax = power
        '            Xm = CDbl(GetCurrentPos(XChannel))
        '            Ym = CDbl(GetCurrentPos(YChannel))
        '        End If

        '        If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
        '            '  Sleep(3 * nDelay)
        '            TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
        '            Xm2 = GetCurrentPos(XChannel)
        '            Ym2 = GetCurrentPos(YChannel)  ' GetCurrentPos(YChannel)

        '        End If
        '        If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
        '        WaveformPlot1.PlotYAppend(power)
        '        WaveformPlot2.PlotYAppend(PowerB)
        '        If TempMax > dThreshold And bFindThreshold = False Then
        '            bFindThreshold = True
        '            MaxPower = TempMax
        '            MaxX = Xm
        '            MaxY = Ym

        '        End If
        '        If TempMax2 > dThreshold2 And bFindThreshold2 = False Then
        '            bFindThreshold2 = True
        '            MaxPower2 = TempMax2
        '            MaxX2 = Xm2
        '            MaxY2 = Ym2
        '        End If
        '        If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
        '            MaxPower = TempMax
        '            MaxX = Xm
        '            MaxY = Ym
        '        End If
        '        If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
        '            MaxPower2 = TempMax2
        '            MaxX2 = Xm2
        '            MaxY2 = Ym2
        '        End If
        '        If bFindThreshold = True And bFindThreshold2 = True Then
        '            If power < MaxPower * 2 And PowerB < MaxPower2 * 2 Then nLowVoltage = nLowVoltage + 1
        '            If nLowVoltage = 2 Then Exit While
        '        End If
        '    Next


        '    For i = 1 To nTimers
        '        If bStop = True Or g_bPauseFlag = True Then
        '            Exit While
        '        End If
        '        dCurPos = GetCurrentPos(XChannel)
        '        AxisRelativeMove("X", XChannel, dStepX)
        '        PositionDelay(XChannel, dCurPos + dStepX)
        '        ' Delay(nDelay)
        '        System.Windows.Forms.Application.DoEvents()
        '        ESP300.ReadPowerAB(power, PowerB)
        '        If power > 0.9767 * TempMax Then
        '            TempMax = power
        '            Xm = GetCurrentPos(XChannel)
        '            Ym = GetCurrentPos(YChannel)
        '        End If

        '        If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
        '            '  Sleep(3 * nDelay)
        '            TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
        '            Xm2 = GetCurrentPos(XChannel)
        '            Ym2 = GetCurrentPos(YChannel)  ' GetCurrentPos(YChannel)

        '        End If
        '        If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
        '        WaveformPlot1.PlotYAppend(power)
        '        WaveformPlot2.PlotYAppend(PowerB)
        '        If TempMax > dThreshold And bFindThreshold = False Then
        '            bFindThreshold = True
        '            MaxPower = TempMax
        '            MaxX = Xm
        '            MaxY = Ym
        '        End If
        '        If TempMax2 > dThreshold2 And bFindThreshold2 = False Then
        '            bFindThreshold2 = True
        '            MaxPower2 = TempMax2
        '            MaxX2 = Xm2
        '            MaxY2 = Ym2
        '        End If
        '        If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
        '            MaxPower = TempMax
        '            MaxX = Xm
        '            MaxY = Ym
        '        End If
        '        If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
        '            MaxPower2 = TempMax2
        '            MaxX2 = Xm2
        '            MaxY2 = Ym2
        '        End If
        '        If bFindThreshold = True And bFindThreshold2 = True Then
        '            If (power < MaxPower * 1.5 And PowerB < MaxPower2 * 1.5) Or (MaxPower >= dThreshold * 0.5 And PowerB >= MaxPower2 * 0.5) Then nLowVoltage = nLowVoltage + 1
        '            If nLowVoltage = 2 Then Exit While
        '        End If
        '    Next
        '    nTimers -= 1
        '    dStepX = -dStepX
        'End While

        'txtMaxPower.Text = MaxPower
        'txtMaxPower2.Text = MaxPower2
        'Label10.Text = MaxX2
        'Label14.Text = MaxY2
        'txtScanTime.Text = (GetTickCount - t1) * 0.001
        'txtYDif.Text = Format((MaxY - MaxY2) * 1000, "0.0")
        'Scan = False
        '' MsgBox("ok1")


        'If bFindThreshold = True Then 'bFindThreshold = True And 
        '    AxisAbsMove("X", XChannel, MaxX)
        '    AxisAbsMove("Y", YChannel, MaxY)

        '    PositionDelay(XChannel, MaxX)
        '    PositionDelay(YChannel, MaxY)


        'Else

        '    If bFindThreshold2 = True Then


        '        AxisAbsMove("X", XChannel, MaxX2)
        '        AxisAbsMove("Y", YChannel, MaxY2)

        '        PositionDelay(XChannel, MaxX2)
        '        PositionDelay(YChannel, MaxY2)


        '    Else

        '        If MaxPower > 0.2 Or MaxPower2 > 0.2 Then
        '            If MaxPower > MaxPower2 Then

        '                HillClimb.HillClimbAlign("INPUTA", 20, 0.002, 2, 2, 0.005, False)
        '                HillClimb.HillClimbAlign("ChA", 20, 0.002, 2, 2, 0.005, False)
        '            Else
        '                AxisAbsMove("X", XChannel, MaxX2)
        '                AxisAbsMove("Y", YChannel, MaxY2)

        '                PositionDelay(XChannel, MaxX2)
        '                PositionDelay(YChannel, MaxY2)

        '                HillClimb.HillClimbAlign("INPUTB", 20, 0.002, 2, 2, 0.005, False)  '0.2
        '                HillClimb.HillClimbAlign("ChB", 20, 0.002, 2, 2, 0.005, False)

        '            End If
        '        Else
        '            AxisAbsMove("X", XChannel, x0)
        '            AxisAbsMove("Y", YChannel, y0)

        '            PositionDelay(XChannel, x0)
        '            PositionDelay(YChannel, y0)
        '        End If
        '    End If
        'End If



        '扫描一正方形区域，变长为Scanx
        While (n <= ScanX)
            For i = 1 To n
                If bStop = True Or g_bPauseFlag = True Then
                    Exit While
                End If

                AxisRelativeMove("Y", YChannel, dStepX)
                PositionDelay(YChannel)
                System.Windows.Forms.Application.DoEvents()
                ESP300.ReadPowerAB(power, PowerB)

                If power > 0.9767 * TempMax Then
                    TempMax = power
                    Xm = CDbl(GetCurrentPos(XChannel))
                    Ym = CDbl(GetCurrentPos(YChannel))
                End If

                If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
                    '  Sleep(3 * nDelay)
                    TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
                    Xm2 = GetCurrentPos(XChannel)
                    Ym2 = GetCurrentPos(YChannel)  ' GetCurrentPos(YChannel)

                End If
                If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
                WaveformPlot1.PlotYAppend(power)
                WaveformPlot2.PlotYAppend(PowerB)
                If TempMax > dThreshold And bFindThreshold = False Then
                    bFindThreshold = True
                    MaxPower = TempMax
                    MaxX = Xm
                    MaxY = Ym

                End If
                If TempMax2 > dThreshold2 And bFindThreshold2 = False Then
                    bFindThreshold2 = True
                    MaxPower2 = TempMax2
                    MaxX2 = Xm2
                    MaxY2 = Ym2
                End If
                If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
                    MaxPower = TempMax
                    MaxX = Xm
                    MaxY = Ym
                End If
                If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
                    MaxPower2 = TempMax2
                    MaxX2 = Xm2
                    MaxY2 = Ym2
                End If
                If bFindThreshold = True And bFindThreshold2 = True Then
                    If power < MaxPower * 2 And PowerB < MaxPower2 * 2 Then nLowVoltage = nLowVoltage + 1
                    If nLowVoltage = 2 Then Exit While
                End If
                '上下移动一个波导
                If bXMove = False Then
                    If (bFindThreshold = True And bFindThreshold2 = False) Or (bFindThreshold = False And bFindThreshold2 = True) Then

                        AxisRelativeMove("", OutputX, 127 * 0.001)
                        PositionDelay(OutputX)
                        Delay(100)
                        ESP300.ReadPowerAB(power, PowerB)
                        If power < dBlindSearchThreshold - 5 Or PowerB < dBlindSearchThresholdB - 5 Then

                            AxisRelativeMove("", OutputX, -2 * 127 * 0.001)
                            PositionDelay(OutputX)
                            Delay(100)
                            ESP300.ReadPowerAB(power, PowerB)
                            If power < dBlindSearchThreshold - 10 Or PowerB < dBlindSearchThresholdB - 10 Then

                                AxisRelativeMove("", OutputX, 127 * 0.001)
                                PositionDelay(OutputX)
                                Delay(100)
                            End If
                            bXMove = True
                        Else
                            bXMove = True
                            GoTo again
                        End If

                    End If

                End If

            Next


            For i = 1 To n
                If bStop = True Or g_bPauseFlag = True Then
                    Exit While
                End If

                AxisRelativeMove("X", XChannel, dStepX)
                PositionDelay(XChannel)
                ' Delay(nDelay)
                System.Windows.Forms.Application.DoEvents()
                ESP300.ReadPowerAB(power, PowerB)
                If power > 0.9767 * TempMax Then
                    TempMax = power
                    Xm = GetCurrentPos(XChannel)
                    Ym = GetCurrentPos(YChannel)
                End If

                If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
                    '  Sleep(3 * nDelay)
                    TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
                    Xm2 = GetCurrentPos(XChannel)
                    Ym2 = GetCurrentPos(YChannel)  ' GetCurrentPos(YChannel)

                End If
                If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
                WaveformPlot1.PlotYAppend(power)
                WaveformPlot2.PlotYAppend(PowerB)
                If TempMax > dThreshold And bFindThreshold = False Then
                    bFindThreshold = True
                    MaxPower = TempMax
                    MaxX = Xm
                    MaxY = Ym
                End If
                If TempMax2 > dThreshold2 And bFindThreshold2 = False Then
                    bFindThreshold2 = True
                    MaxPower2 = TempMax2
                    MaxX2 = Xm2
                    MaxY2 = Ym2
                End If
                If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
                    MaxPower = TempMax
                    MaxX = Xm
                    MaxY = Ym
                End If
                If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
                    MaxPower2 = TempMax2
                    MaxX2 = Xm2
                    MaxY2 = Ym2
                End If
                If bFindThreshold = True And bFindThreshold2 = True Then
                    If (power < MaxPower * 1.5 And PowerB < MaxPower2 * 1.5) Or (MaxPower >= dThreshold * 0.5 And PowerB >= MaxPower2 * 0.5) Then nLowVoltage = nLowVoltage + 1
                    If nLowVoltage = 2 Then Exit While
                End If
            Next
            n = n + 1
            dStepX = -dStepX
        End While

        txtMaxPower.Text = MaxPower
        txtMaxPower2.Text = MaxPower2
        Label10.Text = MaxX2
        Label14.Text = MaxY2
        txtScanTime.Text = (GetTickCount - t1) * 0.001
        txtYDif.Text = Format((MaxY - MaxY2) * 1000, "0.0")
        Scan = False
        ' MsgBox("ok1")


        If bFindThreshold = True Then 'bFindThreshold = True And 
            AxisAbsMove("X", XChannel, MaxX)
            AxisAbsMove("Y", YChannel, MaxY)

            PositionDelay(XChannel)
            PositionDelay(YChannel)


        Else

            If bFindThreshold2 = True Then


                AxisAbsMove("X", XChannel, MaxX2)
                AxisAbsMove("Y", YChannel, MaxY2)

                PositionDelay(XChannel)
                PositionDelay(YChannel)


            Else

                If MaxPower > 0.2 Or MaxPower2 > 0.2 Then
                    If MaxPower > MaxPower2 Then

                        HillClimb.HillClimbAlign("INPUTA", 20, 0.002, 2, 2, 0.005, False)
                        HillClimb.HillClimbAlign("ChA", 20, 0.002, 2, 2, 0.005, False)
                    Else
                        AxisAbsMove("X", XChannel, MaxX2)
                        AxisAbsMove("Y", YChannel, MaxY2)

                        PositionDelay(XChannel)
                        PositionDelay(YChannel)

                        HillClimb.HillClimbAlign("INPUTB", 20, 0.002, 2, 2, 0.005, False)  '0.2
                        HillClimb.HillClimbAlign("ChB", 20, 0.002, 2, 2, 0.005, False)

                    End If
                Else
                    AxisAbsMove("X", XChannel, x0)
                    AxisAbsMove("Y", YChannel, y0)

                    PositionDelay(XChannel)
                    PositionDelay(YChannel)
                End If
            End If
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bStop = True
        If g_bIsFlowRunning = True And g_bIsFlowPaused = False Then '如果流程在运行并且不处于暂停状态
            g_bPauseFlag = True '使整个流程暂停
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BlindSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim PowerA, PowerB As Double
        Delay(20)
        ESP300.ReadPowerAB(PowerA, PowerB)
        If (PowerA < dBlindSearchThreshold And PowerB > dBlindSearchThresholdB) Or (PowerA > dBlindSearchThreshold And PowerB < dBlindSearchThresholdB) Then

            MsgBox("有一个通道没有光")
            g_bAbnormalPauseFlag = True
        End If

        Me.Hide()
    End Sub

    Private Sub BlindSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtThreshold.Text = dBlindSearchThreshold
        txtThresholdB.Text = dBlindSearchThresholdB

    End Sub

    Private Sub AxSlider1_ClickEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer

        i = Slide1.Value
        AxisAbsMove("", InputX, PosRecord.Item(i).X)
        AxisAbsMove("", InputY, PosRecord.Item(i).Y)
    End Sub
    '平衡
    Private Sub btnBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalance.Click
        TwoChBalance()
    End Sub
    'OK
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
    '平衡功能函数
    Public Sub TwoChBalance()
        Dim y, y1, y2 As Double
        'Dim dRollvalue, vdifference As Double
        'Dim powerA, powerB, doldpowerA, doldpwerB As Double

        Dim nRdiff As Double = 250 '表示输入端两个光源的间距


        Cursor = System.Windows.Forms.Cursors.WaitCursor

        dOldDiff = 100
again:  y1 = 100
        y2 = 100

        btnStart_Click(btnStart, New System.EventArgs)



        If bStop = True Or g_bPauseFlag = True Then Exit Sub
        If bFindThreshold = True And bFindThreshold2 = True Then

            y = CDbl(txtYDif.Text) ' y1 - y2
            '   MsgBox(y * 1000)
            If Math.Abs(y) < 5 Or m_bChipTest = True Then
                Cursor = Cursors.Default
                GoTo end1
            End If

            '如果deltaY绝对值变大并且同号 ，表示连接错误 zbh 2012-11-1
            If Math.Abs(y) > Math.Abs(dOldDiff) And y / dOldDiff > 0 Then
                MsgBox("请检查通道 A和 B是否连接正确。")
                Cursor = Cursors.Default
                g_bAbnormalPauseFlag = True
                Exit Sub
            End If

            If y < 0 Then
                y = y + 2
            Else
                y = y - 2
            End If
            dOldDiff = y
            If Math.Abs(y) >= 5 Then


                y = y * 0.001 * 0.9

                AxisRelativeMove("", OutputR, -y * (OutputRCompensate + OutputRCompensate * Math.Abs(y) * 1000 / 100))
                AxisRelativeMove("", OutputY, -y * OutputRCompensate / OutputYcompensate)
                'ScanLenY.Text = CStr(Math.Abs(y) + 20) '"60"
                Sleep(500)
                ' PositionDelay(OutputR, 
                GoTo again
            Else
                y = y * 0.001

                AxisRelativeMove("", OutputR, -y * OutputRCompensate)
                AxisRelativeMove("", OutputY, -y * OutputRCompensate / OutputYcompensate)
                ScanLenY.Text = "50"
                Sleep(50)
            End If

        End If

end1:
        If bFindThreshold = True And bFindThreshold2 = True Then
            If CDbl(txtMaxPower.Text) > CDbl(txtMaxPower2.Text) Then
                QuickScan(3, 1 * 0.001, "ChA", 5 * 0.001)
            Else
                QuickScan(3, 1 * 0.001, "ChB", 5 * 0.001)
            End If
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub QuickScan(ByVal checkpoints As Integer, ByVal dStep As Double, ByVal strIO As String, ByVal delta As Double) 'strIO, LenX, dStepX, ChkPoints, Iteration, Delta, True)
        Dim i, j, k As Integer
        Dim x, y0 As Double
        Dim power, OldMaxPower, tempPower, minTempPower, maxTempPower As Double

        Dim tempStrIO As String

        Dim dDelta As Double = 0.03
        Dim n As Integer

        nDelay = 0
        Select Case strIO
            Case "INPUTA"
                XChannel = InputX ' OUTPUT_X_AXIAL
                YChannel = InputY
                strIO = "ChA"
            Case "INPUTB"
                XChannel = InputX ' OUTPUT_X_AXIAL
                YChannel = InputY
                strIO = "ChB"
            Case "ChA"
                XChannel = OutputX ' OUTPUT_X_AXIAL
                YChannel = OutputY
                strIO = "ChA"

            Case "ChB"
                XChannel = OutputX ' OUTPUT_X_AXIAL
                YChannel = OutputY
                strIO = "ChB"
        End Select

        Scan = True
        tempStrIO = strIO
        strIO = strIO.Substring(2)


        x = GetCurrentPos(XChannel)
        y0 = GetCurrentPos(YChannel)

        bStop = False

again:

        AxisAbsMove("", XChannel, x)
        AxisAbsMove("", YChannel, y0)

        MaxX = x
        MaxY = y0

        'ESP300.ReadPowerMeter(strIO, MaxPower)
        i = 1
        PositionDelay(XChannel)
        PositionDelay(YChannel)
        Delay(20)

        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3


        OldMaxPower = MaxPower

        If bStop = True Or g_bPauseFlag = True Then GoTo end1
        For j = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1

            AxisRelativeMove("X", XChannel, dStep)
            ' Sleep(nDelay)

            'zbh
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3

            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)


                j = 0
            End If
        Next j
        ''<--x


        AxisAbsMove("X", XChannel, MaxX)
        PositionDelay(XChannel)
        Sleep(20) '增加延时，确保精度

        ''重新赋值给MaxPower
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3


        For j = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1
            AxisRelativeMove("X", XChannel, -dStep)
            ' Sleep(nDelay)
            'zbh
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3



            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)

                j = 0
            End If
        Next j

        AxisAbsMove("X", XChannel, MaxX)
        PositionDelay(XChannel)
        Sleep(20) '增加延时，确保精度


        ''重新赋值给MaxPower
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3


        For k = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1
            AxisRelativeMove("Y", YChannel, dStep)
            ' Sleep(nDelay)

            '------------------------------------1-------------

            'zbh
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3


            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)

                k = 0
            End If
        Next k

        ''''''''''''''''''''''''''

        AxisAbsMove("Y", YChannel, MaxY)
        PositionDelay(YChannel)
        Sleep(20) '增加延时，确保精度

        ''重新赋值给MaxPower
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3

        For k = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1
            AxisRelativeMove("Y", YChannel, -dStep)
            ' Sleep(nDelay)
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3

            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)

                k = 0
            End If
        Next k

        AxisAbsMove("Y", YChannel, MaxY)
        PositionDelay(YChannel)
        Sleep(20) '增加延时，确保精度
        'AxisAbsMove("X", XChannel, MaxX)

        '重新赋值给MaxPower
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3


        For j = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1

            AxisRelativeMove("X", XChannel, dStep)
            'Sleep(nDelay)

            'zbh
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3

            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)
                j = 0
            End If
        Next j
        ''<--x

        AxisAbsMove("X", XChannel, MaxX)
        PositionDelay(XChannel)
        Sleep(20) '增加延时，确保精度

        '重新赋值给MaxPower
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3

        For j = 1 To checkpoints
            Application.DoEvents()
            If bStop = True Or g_bPauseFlag = True Then GoTo end1
            AxisRelativeMove("X", XChannel, -dStep)
            'Sleep(nDelay)

            'zbh
            power = 0
            minTempPower = 100
            maxTempPower = -100
            For n = 0 To 4
                ESP300.ReadPowerMeter(strIO, tempPower)
                power += tempPower
                If tempPower > maxTempPower Then
                    maxTempPower = tempPower
                End If
                If tempPower < minTempPower Then
                    minTempPower = tempPower
                End If
            Next
            power = (power - minTempPower - maxTempPower) / 3



            If power - MaxPower > delta Then 'power > Delta * MaxPower
                MaxPower = power
                MaxX = GetCurrentPos(XChannel)
                MaxY = GetCurrentPos(YChannel)
                j = 0
            End If
        Next j

        AxisAbsMove("X", XChannel, MaxX)
        PositionDelay(XChannel)
        Sleep(20) '增加延时，确保精度

        '重新赋值给MaxPower()
        MaxPower = 0
        minTempPower = 100
        maxTempPower = -100
        For n = 0 To 4
            ESP300.ReadPowerMeter(strIO, tempPower)
            MaxPower += tempPower
            If tempPower > maxTempPower Then
                maxTempPower = tempPower
            End If
            If tempPower < minTempPower Then
                minTempPower = tempPower
            End If
        Next
        MaxPower = (MaxPower - maxTempPower - minTempPower) / 3
end1:


        ESP300.ReadPowerMeter(strIO, MaxPower)
        If MaxPower <= OldMaxPower - dDelta Then
            AxisAbsMove("X", XChannel, x)
            AxisAbsMove("Y", YChannel, y0)
            PositionDelay(XChannel)
            PositionDelay(YChannel)
            Sleep(20) '增加延时，确保精度
            Scan = False
            Exit Sub
        End If
        AxisAbsMove("X", XChannel, MaxX)
        AxisAbsMove("Y", YChannel, MaxY)
        PositionDelay(XChannel)
        PositionDelay(YChannel)
        Sleep(20) '增加延时，确保精度


        Scan = False

error1:
    End Sub

    'Private Sub BtnChipSearchLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChipSearchLight.Click '芯片测试找光
    '    ChipSearchFirstLight("A", m_dCTcheckLength, CDbl(txtThreshold.Text))
    'End Sub
    '参数说明：strCH表示读取的通道数，“A”表示读取通道1，“B”表示读取通道2,checkLength表示找到最大值之后再检查的长度，单位：um,dThreshold 表示阈值
    Public Sub ChipSearchFirstLight(ByVal strCH As String, ByVal checkLength As Double, ByVal dThreshold As Double)
        Dim m, stepcount As Integer 'stepcount表示匹配到一个之后所走的步数

        Dim dStepChipX, ChipX0, ChipXBest As Double
        Dim dPower, dMaxPower As Double '读取的功率数
        Dim sanChipz As Double

        Dim nDelay As Integer
        Dim t1 As Long

        Dim bHasLight As Boolean '表示是否有光 

        stepcount = 0
        m_bIshasFirstLight = False
        txtScanTime.Text = ""


        Sleep(600)
        t1 = GetTickCount()
        Scan = True
        bStop = False

        nDelay = 20
        dStepChipX = 0.001 * CDbl(StepSizeX.Text)

        ChipX0 = GetCurrentPos(XChip)
        ChipXBest = ChipX0


        sanChipz = 50 '初始化扫描长度默认为50mm
        dMaxPower = -100 '初始化最大功率

        m = sanChipz / dStepChipX
        WaveformGraph1.ClearData()
        Delay(nDelay)
        While (m >= 0)
            AxisRelativeMove("", XChip, -dStepChipX)
            m = m - 1
            Delay(nDelay)
            ESP300.ReadPowerMeter(strCH, dPower)
            If strCH = "A" Then
                WaveformPlot1.PlotYAppend(dPower)
            Else
                WaveformPlot2.PlotYAppend(dPower)
            End If

            If dPower > dThreshold And bHasLight = False Then '表示找到光了
                sanChipz = checkLength * 0.001
                dStepChipX = 0.002
                m = sanChipz / dStepChipX
                bHasLight = True
            End If
            If dPower > dMaxPower And dPower > dThreshold Then '如果有光，记录功率最大值
                dMaxPower = dPower
                ChipXBest = GetCurrentPos(XChip)
            End If
            If bStop = True Or g_bPauseFlag = True Then GoTo end1

        End While
end1:
        If bHasLight = True Then
            AxisAbsMove("", XChip, ChipX0)
            g_bAbnormalPauseFlag = True

        Else
            AxisAbsMove("", XChip, ChipXBest)
            If PMS.cmdRun.Visible = False Then DataLog(6) = GetRefTime()
            Sleep(50)

            g_bAbnormalPauseFlag = False
            m_bIshasFirstLight = True

        End If
        txtScanTime.Text = (GetTickCount() - t1) * 0.001

        Delay(200)

        Scan = False
        PMS.cmdNext.Enabled = True
    End Sub

    Public Sub LinkageSearchPower() '联动找光
        Dim ScanX As Int32
        Dim inx0, iny0, outx0, outy0, InXm, InYm, OutXm, OutYm, InXm2, InYm2, OutXm2, OutYm2 As Double
        Dim dStepX, dStepY As Double
        Dim power, PowerB As Double
        Dim MaxPower, MaxPower2 As Double

        Dim InMaxX, InMaxY, InMaxX2, InMaxY2, OutMaxX, OutMaxY, OutMaxX2, OutMaxY2 As Double

        Dim t1 As Long
        'Dim oldXCh, oldYCh As Integer
        Dim nDelay As Integer
        Dim nLowVoltage As Integer
        Dim n As Integer
        'oldXCh = XChannel
        'oldYCh = YChannel
        bFindThreshold = False
        bFindThreshold2 = False
        Scan = True
        nDelay = 50 ' CInt(txtDelay.Text)


        txtMaxPower.Text = ""
        txtMaxPower2.Text = ""
        txtYDif.Text = ""
        XChannel = OutputX   ' OUTPUT_X_AXIAL
        YChannel = OutputY  'OUTPUT_Y_AXIAL
        strIO = "ChA"
        strIO2 = "ChB"
        dThreshold = CDbl(txtThreshold.Text)
        dThreshold2 = CDbl(txtThresholdB.Text)

        dBlindSearchThreshold = CDbl(txtThreshold.Text)
        dBlindSearchThresholdB = CDbl(txtThresholdB.Text)

        ESP300.ReadPowerAB(power, PowerB)
        ' MsgBox(power)
        'zhb 取消阈值
        'If power > dBlindSearchThreshold And PowerB > dBlindSearchThresholdB Then   '如果大于
        '    ScanLenX.Text = 50
        '    ScanLenY.Text = 50
        'End If
        bFindThreshold = False
        bFindThreshold2 = False
        txtScanTime.Text = ""
        bStop = False

        dStepX = 0.001 * CDbl(StepSizeX.Text)
        dStepY = 0.001 * CDbl(StepSizeX.Text)

        inx0 = GetCurrentPos(InputX)
        iny0 = GetCurrentPos(InputY)
        outx0 = GetCurrentPos(OutputX)
        outy0 = GetCurrentPos(OutputY)

        '记录原始位置
        InMaxX = inx0
        InMaxY = iny0
        InMaxX2 = inx0
        InMaxY2 = iny0

        OutMaxX = outx0
        OutMaxY = outy0
        OutMaxX2 = outx0
        OutMaxY2 = outy0

        MaxPower = -100 'ESP300.ReadPower(strIO)
        MaxPower2 = -100
        TempMax2 = -100
        TempMax = -100
        t1 = GetTickCount()
        ' bFindThreshold = False
        WaveformGraph1.ClearData()

        '画初始图形 判断初始状态是否已找到光了 zbh 2012-11-16 改
        ESP300.ReadPowerAB(power, PowerB)
        WaveformPlot1.PlotYAppend(power)
        WaveformPlot2.PlotYAppend(PowerB)

        If power > dThreshold And bFindThreshold = False Then '说明通道A找到光了
            bFindThreshold = True
            MaxPower = power
            'InMaxX = InXm
            'InMaxY = InYm
            'OutMaxX = OutXm
            'OutMaxY = OutYm
        End If
        If PowerB > dThreshold2 And bFindThreshold2 = False Then '说明通道B找到光了
            bFindThreshold2 = True
            MaxPower2 = PowerB
            'InMaxX2 = InXm2
            'InMaxY2 = InYm2
            'OutMaxX2 = OutXm2
            'OutMaxY2 = OutYm2
        End If 'zbh 2012-11-16 改


        ScanX = (0.001 * ScanLenX.Text) / dStepX
        Slide1.Maximum = ScanX * ScanX
        Slide1.Value = 0
        txtScanTime.Text = ""

        nLowVoltage = 0
        TempMax = -100
        n = 1
        '扫描一正方形区域，变长为Scanx
        While (n <= ScanX)
            For i = 1 To n
                If bStop = True Or g_bPauseFlag = True Then
                    Exit While
                End If
                AxisRelativeMove("Y", InputY, dStepX)
                AxisRelativeMove("Y", OutputY, dStepX)


                Delay(40)
                ' tempY = tempY + dStepX
                ESP300.ReadPowerAB(power, PowerB)


                '记录两个通道功率的最大值
                If power > 0.9767 * TempMax Then
                    TempMax = power
                    InXm = GetCurrentPos(InputX)
                    InYm = GetCurrentPos(InputY)
                    OutXm = GetCurrentPos(OutputX)
                    OutYm = GetCurrentPos(OutputY)
                End If

                If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
                    '  Sleep(3 * nDelay)
                    TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
                    InXm2 = GetCurrentPos(InputX)
                    InYm2 = GetCurrentPos(InputY)
                    OutXm2 = GetCurrentPos(OutputX)
                    OutYm2 = GetCurrentPos(OutputY)

                End If
                If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
                WaveformPlot1.PlotYAppend(power)
                WaveformPlot2.PlotYAppend(PowerB)
                If TempMax > dThreshold And bFindThreshold = False Then '说明通道A找到光了
                    bFindThreshold = True
                    MaxPower = TempMax
                    InMaxX = InXm
                    InMaxY = InYm
                    OutMaxX = OutXm
                    OutMaxY = OutYm
                End If
                If TempMax2 > dThreshold2 And bFindThreshold2 = False Then '说明通道B找到光了
                    bFindThreshold2 = True
                    MaxPower2 = TempMax2
                    InMaxX2 = InXm2
                    InMaxY2 = InYm2
                    OutMaxX2 = OutXm2
                    OutMaxY2 = OutYm2
                End If
                '分别记录两个通道的功率最大值和功率最大值的位置
                If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
                    MaxPower = TempMax
                    InMaxX = InXm
                    InMaxY = InYm
                    OutMaxX = OutXm
                    OutMaxY = OutYm
                End If
                If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
                    MaxPower2 = TempMax2
                    InMaxX2 = InXm2
                    InMaxY2 = InYm2
                    OutMaxX2 = OutXm2
                    OutMaxY2 = OutYm2
                End If
                '如果两个通道都找到光了并且当前功率都小于最大功率的2倍（相当于正值的0.5倍）则退出while循环
                If bFindThreshold = True And bFindThreshold2 = True Then
                    If power < MaxPower * 2 And PowerB < MaxPower2 * 2 Then nLowVoltage = nLowVoltage + 1
                    If nLowVoltage = 2 Then Exit While
                End If
            Next


            For i = 1 To n
                If bStop = True Or g_bPauseFlag = True Then
                    Exit While
                End If
                'AxisRelativeMove("X", XChannel, dStepX)
                AxisRelativeMove("x", InputX, dStepX)
                AxisRelativeMove("x", OutputX, dStepX)

                Delay(40)
                ESP300.ReadPowerAB(power, PowerB)
                If power > 0.9767 * TempMax Then
                    TempMax = power
                    InXm = GetCurrentPos(InputX)
                    InYm = GetCurrentPos(InputY)
                    OutXm = GetCurrentPos(OutputX)
                    OutYm = GetCurrentPos(OutputY)
                End If

                If PowerB > 0.9767 * TempMax2 Then 'And bFindThreshold = True 
                    '  Sleep(3 * nDelay)
                    TempMax2 = PowerB 'ESP300.ReadPower(strIO2)
                    InXm2 = GetCurrentPos(InputX)
                    InYm2 = GetCurrentPos(InputY)
                    OutXm2 = GetCurrentPos(OutputX)
                    OutYm2 = GetCurrentPos(OutputY)
                End If
                If Slide1.Value < Slide1.Maximum Then Slide1.Value = Slide1.Value + 1
                WaveformPlot1.PlotYAppend(power)
                WaveformPlot2.PlotYAppend(PowerB)
                If TempMax > dThreshold And bFindThreshold = False Then
                    bFindThreshold = True
                    MaxPower = TempMax
                    InMaxX = InXm
                    InMaxY = InYm
                    OutMaxX = OutXm
                    OutMaxY = OutYm
                End If
                If TempMax2 > dThreshold2 And bFindThreshold2 = False Then
                    bFindThreshold2 = True
                    MaxPower2 = TempMax2
                    InMaxX2 = InXm2
                    InMaxY2 = InYm2
                    OutMaxX2 = OutXm2
                    OutMaxY2 = OutYm2
                End If
                If TempMax > 0.9767 * MaxPower Then 'And bFindThreshold = True    1.0233 -- 0.1dB
                    MaxPower = TempMax
                    InMaxX = InXm
                    InMaxY = InYm
                    OutMaxX = OutXm
                    OutMaxY = OutYm
                End If
                If TempMax2 > 0.9767 * MaxPower2 Then 'And bFindThreshold = True 
                    MaxPower2 = TempMax2
                    InMaxX2 = InXm2
                    InMaxY2 = InYm2
                    OutMaxX2 = OutXm2
                    OutMaxY2 = OutYm2
                End If
                If bFindThreshold = True And bFindThreshold2 = True Then
                    If power < MaxPower * 2 And PowerB < MaxPower2 * 2 Then nLowVoltage = nLowVoltage + 1
                    If nLowVoltage = 2 Then Exit While
                End If
            Next
            n = n + 1
            dStepX = -dStepX
        End While

        txtMaxPower.Text = MaxPower
        txtMaxPower2.Text = MaxPower2
        Label10.Text = MaxX2
        Label14.Text = MaxY2
        txtScanTime.Text = (GetTickCount - t1) * 0.001
        txtYDif.Text = Format((OutMaxY - OutMaxY2) * 1000, "0.0")
        Scan = False
        ' MsgBox("ok1")
        If bFindThreshold = True Then 'bFindThreshold = True And 
            'MsgBox("1")
            AxisAbsMove("X", InputX, InMaxX)
            AxisAbsMove("Y", InputY, InMaxY)

            AxisAbsMove("X", OutputX, OutMaxX)
            AxisAbsMove("Y", OutputY, OutMaxY)


        Else

            If bFindThreshold2 = True Then
                'MsgBox("2")
                AxisAbsMove("X", InputX, InMaxX2)
                AxisAbsMove("Y", InputY, InMaxY2)

                AxisAbsMove("X", OutputX, OutMaxX2)
                AxisAbsMove("Y", OutputY, OutMaxY2)

            Else

                If MaxPower > 0.2 Or MaxPower2 > 0.2 Then
                    If MaxPower > MaxPower2 Then

                        HillClimb.HillClimbAlign("INPUTA", 20, 0.002, 2, 2, 0.005, False)
                        HillClimb.HillClimbAlign("ChA", 20, 0.002, 2, 2, 0.005, False)
                    Else
                        AxisAbsMove("X", XChannel, MaxX2)
                        AxisAbsMove("Y", YChannel, MaxY2)

                        HillClimb.HillClimbAlign("INPUTB", 20, 0.002, 2, 2, 0.005, False)  '0.2
                        HillClimb.HillClimbAlign("ChB", 20, 0.002, 2, 2, 0.005, False)

                    End If
                Else '移到初始位置
                    AxisAbsMove("X", InputX, inx0)
                    AxisAbsMove("Y", InputY, iny0)

                    AxisAbsMove("x", OutputX, outx0)
                    AxisAbsMove("y", OutputY, outy0)
                End If
            End If
        End If

    End Sub


    'Private Sub BalanceR(ByVal dStep As Double, ByVal checkpoints As Integer) '平衡R '
    '    Dim bMoveFlag As Integer
    '    Dim dpowerA, dpowerB, dpowerDiff, dMinpoerdiff As Double
    '    Dim dOldCheckPoints As Integer
    '    Dim bIsRight(1) As Boolean '两个方向，当往一个方向运动时功率差变小则值为true，当都为false时跳出循环

    '    Dim nDelay As Integer
    '    Dim nMinPowerDiffPos As Double

    '    '初始化
    '    nDelay = 20
    '    'dMinpoerdiff = 100
    '    dOldCheckPoints = checkpoints
    '    bIsRight(0) = True
    '    bIsRight(1) = True
    '    bMoveFlag = -1

    '    ESP300.ReadPowerMeter("A", dpowerA)
    '    ESP300.ReadPowerMeter("B", dpowerB)
    '    dMinpoerdiff = Math.Abs(dpowerA - dpowerB)


    '    nMinPowerDiffPos = GetCurrentPos(OutputR)
    '    While (Not (bIsRight(0) = False And bIsRight(1) = False))
    '        If g_bstop = True Then
    '            Exit While
    '        End If


    '        AxisRelativeMove("", OutputR, dStep)
    '        Sleep(nDelay)
    '        ESP300.ReadPowerMeter("A", dpowerA)
    '        ESP300.ReadPowerMeter("B", dpowerB)
    '        dpowerDiff = dpowerA - dpowerB

    '        If Math.Abs(dpowerDiff) < dMinpoerdiff Then '说明方向是对的
    '            dMinpoerdiff = Math.Abs(dpowerDiff)
    '            checkpoints = dOldCheckPoints
    '            nMinPowerDiffPos = GetCurrentPos(OutputR) '记录最佳位置
    '            If bMoveFlag > 0 Then
    '                bIsRight(1) = True
    '            Else
    '                bIsRight(0) = True
    '            End If
    '        Else '如果差距变大了，说明方向不对了，检查点数减一
    '            checkpoints = checkpoints - 1
    '        End If
    '        If checkpoints = 0 Then '如果检查点数已经减为0了
    '            dStep = -dStep
    '            AxisAbsMove("", OutputR, nMinPowerDiffPos)
    '            If bMoveFlag > 0 Then
    '                bIsRight(1) = False
    '            Else
    '                bIsRight(0) = False
    '            End If
    '            bMoveFlag = -bMoveFlag
    '            checkpoints = dOldCheckPoints
    '        End If

    '    End While
    '    AxisAbsMove("", OutputR, nMinPowerDiffPos)
    'End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim y, y1, y2 As Double
        Dim nRdiff As Double = 250 '表示输入端两个光源的间距


        Cursor = System.Windows.Forms.Cursors.WaitCursor

        dOldDiff = 100
        y1 = 100
        y2 = 100

        LinkageSearchPower()



        If bStop = True Or g_bPauseFlag = True Then Exit Sub
        If bFindThreshold = True And bFindThreshold2 = True Then

            y = CDbl(txtYDif.Text) ' y1 - y2
            '   MsgBox(y * 1000)
            If Math.Abs(y) < 5 Then
                Cursor = Cursors.Default
                GoTo end1
            End If

            '如果deltaY绝对值变大并且同号 ，表示连接错误 zbh 2012-11-1
            If Math.Abs(y) > Math.Abs(dOldDiff) And y / dOldDiff > 0 Then
                MsgBox("请检查通道 A和 B是否连接正确。")
                Cursor = Cursors.Default
                g_bAbnormalPauseFlag = True
                Exit Sub
            End If

            If y < 0 Then
                y = y + 2
            Else
                y = y - 2
            End If
            dOldDiff = y
            If Math.Abs(y) >= 5 Then
                y = y * 0.001 * 0.9

                AxisRelativeMove("", OutputR, -y * (OutputRCompensate + OutputRCompensate * Math.Abs(y) * 1000 / 100))
                AxisRelativeMove("", OutputY, -y * OutputRCompensate / OutputYcompensate)
                'ScanLenY.Text = CStr(Math.Abs(y) + 20) '"60"
                Sleep(500)
            Else
                y = y * 0.001

                AxisRelativeMove("", OutputR, -y * OutputRCompensate)
                AxisRelativeMove("", OutputY, -y * OutputRCompensate / OutputYcompensate)
                ScanLenY.Text = "50"
                Sleep(50)
            End If
        End If

end1:
        Cursor = Cursors.Default
    End Sub
End Class