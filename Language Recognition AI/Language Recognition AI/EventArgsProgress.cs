using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public class EventArgsProgress : EventArgs
    {
        private int progress;

        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
            }
        }

        public EventArgsProgress(int progress)
        {
            this.progress = progress;
        }
    }
}
