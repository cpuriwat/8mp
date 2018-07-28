using System.Collections.Generic;
using _8mpBl.Model.General;
using _8mpBl.Model.Parameter;
using _8mpBl.Model.Product;
using _8mpBl.Model.Route;
using _8mpBl.Model.Sn;
using _8mpBl.Model.Snip;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Helper.Interfaces
{
    public partial interface IWebServiceHelper
    {
        bool ReturnAsModel { get; set; }
        ReturnMsgVm ReturnMsg { get; set; }
        string TokenAccessKey { get; set; }
        int UserId { get; set; }
        object GetSnCreate(object data);
        object GetParameterBySlug(string routingDetailSlug);
        object GetItemBySlug(string parameterSlug);
        object GetSnUpdate(object data, string slug);
        SnipVm GetSnippetBySlug(string vSnippetSlug);
        string ValidateUserAndPasswordWithAccess(string user, string password, string station);
        object GetSnPerform(object data);
        object GetParametric(object data);
        object GetOperation(string slug);
        object GetListOperations(int userid);
        string GetTokenPath();
        ProductDetailVm GetProductBySlug(string slug);
        List<WorkOrderVm> GetWorkOrder();
        List<WorkOrderVm> GetWorkOrder(string product);
        WorkOrderDetailVm GetWorkOrderDetail(string wo);
        object GetListOperations();
        WorkOrderDetailVm GetWorkOrderBySlug(string slug);

          List<SnVm> GetSn(string sn);


        RouteListVm GetRoute(string slug);
        List<RouteDetailListVm> GetRoutingDetail(string route, string operation);
        RouteDetailOperationStepVm GetRoutingDetailList(string url);
        object GetRoutingDetail(string slug);
        object GetNextCode(string slug);
        RouteDetailSingleVm GetSnipByRouteRejectName(string routeRejectSlug);
        RouteDetailSingleVm GetSnipByRouteAcceptName(string routeAcceptSlug);

        ParameterVm GetParameterProfileDetail(string slug);
        string GetTokenRefreshPath();
        ParameterItemDetailVm GetParameterItemDetail(string slug);
        object GetFailureCode();
        object GetDefectCode();
        object GetDefectCode(string failureCode);
        object GetReworkCode(string defectCode);
        object GetFailureHistory(string sn);
        object GetBomDetail(string slug);
        object GetHookDetail(string slug);
    }
}
