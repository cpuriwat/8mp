using System;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcFailure 
    {
        private readonly IFailureApi _objFailure;
        public UcFailure(IFailureApi objFailure, IControlBuilder objObjControlBuild) : base(objFailure.GetFlexObj, objFailure.GetWsObj, objFailure.GetMsgObj, objFailure.FormObject, objFailure.Operation, objObjControlBuild)
        {
            _objFailure = objFailure;
            InitializeComponent();
            HookCustomEvent(this, _objFailure);
        }
        private void UcFailure_Load(object sender, EventArgs e)
        {
            LoadData();
            GbRework.Enabled = _objFailure.ReworkOperation;
        }
        private void LoadData()
        {
            // TxtRefDes.AutoCompleteCustomSource = _objFailure.GetRdAutoComplete
            // TxtPn.AutoCompleteCustomSource = _objFailure.GetPnAutoComplete
            // 'CbFailCode.AutoCompleteCustomSource = _objFailure.GetFailCodeAutoComplete
            // CbDefectCode.AutoCompleteCustomSource = _objFailure.GetDefectCodeAutoComplete
            // '  CbReworkCode.AutoCompleteCustomSource = _objFailure.GetReworkCodeAutoComplete
            // GvFailure.DataSource = New List(Of UnitFailureFlatVm)
            base.ObjControlBuilder.RenameGridColumnToModelDescriptionAttribute<UnitFailureFlatVm>(GvFailure);
        }
        public new void SetFocus()
        {
            base.ObjControlBuilder.FindAndSetFocus(this);
        }
        private void TxtRefDes_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

