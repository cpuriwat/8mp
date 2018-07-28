using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8mp.Uc;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Helper.Classes
{
    partial class MpModuleController
    {
        private void RenderUcSn()
        {
            var objUcSn = new UcSn(new SnApi(_objWs, _objMsg, _objFlex) { Operation = _operation, FormObject = FormObject, LoginInfo = LoginInfo }, _objCb);
            AssignedUcEvent(objUcSn);
            objUcSn.ParamRendering += OnUcParamRendering;
            objUcSn.FinishEvent += UcSn_Finish;
            _listOfUc.Add(objUcSn);
        }
        private void UcSn_Finish(object sender, EventArgs e)
        {
            var obj = (ISnApi)_objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            if (obj == null) return;
            AddMsg(obj, sender);
            var uc = (IMpUserControl)sender;
            uc.EnableControl(false);
            //RenderModule(obj);
        }
    }
}
