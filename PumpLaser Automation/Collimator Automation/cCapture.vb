Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Diagnostics
Imports System.Windows.Forms
Imports DirectShowLib
Public Class cCapture

#Region "Var"
    Implements ISampleGrabberCB
    Implements IDisposable
    Private m_FilterGraph As IFilterGraph2 = Nothing
    Private s As RotateFlipType
    Private m_VidControl As IAMVideoControl = Nothing
    Private m_pinStill As IPin = Nothing
    Private m_PictureReady As ManualResetEvent = Nothing
    Private m_WantOne As Boolean = False
    Private m_videoWidth As Integer = 640
    Private m_videoHeight As Integer = 480
    Private m_stride As Integer = 24
    Private m_ipBuffer As IntPtr = IntPtr.Zero
#If DEBUG Then
    Private m_rot As DsROTEntry = Nothing
#End If
#End Region

#Region "Dll"
    <DllImport("Kernel32.dll", EntryPoint:="RtlMoveMemory")> _
    Private Shared Sub CopyMemory(ByVal Destination As IntPtr, ByVal Source As IntPtr, <MarshalAs(UnmanagedType.U4)> ByVal Length As Integer)

    End Sub
#End Region
    Public IsOpenOk As Boolean = False
    Public Function GetDevice() As List(Of String)
        Dim tmp As New List(Of String)
        Dim capDevices As DsDevice()
        capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)
        For i As Int16 = 0 To capDevices.Length - 1
            tmp.Add(i)
        Next
        Return tmp
    End Function
    Public Sub New(ByVal iDeviceNum As Integer, ByVal iWidth As Integer, ByVal iHeight As Integer, ByVal iBPP As Short, ByVal hControl As Control, ByRef device As Integer)
        Dim capDevices As DsDevice()
        capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)

        Try
            If iDeviceNum + 1 > capDevices.Length Then
                iDeviceNum = 0
            End If
        Catch ex As Exception

        End Try



        Try
            SetupGraph(capDevices(iDeviceNum), iWidth, iHeight, iBPP, hControl)

            m_PictureReady = New ManualResetEvent(False)
        Catch
            IsOpenOk = False

        End Try
        IsOpenOk = True
    End Sub
    Private Function CreateFilter(ByVal category As Guid, ByVal friendlyname As String) As IBaseFilter
        Dim source As Object = Nothing
        Dim iid As Guid = GetType(IBaseFilter).GUID
        For Each device As DsDevice In DsDevice.GetDevicesOfCat(category)
            If device.Name.CompareTo(friendlyname) = 0 Then
                device.Mon.BindToObject(Nothing, Nothing, iid, source)
                Exit For
            End If
        Next

        Return DirectCast(source, IBaseFilter)
    End Function

    Public Sub Dispose()
#If DEBUG Then
        If m_rot IsNot Nothing Then
            m_rot.Dispose()
        End If
#End If
        CloseInterfaces()
        If m_PictureReady IsNot Nothing Then
            m_PictureReady.Close()
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Try
            Dispose()
        Finally
            MyBase.Finalize()
        End Try
    End Sub
    Public Function Click() As IntPtr
        Dim hr As Integer

        m_PictureReady.Reset()
        m_ipBuffer = Marshal.AllocCoTaskMem(Math.Abs(m_stride) * m_videoHeight)

        Try
            m_WantOne = True


            If m_VidControl IsNot Nothing Then

                hr = m_VidControl.SetMode(m_pinStill, VideoControlFlags.Trigger)

                DsError.ThrowExceptionForHR(hr)
            End If

            If Not m_PictureReady.WaitOne(9000, False) Then
                Throw New Exception("Timeout waiting to get picture")
            End If
        Catch
            Marshal.FreeCoTaskMem(m_ipBuffer)
            m_ipBuffer = IntPtr.Zero
            Throw
        End Try
        Return m_ipBuffer
    End Function

    Public ReadOnly Property Width() As Integer
        Get
            Return m_videoWidth
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return m_videoHeight
        End Get
    End Property
    Public ReadOnly Property Stride() As Integer
        Get
            Return m_stride
        End Get
    End Property
    Private Sub SetupGraph(ByVal dev As DsDevice, ByVal iWidth As Integer, ByVal iHeight As Integer, ByVal iBPP As Short, ByVal hControl As Control)
        Dim hr As Integer

        Dim sampGrabber As ISampleGrabber = Nothing
        Dim capFilter As IBaseFilter = Nothing
        Dim pCaptureOut As IPin = Nothing
        Dim pSampleIn As IPin = Nothing
        Dim pRenderIn As IPin = Nothing
        m_FilterGraph = TryCast(New FilterGraph(), IFilterGraph2)
        sampGrabber = TryCast(New SampleGrabber(), ISampleGrabber)


        Try
#If DEBUG Then
            m_rot = New DsROTEntry(m_FilterGraph)
#End If

            hr = m_FilterGraph.AddSourceFilterForMoniker(dev.Mon, Nothing, dev.Name, capFilter)
            DsError.ThrowExceptionForHR(hr)
            m_pinStill = DsFindPin.ByCategory(capFilter, PinCategory.Still, 0)
            If m_pinStill Is Nothing Then
                m_pinStill = DsFindPin.ByCategory(capFilter, PinCategory.Preview, 0)
            End If
            If m_pinStill Is Nothing Then
                Dim pRaw As IPin = Nothing
                Dim pSmart As IPin = Nothing

                m_VidControl = Nothing

                Dim iSmartTee As IBaseFilter = DirectCast(New SmartTee(), IBaseFilter)

                Try
                    hr = m_FilterGraph.AddFilter(iSmartTee, "SmartTee")
                    DsError.ThrowExceptionForHR(hr)
                    pRaw = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0)
                    pSmart = DsFindPin.ByDirection(iSmartTee, PinDirection.Input, 0)

                    hr = m_FilterGraph.Connect(pRaw, pSmart)
                    DsError.ThrowExceptionForHR(hr)
                    m_pinStill = DsFindPin.ByName(iSmartTee, "Preview")
                    pCaptureOut = DsFindPin.ByName(iSmartTee, "Capture")

                    If iHeight + iWidth + iBPP > 0 Then
                        SetConfigParms(pRaw, iWidth, iHeight, iBPP)
                    End If
                Finally
                    If pRaw IsNot Nothing Then
                        Marshal.ReleaseComObject(pRaw)
                    End If
                    If pRaw Is pSmart Then
                        Marshal.ReleaseComObject(pSmart)
                    End If
                    If pRaw Is iSmartTee Then
                        Marshal.ReleaseComObject(iSmartTee)
                    End If
                End Try
            Else

                m_VidControl = TryCast(capFilter, IAMVideoControl)

                pCaptureOut = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0)

                If iHeight + iWidth + iBPP > 0 Then
                    SetConfigParms(m_pinStill, iWidth, iHeight, iBPP)
                End If
            End If

            Dim baseGrabFlt As IBaseFilter = TryCast(sampGrabber, IBaseFilter)
            ConfigureSampleGrabber(sampGrabber)
            pSampleIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0)


            Dim pRenderer As IBaseFilter = TryCast(New VideoRendererDefault(), IBaseFilter)
            hr = m_FilterGraph.AddFilter(pRenderer, "Renderer")
            DsError.ThrowExceptionForHR(hr)

            pRenderIn = DsFindPin.ByDirection(pRenderer, PinDirection.Input, 0)

            'pRenderIn = DsFindPin.
            hr = m_FilterGraph.AddFilter(baseGrabFlt, "Ds.NET Grabber")
            DsError.ThrowExceptionForHR(hr)

            If m_VidControl Is Nothing Then

                hr = m_FilterGraph.Connect(m_pinStill, pSampleIn)
                DsError.ThrowExceptionForHR(hr)


                hr = m_FilterGraph.Connect(pCaptureOut, pRenderIn)
                DsError.ThrowExceptionForHR(hr)
            Else

                hr = m_FilterGraph.Connect(pCaptureOut, pRenderIn)
                DsError.ThrowExceptionForHR(hr)

                hr = m_FilterGraph.Connect(m_pinStill, pSampleIn)
                DsError.ThrowExceptionForHR(hr)
            End If
            SaveSizeInfo(sampGrabber)
            ConfigVideoWindow(hControl)

            Dim mediaCtrl As IMediaControl = TryCast(m_FilterGraph, IMediaControl)

            hr = mediaCtrl.Run()
            DsError.ThrowExceptionForHR(hr)
        Finally
            If sampGrabber IsNot Nothing Then
                Marshal.ReleaseComObject(sampGrabber)
                sampGrabber = Nothing
            End If
            If pCaptureOut IsNot Nothing Then
                Marshal.ReleaseComObject(pCaptureOut)
                pCaptureOut = Nothing
            End If
            If pRenderIn IsNot Nothing Then
                Marshal.ReleaseComObject(pRenderIn)
                pRenderIn = Nothing
            End If
            If pSampleIn IsNot Nothing Then
                Marshal.ReleaseComObject(pSampleIn)
                pSampleIn = Nothing
            End If
        End Try
        'm_VidControl.SetMode(capFilter, VideoControlFlags.)
    End Sub

    Private Sub SaveSizeInfo(ByVal sampGrabber As ISampleGrabber)
        Dim hr As Integer

        Dim media As New AMMediaType()

        hr = sampGrabber.GetConnectedMediaType(media)
        DsError.ThrowExceptionForHR(hr)

        If (media.formatType <> FormatType.VideoInfo) OrElse (media.formatPtr = IntPtr.Zero) Then
            Throw New NotSupportedException("Unknown Grabber Media Format")
        End If

        Dim videoInfoHeader As VideoInfoHeader = DirectCast(Marshal.PtrToStructure(media.formatPtr, GetType(VideoInfoHeader)), VideoInfoHeader)
        m_videoWidth = videoInfoHeader.BmiHeader.Width
        m_videoHeight = videoInfoHeader.BmiHeader.Height
        m_stride = m_videoWidth * (videoInfoHeader.BmiHeader.BitCount / 8)

        DsUtils.FreeAMMediaType(media)
        media = Nothing
    End Sub
    Private Function HasPropertyPages(ByVal filter As IBaseFilter) As Boolean
        If filter Is Nothing Then
            Throw New ArgumentNullException("filter")
        End If

        Return (TryCast(filter, ISpecifyPropertyPages) IsNot Nothing)
    End Function

    Private Function FindCaptureDevice(ByVal iDeviceId As Integer) As IBaseFilter

        Debug.WriteLine("Start the Sub FindCaptureDevice")

        Dim hr As Integer = 0

        Dim id As Integer = 0

        Dim classEnum As ComTypes.IEnumMoniker = Nothing

        Dim moniker As ComTypes.IMoniker() = New ComTypes.IMoniker(0) {}

        Dim source As Object = Nothing

        Dim devEnum As ICreateDevEnum = CType(New CreateDevEnum, ICreateDevEnum)

        hr = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, classEnum, 0)

        Debug.WriteLine("Create an enumerator for the video capture devices : " & DsError.GetErrorText(hr))

        DsError.ThrowExceptionForHR(hr)

        Marshal.ReleaseComObject(devEnum)



        If classEnum Is Nothing Then

            Throw New ApplicationException("No video capture device was detected.\r\n\r\n" & _
                           "This sample requires a video capture device, such as a USB WebCam,\r\n" & _
                           "to be installed and working properly.  The sample will now close.")
        End If

        While (hr = classEnum.Next(moniker.Length, moniker, IntPtr.Zero))

            If hr <> 0 Then Exit While

            Dim iid As Guid = GetType(IBaseFilter).GUID

            If id = iDeviceId Then

                moniker(0).BindToObject(Nothing, Nothing, iid, source)

                Exit While

            End If

            id += 1

        End While


        Marshal.ReleaseComObject(moniker(0))

        Marshal.ReleaseComObject(classEnum)



        Return CType(source, IBaseFilter)

    End Function
    Public Function Operation() As Boolean 'Implements CameraInterface.ICamera.Operation


        '  Dim SetPage As New Form1
        'ShowPropertyPage(SetPage.Handle)
        'SetPage.Dispose()



        Return True

    End Function
    Public Sub ShowPropertyPage(ByVal hwndOwner As IntPtr)
        Dim cauuid As DsCAUUID
        Dim filterInfo As FilterInfo = Nothing
        Dim hr As Integer = 0
        Dim objs As Object()
        Dim sourceFilter As IBaseFilter = Nothing
        Try
            sourceFilter = FindCaptureDevice(0)
            If sourceFilter Is Nothing Then
                Throw New ArgumentNullException("sourceFilter")
            End If

            If HasPropertyPages(sourceFilter) Then
                hr = sourceFilter.QueryFilterInfo(filterInfo)
                DsError.ThrowExceptionForHR(hr)

                If filterInfo.pGraph IsNot Nothing Then
                    Marshal.ReleaseComObject(filterInfo.pGraph)
                End If

                hr = TryCast(sourceFilter, ISpecifyPropertyPages).GetPages(cauuid)
                DsError.ThrowExceptionForHR(hr)

                objs = New Object(0) {}
                objs(0) = sourceFilter

                NativeMethods.OleCreatePropertyFrame(hwndOwner, 0, 0, filterInfo.achName, objs.Length, objs, _
                 cauuid.cElems, cauuid.pElems, 0, 0, IntPtr.Zero)
            End If

            Marshal.ReleaseComObject(sourceFilter)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ConfigVideoWindow(ByVal hControl As Control)
        Dim hr As Integer

        Dim ivw As IVideoWindow = TryCast(m_FilterGraph, IVideoWindow)
        hr = ivw.put_Owner(hControl.Handle)
        DsError.ThrowExceptionForHR(hr)
        hr = ivw.put_WindowStyle(WindowStyle.Child Or WindowStyle.ClipChildren Or WindowStyle.ClipSiblings)
        DsError.ThrowExceptionForHR(hr)


        hr = ivw.put_Visible(OABool.[True])
        DsError.ThrowExceptionForHR(hr)

        Dim rc As Rectangle = hControl.ClientRectangle
        hr = ivw.SetWindowPosition(0, 0, rc.Right, rc.Bottom)

        DsError.ThrowExceptionForHR(hr)
    End Sub

    Private Sub ConfigureSampleGrabber(ByVal sampGrabber As ISampleGrabber)
        Dim hr As Integer
        Dim media As New AMMediaType()
        media.majorType = MediaType.Video
        media.subType = MediaSubType.RGB24
        media.formatType = FormatType.VideoInfo

        hr = sampGrabber.SetMediaType(media)
        DsError.ThrowExceptionForHR(hr)
        DsUtils.FreeAMMediaType(media)
        media = Nothing
        hr = sampGrabber.SetCallback(Me, 1)
        DsError.ThrowExceptionForHR(hr)
    End Sub

    Private Sub SetConfigParms(ByVal pStill As IPin, ByVal iWidth As Integer, ByVal iHeight As Integer, ByVal iBPP As Short)
        Dim hr As Integer
        Dim media As AMMediaType = Nothing
        Dim v As VideoInfoHeader
        Dim videoStreamConfig As IAMStreamConfig = TryCast(pStill, IAMStreamConfig)
        hr = videoStreamConfig.GetFormat(media)
        DsError.ThrowExceptionForHR(hr)
        Try
            v = New VideoInfoHeader()
            Marshal.PtrToStructure(media.formatPtr, v)
            If iWidth > 0 Then
                v.BmiHeader.Width = iWidth
            End If

            If iHeight > 0 Then
                v.BmiHeader.Height = iHeight
            End If

            If iBPP > 0 Then
                v.BmiHeader.BitCount = iBPP
            End If

            Marshal.StructureToPtr(v, media.formatPtr, False)

            hr = videoStreamConfig.SetFormat(media)
            DsError.ThrowExceptionForHR(hr)
        Finally
            DsUtils.FreeAMMediaType(media)
            media = Nothing
        End Try
    End Sub
    Private Sub CloseInterfaces()
        Dim hr As Integer

        Try
            If m_FilterGraph IsNot Nothing Then
                Dim mediaCtrl As IMediaControl = TryCast(m_FilterGraph, IMediaControl)
                hr = mediaCtrl.[Stop]()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        If m_FilterGraph IsNot Nothing Then
            Marshal.ReleaseComObject(m_FilterGraph)
            m_FilterGraph = Nothing
        End If

        If m_VidControl IsNot Nothing Then
            Marshal.ReleaseComObject(m_VidControl)
            m_VidControl = Nothing
        End If

        If m_pinStill IsNot Nothing Then
            Marshal.ReleaseComObject(m_pinStill)
            m_pinStill = Nothing
        End If
    End Sub
    Private Function SampleCB(ByVal SampleTime As Double, ByVal pSample As IMediaSample) As Integer Implements ISampleGrabberCB.SampleCB
        Marshal.ReleaseComObject(pSample)
        Return 0
    End Function
    Private Function BufferCB(ByVal SampleTime As Double, ByVal pBuffer As IntPtr, ByVal BufferLen As Integer) As Integer Implements ISampleGrabberCB.BufferCB
        Debug.Assert(BufferLen = Math.Abs(m_stride) * m_videoHeight, "Incorrect buffer length")

        If m_WantOne Then
            m_WantOne = False
            Debug.Assert(m_ipBuffer <> IntPtr.Zero, "Unitialized buffer")

            CopyMemory(m_ipBuffer, pBuffer, BufferLen)

            m_PictureReady.[Set]()
        End If

        Return 0
    End Function

    Public Sub Dispose1() Implements System.IDisposable.Dispose

    End Sub
End Class
Friend NotInheritable Class NativeMethods
    Private Sub New()
    End Sub

    <DllImport("olepro32.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
    Public Shared Function OleCreatePropertyFrame(<[In]()> ByVal hwndOwner As IntPtr, <[In]()> ByVal x As Integer, <[In]()> ByVal y As Integer, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, <[In]()> ByVal cObjects As Integer, <[In](), MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.IUnknown)> ByVal ppUnk As Object(), _
             <[In]()> ByVal cPages As Integer, <[In]()> ByVal pPageClsID As IntPtr, <[In]()> ByVal lcid As Integer, <[In]()> ByVal dwReserved As Integer, <[In]()> ByVal pvReserved As IntPtr) As Integer
    End Function

End Class

