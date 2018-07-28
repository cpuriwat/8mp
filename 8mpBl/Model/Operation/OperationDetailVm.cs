using _8mpBl.Model.General;

namespace Model.Operation
{
    public class OperationDetailVm : CommonMainSingleVm
    {
        public string name { get; set; }
        public string operation_type { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string customer_name { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
