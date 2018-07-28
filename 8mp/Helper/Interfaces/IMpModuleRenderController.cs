using System;
using _8mpBl.Events;

namespace _8mp.Helper.Interfaces
{
    internal interface IMpModuleRenderController
    {
        //void RenderModule();
        //void RenderUc(Control formObject, string operation, LoginInfoVm loginInfo);
        event EventHandler<CustomReturnEventArgs> MsgRendering;
        event EventHandler EnableOtherControlRendering;
    }
}
