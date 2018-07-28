using System;
using Interfaces.Api;
using Interfaces.Helper;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;

namespace _8mpBl.Factory.Classes
{
    public class AuthenticationApi : IAuthenticationApi
    {
        public string Message { get; set; }
        public int MessageCode { get; set; }
        public ReturnMsgVm ReturnMsg { get; set; }
        private IWebServiceHelper _objWs;
        private IMessageTextHandler _objMsg;
        public AuthenticationApi(IWebServiceHelper objWs, IMessageTextHandler objMsg)
        {
            _objWs = objWs;
            _objMsg = objMsg;
        }
        public bool TokenRequest(string username, string password)
        {
            var result = _objWs.GetHttpPost("username=" + username + "&password=" + password);
            Message = _objWs.ReturnMsg.ReturnMsg;
            MessageCode = (int) _objWs.ReturnMsg.ReturnMsgEnum;
            ReturnMsg = _objWs.ReturnMsg;
            return result;
        }

        public void Dispose()
        {
            _objWs.Dispose();
            _objWs = null;
            _objMsg.Dispose();
            _objMsg = null;
            GC.SuppressFinalize(this);
        }
    }
}
