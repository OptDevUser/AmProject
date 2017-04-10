<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 回原点编辑
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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
        Me.txt_Home_Speed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbHomeDir = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbAxisName = New System.Windows.Forms.Label()
        Me.cbAxisName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.listView1 = New System.Windows.Forms.ListView()
        Me.txt_Home_TimeOut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_Home_Speed
        '
        Me.txt_Home_Speed.Location = New System.Drawing.Point(248, 59)
        Me.txt_Home_Speed.Name = "txt_Home_Speed"
        Me.txt_Home_Speed.Size = New System.Drawing.Size(111, 21)
        Me.txt_Home_Speed.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "回原点速度："
        '
        'cbHomeDir
        '
        Me.cbHomeDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHomeDir.FormattingEnabled = True
        Me.cbHomeDir.Location = New System.Drawing.Point(83, 56)
        Me.cbHomeDir.Name = "cbHomeDir"
        Me.cbHomeDir.Size = New System.Drawing.Size(74, 20)
        Me.cbHomeDir.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "回原点方向："
        '
        'lbAxisName
        '
        Me.lbAxisName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbAxisName.Location = New System.Drawing.Point(163, 15)
        Me.lbAxisName.Name = "lbAxisName"
        Me.lbAxisName.Size = New System.Drawing.Size(192, 21)
        Me.lbAxisName.TabIndex = 33
        '
        'cbAxisName
        '
        Me.cbAxisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAxisName.FormattingEnabled = True
        Me.cbAxisName.Location = New System.Drawing.Point(83, 12)
        Me.cbAxisName.Name = "cbAxisName"
        Me.cbAxisName.Size = New System.Drawing.Size(74, 20)
        Me.cbAxisName.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "轴Ic:"
        '
        'listView1
        '
        Me.listView1.FullRowSelect = True
        Me.listView1.GridLines = True
        Me.listView1.Location = New System.Drawing.Point(12, 121)
        Me.listView1.MultiSelect = False
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(429, 174)
        Me.listView1.TabIndex = 43
        Me.listView1.UseCompatibleStateImageBehavior = False
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'txt_Home_TimeOut
        '
        Me.txt_Home_TimeOut.Location = New System.Drawing.Point(83, 94)
        Me.txt_Home_TimeOut.Name = "txt_Home_TimeOut"
        Me.txt_Home_TimeOut.Size = New System.Drawing.Size(111, 21)
        Me.txt_Home_TimeOut.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "回原点逾时："
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(377, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "增加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(377, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "修改"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(377, 92)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 48
        Me.Button3.Text = "保存"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 12)
        Me.Label3.TabIndex = 49
        '
        '回原点编辑
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 307)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_Home_TimeOut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.listView1)
        Me.Controls.Add(Me.txt_Home_Speed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbHomeDir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbAxisName)
        Me.Controls.Add(Me.cbAxisName)
        Me.Controls.Add(Me.Label6)
        Me.Name = "回原点编辑"
        Me.Text = "回原点编辑"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Home_Speed As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbHomeDir As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbAxisName As System.Windows.Forms.Label
    Friend WithEvents cbAxisName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents listView1 As System.Windows.Forms.ListView
    Friend WithEvents txt_Home_TimeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
