using _8mpBl.Model.Snip;

namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public SnipVm GetSnippetBySlug(string snippetSlug)
        {
            return GetJsonObject<SnipVm>("/api/snippet/" + snippetSlug + "/");
        }
    }
}

