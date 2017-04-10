Public Class 函数说明
    Dim Flow As New FlowFunctionlist
    Private Sub 函数说明_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FunctionName() As String = BrainDll.BrainUserDll.GlobalTool.GetEnumList(Of FlowFunctionlist.UerFuntion)()
        ListBox1.Items.AddRange(FunctionName)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'Flow.FunctionName = ListBox1.SelectedIndex
        'Dim a As String = Flow.DetailedPrompt()
        'RichTextBox1.Text = ""
        'RichTextBox1.Text = a
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Ini.WriteINIValue("函数说明", ListBox1.SelectedItem, RichTextBox1.Text, IniFile)
    End Sub
End Class