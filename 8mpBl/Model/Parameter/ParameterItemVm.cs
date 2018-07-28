using Model.Interfaces;

namespace _8mpBl.Model.Parameter
{
    public class ParameterItemVm : INameTitleVm
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string input_type { get; set; }
        public string default_value { get; set; }
        public string regexp { get; set; }
        public int ordered { get; set; }
        public string status { get; set; }
        public string slug { get; set; }
        public bool required { get; set; }
    }
}
