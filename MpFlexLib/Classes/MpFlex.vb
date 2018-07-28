Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports MpFlexLib.Interfaces

Namespace Classes

    <Runtime.InteropServices.ComVisible(True)>
    Partial Public Class MpFlex : Implements IMpFlex
        Dim currentForm As Form
        Public ObjectName As String 'argument of local function
        Public vObjName As String 'For access object name
        Public vReturn As String 'argument for Return
        Public vSnippetName As String 'argument for Code Library

        Public Property Success As Boolean Implements IMpFlex.Success
            Get
                ' Gets the property value.
                Return vLocalSuccess
            End Get
            Set(ByVal vSuccess_ As Boolean)
                ' Sets the property value.
                vLocalSuccess = vSuccess_
            End Set
        End Property

        Public Property ErrorMessage As String Implements IMpFlex.ErrorMessage
            Get
                ' Gets the property value.
                Return vLocalErrorMsg
            End Get
            Set(ByVal vErrorMsg_ As String)
                ' Sets the property value.
                vLocalErrorMsg = vErrorMsg_
            End Set
        End Property

        'Public vSelfObject As Object
        Dim vLocalUrl As String
        Dim vLocalSuccess As Boolean
        Dim vLocalErrorMsg As String
        Dim vLocalMsg As String

        Private ReadOnly _hostUrl As String
        Public vJsonObj As Object


        'Dim vScriptControl As Object
        Public vScriptControl As MSScriptControl.ScriptControlClass

        'Property
        Public Property Form() As Object Implements IMpFlex.Form
            Get
                ' Gets the property value.
                Return currentForm
            End Get
            Set(ByVal vForm_ As Object)
                ' Sets the property value.
                currentForm = vForm_
            End Set
        End Property

        Public Property Url As String
            Get
                ' Gets the property value.
                Return vLocalUrl
            End Get
            Set(ByVal vUrl_ As String)
                ' Sets the property value.
                vLocalUrl = vUrl_
            End Set
        End Property

        Public Property TokenData As String
            Get
                ' Gets the property value.
                Return _token
            End Get
            Set(ByVal token As String)
                ' Sets the property value.
                _token = token
            End Set
        End Property
        Private _token As string


         Public Property SnDetail As SnDetailVm Implements IMpFlex.SnDetail
            Get
                ' Gets the property value.
                Return _sndetail
            End Get
            Set(ByVal value As SnDetailVm)
                ' Sets the property value.
                _sndetail = value
            End Set
        End Property
        Private _sndetail As SnDetailVm


        Public Property message As String Implements IMpFlex.message
            Get
                ' Gets the property value.
                Return vLocalMsg
            End Get
            Set(ByVal vMsg_ As String)
                ' Sets the property value.
                vLocalMsg = vMsg_
            End Set
        End Property
        'ReadOnly Property Length() As Integer
        '    Get
        '        Return mstrLine.Length
        '    End Get
        'End Property

        'Method
        'Public Sub Capitalize()
        '    ' Capitalize the value of the property.
        '    userNameValue = UCase(userNameValue)
        'End Sub

        Public Function ExecuteScriptCode(vScritp As String) As String
            'On Error GoTo HasError
            Try
                Dim message_out As String
                initialScript()
                vScriptControl.ExecuteStatement(vScritp)
                ExecuteScriptCode = vScriptControl.Eval("returndata("""")")
                message_out = vScriptControl.Eval("returnMessage("""")")
                vScriptControl.Reset()
                vLocalMsg = message_out
                vLocalSuccess = True
                Exit Function
            Catch ex As Exception
                destroyObject()
                vLocalSuccess = False
                vLocalErrorMsg = "Snip Execution Error : " + Err.Description
            End Try
        End Function

        Private Sub destroyObject()
            vScriptControl = Nothing
        End Sub

        Public Function returnData(vOutput As String) As String
            'getValueByParameter
            returnData = vReturn
        End Function

        Public Function returnMessage(vOutput As String) As String
            'getValueByParameter
            returnMessage = vLocalMsg

        End Function


        Private Sub initialScript()


            'Set clsODC = New clsODCSEscript 'Added by Chuthcai S on June 18,2009
            'Dim clsFlex As New Classes.MpFlex
            Dim clsFlex As New MpFlex


            vScriptControl = New MSScriptControl.ScriptControlClass
            'vSelfObject = Nothing
            vLocalMsg = ""

            With vScriptControl
                .Language = "VBScript"
                .AllowUI = True

                'Core Objects
                .AddObject("flex", clsFlex, True)
                '    vScriptControl.AddObject "dbCon", vDBconnection ', True
                '    vScriptControl.AddObject "clsODCSEscript", clsODC ', True
                .AddObject("clsMain", vScriptControl, True) 'For includelib
                If Not currentForm Is Nothing Then
                    .AddObject("clsForm", currentForm, True)
                End If
                .AddObject("wmp_url", vLocalUrl, True)

                .AddObject("message", vLocalMsg, True)
                If Not _sndetail Is Nothing Then 'TODO : need to pass this value on all flex call
                    .AddObject("snd", _sndetail, True)
                End If

            End With

            'Initial GLOBAL Variable
            Dim vGlobal As String
            vGlobal = "GLOBAL_URL = """ & vLocalUrl & """"
            vScriptControl.AddCode(vGlobal)

            'puriwat:11jun2018 'TODO : need to pass this value on all flex call
            Dim vToken As String
            vToken = "GLOBAL_TOKEN = """ & _token & """"
            vScriptControl.AddCode(vToken)

             

            Dim vgetObj As String
            'vgetObj = "Function localObject(vObjectName,vNewName)" & vbCrLf &
            '          "flex.ObjectName =  vObjectName " & vbCrLf &
            '          "flex.Form = clsForm " & vbCrLf &
            '          "clsMain.AddObject vNewName,flex.getObject("""") " & vbCrLf &
            '          "End Function"
            vgetObj = "Function localObject(vObjectName,vNewName)" & vbCrLf &
                      "flex.ObjectName =  vObjectName " & vbCrLf &
                      "flex.Form = clsForm " & vbCrLf &
                      "clsMain.AddObject vNewName,flex.getObject("""") " & vbCrLf &
                      "End Function"

            vScriptControl.AddCode(vgetObj)

            'Test flex.getJsonObject("""")
            'Dim vJsonStrObj As String
            'vJsonStrObj = "Function json(vUrl_,jsonName) " & vbCrLf &
            '        "flex.vUrl =  vUrl_ " & vbCrLf &
            '        "flex.Form = clsForm " & vbCrLf &
            '        "clsMain.AddObject jsonName,flex.getJsonObject("""") " & vbCrLf &
            '        "End Function"
            'vScriptControl.AddCode(vJsonStrObj)
            Dim vJsonStrObj As String
            vJsonStrObj = "Function json(vUrl_) " & vbCrLf &
                          " dim outputx " & vbCrLf &
                          " outputx = getJsonString(vUrl_) " & vbCrLf &
                          " json = parseJson(outputx) " & vbCrLf &
                          "End Function"
            vScriptControl.AddCode(vJsonStrObj)

            'Return
            Dim vReturn_ As String
            vReturn_ = "Function return(vReturn_) " & vbCrLf &
                       " dim output_" & vbCrLf &
                       "    flex.vReturn = vReturn_ " & vbCrLf &
                       "End Function"
            vScriptControl.AddCode(vReturn_)

            Dim vReturnMsg_ As String
            vReturnMsg_ = "Function return_message(vReturn_) " & vbCrLf &
                          " dim output_" & vbCrLf &
                          "    flex.message = vReturn_ " & vbCrLf &
                          "End Function"
            vScriptControl.AddCode(vReturnMsg_)

            vReturn_ = "Function returndata(vReturn_) " & vbCrLf &
                       " dim output_" & vbCrLf &
                       "    output_ = flex.returnData("""") " & vbCrLf &
                       "   returndata = output_ " & vbCrLf &
                       "End Function"
            vScriptControl.AddCode(vReturn_)

            'New function to include library (vFlexLibName)
            Dim vInclude As String
            vInclude = "Function includeSnippet(vSnippet)" & vbCrLf &
                       "flex.vSnippetName = vSnippet " & vbCrLf &
                       "flex.Url = wmp_url " & vbCrLf &
                       "vCode = getSnippetCode(vSnippet)" & vbCrLf &
                       "clsMain.AddCode vCode  " & vbCrLf &
                       "End Function"

            vScriptControl.AddCode(vInclude)





            '    'Added by Chutchai S on Dec 19,2007
            '    'To add result XML in to class
            '    Dim objXml As Object
            'Set objXml = CreateObject("MSXML.DOMDocument")
            'If vXmlResult <> "" Then
            '        objXml.loadXML vXmlResult
            '    vScriptControl.AddObject "objXml_tmp", objXml, True
            'End If
            '    '---------------------------------------------



            '    'Funtions
            '    'New function for get parameter (DES version 3.8.14)
            '    'Added by Chutchai S on Oct 16,2009
            '    vXmlRequest = "Function request(vRequestIn) " & vbCrLf &
            '                " dim vQueryString " & vbCrLf &
            '                " vQueryString =""/request/"" & vRequestIn  " & vbCrLf &
            '                " if not objXml_tmp.selectSingleNode(vQueryString) is nothing then " & vbCrLf &
            '                "       request = objXml_tmp.selectSingleNode(vQueryString).text " & vbCrLf &
            '                " end if " & vbCrLf &
            '                "End Function"
            '    vScriptControl.AddCode vXmlRequest
            ''--------------------------------------------------------


            '    'New function for get current result XML data
            '    'Added by Chutchai S on Dec 19,2007
            '    vXml = "Function getResultXML() " & vbCrLf &
            '            " getResultXML = clsODCSEscript.getXml(objXml_tmp.xml) " & vbCrLf &
            '            "End Function"
            '    If vXmlResult <> "" Then vScriptControl.AddCode vXml



            'New function to get local object
            'vgetObj = "Function localObject(vObjectName,vNewName)" & vbCrLf &
            '        "clsODCSEscript.vObjName=  vObjectName " & vbCrLf &
            '        "clsODCSEscript.setCurrentForm clsForm " & vbCrLf &
            '        "clsMain.AddObject vNewName,clsODCSEscript.getObject("""") " & vbCrLf &
            '        "End Function"

            'vScriptControl.AddCode vgetObj

            ''Parameter definetion (par)
            '    '    fpara = "Function par(param)" & vbCrLf & _
            '    '                "Dim Result                    " & vbCrLf & _
            '    '                "Dim Sn                    " & vbCrLf & _
            '    '                "Dim So                    " & vbCrLf & _
            '    '                "Dim Product                    " & vbCrLf & _
            '    '                "clsODCSEscript.vScript = param " & vbCrLf & _
            '    '                "Sn =""" & vSN & """ " & vbCrLf & _
            '    '                "So =""" & vSO & """ " & vbCrLf & _
            '    '                "Product =""" & vProduct & """ " & vbCrLf & _
            '    '                "    Result = clsODCSEscript.getParameter("""",""" & vSN & """,""" & vSO & """,""" & vProduct & """,dbCon) " & vbCrLf & _
            '    '                "    par = Result    " & vbCrLf & _
            '    '                "End Function"

            '    fpara = "Function par(param)" & vbCrLf &
            '            "Dim Result                    " & vbCrLf &
            '            "Dim Sn                    " & vbCrLf &
            '            "Dim So                    " & vbCrLf &
            '            "Dim Product                    " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "clsODCSEscript.vScript = param " & vbCrLf &
            '            "Sn =""" & vSN & """ " & vbCrLf &
            '            "So =""" & vSO & """ " & vbCrLf &
            '            "Product =""" & vProduct & """ " & vbCrLf &
            '            "    Result = clsODCSEscript.getParameter("""",""" & vSN & """,""" & vSO & """,""" & vProduct & """,dbCon) " & vbCrLf &
            '            "    par = Result    " & vbCrLf &
            '            "End Function"

            '    vScriptControl.AddCode fpara



            '    floc = "Function local(param)" & vbCrLf &
            '            "Dim Result                    " & vbCrLf &
            '            "clsODCSEscript.vObjectName = param " & vbCrLf &
            '            "  if not " & IIf(vRunAsService, "true", "false") & " then " & vbCrLf &
            '            "    clsODCSEscript.setCurrentForm clsForm " & vbCrLf &
            '            "    Result = clsODCSEscript.getLocalObject("""") " & vbCrLf &
            '            "  else " & vbCrLf &
            '            "     Result = clsODCSEscript.getLocalObjectFromXML(objXml_tmp.xml)  " & vbCrLf &
            '            "  end if " & vbCrLf &
            '            "    local = Result    " & vbCrLf &
            '            "End Function"

            '    vScriptControl.AddCode floc


            ''Database Object
            ''vExecuteQuery = "Function ExecuteQuery(vSql)" & vbCrLf & _
            '            "   dim rst " & vbCrLf & _
            '            "    clsODCSEscript.vSql = vSql " & vbCrLf & _
            '            "    set rst = clsODCSEscript.ExecuteQuery("""",dbCon) " & vbCrLf & _
            '            "    set ExecuteQuery = rst " & vbCrLf & _
            '            "End Function"

            ' vExecuteQuery = "Function ExecuteQuery(vSql)" & vbCrLf &
            '            "   dim rst " & vbCrLf &
            '            "    clsODCSEscript.vSql = vSql " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "    set rst = clsODCSEscript.ExecuteQuery("""",dbCon) " & vbCrLf &
            '            "    set ExecuteQuery = rst " & vbCrLf &
            '            "End Function"

            '    vScriptControl.AddCode vExecuteQuery

            ''vExecuteNonQuery = "Function ExecuteNonQuery(vSql)" & vbCrLf & _
            '            "    clsODCSEscript.vSql = vSql " & vbCrLf & _
            '            "    clsODCSEscript.ExecuteNonQuery """",dbCon " & vbCrLf & _
            '            "    ExecuteNonQuery=true " & vbCrLf & _
            '            "End Function"

            'vExecuteNonQuery = "Function ExecuteNonQuery(vSql)" & vbCrLf &
            '            "    clsODCSEscript.vSql = vSql " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "    clsODCSEscript.ExecuteNonQuery """",dbCon " & vbCrLf &
            '            "    ExecuteNonQuery=true " & vbCrLf &
            '            "End Function"

            '    vScriptControl.AddCode vExecuteNonQuery


            '    vBeginTrans = "Function BeginTrans()" & vbCrLf &
            '            "    clsODCSEscript.BeginTrans dbCon " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "    BeginTrans=true " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vBeginTrans

            'vCommit = "Function Commit()" & vbCrLf &
            '            "    clsODCSEscript.commit dbCon " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "    Commit=true " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vCommit

            'vRollback = "Function rollback()" & vbCrLf &
            '            "    clsODCSEscript.rollback dbCon " & vbCrLf &
            '            "    clsODCSEscript.DTS_location = """ & vDtsLocation & """ " & vbCrLf &
            '            "    clsODCSEscript.DTS_mode = " & vDtsMode & " " & vbCrLf &
            '            "    rollback=true " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vRollback

            ''Return
            '    vReturn_ = "Function return(vReturn_) " & vbCrLf &
            '            " dim output_" & vbCrLf &
            '            "    clsODCSEscript.vReturn = vReturn_ " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vReturn_

            'vReturn_ = "Function returndata(vReturn_) " & vbCrLf &
            '            " dim output_" & vbCrLf &
            '            "    output_ = clsODCSEscript.returnData("""") " & vbCrLf &
            '            "   returndata = output_ " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vReturn_
            ''Parameter
            '    vparameter_ = "Function parametervalue() " & vbCrLf &
            '            " dim value_" & vbCrLf &
            '            "    value_ clsODCSEscript.para   " & vbCrLf &
            '            "   parametervalue = value_ " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vparameter_
            ''"    clsODCSEscript.vReturn = clsODCSEscript.returnData("""") " & vbCrLf


            '    vShall_ = "Function shell(filename_)" & vbCrLf &
            '            "   clsODCSEscript.vExeFileName = filename_ " & vbCrLf &
            '            "    clsODCSEscript.ShellAndWait("""") " & vbCrLf &
            '            "    shell= true " & vbCrLf &
            '            "End Function"
            '    vScriptControl.AddCode vShall_

            '    If vAllowUI Then
            '        vDSP_ = "Function dsp(dspProfilename_,service_,sn_,so_,product_,station_,pc_,line_)" & vbCrLf &
            '            "   clsODCSEscript.vDSPProfileName = dspProfilename_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPServiceName = service_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPSnName = sn_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPSoName = so_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPStationName = station_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPProductName = product_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPPcName = pc_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPLineName = line_ " & vbCrLf &
            '            "   clsODCSEscript.setCurrentForm clsForm " & vbCrLf &
            '            "    dsp = clsODCSEscript.dspProcess("""","""","""","""",dbcon)  " & vbCrLf &
            '            "End Function"
            '        vScriptControl.AddCode vDSP_
            'Else
            '        vDSP_ = "Function dsp(dspProfilename_,service_,sn_,so_,product_,station_,pc_,line_)" & vbCrLf &
            '            "   clsODCSEscript.vDSPProfileName = dspProfilename_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPServiceName = service_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPSnName = sn_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPSoName = so_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPStationName = station_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPProductName = product_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPPcName = pc_ " & vbCrLf &
            '            "   clsODCSEscript.vDSPLineName = line_ " & vbCrLf &
            '            "    dsp = clsODCSEscript.dspProcess("""","""","""","""",dbcon)  " & vbCrLf &
            '            "End Function"
            '        vScriptControl.AddCode vDSP_
            'End If


            '    If vAllowUI Then
            '        vWS_ = "Function ws(dspProfilename_)" & vbCrLf &
            '                    "   clsODCSEscript.vDSPProfileName = dspProfilename_ " & vbCrLf &
            '                    "   clsODCSEscript.setCurrentForm clsForm " & vbCrLf &
            '                    "    ws = clsODCSEscript.wsProcess(""" & vSN & """,""" & vSO & """,""" & vProduct & ""","""",dbcon)  " & vbCrLf &
            '                    "End Function"
            '    Else
            '        vWS_ = "Function ws(dspProfilename_)" & vbCrLf &
            '                   "   clsODCSEscript.vDSPProfileName = dspProfilename_ " & vbCrLf &
            '                   "    ws = clsODCSEscript.wsProcess(""" & vSN & """,""" & vSO & """,""" & vProduct & ""","""",dbcon)  " & vbCrLf &
            '                   "End Function"
            '    End If

            '    vScriptControl.AddCode vWS_

        End Sub

        'Public Function FindControl(root As Control, target As String) As Control
        '    'On Error GoTo HasError
        '    If root.Name = target Then
        '        Return root
        '    End If

        '    If Not root.HasChildren Then
        '        Return Nothing
        '    End If

        '    Dim newTarget As String
        '    newTarget = Split(target, ".")(0)

        '    Dim result As Control = Nothing
        '    For Each result In root.Controls
        '        result = FindControl(result, newTarget)
        '        If Not IsNothing(result) Then
        '            Return result
        '            Exit For
        '        End If
        '    Next

        '    Exit Function
        '    HasError:
        '    FindControl = Nothing

        'End Function
        Private Function FindControl(parentControl As Control, childname As String) As Control
            For Each c As Control In parentControl.Controls
                If c.HasChildren() Then
                    Dim found = FindControl(c, childname)
                    If found IsNot Nothing Then Return found
                End If
                If [String].Equals(c.Name, childname, StringComparison.CurrentCultureIgnoreCase) Then Return c
            Next
            Return Nothing
        End Function
        Public Function ShowObjectName(ele As Object, parentName As String) As Control
            Dim nControl As Control
            Dim pName As String
            Dim i = 1
            For Each nControl In ele.Controls
                If nControl.Name = "" Then nControl.Name = "system" + i.ToString() 'if no name found, set it
                If parentName = "" Then
                    pName = nControl.Name
                Else
                    pName = parentName + "." + nControl.Name
                End If
                Return ShowObjectName(nControl, pName)

                i = i + 1
            Next
            Return Nothing
        End Function
        Public Function getObject(vControlName As String) As Object  'vControlName=1.text1 (StepName.Control)
            On Error GoTo HasError
            Dim ddd As Control = Nothing
            Dim vSteps() As String

            vSteps = Split(ObjectName, ".")

            '---Recursive finding Control---
            Dim vControl As Control = Form
            Dim vStep As String
            For Each vStep In vSteps
                ddd = FindControl(vControl, vStep)
                'ddd = ShowObjectName(vControl, vStep)

                If Not IsNothing(ddd) Then
                    vControl = ddd
                    Continue For
                End If
            Next

            '-------
            'Commit on Oct 10,2017
            'If UBound(vSteps) = 0 Then 'One level
            '    If Not Form Is Nothing Then
            '        ddd = Form.Controls(vSteps(0))
            '    End If
            'End If

            'If UBound(vSteps) = 1 Then 'One level
            '    If Not Form Is Nothing Then
            '        'ddd = Form.Controls(vStep(0)).object.localControls(vStep(1))
            '        ddd = Form.Controls(vSteps(0)).Controls(vSteps(1))
            '    End If
            'End If

            'If UBound(vSteps) = 2 Then 'One level'Two level
            '    If Not Form Is Nothing Then
            '        'ddd = Form.Controls(vStep(0)).object.localControls(vStep(1)).object.localControls(vStep(2))
            '        ddd = Form.Controls(vSteps(0)).Controls(vSteps(1)).Controls(vSteps(2))
            '    End If
            'End If
            getObject = ddd
            Exit Function
HasError:
            getObject = Nothing
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error on Finding control")

        End Function

        Public Function getJsonString(ByVal address As String) As String

            Dim client As WebClient = New WebClient()
            Dim reply As String = client.DownloadString(address)
            getJsonString = reply
        End Function

        Public Function getJsonObject(ByVal address As String) As Object

            Dim client As WebClient = New WebClient()
            Dim json As String = client.DownloadString(address)

            'Dim x As Object = JsonConvert.DeserializeObject(Of Object)(json)
            'Dim d As Object
            'd = JObject.Parse(json)
            'Dim ccc As String = d("name")

            Dim jss = New JavaScriptSerializer()
            'Dim data As Object = jss.Deserialize(Of JObject)(json)
            Dim data As Object = jss.DeserializeObject(json)
            'vJsonObj = data
            Return data
        End Function

        Public Function getSnippetCode(ByVal _vSnippetName As String) As String

            Dim client As WebClient = New WebClient()
            Dim json As String = client.DownloadString(vLocalUrl + "/api/snippet/" + _vSnippetName)
            Dim jss = New JavaScriptSerializer()
            Dim data As Object = jss.Deserialize(Of Object)(json)
            Return data("code")
        End Function


        Public Function parseJson(_jsonStr) As Object
            Dim result As Object
            Dim scriptControl As Object
            scriptControl = CreateObject("MSScriptControl.ScriptControl")
            scriptControl.Language = "JScript"
            result = scriptControl.Eval("(" + _jsonStr + ")")
            parseJson = result
        End Function
        'Public Function getJsonObject(ByVal address As String) As Object

        '    Dim client As WebClient = New WebClient()
        '    Dim json As String = client.DownloadString(vUrl)
        '    Dim jss = New JavaScriptSerializer()
        '    Dim data As Object = jss.Deserialize(Of Object)(json)
        '    vJsonObj = data
        '    Return vJsonObj
        'End Function


    End Class

End Namespace