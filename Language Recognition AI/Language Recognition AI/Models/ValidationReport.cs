using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ValidationReport
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

        public ValidationReport()
        {
            countCorrect = 0;
            countIncorrect = 0;
        }

        public void AddCase(string predicted, string actual)
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
