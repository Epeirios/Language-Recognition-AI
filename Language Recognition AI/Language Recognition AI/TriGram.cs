using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class TriGram : NGram
    {
        int[,,] matrix;

        public TriGram(int size, Languages language) : base(size, language)
        {
            matrix = new int[size, size, size];
        }

        public override void AddOccurence(string value)
        {
            throw new NotImplementedException();
        }

        public override float GetPropability(string value)
        {
            throw new NotImplementedException();
        }

        protected override void FillMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        matrix[i, j, k] = 1;
                        totalOccurencesCount++;
                    }
                }
            }
        }
    }
}
