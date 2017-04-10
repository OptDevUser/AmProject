<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AxisContorl
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lbOrg = New System.Windows.Forms.Label()
        Me.lbAxisName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbError = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnHome = New System.Windows.Forms.Button()
        Me.cbPostion = New System.Windows.Forms.CheckBox()
        Me.txtoffset = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_nlm = New System.Windows.Forms.Button()
        Me.btn_plm = New System.Windows.Forms.Button()
        Me.lbPos = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbOrg
        '
        Me.lbOrg.BackColor = System.Drawing.Color.Red
        Me.lbOrg.Location = New System.Drawing.Point(182, 4)
        Me.lbOrg.Name = "lbOrg"
        Me.lbOrg.Size = New System.Drawing.Size(21, 21)
        Me.lbOrg.TabIndex = 1
        '
        'lbAxisName
        '
        Me.lbAxisName.BackColor = System.Drawing.Color.Lime
        Me.lbAxisName.Location = New System.Drawing.Point(6, 5)
        Me.lbAxisName.Name = "lbAxisName"
        Me.lbAxisName.Size = New System.Drawing.Size(56, 19)
        Me.lbAxisName.TabIndex = 7
        Me.lbAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(337, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Error:"
        Me.Label7.Visible = False
        '
        'lbError
        '
        Me.lbError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbError.Location = New System.Drawing.Point(381, 4)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(93, 15)
        Me.lbError.TabIndex = 9
        Me.lbError.Text = "未开启"
        Me.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(133, 4)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(43, 19)
        Me.btnHome.TabIndex = 14
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'cbPostion
        '
        Me.cbPostion.AutoSize = True
        Me.cbPostion.Location = New System.Drawing.Point(70, 27)
        Me.cbPostion.Name = "cbPostion"
        Me.cbPostion.Size = New System.Drawing.Size(54, 16)
        Me.cbPostion.TabIndex = 15
        Me.cbPostion.Text = "*****"
        Me.cbPostion.UseVisualStyleBackColor = True
        '
        'txtoffset
        '
        Me.txtoffset.Location = New System.Drawing.Point(237, 5)
        Me.txtoffset.Name = "txtoffset"
        Me.txtoffset.Size = New System.Drawing.Size(43, 21)
        Me.txtoffset.TabIndex = 16
        Me.txtoffset.Text = "10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(285, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "um"
        '
        'btn_nlm
        '
        Me.btn_nlm.Location = New System.Drawing.Point(207, 7)
        Me.btn_nlm.Name = "btn_nlm"
        Me.btn_nlm.Size = New System.Drawing.Size(28, 16)
        Me.btn_nlm.TabIndex = 18
        Me.btn_nlm.Text = "-"
        Me.btn_nlm.UseVisualStyleBackColor = True
        '
        'btn_plm
        '
        Me.btn_plm.Location = New System.Drawing.Point(308, 5)
        Me.btn_plm.Name = "btn_plm"
        Me.btn_plm.Size = New System.Drawing.Size(23, 18)
        Me.btn_plm.TabIndex = 19
        Me.btn_plm.Text = "+"
        Me.btn_plm.UseVisualStyleBackColor = True
        '
        'lbPos
        '
        Me.lbPos.Location = New System.Drawing.Point(68, 2)
        Me.lbPos.Name = "lbPos"
        Me.lbPos.Size = New System.Drawing.Size(59, 21)
        Me.lbPos.TabIndex = 20
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(183, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(52, 21)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.Text = "0"
        Me.TextBox1.Visible = False
        '
        'AxisContorl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbPos)
        Me.Controls.Add(Me.btn_plm)
        Me.Controls.Add(Me.btn_nlm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtoffset)
        Me.Controls.Add(Me.cbPostion)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbAxisName)
        Me.Controls.Add(Me.lbOrg)
        Me.Name = "AxisContorl"
        Me.Size = New System.Drawing.Size(477, 44)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbOrg As System.Windows.Forms.Label
    Friend WithEvents lbAxisName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbError As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents cbPostion As System.Windows.Forms.CheckBox
    Friend WithEvents txtoffset As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_nlm As System.Windows.Forms.Button
    Friend WithEvents btn_plm As System.Windows.Forms.Button
    Friend WithEvents lbPos As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
