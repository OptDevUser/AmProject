Public Class 暂存器
    Public TmpInfo As OutDataInfo
    Sub New(tmp As OutDataInfo)

        ' This call is required by the designer.
        InitializeComponent()
        TmpInfo = tmp
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub 暂存器_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PropertyGrid1.SelectedObject = TmpInfo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TmpInfo = PropertyGrid1.SelectedObject
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class