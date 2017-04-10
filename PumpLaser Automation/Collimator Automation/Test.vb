Public Class Test

   
    Private Sub Test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IMC._NetCardInformation.Count > 0 Then
            For I As Int16 = 0 To IMC._NetCardInformation.Count - 1
                ComboBox1.Items.Add(IMC._NetCardInformation(I).CardInfor)
            Next
            ComboBox1.SelectedIndex = 0
            If IMC._IMCCardInformation.Count > 0 Then
                Dim OldIndex As Int16 = -1
                For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
                    ComboBox3.Items.Add(i)
                Next
                ComboBox3.SelectedIndex = 0
            End If

        End If

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Label4.Text = IMC._IMCCardInformation(ComboBox3.Text).CardID & "   " & IMC._IMCCardInformation(ComboBox3.Text).CardHandle
        AxisMove1.AxisIndex = ComboBox3.Text
        AxisMove1.AxisName = Ini.GetINIValue("Axis", "Axis" & ComboBox3.Text, IniFile)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        IMC.SearchNet()
        IMC.OpenDev()
        For i As Integer = 0 To 7
            IMC.InitalCard(i)
        Next
        Me.Refresh()
    End Sub
End Class