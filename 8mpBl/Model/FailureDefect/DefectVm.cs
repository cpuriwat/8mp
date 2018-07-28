using Model.Interfaces;

namespace _8mpBl.Model.FailureDefect
{
    public class DefectVm : IUserStatusVm, ICreateModDateVm
    {
        public string defect_code { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
