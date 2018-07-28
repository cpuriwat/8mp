using System.Collections.Generic;
using System.Windows.Forms;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.FailureDefect;

namespace _8mpBl.Factory.Interfaces
{
    public interface IFailureApi : IMpCommonApi
    {
        string UnitSn { get; set; }
        bool ReworkOperation { get; set; }
        UnitFailureVm GetUnitFailure(string sn);
        UnitFailureVm GetUnitFailure();
        List<DefectVm> GetDefect(string failureCode);
        List<FailureVm> GetFailure();
        List<ReworkVm> GetRework(string defectCode);
        AutoCompleteStringCollection GetRdAutoComplete();
        AutoCompleteStringCollection GetPnAutoComplete();
        AutoCompleteStringCollection GetFailCodeAutoComplete();
        AutoCompleteStringCollection GetDefectCodeAutoComplete();
        AutoCompleteStringCollection GetReworkCodeAutoComplete();
    }
}
