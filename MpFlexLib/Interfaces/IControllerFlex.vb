Namespace Interfaces
    Public Partial Interface IMpFlex
        Sub ShowObjectName(ele As Object,toolTips As Object,parentName As string)
        'Function ExecuteScript(code As String,formObj As Object) As Boolean
        Function ExecuteScript(code As String, tokenData As String) As Boolean 
    End Interface
End NameSpace