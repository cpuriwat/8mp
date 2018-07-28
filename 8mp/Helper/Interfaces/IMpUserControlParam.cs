using _8mpBl.Helper.Interfaces;

namespace _8mp.Helper.Interfaces
{
    public interface IMpUserControlParam : IMpUserControl
    {
        int ControlHeight { get; set; }
        int ControlWidth { get; set; }
        int LabelParamNameWidth { get; set; }
        void LabelWidth(int widthValue);
        void ShowData();
    }
}
