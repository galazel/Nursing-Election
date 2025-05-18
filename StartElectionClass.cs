using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursing_Election
{
    internal class StartElectionClass
    {
        public static bool isElectionStarted = false;

        public void SetElectionStarted(bool started)
        {
            isElectionStarted = started;
        }
        public bool IsElectionStarted()
        {
            return isElectionStarted;
        }
    }
}
