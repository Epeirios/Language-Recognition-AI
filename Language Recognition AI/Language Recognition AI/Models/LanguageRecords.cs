using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LanguageRecords
    {
        private Languages language;

        private int recordCount;
        private int maxLenghtRecord;
        private int minLenghtRecord;

        private List<string> records;
        private List<string> charDictionary;

        public Languages Language
        {
            get
            {
                return language;
            }
        }

        public int RecordCount
        {
            get
            {
                return recordCount;
            }
        }

        public int MaxLenghtRecord
        {
            get
            {
                return maxLenghtRecord;
            }
        }

        public int MinLenghtRecord
        {
            get
            {
                return minLenghtRecord;
            }
        }

        public string[] Records
        {
            get
            {
                return records.ToArray();
            }
        }

        public List<string> CharDictionary
        {
            get
            {
                return charDictionary;
            }
        }

        public LanguageRecords(Languages language)
        {
            this.language = language;

            recordCount = 0;
            maxLenghtRecord = 0;
            minLenghtRecord = 999;

            records = new List<string>();
            charDictionary = new List<string>();
        }

        public void Addrecord(string record)
        {
            records.Add(record);

            recordCount++;

            int recordlength = record.Length;

            if (recordlength > maxLenghtRecord)
            {
                maxLenghtRecord = recordlength;
            }

            if (recordlength < minLenghtRecord)
            {
                minLenghtRecord = recordlength;
            }

            foreach (var chr in record)
            {
                if (!charDictionary.Contains(chr.ToString()))
                {
                    charDictionary.Add(chr.ToString());
                }
            }
        }
    }
}
