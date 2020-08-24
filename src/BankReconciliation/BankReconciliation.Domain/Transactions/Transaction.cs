using BankReconciliation.Domain.Common;
using System;

namespace BankReconciliation.Domain.Transactions
{
    public class Transaction : Entity<Transaction>
    {
        public Money Amount { get; private set; }
        public DateTime PostedDate { get; private set; }
        public string Description { get; private set; }
        public TransactionType TransactionType { get; private set; }

        protected Transaction() { }

        public Transaction(Money amount, DateTime postedDate, string description, TransactionType transactionType)
        {
            Amount = amount ?? throw new ArgumentNullException(nameof(amount)); ;
            PostedDate = postedDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TransactionType = transactionType;
        }
    
    }
}
