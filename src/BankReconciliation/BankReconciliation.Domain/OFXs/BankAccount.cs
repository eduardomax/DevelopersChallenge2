using BankReconciliation.Domain.Common;

namespace BankReconciliation.Domain.OFXs
{
    public class BankAccount : Entity<BankAccount>
    {
        public string BankId { get; private set; }
        public string AccountId { get; private set; }
        public AccountType AccountType { get; private set; }

        public BankAccount(string bankId, string accountId, AccountType accountType)
        {
            this.BankId = bankId;
            this.AccountId = accountId;
            this.AccountType = accountType;
        }

    }
}