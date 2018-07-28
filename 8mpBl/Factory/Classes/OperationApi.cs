using System;
using System.Collections.Generic;
using Model.Operation;
using _8mpBl.Enums;
using _8mpBl.Factory.Interfaces;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.Operation;

namespace _8mpBl.Factory.Classes
{
    public class OperationApi : IOperationApi
    {
        private readonly IWebServiceHelper _objWs;
        public OperationApi(IWebServiceHelper objWs)
        {
            _objWs = objWs;
        }
        // Public Function GetOperationLayout(operationName As string) As EnumOperationType Implements IOperationApi.GetOperationLayout
        // 'TODO: change to API
        // If operationName = "001-Register" Then Return EnumOperationType.SystemRegister
        // If operationName = "002-Inspection" Then Return EnumOperationType.StandardInspection
        // If operationName = "003-Rework" Then Return EnumOperationType.StandardRework

        // End Function

        public List<OperationVm> GetListOperations(int userid)
        {
            var op = new List<OperationVm>();
            foreach (var o in (IEnumerable<OperationVm>) _objWs.GetListOperations(userid))
            {
                var od = (OperationDetailVm) _objWs.GetOperation(o.slug);
                if (od != null && od.operation_type != EnumOperationType.END.ToString())
                {
                    o.name = o.name + "-type-" + (EnumOperationType)Enum.Parse(typeof(EnumOperationType), od.operation_type);
                    op.Add(o);
                }
            }
            return op;
        }
    }
}

