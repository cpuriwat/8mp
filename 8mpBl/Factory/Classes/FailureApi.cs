using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.FailureDefect;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;
using IWebServiceHelper = _8mpBl.Helper.Interfaces.IWebServiceHelper;

namespace _8mpBl.Factory.Classes
{
    public class FailureApi : IFailureApi, IDisposable
    {
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        IMessageTextHandler IMpCommonApi.GetMsgObj { get; set; }
        IWebServiceHelper IMpCommonApi.GetWsObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        private readonly IControlBuilder _objControlBuild;
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public FailureVm SnFailure;
        private string _bomName;
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public object FormObject { get; set; }
        public EnumResult Result { get; set; }
        public string UnitSn { get; set; }
        public bool ReworkOperation { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public FailureApi(IWebServiceHelper objWs, IMessageTextHandler objMsg, IMpFlex objFlex, IControlBuilder objControlBuild)
        {
            GetWsObj = objWs;
            GetMsgObj = objMsg;
            GetFlexObj = objFlex;
            _objControlBuild = objControlBuild;
        }
        public void SetFocus()
        {
            SnFailure = null;
            ReturnMsg = null;
        }
        public UnitFailureVm GetUnitFailure(string sn)
        {
            UnitSn = sn;
            return (UnitFailureVm) GetWsObj.GetFailureHistory(UnitSn);
        }
        public UnitFailureVm GetUnitFailure() => (UnitFailureVm) GetWsObj.GetFailureHistory(UnitSn);
        public List<DefectVm> GetDefect(string failureCode) => (List<DefectVm>) GetWsObj.GetDefectCode(failureCode);
        public List<FailureVm> GetFailure() => (List<FailureVm>) GetWsObj.GetFailureCode();
        public List<ReworkVm> GetRework(string defectCode) => (List<ReworkVm>) GetWsObj.GetReworkCode(defectCode);
        public AutoCompleteStringCollection GetFailCodeAutoComplete() { throw new NotImplementedException(); }

        public AutoCompleteStringCollection GetDefectCodeAutoComplete()
        {
            // TODO : need to change bom name to variable
            return (AutoCompleteStringCollection) GetWsObj.GetDefectCode();
        }
        public AutoCompleteStringCollection GetReworkCodeAutoComplete()
        {
            // TODO : need to change bom name to variable
            if (_bomName == "")
                _bomName = "bom001";
            return _objControlBuild.GetAutoComplete(GetWsObj.GetBomDetail(_bomName), "rd");
        }
        public AutoCompleteStringCollection GetRdAutoComplete()
        {
            // TODO : need to change bom name to variable
            if (_bomName == "")
                _bomName = "bom001";
            return _objControlBuild.GetAutoComplete(GetWsObj.GetBomDetail(_bomName), "rd");
        }
        public AutoCompleteStringCollection GetPnAutoComplete()
        {
            // TODO : need to change bom name to variable
            if (_bomName == "")
                _bomName = "bom001";
            return _objControlBuild.GetAutoComplete(GetWsObj.GetBomDetail(_bomName), "pn");
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
            }
            _disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        // Protected Overrides Sub Finalize()
        // ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        // Dispose(False)
        // MyBase.Finalize()
        // End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
        }
    }
}
