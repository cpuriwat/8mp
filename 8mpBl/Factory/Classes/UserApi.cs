using System;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Factory.Classes
{
    public class UserApi : IUserApi
    {
        public string ApiHost { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Station { get; set; }
        public int StationId { get; set; }
        public DateTime LoginDateTime { get; set; }
        private readonly IWebServiceHelper _wsHelper;
        public UserApi()
        {
        }
        public UserApi(IWebServiceHelper wsHelper)
        {
            _wsHelper = wsHelper;
        }
        public string ValidateUserAndPasswordWithAccess(string user, string password, string station)
        {
            return _wsHelper.ValidateUserAndPasswordWithAccess(user, password, station);
        }
    }
}
