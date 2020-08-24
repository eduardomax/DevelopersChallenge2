using System;

namespace BankReconciliation.Infrastructure.Parser
{
    public class ParserUtils
    {
        public static string GetValue(string line, string tag)
        {
            var index = line.IndexOf(tag);
            var subStringAhead = line.Substring(index + tag.Length);
            var separator = '\r';
            return subStringAhead.Split(separator)[0];
        }
        public static DateTime ExtractDate(string dtPosted)
        {
            var startIndexDate = 0;
            var lengthDate = 8;
            var formatDate = "yyyyMMdd";
            return DateTime.ParseExact(dtPosted.Substring(startIndexDate, lengthDate), formatDate,
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
