using System.Collections.Generic;
using Model.Interfaces;

namespace _8mpBl.Model.FailureDefect
{
    public class UnitFailureVm : IUserStatusVm, ICreateModDateVm
    {
        public string number { get; set; }
        public string fail_code { get; set; }
        public List<UnitDefectVm> defect_code { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
