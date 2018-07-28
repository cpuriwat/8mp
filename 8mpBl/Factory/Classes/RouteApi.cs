using Interfaces.Helper;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Factory.Classes
{
    public class RouteApi : IRouteApi
    {
        private readonly IWebServiceHelper _wsHelper;
        private readonly IMessageTextHandler _errCode;
        public RouteApi(IWebServiceHelper wsHelper, IMessageTextHandler errCode)
        {
            _wsHelper = wsHelper;
            _errCode = errCode;
        }
        object IRouteApi.GetRoutingDetail(string vRoute, string vOperation)
        {
            return _wsHelper.GetRoutingDetail(vRoute, vOperation);
        }

        object IRouteApi.GetRoutingDetail(string vSlug)
        {
            return _wsHelper.GetJsonObject(vSlug);
        }

        object IRouteApi.GetNextCode(string vSlug)
        {
            return _wsHelper.GetNextCode(vSlug);
        }
    }
}

