using System;
using System.Linq;
using System.Windows.Forms;
using _8mp.Helper.Interfaces;
using _8mpBl.Enums;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.WorkOrder;

namespace _8mp.Uc
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class UcSo : IMpModuleRenderController
    {
        public readonly ISoApi ObjSoApi;
        public event EventHandler<CustomReturnEventArgs> MsgRendering;
        public event EventHandler EnableOtherControlRendering;
        public UcSo(ISoApi objSoApi, IControlBuilder objObjControlBuilder) : base(objSoApi.GetFlexObj, objSoApi.GetWsObj, objSoApi.GetMsgObj, objSoApi.FormObject, objSoApi.Operation, objObjControlBuilder)
        {
            ObjSoApi = objSoApi;
            InitializeComponent();
            HookCustomEvent(this, ObjSoApi);
        }
        private void UcSo_Load(object sender, EventArgs e)
        {
            var listOfDistinctProduct = ObjSoApi.GetOrderVm().Select(x => x.product).Distinct().OrderBy(x => x).ToList();
            ObjControlBuilder.LoadComboBox(cbProduct, listOfDistinctProduct);
        }
        public override void ResetControl(bool success) => ObjSoApi.SetFocus();
        private void cbProduct_SelectionChangeCommitted(object sender, EventArgs e) => ObjControlBuilder.LoadComboBox(CbSo, ObjSoApi.GetOrderVm(cbProduct.SelectedValue.ToString()), nameof(WorkOrderVm.name), nameof(WorkOrderVm.slug));
        private void ShowData(WorkOrderVm value)
        {
            LblProductName.Text = value.product;
            LblRoute.Text = value.routing;
            WorkOrderDetailVm soDetail = ObjSoApi.GetOrderDetailVm(value.slug);
            if (soDetail != null) LblOrderQty.Text = soDetail.qty;
            ObjSoApi.ShopOrder = value.slug;
            ObjSoApi.ShopOrderName = value.name;
            RaiseFinishEvent(this, new CustomReturnEventArgs{ReturnResult = EnumResult.Pass, ReturnMsg = ObjSoApi.ReturnMsg});
        }
        public new void SetFocus() => CbSo.Select();

        private void cbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            ObjControlBuilder.LoadComboBox(CbSo, ObjSoApi.GetOrderVm(cbProduct.SelectedValue.ToString()), nameof(WorkOrderVm.name), nameof(WorkOrderVm.slug));
            ShowData((WorkOrderVm)CbSo.SelectedItem);
        }

        private void CbSo_SelectedValueChanged(object sender, EventArgs e)
        {
            var value = (WorkOrderVm)CbSo.SelectedItem;
            if (!ObjSoApi.CheckWorkOrder(value.slug)) return;
            ShowData(value);
            //RaiseFinishEvent(this, new CustomReturnEventArgs { ReturnEvent = e });
        }
    }
}
