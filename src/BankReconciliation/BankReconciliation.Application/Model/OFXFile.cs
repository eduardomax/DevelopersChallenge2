namespace BankReconciliation.Application.Model
{
    public class OFXFile
    {
        public byte[] Content { get; private set; }

        public OFXFile(byte[] content)
        {
            Content = content;
        }
    }
}
