Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.Util
Imports Emgu.CV.Structure

Public Class Camra
    Private _Capture As Capture = Nothing
    Private _OldCapture As Capture = Nothing
    Private _captureInProgress As Boolean
    Private _IsPerView As Boolean
    Public _CenterX As Single = 20
    Public _CenterY As Single = 20
    Public IsOpenCamera As Boolean = False
    Public _CenterX1 As Single = 20
    Public _CenterY1 As Single = 20
    Dim ThreadCamera As Threading.Thread

    Private Sub Camra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboBox1.Items.Add("HORIZONTAL")
        comboBox1.Items.Add("VERTICAL")
        comboBox1.Items.Add("Non")
    End Sub
    Public Sub InitalCamera(ID As Integer)
        If IsOpenCamera = True Then Return

        CvInvoke.UseOpenCL = False
        Try
            _OldCapture = New Capture(ID)
            _Capture = _OldCapture
            ThreadCamera = New Threading.Thread(AddressOf ProcessFrame)
            ThreadCamera.IsBackground = True
            ThreadCamera.Start()

            ' Bgw.RunWorkerAsync()
            IsOpenCamera = True
            Me.SplitContainer1.Panel2Collapsed = True
        Catch ex As NullReferenceException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim distance As Double
    Dim distance1 As Double
    Private Sub ProcessFrame()
        While True
            Try
                Dim frame As Mat = New Mat()
                _Capture.Retrieve(frame, 0)
                Dim grayFrame As Mat = New Mat()
                CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray)
                Dim smallGrayFrame As Mat = New Mat()
                Dim image As Image(Of Bgr, Byte) = frame.ToImage(Of Bgr, Byte)()
                CvInvoke.PyrDown(grayFrame, smallGrayFrame)
                Dim smoothedGrayFrame As Mat = New Mat()
                CvInvoke.PyrUp(smallGrayFrame, smoothedGrayFrame)
                Dim cannyFrame As Mat = New Mat()
                CvInvoke.Canny(smoothedGrayFrame, cannyFrame, 100, 60)

                Dim cross As Cross2DF = New Cross2DF(New PointF(_CenterX, _CenterY), 100000, 100000)
                image.Draw(cross, New Bgr(Color.Red), 2)


                Dim cross1 As Cross2DF = New Cross2DF(New PointF(_CenterX + distance, _CenterY), 100000, 100000)
                image.Draw(cross1, New Bgr(Color.Green), 2)

                Dim cross3 As Cross2DF = New Cross2DF(New PointF(_CenterX + distance1, _CenterY), 100000, 100000)
                image.Draw(cross3, New Bgr(Color.Yellow), 2)
                'cross = New Cross2DF(New PointF(_CenterX, _CenterY1), image.Width, image.Height)
                'image.Draw(cross, New Bgr(Color.Yellow), 2)
                ImageBox1.Image = image
            Catch ex As Exception

            End Try
            
        End While
    End Sub

    Private Sub Bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bgw.DoWork
        While True
            ProcessFrame()
        End While
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Dim Cmd As String = comboBox1.SelectedItem.ToString()
        Select Case Cmd
            Case "HORIZONTAL"
                If _Capture IsNot Nothing Then
                    _Capture.FlipVertical = Not _Capture.FlipHorizontal
                End If
            Case "VERTICAL"
                If _Capture IsNot Nothing Then
                    _Capture.FlipVertical = Not _Capture.FlipVertical
                End If

        End Select
       
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        If (_CenterY = 0) Then Return
        If _CenterY - Convert.ToDouble(NumericUpDown2.Value) < 0 Then
            Return
        End If
        _CenterY = _CenterY - Convert.ToDouble(NumericUpDown2.Value)
    End Sub

    Private Sub button5_Click(sender As Object, e As EventArgs) Handles button5.Click
        _CenterY = _CenterY + Convert.ToDouble(NumericUpDown2.Value)
    End Sub

    Private Sub button6_Click(sender As Object, e As EventArgs) Handles button6.Click
        _CenterX = _CenterX + Convert.ToDouble(NumericUpDown2.Value)
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
        If (_CenterX = 0) Then Return
        If _CenterX - Convert.ToDouble(NumericUpDown2.Value) < 0 Then
            Return
        End If
        _CenterX = _CenterX - Convert.ToDouble(NumericUpDown2.Value)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InitalCamera(NumericUpDown1.Value)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ini.WriteINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterX", _CenterX, IniFile)
        Ini.WriteINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterY", _CenterY, IniFile)
        Ini.WriteINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "Dis", distance, IniFile)
        Ini.WriteINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "Dis1", distance1, IniFile)
    End Sub
    Public Sub LoadDefut()
        Dim Tmp As String
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterX", IniFile)
        If Tmp <> "" Then
            _CenterX = Convert.ToSingle(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterY", IniFile)
        If Tmp <> "" Then
            _CenterY = Convert.ToSingle(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "dis", IniFile)
        If Tmp <> "" Then
            distance = Convert.ToDouble(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "dis1", IniFile)
        If Tmp <> "" Then
            distance1 = Convert.ToDouble(Tmp)
        End If
        ' Label4.Text = _CenterX & "," & _CenterY
        IsLoadSpecOK = True
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Tmp As String
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterX", IniFile)
        If Tmp <> "" Then
            _CenterX = Convert.ToSingle(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "CenterY", IniFile)
        If Tmp <> "" Then
            _CenterY = Convert.ToSingle(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "dis", IniFile)
        If Tmp <> "" Then
            distance = Convert.ToDouble(Tmp)
        End If
        Tmp = Ini.GetINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "dis1", IniFile)
        If Tmp <> "" Then
            distance1 = Convert.ToDouble(Tmp)
        End If
        ' Label4.Text = _CenterX & "," & _CenterY
        IsLoadSpecOK = True
    End Sub
    Private IsFullScreen As Boolean = False
    Private Sub ImageBox1_Click(sender As Object, e As EventArgs) Handles ImageBox1.Click
    End Sub
    Private IsLoadSpecOK As Boolean = False
    Private Sub ImageBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles ImageBox1.MouseUp

        Dim Tmp As Int32 = e.Button
        Select Case Tmp
            Case 1
                _CenterX = e.X
                _CenterY = e.Y
                IsLoadSpecOK = False
            Case 2
                _CenterX1 = e.X
                _CenterY1 = e.Y
                If IsLoadSpecOK = True Then
                    Dim dIS As Double = Math.Abs(_CenterY1 - _CenterY)
                    If _CenterY > _CenterY1 Then
                        ' IMC.MoveVel(1, 10.27 * -1 * dIS)
                    Else
                        ' IMC.MoveVel(1, 10.27 * 1 * dIS)
                    End If

                End If
        End Select

    End Sub
    Public Sub FullSeree()
        If Me.SplitContainer1.Panel2Collapsed = True Then Return
        Me.SplitContainer1.Panel2Collapsed = Not IsFullScreen
        IsFullScreen = Not IsFullScreen
    End Sub
    
    Private Sub ImageBox1_DoubleClick(sender As Object, e As EventArgs) Handles ImageBox1.DoubleClick
        Me.SplitContainer1.Panel2Collapsed = Not IsFullScreen
        IsFullScreen = Not IsFullScreen
    End Sub

   

   
    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs)

        Ini.WriteINIValue("WebCamSetting", "Cam" & NumericUpDown1.Value.ToString & "Dis", distance, IniFile)
    End Sub
    Public Sub PasueCamer()
        Try
            _OldCapture.Dispose()
            IsOpenCamera = False
            If ThreadCamera IsNot Nothing Then
                ThreadCamera.Abort()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        distance = distance + NumericUpDown2.Value
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        distance = distance - NumericUpDown2.Value
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PasueCamer()
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        distance1 = distance1 - NumericUpDown2.Value
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        distance1 = distance1 + NumericUpDown2.Value
    End Sub
End Class
