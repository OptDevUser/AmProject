Imports System.ComponentModel
Public Class AxisContorl
    Public WriteOnly Property ContorlEnable As Boolean
        Set(ByVal value As Boolean)
            Timer1.Enabled = value
        End Set
    End Property
    ' 轴号 、 轴名称
    Private _AxisName As String = "0"
    <Browsable(True)>
    Public Property AxisName As String
        Get
            Return lbAxisName.Text
        End Get
        Set(ByVal value As String)
            _AxisName = value
            lbAxisName.Text = _AxisName
            If _AxisName.Contains("R") Then
                Label1.Text = "度"
            End If
            If _AxisName.Contains("Yaw") Then
                Label1.Text = "度"
            End If
            If _AxisName.Contains("Picth") Then
                Label1.Text = "度"
            End If

        End Set
    End Property
    Private _AxisIndex As Integer = 0
    Public Property AxisIndex As Integer
        Get
            Return _AxisIndex
        End Get
        Set(ByVal value As Integer)
            _AxisIndex = value
        End Set
    End Property
    ' 实时刷新轴 信息： 极限文字，紧急停止 | 是否机械原点 | 位置
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If IMC._IMCCardInformation.Count > 0 Then
            Try
                If IMC._IMCCardInformation(_AxisIndex).ErrorMessage = "16" Then
                    lbError.Text = "紧急停止"
                Else
                    If IMC._IMCCardInformation(_AxisIndex).ErrorMessage = "3" Then
                        lbError.Text = "正负极限异常"
                    Else
                        If IMC._IMCCardInformation(_AxisIndex).ErrorMessage = "1" Then
                            lbError.Text = "正极限亮"
                        Else
                            If IMC._IMCCardInformation(_AxisIndex).ErrorMessage = "2" Then
                                lbError.Text = "负极限亮"
                            Else
                                lbError.Text = "正常"
                            End If
                        End If
                    End If

                End If
                '? IsHome 是机械原点， 还是开关原点
                lbOrg.BackColor = CType(IIf(IMC._IMCCardInformation(_AxisIndex).IsHome, Color.Green, Color.Red), Color)

                btn_plm.Enabled = Not IMC._IMCCardInformation(_AxisIndex).PLM
                btn_nlm.Enabled = Not IMC._IMCCardInformation(_AxisIndex).NLM
                lbPos.Text = IMC._IMCCardInformation(_AxisIndex).Postion.ToString
                'If _AxisName.Contains("R") Then
                '    lbPos.Text &= "度"
                'Else
                '    lbPos.Text &= "um"
                'End If
            Catch ex As Exception

            End Try

        End If

    End Sub
    Public Sub SetTimerInter()

    End Sub
    ' cb状态、显示文字 
    '? gansha
    Private _Cbtxt As String = ""
    Public Property SetCbtxt() As String
        Get
            If _Cbtxt = "" Then
                Return "0"
            End If
            Return _Cbtxt
        End Get
        Set(ByVal value As String)
            _Cbtxt = value
            cbPostion.Text = value
        End Set
    End Property
    Private _cbstatus As Boolean
    Public Property cbstatus As Boolean
        Get
            Return cbPostion.Checked
        End Get
        Set(ByVal value As Boolean)
            _cbstatus = value
            cbPostion.Checked = value
        End Set
    End Property
    ' 排序号
    '? gansha
    Public _OrderIndex As Integer
    Public Property OrderIndex As Integer
        Get
            Return Convert.ToInt32(TextBox1.Text)
        End Get
        Set(ByVal value As Integer)
            _OrderIndex = value
            TextBox1.Text = value
        End Set
    End Property
    Private Sub AxisContorl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BrainDll.BrainUserDll.GlobalTool.ChangeControlForm(lbOrg, BrainDll.BrainUserDll.GlobalTool.Shape.Circle)
        AddHandler lbPos.MouseWheel, AddressOf TxtMouseWheel
    End Sub
    ' 滚动 驱动 电机 移动
    Private Sub TxtMouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Delta > 0 Then
            IMC.MoveVel(AxisIndex, 1 * Convert.ToDouble((txtoffset.Text)))
        Else
            IMC.MoveVel(AxisIndex, -1 * Convert.ToDouble((txtoffset.Text)))
        End If

    End Sub
    ' 清除 轴 状态
    Private Sub BtnRest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            cIMCHandle.IMC_SetParam16(IMC._IMCCardInformation(_AxisIndex).CardHandle, cIMCHandle.errorLoc, 0, IMC._IMCCardInformation(_AxisIndex).AxisNo, cIMCHandle.TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
        Catch ex As Exception

        End Try

    End Sub
    ' 去 HOME
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
       
            IMC.HandleHome(New HomeParameter(_AxisIndex)) = True


    End Sub
    Public Sub Home()
        IMC.HandleHome(New HomeParameter(_AxisIndex)) = True
    End Sub

    Private Sub btn_nlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nlm.Click
        Try
            IMC.MoveVel(AxisIndex, -1 * Convert.ToDouble((txtoffset.Text)))
        Catch ex As Exception
            MessageBox.Show("参数输入有误")
        End Try


    End Sub
    ' 回到0点
    Public Sub GoToZero()
        IMC.MoveAbs(AxisIndex, 0)
    End Sub
    ' 》
    Private Sub btn_plm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plm.Click
        Try
            IMC.MoveVel(AxisIndex, 1 * Convert.ToDouble((txtoffset.Text)))
        Catch ex As Exception
            MessageBox.Show("参数输入有误")
        End Try


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbPostion.Text = lbPos.Text
    End Sub
    ' 定位用户需要 的地方
    Private Sub lbPos_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbPos.MouseDoubleClick
        Dim TargetPos As String = InputBox("请输入绝对位置坐标")
        Try
            IMC.MoveAbs(AxisIndex, Convert.ToDouble((TargetPos)))
        Catch ex As Exception

        End Try

    End Sub
End Class
