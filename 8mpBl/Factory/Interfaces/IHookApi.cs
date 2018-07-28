using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _8mpBl.Enums;
using _8mpBl.Model.Snip;

namespace _8mpBl.Factory.Interfaces
{
    public delegate void FinishEventEventHandler(string objName, string objType, SnipVm code, EnumResult result, Control o);
    public interface IHookApi
    {
        void HookCustomEvent(Control obj, List<string> hookName);
        event FinishEventEventHandler FinishEvent;
        List<string> GetHookList();
    }
}

