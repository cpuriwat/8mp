using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using _8mpBl.Enums;
using _8mpBl.Model.General;

namespace _8mp.Helper.Interfaces
{
    public interface IMpModuleController
    {
        Control FormObject { get; set; }
        ReturnMsgVm ReturnMsgVm { get; set; }
        EnumResult Result { get; set; }
        DockPanel DockPanelMain { get; set; }
        LoginInfoVm LoginInfo { get; set; }
        void LoadMain();
    }
}
