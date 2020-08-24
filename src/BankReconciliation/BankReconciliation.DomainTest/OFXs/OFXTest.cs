using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.OFXs;
using BankReconciliation.Domain.Transactions;
using BankReconciliation.DomainTest.Builders;
using NUnit.Framework;
using System;
using System.Linq;

namespace BankReconciliation.DomainTest.OFXs
{
    [TestFixture]
    public class OFXTest
    {
        private readonly CurrencyType CURRENCY_TYPE = CurrencyType.BRL;
        private readonly BankAccount BANK_ACCOUNT_FROM = BankAccountBuilder.Builder().Build();

        [Test]
        public void ShouldCreate()
        {
            var ofx = new OFX(CURRENCY_TYPE, BANK_ACCOUNT_FROM);

            Assert.AreEqual(CURRENCY_TYPE, ofx.CurrencyType);
            Assert.AreEqual(BANK_ACCOUNT_FROM, ofx.BankAccountFrom);
        }

        [Test]
        public void ShouldAddTransaction()
        {
            Money amount = Money.Of(10);
            DateTime postedDate = new DateTime(2020, 1, 1);
            string description = "description";
            TransactionType transactionType = TransactionType.CREDIT;
            var ofx = new OFX(CURRENCY_TYPE, BANK_ACCOUNT_FROM);

            ofx.AddTransaction(amount, postedDate, description, transactionType);
            
            var transaction = ofx.Transactions.First();
            Assert.AreEqual(amount, transaction.Amount);
            Assert.AreEqual(postedDate, transaction.PostedDate);
            Assert.AreEqual(description, transaction.Description);
            Assert.AreEqual(transactionType, transaction.TransactionType);
        }
    }
}
