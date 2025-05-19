using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class ChooseCandidate : Form
    {
        private ArrayList choices = new ArrayList();
        private string selectedCandidate;
        public ChooseCandidate()
        {
            InitializeComponent();
            LabelCount labelCount = new LabelCount();   

        }
        public void SetChoices(ArrayList choices)
        {
            this.choices = choices;
            cb_choose_candidate.Items.Clear();
            foreach (string choice in choices)
            {
                cb_choose_candidate.Items.Add(choice);
            }

        }
        public string GetSelectedCandidate()
        {
            if (cb_choose_candidate.SelectedItem != null)
            {
                return selectedCandidate;
            }
            else
            {
                return null;
            }
        }
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (cb_choose_candidate.SelectedItem == null)
            {
                MessageBox.Show("Please select a candidate.");
            }
            else
            {
                selectedCandidate = cb_choose_candidate.SelectedItem.ToString();
                Close();
            }
        }


        private void cb_choose_candidate_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCandidate = cb_choose_candidate.SelectedItem.ToString();
        }
    }
}
