using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class DataManager
    {
        public event EventHandler<EventArgsProgress> EventProgress;

        string dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\sentences.cvs");

        private LanguageRecords[] trainingData;
        private LanguageRecords[] validationData;

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

        public DataManager()
        {
            
        }

        public void ProcessData()
        {
            int linecount = 0;
            int progress = 0;

            int[] counts =
            {
                392501,
                539839,
                335118,
                798798,
                527907,
                549855,
                276650,
                256993,
            };

            int totalcount = counts.Sum();

            StreamReader sr = new StreamReader(dataPath);

            List<string> languages = Enum.GetNames(typeof(Languages)).ToList<string>();
            
            LanguageRecords[] trainingData = new LanguageRecords[8];
            LanguageRecords[] validationData = new LanguageRecords[8];

            for (int i = 0; i < trainingData.Length; i++)
            {
                trainingData[i] = new LanguageRecords((Languages)i);
                validationData[i] = new LanguageRecords((Languages)i);
            }

            string currentline;

            while ((currentline = sr.ReadLine()) != null)
            {
                string[] cur = currentline.Split('\t');

                if (cur.Length == 2)
                {
                    string lang = cur[0];

                    if (languages.Contains(lang))
                    {
                        int index = languages.IndexOf(lang);

                        if (trainingData[index].RecordCount < (int)(counts[index] * 0.8))
                        {
                            trainingData[index].Addrecord(cur[1]);
                        }
                        else
                        {
                            validationData[index].Addrecord(cur[1]);
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }

                linecount++;

                if ((linecount % (totalcount / 100)) == 0)
                {
                    progress++;
                    UpdateProgress(progress);
                }
            }

            this.trainingData = trainingData;
            this.validationData = validationData;
        }

        protected void UpdateProgress(int progress)
        {
            EventProgress(this, new EventArgsProgress(progress));
        }
    }
}
