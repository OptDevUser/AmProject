Public Class cIniTool

#Region "Delcarations"

    Private Declare Function GetPrivateProfileSectionNames Lib "kernel32.dll" Alias "GetPrivateProfileSectionNamesA" (ByVal lpszReturnBuffer() As Byte, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Const MAX_ENTRY As Integer = 32768

    'Public LocRM As New System.Resources.ResourceManager("FUPO.ResourceStrings", GetType(AOI_MAP).Assembly)
    'Public apDIR As String = My.Application.Info.DirectoryPath

    'Public iniFILE As String = apDIR & "\FUPO.INI"  'Environ("WINDIR") & "\FUPO.INI"

#End Region

#Region "Get INI Value"

    Public Function GetINIValue(ByVal sSection As String, ByVal sVariableName As String, ByVal sFilename As String) As String
        Try
            Dim sb As New System.Text.StringBuilder(MAX_ENTRY)
            Dim intRetVal As Integer = GetPrivateProfileString(sSection, sVariableName, "", sb, MAX_ENTRY, sFilename)
            Return sb.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region "Write INI Value"

    Public Function WriteINIValue(ByVal sSection As String, ByVal sVariableName As String, ByVal sValue As String, ByVal sFilename As String) As Boolean
        Try
            WritePrivateProfileString(sSection, sVariableName, sValue, sFilename)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Delete INI Value"

    Public Function DelteINIValue(ByVal sSection As String, ByVal sVariableName As String, ByVal sFilename As String) As Boolean
        Try
            WritePrivateProfileString(sSection, sVariableName, vbNullString, sFilename)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Add INI Section"

    Public Function AddINISection(ByVal sSection As String, ByVal sFilename As String, Optional ByVal sVariableName As String = Nothing) As Boolean
        Try
            WritePrivateProfileString(sSection, sVariableName, vbNullString, sFilename)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Delete INI Section"

    Public Function DeleteINISection(ByVal sSection As String, ByVal sFileName As String) As Boolean
        Try
            WritePrivateProfileString(sSection, vbNullString, vbNullString, sFileName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Get INI Sections"

    Public Function GetINISections(ByVal sFilename As String) As ArrayList
        GetINISections = New ArrayList
        Dim bBuffer(MAX_ENTRY) As Byte
        Dim strBuffer As String
        Dim intPrevPos As Integer = 0
        Dim intLength As Integer
        Try
            intLength = GetPrivateProfileSectionNames(bBuffer, MAX_ENTRY, sFilename)
        Catch
            Exit Function
        End Try
        Dim ASCII As New System.Text.ASCIIEncoding
        If intLength > 0 Then
            strBuffer = ASCII.GetString(bBuffer)
            intLength = 0
            intPrevPos = -1
            Do
                intLength = strBuffer.IndexOf(ControlChars.NullChar, intPrevPos + 1)
                If intLength - intPrevPos = 1 OrElse intLength = -1 Then Exit Do
                Try
                    GetINISections.Add(strBuffer.Substring(intPrevPos + 1, intLength - intPrevPos))
                Catch
                End Try
                intPrevPos = intLength
            Loop
        End If
    End Function

#End Region

End Class
