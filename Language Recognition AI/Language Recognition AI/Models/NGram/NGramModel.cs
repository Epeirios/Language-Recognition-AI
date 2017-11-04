using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NGram
{
    public class NGramModel
    {
        private string language;

        private NGram n1gram;
        private NGram n2gram;

        public NGramModel(int n, string language)
        {
            this.language = language;

            if (n <= 1)
            {
                throw new Exception("n must be larger than 1");
            }
            else
            {
                this.n1gram = new NGram(n, language);
                this.n2gram = new NGram(n - 1, language);
            }
        }

        public double Run(string sentence)
        {
            double product = 1;

            string[] n1grams = SplitInGrams(sentence, n1gram.NGramSize);
            string[] n2grams = SplitInGrams(sentence, n2gram.NGramSize, true); // assumed that this is always the shortest by 1

            int n1gramlenght = n1grams.Length;
            int n2gramlenght = n2grams.Length;

            if (n1gramlenght > 1)
            {
                if (n1gramlenght == n2gramlenght + 1) // check if assumption is true (should always be)
                {
                    for (int i = 0; i < n2gramlenght; i++) // is the reason we iterate through n2grams
                    {
                        double prob1 = n1gram.GetPropability(n1grams[i]);
                        double prob2 = n2gram.GetPropability(n2grams[i]);

                        double calc = prob1 / prob2;

                        product *= calc;
                    }
                    
                    product *= n1gram.GetPropability(n1grams[n1gramlenght - 1]);
                }
                else
                {
                    throw new Exception("lenght of ngrams is wrong");
                }
            }
            else if (n2grams.Length == 1 && n1grams.Length == 0)
            {
                return n2gram.GetPropability(sentence);
            }
            else
            {
                return 0.0f;
            }

            return product;
        }

        public void Train(string sentence)
        {
            string[] parts = SplitInGrams(sentence, n1gram.NGramSize);

            foreach (var item in parts)
            {
                n1gram.AddOccurence(item);
            }

            parts = SplitInGrams(sentence, n2gram.NGramSize);

            foreach (var item in parts)
            {
                n2gram.AddOccurence(item);
            }
        }

        private string[] SplitInGrams(string str, int partLength, bool b = false)
        {
            List<string> output = new List<string>();

            if (str == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (int i = 0; i < str.Length - partLength; i++)
            {
                output.Add(str.Substring(i, partLength));
            }

            if (b)
            {
                if (output.Count <= 2)
                {
                    return new string[] { };
                }

                output.RemoveAt(0);
                output.RemoveAt(output.Count - 1);
            }

            return output.ToArray();
        }
    }
}
