using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcParam
    {
        public IParamApi ObjParam;
        public UcParam(IParamApi objParam, IControlBuilder objObjControlBuild) : base(objParam.GetFlexObj, objParam.GetWsObj, objParam.GetMsgObj, objParam.FormObject, objParam.Operation, objObjControlBuild)
        {
            ObjParam = objParam;
            InitializeComponent();
            HookCustomEvent(this, ObjParam);

        }
        private void UcParam_Load(object sender, EventArgs e)
        {
            LoadParameter();
            var ucList = ObjControlBuilder.FindControlsByType<IMpUserControlParam>(this, new List<Control>());
            foreach (var c in ucList)
            {
                var uc = (IMpUserControlParam)c;
                uc.FinishEvent += UcParam_Finish;
            }
        }
        private void LoadParameter()
        {
            TabControl tabControl = new TabControl() { Name = "Parameter" };
            tabControl.SelectedIndexChanged += ObjControlBuilder.FindAndSetFocus;

            foreach (string paramSlug in ObjParam.RouteDetail.parameter)
            {
                var param = ObjParam.GetParameterProfileDetail(paramSlug);
                var tabPage = new TabPage { Text = param.title ?? param.name, Name = param.name, AutoSize = true, Size = new Size(tabControl.Width, 1300) };
                //tabControl.TabPages.Add(tabPage);
                AddParameterToPage(tabPage, param, tabControl, param.title, param.name);
            }
            tabControl.SelectedTab = tabControl.TabPages[0];
            tabControl.Show();
            Controls.Add(tabControl);
        }
        private void AddParameterToPage(TabPage page, ParameterVm paramVm, TabControl tbc, string pageTitle, string pageName)
        {
            var lt = new List<IMpUserControlParam>();
            var sumH = 0;
            var maxW = 500;
            var maxLabelW = 100;
            var i = 1;
            foreach (ParameterItemVm paramItem in paramVm.items.Where(s => s.status == EnumStatus.A.ToString()).OrderBy(s => s.ordered))
            {
                IParamItemApi objParamItem = new ParamItemApi(ObjParam.GetWsObj, ObjParam.GetMsgObj, ObjParam.GetFlexObj, paramItem) { RouteDetail = ObjParam.RouteDetail };
                IMpUserControlParam ucParamItem;
                if (paramItem.input_type == EnumParamItemType.LIST.ToString()){ucParamItem = new UcParamItemList(objParamItem, ObjControlBuilder);}
                else if (paramItem.input_type == EnumParamItemType.RADIO.ToString()){ucParamItem = new UcParamItemRadio(objParamItem, ObjControlBuilder);}
                else if (paramItem.input_type == EnumParamItemType.OPTION.ToString()){ucParamItem = new UcParamItemOption(objParamItem, ObjControlBuilder);}
                else {ucParamItem = new UcParamItemTextBox(objParamItem, ObjControlBuilder);}

                ucParamItem.SetTabIndex(i);
                ucParamItem.ShowData();
                sumH = sumH + ucParamItem.ControlHeight;
                if (ucParamItem.ControlWidth > maxW)maxW = ucParamItem.ControlWidth;
                if (ucParamItem.LabelParamNameWidth > maxLabelW)maxLabelW = ucParamItem.LabelParamNameWidth;
                lt.Add(ucParamItem);
                i = i + 1;
            }
            var ltControl = new List<UserControl>();
            foreach (var obj in lt)
            {
                obj.LabelWidth(maxLabelW);
                ltControl.Add((UserControl) obj);
            }
            if (tbc.Size.Height <= sumH)tbc.Size = new Size(maxW, sumH + 50);
            if (page.Size.Height <= sumH)page.Size = new Size(maxW, sumH + 50);
            page.Refresh();

            ObjControlBuilder.RenderTabForm(ltControl, pageName, pageTitle, tbc, false);
        }


        private void UcParam_Finish(object sender, EventArgs e)
        {
            //TODO : cast to ucparamitem
            //_objParam.ReturnMsg = sender.ReturnMsg;
            //_objParam.Result = sender.Result;
            //CustomMpUserControl.RaiseFinishEvent(sender, new EventArgs());
        }


    }
}
