Imports System.ComponentModel

Public Class AxisMove
    Private FrmThread As Threading.Thread
    '
    ' 启动 定时刷新UI上状态：
    Private Sub StartThread()
        FrmThread = New Threading.Thread(New Threading.ThreadStart(AddressOf RefreshStatus))
        FrmThread.IsBackground = True
        FrmThread.Start()
    End Sub
    '
    ' 终止 定时刷新UI上状态：
    Private Sub AbortThread()
        If FrmThread IsNot Nothing Then
            FrmThread.Abort()
        End If
    End Sub
    ' 常见组件刷新方法集合
    Private Sub ChangelbTitle(ByVal lb As Label, ByVal txt As String)
        If lb.InvokeRequired Then
            lb.BeginInvoke(New Action(Of Label, String)(AddressOf ChangelbTitle), New Object() {lb, txt})
        Else
            lb.Text = txt
        End If
    End Sub
    Private Sub ChangelbColor(ByVal lb As Label, ByVal status As Boolean)
        If lb.InvokeRequired Then
            lb.BeginInvoke(New Action(Of Label, Boolean)(AddressOf ChangelbColor), New Object() {lb, status})
        Else
            lb.BackColor = IIf(status, Color.Green, Color.Red)
        End If
    End Sub
    Private Sub ChangeckbColor(ByVal lb As CheckBox, ByVal status As Boolean)
        If lb.InvokeRequired Then
            lb.BeginInvoke(New Action(Of CheckBox, Boolean)(AddressOf ChangeckbColor), New Object() {lb, status})
        Else
            lb.BackColor = IIf(status, Color.Green, Color.Red)
        End If
    End Sub
    '
    ' 启动 定时刷新UI上状态 核心过程 ： 当前轴的错误文字，原点，极限，HOME点（马达停止）， 位置， IO输入、输出信息
    Private Sub RefreshStatus()
        While True
            Threading.Thread.Sleep(20)
            Application.DoEvents()
            If IMC._IMCCardInformation.Count > 0 Then
                ChangelbTitle(lbError, IMC._IMCCardInformation(_AxisIndex).ErrorMessage)
                ChangelbColor(lbOrg, IMC._IMCCardInformation(_AxisIndex).Org)

                ChangelbColor(lbPlm, IMC._IMCCardInformation(_AxisIndex).PLM)
                ChangelbColor(lbnlm, IMC._IMCCardInformation(_AxisIndex).NLM)
                ChangelbColor(lbhome, IMC._IMCCardInformation(_AxisIndex).MotionDone)
                ChangelbTitle(lbpos, IMC._IMCCardInformation(_AxisIndex).Postion)
                For i As Integer = 0 To 15
                    ChangelbColor(lblIoLight(i), IMC.ReadIn(i, _AxisIndex))
                    ChangeckbColor(lblIoLight1(i), IMC.WriteOut(i, _AxisIndex)) '?定时输出控制么
                Next
            End If
        End While

    End Sub
    '定义数组， 包含输入显示名称、 圆形颜色 | 输出位的文字、颜色 的所有控件
    Friend lblIoLight(30) As Label
    Friend lblIoName(30) As Label
    Friend lblIoLight1(30) As CheckBox
    Friend lblIoName1(30) As Label

    ' 控制实时刷新与否  = true | false
    Public WriteOnly Property ContorlEnable As Boolean
        Set(ByVal value As Boolean)
            If value = True Then
                StartThread()
            Else
                AbortThread()
            End If

        End Set
    End Property

    ' 轴号， 和轴的名称【x、y、z啊等等】
    Private _AxisName As String = 0
    <Browsable(True)>
    Public Property AxisName As String
        Get
            Return _AxisName
        End Get
        Set(ByVal value As String)
            _AxisName = value
            lbAxisName.Text = _AxisName
        End Set
    End Property
    Private _AxisIndex As Integer = 0
    Public Property AxisIndex As Integer
        Get
            Return _AxisIndex
        End Get
        Set(ByVal value As Integer)
            _AxisIndex = value
            lbAxisIndex.Text = _AxisIndex
        End Set
    End Property
    ' 加载LOAD， 动态加入所有输入、输出位控制开关量等
    Private Sub AxisMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer = 16
        For i As Integer = 0 To cnt - 1
            lblIoLight(i) = New Label

            lblIoLight(i).Parent = Me.GroupBox2
            lblIoLight(i).Name = "lblLight" & i.ToString("00")
            lblIoLight(i).Size = New System.Drawing.Size(20, 20)
            lblIoLight(i).Text = ""
            lblIoLight(i).BackColor = Color.Blue
            lblIoLight(i).Visible = True
            lblIoName(i) = New Label
            lblIoName(i).Parent = Me.GroupBox2
            lblIoName(i).Name = i.ToString("00")
            lblIoName(i).Size = New System.Drawing.Size(20, 20)
            lblIoName(i).Text = lblIoName(i).Name
            lblIoName(i).Visible = True
            lblIoLight(i).Location = New System.Drawing.Point(50 + 30 * i, 20)
            lblIoName(i).Location = New System.Drawing.Point(50 + i * 30, 40)
            BrainDll.BrainUserDll.GlobalTool.ChangeControlForm(lblIoLight(i), BrainDll.BrainUserDll.GlobalTool.Shape.Circle)
        Next
        For i As Integer = 0 To cnt - 1
            lblIoLight1(i) = New CheckBox
            lblIoLight1(i).Parent = Me.GroupBox1
            lblIoLight1(i).Name = i
            lblIoLight1(i).Size = New System.Drawing.Size(20, 20)
            lblIoLight1(i).Text = ""
            lblIoLight1(i).Visible = True
            AddHandler lblIoLight1(i).CheckedChanged, AddressOf CbValueChange
            lblIoName1(i) = New Label
            lblIoName1(i).Parent = Me.GroupBox1
            lblIoName1(i).Name = i.ToString("00")
            lblIoName1(i).Size = New System.Drawing.Size(20, 20)
            lblIoName1(i).Text = lblIoName(i).Name
            lblIoName1(i).Visible = True
            lblIoLight1(i).Location = New System.Drawing.Point(50 + 30 * i, 20)
            lblIoName1(i).Location = New System.Drawing.Point(50 + i * 30, 40)

        Next
        ComboBox1.SelectedIndex = 0
        ContorlEnable = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
       
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        AxisMove(-1)
        System.Threading.Thread.Sleep(100)
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub
    ' 轴移动方法： abs、vel、点动（点动偏移量、恒定点动）
    Sub AxisMove(ByVal Dir As Int16)
        If ComboBox1.Text = "" Then Return
        Select Case ComboBox1.Text
            Case "MoveAbs"
                ' IMC.MoveAbs(_AxisIndex, Convert.ToInt32(nudMove.Value) * Dir, NumericUpDown1.Value, NumericUpDown1.Value)
                IMC.MoveAbs(_AxisIndex, Convert.ToInt32(nudMove.Value) * Dir)
            Case "MoveVel"
                IMC.MoveVel(_AxisIndex, Convert.ToInt32(nudMove.Value) * Dir)
            Case "JogSpeed"
                IMC.JOG(_AxisIndex, Convert.ToInt32(NumericUpDown1.Value) * Dir, Convert.ToInt32(nudMove.Value) * Dir, JogTpye.Speed)
            Case "JogPos"
                IMC.JOG(_AxisIndex, Convert.ToInt32(NumericUpDown1.Value) * Dir, Convert.ToInt32(nudMove.Value) * Dir, JogTpye.Pos)
        End Select
    End Sub
    Public Sub CbValueChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = CType(sender, CheckBox)
        IMC.WriteOut(cb.Name, _AxisIndex) = cb.Checked
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
        AxisMove(1)
        System.Threading.Thread.Sleep(100)
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        PictureBox3.BorderStyle = BorderStyle.Fixed3D
        IMC.StopJog(_AxisIndex, JogTpye.Pos)
        IMC.StopJog(_AxisIndex, JogTpye.Speed)
        System.Threading.Thread.Sleep(100)
        PictureBox3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        PictureBox4.BorderStyle = BorderStyle.Fixed3D
        IMC.HandleHome(New HomeParameter(_AxisIndex)) = True
        System.Threading.Thread.Sleep(100)
        PictureBox4.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        PictureBox5.BorderStyle = BorderStyle.Fixed3D
        Try
            cIMCHandle.IMC_SetParam16(IMC._IMCCardInformation(_AxisIndex).CardHandle, cIMCHandle.clearLoc, -1, IMC._IMCCardInformation(_AxisIndex).AxisNo, cIMCHandle.TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
        Catch ex As Exception

        End Try

        System.Threading.Thread.Sleep(100)
        PictureBox5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '   IMC.SetVelParmater(_AxisIndex, NumericUpDown1.Value, NumericUpDown2.Value)
    End Sub


End Class
