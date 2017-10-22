using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class Report
    {
        private int countCorrect;
        private int countIncorrect;

        public int CountCorrect
        {
            get
            {
                return countCorrect;
            }
        }

        public int CountIncorrect
        {
            get
            {
                return countIncorrect;
            }
        }

        public int CountCases
        {
            get
            {
                return CountCorrect + CountIncorrect;
            }
        }

        public Report()
        {
            countCorrect = 0;
            countIncorrect = 0;
        }

        public void AddCase(Languages predicted, Languages actual)
        {
            if (predicted == actual)
            {
                countCorrect++;
            }
            else
            {
                countIncorrect++;
            }
        }
    }
}
