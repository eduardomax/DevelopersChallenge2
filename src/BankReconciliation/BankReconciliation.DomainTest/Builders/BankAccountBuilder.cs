using BankReconciliation.Domain.OFXs;

namespace BankReconciliation.DomainTest.Builders
{
    public class BankAccountBuilder
    {
        private string bankId = "1";
        private string accountId = "2";
        private AccountType accountType = AccountType.CHECKING;

        public static BankAccountBuilder Builder()
        {
            return new BankAccountBuilder();
        }

        public BankAccount Build()
        {
            return new BankAccount(bankId, accountId, accountType);
        }
    }
}
