// <copyright file="SoApiTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpFlexLib.Interfaces;
using _8mpBl.Factory.Classes;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.WorkOrder;

namespace _8mpBl.Factory.Classes.Tests
{
    /// <summary>This class contains parameterized unit tests for SoApi</summary>
    [PexClass(typeof(SoApi))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SoApiTest
    {
        /// <summary>Test stub for CheckWorkOrder(String)</summary>
        [PexMethod]
        public bool CheckWorkOrderTest([PexAssumeUnderTest]SoApi target, string wo)
        {
            bool result = target.CheckWorkOrder(wo);
            return result;
            // TODO: add assertions to method SoApiTest.CheckWorkOrderTest(SoApi, String)
        }

        /// <summary>Test stub for .ctor(IWebServiceHelper, IMessageTextHandler, IMpFlex)</summary>
        [PexMethod]
        public SoApi ConstructorTest(
            IWebServiceHelper wsHelper,
            IMessageTextHandler errCode,
            IMpFlex objFlex
        )
        {
            SoApi target = new SoApi(wsHelper, errCode, objFlex);
            return target;
            // TODO: add assertions to method SoApiTest.ConstructorTest(IWebServiceHelper, IMessageTextHandler, IMpFlex)
        }

        /// <summary>Test stub for Dispose()</summary>
        [PexMethod]
        public void DisposeTest([PexAssumeUnderTest]SoApi target)
        {
            target.Dispose();
            // TODO: add assertions to method SoApiTest.DisposeTest(SoApi)
        }

        /// <summary>Test stub for GetOrderDetailVm(String)</summary>
        [PexMethod]
        public WorkOrderDetailVm GetOrderDetailVmTest([PexAssumeUnderTest]SoApi target, string order)
        {
            WorkOrderDetailVm result = target.GetOrderDetailVm(order);
            return result;
            // TODO: add assertions to method SoApiTest.GetOrderDetailVmTest(SoApi, String)
        }

        /// <summary>Test stub for GetOrder()</summary>
        [PexMethod]
        public object GetOrderTest([PexAssumeUnderTest]SoApi target)
        {
            object result = target.GetOrder();
            return result;
            // TODO: add assertions to method SoApiTest.GetOrderTest(SoApi)
        }

        /// <summary>Test stub for GetOrderVm()</summary>
        [PexMethod]
        public List<WorkOrderVm> GetOrderVmTest([PexAssumeUnderTest]SoApi target)
        {
            List<WorkOrderVm> result = target.GetOrderVm();
            return result;
            // TODO: add assertions to method SoApiTest.GetOrderVmTest(SoApi)
        }

        /// <summary>Test stub for GetOrderVm(String)</summary>
        [PexMethod]
        public List<WorkOrderVm> GetOrderVmTest01([PexAssumeUnderTest]SoApi target, string prod)
        {
            List<WorkOrderVm> result = target.GetOrderVm(prod);
            return result;
            // TODO: add assertions to method SoApiTest.GetOrderVmTest01(SoApi, String)
        }

        /// <summary>Test stub for GetProductVm()</summary>
        [PexMethod]
        public List<WorkOrderVm> GetProductVmTest([PexAssumeUnderTest]SoApi target)
        {
            List<WorkOrderVm> result = target.GetProductVm();
            return result;
            // TODO: add assertions to method SoApiTest.GetProductVmTest(SoApi)
        }

        /// <summary>Test stub for SetFocus()</summary>
        [PexMethod]
        public void SetFocusTest([PexAssumeUnderTest]SoApi target)
        {
            target.SetFocus();
            // TODO: add assertions to method SoApiTest.SetFocusTest(SoApi)
        }
    }
}
