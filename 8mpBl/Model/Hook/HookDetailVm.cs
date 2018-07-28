using _8mpBl.Model.General;

namespace Model
{
    public class HookDetailVm : CommonMainSingleVm
    {
        public int id { get; set; }
        public string routing_detail { get; set; }
        public string snippet { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public int ordered { get; set; }
        public string @event { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }
    }
}
