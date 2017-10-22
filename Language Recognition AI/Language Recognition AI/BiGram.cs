using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class BiGram : NGram
    {
        int[,] matrix;

        public BiGram(int size, Languages language) : base(size, language)
        {
            matrix = new int[size, size];
        }

        protected override void FillMatrix(int size)
        {
            // smoothing
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = 1;
                    totalOccurencesCount++;
                }
            }
        }

        public override void AddOccurence(string value)
        {
            if (value.Length == 2)
            {
                char[] dict = DataManager.Instance.TrainingData[(int)language].CharDictionary;

                int x = Array.IndexOf(dict, value[0]);
                int y = Array.IndexOf(dict, value[1]);

                matrix[x, y] += 1;
            }
            else
            {
                new NotImplementedException();
            }
        }

        public override float GetPropability(string value)
        {
            if (value.Length == 2)
            {
                char[] dict = DataManager.Instance.TrainingData[(int)language].CharDictionary;

                int x = Array.IndexOf(dict, value[0]);
                int y = Array.IndexOf(dict, value[1]);

                return matrix[x, y] / totalOccurencesCount;
            }
            else
            {
                new NotImplementedException();
                return new float();
            }            
        }
    }
}
