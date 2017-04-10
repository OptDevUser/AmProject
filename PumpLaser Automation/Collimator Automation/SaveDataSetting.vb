Public Class SaveDataSetting

   
    Private Sub SaveDataSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = SaveProductInfo.IsSaveAxisXPosition
        CheckBox2.Checked = SaveProductInfo.IsSaveAxisYawPosition
        CheckBox3.Checked = SaveProductInfo.IsSaveAxisZPosition
        CheckBox4.Checked = SaveProductInfo.IsSaveAxisRPosition
        CheckBox5.Checked = SaveProductInfo.IsSaveAxisPitchPosition
        CheckBox6.Checked = SaveProductInfo.IsSaveAxisYawPosition
        CheckBox7.Checked = SaveProductInfo.IsSaveAxisM_ZPosition
        CheckBox8.Checked = SaveProductInfo.IsSaveChannelPowerA
        CheckBox9.Checked = SaveProductInfo.IsSaveChannelPowerB
        CheckBox10.Checked = SaveProductInfo.IsSaveChannelSensorA
        CheckBox11.Checked = SaveProductInfo.IsSaveChannelSensorB


        TextBox1.Text = SaveProductInfo.AxisXOutName
        TextBox2.Text = SaveProductInfo.AxisYOutName
        TextBox3.Text = SaveProductInfo.AxisZOutName
        TextBox4.Text = SaveProductInfo.AxisROutName
        TextBox5.Text = SaveProductInfo.AxisPitchOutName
        TextBox6.Text = SaveProductInfo.AxisYawOutName
        TextBox7.Text = SaveProductInfo.AxisM_ZOutName
        TextBox8.Text = SaveProductInfo.ChannelPowerAName
        TextBox9.Text = SaveProductInfo.ChannelPowerBName
        TextBox10.Text = SaveProductInfo.ChannelSensorAName
        TextBox11.Text = SaveProductInfo.ChannelSensorBName
      
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveProductInfo.IsSaveAxisXPosition = CheckBox1.Checked
        SaveProductInfo.IsSaveAxisYawPosition = CheckBox2.Checked
        SaveProductInfo.IsSaveAxisZPosition = CheckBox3.Checked
        SaveProductInfo.IsSaveAxisRPosition = CheckBox4.Checked
        SaveProductInfo.IsSaveAxisPitchPosition = CheckBox5.Checked
        SaveProductInfo.IsSaveAxisYawPosition = CheckBox6.Checked
        SaveProductInfo.IsSaveAxisM_ZPosition = CheckBox7.Checked
        SaveProductInfo.IsSaveChannelPowerA = CheckBox8.Checked
        SaveProductInfo.IsSaveChannelPowerB = CheckBox9.Checked
        SaveProductInfo.IsSaveChannelSensorA = CheckBox10.Checked
        SaveProductInfo.IsSaveChannelSensorB = CheckBox11.Checked


        SaveProductInfo.AxisXOutName = TextBox1.Text
        SaveProductInfo.AxisYOutName = TextBox2.Text
        SaveProductInfo.AxisZOutName = TextBox3.Text
        SaveProductInfo.AxisROutName = TextBox4.Text
        SaveProductInfo.AxisPitchOutName = TextBox5.Text
        SaveProductInfo.AxisYawOutName = TextBox6.Text
        SaveProductInfo.AxisM_ZOutName = TextBox7.Text
        SaveProductInfo.ChannelPowerAName = TextBox8.Text
        SaveProductInfo.ChannelPowerBName = TextBox9.Text
        SaveProductInfo.ChannelSensorAName = TextBox10.Text
        SaveProductInfo.ChannelSensorBName = TextBox11.Text

        BrainDll.BrainUserDll.GlobalTool.ToSave(Of SaveDataProductInfo)(SaveProductInfo, SaveProductInfofile)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class