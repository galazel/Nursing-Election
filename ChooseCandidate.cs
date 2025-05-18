using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class ChooseCandidate : Form
    {

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

        public ChooseCandidate()
        {
            InitializeComponent();
            LabelCount labelCount = new LabelCount();   

        }
        
        public string GetSelectedCandidate()
        {
            if (cb_choose_candidate.SelectedItem != null)
            {
                return cb_choose_candidate.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }



    }
}
