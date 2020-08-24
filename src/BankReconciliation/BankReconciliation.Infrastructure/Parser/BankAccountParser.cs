using BankReconciliation.Domain.OFXs;
using System;

namespace BankReconciliation.Infrastructure.Parser
{
    public class BankAccountParser
    {
        public static BankAccount Parser(string ofxString)
        {
            var startIndexBankAcctFrom = ofxString.IndexOf("<BANKACCTFROM>") + "<BANKACCTFROM>".Length;
            var finalIndexBankAcctFrom = ofxString.IndexOf("</BANKACCTFROM>");
            var lengthBankAcctFrom = finalIndexBankAcctFrom - startIndexBankAcctFrom;
            var bankAcctFrom = ofxString.Substring(startIndexBankAcctFrom, lengthBankAcctFrom);

            return BuildBankAccount(bankAcctFrom);
        }

        private static BankAccount BuildBankAccount(string bankAcctFrom)
        {
            var bankId = ParserUtils.GetValue(bankAcctFrom, "<BANKID>");
            var acctId = ParserUtils.GetValue(bankAcctFrom, "<ACCTID>");
            var acctType = ParserUtils.GetValue(bankAcctFrom, "<ACCTTYPE>");
            Enum.TryParse(acctType, true, out AccountType accountType);

            return new BankAccount(bankId, acctId, accountType);
        }
    }
}
