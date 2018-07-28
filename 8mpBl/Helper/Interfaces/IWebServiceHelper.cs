using System;
using System.Collections.Generic;

namespace _8mpBl.Helper.Interfaces
{
    public partial interface IWebServiceHelper : IDisposable
    {
        string HostAddress { get; set; }
        object GetJsonObject(string address);
        object GetJsonObjectUrl(string url);
        T GetJsonObject<T>(string address);
        T GetJsonObjectUrl<T>(string url);
        string GetUrl();
        bool GetHttpPost(string postData);
        bool RexExValidate(string value, string format);
    }
}
