Public Class 归零

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label2.Text = ESP300.ChALightPower.ToString("0.000") + ESP300.ZeroPower(0)
        'Label3.Text = ESP300.ChBlightPower.ToString("0.000") + ESP300.ZeroPower(1)
        'Label5.Text = ESP300.ChASeneor.ToString("0.000") + ESP300.ZeroPower(2)
        'Label7.Text = ESP300.ChBSensor.ToString("0.000") + ESP300.ZeroPower(3)

        Label12.Text = ESP300.ZeroPower(0)
        Label11.Text = ESP300.ZeroPower(1)
        Label10.Text = ESP300.ZeroPower(2)
        Label9.Text = ESP300.ZeroPower(3)
    End Sub
    Private Sub 归零_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case "Button1"
                ESP300.ZeroPower(0) = ESP300.ZeroPower(0) + ESP300.ChALightPower.ToString("0.000")
            Case "Button2"
                ESP300.ZeroPower(1) = ESP300.ZeroPower(1) + ESP300.ChBlightPower.ToString("0.000")
            Case "Button3"
                ESP300.ZeroPower(2) = ESP300.ZeroPower(2) + ESP300.ChASeneor.ToString("0.000")
            Case "Button4"
                ESP300.ZeroPower(3) = ESP300.ZeroPower(3) + ESP300.ChBSensor.ToString("0.000")
        End Select

    End Sub

    'Private Sub 归零_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosing
    '    Timer1.Enabled = False
    'End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class