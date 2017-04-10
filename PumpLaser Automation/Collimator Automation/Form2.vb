
Public Class Form2
    Private _Channel As Integer
    Private _PowerType As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case Val(ComboBox1.Text)
            Case 1
                Label2.Text = "通道" & _Channel & "："
                Label3.Text = ESP300.ChALightPower
            Case 2
                Label2.Text = "通道" & _Channel & "："
                Label3.Text = ESP300.ChBlightPower
            Case 3
                Label2.Text = "通道" & _Channel & "："
                Label3.Text = ESP300.ChASeneor
            Case 4
                Label2.Text = "通道" & _Channel & "："
                Label3.Text = ESP300.ChBSensor
        End Select
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "1"
                _Channel = 1
                _PowerType = 1
            Case "2"
                _Channel = 2
                _PowerType = 1
            Case "3"
                _Channel = 1
                _PowerType = 0
            Case "4"
                _PowerType = 0
                _Channel = 2
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Pos As Integer = IMC._IMCCardInformation(3).Postion + 360
        Dim a As Date = Now
        IMC.MoveVel(3, 360)
        
        ESP300.OpenAddPoint(_Channel, _PowerType)
        While True
            If Math.Abs(Pos - IMC._IMCCardInformation(3).Postion) < 5 Then
                Exit While
            End If
        End While
        Button4.PerformClick()
        Dim MaxPower As Single
        Dim MinPower As Single
        Dim MaxTime As Integer
        Dim MinTime As Integer
        ESP300.ReadAddPoint(MaxPower, MinPower, MaxTime, MinTime)
        Label5.Text = MaxPower.ToString("0.000") & "    " & MaxTime
        Label6.Text = MinPower.ToString("0.000") & "    " & MinTime
        Dim b As Double = MinTime * Now.Subtract(a).TotalSeconds * 1000 / 360
        IMC.MoveAbs(3, b)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MaxPower As Single
        Dim MinPower As Single
        Dim MaxTime As Integer
        Dim MinTime As Integer
        ESP300.ReadAddPoint(MaxPower, MinPower, MaxTime, MinTime)
        Label5.Text = MaxPower
        Label6.Text = MinPower
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ESP300.ReStart()
    End Sub
    Public Enum TYPE_FIFO
        SEL_IFIFO = 0
        SEL_QFIFO
        SEL_PFIFO1
        SEL_PFIFO2
        SEL_CFIFO
    End Enum
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Speed, accspeed, deccspeed, SartSpeed As Double
        '  cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(2).CardHandle, 160, 2, 2) ',  TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
        '  cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(2).CardHandle, 158, 2, 2) ', TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
        cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(3).CardHandle, 16, Speed, 3) ', TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
        cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(3).CardHandle, 18, accspeed, 3) ', TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
        cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(3).CardHandle, 12, SartSpeed, 3) ', TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
        cIMCHandle.IMC_GetParam32(IMC._IMCCardInformation(3).CardHandle, 20, deccspeed, 3) ', TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
        TextBox2.Text = Speed
        TextBox3.Text = accspeed
        TextBox4.Text = deccspeed
        TextBox5.Text = SartSpeed
        '  MessageBox.Show(运动总时间(360 * IMC._IMCCardInformation(3).Resoulotion, accspeed, SartSpeed, deccspeed, Speed))
    End Sub

    Public Function 运动总时间(Dis As Double, acc As Integer, startspeed As Integer, dec As Integer, Speed As Integer) As Integer

        Dim acct As Integer = (Speed - startspeed) / acc
        Dim dect As Integer = (Speed - startspeed) / dec
        Dim d1 As Double = acc * acct * acct / 2
        Dim d2 As Double = dec * dect * dect / 2
        Dim t As Integer = (Dis - d1 - d2) / Speed
        Return t + acct + dect
    End Function


End Class