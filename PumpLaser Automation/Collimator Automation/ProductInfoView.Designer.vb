<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductInfoView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.保存数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.productlist = New System.Windows.Forms.ListView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.保存数据ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(567, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '保存数据ToolStripMenuItem
        '
        Me.保存数据ToolStripMenuItem.Name = "保存数据ToolStripMenuItem"
        Me.保存数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.保存数据ToolStripMenuItem.Text = "保存数据"
        '
        'productlist
        '
        Me.productlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.productlist.Font = New System.Drawing.Font("SimSun", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.productlist.ForeColor = System.Drawing.Color.Lime
        Me.productlist.FullRowSelect = True
        Me.productlist.GridLines = True
        Me.productlist.Location = New System.Drawing.Point(0, 25)
        Me.productlist.MultiSelect = False
        Me.productlist.Name = "productlist"
        Me.productlist.Size = New System.Drawing.Size(567, 444)
        Me.productlist.TabIndex = 46
        Me.productlist.UseCompatibleStateImageBehavior = False
        Me.productlist.View = System.Windows.Forms.View.Details
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "程序檔|*.csv"
        '
        'ProductInfoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 469)
        Me.Controls.Add(Me.productlist)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ProductInfoView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProductInfoView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 保存数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents productlist As System.Windows.Forms.ListView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
