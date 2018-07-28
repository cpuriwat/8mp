using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.Operation;

namespace _8mpBl.Helper.Classes
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class ControlBuilder : IControlBuilder
    {
        private readonly IMpFlex _objFlex;
        private readonly IMessageTextHandler _objMsg;
        private readonly IWebServiceHelper _objWs;
        public ControlBuilder(IMpFlex objFlex, IWebServiceHelper objWs, IMessageTextHandler objMsg)
        {
            _objFlex = objFlex;
            _objWs = objWs;
            _objMsg = objMsg;
        }
        public void LoadButtonToToolBox(List<OperationVm> member, Control tw, EventHandler eventHandler)
        {
            if (member == null)
                return;
            for (var i = member.Count - 1; i >= 0; i += -1)
            {
                var op = member[i];
                var btnOp = new Button() { Name = op.name, Text = op.title, Dock = DockStyle.Top, BackColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnOp.FlatAppearance.BorderSize = 1;
                btnOp.FlatAppearance.BorderColor = Color.Silver;
                btnOp.Click += eventHandler;
                tw.Controls.Add(btnOp);
            }
        } // leave this method to be example 
        public Control FindControls(Control parentControl, string childname)
        {
            foreach (Control c in parentControl.Controls)
            {
                if (c.HasChildren)
                {
                    var found = FindControls(c, childname);
                    if (found != null)
                        return found;
                }
                if (c.Name == childname)
                    return c;
            }
            return null;
        }
        public List<Control> FindControlsByType<T>(Control parentControl, List<Control> listOfC)
        {
            foreach (Control c in parentControl.Controls)
            {
                if (c.HasChildren) listOfC = this.FindControlsByType<T>(c, listOfC);
                if (c is T) listOfC.Add(c);
            }
            return listOfC;
        }
        public void LoadComboBox(ComboBox cb, IEnumerable<object> list, string v1, string v2)
        {
            if (cb == null | list == null) return;
            cb.DataSource = list;
            cb.DisplayMember = v1;
            cb.ValueMember = v2;
        }
        public void LoadComboBox(ComboBox cb, IEnumerable<object> list)
        {
            if (cb == null | list == null) return;
            cb.DataSource = list;
        }
        public void DisplayLabel(Label l, ReturnMsgVm msg)
        {
            if (l == null | msg == null)
                return;
            var msgFirstDigit = Convert.ToInt32(msg.ReturnMsgEnum).ToString().Substring(0, 1);
            switch (msgFirstDigit)
            {
                case "1": { l.ForeColor = Color.Green; break; }
                case "5": { l.ForeColor = Color.Blue; break; }
                default: { l.ForeColor = Color.Red; break; }
            }
            l.Text = msg.ReturnMsg;
        }
        public void SelectText(TextBox t)
        {
            t.Enabled = true;
            t.Focus();
            t.SelectAll();
        }
        public void AppendTextToToolWindow(Control tb, string msg)
        {
            if (msg == "") return;
            tb.Controls.Add(new Label() { Text = msg });
        }
        public void CreatePanel(Panel sp, Control objControl, int panelSeq, DockStyle dockType, Control doc, bool autoScroll)
        {
            sp.Name = "Panel" + panelSeq.ToString();
            sp.TabIndex = 99 - panelSeq; // to make tab reverse
            sp.Controls.Add(objControl);
            sp.AutoSize = true;
            // sp.BackColor=color.Yellow
            sp.AutoScroll = autoScroll;
            sp.Dock = dockType;
            doc.Controls.Add(sp);
        }
        // call only to initiate tabcontrol

        public void RenderTabForm(List<UserControl> ucData, string tabPageName, string tabPageText, TabControl tc, bool autoSelect)
        {
            var tp = new TabPage() { Name = tabPageName, Text = tabPageText, BackColor = Color.White, AutoScroll = true, Dock = DockStyle.Fill };
            foreach (var u in ucData.AsEnumerable().Reverse())
            {
                u.Dock = DockStyle.Top; u.AutoScroll = true;
                tp.Controls.Add(u);
                u.Show();
            }
            tc.Controls.Add(tp);
            tp.Show();
            if (!autoSelect) return;
            tc.SelectTab(tp);
            FindAndSetFocusOnTabIndex(tp);
        }
        //public Control FindFocussedControl(Control ctr)
        //{
        //    var container = ctr as ContainerControl;
        //    while ((container != null))
        //    {
        //        ctr = container.ActiveControl;
        //        container = ctr as ContainerControl;
        //    }
        //    return ctr;
        //}
        public void FindAndSetFocusOnTabIndex(Control obj)
        {
            foreach (Control ctl in obj.Controls)
            {
                // HookPrePostEvent(ctl)
                if (ctl.TabIndex == 1)
                {
                    if (ctl.HasChildren)FindAndSetFocusOnTabIndex(ctl);
                    ctl.Select();
                    Debug.Print(ctl.Name);
                }
                if (ctl.HasChildren)FindAndSetFocusOnTabIndex(ctl);
            }
        }

        public void FindAndSetFocus(object sender, EventArgs e)
        {
            var obj = (TabControl)sender;
            FindAndSetFocus(obj.SelectedTab);
        }

        //public void FindAndSetFocus(TabControl sender, EventArgs e)
        //public void FindAndSetFocus(object sender, EventArgs e)
        //{
        //    var obj = (TabControl) sender;
        //    FindAndSetFocus(obj.SelectedTab);
        //}

        public bool FindAndSetFocus(Control sender)
        {
            for (var i = sender.Controls.Count - 1; i >= 0; i += -1)
            {
                var c = sender.Controls[i];
                if (c.TabStop & !c.HasChildren)
                {
                    c.Select();
                    return true;
                }
                if (!c.HasChildren) continue;
                if (c is TabControl tb)
                {
                    tb.SelectedIndex = 0;
                    if (FindAndSetFocus(tb.SelectedTab))return true;
                }
                else if (FindAndSetFocus(c))return true;
            }
            return true;
        }
        public void DisplayMsgToolbox(Control messageToolbox, string returnMsg)
        {
            var currentTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            messageToolbox.Controls.Add(new Label() { Text = currentTime + " - " + returnMsg, Dock = DockStyle.Top, AutoSize = true });
        }

        public AutoCompleteStringCollection GetAutoComplete(object objApiResult, string fieldName)
        {
            var listData = new AutoCompleteStringCollection();
            //List<BomDetailVm> valueApi = objApiResult;
            //Array data = valueApi.Select(x => Interaction.CallByName(x, fieldName, CallType.Get, null).ToString()).ToArray();
            //listData.AddRange(data);
            return listData;
        }
        public void RenameGridColumnToModelDescriptionAttribute<T>(DataGridView grid)
        {
            foreach (DataGridViewColumn h in grid.Columns)
            {
                Type myType = typeof(T);
                PropertyInfo myPropInfo = myType.GetProperty(h.HeaderText);
                var description = myPropInfo.GetCustomAttribute(typeof(DescriptionAttribute), true);
                var desc = description as DescriptionAttribute;
                h.HeaderText = desc.Description;
            }
        }
        
        public object FindControlInList<T>(List<Control> listOfControl)
        {
            foreach (var obj in listOfControl)
            {
                if (obj.GetType() == typeof(T))return obj;
            }
            return null;
        }
        public object FindControlHasInterfaceInList<T>(List<object> listOfControl)
        {
            foreach (var obj in listOfControl)
            {
                if (obj is T)return obj;
            }
            return null;
        }
        public void ShowObjectName(Control obj, ToolTip tt)
        {
            foreach (Control nControl in obj.Controls)
            {
                if (nControl.HasChildren) ((IControlBuilder)this).ShowObjectName(nControl, tt);
                tt.SetToolTip(nControl, nControl.Name);
            }
        }
        public string RemoveNontext(string title) => title.Replace(" ", "").Replace("(", "").Replace(")", "");
        public void EnableModule<T>(bool enable, List<Control> lt)
        {
            var c = (IMpUserControl) FindControlInList<T>(lt);
            if (c == null) return;
            c.EnableControl(enable); c.SetFocus();
        }
      
        
    }
}

