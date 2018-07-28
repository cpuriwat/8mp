using System.Collections.Generic;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public object GetBomDetail(string slug)
        {
            return GetJsonObject<List<BomDetailVm>>("/api/bom-detail/?slug=" + slug);
        }
    }
}

