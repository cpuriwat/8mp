using System.Collections.Generic;
using _8mpBl.Model.Sn;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public object GetSnCreate(object data)
        {
            return GetHttpPost(data, "/api/serialnumber/create/");
        }
        public object GetSnUpdate(object data, string slug)
        {
            return GetHttpPost(data, "/api/serialnumber/" + slug + "/update/");
        }
        public object GetSnPerform(object data)
        {
            return GetHttpPost(data, "/api/performing/create/");
        }
        public List<SnVm> GetSn(string sn)
        {
            return GetJsonObject<List<SnVm>>("/api/serialnumber/?q=" + sn);
        }
    }
}

