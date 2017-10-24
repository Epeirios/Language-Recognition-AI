using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class NGramModel : IModel
    {
        public event EventHandler<EventArgsProgress> EventProgress;

        private NGramMatrix n1Grams;
        private NGramMatrix n2Grams;

        public NGramMatrix N1Grams
        {
            get
            {
                return n1Grams;
            }
            set
            {
                n1Grams = value;
            }
        }

        public NGramMatrix N2Grams
        {
            get
            {
                return n2Grams;
            }
            set
            {
                n2Grams = value;
            }
        }

        public NGramModel(NGramMatrix n1Grams, NGramMatrix n2Grams)
        {
            this.n1Grams = n1Grams;
            this.n2Grams = n2Grams;
        }

        public Report Validate(LanguageRecords[] languageRecords)
        {
            Report confusionReport = new Report();

            int progress = 0;

            foreach (LanguageRecords lRecords in languageRecords)
            {
                foreach (string record in lRecords.Records)
                {
                    Dictionary<Languages, double> report = ValidateSentence(record);

                    Languages language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    confusionReport.AddCase(language, lRecords.Language);
                }

                progress += 100 / languageRecords.Length;
                UpdateProgress(progress);
            }

            UpdateProgress(100);

            return confusionReport;
        }

        private void UpdateProgress(int progress)
        {
            EventProgress(this, new EventArgsProgress(progress));
        }

        public Dictionary<Languages, double> ValidateSentence(string sentence)
        {
            Dictionary<Languages, double> report = new Dictionary<Languages, double>();

            Dictionary<Languages, double> productn1 = GetNgramProduct(n1Grams, sentence);
            Dictionary<Languages, double> productn2 = GetNgramProduct(n2Grams, sentence, true);

            foreach (var item in productn1.Keys)
            {
                report.Add(item, productn1[item] / productn2[item]);
            }

            return report;
        }

        private Dictionary<Languages, double> GetNgramProduct(NGramMatrix nGrams, string sentence, bool b = false)
        {
            Dictionary<Languages, double> products = new Dictionary<Languages, double>();

            foreach (var nGram in nGrams.NGrams)
            {
                double product = 1.0f;

                IEnumerable<string> parts = Utility.SplitInParts(sentence, nGram.NgramSize, b);

                foreach (string part in parts)
                {
                    product *= 1 + nGram.GetPropability(part.ToCharArray().Select(c => c.ToString()).ToArray());
                }

                products.Add(nGram.Language, product);
            }

            return products;
        }
    }
}
