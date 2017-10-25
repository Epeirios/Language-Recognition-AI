using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public abstract class NGram
    {
        protected int totalOccurencesCount;
        protected Languages language;
        Dictionary<string, int> matrix;

        public Languages Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

        public abstract int NgramSize { get; }

        public int TotalOccurences
        {
            get
            {
                return totalOccurencesCount;
            }
        }

        public NGram()
        {
            totalOccurencesCount = 0;
            matrix = new Dictionary<string, int>();
        }

        public void AddOccurence(string value)
        {
            if (matrix.ContainsKey(value))
            {
                matrix[value]++;
            }
            else
            {
                matrix.Add(value, 1);
            }

            totalOccurencesCount++;
        }

        public double GetPropability(string value)
        {
            if (matrix.ContainsKey(value))
            {
                return matrix[value] / (double)totalOccurencesCount;
            }
            else
            {
                return 1 / (double)totalOccurencesCount + 1;
            }
        }
    }
}
