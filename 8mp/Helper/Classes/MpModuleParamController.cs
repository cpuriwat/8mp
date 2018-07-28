using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _8mp.Uc;
using _8mpBl.Enums;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;

namespace _8mp.Helper.Classes
{
    partial class MpModuleController
    {
        private void RenderModule(Control obj)
        {
            var objSn = (UcSn) obj;
            var objUcParam = new UcParam(new ParamApi(_objWs, _objMsg, _objFlex, _objCb) { FormObject = objSn.ObjSnApi.FormObject, RouteDetail = objSn.ObjSnApi.RouteDetail, SnId = objSn.ObjSnApi.SnDetail.id }, _objCb);
            objUcParam.FinishEvent += UcParam_Finish;
            _objCb.RenderTabForm(new List<UserControl>(){objUcParam},"Tab_" + _tabControl.TabCount, "Unit Parameter", _tabControl, false);

            // set failureapi with SN property, then implement new IUserControl.RefreshForm .
            // in event RefreshForm on usercontrol, inside you can call any method in failureapi inside. (apply to all custom usercontrol).
            //_listOfObjSnBase.Add(objParam);
        }
        protected void OnUcParamRendering(object sender, EventArgs e) => RenderModule((Control)sender);
        private void UcParam_Finish(object sender, EventArgs e) => AddMessage(((UcParam) sender).ReturnMsgVm);
    }
}
