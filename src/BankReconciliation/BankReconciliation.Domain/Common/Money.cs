using BankReconciliation.Domain.OFXs;

namespace BankReconciliation.Domain.Common
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get; protected set; }
        public CurrencyType CurrencyType { get; protected set; }

        protected Money() { }

        public Money(decimal value, CurrencyType currencyType)
        {
            this.Value = value;
            this.CurrencyType = currencyType;
        }

        public static Money Of(decimal value)
        {
            return new Money(value, CurrencyType.BRL);
        }

        protected override bool EqualsCore(Money other)
        {
            return Value == other.Value && CurrencyType == other.CurrencyType;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ CurrencyType.GetHashCode();
        }
    }
}