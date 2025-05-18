using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursing_Election
{
    internal class LabelCount
    {
        public static int positionsCount = 0;
        public static int candidatesCount = 0;
        private static ArrayList positionTitles = new ArrayList();
        private static ArrayList presidentCandidates = new ArrayList();
        private static ArrayList vicePresidentCandidates = new ArrayList();
        private static ArrayList secretaryCandidates = new ArrayList();
        private static ArrayList treasurerCandidates = new ArrayList();
        private static ArrayList auditorCandidates = new ArrayList();
        private static ArrayList publicRelationsCandidates = new ArrayList();
        private static ArrayList firstYearRepresentativeCandidates = new ArrayList();
        private static ArrayList secondYearRepresentativeCandidates = new ArrayList();
        private static ArrayList thirdYearRepresentativeCandidates = new ArrayList();
        private static ArrayList fourthYearRepresentativeCandidates = new ArrayList();
        private static ArrayList representativeCandidates = new ArrayList();
        private static ArrayList academicRepresentativeCandidates = new ArrayList();
        private static ArrayList caresRepresentativeCandidates = new ArrayList();

        public void SetPositionsCount(int count)
        {
            positionsCount = count;
        }
        public int GetPositionsCount() { return positionsCount; }
        public void SetCandidatesCount(int count)
        {
            candidatesCount = count;
        }
        public int GetCandidatesCount() { return candidatesCount; }

        public void SetPositionTitles(ArrayList titles)
        {
            positionTitles = titles;
        }
        public ArrayList GetPositionTitles()
        {
            return positionTitles;
        }
        public void SetPresidentCandidates(ArrayList candidates)
        {
            presidentCandidates = candidates;
        }
        public ArrayList GetPresidentCandidates()
        {
            return presidentCandidates;
        }
        public void SetVicePresidentCandidates(ArrayList candidates)
        {
            vicePresidentCandidates = candidates;
        }
        public ArrayList GetVicePresidentCandidates()
        {
            return vicePresidentCandidates;
        }
        public void SetSecretaryCandidates(ArrayList candidates)
        {
            secretaryCandidates = candidates;
        }
        public ArrayList GetSecretaryCandidates()
        {
            return secretaryCandidates;
        }
        public void SetTreasurerCandidates(ArrayList candidates)
        {
            treasurerCandidates = candidates;
        }
        public ArrayList GetTreasurerCandidates()
        {
            return treasurerCandidates;
        }
        public void SetAuditorCandidates(ArrayList candidates)
        {
            auditorCandidates = candidates;
        }
        public ArrayList GetAuditorCandidates()
        {
            return auditorCandidates;
        }
        public void SetPublicRelationsCandidates(ArrayList candidates)
        {
            publicRelationsCandidates = candidates;
        }
        public ArrayList GetPublicRelationsCandidates()
        {
            return publicRelationsCandidates;
        }
        public void SetRepresentativeCandidates(ArrayList candidates)
        {
            representativeCandidates = candidates;
        }
        public ArrayList GetRepresentativeCandidates()
        {
            return representativeCandidates;
        }
        public void SetFirstYearRepresentativeCandidates(ArrayList candidates)
        {
            firstYearRepresentativeCandidates = candidates;
        }
        public ArrayList GetFirstYearRepresentativeCandidates()
        {
            return firstYearRepresentativeCandidates;
        }
        public void SetSecondYearRepresentativeCandidates(ArrayList candidates)
        {
            secondYearRepresentativeCandidates = candidates;
        }
        public ArrayList GetSecondYearRepresentativeCandidates()
        {
            return secondYearRepresentativeCandidates;
        }
        public void SetThirdYearRepresentativeCandidates(ArrayList candidates)
        {
            thirdYearRepresentativeCandidates = candidates;
        }
        public ArrayList GetThirdYearRepresentativeCandidates()
        {
            return thirdYearRepresentativeCandidates;
        }
        public void SetFourthYearRepresentativeCandidates(ArrayList candidates)
        {
            fourthYearRepresentativeCandidates = candidates;
        }
        public ArrayList GetFourthYearRepresentativeCandidates()
        {
            return fourthYearRepresentativeCandidates;
        }
        public void SetCaresRepresentativeCandidates(ArrayList candidates)
        {
            caresRepresentativeCandidates = candidates;
        }
        public ArrayList GetCaresRepresentativeCandidates()
        {
            return caresRepresentativeCandidates;
        }
        public void SetAcademicRepresentativeCandidates(ArrayList candidates)
        {
            academicRepresentativeCandidates = candidates;
        }
        public ArrayList GetAcademicRepresentativeCandidates()
        {
            return academicRepresentativeCandidates;
        }


        public void ClearAll()
        {
            positionsCount = 0;
            candidatesCount = 0;
            positionTitles.Clear();
            presidentCandidates.Clear();
            vicePresidentCandidates.Clear();
            secretaryCandidates.Clear();
            treasurerCandidates.Clear();
            auditorCandidates.Clear();
            publicRelationsCandidates.Clear();
            representativeCandidates.Clear();
        }


    }
}
