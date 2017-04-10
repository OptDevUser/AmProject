'
'
'
'
Public Class AirSettingView
    Private _AxisDeltail As New cAirOperated
    Public ReadOnly Property AxisDeltail As cAirOperated
        Get
            Return _AxisDeltail
        End Get
    End Property
    Sub New(ByVal TestObj As cAirOperated)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        _AxisDeltail = TestObj
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''Dim c As cAirOperated._AirOperateitem
        '[Enum].TryParse(ComboBox1.Text, c)
        DialogResult = Windows.Forms.DialogResult.OK
        _AxisDeltail.Operateitem = ComboBox1.Text
        _AxisDeltail.OperateValue = IIf(ComboBox2.SelectedIndex = 0, True, False)
        Me.Close()
    End Sub
    Private Sub AirSettingView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of IOSetting)(IOSetingIni, New IOSetting, IOSettingfile)
        For i As Integer = 0 To IOSetingIni.IOList.Count - 1
            ComboBox1.Items.Add(IOSetingIni.IOList(i).IOName)
            ComboBox1.SelectedIndex = 0
        Next
        '  ComboBox1.Items.AddRange(Namelist.ToArray)
        'ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox1.Text = _AxisDeltail.Operateitem
        ComboBox2.SelectedIndex = IIf(_AxisDeltail.OperateValue, 0, 1)
    End Sub
End Class