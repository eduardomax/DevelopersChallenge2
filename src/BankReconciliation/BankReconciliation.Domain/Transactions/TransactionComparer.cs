using System;
using System.Collections.Generic;

namespace BankReconciliation.Domain.Transactions
{
    public class TransactionComparer : IEqualityComparer<Transaction>
    {
        public Boolean Equals(Transaction x, Transaction y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if ((x == null) != (y == null)) return false;
            if (x == null && y == null) return true;

            return
                x.Amount.Equals(y.Amount) &&
                x.PostedDate.Equals(y.PostedDate) &&
                x.Description.Equals(y.Description) &&
                x.TransactionType.Equals(y.TransactionType);
        }

        public int GetHashCode(Transaction obj)
        {
            return
                obj.Amount.GetHashCode() ^
                obj.PostedDate.GetHashCode() ^
                obj.Description.GetHashCode() ^
                obj.TransactionType.GetHashCode();
        }
    }
}
