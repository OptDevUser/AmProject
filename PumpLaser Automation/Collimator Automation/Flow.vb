Imports PumpLaser_Automation.FlowFunctionlist

Public Class Flow
    Private TempObj As UserFlow                 ' 用户流程 总信息
    Private _FunctionIndex As Integer = 0   ' 函数 索引
    Private _AxisSettingIndex As Integer = 0 ' Axis 索引
    Private _AirSettingIndex As Integer = 0  ' Air 索引
    Private _FileSet As New List(Of BasepositionInformation)    '轴 有关坐标信息

    ' 增加 Axis 记录行
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAxisSet.Click
        Dim Axisdetail As New AxisInfo
        Dim f As New AxisSettingView(Axisdetail, ComboBox1.SelectedIndex) ' ComboBox1 函数
        If f.ShowDialog() = DialogResult.OK Then
            Axisdetail = f.AxisDeltail
            f.Close()
        Else
            Return
        End If
        TempObj.FunctionList(_FunctionIndex).AxisSetting.Add(Axisdetail)
        DataGridView1.DataSource = TempObj.FunctionList(_FunctionIndex).AxisSetting
        DataGridView1.Refresh()
        AutoSizeColum(DataGridView1)
        RefresAir()
        RefresFrm()
        RefresAxis()
        Refreshlist()
    End Sub
    '  RefresAir | DataGridView2
    Public Sub RefresAir()
        Try
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = TempObj.FunctionList(_FunctionIndex).AirOp
            DataGridView2.Refresh()
            AutoSizeColum(DataGridView2)
        Catch ex As Exception

        End Try

    End Sub
    ' RefresFrm 《 TempObj.FunctionList(_FunctionIndex)
    Public Sub RefresFrm()
        Try
            ComboBox1.SelectedIndex = TempObj.FunctionList(_FunctionIndex).FunctionName
            CheckBox1.Checked = TempObj.FunctionList(_FunctionIndex).IsUseFilePos       ' 是否需要文件路径右边的 是否使用
            Label8.Text = TempObj.FunctionList(_FunctionIndex).Prompt                   ' 文件： 子流程的文件、。。。。
            CheckBox2.Checked = TempObj.FunctionList(_FunctionIndex).IsNeedPaus
            CheckBox3.Checked = TempObj.FunctionList(_FunctionIndex).IsJumpThisFunction
            TextBox3.Text = TempObj.FunctionList(_FunctionIndex).UserInfo
            TextBox1.Text = TempObj.FunctionList(_FunctionIndex).DelayTime.ToString
            Label7.Text = TempObj.FunctionList(_FunctionIndex).SaveFilePath
            CheckBox4.Checked = TempObj.FunctionList(_FunctionIndex).IsUsedReferenceInterface   ' 是否需要 暂存器（Reference）
            CheckBox5.Checked = TempObj.FunctionList(_FunctionIndex).IsNeedRepeat   ' 是否需要重复
            CheckBox6.Checked = TempObj.FunctionList(_FunctionIndex).IsSkipThisStep ' 是否错误 不执行
            TextBox2.Text = TempObj.FunctionList(_FunctionIndex).ProductCurrent
            TextBox4.Text = TempObj.FunctionList(_FunctionIndex).ProductVolt
            ComboBox2.SelectedIndex = TempObj.FunctionList(_FunctionIndex).IOChannel
            ComboBox3.SelectedIndex = IIf(TempObj.FunctionList(_FunctionIndex).IOStatus, 0, 1)
            CheckBox7.Checked = TempObj.FunctionList(_FunctionIndex).IsErrorRun     '错误，则运行
            TextBox4.Text = TempObj.FunctionList(_FunctionIndex).IOIndex
            NumericUpDown1.Value = TempObj.FunctionList(_FunctionIndex).RepeatConut
            If CheckBox1.Checked = False Then
                DataGridView4.Visible = False
            Else
                DataGridView4.Visible = True
                Dim a As New PositionInformation
                BrainDll.BrainUserDll.GlobalTool.ToTryLoad(a, New PositionInformation, TempObj.FunctionList(_FunctionIndex).Prompt)
                _FileSet.Clear()
                For i As Integer = 0 To a.AxisPostion.Length - 1
                    _FileSet.Add(a.AxisPostion(i))
                Next
                BrainDll.BrainUserDll.GlobalTool.ToTryLoad(a, New PositionInformation, Label8.Text)
                _FileSet.Clear()
                For i As Integer = 0 To a.AxisPostion.Length - 1
                    _FileSet.Add(a.AxisPostion(i))
                Next
                DataGridView4.DataSource = Nothing
                DataGridView4.DataSource = _FileSet
                DataGridView4.Refresh()
                AutoSizeColum(DataGridView4)
            End If
        Catch ex As Exception

        End Try

    End Sub
    ' RefresAxis
    Public Sub RefresAxis()
        Try
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = TempObj.FunctionList(_FunctionIndex).AxisSetting
            DataGridView1.Refresh()
            AutoSizeColum(DataGridView1)
        Catch ex As Exception

        End Try

    End Sub
    ' 打开文档
    Private Sub tsmi_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_Open.Click
        OpenFile.InitialDirectory = ProductDir.FullName
        If Not OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then Return
        lab_FileName.Text = OpenFile.FileName
        Dim loadSpec As New UserFlow
        If BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of UserFlow)(loadSpec, New UserFlow, OpenFile.FileName) Then
            TempObj = loadSpec
            Refreshlist()
        End If
    End Sub
    ' 刷新DataGridView3  函数列表
    Public Sub Refreshlist()
        DataGridView3.DataSource = Nothing
        DataGridView3.DataSource = TempObj.FunctionList
        DataGridView3.Refresh()
        AutoSizeColum(DataGridView3)
    End Sub
    Private Sub AutoSizeColum(ByVal dgv As DataGridView)
        Try
            'Dim Width As Integer = 0
            'For i As Integer = 0 To dgv.ColumnCount - 1
            '    dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells)
            '    Width += dgv.Columns(i).Width

            'Next
            'If Width > dgv.Size.Width Then
            '    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            'Else
            '    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'End If
            'dgv.Columns(3).Frozen = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        _FunctionIndex = DataGridView3.CurrentCell.RowIndex
        RefresAir()
        RefresAxis()
        RefresFrm()
    End Sub
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        _AirSettingIndex = DataGridView2.CurrentCell.RowIndex
    End Sub
    ' 保存文档
    Private Sub tsmi_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_Save.Click
        SaveFile.InitialDirectory = ProductDir.FullName
        If SaveFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        tsmi_Save.Enabled = False
        lab_FileName.Text = SaveFile.FileName
        If System.IO.File.Exists(SaveFile.FileName) Then System.IO.File.Delete(SaveFile.FileName)
        Dim SaveSpec As New UserFlow
        SaveSpec = TempObj
        BrainDll.BrainUserDll.GlobalTool.ToSave(SaveSpec, SaveFile.FileName)
        tsmi_Save.Enabled = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    ' load proc
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of FlowFunctionlist.UerFuntion)())
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
    End Sub

    ' 修改 当前记录 | 函数
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim c As FlowFunctionlist.UerFuntion
        [Enum].TryParse(ComboBox1.Text, c)
        TempObj.FunctionList(_FunctionIndex).FunctionName = c
        TempObj.FunctionList(_FunctionIndex).IsUseFilePos = CheckBox1.Checked
        TempObj.FunctionList(_FunctionIndex).Prompt = Label8.Text
        TempObj.FunctionList(_FunctionIndex).DelayTime = Convert.ToDouble(TextBox1.Text)
        TempObj.FunctionList(_FunctionIndex).IsNeedPaus = CheckBox2.Checked
        TempObj.FunctionList(_FunctionIndex).IsJumpThisFunction = CheckBox3.Checked
        TempObj.FunctionList(_FunctionIndex).UserInfo = TextBox3.Text.Trim(" ")
        TempObj.FunctionList(_FunctionIndex).IsUsedReferenceInterface = CheckBox4.Checked
        TempObj.FunctionList(_FunctionIndex).SaveFilePath = Label7.Text
        TempObj.FunctionList(_FunctionIndex).IsNeedRepeat = CheckBox5.Checked   ' 是否需要重复
        TempObj.FunctionList(_FunctionIndex).IsSkipThisStep = CheckBox6.Checked ' 是否错误 不执行
        TempObj.FunctionList(_FunctionIndex).ProductCurrent = TextBox2.Text
        TempObj.FunctionList(_FunctionIndex).ProductVolt = TextBox4.Text
        TempObj.FunctionList(_FunctionIndex).IsErrorRun = CheckBox7.Checked     '错误，则运行
        TempObj.FunctionList(_FunctionIndex).IOChannel = ComboBox2.SelectedIndex
        TempObj.FunctionList(_FunctionIndex).IOStatus = IIf(ComboBox3.SelectedIndex = 0, True, False)
        TempObj.FunctionList(_FunctionIndex).IOIndex = Convert.ToDouble(TextBox4.Text)
        TempObj.FunctionList(_FunctionIndex).RepeatConut = NumericUpDown1.Value
        RefresAxis()
        RefresAir()
        RefresFrm()
        Refreshlist()
    End Sub
    ' 打开气件设定
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAirSet.Click
        Dim Axisdetail As New cAirOperated
        Dim f As New AirSettingView(Axisdetail)
        If f.ShowDialog() = DialogResult.OK Then
            Axisdetail = f.AxisDeltail
        Else
            Return
        End If
        TempObj.FunctionList(_FunctionIndex).AirOp.Add(Axisdetail)
        DataGridView2.DataSource = TempObj.FunctionList(_FunctionIndex).AirOp
        DataGridView2.Refresh()
        AutoSizeColum(DataGridView2)
        RefresAir()
        RefresFrm()
        RefresAxis()
        Refreshlist()
    End Sub
    ' 删除 气件 记录
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAirSet.Click
        Try

            TempObj.FunctionList(_FunctionIndex).AxisSetting.RemoveAt(_AirSettingIndex)

            RefresAxis()
            RefresAir()
            RefresFrm()
            Refreshlist()
        Catch ex As Exception

        End Try

    End Sub
    ' 删除 轴 记录
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAxisSet.Click
        Try
            If DataGridView1.CurrentCell Is Nothing Then Return
            If DataGridView3.CurrentCell Is Nothing Then Return
            TempObj.FunctionList(_FunctionIndex).AxisSetting.RemoveAt(_AxisSettingIndex)

            RefresAxis()
            RefresAir()
            RefresFrm()
            Refreshlist()
        Catch ex As Exception

        End Try

    End Sub
    ' 点击　选择文件对话框 |　移动轴使用文件路径，　设定电源输出波形　，　增加子流程
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Select Case ComboBox1.SelectedIndex
            Case UerFuntion.移动轴使用文件路径
                If CheckBox1.Checked = False Then Return
                Dim _file As New System.Windows.Forms.OpenFileDialog
                _file.InitialDirectory = PostionDir.FullName
                _file.Filter = "*.xml|*.xml"
                If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
                Label8.Text = _file.FileName
                Dim a As New PositionInformation
                BrainDll.BrainUserDll.GlobalTool.ToTryLoad(a, New PositionInformation, Label8.Text)
                _FileSet.Clear()
                For i As Integer = 0 To a.AxisPostion.Length - 1
                    _FileSet.Add(a.AxisPostion(i))
                Next
                DataGridView4.Visible = True
                DataGridView4.DataSource = Nothing
                DataGridView4.DataSource = _FileSet
                DataGridView4.Refresh()
                AutoSizeColum(DataGridView4)
                RefresAxis()
                RefresAir()
            Case UerFuntion.设定电源输出波形
                If CheckBox1.Checked = False Then Return
                Dim _file As New System.Windows.Forms.OpenFileDialog
                '_file.InitialDirectory = PostionDir.FullName
                '_file.Filter = "*.xml|*.xml"
                If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
                Label8.Text = _file.FileName
                '   DataGridView4.Visible = True
                'DataGridView4.DataSource = Nothing
                'DataGridView4.DataSource = _FileSet
                'DataGridView4.Refresh()
                'AutoSizeColum(DataGridView4)
                RefresAxis()
                RefresAir()
            Case UerFuntion.增加子流程
                Dim _file As New System.Windows.Forms.OpenFileDialog
                _file.InitialDirectory = OpenFile.InitialDirectory = ProductDir.FullName
                _file.Filter = "*.xml|*.xml"
                If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
                Label8.Text = _file.FileName
                Dim a As New UserFlow
                BrainDll.BrainUserDll.GlobalTool.ToTryLoad(a, New UserFlow, Label8.Text)
                DataGridView4.Visible = True
                DataGridView4.DataSource = Nothing
                DataGridView4.DataSource = a.FunctionList
                DataGridView4.Refresh()
                AutoSizeColum(DataGridView4)
                RefresAxis()
                RefresAir()
        End Select




        ' TempObj.FunctionList(_FunctionIndex).FileSetting = _FileSet
        'RefresFrm()
    End Sub

    '　增加函数　
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TempObj Is Nothing Then
            TempObj = New UserFlow
        End If
        TempObj.FunctionList.Add(New FlowFunctionlist)
        Refreshlist()
    End Sub

    ' 修改轴 
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModAxisSet.Click
        Dim Axisdetail As New AxisInfo
        Try
            Axisdetail = TempObj.FunctionList(_FunctionIndex).AxisSetting(_AxisSettingIndex)
            Dim f As New AxisSettingView(Axisdetail, ComboBox1.SelectedIndex)
            If f.ShowDialog() = DialogResult.OK Then
                Axisdetail = f.AxisDeltail
            End If
            ' TempObj.FunctionList(_FunctionIndex).AxisSetting.Add(Axisdetail)
            DataGridView1.DataSource = TempObj.FunctionList(_FunctionIndex).AxisSetting
            DataGridView1.Refresh()
            AutoSizeColum(DataGridView1)
            RefresAir()
            RefresFrm()
            RefresAxis()
            Refreshlist()
        Catch ex As Exception

        End Try


    End Sub
    ' 修改器件 
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModeAirSet.Click
        Dim Axisdetail As New cAirOperated
        Axisdetail = TempObj.FunctionList(_FunctionIndex).AirOp(_AirSettingIndex)
        Dim f As New AirSettingView(Axisdetail)
        If f.ShowDialog() = DialogResult.OK Then
            Axisdetail = f.AxisDeltail
        End If
        DataGridView2.DataSource = TempObj.FunctionList(_FunctionIndex).AirOp
        DataGridView2.Refresh()
        AutoSizeColum(DataGridView2)
        RefresAir()
        RefresFrm()
        RefresAxis()
        Refreshlist()
    End Sub
    '　删除函数
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            TempObj.FunctionList.RemoveAt(_FunctionIndex)
            Refreshlist()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub 新建档案ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TempObj = New UserFlow
    End Sub
    '　增加行
    Private Sub DataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded, DataGridView2.RowsAdded, DataGridView3.RowsAdded
        Dim dgv As DataGridView = CType(sender, DataGridView)
        For i As Integer = 0 To e.RowCount - 1
            dgv.Rows(e.RowIndex + i).HeaderCell.Value = (e.RowIndex + i + 1).ToString()
        Next
    End Sub
    '　下移
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If _FunctionIndex + 1 > TempObj.FunctionList.Count Then MessageBox.Show("无法下移") : Return
        Dim _Tmp As FlowFunctionlist = TempObj.FunctionList(_FunctionIndex)
        ' Dim _Tmp1 As FlowFunctionlist = TempObj.FunctionList(_FunctionIndex + 1)
        TempObj.FunctionList(_FunctionIndex) = TempObj.FunctionList(_FunctionIndex + 1)
        TempObj.FunctionList(_FunctionIndex + 1) = _Tmp
        Refreshlist()
    End Sub
    '　上移
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If _FunctionIndex = 0 Then MessageBox.Show("无法下移") : Return
        Dim _Tmp As FlowFunctionlist = TempObj.FunctionList(_FunctionIndex)
        'Dim _Tmp1 As FlowFunctionlist = TempObj.FunctionList(_FunctionIndex - 1)


        TempObj.FunctionList(_FunctionIndex) = TempObj.FunctionList(_FunctionIndex - 1)
        TempObj.FunctionList(_FunctionIndex - 1) = _Tmp
        Refreshlist()
    End Sub

    Private Sub DataGridView3_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView3.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Select Case dgv.Columns(e.ColumnIndex).Name
            Case "DetailedPrompt"
                e.CellStyle.BackColor = Color.Red
        End Select
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            '  If DataGridView1.CurrentCell Is Nothing Then Return
            _AxisSettingIndex = DataGridView1.CurrentCell.RowIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Dim c As FlowFunctionlist.UerFuntion
        '[Enum].TryParse(ComboBox1.Text, c)
        'Select Case c
        '    Case FlowFunctionlist.UerFuntion.改变气动元件状态
        '        DataGridView4.Visible = False
        '        DataGridView1.Visible=False
        '        btnAxisSet.Visible = False
        '        ModAxisSet.Visible = False
        '        RemoveAxisSet.Visible = False
        '    Case FlowFunctionlist.UerFuntion.光纤与Lens对八度脚
        '        DataGridView4.Visible = False
        '        DataGridView2.Visible = False
        '        ModeAirSet.Visible = False
        '        RemoveAxisSet.Visible = False
        '        AddAirSet.Visible=False
        'End Select
        Try
            ComboBox2.Visible = False
            ComboBox3.Visible = False
            Select Case ComboBox1.SelectedIndex
                Case UerFuntion.PD对准
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.移动轴
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.改变气动元件状态
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    AddAirSet.Enabled = True
                    ModeAirSet.Enabled = True
                    RemoveAirSet.Enabled = True
                Case UerFuntion.GoArryBox
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.GoReferenceFile
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                Case UerFuntion.SaveReferenceFile
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.把光纤插入玻璃管
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.盲扫
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.移动轴使用文件路径
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.用户提示
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.找零界点, UerFuntion.寻找光的临界点
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.关闭电源
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.保存文件
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.打开电源
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                Case UerFuntion.GetCurrentPowerMeterValue
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = True
                    ModAxisSet.Enabled = True
                    RemoveAxisSet.Enabled = True
                Case UerFuntion.设定电源输出波形
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    Label6.Text = "参数曲线文件"
                Case UerFuntion.GetCurrentSpec
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    ComboBox2.Visible = False
                    ComboBox3.Visible = False
                    Label10.Text = "SpecCurrent："
                    Label12.Text = "Percent:"
                Case UerFuntion.判断电压
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    ComboBox2.Visible = False
                    ComboBox3.Visible = False
                    Label10.Text = "电压："
                    Label12.Text = "比率:"
                Case UerFuntion.获取板卡IO输出输入状态
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    ComboBox2.Visible = True
                    ComboBox3.Visible = True
                    Label10.Text = "I/O："
                    Label12.Text = "Index："
                Case UerFuntion.更新UV后数据
                    AddAirSet.Enabled = False
                    ModeAirSet.Enabled = False
                    RemoveAirSet.Enabled = False
                    btnAxisSet.Enabled = False
                    ModAxisSet.Enabled = False
                    RemoveAxisSet.Enabled = False
                    ComboBox2.Visible = False
                    ComboBox3.Visible = False
                    Label10.Text = "通道："
                    Label12.Visible = False ' = "Index："
                    TextBox4.Visible = False
                    GroupBox6.Text = "通道选择"

            End Select

        Catch ex As Exception


        End Try




    End Sub

    '　增加一行函数    
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        TempObj.FunctionList.Insert(_FunctionIndex, New FlowFunctionlist)
        Refreshlist()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tmp As New OutDataInfo
        Dim f As New 暂存器(tmp)
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            TempObj.FunctionList(_FunctionIndex).ReferenceInterface = tmp
            DataGridView1.DataSource = TempObj.FunctionList(_FunctionIndex).AxisSetting
            DataGridView1.Refresh()
            AutoSizeColum(DataGridView1)
            RefresAir()
            RefresFrm()
            RefresAxis()
            Refreshlist()
        Else
            Return
        End If

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        Button2.Enabled = CheckBox4.Checked
    End Sub
    '　暂存器　对应的文件
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim _file As New System.Windows.Forms.SaveFileDialog
        _file.InitialDirectory = PostionDir.FullName
        _file.Filter = "*.dat|*.dat"
        If Not _file.ShowDialog = Windows.Forms.DialogResult.OK Then Return
        Label7.Text = _file.FileName
    End Sub
End Class