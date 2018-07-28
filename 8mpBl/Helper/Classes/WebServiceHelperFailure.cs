using System.Collections.Generic;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        // TODO : this class need to revise all
        public object GetFailureCode()
        {
            return GetJsonObject<List<global::_8mpBl.Model.FailureDefect.FailureVm>>("/api/failure/");
        }

        public object GetDefectCode(string failureCode)
        {
            return GetJsonObject<List<global::_8mpBl.Model.FailureDefect.DefectVm>>("/api/defect/?fail_code=" + failureCode);
        }
        public object GetDefectCode()
        {
            return GetJsonObject<List<global::_8mpBl.Model.FailureDefect.DefectVm>>("/api/defectcode/");
        }
        public object GetReworkCode(string defectCode)
        {
            return GetJsonObject<List<global::_8mpBl.Model.FailureDefect.ReworkVm>>("/api/rework/?defect_code=" + defectCode);
        }
        public object GetFailurehistory(string sn)
        {
            return GetJsonObject<List<global::_8mpBl.Model.FailureDefect.ReworkVm>>("/api/failure/?number=" + sn);
        }
        public object GetFailureHistory(string sn) { throw new System.NotImplementedException(); }
    }
}

