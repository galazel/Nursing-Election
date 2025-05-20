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
    public partial class VoterStatus : Form
    {
        private VotersInformation info;
        private bool logout = false;
        public VoterStatus(VotersInformation info)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ShowIcon = false;
            this.info = info;
        }

        private void VoterStatus_Load(object sender, EventArgs e)
        {
            lb_student_id.Text = info.StudentId.ToString();
            lb_name.Text = info.Name;
            lb_block_section.Text = $"BSN - {info.Level}{info.Block}";

            if (info.ProfileImage != null && info.ProfileImage.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(info.ProfileImage))
                {
                    pb_profile.Image = Image.FromStream(ms);
                }
            }
        }

        private void btn_ballot_preview_Click(object sender, EventArgs e)
        {
            new ViewPreview(info.StudentId);   
        }

        private void lb_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
            (
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                logout = true;  
                this.Close();
            }
        }
        public bool GetLogout()
            { return logout; }

        public int GetStudetnId()
        {
            return info.StudentId;
        }


        private void btn_result_Click(object sender, EventArgs e)
        {
            StartElectionClass start = new StartElectionClass();
            if (start.IsElectionFinished())
            {
                MessageBox.Show("Election is finished.");
                ViewResultClass viewResultClass = new ViewResultClass();
                viewResultClass.ShowElectionResults();
            }
            else
            {
                MessageBox.Show("Election is not finished yet.");
            }
        }
    }
}
