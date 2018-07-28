using System;
using _8mpBl.Events;
using _8mpBl.Factory.Interfaces;

namespace _8mpBl.Helper.Interfaces
{
    public interface IMpTransaction
    {
        event EventHandler<CustomReturnEventArgs> TransactionProceed;
        bool ProcessTransaction(ISnApi objSn, ISoApi objSo, IParamApi objParam);
        bool ProcessTransactionPass(ISnApi objSn, IParamApi objParam);
        bool ProcessTransactionFail(ISnApi objSn, IParamApi objParam, IFailureApi objApi);
    }
}
