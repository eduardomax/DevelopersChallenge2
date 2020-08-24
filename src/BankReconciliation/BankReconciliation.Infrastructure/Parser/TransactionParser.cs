using BankReconciliation.Domain.Common;
using BankReconciliation.Domain.OFXs;
using BankReconciliation.Domain.Transactions;
using System;

namespace BankReconciliation.Infrastructure.Parser
{
    public class TransactionParser
    {
        public static void Parser(OFX ofx, CurrencyType currencyType, string ofxString)
        {
            var startIndexTransactionList = ofxString.IndexOf("<BANKTRANLIST>");
            var finalIndexTransactionList = ofxString.IndexOf("</BANKTRANLIST>");
            var lengthTransactionList = finalIndexTransactionList - startIndexTransactionList;
            var transactionListString = ofxString.Substring(startIndexTransactionList, lengthTransactionList);

            var transactionList = transactionListString.Split(new string[] { "<STMTTRN>" }, StringSplitOptions.None);

            foreach (var transactionString in transactionList)
            {
                if (IsValidTransactionString(transactionString))
                {
                    AddTransactionToOFX(transactionString, ofx, currencyType);
                }
            }
        }

        private static bool IsValidTransactionString(string transactionString)
        {
            return transactionString.Contains("<TRNTYPE>") && transactionString.Contains("<DTPOSTED>") &&
                    transactionString.Contains("<TRNAMT>") && transactionString.Contains("<MEMO>");
        }

        private static void AddTransactionToOFX(string transactionString, OFX ofx, CurrencyType currencyType)
        {
            var trnType = ParserUtils.GetValue(transactionString, "<TRNTYPE>");
            var dtPosted = ParserUtils.GetValue(transactionString, "<DTPOSTED>");
            var trnAmt = ParserUtils.GetValue(transactionString, "<TRNAMT>");
            var description = ParserUtils.GetValue(transactionString, "<MEMO>");

            Enum.TryParse(trnType, true, out TransactionType transactionType);
            Money amountMoney = new Money(decimal.Parse(trnAmt), currencyType);
            DateTime datePosted = ParserUtils.ExtractDate(dtPosted);

            ofx.AddTransaction(amountMoney, datePosted, description, transactionType);
        }
    }
}
