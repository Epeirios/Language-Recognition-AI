using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class LanguageRecords
    {
        private string language;

        private int recordCount;
        private int maxLenghtRecord;
        private int minLenghtRecord;

        private List<string> records;
        private List<char> charDictionary;

        public string Language
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

        public char[] CharDictionary
        {
            get
            {
                return charDictionary.ToArray();
            }
        }

        public LanguageRecords(string language)
        {
            this.language = language;

            recordCount = 0;
            maxLenghtRecord = 0;
            minLenghtRecord = 999;

            records = new List<string>();
            charDictionary = new List<char>();
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

            foreach (char chr in record)
            {
                if (!charDictionary.Contains(chr))
                {
                    charDictionary.Add(chr);
                }
            }
        }
    }
}
