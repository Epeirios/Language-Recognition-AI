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
            int progress = 0;

            foreach (LanguageRecords lRecords in languageRecords)
            {
                BiGram bigram = new BiGram(lRecords.CharDictionary, lRecords.Language);

                foreach (string record in lRecords.Records)
                {
                    IEnumerable<string> parts = Utility.SplitInParts(record, partlength);

                    foreach (var item in parts)
                    {
                        bigram.AddOccurence(item.ToCharArray().Select(c => c.ToString()).ToArray());
                    }
                }

                progress += 100 / languageRecords.Length;

                UpdateTrainingProgress(progress);

                nGrams.Add(bigram);
            }

            UpdateTrainingProgress(100);
        }
    }
}
