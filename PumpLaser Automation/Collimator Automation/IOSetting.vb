'
' IO口 设定 {UI要显示行、列、 每个口的名称、索引}
'
'
<Serializable> _
Public Class IOSetting
    Public Property IOList As New List(Of IOProperty)
    Public Row As Integer = 2
    Public Colum As Integer = 2
End Class
Public Class IOProperty
    Public Property IOName As String
    Public Property IOIndex As Integer


End Class
