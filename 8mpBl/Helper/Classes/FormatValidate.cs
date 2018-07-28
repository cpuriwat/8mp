using System.Text.RegularExpressions;
using Interfaces.Helper;

namespace _8mpBl.Helper.Classes
{
    public class FormatValidate : IFormatValidate
    {
        public string UrlPathFormat(string value, int urlPathPosition)
        {
            if (value == null) return "HTTP://";
            if (Path(value)) return value;
            value = value.Replace("http://", "").Replace("HTTP://", ""); // remove http://
            if (value.Contains("//")) value = value.Replace("//", "/");
            if (value.Contains("///")) value = value.Replace("///", "//");
            if (value.Contains("////")) value = value.Replace("////", "///");
            if (value.Substring(0, 1) != "/") value = "/" + value;
            return "HTTP://" + value;
        }
        private bool Path(string pathvalue)
        {
            const string pattern = @"http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?";
            return RexExValidate(pathvalue, pattern);
        }
        public bool RexExValidate(string value, string rexExValue) => rexExValue == "*" || Regex.IsMatch(value ?? "", rexExValue);
    }
}
