using System.Collections.Generic;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public List<WorkOrderVm> GetWorkOrder()
        {
            return GetJsonObject<List<WorkOrderVm>>("/api/workorder/");
        }
        public List<WorkOrderVm> GetWorkOrder(string product)
        {
            return GetJsonObject<List<WorkOrderVm>>("/api/workorder/?name=" + product);
        }
        public WorkOrderDetailVm GetWorkOrderBySlug(string slug)
        {
            return GetJsonObject<WorkOrderDetailVm>("/api/workorder/" + slug + "/");
        }
        public WorkOrderDetailVm GetWorkOrderDetail(string wo)
        {
            return GetJsonObject<WorkOrderDetailVm>("/api/workorder/" + wo + "/");
        }
    }
}

