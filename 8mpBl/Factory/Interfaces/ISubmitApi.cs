using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Factory.Interfaces
{
    public interface ISubmitApi : IMpCommonApi
    {
        bool ExecutePostMpFlex(EnumResult result);
        void CancelClick();
        void SubmitClick();
    }
}

