Public Class 流程编辑

    Private Sub 流程编辑_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x, y As Integer
        x = My.Computer.Screen.Bounds.Height / 2 - Me.Size.Height / 2
        y = My.Computer.Screen.Bounds.Width / 2 - Me.Size.Width / 2
        Me.SetDesktopLocation(y, x)
    End Sub

    

    Private Sub tsmi_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_Open.Click
        OpenFile.InitialDirectory = ProductDir.FullName
        If Not OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then Return
        lab_FileName.Text = OpenFile.FileName
        Dim loadSpec As New UserFlow
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(loadSpec, New UserFlow, OpenFile.FileName) Then
            FlowGrid.SelectedObject = loadSpec
        End If
    End Sub

    Private Sub tsmi_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_Save.Click
        SaveFile.InitialDirectory = ProductDir.FullName
        If SaveFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        tsmi_Save.Enabled = False
        lab_FileName.Text = SaveFile.FileName
        If System.IO.File.Exists(SaveFile.FileName) Then System.IO.File.Delete(SaveFile.FileName)
        Dim SaveSpec As New UserFlow
        SaveSpec = FlowGrid.SelectedObject
        BrainDll.BrainUserDll.GlobalTool.ToSave(SaveSpec, SaveFile.FileName)
        tsmi_Save.Enabled = True
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As UserFlow = CType(FlowGrid.SelectedObject, UserFlow)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = a.FunctionList
        DataGridView1.Refresh()
    End Sub

    Private Sub 新建档案ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新建档案ToolStripMenuItem.Click
        FlowGrid.SelectedObject = New UserFlow
    End Sub
End Class