using System;
using System.Collections.Generic;
using System.Linq;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;

namespace _8mpBl.Helper.Classes
{
    public class MpTransaction : IMpTransaction, IMpCommonApi
    {
        public object FormObject { get; set; }
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public void SetFocus() { throw new NotImplementedException(); }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }

        private readonly IMpFlex _objFlex;
        private readonly IMessageTextHandler _objMsg;
        private readonly IWebServiceHelper _objWs;
        public event EventHandler<CustomReturnEventArgs> TransactionProceed;

        private int _engageId = 0;
        private int _transId = 0;
        private int _paramId = 0;
        private int _failureId = 0;

        public MpTransaction(IMpFlex objFlex, IWebServiceHelper objWs, IMessageTextHandler objMsg)
        {
            _objFlex = objFlex;
            _objWs = objWs;
            _objMsg = objMsg;
            ListReturnMsgVm = new List<ReturnMsgVm>();
        }
        protected virtual void OnTransactionProceed(ReturnMsgVm r)
        {
            TransactionProceed?.Invoke(this, new CustomReturnEventArgs() { ReturnMsg = r });
        }
        #region "interface"
        public bool ProcessTransaction(ISnApi objSn, ISoApi objSo, IParamApi objParam)
        {
            var r = false;
            var nextcode = objSn.ValidateNextCode();
            if (nextcode != objSn.RouteDetail.next_pass) OnTransactionProceed(objSn.ReturnMsg);
            _engageId = ProcessEngage(objSn, objSo, nextcode);
            if (_engageId > 0)
            {
                _transId = ProcessTransaction(objSn, _engageId, true);
                if (_transId > 0)
                {
                    r = true;
                    if (objParam != null)
                    {
                        _paramId = ProcessParam(objSn, objParam, _engageId);
                        if (_paramId < 0) r = false;
                    }
                }
            }
            if (!r) RollBackTransaction(objSn, objSo,objParam,null);
            return r;
        }
        public bool ProcessTransactionPass(ISnApi objSn, IParamApi objParam)
        {
            var r = false;
            var transId = ProcessTransaction(objSn, objSn.SnDetail.id, true);
            if (transId > 0)
            {
                var nextcode = objSn.ValidateNextCode();
                if (nextcode != objSn.RouteDetail.next_pass) OnTransactionProceed(objSn.ReturnMsg);

                var performId = ProcessEngageUpdate(objSn, nextcode);
                if (performId > 0)
                {
                    r = true;
                    if (objParam != null)
                    {
                        var pId = ProcessParam(objSn, objParam, performId);
                        if (pId < 0) r = false;
                    }
                }
            }
            if (!r) RollBackTransaction(objSn, null, objParam, null);
            return r;
        }

        public bool ProcessTransactionFail(ISnApi objSn, IParamApi objParam, IFailureApi objFailure)
        {
            var r = false;
            _transId = ProcessTransaction(objSn, objSn.SnDetail.id, false);
            if (_transId > 0)
            {

                var nextcode = objSn.ValidateNextCode();
                if (nextcode != objSn.RouteDetail.next_pass) OnTransactionProceed(objSn.ReturnMsg);
                var performId = ProcessEngageUpdate(objSn, nextcode);
                if (performId > 0)
                {
                    r = true;
                    if (objParam != null)
                    {
                        var pId = ProcessParam(objSn, objParam, performId);
                        if (pId < 0) r = false;
                    }
                }
            }
            if (!r) RollBackTransaction(objSn, null, objParam, objFailure);
            return r;
        }
        #endregion
        #region "ProcessTrans"
        private int ProcessEngageUpdate(ISnApi objSn, string nextcode)
        {
            var result = objSn.EngageTransactionUpdate(new SnEngageUpdateVm() { number = objSn.UnitSn, workorder = objSn.ShopOrderName, current_operation = nextcode, category1 = null, category2 = null, routing = null, description = "", last_operation = objSn.SnDetail.last_operation, last_result = true, finished_date = null, wip = true, perform_start_date = null, perform_operation = Operation }, objSn.SnDetail.slug);
            OnTransactionProceed(ReturnMsg);
            return result;
        }
        private int ProcessEngage(ISnApi objSn, ISoApi objSo, string nextcode)
        {
            var result = objSn.EngageTransaction(new SnEngageVm() { number = objSn.UnitSn, workorder = objSo.ShopOrderName, current_operation = nextcode, category1 = "", category2 = "", routing = null, description = "" });
            OnTransactionProceed(ReturnMsg);
            return result;
        }
        private int ProcessTransaction(ISnApi objSn, int transId, bool transResult)
        {
            var result = objSn.PerformTransaction(new SnPerformVm() { sn = transId, operation = Operation, start_time = null, stop_time = null, result = transResult, resource_name = "", remark = "" }, objSn.UnitSn);
            OnTransactionProceed(ReturnMsg);
            return result;
        }
        private int ProcessParam(ISnApi objSn, IParamApi objParam, int performId)
        {
            var paramValue = objParam.GetParamItemValue(performId);
            if (!paramValue.Any()) return 0;
            var result = objParam.PerformParametric(paramValue, objSn.UnitSn);
            OnTransactionProceed(ReturnMsg);
            return result;
        }
        private int ProcessFailure( ISnApi objSn, IFailureApi objFailure, int performId)
        {
            //TODO : update failure
            //var paramValue = objFailure.GetParamItemValue(performId);
            //if (!paramValue.Any()) return 0;
            //var result = _objTrans.PerformParametric(paramValue, objSn.UnitSn);
            var result = 0;
            OnTransactionProceed(ReturnMsg);
            return result;
        }
        #endregion
        #region "Rollback"
        private void RollBackTransaction(ISnApi objSn, ISoApi objSo, IParamApi objParam, IFailureApi objFailure)
        {
            if (_paramId != 0) RollBackParameter(objParam);
            if (_failureId != 0) RollBackFailure(objFailure);
            if (_engageId != 0) RollBackEngage(objSn, objSo);
            if (_transId != 0) RollBackTransaction(objSn);

        }
        private void RollBackEngage(ISnApi objSn, ISoApi objSo)
        {

        }
        private void RollBackTransaction(ISnApi objSn)
        {

        }
        private void RollBackParameter(IParamApi objParam)
        {

        }
        
        
        private void RollBackFailure(IFailureApi objFailure)
        {

        }



        #endregion

        private void ClearValue()
        {
            _transId = 0;
            _engageId = 0;
            _paramId = 0;
            _failureId = 0;
        }

    }
}
