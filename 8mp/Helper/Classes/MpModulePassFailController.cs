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
    partial class MpModuleController
    {
        private void RenderModule (IPassFailApi objApi)
        {
            var objSn = (ISnApi)_objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            switch (objApi.Result)
            {
                case EnumResult.ButtonPass:
                    if (objApi.Result != EnumResult.ButtonSubmit) return;
                    var objParam = (IParamApi)_objCb.FindControlHasInterfaceInList<IParamApi>(_listOfObjSnBase);
                    var result = _objTrans.ProcessTransactionPass(objSn, objParam);
                    if (result) CancelSn(true);
                    break;
                case EnumResult.ButtonFail:
                    var objFailure = new FailureApi(_objWs, _objMsg, _objFlex, _objCb) { FormObject = objSn.FormObject, UnitSn = objSn.UnitSn };
                    if (_mType == EnumOperationType.INSPECTION)
                        objFailure.ReworkOperation = true; // TODO: need condition to show rework group or not
                    var objUcFailure = new UcFailure(objFailure, _objCb);
                    objUcFailure.FinishEvent += UcFailure_Finish;
                    var lt = new List<UserControl> {objUcFailure};
                    _objCb.RenderTabForm(lt, objFailure.GetType().Name, "Unit Failure", _tabControl, true);
                    _listOfObjSnBase.Add(objFailure);
                    break;
                case EnumResult.ButtonSubmitFail: break;
            }
        }
        private void UcPassFail_Finish(object sender, CustomReturnEventArgs e)
        {
            AddMessage(e.ReturnMsg);
            switch (e.ReturnResult)
            {
                case EnumResult.ButtonCancel: CancelSn(false); return;
                case EnumResult.ButtonFail: RenderModule((IPassFailApi)sender); return;
                case EnumResult.ButtonPass: RenderModule((IPassFailApi)sender); return;
            }
        }
    }
}
