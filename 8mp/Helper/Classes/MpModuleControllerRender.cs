using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using _8mp.Form;
using _8mp.Helper.Interfaces;
using _8mp.Uc;
using _8mpBl.Enums;
using _8mpBl.Factory.Classes;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Helper.Classes
{
    public partial class MpModuleController
    {
        //private void EnableModule<T>(bool enable)
        //{
        //    var c = (IMpUserControl)_objCb.FindControlInList<T>(_listOfUc);
        //    if (c == null) return;
        //    c.EnableControl(enable); c.SetFocus();
        //}
        private void RenderModule()
        {
            ClearDockContent(_dockContent);
            switch (_mType)
            {
                case EnumOperationType.REGISTERATION:
                    {
                        RenderUcSo();
                        RenderUcSn();
                        RenderUcSubmit();
                        break;
                    }
                case EnumOperationType.INSPECTION:
                    {
                        RenderUcSn();
                        RenderUcPassFail();
                        break;
                    }
                case EnumOperationType.TROUBLESHOOTING:
                    {
                        RenderUcSn();
                        RenderUcFailure();
                        RenderUcSubmit();
                        break;
                    }
            }
            _tabControl = RenderForm(_dockContent, _listOfUc, "TabMain", "Main Operation", new TabControl() { Name = "TabControlMain", Dock = DockStyle.Fill });
            //_tabControl.SelectedIndexChanged += _objCb.FindAndSetFocus();
            if (_mType != EnumOperationType.REGISTERATION) return;
            var objSn = (ISnApi)_objCb.FindControlHasInterfaceInList<ISnApi>(_listOfObj);
            var objSo = (ISoApi)_objCb.FindControlHasInterfaceInList<ISoApi>(_listOfObj);
            if (objSo != null && objSn != null) objSn.ShopOrder = objSo.ShopOrder;
        }

       
        //private void TabSelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    // TODO : find control in tabpage 
        //    _objCb.FindAndSetFocus(sender.SelectedTab);
        //}
        private void AssignedUcEvent(IMpModuleRenderController obj)
        {
            obj.MsgRendering += OnMsgUcRendering;
            obj.EnableOtherControlRendering += OnUcSnEnable;
        }
        private void ClearDockContent(MpDockContent doc)
        {
            // TODO : find method to clear sn based dock content
            if (doc.Controls.Count <= 0) return;
            for (var ix = doc.Controls.Count - 1; ix >= 0; ix += -1) doc.Controls[ix].Dispose();
            for (var ix = _listOfObj.Count - 1; ix >= 0; ix += -1)
            {
                if (_listOfObj[ix] == null) continue;
                var c = (IDisposable)_listOfObj[ix];
                _listOfObj.RemoveAt(ix);
                c.Dispose();
                c = null;
            }
            _tabControl?.Dispose();
            _listOfUc.Clear();
            _listOfUcSnBase.Clear();
            _listOfMpDockContent.Clear();
            _listOfObj.Clear();
            _listOfObjSnBase.Clear();
        }
        public void LoadMain()
        {
            if (DockPanelMain == null) return;
            DockPanelMain.DockLeftPortion = 0.2;
            _dockContent = new MpDockContent() { Name = "mainMpDockContent", Text = "Operation", BackColor = Color.White, AutoScroll = true };
            _dockContent.Show(DockPanelMain, DockState.Document);
            _operationToolbox = LoadToolBox("Operations", "OperationList", DockPanelMain, DockState.DockLeft, @"images\form.ico");
            _snToolbox = LoadToolBox("Unit Information", "SnInformation", DockPanelMain, DockState.DockLeft, @"images\folder.ico");
            _objCb.LoadButtonToToolBox(_objOper.GetListOperations(LoginInfo.UserId), _operationToolbox, OperationButtonClick);
            _messageToolbox = LoadToolBox("Messages", "MessageList", DockPanelMain, DockState.DockBottom, @"images\ToolboxWindow.ico");
            _messageServerToolbox = LoadToolBox("Administrator Messages ", "MessageServerList", DockPanelMain, DockState.DockBottom, @"images\net.ico");
            _operationToolbox.Activate();
            _messageToolbox.Activate();
            _objCb.DisplayMsgToolbox(_messageToolbox, _objMsg.GetSystemMsg(EnumMessage.Welcome, LoginInfo.Username.ToString()).ReturnMsg);
        }
        public MpToolbox LoadToolBox(string textValue, string nameValue, DockPanel panelValue, DockState docState, string iconFile)
        {
            var tw = new MpToolbox() { IsHidden = false, Text = textValue, Name = nameValue, CloseButtonVisible = false, BackColor = Color.White, Icon = new Icon(iconFile) };
            tw.Show(panelValue, docState);
            return tw;
        }
        public TabControl RenderForm(Control doc, List<Control> ucData, string tabPageName, string tabPageText, TabControl tc)
        {
            _objCb.CreatePanel(new Panel(), tc, 0, DockStyle.Fill, doc, true);
            var tp = new TabPage() { Name = tabPageName, Text = tabPageText, BackColor = Color.White, AutoScroll = true };
            tc.Controls.Add(tp);
            var i = 1;
            foreach (Control u in ucData.AsEnumerable().Reverse())
            {
                if ((u is UcSubmit) || (u is UcPassFail))
                {
                    _objCb.CreatePanel(new Panel(), u, i, DockStyle.Bottom, doc, true);
                }
                else
                {
                    u.Dock = DockStyle.Top; tp.Controls.Add(u); u.Show();
                }
                i = i + 1;
            }
            tp.AutoScroll = true;
            tc.SelectTab(tp);
            _objCb.FindAndSetFocusOnTabIndex(tp);
            tc.BringToFront();
            return tc;
        }
    }
}
