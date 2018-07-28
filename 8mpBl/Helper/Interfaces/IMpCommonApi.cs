using System.Collections.Generic;
using Interfaces.Helper;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Model.General;
using _8mpBl.Model.Route;

namespace _8mpBl.Helper.Interfaces
{
    public interface IMpCommonApi
    {
        object FormObject { get; set; }
        ReturnMsgVm ReturnMsg { get; set; }
        List<ReturnMsgVm> ListReturnMsgVm { get; set; }
        EnumResult Result { get; set; }
        void SetFocus();
        IWebServiceHelper GetWsObj { get; set; }
        IMpFlex GetFlexObj { get; set; }
        IMessageTextHandler GetMsgObj { get; set; }
        string Operation { get; set; }
        LoginInfoVm LoginInfo { get; set; }
        RouteDetailOperationStepVm RouteDetail { get; set; }
    }
}
