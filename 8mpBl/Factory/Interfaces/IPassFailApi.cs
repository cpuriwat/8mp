using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;

namespace _8mpBl.Factory.Interfaces
{
    public interface IPassFailApi : IMpCommonApi
    {
        bool ExecutePostMpFlex(EnumResult result);
        void CancelClick();
        void PassClick();
        void FailClick();
        void SubmitFailClick();
    }
}
