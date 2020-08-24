using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.Transactions;
using System;

namespace BankReconciliation.DomainTest.Builders
{
    public class TransactionBuilder
    {
        private Money Amount = Money.Of(100);
        private DateTime PostedDate = new DateTime();
        private string Description = "description";
        private TransactionType TransactionType = TransactionType.CREDIT;

        public static TransactionBuilder Builder()
        {
            return new TransactionBuilder();
        }

        public Transaction Build()
        {
            return new Transaction(Amount, PostedDate, Description, TransactionType);
        }

    }
}
