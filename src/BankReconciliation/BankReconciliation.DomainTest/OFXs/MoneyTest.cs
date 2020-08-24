using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.OFXs;
using NUnit.Framework;

namespace BankReconciliation.DomainTest.OFXs
{
    [TestFixture]
    public class MoneyTest
    {
        private readonly decimal VALUE = 100m;
        private readonly CurrencyType CURRENCY_TYPE = CurrencyType.BRL;

        [Test]
        public void ShouldCreate()
        {
            Money money = new Money(VALUE, CURRENCY_TYPE);

            Assert.AreEqual(VALUE, money.Value);
            Assert.AreEqual(CURRENCY_TYPE, money.CurrencyType);
        }

        [Test]
        public void ShouldCreateWithCurrencyTypeDefaultEqualsBRL()
        {
            Money money = Money.Of(VALUE);

            Assert.AreEqual(VALUE, money.Value);
            Assert.AreEqual(CURRENCY_TYPE, money.CurrencyType);
        }
    }
}
