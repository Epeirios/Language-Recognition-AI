using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Recognition_AI
{
    public interface IProgress
    {
        event EventHandler<EventArgsProgress> EventProgress;
    }
}
