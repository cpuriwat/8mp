using System.Drawing;
using System.Windows.Forms;
using _8mpBl.Enums;

namespace _8mpBl.Helper.Classes
{
    public partial class ControlBuilder
    {
        public void MessageLabel(EnumMessage msgEnum, Label label)
        {
            var msg = ((int)msgEnum).ToString();
            label.Text = _objMsg.GetSystemMsg(msgEnum).ReturnMsg;
            label.ForeColor = Color.Black;
            if (msg.Substring(1, 1) == "9")label.ForeColor = Color.Red;
            if (msg.Substring(1, 1) == "1")label.ForeColor = Color.Green;
        }
    }
}

