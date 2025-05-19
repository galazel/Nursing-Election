using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    internal class StartElectionClass
    {
        public static bool isElectionStarted = false;
        public static bool isStartButtonClicked = false;
        public static bool isElectionFinished = false;
        public static int noOfVotersVoted = 0;
        public static int noOfVoters = 0;
        public static string choosenCandidate;
        public static bool reset = false;
        public static bool save = false;



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
        public void SetChoosenCandidate(string candidate)
        {
            choosenCandidate = candidate;
        }
        public string GetChoosenCandidate()
        {
            return choosenCandidate;
        }
        public void SetReset(bool r)
        {
            reset = r;
        }
        public bool IsReset()
        {
            return reset;
        }
        public void SetSave(bool s)
        {
            save = s;
        }
        public bool IsSave()
        {
            return save;
        }

        public void ResetElection()
        {
            isElectionStarted = false;
            isStartButtonClicked = false;
            isElectionFinished = false;
            noOfVotersVoted = 0;
            noOfVoters = 0;
            choosenCandidate = string.Empty;
            reset = true;
        }

        //public void SetViewResult(string pres, string vp, string sec, string trea, string aud, string pio, string first, string secr, string third, string fourth, string cares, string acad)
        //{
        //    ViewResultClass viewResultClass = new ViewResultClass();
        //    viewResultClass.SetPresident(pres);
        //    viewResultClass.SetVicePresident(vp);
        //    viewResultClass.SetSecretary(sec);
        //    viewResultClass.SetTreasurer(trea);
        //    viewResultClass.SetAuditor(aud);
        //    viewResultClass.SetPRO(pio);
        //    viewResultClass.SetFirstYearRep(first);
        //    viewResultClass.SetSecondYearRep(secr);
        //    viewResultClass.SetThirdYearRep(third);
        //    viewResultClass.SetFourthYearRep(fourth);
        //    viewResultClass.SetCaresRep(cares);
        //    viewResultClass.SetAcademicRep(acad);


        //}

        public void SetResult(string res)
        {
            ViewResultClass viewResultClass = new ViewResultClass();
            viewResultClass.SetResult(res);
        }

      

    }
}
