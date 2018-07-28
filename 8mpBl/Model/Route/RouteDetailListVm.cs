using Model;

namespace _8mpBl.Model.Route
{
    public class RouteDetailListVm : CommonDesCateUrlSlugVm
    {
        public string operation { get; set; }
        public string routing { get; set; }
        public string position { get; set; }
        public string next_pass { get; set; }
        public string next_fail { get; set; }
    }
}
