using System;

namespace BankReconciliation.Application.Model
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime PostedDate { get; set; }
        public string Description { get; set; }
        public string TransactionType { get; set; }

        public TransactionDto(decimal amount, DateTime postedDate, string description, string transactionType)
        {
            Amount = amount;
            PostedDate = postedDate;
            Description = description;
            TransactionType = transactionType;
        }
    }
}
