using BankReconciliation.Domain.OFXs;
using NUnit.Framework;

namespace BankReconciliation.DomainTest.OFXs
{
    [TestFixture]
    public class BankAccountTest
    {
        private readonly string BANK_ID = "1";
        private readonly string ACCOUNT_ID = "2";
        private readonly AccountType ACCOUNT_TYPE = AccountType.CHECKING;

        [Test]
        public void ShouldCreate()
        {
            BankAccount bankAccount = new BankAccount(BANK_ID, ACCOUNT_ID, ACCOUNT_TYPE);

            Assert.AreEqual(BANK_ID, bankAccount.BankId);
            Assert.AreEqual(ACCOUNT_ID, bankAccount.AccountId);
            Assert.AreEqual(ACCOUNT_TYPE, bankAccount.AccountType);
        }
    }
}
