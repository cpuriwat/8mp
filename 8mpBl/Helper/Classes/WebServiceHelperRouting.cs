using System.Collections.Generic;
using _8mpBl.Model.Route;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public RouteListVm GetRoute(string slug)
        {
            return GetJsonObject<RouteListVm>("/api/routing/" + slug);
        }
        public object GetRoutingDetail(string slug)
        {
            return GetJsonObject("/api/routing-detail/" + slug);
        }
        public List<RouteDetailListVm> GetRoutingDetail(string route, string operation)
        {
            return GetJsonObject<List<RouteDetailListVm>>("/api/routing-detail/?route=" + route + "&operation=" + operation);
        }
        public RouteDetailOperationStepVm GetRoutingDetailList(string url)
        {
            var result = GetJsonObjectUrl<RouteDetailOperationStepVm>(url);
            return result;
        }
        public RouteDetailSingleVm GetSnipByRouteRejectName(string routeRejectSlug)
        {
            return GetJsonObject<RouteDetailSingleVm>("/api/routing-reject/" + routeRejectSlug + "/");
        }
        public RouteDetailSingleVm GetSnipByRouteAcceptName(string routeRejectSlug)
        {
            return GetJsonObject<RouteDetailSingleVm>("/api/routing-accept/" + routeRejectSlug + "/");
        }
        public object GetNextCode(string slug)
        {
            return GetJsonObject<NextCodeDetailVm>("/api/routing-next/" + slug + "/");
        }
    }
}

