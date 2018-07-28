using Microsoft.VisualStudio.TestTools.UnitTesting;
using _8mpBl.Model.Route;
using _8mpBl.Enums;
using System.Collections.Generic;
using _8mpBl.Model.General;
using MpFlexLib.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Factory.Classes;
using Microsoft.Pex.Framework.Generated;
// <copyright file="SoApiTest.DisposeTest.g.cs">Copyright ©  2018</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace _8mpBl.Factory.Classes.Tests
{
    public partial class SoApiTest
    {

[TestMethod]
[PexGeneratedBy(typeof(SoApiTest))]
public void DisposeTest273()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      SoApi soApi;
      soApi =
        new SoApi((IWebServiceHelper)null, (IMessageTextHandler)null, (IMpFlex)null);
      soApi.ReturnMsg = (ReturnMsgVm)null;
      soApi.ListReturnMsgVm = (List<ReturnMsgVm>)null;
      soApi.Result = EnumResult.Cancel;
      soApi.GetFlexObj = (IMpFlex)null;
      soApi.Operation = (string)null;
      soApi.FormObject = (object)null;
      soApi.ShopOrder = (string)null;
      soApi.ShopOrderName = (string)null;
      soApi.LoginInfo = (LoginInfoVm)null;
      soApi.RouteDetail = (RouteDetailOperationStepVm)null;
      disposables.Add((IDisposable)soApi);
      this.DisposeTest(soApi);
      disposables.Dispose();
      Assert.IsNotNull((object)soApi);
      Assert.IsNull(soApi.ReturnMsg);
      Assert.IsNull(soApi.ListReturnMsgVm);
      Assert.AreEqual<EnumResult>(EnumResult.Cancel, soApi.Result);
      Assert.IsNull(soApi.GetWsObj);
      Assert.IsNull(soApi.GetFlexObj);
      Assert.IsNull(soApi.GetMsgObj);
      Assert.AreEqual<string>((string)null, soApi.Operation);
      Assert.IsNull(soApi.FormObject);
      Assert.AreEqual<string>((string)null, soApi.ShopOrder);
      Assert.AreEqual<string>((string)null, soApi.ShopOrderName);
      Assert.IsNull(soApi.LoginInfo);
      Assert.IsNull(soApi.RouteDetail);
    }
}
    }
}
