Public Class ContorlSetting
    Private CurrentAxisID As Integer = 0
    Public TmpAxisInitalParameter As cAxisParameter = New cAxisParameter
    Private Sub ContorlSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Int16 = 0 To IMC._IMCCardInformation.Count - 1
            If Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile) = "" Then
                ComboBox1.Items.Add(i)
            Else
                ComboBox1.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
            End If

        Next
        PropertyGrid1.SelectedObject = TmpAxisInitalParameter
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CurrentAxisID = ComboBox1.SelectedIndex
        AxisInitalPara.AxisInitalParameter(CurrentAxisID).AxisNo = CurrentAxisID
        TmpAxisInitalParameter = AxisInitalPara.AxisInitalParameter(CurrentAxisID)
        BrainDll.BrainUserDll.GlobalTool.ToSave(Of AxisParameter)(AxisInitalPara, AxisParameterfile)
        PropertyGrid1.SelectedObject = Nothing
        PropertyGrid1.SelectedObject = TmpAxisInitalParameter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AxisInitalPara.AxisInitalParameter(CurrentAxisID) = PropertyGrid1.SelectedObject
        BrainDll.BrainUserDll.GlobalTool.ToSave(Of AxisParameter)(AxisInitalPara, AxisParameterfile)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class