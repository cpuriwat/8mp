using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8mp.Uc;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;

namespace _8mp.Helper.Classes
{
    public partial class MpModuleController
    {
        private void RenderModule(IFailureApi objApi)
        {
            var objSn = (ISnApi) _objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            var objParam = (IParamApi) _objCb.FindControlHasInterfaceInList<IParamApi>(_listOfObjSnBase);
            var result = _objTrans.ProcessTransactionFail(objSn, objParam, objApi);
            if (result) CancelSn(true);
        }
        private void UcFailure_Finish(object sender, CustomReturnEventArgs e)
        {
            AddMessage(e.ReturnMsg);
            var obj = (IFailureApi)_objCb.FindControlHasInterfaceInList<IFailureApi>(_listOfObjSnBase);
            if (obj == null) return;
            AddMsg(obj, sender);
            RenderModule(obj);
        }
    }
}
