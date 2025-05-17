using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class AdminDashboard : Form
    {
        private AddPostion position = new AddPostion();
        private AddCandidate candidate = new AddCandidate();
        private ArrayList positionTitles = new ArrayList();
        private ArrayList presidentCandidates = new ArrayList();
        private ArrayList vicePresidentCandidates = new ArrayList();
        private ArrayList secretaryCandidates = new ArrayList();
        private ArrayList treasurerCandidates = new ArrayList();
        private ArrayList auditorCandidates = new ArrayList();
        private ArrayList publicRelationsCandidates = new ArrayList();
        private ArrayList representativeCandidates = new ArrayList();
        private DateTime startTime;
        private DateTime endTime;

        public AdminDashboard()
        {
            InitializeComponent();
            lb_timer.Visible = false;
            lb_end_timer.Visible = false;
            timer1.Enabled = false;
            btn_end_election.Enabled = false;

            string filePathPositions = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
            string filePathCandidates = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";


            if (filePathPositions.Length > 0)
            {
                LabelCount labelCount = new LabelCount();
                lb_no_of_positions.Text = labelCount.GetPositionsCount().ToString();
                lb_no_of_candidates.Text = labelCount.GetCandidatesCount().ToString();

                try
                {
                    FileInfo filePositions = new FileInfo(filePathPositions);
                    if (filePositions.Exists && filePositions.Length > 0)
                    {
                        string[] lines1 = File.ReadAllLines(filePathPositions);
                        for (int i = 0; i < lines1.Length; i += 2)
                        {
                            if (i + 1 < lines1.Length)
                            {
                                string title = lines1[i].Trim();
                                string description = lines1[i + 1].Trim();
                                Console.WriteLine("Title: " + title);

                                positionTitles.Add(title);
                                AddPosition(title, description);
                            }
                        }
                    }

                    FileInfo fileCandidates = new FileInfo(filePathCandidates);
                    if (fileCandidates.Exists && fileCandidates.Length > 0)
                    {
                        string[] lines2 = File.ReadAllLines(filePathCandidates);
                        for (int i = 0; i < lines2.Length; i += 5)
                        {
                            if (i + 4 < lines2.Length)
                            {
                                string name = lines2[i].Trim();
                                string motto = lines2[i + 1].Trim();
                                int studentId = int.Parse(lines2[i + 2].Trim());
                                string imagePath = lines2[i + 3].Trim();
                                string positionTitle = lines2[i + 4].Trim();

                                if (File.Exists(imagePath))
                                {
                                    Image candidateImage = Image.FromFile(imagePath);
                                    AddCandidate(name, motto, studentId, candidateImage, positionTitle);
                                }
                                else
                                {
                                    MessageBox.Show("Image file not found: " + imagePath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file ff: " + ex.Message);
                }
            }


        }


        private void AddPosition(string positionTitle, string description)
        {
            Panel positionPanel = new Panel();
            positionPanel.Size = new Size(850, 100);
            positionPanel.BackColor = Color.WhiteSmoke;
            positionPanel.BorderStyle = BorderStyle.Fixed3D;
            positionPanel.Margin = new Padding(8);
            positionPanel.Padding = new Padding(10);

            Label titleLabel = new Label();
            titleLabel.Text = positionTitle.ToUpper();
            titleLabel.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 20);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = $"Role: {description}";
            descriptionLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            descriptionLabel.ForeColor = Color.DimGray;
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(20, 45);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point(700, 35);
            buttonPanel.Padding = new Padding(0);

            int btnWidth = 60;
            int btnHeight = 28;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Size = new Size(btnWidth, btnHeight);
            viewButton.Font = new Font("Segoe UI", 8);
            viewButton.Click += (s, e) =>
            {
                if (titleLabel.Text.Equals("PRESIDENT"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in presidentCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }

                    Console.WriteLine("Presidents: \n" + sb.ToString());
                    MessageBox.Show("President Candidates: \n" + sb.ToString(), "Candidates for President");
                }
                else if (titleLabel.Text.Equals("VICE PRESIDENT") || titleLabel.Text.Equals("VICE-PRESIDENT"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in vicePresidentCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }

                    MessageBox.Show("Vice President Candidates: \n" + sb.ToString(), "Candidates for Vice President");
                }
                else if (titleLabel.Text.Equals("SECRETARY"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in secretaryCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Secretary Candidates: \n" + sb.ToString(), "Candidates for Secretary");

                }
                else if (titleLabel.Text.Equals("TREASURER"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in treasurerCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Treasurer Candidates: \n" + sb.ToString(), "Candidates for Treasurer");
                }
                else if (titleLabel.Text.Equals("AUDITOR"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in auditorCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Auditor Candidates: \n" + sb.ToString(), "Candidates for Auditor");
                }
                else if (titleLabel.Text.Equals("PUBLIC RELATIONS OFFICER") || titleLabel.Text.Equals("PRO"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in publicRelationsCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Public Relations Officer Candidates: \n" + sb.ToString(), "Candidates for PRO");
                }
                else if (titleLabel.Text.EndsWith("REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in representativeCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                }

            };
            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(btnWidth, btnHeight);
            deleteButton.Font = new Font("Segoe UI", 8);
            deleteButton.Click += (s, e) =>
            {
                string removed = titleLabel.Text;
                string desc = description;
                positionTitles.Remove(removed);
                candidate.SetPositionTitles(positionTitles);
                flowLayoutPanel1.Controls.Remove(positionPanel);
                positionPanel.Dispose();
                position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                int noOfPositions = position.GetNoOfPositions();
                lb_no_of_positions.Text = noOfPositions.ToString();


                try
                {
                    string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    lines.RemoveAll(line => line.Equals(removed) || line.Equals(desc));
                    File.WriteAllLines(filePath, lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading or writing file: " + ex.Message);
                }



            };

            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(deleteButton);

            positionPanel.Controls.Add(titleLabel);
            positionPanel.Controls.Add(descriptionLabel);
            positionPanel.Controls.Add(buttonPanel);

            flowLayoutPanel1.Controls.Add(positionPanel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddPostion position1 = new AddPostion();
            position1.Show();


            position1.FormClosing += (s, args) =>
            {
                string positionTitle = position1.GetPositionTitle();
                string description = position1.GetDescription();

                if (string.IsNullOrEmpty(positionTitle) && string.IsNullOrEmpty(description))
                    return;

                foreach (string title in positionTitles)
                {
                    if (title.Equals(positionTitle))
                    {
                        position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                        MessageBox.Show("Position already exists.");
                        return;
                    }
                }
                String[] listOfPositoins =
                {
                    "PRESIDENT",
                    "VICE PRESIDENT",
                    "SECRETARY",
                    "TREASURER",
                    "AUDITOR",
                    "PUBLIC RELATIONS OFFICER",
                    "PRO",
                    "REPRESENTATIVE"
                };

                bool isValidPosition = false;
                for (int i = 0; i < listOfPositoins.Length; i++)
                {
                    if (positionTitle.ToUpper().Equals(listOfPositoins[i]) || positionTitle.ToUpper().EndsWith(listOfPositoins[i]))
                    {
                        isValidPosition = true;
                        break;
                    }
                }

                if (!isValidPosition)
                {
                    MessageBox.Show("Invalid position title. Please enter a valid position.");
                    position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                    return;
                }


                if (!string.IsNullOrEmpty(positionTitle) && !string.IsNullOrEmpty(description))
                {
                    AddPosition(positionTitle, description);
                    lb_no_of_positions.Text = position1.GetNoOfPositions().ToString();
                    positionTitles.Add(positionTitle.ToUpper());
                    candidate.SetPositionTitles(positionTitles);

                    try
                    {

                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt", true))
                        {
                            sw.WriteLine(positionTitle.ToUpper());
                            sw.WriteLine(description);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing to file: " + ex.Message);
                    }
                }
            };
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        public void AddCandidate(string name, string motto, int studentId, Image candidateImage, string positionTitle)
        {
            Panel candidatePanel = new Panel();
            candidatePanel.Size = new Size(850, 100);
            candidatePanel.BackColor = Color.White;
            candidatePanel.BorderStyle = BorderStyle.FixedSingle;
            candidatePanel.Margin = new Padding(8);
            candidatePanel.Padding = new Padding(10);

            candidatePanel.BackColor = Color.WhiteSmoke;
            candidatePanel.BorderStyle = BorderStyle.Fixed3D;

            PictureBox profilePicture = new PictureBox();
            profilePicture.Image = candidateImage;
            profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            profilePicture.Size = new Size(60, 60);
            profilePicture.Location = new Point(15, 20);
            profilePicture.BorderStyle = BorderStyle.FixedSingle;

            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            nameLabel.ForeColor = Color.Black;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(90, 20);

            Label idLabel = new Label();
            idLabel.Text = $"{studentId}";
            idLabel.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            idLabel.ForeColor = Color.DimGray;
            idLabel.AutoSize = true;
            idLabel.Location = new Point(90, 45);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point(700, 35);
            buttonPanel.Padding = new Padding(0);

            int btnWidth = 60;
            int btnHeight = 28;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Size = new Size(btnWidth, btnHeight);
            viewButton.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            viewButton.Click += (s, e) =>
            {
                MessageBox.Show($"Name: {name}\nMotto: {motto} \nStudent ID: {studentId}\nPosition: {positionTitle}", "Candidate Info");
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(btnWidth, btnHeight);
            deleteButton.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            deleteButton.Click += (s, e) =>
            {
                flowLayoutPanel2.Controls.Remove(candidatePanel);
                candidatePanel.Dispose();

                candidate.SetNoOfCandidates(candidate.GetNoOfCandidates() - 1);
                int noOfCandidates = candidate.GetNoOfCandidates();
                lb_no_of_candidates.Text = noOfCandidates.ToString();

                // Remove from position list
                string title = positionTitle.Trim().ToUpper();
                if (title == "PRESIDENT")
                    presidentCandidates.Remove(name);
                else if (title == "VICE PRESIDENT" || title == "VICE-PRESIDENT")
                    vicePresidentCandidates.Remove(name);
                else if (title == "SECRETARY")
                    secretaryCandidates.Remove(name);
                else if (title == "TREASURER")
                    treasurerCandidates.Remove(name);
                else if (title == "AUDITOR")
                    auditorCandidates.Remove(name);
                else if (title == "PUBLIC RELATIONS OFFICER" || title == "PRO")
                    publicRelationsCandidates.Remove(name);
                else if (title.EndsWith("REPRESENTATIVE"))
                    representativeCandidates.Remove(name);

                try
                {
                    string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    for (int i = 0; i <= lines.Count - 5; i++)
                    {
                        if (lines[i].Trim() == name.Trim() &&
                            lines[i + 1].Trim() == motto.Trim() &&
                            lines[i + 2].Trim() == studentId.ToString().Trim())
                        {
                            string imagePath = lines[i + 3].Trim();

                            if (File.Exists(imagePath))
                                File.Delete(imagePath);

                            lines.RemoveRange(i, 5);

                            if (i < lines.Count && string.IsNullOrWhiteSpace(lines[i]))
                                lines.RemoveAt(i);

                            File.WriteAllLines(filePath, lines);
                            return; // Exit once deleted
                        }
                    }

                    MessageBox.Show("Candidate not found in file.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting candidate data or image: " + ex.Message);
                }
            };


            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(deleteButton);

            candidatePanel.Controls.Add(profilePicture);
            candidatePanel.Controls.Add(nameLabel);
            candidatePanel.Controls.Add(idLabel);
            candidatePanel.Controls.Add(buttonPanel);

            flowLayoutPanel2.Controls.Add(candidatePanel);
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (position.GetNoOfPositions() == 0)
            {
                MessageBox.Show("Please add a position first.");
                return;
            }
            AddCandidate candidate1 = new AddCandidate();
            candidate1.Show();
            candidate1.FormClosing += (s, args) =>
            {
                string name = candidate1.GetName();
                string motto = candidate1.GetMotto();
                int studentId = candidate1.GetStudentId();
                Image candidateImage = candidate1.GetCandidateImage();

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(motto) && studentId == 0)
                    return;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(motto) && studentId > 0)
                {
                    AddCandidate(name, motto, studentId, candidateImage, candidate1.GetPositionTitle());
                    lb_no_of_candidates.Text = candidate1.GetNoOfCandidates().ToString();

                    string positionTitle = candidate1.GetPositionTitle();

                    if (positionTitle.ToUpper().Equals("PRESIDENT"))
                        presidentCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("VICE PRESIDENT") || name.Equals("VICE-PRESIDENT"))
                        vicePresidentCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("SECRETARY"))
                        secretaryCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("TREASURER"))
                        treasurerCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("AUDITOR"))
                        auditorCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("PUBLIC RELATIONS OFFICER") || name.Equals("PRO"))
                        publicRelationsCandidates.Add(name);
                    else if (positionTitle.ToUpper().EndsWith("REPRESENTATIVE"))
                        representativeCandidates.Add(name);

                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt", true))
                        {
                            sw.WriteLine(name);
                            sw.WriteLine(motto);
                            sw.WriteLine(studentId);

                            string imageFileName = $"{studentId}_{DateTime.Now.Ticks}.png";
                            string imagePath = Path.Combine("D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateImages", imageFileName);
                            candidateImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                            sw.WriteLine(imagePath);


                            sw.WriteLine(candidate1.GetPositionTitle());
                            sw.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing to file: sdf" + ex.Message);
                    }

                }
            };
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LabelCount labelCount = new LabelCount();
                labelCount.SetPositionsCount(position.GetNoOfPositions());
                labelCount.SetCandidatesCount(candidate.GetNoOfCandidates());
                new Login().Show();
                this.Hide();
            }
        }
        private void btn_start_election_Click_1(object sender, EventArgs e)
        {
            if (position.GetNoOfPositions() == 0)
            {
                MessageBox.Show("Please add a position first.");
                return;
            }
            else if (candidate.GetNoOfCandidates() == 0)
            {
                MessageBox.Show("Please add a candidate first.");
                return;
            }
            else if (candidate.GetNoOfCandidates() < 5)
            {
                MessageBox.Show("Candidates should atleast 20.");
                return;
            }

            StartElectionClass start = new StartElectionClass();
            start.SetElectionStarted(true);

            startTime = DateTime.Now;
            endTime = startTime.AddHours(24);

            lb_timer.Visible = true;
            lb_end_timer.Visible = true;

            lb_timer.Text = "Time Left: 24:00:00";
            lb_end_timer.Text = "End Time: " + endTime.ToString("hh:mm:ss tt");

            timer1.Start();
            btn_start_election.Enabled = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = endTime - DateTime.Now;

            if (remainingTime.TotalSeconds <= 0)
            {
                timer1.Stop();
                lb_timer.Text = "Election ended.";
                lb_end_timer.Text = "Ended at: " + DateTime.Now.ToString("hh:mm:ss tt");
            }
            else
            {
                lb_timer.Text = "Time Left: " + remainingTime.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
