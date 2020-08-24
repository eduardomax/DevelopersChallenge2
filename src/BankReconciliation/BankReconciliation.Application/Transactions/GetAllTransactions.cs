using BankReconciliation.Application.Model;
using BankReconciliation.Domain.Transactions;
using System.Collections.Generic;

namespace BankReconciliation.Application.Transactions
{
    public class GetAllTransactions : IGetAllTransactions
    {
        private ITransactionRepository _repository;

        public GetAllTransactions(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public List<TransactionDto> GetAll()
        {
            var transactionsDtos = new List<TransactionDto>();
            var transactions = _repository.All();

            foreach (var transaction in transactions)
            {
                var transactionDto = new TransactionDto(transaction.Amount.Value, transaction.PostedDate,
                    transaction.Description, transaction.TransactionType.ToString());
                transactionsDtos.Add(transactionDto);
            }

            return transactionsDtos;
        }
    }
}
