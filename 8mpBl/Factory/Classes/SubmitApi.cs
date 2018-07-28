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
    public class SubmitApi : ISubmitApi, IDisposable
    {
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public object FormObject { get; set; }
        public EnumResult Result { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public LoginInfoVm LoginInfo { get; set; }


        public SubmitApi(IWebServiceHelper wsHelper, IMessageTextHandler errCode, IMpFlex objFlex)
        {
            GetWsObj = wsHelper;
            GetMsgObj = errCode;
            GetFlexObj = objFlex;
        }
        public void SubmitClick()
        {
            Result = EnumResult.ButtonSubmit;
            if (!ExecutePostMpFlex(Result))Result = EnumResult.Fail;
        }
        public void CancelClick()
        {
            ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.UnitIsAbort);
            Result = EnumResult.ButtonCancel;
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
