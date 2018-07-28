using Model.Interfaces;

namespace _8mpBl.Model.Snip
{
    public class SnipVm : INameTitleVm, IDesCatVm, ISlugUrlVm, IUserStatusVm
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string cagegory1 { get; set; }
        public string cagegory2 { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public bool linenos { get; set; }
        public string language { get; set; }
        public string style { get; set; }
        public string highlight { get; set; }
        public string returnmessage { get; set; }
    }
}

