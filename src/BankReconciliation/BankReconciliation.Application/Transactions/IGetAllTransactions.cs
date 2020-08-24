using BankReconciliation.Application.Model;
using System.Collections.Generic;

namespace BankReconciliation.Application.Transactions
{
    public interface IGetAllTransactions
    {
        List<TransactionDto> GetAll();
    }
}
