Public Class 系统设置

    Private Sub 系统设置_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PropertyGrid1.SelectedObject = SystemIni
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SystemIni = Me.PropertyGrid1.SelectedObject
        BrainDll.BrainUserDll.GlobalTool.ToSave(Of cSystemParmater)(SystemIni, SystemIniFile)
    End Sub
End Class