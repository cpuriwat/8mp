using System;
using System.Collections.Generic;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;

namespace _8mpBl.Factory.Classes
{
    public class PassFailApi : IPassFailApi, IDisposable
    {
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public object FormObject { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        private IMpFlex _objFlex;
        public PassFailApi(IWebServiceHelper wsHelper, IMessageTextHandler errCode, IMpFlex objFlex)
        {
            GetWsObj = wsHelper;
            GetMsgObj = errCode;
            _objFlex = objFlex;
        }
        public void SubmitFailClick()
        {
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.UnitIsSubmitFail);
            Result = EnumResult.ButtonSubmit;
        }
        public void CancelClick()
        {
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.UnitIsAbort);
            Result = EnumResult.ButtonCancel;
        }
        public void PassClick()
        {
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.UnitIsPass);
            Result = EnumResult.ButtonPass;
            if (!ExecutePostMpFlex(Result))
                Result = EnumResult.Fail; // return msg will get from ExecutePostMpFlex
        }
        public void FailClick()
        {
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.UnitIsFail);
            Result = EnumResult.ButtonFail;
            if (!ExecutePostMpFlex(Result))
                Result = EnumResult.Fail; // return msg will get from ExecutePostMpFlex
        }
        public void SetFocus()
        {
        }

        public bool ExecutePostMpFlex(EnumResult result)
        {
            return true;
        }
        public bool CheckNextCondition(string vDefaultNextOpr) { return true; }

        private bool disposedValue; // To detect redundant calls

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
            }
            disposedValue = true;
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
