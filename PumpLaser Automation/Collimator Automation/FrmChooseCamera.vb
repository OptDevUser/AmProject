Public Class FrmChooseCamera
    Private _Tmp As cCapture
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Private Sub FrmChooseCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(_Tmp.GetDevice.ToArray)
    End Sub
    Public CameraIndex As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CameraIndex = ComboBox1.SelectedIndex
        DialogResult = DialogResult.OK
        me.Close
    End Sub
End Class