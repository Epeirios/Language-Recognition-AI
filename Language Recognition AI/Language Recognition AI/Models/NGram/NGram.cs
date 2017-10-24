using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public abstract class NGram
    {
        protected int totalOccurencesCount = 0;
        protected Languages language;
        protected List<string> dict;

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

        public abstract List<string> Dict { set; get; }

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

        }

        protected abstract void FillMatrix(int size);

        public abstract void AddOccurence(string[] value);

        public abstract double GetPropability(string[] value);
    }
}
