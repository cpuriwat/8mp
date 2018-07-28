using System.Collections.Generic;
using Model.Interfaces;

namespace _8mpBl.Model.FailureDefect
{
    public class UnitDefectVm : IUserStatusVm, ICreateModDateVm
    {
        public string defect_code { get; set; }
        public string rd { get; set; }
        public string pn { get; set; }
        public bool rootcause { get; set; }
        public List<UnitReworkVm> rework { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
