using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class QuadGram : NGram
    {
        public override int NgramSize
        {
            get
            {
                return 4;
            }
        }
    }
}
