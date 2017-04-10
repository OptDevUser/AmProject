Public Class 自动校准轴
    Dim AxisNo As Integer = 0
    Private Sub 自动校准轴_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Enabled = False
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            ComboBox1.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
            Timer1.Enabled = True
            ComboBox1.SelectedIndex = 0
            Me.Enabled = True
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Label3.Text = IMC._IMCCardInformation(AxisNo).Plus.ToString
            Label4.Text = IMC._IMCCardInformation(AxisNo).Postion.ToString
            ' Label6.Text = IMC._IMCCardInformation(AxisNo).Resoulotion
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        AxisNo = ComboBox1.SelectedIndex
        If ComboBox1.Text.Contains("Picth") Or ComboBox1.Text.Contains("Yaw") Or ComboBox1.Text.Contains("R") Then
            Label5.Text = "当前实际距离(deg):"
            Label7.Text = "当前比例(deg/Plus):"
            ' Label10.Text = "真实位移(deg):"
        Else
            Label5.Text = "当前实际距离(um):"
            Label7.Text = "当前比例(um/Plus):"
            ' Label10.Text = "真实位移(um):"
        End If
        TextBox1.Text = IMC._IMCCardInformation(AxisNo).Resoulotion
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        IMC.MoveVelPlus(AxisNo, Convert.ToDouble(TextBox1.Text))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        IMC.MoveVelPlus(AxisNo, -1 * Convert.ToDouble(TextBox1.Text))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        IMC._IMCCardInformation(AxisNo).Resoulotion = Convert.ToDouble(TextBox1.Text) ' / Convert.ToDouble(TextBox2.Text)
    End Sub
End Class