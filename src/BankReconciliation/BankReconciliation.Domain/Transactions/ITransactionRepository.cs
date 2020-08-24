using System.Collections.Generic;

namespace BankReconciliation.Domain.Transactions
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> All();
        void Add(Transaction transaction);
        void AddAll(List<Transaction> transactions);
    }
}
