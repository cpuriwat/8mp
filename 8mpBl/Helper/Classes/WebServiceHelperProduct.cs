using _8mpBl.Model.Product;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public ProductDetailVm GetProductBySlug(string slug)
        {
            return GetJsonObject< ProductDetailVm>("/api/product/" + slug);
        }
    }
}

