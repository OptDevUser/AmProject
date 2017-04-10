Public Class IOSetting1

    ' 保存IO
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IOSetingIni = PropertyGrid1.SelectedObject
        BrainDll.BrainUserDll.GlobalTool.ToSave(Of IOSetting)(IOSetingIni, IOSettingfile)
        Ini.WriteINIValue("FormSetting", "Row", NumericUpDown2.Value, IniFile)
        Ini.WriteINIValue("FormSetting", "Colunm", NumericUpDown1.Value, IniFile)
    End Sub

    Private Sub IOSetting1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of IOSetting)(IOSetingIni, New IOSetting, IOSettingfile)
        PropertyGrid1.SelectedObject = IOSetingIni
        Dim TrayRow, TrayCol As Integer
        TrayRow = 2
        TrayCol = 2
        Dim Tmp As String
        Tmp = Ini.GetINIValue("FormSetting", "Row", IniFile)
        If Tmp = "" Then
            Ini.WriteINIValue("FormSetting", "Row", TrayRow, IniFile)
        Else
            TrayRow = Val(Tmp)
        End If
        Tmp = Ini.GetINIValue("FormSetting", "Colunm", IniFile)
        If Tmp = "" Then
            Ini.WriteINIValue("FormSetting", "Colunm", TrayCol, IniFile)
        Else
            TrayCol = Val(Tmp)
        End If
        NumericUpDown1.Value = TrayCol
        NumericUpDown2.Value = TrayRow
    End Sub
End Class