using System.Collections.Generic;
using _8mpBl.Model.Operation;

namespace _8mpBl.Factory.Interfaces
{
    public interface IOperationApi
    {
        List<OperationVm> GetListOperations(int userid);
    }
}
