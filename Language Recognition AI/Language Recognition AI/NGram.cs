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

        public NGram(int size, Languages language)
        {
            this.language = language;

            FillMatrix(size);
        }

        protected abstract void FillMatrix(int size);

        public abstract void AddOccurence(string value);

        public abstract float GetPropability(string value);
    }
}
