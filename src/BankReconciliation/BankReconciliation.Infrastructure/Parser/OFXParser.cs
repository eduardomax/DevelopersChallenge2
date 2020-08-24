using BankReconciliation.Domain.OFXs;
using System;

namespace BankReconciliation.Infrastructure.Parser
{
    public class OFXParser : IOFXParser
    {
        public OFX Parser(string ofxString)
        {
            CurrencyType currencyType = ExtractCurrencyType(ofxString);
            var bankAccount = BankAccountParser.Parser(ofxString);

            OFX ofx = new OFX(currencyType, bankAccount);
            TransactionParser.Parser(ofx, currencyType, ofxString);

            return ofx;
        }

        private CurrencyType ExtractCurrencyType(string ofxString)
        {
            var indexCurDef = ofxString.IndexOf("<CURDEF>");
            var curDef = ParserUtils.GetValue(ofxString, "<CURDEF>");
            Enum.TryParse(curDef, true, out CurrencyType currencyType);

            return currencyType;
        }
    }
}
