using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class BiGramModel : NGramModel, IModel
    {
        public BiGramModel() : base()
        {
            partlength = 2;
        }

        public override void Train(LanguageRecords[] languageRecords)
        {
            foreach (LanguageRecords lRecords in languageRecords)
            {
                BiGram bigram = new BiGram(lRecords.CharDictionary.Count, lRecords.Language);

                foreach (string record in lRecords.Records)
                {
                    IEnumerable<string> parts = Utility.SplitInParts(record, partlength);

                    foreach (var item in parts)
                    {
                        bigram.AddOccurence(item);
                    }
                }

                nGrams.Add(bigram);
            }
        }
    }
}
