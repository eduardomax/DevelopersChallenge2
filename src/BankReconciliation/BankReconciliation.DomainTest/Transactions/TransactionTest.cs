using System;
using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.Transactions;
using NUnit.Framework;

namespace BankReconciliation.DomainTest.Transactions
{
    [TestFixture]
    public class TransactionTest
    {
        private readonly Money AMOUNT = Money.Of(100);
        private readonly DateTime POSTED_DATE = new DateTime(2020, 1, 1);
        private readonly string DESCRIPTION = "Description";
        private readonly TransactionType TRANSACTION_TYPE = TransactionType.CREDIT;

        [Test]
        public void ShouldCreate()
        {
            var transaction = new Transaction(AMOUNT, POSTED_DATE, DESCRIPTION, TRANSACTION_TYPE);

            Assert.AreEqual(AMOUNT, transaction.Amount);
            Assert.AreEqual(POSTED_DATE, transaction.PostedDate);
            Assert.AreEqual(DESCRIPTION, transaction.Description);
            Assert.AreEqual(TRANSACTION_TYPE, transaction.TransactionType);
        }
    }
}
