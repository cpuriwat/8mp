using System;
using System.Collections.Generic;
using _8mpBl.Enums;
using _8mpBl.Model.General;

namespace _8mpBl.Helper.Interfaces
{
    public interface IMessageTextHandler : IDisposable
    {
        ReturnMsgVm GetSystemMsg(EnumMessage eCode, List<string> value);
        ReturnMsgVm GetSystemMsg(EnumMessage errCode, string value);
        ReturnMsgVm GetSystemMsg(EnumMessage errCode);
        void ClearSystemCommunicationError();
    }
}
