namespace BankReconciliation.Application.Model
{
    public class BankAccountDto
    {
        public int BankId { get; set; }
        public int AccountId { get; set; }
        public string AccountType { get; set; }

        public BankAccountDto(int bankId, int accountId, string accountType)
        {
            BankId = bankId;
            AccountId = accountId;
            AccountType = accountType;
        }
    }
}
