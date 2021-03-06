// <copyright file="UcSoTest.cs">Copyright ©  2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _8mp.Uc;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc.Tests
{
    /// <summary>This class contains parameterized unit tests for UcSo</summary>
    [PexClass(typeof(UcSo))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class UcSoTest
    {
        /// <summary>Test stub for .ctor(ISoApi, IControlBuilder)</summary>
        [PexMethod]
        public UcSo ConstructorTest(ISoApi objSoApi, IControlBuilder objObjControlBuilder)
        {
            UcSo target = new UcSo(objSoApi, objObjControlBuilder);
            return target;
            // TODO: add assertions to method UcSoTest.ConstructorTest(ISoApi, IControlBuilder)
        }

        /// <summary>Test stub for ResetControl(Boolean)</summary>
        [PexMethod]
        public void ResetControlTest([PexAssumeUnderTest]UcSo target, bool success)
        {
            target.ResetControl(success);
            // TODO: add assertions to method UcSoTest.ResetControlTest(UcSo, Boolean)
        }

        /// <summary>Test stub for SetFocus()</summary>
        [PexMethod]
        public void SetFocusTest([PexAssumeUnderTest]UcSo target)
        {
            target.SetFocus();
            // TODO: add assertions to method UcSoTest.SetFocusTest(UcSo)
        }

        [PexMethod(MaxBranches = 20000)]
        public void ResetControl([PexAssumeUnderTest]UcSo target, bool success)
        {
            target.ResetControl(success);
            // TODO: add assertions to method UcSoTest.ResetControl(UcSo, Boolean)
        }
    }
}
