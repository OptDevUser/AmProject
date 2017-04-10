Public Class IOControl1
    Public Lb As New List(Of Button)
    Public ShowIO As New List(Of Button)
    Public Sub IntialView()
        Try

            BrainDll.BrainUserDll.GlobalTool.ToTryLoad(Of IOSetting)(IOSetingIni, New IOSetting, IOSettingfile)
            Dim ColIndex As Integer
            Dim RowIndex As Integer
            Dim TrayCol As Integer = 2
            Dim TrayRow As Integer = 2
            Dim Tmp As String = ""
            Tmp = Ini.GetINIValue("FormSetting", "Row", IniFile)
            If Tmp = "" Then
                Ini.WriteINIValue("FormSetting", "Row", TrayRow, IniFile)
            Else
                TrayRow = Tmp
            End If
            Tmp = Ini.GetINIValue("FormSetting", "Colunm", IniFile)
            If Tmp = "" Then
                Ini.WriteINIValue("FormSetting", "Colunm", TrayCol, IniFile)
            Else
                TrayCol = Tmp
            End If
            TabPage1.Controls.Clear()
            Dim lblMagnetResult(,) As Button
            Dim Lb As New List(Of Button)
            ReDim lblMagnetResult(TrayRow, TrayCol)

            For ColIndex = 1 To TrayCol
                For RowIndex = 1 To TrayRow
                    lblMagnetResult(RowIndex, ColIndex) = New Button
                    lblMagnetResult(RowIndex, ColIndex).Size = New Size(50, 50)
                    lblMagnetResult(RowIndex, ColIndex).Parent = TabPage1
                    lblMagnetResult(RowIndex, ColIndex).SetBounds(Convert.ToInt16(1 + (TabPage1.Width / TrayRow * (RowIndex - 1))), Convert.ToInt32(+(TabPage1.Height / TrayCol * (ColIndex - 1))), Convert.ToInt32(((TabPage1.Width / TrayRow) - 10)), Convert.ToInt32(((TabPage1.Height / TrayCol) - 10)))
                    lblMagnetResult(RowIndex, ColIndex).BackColor = Color.DarkGray
                    '     lblMagnetResult(RowIndex, ColIndex).b = BorderStyle.FixedSingle
                    lblMagnetResult(RowIndex, ColIndex).TextAlign = ContentAlignment.MiddleCenter
                    If TrayRow > 7 Or TrayCol > 7 Then
                        lblMagnetResult(RowIndex, ColIndex).Font = New Font("微软雅黑", 10, FontStyle.Underline) '(lblMagnetResult(RowIndex, ColIndex).Size.Height * lblMagnetResult(RowIndex, ColIndex).Size.Width / 10)
                    Else
                        lblMagnetResult(RowIndex, ColIndex).Font = New Font("微软雅黑", 10, FontStyle.Underline)
                    End If
                    AddHandler lblMagnetResult(RowIndex, ColIndex).Click, AddressOf lbClick
                    Try
                        lblMagnetResult(RowIndex, ColIndex).Tag = TrayRow * (ColIndex - 1) + RowIndex - 1
                        lblMagnetResult(RowIndex, ColIndex).Text = IOSetingIni.IOList(TrayRow * (ColIndex - 1) + RowIndex - 1).IOName
                    Catch ex As Exception
                        lblMagnetResult(RowIndex, ColIndex).Tag = (TrayRow * (ColIndex - 1) + RowIndex - 1).ToString
                        lblMagnetResult(RowIndex, ColIndex).Text = "None"
                    End Try
                    lblMagnetResult(RowIndex, ColIndex).Visible = False
                    Lb.Add(lblMagnetResult(RowIndex, ColIndex))
                Next
            Next

            For i As Integer = 0 To IOSetingIni.IOList.Count - 1
                Lb(i).Visible = True
                Lb(i).FlatStyle = FlatStyle.Standard
            Next
            ShowIO = Lb
            Timer1.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
    Public Sub lbClick(sender As Object, e As EventArgs)
        Dim lb As Button = CType(sender, Button)
        Dim Index As Integer = IOSetingIni.IOList(lb.Tag).IOIndex - 1
        System.Threading.Thread.Sleep(1)
        If lb.BackColor = Color.Red Then
            IMC.WriteOut(Index, 0) = True
            lb.BackColor = Color.Green
        Else
            IMC.WriteOut(Index, 0) = False
            lb.BackColor = Color.Red
        End If
    End Sub
    Private Sub IOControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IntialView()
    End Sub

    Private Sub IOControl1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        '  IntialView()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If MainForm.AutoRun = False Then
        '    Try
        '        For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
        '            ShowIO(i).BackColor = IIf(IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0), Color.Green, Color.Red)
        '        Next
        '    Catch ex As Exception

        '    End Try

        'End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If IsRefreshIOStatus = True Then
            Try
                For i As Int16 = 0 To IOSetingIni.IOList.Count - 1
                    ShowIO(i).BackColor = IIf(IMC.WriteOut(IOSetingIni.IOList(i).IOIndex - 1, 0), Color.Green, Color.Red)
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
