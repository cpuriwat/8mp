using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Interfaces.Helper;
using Model;
using MpFlexLib.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Model.Snip;
using IWebServiceHelper = _8mpBl.Helper.Interfaces.IWebServiceHelper;

namespace _8mpBl.Factory.Classes
{
    public class HookApi : IHookApi
    {
        public event FinishEventEventHandler FinishEvent;
        private readonly IMpFlex _objFlex;
        private readonly IWebServiceHelper _objWs;
        private List<string> _hookList;
        private EnumResult _result = EnumResult.Pass;
        public HookApi(IMpFlex objFlex, IWebServiceHelper objWs)
        {
            _objFlex = objFlex;
            _objWs = objWs;
        }
        private List<string> GetHookList()
        {
            return _hookList;
        }
        protected void HookCustomEvent(Control obj, List<string> hookName)
        {
            _hookList = hookName;
            foreach (Control ctl in obj.Controls)
            {
                HookPrePostEvent(ctl);
                if (ctl.HasChildren)HookCustomEvent(ctl, hookName);
            }
        }
        private void HookPrePostEvent(Control c)
        {
            // TODO : define all hook state
            if (c is TextBox)
            {
                Debug.Print(c.Name + ": Hook TextBox");
                c.KeyDown += PostHookKeyDown;
                c.Leave += PostHookLeave;
            }
            else if (c is Button)
            {
                Debug.Print(c.Name + ": Hook Click");
                c.MouseDown += PreHookMouseDown;
                c.Click += PostHookClick;
            }
            else if (c is RadioButton)
            {
                Debug.Print(c.Name + ": Hook Click");
                c.Click += HookClick;
            }
            else if (c is ComboBox)
            {
                Debug.Print(c.Name + ": Hook Click");
                ComboBox t = (ComboBox)c;
                t.SelectedIndexChanged += HookClick;
            }
            else
            {
                c.Click += HookClick;
            }
        }
        private void PreHookMouseDown(object sender, MouseEventArgs e)
        {
            Debug.Print("Hook - PreHookMouseDown");
            ExecuteHookScript(EnumSnipType.Pre, sender);
        }
        private void HookClick(object sender, EventArgs e)
        {
            Debug.Print("Hook - HookClick");
            ExecuteHookScript(EnumSnipType.Click, sender);
        }
        private void PostHookClick(object sender, EventArgs e)
        {
            Debug.Print("Hook - PostHookClick");
            ExecuteHookScript(EnumSnipType.Post, sender);
        }
        private void PostHookLeave(object sender, EventArgs e)
        {
            var tb = (TextBox) sender;
            if (tb.Text == "")return;
            if (_result == EnumResult.Fail)return;
            Debug.Print("Hook - TextBox Leave");
            ExecuteHookScript(EnumSnipType.Validate, sender);
        }
        private void PostHookKeyDown(object sender, KeyEventArgs e)
        {
            var tb = (TextBox) sender;
            if (tb.Text == "")return;
            if (_result == EnumResult.Fail)return;
            Debug.Print("Hook - TextBox Keydown");
            ExecuteHookScript(EnumSnipType.Validate, sender);
        }
        private void ExecuteHookScript(EnumSnipType snipType, object obj)
        {
            _result = EnumResult.Pass;
            if (_hookList.Count <= 0)return;
            var o = (Control) obj;
            foreach (var hookSlug in _hookList)
            {
                var hookDetail = (HookDetailVm) _objWs.GetHookDetail(hookSlug);
                if (hookDetail == null) continue;
                if (hookDetail.name.ToUpper() != o.Name.ToUpper() | hookDetail.@event.ToUpper() != snipType.ToString().ToUpper())
                    continue;
                var code = (SnipVm) _objWs.GetSnippetBySlug(hookDetail.snippet);
                if (!_objFlex.ExecuteScript(code.code, _objWs.TokenAccessKey))
                {
                    o.Select();
                    _result = EnumResult.Fail;
                }
                FinishEvent?.Invoke(o.Name, snipType.ToString(), code, _result, o);
            }
        }

        void IHookApi.HookCustomEvent(Control obj, List<string> hookName)
        {
            throw new NotImplementedException();
        }

        List<string> IHookApi.GetHookList()
        {
            throw new NotImplementedException();
        }
    }
}
