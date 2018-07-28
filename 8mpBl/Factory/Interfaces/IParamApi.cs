using System.Collections.Generic;
using System.Windows.Forms;
using Interfaces.Api;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Parameter;

namespace _8mpBl.Factory.Interfaces
{
    public interface IParamApi : IMpCommonApi
    {
        object GetParameterBySlug(string routingDetailSlug);
        object GetItemBySlug(string parameterSlug);
        string GetSnippedCode(string slug);
        string SnipErrorMessage();
        List<Model.Parameter.ParameterItemValueVm> ParamItemValue { get; set; }
        int SnId { get; set; }
        List<ParameterItemValueVm> GetParamItemValue(int performId);
        int PerformParametric(List<ParameterItemValueVm> data, string sn);
        int RollBackParam(int paramId);
        ParameterVm GetParameterProfileDetail(string paramSlug);
    }
}
