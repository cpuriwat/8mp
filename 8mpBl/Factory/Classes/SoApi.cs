using System;
using System.Collections.Generic;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Factory.Classes
{
    public class SoApi : ISoApi, IDisposable
    {
        private bool _disposedValue; // To detect redundant calls
        public ReturnMsgVm ReturnMsg { get; set; }
        public List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        public EnumResult Result { get; set; }
        public IWebServiceHelper GetWsObj { get; set; }
        public IMpFlex GetFlexObj { get; set; }
        public IMessageTextHandler GetMsgObj { get; set; }
        public string Operation { get; set; }
        public object FormObject { get; set; }
        public string ShopOrder { get; set; }
        public string ShopOrderName { get; set; }
        public LoginInfoVm LoginInfo { get; set; }
        public RouteDetailOperationStepVm RouteDetail { get; set; }
        public SoApi(IWebServiceHelper wsHelper, IMessageTextHandler errCode, IMpFlex objFlex)
        {
            GetWsObj = wsHelper;
            GetMsgObj = errCode;
            GetFlexObj = objFlex;
        }

        public void SetFocus()
        {
        }
        public object GetOrder()
        {
            return GetWsObj.GetWorkOrder();
        }
        public List<WorkOrderVm> GetOrderVm()
        {
            return GetWsObj.GetWorkOrder();
        }
        public WorkOrderDetailVm GetOrderDetailVm(string order)
        {
            return GetWsObj.GetWorkOrderDetail(order);
        }
        public List<WorkOrderVm> GetOrderVm(string prod)
        {
            return GetWsObj.GetWorkOrder(prod);
        }
        public List<WorkOrderVm> GetProductVm()
        {
            List<WorkOrderVm> result = GetWsObj.GetWorkOrder();
            return result ?? new List<WorkOrderVm>();
        }
        public bool CheckWorkOrder(string wo)
        {
            ShopOrder = wo??"";
            if (GetMsgObj != null) ReturnMsg = GetMsgObj.GetSystemMsg(EnumMessage.ValueSelected, new List<string>() {ShopOrder});
            return true;
        }


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
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
