using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class TriGramModel : NGramModel
    {
        public TriGramModel() : base()
        {
            partlength = 3;
        }

        public override void Train(LanguageRecords[] languageRecords)
        {
            foreach (LanguageRecords lRecords in languageRecords)
            {
                TriGram trigram = new TriGram(lRecords.CharDictionary.Count, lRecords.Language);

                foreach (string record in lRecords.Records)
                {
                    IEnumerable<string> parts = Utility.SplitInParts(record, partlength);

                    foreach (var item in parts)
                    {
                        trigram.AddOccurence(item);
                    }
                }

                nGrams.Add(trigram);
            }
        }
    }
}
