using System.Collections.Generic;
using _8mpBl.Model.Operation;
using _8mpBl.Model.User;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public string ValidateUserAndPasswordWithAccess(string user, string password, string station)
        {
            return (string)GetJsonObject("GetAuthenication/?username=" + user + "&password=" + password + "&station=" + station);
        }

        public object GetOperation(string slug)
        {
            return GetJsonObject<global::Model.Operation.OperationDetailVm>("/api/operation/" + slug + "/");
        }

        public object GetListOperations()
        {
            return GetJsonObject<List<OperationVm>>("/api/operation/");
        }
        public object GetListOperations(int userId)
        {
            var result = GetJsonObject<UserDetailVm>("/api/users/" + userId.ToString() + "/");
            return result != null ? result.operations : new List<OperationVm>();
        }
        public string GetTokenPath()
        {
            return _hostApiUrl + "/api/token/";
        }
        public string GetTokenRefreshPath()
        {
            return _hostApiUrl + "/api/token/refresh/";
        }
    }
}
