using System.Collections.Generic;
using System.Linq;

namespace BankReconciliation.Domain.Transactions
{
    public class TransactionMerge
    {
        public static List<Transaction> Merge(IEnumerable<Transaction> firstTransactions, IEnumerable<Transaction> secondTransactions)
        {
            TransactionComparer comparer = new TransactionComparer();
            HashSet<Transaction> set = new HashSet<Transaction>(firstTransactions, comparer);

            firstTransactions.ToList().ForEach(t => set.Add(t));
            secondTransactions.ToList().ForEach(t => set.Add(t));
            return set.ToList();
        }
    }
}
