using NGram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NGramFacade : IModelFacade
    {
        int ngramsize;
        Dictionary<Languages, NGramModel> ngrammodels;
        ValidationReport validationReport;

        public NGramFacade(int ngramsize)
        {
            this.ngramsize = ngramsize;
            this.ngrammodels = new Dictionary<Languages, NGramModel>();
            this.validationReport = new ValidationReport();

            foreach (var item in Enum.GetValues(typeof(Languages)).Cast<Languages>())
            {
                ngrammodels.Add(item, new NGramModel(ngramsize, item.ToString()));
            }
        }

        public ValidationReport GetValidationReport()
        {
            return validationReport;
        }

        public void TrainModel(LanguageRecords[] languagerecords)
        {
            foreach (var languagerecord in languagerecords)
            {
                foreach (var record in languagerecord.Records)
                {
                    ngrammodels[languagerecord.Language].Train(record);
                }
            }
        }

        public ValidationReport ValidateModel(LanguageRecords[] languageRecords)
        {
            ValidationReport localReport = new ValidationReport();

            foreach (var languagerecord in languageRecords)
            {
                foreach (var record in languagerecord.Records)
                {
                    Dictionary<Languages, double> report = ValidateSentence(record);

                    Languages language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    localReport.AddCase(language, languagerecord.Language);
                    validationReport.AddCase(language, languagerecord.Language);
                }
            }

            return localReport;
        }

        public Dictionary<Languages, double> ValidateSentence(string sentence)
        {
            Dictionary<Languages, double> products = new Dictionary<Languages, double>();

            const int chars = 30;

            int parts = (int)Math.Floor(sentence.Length / (double)chars);

            if (parts == 0)
            {
                foreach (var model in ngrammodels)
                {
                    products.Add(model.Key, model.Value.Run(sentence));
                }
            }
            else
            {
                for (int i = 1; i <= parts; i++)
                {
                    products.Clear();

                    int sublenght = (i) * chars;

                    if (i == parts)
                    {
                        sublenght = sentence.Length;
                    }

                    foreach (var model in ngrammodels)
                    {
                        products.Add(model.Key, model.Value.Run(sentence.Substring(0, sublenght)));
                    }

                    double max = 0;
                    int mindif = 0;

                    foreach (var item in products)
                    {
                        if (item.Value > max)
                        {
                            max = item.Value;
                        }
                    }

                    foreach (var item in products)
                    {
                        if (item.Value != max)
                        {
                            int val = (int)(max / item.Value * 100);

                            if (mindif > val)
                            {
                                mindif = val;
                            }
                        }
                    }

                    if (mindif >= 50)
                    {
                        break;
                    }
                }
            }



            return products;
        }
    }
}
