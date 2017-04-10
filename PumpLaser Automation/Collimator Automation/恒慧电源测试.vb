Public Class 恒慧电源测试

    Private Sub 恒慧电源测试_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each port As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(port)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CurVoltTool.Connect(ComboBox1.Text)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CurVoltTool.SetParameter(TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "打开" Then
            CurVoltTool.CurrentOut = True
            Button3.Text = "关闭"
        Else
            If Button3.Text = "关闭" Then
                CurVoltTool.CurrentOut = False
                Button3.Text = "打开"
            End If
        End If
    End Sub

    Private Sub 恒慧电源测试_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CurVoltTool.Disconnect()
    End Sub
End Class