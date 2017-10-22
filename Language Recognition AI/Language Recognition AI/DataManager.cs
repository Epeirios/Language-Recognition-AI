using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class DataManager
    {
        private static DataManager instance;             

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }

                return instance;
            }
        }

        private string[] langFilter = { "bs", "id", "pt-PT", "pt-BR", "fr-CA", "fr-FR" };

        private LanguageRecords[] trainingData;
        private LanguageRecords[] validationData;

        public string[] Languages
        {
            get
            {
                return langFilter;
            }
        }

        public LanguageRecords[] TrainingData
        {
            get
            {
                return trainingData;
            }
        }

        public LanguageRecords[] ValidationData
        {
            get
            {
                return validationData;
            }
        }

        private DataManager()
        {
            trainingData = ProcessData(Properties.Resources.DSL_TRAIN);
            validationData = ProcessData(Properties.Resources.DSL_DEV);
        }

        private LanguageRecords[] ProcessData(string resouce)
        {
            List<string> languages = new List<string>(langFilter);

            LanguageRecords[] returnValue = new LanguageRecords[6];

            for (int i = 0; i < returnValue.Length; i++)
            {
                returnValue[i] = new LanguageRecords(languages[i]);
            }

            string[] data = resouce.Split('\n');

            foreach (string line in data)
            {
                string[] cur = line.Split('\t');

                if (cur.Length == 2)
                {
                    string lang = cur[1];

                    if (languages.Contains(lang))
                    {
                        returnValue[languages.IndexOf(lang)].Addrecord(cur[0]);
                    }
                }
            }

            return returnValue;
        }
    }
}
