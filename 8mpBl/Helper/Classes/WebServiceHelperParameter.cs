using _8mpBl.Model.Parameter;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public ParameterVm GetParameterProfileDetail(string slug)
        {
            return GetJsonObject<ParameterVm>("/api/parameter/" + slug + "/");
        }
        public ParameterItemDetailVm GetParameterItemDetail(string slug)
        {
            return GetJsonObject<ParameterItemDetailVm>("/api/item/" + slug + "/");
        }
        public object GetParametric(object data)
        {
            return GetHttpPost(data, "/api/parametric/create/");
        }
        public object GetItemBySlug(string parameterSlug)
        {
            return GetJsonObject("/api/parameter/" + parameterSlug);
        }
        public object GetParameterBySlug(string routingDetailSlug)
        {
            return GetJsonObject("/api/routingdetail/" + routingDetailSlug);
        }

    }
}

