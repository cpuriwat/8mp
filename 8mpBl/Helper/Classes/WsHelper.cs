using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Interfaces.Helper;
using Newtonsoft.Json;
using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;
using _8mpBl.Model.WorkOrder;
using _8mpBl.Model.Route;

namespace _8mpBl.Helper.Classes
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class WsHelper : IWebServiceHelper
    {
        public string HostAddress { get; set; }
        public ReturnMsgVm ReturnMsg { get; set; }
        public bool ReturnAsModel { get; set; }
        private readonly string _hostApiUrl;
        private readonly IFormatValidate _fv;
        private readonly IMessageTextHandler _objMsg;

        public string TokenAccessKey { get; set; }
        public int UserId { get; set; }


        private string _tokenRefresh;
        private string _tokenAccess;
        private int _refreshAttempt = 0;
        public void Dispose()
        {
            // TODO : dispose _fv
            GC.SuppressFinalize(this);
        }
        public WsHelper(string hostApiUrl, IFormatValidate objFormatValidation, IMessageTextHandler objMsg)
        {
            _fv = objFormatValidation;
            _objMsg = objMsg;
            _hostApiUrl = _fv.UrlPathFormat(hostApiUrl, 1);
            HostAddress = _hostApiUrl;
        }
        public bool RexExValidate(string value, string format)
        {
            return _fv.RexExValidate(value, format);
        }
        public object GetJsonObject(string address)
        {
            var path = _fv.UrlPathFormat(_hostApiUrl + address, 2);
            return GetJsonObjectUrl(path);
        }

        public object GetJsonObjectUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);//beware HttpWebRequest vs WebRequest
            request.Method = "GET";
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + _tokenAccess);
            try
            {
                var myHttpWebResponse = (HttpWebResponse)request.GetResponse();
                StreamReader myWebSource = new StreamReader(myHttpWebResponse.GetResponseStream());
                string myPageSource = myWebSource.ReadToEnd();
                var jss = new JavaScriptSerializer();
                var data = jss.Deserialize<object>(myPageSource);
                // Dim data = JsonConvert.DeserializeObject(Of Object)(myPageSource)
                return data;
            }
            catch (WebException e)
            {
                using (WebResponse r = e.Response)
                {
                    var httpResponse = (HttpWebResponse)r;
                    if (httpResponse != null)
                    {
                        if (httpResponse.StatusCode == (HttpStatusCode)401 & _refreshAttempt <= 3)
                        {
                            _refreshAttempt = _refreshAttempt + 1;
                            if (GetNewAccessToken())
                            {
                                _refreshAttempt = 0; return GetJsonObjectUrl(url);
                            }
                        }
                        ValidateResponseErrorCode((int)httpResponse.StatusCode);
                    }
                    else
                        ValidateResponseErrorCode(0);
                }
                return null;
            }
        }
        public T GetJsonObject<T>(string address)
        {
            var path = _fv.UrlPathFormat(_hostApiUrl + address, 2);
            return GetJsonObjectUrl<T>(path); // no generic return 
            //if (ReturnAsModel) return GetJsonObjectUrl<T>(path);
            //GetJsonObjectUrl<object>(path);
        }

        public T GetJsonObjectUrl<T>(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + _tokenAccess);
            try
            {
                var myHttpWebResponse = (HttpWebResponse)request.GetResponse();
                StreamReader myWebSource = new StreamReader(myHttpWebResponse.GetResponseStream());
                string myPageSource = myWebSource.ReadToEnd();
                var jss = new JavaScriptSerializer();
                // Dim data = jss.Deserialize(Of T)(myPageSource)
                var data = JsonConvert.DeserializeObject<T>(myPageSource);
                return data;
            }
            catch (WebException e)
            {
                using (WebResponse r = e.Response)
                {
                    var httpResponse = (HttpWebResponse)r;
                    Debug.Print(httpResponse.StatusDescription);
                    if (httpResponse != null)
                    {
                        if (httpResponse.StatusCode == (HttpStatusCode)401 & _refreshAttempt <= 3)
                        {
                            _refreshAttempt = _refreshAttempt + 1;
                            if (GetNewAccessToken())
                            {
                                _refreshAttempt = 0; return GetJsonObjectUrl<T>(url);
                            }
                        }
                        ValidateResponseErrorCode((int)httpResponse.StatusCode);
                    }
                    else
                        ValidateResponseErrorCode(0);
                }
                return default(T);
            }
        }

        public string GetUrl()
        {
            return _hostApiUrl;
        }
        private bool GetNewAccessToken()
        {
            string postData = string.Format("refresh={0}", _tokenRefresh);
            var path = _fv.UrlPathFormat(GetTokenRefreshPath(), 1);
            return GetHttpPost(postData, path);
        }
        public bool GetHttpPost(string postData)
        {
            var path = _fv.UrlPathFormat(GetTokenPath(), 1);
            return GetHttpPost(postData, path);
        }
        public int GetHttpPost<T>(T postData, string path)
        {
            string pathData = _fv.UrlPathFormat(_hostApiUrl + path, 2);
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(pathData);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + _tokenAccess);
                httpWebRequest.Method = (pathData.Contains("/update/")) ? "PUT" : "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(postData);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream dataStream = httpResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                httpResponse.Close();
                var jss = new JavaScriptSerializer();
                object data = jss.DeserializeObject(responseFromServer);
                foreach (var item in (IEnumerable<KeyValuePair<string, object>>)data)
                {
                    if (item.Key.ToLower() == "id") return (int)item.Value;
                }
                // TODO : need to change to VM
                // ReturnMsg = _objMsg.GetSystemMsg(EnumMessage.TransactionSuccess,"")
                return 1;
            }
            catch (WebException e)
            {
                using (WebResponse r = e.Response)
                {
                    var httpResponse = (HttpWebResponse)r;
                    Debug.Print(httpResponse.StatusDescription);
                    if (httpResponse != null)
                        ValidateResponseErrorCode((int)httpResponse.StatusCode);
                    else
                        ValidateResponseErrorCode(0);
                }
                return 0;
            }
        }
        public bool GetHttpPost(string postData, string Path)
        {
            WebRequest request = WebRequest.Create(Path);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                var jss = new JavaScriptSerializer();
                object data = jss.DeserializeObject(responseFromServer);
                var handler = new JwtSecurityTokenHandler();
                foreach (var item in (IEnumerable<KeyValuePair<string, object>>)data)
                {
                    if (item.Key.ToLower() == "refresh") _tokenRefresh = (string)item.Value;
                    if (item.Key.ToLower() == "access")
                    {
                        _tokenAccess = (string)item.Value;
                        TokenAccessKey = _tokenAccess;
                        JwtSecurityToken jsonToken = (JwtSecurityToken)handler.ReadToken(_tokenRefresh);
                        foreach (KeyValuePair<string, object> i in jsonToken.Payload)
                        {
                            if (i.Key.ToLower() == "user_id")
                                UserId = Convert.ToInt32( i.Value);
                        }
                    }
                }
                ReturnMsg = _objMsg.GetSystemMsg(EnumMessage.LoginSuccess);
                return true;
            }
            catch (WebException e)
            {
                using (WebResponse r = e.Response)
                {
                    var httpResponse = (HttpWebResponse)r;
                    if (httpResponse != null)
                    {
                        Debug.Print(httpResponse.StatusDescription);
                        ValidateResponseErrorCode((int)httpResponse.StatusCode);
                    }
                    else{ ValidateResponseErrorCode(0); }
                }
                return false;
            }
        }
        private void ValidateResponseErrorCode(int statusCode)
        {
            if (statusCode == 0)
                ReturnMsg = _objMsg.GetSystemMsg(EnumMessage.HostUrlNotFound);
            if (statusCode == 400)
                ReturnMsg = _objMsg.GetSystemMsg(EnumMessage.LoginFail);
            if (statusCode == 401)
                ReturnMsg = _objMsg.GetSystemMsg(EnumMessage.RequestUnauthorized);
        }
    }
}
