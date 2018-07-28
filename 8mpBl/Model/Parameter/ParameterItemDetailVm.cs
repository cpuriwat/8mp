using System.Collections.Generic;
using Model.Interfaces;

namespace _8mpBl.Model.Parameter
{
    public class ParameterItemDetailVm : INameTitleVm, IDesCatVm, IUserStatusVm, ICreateModDateVm
    {
        public int id { get; set; }
        public string url { get; set; }
        public List<ParameterItemListValueVm> lists { get; set; }
        public string snippet { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public string help_text { get; set; }
        public string input_type { get; set; }
        public string cagegory1 { get; set; }
        public string cagegory2 { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
        public string expected_return { get; set; }
        public string product { get; set; }
        public string user { get; set; }
    }
}
