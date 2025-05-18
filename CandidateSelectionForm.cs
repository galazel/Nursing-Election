using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class CandidateSelectionForm : Form
    {
        public string SelectedCandidate { get; private set; }
        public CandidateSelectionForm(List<string> candidates)
        {
            InitializeComponent();
            this.Text = "Select Candidate";

            int y = 10;
            foreach (string name in candidates)
            {
                RadioButton rb = new RadioButton();
                rb.Text = name;
                rb.Location = new Point(10, y);
                rb.AutoSize = true;
                this.Controls.Add(rb);
                y += 30;
            }

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(10, y);
            btnOK.Click += (s, e) =>
            {
                var selected = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (selected != null)
                {
                    SelectedCandidate = selected.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a candidate.");
                }
            };

            this.Controls.Add(btnOK);
            this.Size = new Size(250, y + 70);
        }

        private void CandidateSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
