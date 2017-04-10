Imports CyUSB
Public Class ClsCyUsb

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private loopDevice As CyUSB.CyUSBDevice
    Private usbDevices As CyUSB.USBDeviceList
    Private inEndpoint As CyUSB.CyBulkEndPoint
    Private outEndpoint As CyUSB.CyBulkEndPoint

    Sub New()

        usbDevices = New USBDeviceList(CyConst.DEVICES_CYUSB)
        'add event
        setDevice()
    End Sub
    Private Sub setDevice()
        Try
            loopDevice = usbDevices(&H04B4, &H8613)
            '
            outEndpoint = loopDevice.EndPointOf(&H02)
            inEndpoint = loopDevice.EndPointOf(&H86)
            '
            inEndpoint.TimeOut = 1000
            outEndpoint.TimeOut = 1000
        Catch

        End Try

    End Sub
    Const XFERSIZE_OUT As Integer = 512, XFERSIZE_IN As Integer = 2048  '2048 512
    Dim outData(XFERSIZE_OUT) As Byte
    Dim inData(XFERSIZE_IN) As Byte
    Public Function ReadADValue() As Double
        Dim strSend = "68 00 97 FF 00 00 00 00 00 00"
        Dim arrSend = strSend.Split(" ")

        For II = 0 To arrSend.Length - 1
            outData(II) = Convert.ToByte(arrSend(II), 16)
        Next
        For II = 0 To inData.Length - 1
            inData(II) = 0
        Next

        Dim xferLen As Integer
        Dim bResult As Boolean
        xferLen = XFERSIZE_OUT

        bResult = outEndpoint.XferData(outData, xferLen)
        '
        If bResult Then
            bResult = inEndpoint.XferData(inData, xferLen)
            If bResult Then
                '
                Dim extraData As String = "" : Dim sValue As Integer

                '00 00 00 00 80 00 6C 2F B3 22 00 00 00 00 00 80 
                Dim iData1 As Integer = (Convert.ToInt32(inData(7)) << 8) + Convert.ToInt32(inData(6), 10)
                Dim iData2 As Integer = (Convert.ToInt32(inData(9)) << 8) + Convert.ToInt32(inData(8), 10)
                Return iData1 / 65536 * 5

                '
            End If
        End If
        Return 0

    End Function


End Class
