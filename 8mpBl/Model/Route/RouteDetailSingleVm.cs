using Model.Interfaces;
using _8mpBl.Model.Snip;

namespace _8mpBl.Model.Route
{
    public class RouteDetailSingleVm : INameTitleVm, IDesCatVm, IUserStatusVm, ICreateModDateVm
    {
        public int id { get; set; }
        public SnipVm snippet { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string cagegory1 { get; set; }
        public string cagegory2 { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
