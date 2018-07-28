using System.Collections.Generic;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mpBl.Factory.Interfaces
{
    public interface IParamItemApi : IMpCommonApi
    {
        ParameterItemVm ParamItem { get; set; }
       ParameterItemDetailVm ParamItemDetail { get; set; }
        List<ParameterItemValueVm> ParamItemValue { get; set; }
        bool InputValidation(string value);
        List<ParameterItemListValueVm> GetParamtemList();
        bool SelectionValidation(ParameterItemListValueVm value);
        bool CheckValidation(string value);
        void AddParamItemValue(string name, string value, bool check);
    }
}
