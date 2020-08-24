using BankReconciliation.Domain.Transactions;
using BankReconciliation.Infrastructure.Context;
using System.Collections.Generic;

namespace BankReconciliation.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private TransactionContext context; 

        public TransactionRepository(TransactionContext context)
        {
            this.context = context;
        }

        public IEnumerable<Transaction> All()
        {
            return context.Transactions;
        }

        public void Add(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        public void AddAll(List<Transaction> transactions)
        {
            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}
