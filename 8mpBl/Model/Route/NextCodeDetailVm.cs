using Model;

namespace _8mpBl.Model.Route
{
    public class NextCodeDetailVm : CommonDesCateUrlSlugVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string create_date { get; set; }
        public string modified_data { get; set; }
        public string snippet { get; set; }
        public int user { get; set; }
    }
}

