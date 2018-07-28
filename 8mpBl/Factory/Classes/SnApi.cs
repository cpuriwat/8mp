using System.Collections.Generic;
using System.Linq;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;
using _8mpBl.Model.Sn;
using _8mpBl.Model.Snip;

namespace _8mpBl.Factory.Classes
{
    public class SnApi : ISnApi
    {
        public void SetFocus() { throw new System.NotImplementedException(); }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public SnDetailVm SnDetail { get; set; }
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public object FormObject { get; set; }
        public string SnFormat { get; set; }
        public string ShopOrder { get; set; }
        public string ShopOrderName { get; set; }
        public string Route { get; set; }
        public string UnitSn { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public EnumResult Result { get; set; }

        public SnApi(IWebServiceHelper objWs, IMessageTextHandler objMsg, IMpFlex objFlex)
        {
            GetWsObj = objWs;
            GetMsgObj = objMsg;
            GetFlexObj = objFlex;
        }
        public bool AllowAutoSubmit() => false;
        private bool RegisterSnValidation(string sn)
        {
            var woDetail = GetWsObj.GetWorkOrderDetail(ShopOrder);
            if (woDetail == null) return SetMsgAndReturn(EnumMessage.WorkOrderNotFound, new List<string>() { ShopOrder }, false);
            if (!GetWsObj.RexExValidate(sn, woDetail.regexp)) return SetMsgAndReturn(EnumMessage.SnFormatNotMatch, new List<string>() { sn, SnFormat }, false);

            SnDetail = new SnDetailVm() { number = sn, current_operation = Operation };
            Route = woDetail.routing.name;
            if (!CheckRouting()) return SetMsgAndReturn(EnumMessage.RouteNotFound, new List<string>() { SnDetail.number }, false);
            UnitSn = sn;
            return true;
        }
        private bool SetMsgAndReturn(EnumMessage msgEnum, List<string> msgParam, bool returnValue)
        {
            if (GetMsgObj != null) ReturnMsg = GetMsgObj.GetSystemMsg(msgEnum, msgParam);
            return returnValue;
        }
        public bool CheckSerialNumber(string sn)
        {
            if (sn == "") return SetMsgAndReturn(EnumMessage.SnNotFound, new List<string>() { "Serial Number" }, false);

            var snVmList = GetWsObj.GetSn(sn);
            var snVm = snVmList.Any() ? snVmList.First() : null;
            if (ShopOrder != null && snVm == null) return RegisterSnValidation(sn);  // register station

            if (snVm == null) return SetMsgAndReturn(EnumMessage.SnNotFound, new List<string>() { sn }, false);
            if (!snVm.wip) return SetMsgAndReturn(EnumMessage.SnNotInWip, new List<string>() { sn }, false);

            SnDetail = GetWsObj.GetJsonObjectUrl<SnDetailVm>(snVm.url);
            if (SnDetail == null) return SetMsgAndReturn(EnumMessage.SnDetailNotFound, new List<string>() { sn }, false);
            if (!GetRouting()) return SetMsgAndReturn(EnumMessage.RouteNotFound, new List<string>() { SnDetail.number }, false);

            if (!CheckRouting()) return SetMsgAndReturn(EnumMessage.RouteNotFound, new List<string> { SnDetail.number }, false);
            if (UnitSn != sn) sn = UnitSn; // this supports when flex overwrite txtsn
            return SetMsgAndReturn(EnumMessage.UnitIsReady, new List<string>() { SnDetail.number }, true);
        }
        private bool GetRouting()
        {
            if (SnDetail?.routing != null)
            {
                var routeListVm = GetWsObj.GetRoute(SnDetail.routing);
                if (routeListVm != null) { Route = routeListVm.name; return true; }
            }

            if (SnDetail == null) return true;
            var wo = GetWsObj.GetWorkOrderBySlug(SnDetail.workorder);
            if (wo == null) return false;
            ShopOrderName = wo.name;
            if (wo.routing.name != "") { Route = wo.routing.name; return true; }

            var prod = GetWsObj.GetProductBySlug(wo.product);
            if (prod == null) return false;
            Route = prod.routing.name;

            return true;
        }
        private bool CheckExcept(RouteDetailOperationStepVm rd) // ANY True mean sn will stuck
        {
            if (rd.reject_code.Count <= 0) return true; // if not reject code found = no reject configured
            foreach (var routeRejectSlug in rd.reject_code)
            {
                var routeRejectDetail = GetWsObj.GetSnipByRouteRejectName(routeRejectSlug);
                if (routeRejectDetail == null) return SetMsgAndReturn(EnumMessage.SystemObjectNotFoundBySlug, new List<string>() { EnumMpObject.RouteReject.ToString(), routeRejectSlug }, false);
                if (routeRejectDetail.snippet.code != "" & routeRejectDetail.snippet.code == EnumStatus.A.ToString())
                {
                    if (GetFlexObj.ExecuteScript(routeRejectDetail.snippet.code, GetWsObj.TokenAccessKey))
                        return SetMsgAndReturn(EnumMessage.SnipReturnFalse, new List<string>() { routeRejectDetail.snippet.name, routeRejectDetail.snippet.title, routeRejectDetail.snippet.returnmessage }, false);
                }
            }
            return true;
        }
        private bool CheckAccept(RouteDetailOperationStepVm rd) // ANY True mean sn will stuck
        {
            if (rd.accept_code.Count <= 0) return false; // if not accept code found = no accept configured
            foreach (string routeAcceptSlug in rd.accept_code)
            {
                var routeAcceptDetail = GetWsObj.GetSnipByRouteAcceptName(routeAcceptSlug);
                if (routeAcceptDetail == null) return SetMsgAndReturn(EnumMessage.SystemObjectNotFoundBySlug, new List<string>() { EnumMpObject.RouteAccept.ToString(), routeAcceptSlug }, false);

                if (routeAcceptDetail.snippet.code != "" & routeAcceptDetail.snippet.status == EnumStatus.A.ToString())
                {
                    var snD = new MpFlexLib.Classes.SnDetailVm() { number = "test" };
                    if (GetFlexObj.ExecuteScript(routeAcceptDetail.snippet.code, GetWsObj.TokenAccessKey, snD)) return SetMsgAndReturn(EnumMessage.SnipReturnFalse, new List<string>() { routeAcceptDetail.snippet.name, routeAcceptDetail.snippet.title, routeAcceptDetail.snippet.returnmessage }, true);
                }
            }
            return false;
        }
        private bool CheckRouting() // Start Check Routing process
        {
            if (Operation == "") return SetMsgAndReturn(EnumMessage.SystemNoOperationAssign, new List<string>() { SnDetail.number }, false);
            var routeDetailList = GetWsObj.GetRoutingDetail(Route, Operation);
            if (routeDetailList == null) return SetMsgAndReturn(EnumMessage.OperationNotFoundInRoute, new List<string>() { Route, Operation }, false);

            if (!routeDetailList.Any()) return SetMsgAndReturn(EnumMessage.OperationNotFoundInRoute, new List<string>() { Route, Operation }, false);
            RouteDetail = GetWsObj.GetRoutingDetailList(routeDetailList[0].url);
            if (Operation == SnDetail.current_operation) return CheckExcept(RouteDetail);

            if (CheckAccept(RouteDetail)) return true;// if true = accept route
            return SetMsgAndReturn(EnumMessage.WrongOperation, new List<string>() { SnDetail.number, SnDetail.current_operation }, false);
        }
        public string ValidateNextCode()
        {
            if (RouteDetail.next_code.Count <= 0) return RouteDetail.next_pass; // if no config no action
            foreach (NextCodeVm code in RouteDetail.next_code)
            {
                var snip = (SnipVm)GetWsObj.GetSnippetBySlug(code.slug);
                if (!(snip.code != "" & snip.status == EnumStatus.A.ToString())) continue;
                if (!GetFlexObj.ExecuteScript(snip.code, GetWsObj.TokenAccessKey)) continue;
                SetMsgAndReturn(EnumMessage.NextCodeExecute, new List<string>() { snip.name, snip.title, snip.returnmessage, RouteDetail.next_pass, RouteDetail.operation }, true);
                RouteDetail.next_pass = RouteDetail.operation;
                return RouteDetail.operation;
            }
            return RouteDetail.next_pass;
        }

        private bool _disposedValue; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }
                SnDetail = null;
                RouteDetail = null;
                ReturnMsg = null;
            }
            _disposedValue = true;
        }
        public void Dispose() => Dispose(true);
        #region "transaction"
        public int EngageTransaction(SnEngageVm data)
        {
            var resultvalue = (int)GetWsObj.GetSnCreate(data);
            SetMsgAndReturn(resultvalue > 0 ? EnumMessage.TransactionSuccess : EnumMessage.TransactionParamFail, new List<string>() { data.number }, true);
            return resultvalue;
        }
        public int EngageTransactionUpdate(SnEngageUpdateVm data, string slug)
        {
            var resultvalue = (int)GetWsObj.GetSnUpdate(data, slug);
            SetMsgAndReturn(resultvalue > 0 ? EnumMessage.TransactionSuccess : EnumMessage.TransactionParamFail, new List<string>() { data.number }, true);
            return resultvalue;
        }
        public int PerformTransaction(SnPerformVm data, string sn)
        {
            var resultvalue = (int)GetWsObj.GetSnPerform(data);
            SetMsgAndReturn(resultvalue > 0 ? EnumMessage.TransactionSuccess : EnumMessage.TransactionParamFail, new List<string>() { sn }, true);
            return resultvalue;
        }
        #endregion
    }
}
