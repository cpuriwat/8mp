using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;

namespace _8mp.Helper.Classes
{
    partial class MpModuleController
    {
        private void UcSubmit_Finish(object sender, CustomReturnEventArgs e)
        {
            AddMessage(e.ReturnMsg);
            switch (e.ReturnResult)
            {
                case EnumResult.ButtonCancel: CancelSn(false); return;
                case EnumResult.ButtonSubmit: RenderModule((ISubmitApi)sender); return;
            }
        }
        private void RenderModule(ISubmitApi objApi)
        {
            if (objApi.Result != EnumResult.ButtonSubmit) return;
            var objSn = (ISnApi)_objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            var objSo = (ISoApi)_objCb.FindControlHasInterfaceInList<ISoApi>(_listOfObj);
            var objParam = (IParamApi)_objCb.FindControlHasInterfaceInList<IParamApi>(_listOfObjSnBase);
            var result = _objTrans.ProcessTransaction(objSn, objSo, objParam);
            if (result) CancelSn(true);
        }
    }
}

