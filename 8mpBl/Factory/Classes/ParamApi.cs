using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Parameter;
using _8mpBl.Model.Route;
using IWebServiceHelper = _8mpBl.Helper.Interfaces.IWebServiceHelper;

namespace _8mpBl.Factory.Classes
{
    public class ParamApi : IParamApi, IDisposable
    {
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public void SetFocus() { throw new NotImplementedException(); }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        private readonly IControlBuilder _objControlBuilder;
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public object FormObject { get; set; }
        public int SnId { get; set; }
        public List<Model.Parameter.ParameterItemValueVm> ParamItemValue { get; set; }
        private List<IParamItemApi> _listOfParamItem;

        public ParamApi(IWebServiceHelper objWs, IMessageTextHandler objMsg, IMpFlex objFlex, IControlBuilder objControlBuilder)
        {
            GetWsObj = objWs;
            GetMsgObj = objMsg;
            GetFlexObj = objFlex;
            _objControlBuilder = objControlBuilder;
            _listOfParamItem = new List<IParamItemApi>();
        }
        public void ControlReset()
        {
        }

        public object GetParameterBySlug(string routingDetailSlug) => GetWsObj.GetParameterBySlug(routingDetailSlug);
        public object GetItemBySlug(string parameterSlug) => GetWsObj.GetItemBySlug(parameterSlug);
        public string GetSnippedCode(string slug) { throw new NotImplementedException(); }

        public string SnipErrorMessage()
        {
            return GetFlexObj.ErrorMessage;
        }

        public ParameterVm GetParameterProfileDetail(string paramSlug)
        {
            return GetWsObj != null ? GetWsObj.GetParameterProfileDetail(paramSlug) : new ParameterVm();
        }


        //private void LoadParameter(UserControl parent)
        //{
        //    TabControl tabControl = new TabControl() { Name = "Parameter" };
        //    tabControl.SelectedIndexChanged += _objControlBuilder.FindAndSetFocus;

        //    foreach (string paramSlug in RouteDetail.parameter)
        //    {
        //        var param = GetWsObj.GetParameterProfileDetail(paramSlug);
        //        var tabPage = new TabPage {Text = param.title ?? param.name, Name = param.name, AutoSize = true, Size = new Size(tabControl.Width, 1300)};
        //        tabControl.TabPages.Add(tabPage);
        //    }
        //    tabControl.SelectedTab = tabControl.TabPages[0];
        //    tabControl.Show();
        //    parent.Controls.Add(tabControl);
        //}
        public List<ParameterItemValueVm> GetParamItemValue(int performId)
        {
            foreach (IParamItemApi value in _listOfParamItem)
            {
                if (ParamItemValue == null)
                    ParamItemValue = new List<ParameterItemValueVm>();
                foreach (var v in value.ParamItemValue)
                {
                    v.performing = performId;
                    ParamItemValue.Add(v);
                }
            }
            return ParamItemValue;
        }

        
        private bool _disposedValue; // To detect redundant calls
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }
                _listOfParamItem = null;
            }
            _disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }

        #region "transaction"
        public int PerformParametric(List<ParameterItemValueVm> data, string sn)
        {
            var lastResult = 0;
            foreach (var d in data)
            {
                var resultvalue = (int)GetWsObj.GetParametric(d);
                ReturnMsg = GetMsgObj.GetSystemMsg(resultvalue > 0 ? EnumMessage.TransactionParamSuccess : EnumMessage.TransactionParamFail, sn);
                if (resultvalue == 0) return resultvalue;
                lastResult = resultvalue;
            }
            return lastResult;
        }

        public int RollBackParam(int paramId) { return 0; }

        #endregion
    }
}
