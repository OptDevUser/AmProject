Public Class 回原点编辑

    Private Sub 回原点编辑_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x, y As Integer
        x = My.Computer.Screen.Bounds.Height / 2 - Me.Size.Height / 2
        y = My.Computer.Screen.Bounds.Width / 2 - Me.Size.Width / 2
        Me.SetDesktopLocation(y, x)
        For i As Int64 = 0 To 7
            cbAxisName.Items.Add(i)
        Next
        cbHomeDir.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of cHome.Mode)())
        listView1.Columns.Add("ID", 50, HorizontalAlignment.Left)
        listView1.Columns.Add("轴号", 50, HorizontalAlignment.Left)
        listView1.Columns.Add("轴名称", 110, HorizontalAlignment.Left)
        listView1.Columns.Add("回原点方向", 110, HorizontalAlignment.Left)
        listView1.Columns.Add("回原点速度", 110, HorizontalAlignment.Left)
        listView1.Columns.Add("回原点逾时", 110, HorizontalAlignment.Left)
        UpdataViewSetting()
    End Sub
    Private Sub UpdataViewSetting()
        listView1.Items.Clear()
        Dim lvitem As ListViewItem
        For i As Integer = 0 To HomeFlow.HomeFlow.Count - 1
            lvitem = listView1.Items.Add(i.ToString())
            lvitem.SubItems.Add(HomeFlow.HomeFlow(i).AxisIndex)
            lvitem.SubItems.Add(HomeFlow.HomeFlow(i).AxisName)
            lvitem.SubItems.Add(HomeFlow.HomeFlow(i).HomeDir.ToString)
            lvitem.SubItems.Add(HomeFlow.HomeFlow(i).HomeSpeed)
            lvitem.SubItems.Add(HomeFlow.HomeFlow(i).HomeTimeOut)
        Next
    End Sub

    ' 暂存用户编辑的HomeFlow对象
    Private Sub UpdataSetting()
        Dim lvitem As ListViewItem
        Dim HomeflowObj() As cHome
        ReDim HomeflowObj(listView1.Items.Count - 1)
        For i As Int16 = 0 To HomeflowObj.Length - 1
            HomeflowObj(i) = New cHome
        Next
        For i As Integer = 0 To listView1.Items.Count - 1
            lvitem = listView1.Items(i)
            HomeflowObj(i).AxisIndex = lvitem.SubItems(1).Text
            HomeflowObj(i).AxisName = lvitem.SubItems(2).Text
            Dim c As cHome.Mode
            [Enum].TryParse(lvitem.SubItems(3).Text, c)
            HomeflowObj(i).HomeDir = c
            HomeflowObj(i).HomeSpeed = lvitem.SubItems(4).Text
            HomeflowObj(i).HomeTimeOut = lvitem.SubItems(5).Text
        Next
        HomeFlow.HomeFlow.Clear()
        For i As Int16 = 0 To HomeflowObj.Length - 1
            HomeFlow.HomeFlow.Add(HomeflowObj(i))
        Next
        UpdataViewSetting()
    End Sub
    Private _SelectRow As Integer
    Private Sub listView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listView1.SelectedIndexChanged
        If listView1.SelectedItems.Count > 0 Then
            _SelectRow = listView1.SelectedItems(0).Index
            Dim lvitem As ListViewItem
            lvitem = listView1.Items(_SelectRow)
            Label3.Text = lvitem.SubItems(0).Text
            cbAxisName.SelectedIndex = lvitem.SubItems(1).Text
            lbAxisName.Text = lvitem.SubItems(2).Text
            Dim c As cHome.Mode
            [Enum].TryParse(lvitem.SubItems(3).Text, c)
            cbHomeDir.SelectedIndex = c
            txt_Home_Speed.Text = lvitem.SubItems(4).Text
            txt_Home_TimeOut.Text = lvitem.SubItems(5).Text
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lvitem As ListViewItem
        lvitem = listView1.Items.Add(listView1.Items.Count)
        lvitem.SubItems.Add(cbAxisName.SelectedIndex)
        lvitem.SubItems.Add(lbAxisName.Text)
        lvitem.SubItems.Add(cbHomeDir.Text)
        lvitem.SubItems.Add(txt_Home_Speed.Text)
        lvitem.SubItems.Add(txt_Home_TimeOut.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        UpdataSetting()
        BrainDll.BrainUserDll.GlobalTool.ToSave(HomeFlow, HomeFile) '保存Home至文件
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim lvitem As ListViewItem
        lvitem = listView1.Items(_SelectRow)
        'lvitem.SubItems(0).Text = Label3.Text
        lvitem.SubItems(1).Text = cbAxisName.SelectedIndex
        lvitem.SubItems(2).Text = lbAxisName.Text
        lvitem.SubItems(3).Text = cbHomeDir.Text
        lvitem.SubItems(4).Text = txt_Home_Speed.Text
        lvitem.SubItems(5).Text = txt_Home_TimeOut.Text
    End Sub
End Class