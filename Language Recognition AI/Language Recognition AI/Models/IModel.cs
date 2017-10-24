using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public interface IModel : IProgress
    {
        NGramMatrix N1Grams { get; set; }

        NGramMatrix N2Grams { get; set; }

        Report Validate(LanguageRecords[] languageRecords);

        Dictionary<Languages, double> ValidateSentence(string sentence);
    }
}
