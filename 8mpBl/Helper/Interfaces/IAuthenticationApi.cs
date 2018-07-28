using System;
using _8mpBl.Model.General;

namespace _8mpBl.Helper.Interfaces
{
    public interface IAuthenticationApi : IDisposable
    {
        string Message { get; set; }
        int MessageCode { get; set; }
        bool TokenRequest(string username, string password);
        ReturnMsgVm ReturnMsg { get; set; }

    }
}
