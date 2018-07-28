using Model.Interfaces;

namespace _8mpBl.Model.Parameter
{
    public class ParameterItemListValueVm : INameTitleVm, IDesCatVm, IUserStatusVm, ICreateModDateVm
    {
        public string name { get; set; }
        public string value { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public bool @default { get; set; }
        public int ordered { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string cagegory1 { get; set; }
        public string cagegory2 { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
