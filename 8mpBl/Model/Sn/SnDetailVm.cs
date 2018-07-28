using _8mpBl.Model.General;

namespace _8mpBl.Model.Sn
{
    public class SnDetailVm : CommonMainSingleVm
    {
        public int id { get; set; }
        public string routing { get; set; }
        public string workorder { get; set; }
        public string number { get; set; }
        public string slug { get; set; }
        public string registered_date { get; set; }
        public string last_modified_date { get; set; }
        public bool last_result { get; set; }
        public string finished_date { get; set; }
        public bool wip { get; set; }
        public string perform_start_date { get; set; }
        public string status { get; set; }
        public string current_operation { get; set; }
        public string last_operation { get; set; }
        public string perform_operation { get; set; }
    }
}
