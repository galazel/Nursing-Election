using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nursing_Election
{
    public partial class DashboardVoter : Form
    {
        private VotersInformation currentVoter;
        StartElectionClass start = new StartElectionClass();
        public DashboardVoter()
        {
            InitializeComponent();
            
            if (start.IsElectionStarted())
            {
                btn_vote_now.BackColor = Color.Green;
                btn_vote_now.Text = "VOTING IN PROGRESS";
                btn_vote_now.Enabled = true;
            }
            else if (start.IsElectionFinished())
            {
                btn_vote_now.BackColor = Color.Gray;
                btn_vote_now.Text = "ELECTION WAS ENDED";
            }
            else
            {
                btn_vote_now.BackColor = Color.Red;
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
            if (currentVoter == null)
            {
                MessageBox.Show("Voter information not loaded.");
                return;
            }

            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM CandidatesChoice WHERE student_id = @student_id";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@student_id", currentVoter.StudentId);

                    int exists = (int)checkCommand.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("You already voted.");
                        btn_vote_now.Text = "VOTED";
                        btn_vote_now.BackColor = Color.Gray;
                        btn_vote_now.Enabled = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }
            }
            VoteNow vote = new VoteNow(currentVoter.StudentId);
            vote.Show();
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
