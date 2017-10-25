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

            Dictionary<Languages, double> products = GetNgramProduct(n1Grams, n2Grams, sentence);

            foreach (var key in products.Keys)
            {
                report.Add(key, products[key]);
            }

            return report;
        }

        private Dictionary<Languages, double> GetNgramProduct(NGramMatrix n1GramsMatrix, NGramMatrix n2GramsMatrix, string sentence)
        {
            Dictionary<Languages, double> products = new Dictionary<Languages, double>();

            for (int i = 0; i < n1GramsMatrix.NGrams.Count; i++)
            {
                double product = 1.0f;

                NGram n1Gram = n1GramsMatrix.NGrams[i];
                NGram n2Gram = n2GramsMatrix.NGrams[i];

                string[] partsN1 = Utility.SplitInParts(sentence, n1Gram.NgramSize);
                string[] partsN2 = Utility.SplitInParts(sentence, n2Gram.NgramSize, true);

                if (partsN1.Length > 1)
                {
                    for (int j = 0; j < partsN2.Length; j++)
                    {
                        double prob1 = n1Gram.GetPropability(partsN1[j]);
                        double prob2 = n2Gram.GetPropability(partsN2[j]);

                        double calc = prob1 / prob2;

                        product *= 1 + calc;
                    }

                    product *= n1Gram.GetPropability(partsN1[partsN1.Length - 1]);
                }
                else if (partsN1.Length == 1)
                {
                    product = n1Gram.GetPropability(partsN1[0]);
                }
                else
                {
                    product = 0;
                }

                products.Add(n1Gram.Language, 1 / product);
            }

            return products;
        }
    }
}
