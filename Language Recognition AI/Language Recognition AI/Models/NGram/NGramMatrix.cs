using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public abstract class NGramMatrix : IProgress
    {
        public event EventHandler<EventArgsProgress> EventProgress;

        protected List<NGram> nGrams;

        public List<NGram> NGrams
        {
            get
            {
                return nGrams;
            }
        }

        public NGramMatrix()
        {
            nGrams = new List<NGram>();
        }

        public abstract void Train(LanguageRecords[] languageRecords);

        protected void Train<T>(LanguageRecords[] languageRecords) where T : NGram, new()
        {
            int progress = 0;

            foreach (LanguageRecords lRecords in languageRecords)
            {
                T ngram = new T();

                ngram.Dict = lRecords.CharDictionary;
                ngram.Language = lRecords.Language;

                foreach (string record in lRecords.Records)
                {
                    IEnumerable<string> parts = Utility.SplitInParts(record, ngram.NgramSize);

                    foreach (var item in parts)
                    {
                        ngram.AddOccurence(item.ToCharArray().Select(c => c.ToString()).ToArray());
                    }
                }

                progress += 100 / languageRecords.Length;

                UpdateProgress(progress);

                nGrams.Add(ngram);
            }

            UpdateProgress(100);
        }

        protected void UpdateProgress(int progress)
        {
            EventProgress(this, new EventArgsProgress(progress));
        }
    }
}
