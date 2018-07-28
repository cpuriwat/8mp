using System;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Sn;

namespace _8mpBl.Factory.Interfaces
{
    public interface ISnApi : IMpCommonApi , IDisposable
    {
        bool CheckSerialNumber(string sn);
        string ShopOrder { get; set; }
        // Property RouteDetailSlug As String 
        string SnFormat { get; set; }
        string Route { get; set; }
        string UnitSn { get; set; }
        SnDetailVm SnDetail { get; set; }
        string ShopOrderName { get; set; }
        bool AllowAutoSubmit();
        string ValidateNextCode();
        int EngageTransaction(SnEngageVm data);
        int EngageTransactionUpdate(SnEngageUpdateVm data, string slug);
        int PerformTransaction(SnPerformVm data, string sn);
    }
}
