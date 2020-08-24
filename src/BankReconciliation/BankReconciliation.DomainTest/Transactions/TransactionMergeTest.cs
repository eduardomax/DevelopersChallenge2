using BankReconciliation.Domain.Transactions;
using BankReconciliation.DomainTest.Builders;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankReconciliation.DomainTest.Transactions
{
    [TestFixture]
    public class TransactionMergeTest
    {
        [Test]
        public void ShouldMergeWithoutDuplicates()
        {
            int sizeExpected = 1;
            List<Transaction> listTransactionsOne = new List<Transaction>();
            List<Transaction> listTransactionsTwo = new List<Transaction>();
            listTransactionsOne.Add(TransactionBuilder.Builder().Build());
            listTransactionsTwo.Add(TransactionBuilder.Builder().Build());

            List<Transaction> finalListMerged = TransactionMerge.Merge(listTransactionsOne, listTransactionsTwo);

            Assert.AreEqual(sizeExpected, finalListMerged.Count);
        }
    }
}
