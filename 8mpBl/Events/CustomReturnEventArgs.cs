using System;
using _8mpBl.Enums;
using _8mpBl.Model.General;

namespace _8mpBl.Events
{
    public class CustomReturnEventArgs : EventArgs
    {
        public ReturnMsgVm ReturnMsg;
        public EnumResult ReturnResult;
        public EventArgs ReturnEvent;
    }
}
