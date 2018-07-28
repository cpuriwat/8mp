using System;
using System.Windows.Forms;
using _8mp.Uc;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;

namespace _8mp.Helper.Classes
{
    partial class MpModuleController
    {
        private void RenderUcSo()
        {
            var objUcSo = new UcSo(new SoApi(_objWs, _objMsg, _objFlex) { FormObject = FormObject, Operation = _operation, LoginInfo = LoginInfo }, _objCb);
            AssignedUcEvent(objUcSo);
            objUcSo.FinishEvent += UcSo_Finish;
            _listOfUc.Add(objUcSo);
        }
        private void UcSo_Finish(object sender, CustomReturnEventArgs e)
        {
            AddMessage(e.ReturnMsg);
            var objSn = (UcSn)_objCb.FindControlInList<UcSn>(_listOfUc);
            if (objSn != null) objSn.ObjSnApi.ShopOrder =((UcSo)sender).ObjSoApi.ShopOrder;
            if (Result == EnumResult.Pass) SendKeys.Send("{TAB}");
        }
    }
}
