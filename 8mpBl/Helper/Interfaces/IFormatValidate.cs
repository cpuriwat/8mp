namespace Interfaces.Helper
{
    public interface IFormatValidate
    {
        string UrlPathFormat(string value, int urlPathPosition);
        bool RexExValidate(string value, string rexExValue);
    }
}
