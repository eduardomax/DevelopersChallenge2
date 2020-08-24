using BankReconciliation.Application.Model;
using BankReconciliation.Domain.OFXs;
using System.Collections.Generic;
using BankReconciliation.Domain.Transactions;

namespace BankReconciliation.Application.OFXs
{
    public class ImportOFX : IImportOFX
    {
        private readonly IOFXParser _parser;
        private readonly ITransactionRepository _repository;

        public ImportOFX(ITransactionRepository repository, IOFXParser _ofxParser)
        {
            _parser = _ofxParser;
            _repository = repository;
        }

        public void Import(List<OFXFile> ofxFiles)
        {
            List<OFX> ofxs = new List<OFX>();

            foreach (var ofxFile in ofxFiles)
            {
                var ofxFileString = System.Text.Encoding.Default.GetString(ofxFile.Content);
                OFX ofx = _parser.Parser(ofxFileString);
                ofxs.Add(ofx);
            }

            List<Transaction> allTransactions = new List<Transaction>();

            foreach (var ofx in ofxs)
            {
                allTransactions = TransactionMerge.Merge(allTransactions, ofx.Transactions);
            }

            _repository.AddAll(allTransactions);
        }
    }
}
