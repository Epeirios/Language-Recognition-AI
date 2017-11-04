using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ValidationReport
    {
        Dictionary<Languages, int> countCorrect;
        Dictionary<Languages, int> countIncorrect;

        public int CountCasesTotal
        {
            get
            {
                return countCorrect.Values.Sum() + countIncorrect.Values.Sum();
            }
        }

        public int CountCasesCorrectTotal
        {
            get
            {
                return countCorrect.Values.Sum();
            }
        }

        public int CountCasesIncorrectTotal
        {
            get
            {
                return countIncorrect.Values.Sum();
            }
        }

        public int PercentageCorrectTotal
        {
            get
            {
                return CountCasesCorrectTotal / CountCasesTotal * 100;
            }
        }

        public int CountCases(Languages language)
        {
            return CountCorrect(language) + CountIncorrect(language);
        }

        public int CountCorrect(Languages language)
        {
            return countCorrect[language];
        }

        public int CountIncorrect(Languages language)
        {
            return countIncorrect[language];
        }

        public int PercentageCorrect(Languages language)
        {
            return CountCorrect(language) / CountCases(language) * 100;
        }

        public ValidationReport()
        {
            countCorrect = new Dictionary<Languages, int>();
            countIncorrect = new Dictionary<Languages, int>();

            foreach (Languages item in Enum.GetValues(typeof(Languages)))
            {
                countCorrect.Add(item, 0);
                countIncorrect.Add(item, 0);
            }
        }

        public void AddCase(Languages predicted, Languages actual)
        {
            if (predicted == actual)
            {
                countCorrect[actual]++;
            }
            else
            {
                countIncorrect[actual]++;
            }
        }
    }
}
