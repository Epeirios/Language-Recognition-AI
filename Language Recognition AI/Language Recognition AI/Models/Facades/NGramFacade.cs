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

        public NGramFacade(int ngramsize)
        {
            this.ngramsize = ngramsize;
            this.ngrammodels = new Dictionary<Languages, NGramModel>();

            foreach (var item in Enum.GetValues(typeof(Languages)).Cast<Languages>())
            {
                ngrammodels.Add(item, new NGramModel(ngramsize, item.ToString()));
            }
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
            ValidationReport confusionReport = new ValidationReport();

            foreach (var languagerecord in languageRecords)
            {
                foreach (var record in languagerecord.Records)
                {
                    Dictionary<string, double> report = ValidateSentence(record);

                    string language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    confusionReport.AddCase(language, languagerecord.Language.ToString());
                }
            }

            return confusionReport;
        }

        public Dictionary<string, double> ValidateSentence(string sentence)
        {
            Dictionary<string, double> products = new Dictionary<string, double>();

            foreach (var model in ngrammodels)
            {
                products.Add(model.Key.ToString(), model.Value.Run(sentence));
            }

            return products;
        }
    }
}
