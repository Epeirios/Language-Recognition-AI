using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGram
{
    public class NGram
    {
        int totalOccurencesCount;
        int ngramsize;
        string language;
        Dictionary<string, int> ngramMatrix;

        public string Language
        {
            get
            {
                return language;
            }
        }

        public int NGramSize
        {
            get
            {
                return ngramsize;
            }
        }

        public int TotalOccurences
        {
            get
            {
                return totalOccurencesCount;
            }
        }

        public NGram(int ngramsize, string language)
        {
            this.ngramsize = ngramsize;
            this.language = language;

            totalOccurencesCount = 0;
            ngramMatrix = new Dictionary<string, int>();
        }

        public void AddOccurence(string ngram)
        {
            if (ngramMatrix.ContainsKey(ngram))
            {
                ngramMatrix[ngram]++;
            }
            else
            {
                ngramMatrix.Add(ngram, 1);
            }

            totalOccurencesCount++;
        }

        public double GetPropability(string value)
        {
            if (ngramMatrix.ContainsKey(value))
            {
                return ngramMatrix[value] / (double)totalOccurencesCount;
            }
            else
            {
                return 1 / (double)totalOccurencesCount + 1;
            }
        }
    }
}
