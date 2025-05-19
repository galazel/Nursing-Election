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

        private string selectedPresident = "";
        private string selectedVicePresident = "";
        private string selectedSecretary = "";
        private string selectedTreasurer = "";
        private string selectedAuditor = "";
        private string selectedPublicRelations = "";
        private string selectedRepresentative = "";
        private string selectedFirstYearRepresentative = "";
        private string selectedSecondYearRepresentative = "";
        private string selectedThirdYearRepresentative = "";
        private string selectedFourthYearRepresentative = "";
        private string selectedCaresRepresentative = "";
        private string selectedAcademicRepresentative = "";


        public void SetSelectedPresident(string name)
        {
            selectedPresident = name;
        }
        public string GetSelectedPresident()
        {
            return selectedPresident;
        }
        public void SetSelectedVicePresident(string name)
        {
            selectedVicePresident = name;
        }
        public string GetSelectedVicePresident()
        {
            return selectedVicePresident;
        }

        public void SetSelectedSecretary(string name)
        {
            selectedSecretary = name;
        }
        public string GetSelectedSecretary()
        {
            return selectedSecretary;
        }
        public void SetSelectedTreasurer(string name)
        {
            selectedTreasurer = name;
        }
        public string GetSelectedTreasurer()
        {
            return selectedTreasurer;
        }
        public void SetSelectedAuditor(string name)
        {
            selectedAuditor = name;
        }
        public string GetSelectedAuditor()
        {
            return selectedAuditor;
        }
        public void SetSelectedPublicRelations(string name)
        {
            selectedPublicRelations = name;
        }
        public string GetSelectedPublicRelations()
        {
            return selectedPublicRelations;
        }
        public void SetSelectedRepresentative(string name)
        {
            selectedRepresentative = name;
        }
        public string GetSelectedRepresentative()
        {
            return selectedRepresentative;
        }
        public void SetSelectedFirstYearRepresentative(string name)
        {
            selectedFirstYearRepresentative = name;
        }
        public string GetSelectedFirstYearRepresentative()
        {
            return selectedFirstYearRepresentative;
        }

        public void SetSelectedSecondYearRepresentative(string name)
        {
            selectedSecondYearRepresentative = name;
        }
        public string GetSelectedSecondYearRepresentative()
        {
            return selectedSecondYearRepresentative;
        }
        public void SetSelectedThirdYearRepresentative(string name)
        {
            selectedThirdYearRepresentative = name;
        }
        public string GetSelectedThirdYearRepresentative()
        {
            return selectedThirdYearRepresentative;
        }

        public void SetSelectedFourthYearRepresentative(string name)
        {
            selectedFourthYearRepresentative = name;
        }
        public string GetSelectedFourthYearRepresentative()
        {
            return selectedFourthYearRepresentative;
        }
        public void SetSelectedCaresRepresentative(string name)
        {
            selectedCaresRepresentative = name;
        }
        public string GetSelectedCaresRepresentative()
        {
            return selectedCaresRepresentative;
        }
        public void SetSelectedAcademicRepresentative(string name)
        {
            selectedAcademicRepresentative = name;
        }
        public string GetSelectedAcademicRepresentative()
        {
            return selectedAcademicRepresentative;
        }



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
