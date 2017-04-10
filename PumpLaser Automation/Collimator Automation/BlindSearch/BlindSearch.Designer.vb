<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlindSearch
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMaxPower = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtScanTime = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMaxPower2 = New System.Windows.Forms.TextBox()
        Me.txtYDif = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ScanLenX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StepSizeX = New System.Windows.Forms.TextBox()
        Me.StepSizeY = New System.Windows.Forms.TextBox()
        Me.ScanLenY = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtThreshold = New System.Windows.Forms.TextBox()
        Me.txtThresholdB = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Slide1 = New System.Windows.Forms.TrackBar()
        Me.btnBalance = New System.Windows.Forms.Button()
        Me.chkGetData = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Slide1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtMaxPower)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtScanTime)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtMaxPower2)
        Me.GroupBox2.Controls.Add(Me.txtYDif)
        Me.GroupBox2.Location = New System.Drawing.Point(358, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 100)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(170, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "最大信号B"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "最大信号A"
        '
        'txtMaxPower
        '
        Me.txtMaxPower.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtMaxPower.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxPower.Location = New System.Drawing.Point(110, 29)
        Me.txtMaxPower.Name = "txtMaxPower"
        Me.txtMaxPower.Size = New System.Drawing.Size(55, 24)
        Me.txtMaxPower.TabIndex = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "时间"
        '
        'txtScanTime
        '
        Me.txtScanTime.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtScanTime.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanTime.Location = New System.Drawing.Point(258, 65)
        Me.txtScanTime.Name = "txtScanTime"
        Me.txtScanTime.Size = New System.Drawing.Size(54, 24)
        Me.txtScanTime.TabIndex = 84
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 12)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Y轴差值(um)"
        '
        'txtMaxPower2
        '
        Me.txtMaxPower2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtMaxPower2.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxPower2.Location = New System.Drawing.Point(257, 29)
        Me.txtMaxPower2.Name = "txtMaxPower2"
        Me.txtMaxPower2.Size = New System.Drawing.Size(55, 24)
        Me.txtMaxPower2.TabIndex = 96
        '
        'txtYDif
        '
        Me.txtYDif.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtYDif.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYDif.Location = New System.Drawing.Point(112, 65)
        Me.txtYDif.Name = "txtYDif"
        Me.txtYDif.Size = New System.Drawing.Size(49, 24)
        Me.txtYDif.TabIndex = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ScanLenX)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.StepSizeX)
        Me.GroupBox1.Controls.Add(Me.StepSizeY)
        Me.GroupBox1.Controls.Add(Me.ScanLenY)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtThreshold)
        Me.GroupBox1.Controls.Add(Me.txtThresholdB)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 100)
        Me.GroupBox1.TabIndex = 119
        Me.GroupBox1.TabStop = False
        '
        'ScanLenX
        '
        Me.ScanLenX.Location = New System.Drawing.Point(118, 53)
        Me.ScanLenX.Name = "ScanLenX"
        Me.ScanLenX.Size = New System.Drawing.Size(42, 21)
        Me.ScanLenX.TabIndex = 76
        Me.ScanLenX.Text = "120"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "步长(um)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "长度 (um)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "X"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Y"
        Me.Label4.Visible = False
        '
        'StepSizeX
        '
        Me.StepSizeX.Location = New System.Drawing.Point(43, 53)
        Me.StepSizeX.Name = "StepSizeX"
        Me.StepSizeX.Size = New System.Drawing.Size(43, 21)
        Me.StepSizeX.TabIndex = 74
        Me.StepSizeX.Text = "5"
        '
        'StepSizeY
        '
        Me.StepSizeY.Location = New System.Drawing.Point(42, 66)
        Me.StepSizeY.Name = "StepSizeY"
        Me.StepSizeY.Size = New System.Drawing.Size(44, 21)
        Me.StepSizeY.TabIndex = 75
        Me.StepSizeY.Text = "5"
        Me.StepSizeY.Visible = False
        '
        'ScanLenY
        '
        Me.ScanLenY.Location = New System.Drawing.Point(118, 66)
        Me.ScanLenY.Name = "ScanLenY"
        Me.ScanLenY.Size = New System.Drawing.Size(42, 21)
        Me.ScanLenY.TabIndex = 77
        Me.ScanLenY.Text = "120"
        Me.ScanLenY.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(203, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "B"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(220, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 18)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "阈值(db)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(203, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 12)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "A"
        '
        'txtThreshold
        '
        Me.txtThreshold.Location = New System.Drawing.Point(224, 34)
        Me.txtThreshold.Name = "txtThreshold"
        Me.txtThreshold.Size = New System.Drawing.Size(49, 21)
        Me.txtThreshold.TabIndex = 82
        Me.txtThreshold.Text = "-30"
        '
        'txtThresholdB
        '
        Me.txtThresholdB.Location = New System.Drawing.Point(223, 66)
        Me.txtThresholdB.Name = "txtThresholdB"
        Me.txtThresholdB.Size = New System.Drawing.Size(50, 21)
        Me.txtThresholdB.TabIndex = 91
        Me.txtThresholdB.Text = "-40"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(449, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(23, 12)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "y=0"
        Me.Label14.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(387, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 12)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "x=0"
        Me.Label10.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(270, 18)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "提示：阈值不要小于最大信号的1/4。"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(28, 65)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton2.TabIndex = 106
        Me.RadioButton2.Text = "y_p"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton4)
        Me.GroupBox4.Controls.Add(Me.RadioButton3)
        Me.GroupBox4.Location = New System.Drawing.Point(692, 168)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(90, 100)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "direction"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(28, 25)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(53, 16)
        Me.RadioButton4.TabIndex = 105
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "input"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(28, 65)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton3.TabIndex = 106
        Me.RadioButton3.Text = "output"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Location = New System.Drawing.Point(692, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(90, 100)
        Me.GroupBox3.TabIndex = 122
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "scan"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(28, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton1.TabIndex = 105
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "x_y"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(610, 393)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 32)
        Me.Button3.TabIndex = 121
        Me.Button3.Text = "联动找光"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Slide1
        '
        Me.Slide1.AutoSize = False
        Me.Slide1.Location = New System.Drawing.Point(21, 352)
        Me.Slide1.Name = "Slide1"
        Me.Slide1.Size = New System.Drawing.Size(663, 30)
        Me.Slide1.TabIndex = 115
        Me.Slide1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'btnBalance
        '
        Me.btnBalance.Location = New System.Drawing.Point(390, 392)
        Me.btnBalance.Name = "btnBalance"
        Me.btnBalance.Size = New System.Drawing.Size(76, 32)
        Me.btnBalance.TabIndex = 113
        Me.btnBalance.Text = "平衡"
        Me.btnBalance.UseVisualStyleBackColor = True
        '
        'chkGetData
        '
        Me.chkGetData.AutoSize = True
        Me.chkGetData.Enabled = False
        Me.chkGetData.Location = New System.Drawing.Point(28, 429)
        Me.chkGetData.Name = "chkGetData"
        Me.chkGetData.Size = New System.Drawing.Size(66, 16)
        Me.chkGetData.TabIndex = 112
        Me.chkGetData.Text = "GetData"
        Me.chkGetData.UseVisualStyleBackColor = True
        Me.chkGetData.Visible = False
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(505, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 32)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "关闭"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(162, 392)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(76, 32)
        Me.btnStart.TabIndex = 109
        Me.btnStart.Text = "扫描"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(274, 392)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 32)
        Me.Button2.TabIndex = 111
        Me.Button2.Text = "停止"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BlindSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 429)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Slide1)
        Me.Controls.Add(Me.btnBalance)
        Me.Controls.Add(Me.chkGetData)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Button2)
        Me.Name = "BlindSearch"
        Me.Text = "输出端找光"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Slide1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMaxPower As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtScanTime As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMaxPower2 As System.Windows.Forms.TextBox
    Friend WithEvents txtYDif As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ScanLenX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StepSizeX As System.Windows.Forms.TextBox
    Friend WithEvents StepSizeY As System.Windows.Forms.TextBox
    Friend WithEvents ScanLenY As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtThreshold As System.Windows.Forms.TextBox
    Friend WithEvents txtThresholdB As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    'Friend WithEvents yCursor2 As NationalInstruments.UI.XYCursor
    'Friend WithEvents WaveformPlot1 As NationalInstruments.UI.WaveformPlot
    'Friend WithEvents XAxis1 As NationalInstruments.UI.XAxis
    'Friend WithEvents YAxis1 As NationalInstruments.UI.YAxis
    Friend WithEvents Slide1 As System.Windows.Forms.TrackBar
    'Friend WithEvents WaveformPlot2 As NationalInstruments.UI.WaveformPlot
    'Friend WithEvents WaveformGraph1 As NationalInstruments.UI.WindowsForms.WaveformGraph
    'Friend WithEvents yCursor1 As NationalInstruments.UI.XYCursor
    Friend WithEvents btnBalance As System.Windows.Forms.Button
    Friend WithEvents chkGetData As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
