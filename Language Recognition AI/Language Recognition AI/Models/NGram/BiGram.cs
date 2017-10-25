using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class BiGram : NGram
    {
        public override int NgramSize
        {
            get
            {
                return 2;
            }
        }

        public BiGram() : base()
        {

        }
    }
}
