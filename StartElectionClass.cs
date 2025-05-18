using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Nursing_Election
{
    internal class StartElectionClass
    {
        public static bool isElectionStarted = false;
        public static bool isStartButtonClicked = false;
        public static bool isElectionFinished = false;
        public static int noOfVotersVoted = 0;
        public static int noOfVoters = 0;

        public void SetElectionStarted(bool started)
        {
            isElectionStarted = started;
        }
        public bool IsElectionStarted()
        {
            return isElectionStarted;
        }
        public void SetStartButtonClicked(bool clicked)
        {
            isStartButtonClicked = clicked;
        }
        public bool IsStartButtonClicked()
        {
            return isStartButtonClicked;
        }
        
        public void SetElectionFinished(bool finished)
        {
            isElectionFinished = finished;
        }
        public bool IsElectionFinished()
        {
            return isElectionFinished;
        }
        public void SetNoOfVotersVoted(int noOfVoters)
        {
            noOfVotersVoted = noOfVoters;
        }
        public int GetNoOfVotersVoted()
        {
            return noOfVotersVoted;
        }
        public void SetNoOfVoters(int voter)
        {
            noOfVoters = voter;
        }
        public int GetNoOfVoters()
        {
            return noOfVoters;
        }


    }
}
