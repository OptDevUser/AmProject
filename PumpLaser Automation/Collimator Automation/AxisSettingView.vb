Public Class AxisSettingView
    Private _AxisDeltail As New AxisInfo
    Public ReadOnly Property AxisDeltail As AxisInfo
        Get
            Return _AxisDeltail
        End Get
    End Property
    Sub New(ByVal TestObj As AxisInfo, Optional FunctionName As FlowFunctionlist.UerFuntion = FlowFunctionlist.UerFuntion.移动轴)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        _AxisDeltail = TestObj
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        PerShowFrm(FunctionName)

    End Sub
    Sub PerShowFrm(FunctionName As FlowFunctionlist.UerFuntion)
        Select Case FunctionName
            Case FlowFunctionlist.UerFuntion.PD对准
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                '移动速度
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label5.Enabled = False
                MovePos.Enabled = False
                Label3.Enabled = False
                cbMoveDir.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False
                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False
                Label14.Enabled = True
                Label14.Text = "指标"
                TextBox3.Enabled = True
            Case FlowFunctionlist.UerFuntion.GoReferenceFile
                DialogResult = DialogResult.Cancel
                Me.Enabled = False
                Button2.Enabled = True
            Case FlowFunctionlist.UerFuntion.SaveReferenceFile
                DialogResult = DialogResult.Cancel
                Me.Enabled = False
                Button2.Enabled = True

            Case FlowFunctionlist.UerFuntion.改变气动元件状态
                DialogResult = DialogResult.Cancel
                Me.Enabled = False
                Button2.Enabled = True
            Case FlowFunctionlist.UerFuntion.盲扫
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                '移动速度
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label5.Enabled = False
                MovePos.Enabled = False
                Label3.Enabled = False
                cbMoveDir.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False


                Label10.Enabled = False
                TextBox1.Enabled = False
                Label6.Enabled = False
                MovePicth.Enabled = False
                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                'Case FlowFunctionlist.UerFuntion.校准光路
                '    '移动模式
                '    Label2.Enabled = False
                '    cbMoveMode.Enabled = False
                '    '移动速度
                '    Label4.Enabled = False
                '    MoveSpeed.Enabled = False
                '    Label5.Enabled = False
                '    MovePos.Enabled = False
                '    Label3.Enabled = False
                '    cbMoveDir.Enabled = False
                '    Label15.Enabled = False
                '    ComboBox2.Enabled = False
                '    Label12.Enabled = False
                '    ComboBox1.Enabled = False
                '    Label13.Enabled = False
                '    BlindSearchMaxPostion.Enabled = False
                '    Label14.Enabled = False
                '    TextBox3.Enabled = False
            Case FlowFunctionlist.UerFuntion.移动轴
                Label10.Enabled = False
                TextBox1.Enabled = False
                Label6.Enabled = False
                MovePicth.Enabled = False
                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False
                Label14.Enabled = False
                TextBox3.Enabled = False
                Label9.Enabled = False
                Label8.Enabled = False
                PowerDelate.Enabled = False
                cbChannel.Enabled = False
            Case FlowFunctionlist.UerFuntion.移动轴使用文件路径
                DialogResult = DialogResult.Cancel
                Me.Enabled = False
                Button2.Enabled = True
            Case FlowFunctionlist.UerFuntion.用户提示
                DialogResult = DialogResult.Cancel
                Me.Enabled = False
                Button2.Enabled = True
            Case FlowFunctionlist.UerFuntion.找零界点
                Label10.Enabled = False
                TextBox1.Enabled = False

                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                '移动速度
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label5.Enabled = False
                MovePos.Enabled = False
                Label3.Enabled = False
                cbMoveDir.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False


                Label10.Enabled = False
                TextBox1.Enabled = False

                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False





                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False
                Label14.Text = "最大电压："
                TextBox3.Enabled = True
            Case FlowFunctionlist.UerFuntion.寻找光的临界点
                Label10.Enabled = False
                TextBox1.Enabled = False

                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                '移动速度
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label5.Enabled = True
                Label5.Text = "OffSet:"
                MovePos.Enabled = True
                Label3.Enabled = False
                cbMoveDir.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False


                Label10.Enabled = False
                TextBox1.Enabled = False

                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False





                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False

                Label14.Text = "最大偏移："

            Case FlowFunctionlist.UerFuntion.GoArryBox
                Label10.Enabled = False
                TextBox1.Enabled = False
                Label6.Enabled = True
                MovePicth.Enabled = True
                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False
                Label14.Enabled = False
                TextBox3.Enabled = False
                Label5.Text = "阵列启始位置"
                Label6.Text = "阵列间隙"
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                Label9.Enabled = False
                Label8.Enabled = False
                PowerDelate.Enabled = False
                cbChannel.Enabled = False
            Case FlowFunctionlist.UerFuntion.GetCurrentPowerMeterValue
                Label10.Enabled = False
                TextBox1.Enabled = False
                Label6.Enabled = False
                MovePicth.Enabled = False
                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                Label12.Enabled = False
                ComboBox1.Enabled = False
                Label13.Enabled = False
                BlindSearchMaxPostion.Enabled = False
                Label14.Enabled = True
                Label14.Text = "PowerMax:"
                TextBox3.Enabled = True
                Label9.Enabled = True
                Label8.Enabled = False
                PowerDelate.Enabled = False
                cbChannel.Enabled = True

                Label1.Enabled = False
                cbAxisName.Enabled = False
                Label10.Enabled = False
                TextBox1.Enabled = False

                Label11.Enabled = False
                TextBox2.Enabled = False
                CheckBox1.Enabled = False
                '移动模式
                Label2.Enabled = False
                cbMoveMode.Enabled = False
                '移动速度
                Label4.Enabled = False
                MoveSpeed.Enabled = False
                Label5.Enabled = False
                MovePos.Enabled = False
                Label3.Enabled = False
                cbMoveDir.Enabled = False
                Label15.Enabled = False
                ComboBox2.Enabled = False
        End Select
    End Sub
    Private Sub AxisSettingView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  PropertyGrid1.SelectedObject = _AxisDeltail
    
        For i As Int16 = 0 To 7
            cbAxisName.Items.Add(Ini.GetINIValue("Axis", "Axis" & i.ToString, IniFile))
        Next

        cbChannel.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.ChannelName)())
        cbMoveDir.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.MoveDir)())
        cbMoveMode.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.MoveMode)())
        ComboBox2.Items.AddRange(BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of AxisInfo.SpeedMode)())
        cbAxisName.SelectedIndex = _AxisDeltail.AxisNo
        cbChannel.Text = _AxisDeltail.Channel.ToString
        cbMoveDir.Text = _AxisDeltail.Dir.ToString
        cbMoveMode.Text = _AxisDeltail._MoveMode.ToString
        MovePicth.Text = _AxisDeltail.Picth
        MoveSpeed.Text = _AxisDeltail.Speed
        PowerDelate.Text = _AxisDeltail.PowerDelate
        MovePos.Text = _AxisDeltail.Plus
        cbuseAxis.SelectedIndex = IIf(_AxisDeltail.IsUsedAxis, 0, 1)
        ComboBox2.SelectedIndex = _AxisDeltail.ModeSpeed
        TextBox1.Text = _AxisDeltail.Recursion
        TextBox2.Text = _AxisDeltail.PicthCount
        BlindSearchMaxPostion.Text = _AxisDeltail.BlindSearchRang
        CheckBox1.Checked = _AxisDeltail.IsNeedFouseLighr
     TextBox3 .Text=_AxisDeltail.PowerMax
        ComboBox1.SelectedIndex = IIf(_AxisDeltail.IsUsedBlindSearch, 0, 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c0 As AxisInfo.AxisNoType
        [Enum].TryParse(cbAxisName.Text, c0)
        If cbAxisName.SelectedIndex <> -1 Then
            _AxisDeltail.AxisNo = cbAxisName.SelectedIndex
        End If
        Dim c As AxisInfo.ChannelName
        [Enum].TryParse(cbChannel.Text, c)
        _AxisDeltail.Channel = c
        Dim c1 As AxisInfo.MoveDir
        [Enum].TryParse(cbMoveDir.Text, c1)
        _AxisDeltail.Dir = c1
        Dim c2 As AxisInfo.MoveMode
        [Enum].TryParse(cbMoveMode.Text, c2)
        _AxisDeltail._MoveMode = c2
        _AxisDeltail.Picth = MovePicth.Text
        _AxisDeltail.Speed = MoveSpeed.Text
        _AxisDeltail.PowerDelate = PowerDelate.Text
        _AxisDeltail.Plus = MovePos.Text
        _AxisDeltail.IsUsedAxis = IIf(cbuseAxis.SelectedIndex = 0, True, False)
        _AxisDeltail.Recursion = TextBox1.Text
        _AxisDeltail.PicthCount = TextBox2.Text
        _AxisDeltail.BlindSearchRang = BlindSearchMaxPostion.Text
        _AxisDeltail.PowerMax = TextBox3.Text
        _AxisDeltail.IsUsedBlindSearch = IIf(ComboBox1.SelectedIndex = 0, True, False)
        _AxisDeltail.IsNeedFouseLighr = CheckBox1.Checked
        _AxisDeltail.ModeSpeed = ComboBox2.SelectedIndex
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class