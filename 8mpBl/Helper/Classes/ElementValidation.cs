using System;
using System.Windows.Forms;
using Interfaces.Helper;
using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Helper.Classes
{
    public class ElementValidation : IElementValidate
    {
        private readonly IMessageTextHandler _objErr;
        public ElementValidation(IMessageTextHandler objErr)
        {
            _objErr = objErr;
        }
        public string ValidateFillComplete(Control objC)
        {
            foreach (var cCont in objC.Controls)
            {
                if (!(cCont is TextBox c)) continue;
                if (c.Name.Substring(0, 1).ToLower() == "r" && c.Text == "") return _objErr.GetSystemMsg(EnumMessage.ElementIsEmpty, c.Name).ReturnMsg;
            }
            return "OK";
        }
    }
}
