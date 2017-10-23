﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class BiGramModel : IModel
    {
        const int partlength = 2;

        List<BiGram> BiGrams;

        public BiGramModel()
        {
            BiGrams = new List<BiGram>();
        }

        public void Train(LanguageRecords[] languageRecords)
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

                BiGrams.Add(bigram);
            }
        }

        public Report Validate(LanguageRecords[] languageRecords)
        {
            Report confusionReport = new Report();

            foreach (LanguageRecords lRecords in languageRecords)
            {
                foreach (string record in lRecords.Records)
                {
                    Dictionary<Languages, float> report = ValidateSentence(record);

                    Languages language = report.FirstOrDefault(x => x.Value == report.Values.Max()).Key;

                    confusionReport.AddCase(language, lRecords.Language);
                }
            }

            return confusionReport;
        }

        public Dictionary<Languages, float> ValidateSentence(string sentence)
        {
            Dictionary<Languages, float> report = new Dictionary<Languages, float>();

            foreach (var item in BiGrams)
            {
                float propability = 0;
                IEnumerable<string> parts = Utility.SplitInParts(sentence, partlength);

                foreach (string part in parts)
                {
                    propability += item.GetPropability(part);
                }

                report.Add(item.Language, propability);
            }

            return report;
        }
    }
}
