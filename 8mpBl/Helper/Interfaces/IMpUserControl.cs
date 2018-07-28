using System;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Model.General;

namespace _8mpBl.Helper.Interfaces
{
    public interface IMpUserControl
    {
        event  EventHandler<CustomReturnEventArgs> FinishEvent;
        event EventHandler UcLoadEventEventHandler;
        // Property ReturnMsg() As ReturnMsg
        ReturnMsgVm ReturnMsgVm { get; set; }
        EnumResult Result { get; set; }
        void ResetControl(bool success);
        void SetTabIndex(int ind);
        void SetFocus();
        void EnableControl(bool enable);
        void HookEvent();
    }
}
