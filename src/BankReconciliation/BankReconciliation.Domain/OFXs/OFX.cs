using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace BankReconciliation.Domain.OFXs
{
    public class OFX : Entity<OFX>
    {
        public CurrencyType CurrencyType { get; private set; }
        public BankAccount BankAccountFrom { get; private set; }
        private List<Transaction> _transactions;
        public IEnumerable<Transaction> Transactions => _transactions;

        public OFX(CurrencyType currencyType, BankAccount bankAccountFrom)
        {
            CurrencyType = currencyType;
            BankAccountFrom = bankAccountFrom ?? throw new ArgumentNullException(nameof(bankAccountFrom));

            _transactions = new List<Transaction>();
        }

        public void AddTransaction(Money amount, DateTime posted, string description, TransactionType transactionType)
        {
            var transaction = new Transaction(amount, posted, description, transactionType);

            _transactions.Add(transaction);
        }
    }
}
