using BankReconciliation.Application.Model;
using System.Collections.Generic;

namespace BankReconciliation.API.Models
{
    public class AllTransactionsViewModel
    {
        public List<TransactionDto> transactions { get; set; }

        public AllTransactionsViewModel(List<TransactionDto> transactions)
        {
            this.transactions = transactions;
        }
    }
}
