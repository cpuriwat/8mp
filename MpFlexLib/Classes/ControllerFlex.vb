Imports System.Windows.Forms
Imports MpFlexLib.Interfaces

Namespace Classes
    Partial Public Class MpFlex
        Public Sub ShowObjectName(ele As Object, toolTips As Object, parentName As String) Implements IMpFlex.ShowObjectName
            Dim nControl As Control
            Dim strTooltrip As String
            dim pName as string
            Dim i=1
            For Each nControl In ele.Controls
                If nControl.Name="" then nControl.Name="system" +i.ToString() 'if no name found, set it
                If parentName = "" Then
                    pName=nControl.Name
                Else
                    pName = parentName+"."+nControl.Name
                End If
                ShowObjectName(nControl, toolTips, pName)
                strTooltrip =pName
                toolTips.SetToolTip(nControl, strTooltrip)
                i=i+1
            Next
        End Sub
        'Public Function ExecuteScript(code As String, formObj As Object) As Boolean Implements IMpFlex.ExecuteScript
        '    'initial
        '    Form = formObj
        '    Dim vReturn As Object = ExecuteScriptCode(code)
        '    'MsgBox(vCls.Url)
        '    'lblSuccess.Text = vCls.success
        '    'lblMsg.Text = vCls.message
        '    If Not success Then MsgBox(ErrorMessage)

        '    Return vReturn
        'End Function
        Public Function ExecuteScript(code As String, tokenData As String ) As Boolean Implements IMpFlex.ExecuteScript            'initial
          _token=tokenData
            Dim vReturn As Object = ExecuteScriptCode(code)
            'MsgBox(vCls.Url)
            'lblSuccess.Text = vCls.success
            'lblMsg.Text = vCls.message
            If Not success Then MsgBox(ErrorMessage)

            Return vReturn
        End Function
        Public Function ExecuteScript(code As String, tokenData As String , snDetail As SnDetailVm) As Boolean Implements IMpFlex.ExecuteScript            'initial
          _token=tokenData
           _sndetail =snDetail
            Dim vReturn As Object = ExecuteScriptCode(code)
            'MsgBox(vCls.Url)
            'lblSuccess.Text = vCls.success
            'lblMsg.Text = vCls.message
            If Not success Then MsgBox(ErrorMessage)

            Return vReturn
        End Function

    End Class
        <Runtime.InteropServices.ComVisible(True)>
        Public Class SnDetailVm:Inherits CommonMainSingleVm
        Public Property id As Integer
        Public Property routing As String
        Public Property workorder As String
        Public Property number As String
        Public Property slug As String
        Public Property registered_date As String
        Public Property last_modified_date As String
        Public Property last_result As Boolean
        Public Property finished_date As String
        Public Property wip As Boolean
        Public Property perform_start_date As String
        Public Property status As String
        Public Property current_operation As String
        Public Property last_operation As String
        Public Property perform_operation As String
    End Class
        <Runtime.InteropServices.ComVisible(True)>
       Public Class CommonMainSingleVm
        Public Property description As String
        Public Property category1 As String
        Public Property category2 As String
        Public Property user As integer
    End Class
End Namespace