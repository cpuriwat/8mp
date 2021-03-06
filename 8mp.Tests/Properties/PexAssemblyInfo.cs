// <copyright file="PexAssemblyInfo.cs">Copyright ©  2018</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("8mp")]
[assembly: PexInstrumentAssembly("Telerik.WinControls")]
[assembly: PexInstrumentAssembly("Telerik.WinControls.UI")]
[assembly: PexInstrumentAssembly("Telerik.WinControls.Themes.TelerikMetroBlue")]
[assembly: PexInstrumentAssembly("System.Configuration")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("8mpBl")]
[assembly: PexInstrumentAssembly("System.Windows.Forms")]
[assembly: PexInstrumentAssembly("MpFlexLib")]
[assembly: PexInstrumentAssembly("WeifenLuo.WinFormsUI.Docking")]
[assembly: PexInstrumentAssembly("System.Drawing")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Telerik.WinControls")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Telerik.WinControls.UI")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Telerik.WinControls.Themes.TelerikMetroBlue")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Configuration")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "8mpBl")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Windows.Forms")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MpFlexLib")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "WeifenLuo.WinFormsUI.Docking")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Drawing")]

