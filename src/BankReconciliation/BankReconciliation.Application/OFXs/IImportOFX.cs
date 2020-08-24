using BankReconciliation.Application.Model;
using System.Collections.Generic;

namespace BankReconciliation.Application.OFXs
{
    public interface IImportOFX
    {
        void Import(List<OFXFile> ofxFiles);
    }
}