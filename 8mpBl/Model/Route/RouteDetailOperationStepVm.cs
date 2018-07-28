using System.Collections.Generic;
using Model;
using _8mpBl.Model.General;

namespace _8mpBl.Model.Route
{
    public class RouteDetailOperationStepVm : CommonMainSingleVm
    {
        public int id { get; set; }
        public List<string> accept_code { get; set; }
        public List<string> reject_code { get; set; }
        public List<string> parameter { get; set; }
        public List<NextCodeVm> next_code { get; set; }
        public List<string> hook_set { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
        public string operation { get; set; }
        public string routing { get; set; }
        public string position { get; set; }
        public string next_pass { get; set; }
        public string next_fail { get; set; }
        public int user { get; set; }
    }
}
