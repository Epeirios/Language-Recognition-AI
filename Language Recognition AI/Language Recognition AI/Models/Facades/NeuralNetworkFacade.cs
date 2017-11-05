using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Models
{
    public class NeuralNetworkFacade : IModelFacade
    {
        public ValidationReport GetValidationReport()
        {
            throw new NotImplementedException();
        }

        public long TrainModel(LanguageRecords[] languagerecords)
        {
            throw new NotImplementedException();
        }

        public ValidationReport ValidateModel(LanguageRecords[] languagerecords)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Languages, double> ValidateSentence(string sentence)
        {
            throw new NotImplementedException();
        }
    }
}
