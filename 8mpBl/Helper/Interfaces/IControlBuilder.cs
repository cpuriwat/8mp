using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using _8mpBl.Enums;
using _8mpBl.Model.General;
using _8mpBl.Model.Operation;

namespace _8mpBl.Helper.Interfaces
{
    public interface IControlBuilder
    {
        void CreatePanel(Panel sp, Control objControl, int panelSeq, DockStyle dockType, Control doc, bool autoScroll);
        void LoadButtonToToolBox(List<OperationVm> member, Control tw, EventHandler eventHandler);
        void LoadComboBox(ComboBox cb, IEnumerable<object> list, string v1, string v2);
        void DisplayLabel(Label l, ReturnMsgVm msg);
        void SelectText(TextBox t);
        void AppendTextToToolWindow(Control tb, string msg);
        void DisplayMsgToolbox(Control messageToolbox, string returnMsg);
        void RenderTabForm(List<UserControl> ucData, string tabPageName, string tabPageText, TabControl tabControl, bool autoSelect);
        bool FindAndSetFocus(Control sender);

        //event EventHandler<> FindAndSetFocus(object sender, System.EventArgs e);
        AutoCompleteStringCollection GetAutoComplete(object objApiResult, string fieldName);
        void RenameGridColumnToModelDescriptionAttribute<T>(DataGridView grid);
        void ShowObjectName(Control obj, ToolTip tt);
        string RemoveNontext(string title);


        void MessageLabel(EnumMessage msg, Label label);
        object FindControlInList<T>(List<Control> listOfControl);
        void LoadComboBox(ComboBox cb, IEnumerable<object> list);
        Control FindControls(Control parentControl, string childname);
        List<Control> FindControlsByType<T>(Control parentControl, List<Control> listOfC);
        object FindControlHasInterfaceInList<T>(List<object> listOfControl);
        void FindAndSetFocusOnTabIndex(Control obj);
        void FindAndSetFocus(object sender, EventArgs e);

        //void EnableModule<T>(bool enable);
        void EnableModule<T>(bool enable, List<Control> lt);
    }
}
