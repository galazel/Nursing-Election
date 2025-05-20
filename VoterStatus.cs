using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using System.Windows.Forms;
using System.Xml.Linq;

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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            EditLevelBlock editLevelBlock = new EditLevelBlock(info.Level, info.Block); 
            DialogResult result = editLevelBlock.ShowDialog();

            if (result == DialogResult.OK)
            {
                int level = editLevelBlock.GetLevel();
                string block = editLevelBlock.GetBlock();

                if (level == 0 || string.IsNullOrEmpty(block))
                {
                    MessageBox.Show("Please fill in both level and block.");
                    return;
                }

                string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Voters SET level = @level, block = @block WHERE student_id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@level", level);
                        command.Parameters.AddWithValue("@block", block);
                        command.Parameters.AddWithValue("@id", info.StudentId);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Voter section updated successfully.");
                                info.Level = level;
                                info.Block = block;
                                lb_block_section.Text = $"BSN - {info.Level}{info.Block.ToUpper()}";
                            }
                            else
                            {
                                MessageBox.Show("No changes were made.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Database error: " + ex.Message);
                        }
                    }
                }
            }
        }




    }
}
