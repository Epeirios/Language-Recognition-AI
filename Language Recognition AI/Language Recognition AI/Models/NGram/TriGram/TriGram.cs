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

        public TriGram(List<string> dict, Languages language) : base(dict, language)
        {
            int size = dict.Count;

            matrix = new int[size, size, size];

            FillMatrix(size);
        }

        public override void AddOccurence(string[] value)
        {
            int[] coords = GetCoords(value);

            matrix[coords[0], coords[1], coords[2]] += 1;
            totalOccurencesCount++;
        }

        public override float GetPropability(string[] value)
        {
            int[] coords = GetCoords(value);

            // if case dows not exist
            foreach (var item in coords)
            {
                if (item == -1)
                {
                    return 0.00000000001f;
                }
            }

            return matrix[coords[0], coords[1], coords[2]] / (float)totalOccurencesCount;
        }

        private int[] GetCoords(string[] value)
        {
            int length = value.Length;

            int[] coords = new int[3];                      
            
            coords[0] = dict.IndexOf(" ");
            coords[1] = dict.IndexOf(" ");
            coords[2] = dict.IndexOf(" ");

            if (length >= 1)
            {
                coords[0] = dict.IndexOf(value[0]);
            }
            if (length >= 2)
            {
                coords[1] = dict.IndexOf(value[1]);
            }
            if (length >= 3)
            {
                coords[2] = dict.IndexOf(value[2]);
            }

            return coords;
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
