using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class QuadGram : NGram
    {
        int[,,,] matrix;

        public override int NgramSize
        {
            get
            {
                return 4;
            }
        }

        public override List<string> Dict
        {
            get
            {
                return dict;
            }
            set
            {
                dict = value;

                int size = value.Count;

                matrix = new int[size, size, size, size];

                FillMatrix(size);
            }
        }

        public QuadGram() : base()
        {

        }

        protected override void FillMatrix(int size)
        {
            // smoothing
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        for (int l = 0; l < size; l++)
                        {
                            matrix[i, j, k, l] = 1;
                            totalOccurencesCount++;
                        }
                    }
                }
            }
        }

        public override void AddOccurence(string[] value)
        {
            int[] coords = GetCoords(value);

            matrix[coords[0], coords[1], coords[2], coords[3]] += 1;
            totalOccurencesCount++;
        }

        public override double GetPropability(string[] value)
        {
            int local = 0;

            int[] coords = GetCoords(value);

            int output = 0;

            // if case does not exist
            foreach (var item in coords)
            {
                if (item == -1)
                {
                    local++;

                    output = 1;
                }
            }

            if (output == 0)
            {
                output = matrix[coords[0], coords[1], coords[2], coords[3]];
            }

            return output / (double)totalOccurencesCount + local;
        }

        private int[] GetCoords(string[] value)
        {
            int length = value.Length;

            int[] coords = new int[NgramSize];

            if (length == NgramSize)
            {
                coords[0] = dict.IndexOf(value[0]);
                coords[1] = dict.IndexOf(value[1]);
                coords[2] = dict.IndexOf(value[2]);
                coords[3] = dict.IndexOf(value[3]);
            }
            else
            {
                throw new Exception();
            }

            return coords;
        }
    }
}
