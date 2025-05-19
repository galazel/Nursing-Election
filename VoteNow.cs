using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class VoteNow : Form
    {
        Dictionary<string, List<string>> candidatesPerPosition = new Dictionary<string, List<string>>();

        private string pressCandidate, viceCandidate, secCandidate, treasurerCandidate, auditorCandidate;
        private string firstRep, secondRep, thirdRep, fourthRep, acadRep, caresRep, pioCandidate;
        private int student_id;

        public VoteNow(int student_id)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ShowIcon = false;

            string filePathPositions = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
            string filePathCandidates = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";

            if (File.Exists(filePathPositions) && File.Exists(filePathCandidates))
            {
                try
                {
                    string[] positionLines = File.ReadAllLines(filePathPositions).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                    List<string> positions = new List<string>();
                    for (int i = 0; i < positionLines.Length; i += 2)
                    {
                        if (i + 1 < positionLines.Length)
                        {
                            string title = positionLines[i].Trim();
                            positions.Add(title);
                        }
                    }

                    string[] candidateLines = File.ReadAllLines(filePathCandidates).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                    for (int i = 0; i < candidateLines.Length; i += 5)
                    {
                        if (i + 4 < candidateLines.Length)
                        {
                            string candidateName = candidateLines[i].Trim();
                            string position = candidateLines[i + 4].Trim();

                            if (!candidatesPerPosition.ContainsKey(position))
                                candidatesPerPosition[position] = new List<string>();
                            candidatesPerPosition[position].Add(candidateName);
                        }
                    }

                    foreach (string position in positions)
                    {
                        List<string> candidates = candidatesPerPosition.ContainsKey(position) ? candidatesPerPosition[position] : new List<string>();
                        AddPositionPanel(position, candidates);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            this.student_id = student_id;
        }

        private void AddPositionPanel(string positionName, List<string> candidates)
        {
            Panel panel = new Panel();
            panel.Size = new Size(fp_vote.Width - 30, 100);
            panel.BackColor = Color.White;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblPosition = new Label();
            lblPosition.Text = positionName.ToUpper();
            lblPosition.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPosition.ForeColor = Color.Black;
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(10, 10);

            Button btnChoose = new Button();
            btnChoose.Text = "Choose";
            btnChoose.Size = new Size(80, 30);
            btnChoose.BackColor = Color.LightBlue;
            btnChoose.FlatStyle = FlatStyle.Flat;
            btnChoose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChoose.Location = new Point(panel.Width - btnChoose.Width - 20, 10);

            Label lblChosen = new Label();
            lblChosen.Text = "Chosen: None";
            lblChosen.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblChosen.AutoSize = true;
            lblChosen.Location = new Point(10, 50);

            string selected = null;
            btnChoose.Click += (s, e) =>
            {

                ChooseCandidate chooseCandidate = new ChooseCandidate();
                chooseCandidate.Show();

                LabelCount labelCount = new LabelCount();
                if (positionName.Equals("PRESIDENT"))
                    chooseCandidate.SetChoices(labelCount.GetPresidentCandidates());
                else if (positionName.Equals("VICE PRESIDENT"))
                    chooseCandidate.SetChoices(labelCount.GetVicePresidentCandidates());
                else if (positionName.Equals("SECRETARY"))
                    chooseCandidate.SetChoices(labelCount.GetSecretaryCandidates());
                else if (positionName.Equals("TREASURER"))
                    chooseCandidate.SetChoices(labelCount.GetTreasurerCandidates());
                else if (positionName.Equals("AUDITOR"))
                    chooseCandidate.SetChoices(labelCount.GetAuditorCandidates());
                else if (positionName.Equals("FIRST YEAR REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetFirstYearRepresentativeCandidates());
                else if (positionName.Equals("SECOND YEAR REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetSecondYearRepresentativeCandidates());
                else if (positionName.Equals("THIRD YEAR REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetThirdYearRepresentativeCandidates());
                else if (positionName.Equals("FOURTH YEAR REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetFourthYearRepresentativeCandidates());
                else if (positionName.Equals("ACADEMIC REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetAcademicRepresentativeCandidates());
                else if (positionName.Equals("CARES REPRESENTATIVE"))
                    chooseCandidate.SetChoices(labelCount.GetCaresRepresentativeCandidates());
                else if (positionName.Equals("PUBLIC RELATIONS OFFICER"))
                    chooseCandidate.SetChoices(labelCount.GetPublicRelationsCandidates());

                if (chooseCandidate.ShowDialog() == DialogResult.OK)
                {
                    selected = chooseCandidate.GetSelectedCandidate();
                    lblChosen.Text = "Chosen: " + selected;

                    if (positionName.Equals("PRESIDENT"))
                        pressCandidate = selected;
                    else if (positionName.Equals("VICE PRESIDENT"))
                        viceCandidate = selected;
                    else if (positionName.Equals("SECRETARY"))
                        secCandidate = selected;
                    else if (positionName.Equals("TREASURER"))
                        treasurerCandidate = selected;
                    else if (positionName.Equals("AUDITOR"))
                        auditorCandidate = selected;
                    else if (positionName.Equals("FIRST YEAR REPRESENTATIVE"))
                        firstRep = selected;
                    else if (positionName.Equals("SECOND YEAR REPRESENTATIVE"))
                        secondRep = selected;
                    else if (positionName.Equals("THIRD YEAR REPRESENTATIVE"))
                        thirdRep = selected;
                    else if (positionName.Equals("FOURTH YEAR REPRESENTATIVE"))
                        fourthRep = selected;
                    else if (positionName.Equals("ACADEMIC REPRESENTATIVE"))
                        acadRep = selected;
                    else if (positionName.Equals("CARES REPRESENTATIVE"))
                        caresRep = selected;
                    else if (positionName.Equals("PIO"))
                        pioCandidate = selected;
                }
            
            };
            panel.Controls.Add(lblPosition);
            panel.Controls.Add(btnChoose);
            panel.Controls.Add(lblChosen);
            fp_vote.Controls.Add(panel);
        }

        private void btn_vote_now_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(pressCandidate) ||
                string.IsNullOrEmpty(viceCandidate) ||
                string.IsNullOrEmpty(secCandidate) ||
                string.IsNullOrEmpty(treasurerCandidate) ||
                string.IsNullOrEmpty(auditorCandidate) ||
                string.IsNullOrEmpty(firstRep) ||
                string.IsNullOrEmpty(secondRep) ||
                string.IsNullOrEmpty(thirdRep) ||
                string.IsNullOrEmpty(fourthRep) ||
                string.IsNullOrEmpty(acadRep) ||
                string.IsNullOrEmpty(caresRep) ||
                string.IsNullOrEmpty(pioCandidate))
            {
                MessageBox.Show("Please make sure all positions are selected before voting.");
                return;
            }

            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = @"INSERT INTO CandidatesChoice 
(president, vice, secretary, treasurer, auditor, first_rep, second_rep, third_rep, fourth_rep, acad_rep, cares_rep, pio, student_id)
VALUES 
(@president, @vice, @secretary, @treasurer, @auditor, @firstRep, @secondRep, @thirdRep, @fourthRep, @acadRep, @caresRep, @pio, @student_id)";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@president", pressCandidate);
                    cmd.Parameters.AddWithValue("@vice", viceCandidate);
                    cmd.Parameters.AddWithValue("@secretary", secCandidate);
                    cmd.Parameters.AddWithValue("@treasurer", treasurerCandidate);
                    cmd.Parameters.AddWithValue("@auditor", auditorCandidate);
                    cmd.Parameters.AddWithValue("@firstRep", firstRep);
                    cmd.Parameters.AddWithValue("@secondRep", secondRep);
                    cmd.Parameters.AddWithValue("@thirdRep", thirdRep);
                    cmd.Parameters.AddWithValue("@fourthRep", fourthRep);
                    cmd.Parameters.AddWithValue("@acadRep", acadRep);
                    cmd.Parameters.AddWithValue("@caresRep", caresRep);
                    cmd.Parameters.AddWithValue("@pio", pioCandidate);
                    cmd.Parameters.AddWithValue("@student_id", student_id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You have successfully voted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            StartElectionClass start = new StartElectionClass();
            start.SetNoOfVotersVoted(start.GetNoOfVotersVoted() + 1);

            this.Close();
        }

        private void VoteNow_Load(object sender, EventArgs e) { }

        private void fp_vote_Paint(object sender, PaintEventArgs e) { }
    }
}
