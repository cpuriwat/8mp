using Interfaces.Api;
using Interfaces.Helper;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Factory.Classes
{
    public class SnipApi : ISnipApi
    {
        private readonly IWebServiceHelper _wsHelper;
        private readonly IMessageTextHandler _errCode;
        public SnipApi(IWebServiceHelper wsHelper, IMessageTextHandler errCode)
        {
            _wsHelper = wsHelper;
            _errCode = errCode;
        }

        public object GetSnippetBySlug(string snippetSlug)
        {
            return _wsHelper.GetSnippetBySlug(snippetSlug);
        }
    }
}
