using System.Collections.Generic;
using System.Diagnostics;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Parameter;
using _8mpBl.Model.Route;

namespace _8mpBl.Factory.Classes
{
    public class ParamItemApi : IParamItemApi
    {
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public object FormObject { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public ParameterItemVm ParamItem { get; set; }
        public ParameterItemDetailVm ParamItemDetail { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public List<ParameterItemValueVm> ParamItemValue { get; set; }
        public ParamItemApi(IWebServiceHelper objWs, IMessageTextHandler objMsg, IMpFlex objFlex, ParameterItemVm parameterItem)
        {
            GetWsObj = objWs;
            GetMsgObj = objMsg;
            GetFlexObj = objFlex;
            ParamItem = parameterItem;
            ParamItemDetail = GetWsObj.GetParameterItemDetail(ParamItem.slug);
            if (ParamItemValue == null)ParamItemValue = new List<ParameterItemValueVm>();
        }
        public void SetFocus()
        {
        }
        public List<ParameterItemListValueVm> GetParamtemList()
        {
            return ParamItemDetail == null ? new List<ParameterItemListValueVm>() : ParamItemDetail.lists;
        }
        private bool ExecuteScript()
        {
            Debug.Print("ParamItem - ExecuteScript");
            if (ParamItemDetail == null)
            {
                ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.ParameterItemDetailNotFound, new List<string>() { ParamItem.title });
                return false;
            }
            if (ParamItemDetail.snippet == null)
                return true;
            var c = GetWsObj.GetSnippetBySlug(ParamItemDetail.snippet);
            if (c == null) return true;
            // If GetFlexObj.ExecuteScript(c.code, FormObject) Then
            if (GetFlexObj.ExecuteScript(c.code, GetWsObj.TokenAccessKey)) return true;
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.SnipReturnFalse, new List<string>() { c.name, c.title, c.returnmessage });
            return false;
        }
        public void AddParamItemValue(string name, string value, bool check)
        {
            var newData = new ParameterItemValueVm() { name = name, value = value };
            var temp = new List<ParameterItemValueVm>();
            if (ParamItemValue.Count > 0)
            {
                for (var i = ParamItemValue.Count - 1; i >= 0; i += -1)
                {
                    if (ParamItemValue[i].name == name)ParamItemValue.RemoveAt(i);
                }
            }
            ParamItemValue.Add(newData);
        }
        public bool InputValidation(string value)
        {
            if (ParamItem.input_type == EnumParamItemType.TEXT.ToString() && !GetWsObj.RexExValidate(value, ParamItem.regexp))
            {
                ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.SnFormatNotMatch, new List<string>() { value, ParamItem.regexp });
                return false;
            }
            if (ExecuteScript()) return true;
            Result = EnumResult.Fail;
            return false;
        }
        public bool CheckValidation(string value)
        {
            if (ExecuteScript()) return true;
            Result = EnumResult.Fail;
            return false;
        }
        public bool SelectionValidation(ParameterItemListValueVm value)
        {
            if (ExecuteScript()) return true;
            Result = EnumResult.Fail; return false;
        }
    }
}
