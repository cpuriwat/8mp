namespace _8mpBl.Helper.Classes
{
    public partial class WsHelper
    {
        public object GetHookDetail(string slug)
        {
            return GetJsonObject<global::Model.HookDetailVm>("/api/hook/" + slug + "/");
        }
    }
}

