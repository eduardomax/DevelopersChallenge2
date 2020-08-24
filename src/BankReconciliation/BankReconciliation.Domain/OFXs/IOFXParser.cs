namespace BankReconciliation.Domain.OFXs
{
    public interface IOFXParser
    {
        OFX Parser(string ofxString);
    }
}
