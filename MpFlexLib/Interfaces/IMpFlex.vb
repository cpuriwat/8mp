Imports MpFlexLib.Classes

Namespace Interfaces
    Partial Public Interface IMpFlex
        Property Success As Boolean
        Property ErrorMessage As String
        Property Form As Object
        Property message As String
        Function ExecuteScript(code As String, tokenData As String, snDetail As SnDetailVm) As Boolean
        Property SnDetail As SnDetailVm
    End Interface
End Namespace