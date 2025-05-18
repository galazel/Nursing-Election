using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class DashboardVoter : Form
    {
        private VotersInformation currentVoter;
        public DashboardVoter()
        {
            InitializeComponent();
            StartElectionClass start = new StartElectionClass();
            if (start.IsElectionStarted())
            {
                btn_vote_now.Text = "VOTING IN PROGRESS";
                btn_vote_now.Enabled = true;
            }
            else
            {
                btn_vote_now.Text = "ELECTION NOT STARTED";
                btn_vote_now.Enabled = false;
            }

        }

        public void SetVoter(VotersInformation votersInformation)
        {
            this.currentVoter = votersInformation;
        }
        private void btn_vote_now_Click(object sender, EventArgs e)
        {
            new VoteNow().Show();
        }   
        private void btn_show_status_Click(object sender, EventArgs e)
        {
            VoterStatus status = new VoterStatus(currentVoter);
            status.FormClosed += (s, args) =>
            {
                if (status.GetLogout())
                {
                    new Login().Show();
                    this.Close();
                }
            };
            status.Show();
        }

        private void DashboardVoter_Load(object sender, EventArgs e)
        {

        }
        
    }
}
