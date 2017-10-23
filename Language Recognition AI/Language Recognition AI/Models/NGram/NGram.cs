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
        }

        public int TotalOccurences
        {
            get
            {
                return totalOccurencesCount;
            }
        }

        public NGram(List<string> dict, Languages language)
        {
            this.dict = dict;
            this.language = language;
        }

        protected abstract void FillMatrix(int size);

        public abstract void AddOccurence(string[] value);

        public abstract float GetPropability(string[] value);
    }
}
