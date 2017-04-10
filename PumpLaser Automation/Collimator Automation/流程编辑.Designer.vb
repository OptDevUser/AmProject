<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 流程编辑
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmi_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lab_FileName = New System.Windows.Forms.Label()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.FlowGrid = New System.Windows.Forms.PropertyGrid()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.新建档案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新建档案ToolStripMenuItem, Me.tsmi_Open, Me.tsmi_Save, Me.帮助ToolStripMenuItem, Me.tsmi_Exit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(845, 25)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmi_Open
        '
        Me.tsmi_Open.Name = "tsmi_Open"
        Me.tsmi_Open.Size = New System.Drawing.Size(68, 21)
        Me.tsmi_Open.Text = "打开档案"
        '
        'tsmi_Save
        '
        Me.tsmi_Save.Name = "tsmi_Save"
        Me.tsmi_Save.Size = New System.Drawing.Size(68, 21)
        Me.tsmi_Save.Text = "保存档案"
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        'tsmi_Exit
        '
        Me.tsmi_Exit.Name = "tsmi_Exit"
        Me.tsmi_Exit.Size = New System.Drawing.Size(44, 21)
        Me.tsmi_Exit.Text = "离开"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(474, 53)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.97674!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.02325!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lab_FileName, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(468, 33)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "檔名"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lab_FileName
        '
        Me.lab_FileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lab_FileName.AutoSize = True
        Me.lab_FileName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lab_FileName.Location = New System.Drawing.Point(83, 8)
        Me.lab_FileName.Name = "lab_FileName"
        Me.lab_FileName.Size = New System.Drawing.Size(381, 16)
        Me.lab_FileName.TabIndex = 1
        Me.lab_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "xml"
        Me.SaveFile.Filter = "程序檔|*.xml"
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "xml"
        Me.OpenFile.Filter = "程序檔|*.xml"
        '
        'FlowGrid
        '
        Me.FlowGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.FlowGrid.Location = New System.Drawing.Point(501, 28)
        Me.FlowGrid.Name = "FlowGrid"
        Me.FlowGrid.Size = New System.Drawing.Size(332, 127)
        Me.FlowGrid.TabIndex = 17
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 207)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(821, 413)
        Me.DataGridView1.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(758, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "View"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '新建档案ToolStripMenuItem
        '
        Me.新建档案ToolStripMenuItem.Name = "新建档案ToolStripMenuItem"
        Me.新建档案ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.新建档案ToolStripMenuItem.Text = "新建档案"
        '
        '流程编辑
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 632)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.FlowGrid)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "流程编辑"
        Me.Text = "流程编辑"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmi_Open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lab_FileName As System.Windows.Forms.Label
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents 帮助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowGrid As System.Windows.Forms.PropertyGrid
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents 新建档案ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
