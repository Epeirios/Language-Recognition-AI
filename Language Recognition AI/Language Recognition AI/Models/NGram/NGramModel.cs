using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public abstract class NGramModel : IModel
    {
        public event EventHandler<EventArgsProgress> EventValidationProgress;
        public event EventHandler<EventArgsProgress> EventTrainingProgress;

        protected List<NGram> nGrams;

        protected int partlength;

        public NGramModel()
        {
            nGrams = new List<NGram>();
        }

        public abstract void Train(LanguageRecords[] languageRecords);

        public Report Validate(LanguageRecords[] languageRecords)
        {
            Report confusionReport = new Report();

            int progress = 0;

            foreach (LanguageRecords lRecords in languageRecords)
            {
                foreach (string record in lRecords.Records)
                {
                    Dictionary<Languages, float> report = ValidateSentence(record);

                    Languages language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    confusionReport.AddCase(language, lRecords.Language);
                }

                progress += 100 / languageRecords.Length;
                UpdateValidationProgress(progress);
            }

            UpdateValidationProgress(100);

            return confusionReport;
        }

        protected void UpdateValidationProgress(int progress)
        {
            EventValidationProgress(this, new EventArgsProgress(progress));
        }

        protected void UpdateTrainingProgress(int progress)
        {
            EventTrainingProgress(this, new EventArgsProgress(progress));
        }

        public Dictionary<Languages, float> ValidateSentence(string sentence)
        {
            Dictionary<Languages, float> report = new Dictionary<Languages, float>();

            foreach (var item in nGrams)
            {
                float propability = 0;
                IEnumerable<string> parts = Utility.SplitInParts(sentence, partlength);

                foreach (string part in parts)
                {
                    propability += item.GetPropability(part.ToCharArray().Select(c => c.ToString()).ToArray());
                }

                report.Add(item.Language, propability);
            }

            return report;
        }
    }
}
