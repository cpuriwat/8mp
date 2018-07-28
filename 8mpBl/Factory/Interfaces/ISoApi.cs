using System.Collections.Generic;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Factory.Interfaces
{
    public interface ISoApi : IMpCommonApi
    {
        object GetOrder();
        List<WorkOrderVm> GetOrderVm();
        List<WorkOrderVm> GetOrderVm(string prod);
        string ShopOrder { get; set; }
        string ShopOrderName { get; set; }
        bool CheckWorkOrder(string wo);
        List<WorkOrderVm> GetProductVm();
        WorkOrderDetailVm GetOrderDetailVm(string order);
    }
}
