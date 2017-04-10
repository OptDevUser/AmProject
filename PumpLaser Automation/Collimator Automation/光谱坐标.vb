Public Class 光谱坐标
    Dim tmp As New 光谱XY

    ' 将所有的光谱坐标 保存到 文件中Techfile.xml
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        BrainDll.BrainUserDll.GlobalTool.ToSave(Of 光谱图坐标)(TechPoint, Techfile)
    End Sub

    Private Sub 光谱坐标_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TechPoint._光谱坐标
        DataGridView1.Refresh()
    End Sub
    ' 获得当前坐标，加到光谱图坐标里面(TechPoint)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tmp.X = IMC.GetCurrentPos(4)
        System.Threading.Thread.Sleep(100)
        tmp.Y = IMC.GetCurrentPos(5)
        System.Threading.Thread.Sleep(100)
        TechPoint._光谱坐标.Add(tmp)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = TechPoint._光谱坐标
        DataGridView1.Refresh()
    End Sub
End Class