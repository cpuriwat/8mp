using _8mpBl.Model.General;
using _8mpBl.Model.Route;

namespace _8mpBl.Model.WorkOrder
{
    public class WorkOrderDetailVm : CommonMainSingleVm
    {
        public string name { get; set; }
        public RouteListVm routing { get; set; }
        public string product { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string qty { get; set; }
        public string regexp { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
        public string finished_date { get; set; }
    }
}
