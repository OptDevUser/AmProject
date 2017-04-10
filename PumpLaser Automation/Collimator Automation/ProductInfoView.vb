Public Class ProductInfoView

    Private Sub ProductInfoView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProductView = Me
        productlist.Columns.Add("ID", 50, HorizontalAlignment.Center)
        productlist.Columns.Add("生产时间", 400, HorizontalAlignment.Center)
        productlist.Columns.Add("运动时间", 200, HorizontalAlignment.Center)
        productlist.Columns.Add("指标", 200, HorizontalAlignment.Center)
        productlist.Columns.Add("回损", 200, HorizontalAlignment.Center)
        productlist.Columns.Add("备注", 600, HorizontalAlignment.Center)
    End Sub

    Private Sub 保存数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存数据ToolStripMenuItem.Click
        SaveFileDialog1.InitialDirectory = "C:\"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            IO.File.AppendAllText(SaveFileDialog1.FileName, "ID" & "," & "生产时间" & "," & "运动时间" & "," & "指标" & "," & "回损" & vbNewLine, System.Text.Encoding.Default)
            For Each Item As ListViewItem In productlist.Items

                IO.File.AppendAllText(SaveFileDialog1.FileName, Item.SubItems.Item(0).Text & "," & Item.SubItems.Item(1).Text & "," & Item.SubItems.Item(2).Text & "," & Item.SubItems.Item(3).Text & "," & Item.SubItems.Item(3).Text & vbNewLine, System.Text.Encoding.Default)
            Next
        End If
       
       
    End Sub
End Class