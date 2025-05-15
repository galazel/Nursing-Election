using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class AdminDashboard : Form
    {
        private AddPostion position = new AddPostion();
        private AddCandidate candidate = new AddCandidate();
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AddPosition(string positionTitle, string description)
        {
            Panel positionPanel = new Panel();
            positionPanel.Size = new Size(200, 160);
            positionPanel.BackColor = Color.White;
            positionPanel.Margin = new Padding(10);
            positionPanel.BorderStyle = BorderStyle.FixedSingle;
            positionPanel.Padding = new Padding(5);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 10;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(positionPanel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(positionPanel.Width - radius, positionPanel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, positionPanel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            positionPanel.Region = new Region(path);

            Label titleLabel = new Label();
            titleLabel.Text = positionTitle;
            titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Height = 25;

            Label descriptionLabel = new Label();
            descriptionLabel.Text = description;
            descriptionLabel.Tag = description;
            descriptionLabel.Font = new Font("Segoe UI", 8);
            descriptionLabel.ForeColor = Color.Gray;
            descriptionLabel.Dock = DockStyle.Top;
            descriptionLabel.TextAlign = ContentAlignment.TopLeft;
            descriptionLabel.Padding = new Padding(3);
            descriptionLabel.Height = 40;

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 35;
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.Padding = new Padding(3);
            buttonPanel.BackColor = Color.White;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Width = 50;
            viewButton.Font = new Font("Segoe UI", 8);
            viewButton.Click += (s, e) =>
            {
                MessageBox.Show($"Position: {titleLabel.Text}\nDescription: {descriptionLabel.Tag}", "Position Details");
            };

            Button updateButton = new Button();
            updateButton.Text = "Edit";
            updateButton.BackColor = Color.Orange;
            updateButton.ForeColor = Color.White;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.Width = 50;
            updateButton.Font = new Font("Segoe UI", 8);
            updateButton.Click += (s, e) =>
            {
                AddPostion updateForm = new AddPostion();
                updateForm.SetPositionTitle(titleLabel.Text);
                updateForm.SetDescription(descriptionLabel.Tag.ToString());
                updateForm.Show();
                updateForm.FormClosing += (sender2, args2) =>
                {
                    string updatedTitle = updateForm.GetPositionTitle();
                    string updatedDescription = updateForm.GetDescription();
                    if (!string.IsNullOrEmpty(updatedTitle) && !string.IsNullOrEmpty(updatedDescription))
                    {
                        titleLabel.Text = updatedTitle;
                        descriptionLabel.Text = updatedDescription;
                        descriptionLabel.Tag = updatedDescription;
                    }
                };
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Width = 50;
            deleteButton.Font = new Font("Segoe UI", 8);
            deleteButton.Click += (s, e) =>
            {
                flowLayoutPanel1.Controls.Remove(positionPanel);
                positionPanel.Dispose();
                position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                int noOfPositions = position.GetNoOfPositions();
                lb_no_of_positions.Text = noOfPositions.ToString();

            };

            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(updateButton);
            buttonPanel.Controls.Add(deleteButton);

            positionPanel.Controls.Add(buttonPanel);
            positionPanel.Controls.Add(descriptionLabel);
            positionPanel.Controls.Add(titleLabel);

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
                if (!string.IsNullOrEmpty(positionTitle) && !string.IsNullOrEmpty(description))
                {
                    AddPosition(positionTitle, description);
                    lb_no_of_positions.Text = position1.GetNoOfPositions().ToString();
                }
            };
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        public void AddCandidate(string name, string motto, int studentId, Image candidateImage)
        {
            Panel candidatePanel = new Panel();
            candidatePanel.Size = new Size(850, 80); 
            candidatePanel.BackColor = Color.White;
            candidatePanel.BorderStyle = BorderStyle.FixedSingle;
            candidatePanel.Margin = new Padding(5);

            PictureBox profilePicture = new PictureBox();
            profilePicture.Image = candidateImage;
            profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            profilePicture.Size = new Size(50, 50); 
            profilePicture.Location = new Point(10, 15);

            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold); 
            nameLabel.ForeColor = Color.Black;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(70, 15);

            Label mottoLabel = new Label();
            mottoLabel.Text = motto;
            mottoLabel.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            mottoLabel.ForeColor = Color.Gray;
            mottoLabel.AutoSize = true;
            mottoLabel.Location = new Point(70, 35);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point(650, 25);
            buttonPanel.Padding = new Padding(0);

            int btnWidth = 55;
            int btnHeight = 25;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Size = new Size(btnWidth, btnHeight);
            viewButton.Font = new Font("Segoe UI", 7);
            viewButton.Click += (s, e) =>
            {
                MessageBox.Show($"Name: {name}\nMotto: {motto}", "Candidate Info");
            };

            Button editButton = new Button();
            editButton.Text = "Edit";
            editButton.BackColor = Color.Orange;
            editButton.ForeColor = Color.White;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Size = new Size(btnWidth, btnHeight);
            editButton.Font = new Font("Segoe UI", 7);
            editButton.Click += (s, e) =>
            {
                AddCandidate updateForm = new AddCandidate();
                updateForm.SetName(nameLabel.Text);
                updateForm.SetMotto(motto);
                updateForm.SetStudentId(studentId);
                updateForm.SetCandidateImage(profilePicture.Image);
                updateForm.Show();
                updateForm.FormClosing += (sender2, args2) =>
                {
                    string updatedName = updateForm.GetName();
                    string updatedMotto = updateForm.GetMotto();
                    int updatedId = updateForm.GetStudentId();
                    Image updatedImage = updateForm.GetCandidateImage();
                    if (!string.IsNullOrEmpty(updatedName) && !string.IsNullOrEmpty(updatedMotto) && updatedId > 0)
                    {
                        nameLabel.Text = updatedName;
                        mottoLabel.Text = updatedMotto;
                        profilePicture.Image = updatedImage;
                    }
                };
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(btnWidth, btnHeight);
            deleteButton.Font = new Font("Segoe UI", 7);
            deleteButton.Click += (s, e) =>
            {
                flowLayoutPanel2.Controls.Remove(candidatePanel);
                candidatePanel.Dispose();
                candidate.SetNoOfCandidates(candidate.GetNoOfCandidates() - 1);
                int noOfCandidates = candidate.GetNoOfCandidates();
                lb_no_of_candidates.Text = noOfCandidates.ToString();

            };

            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(editButton);
            buttonPanel.Controls.Add(deleteButton);

            candidatePanel.Controls.Add(profilePicture);
            candidatePanel.Controls.Add(nameLabel);
            candidatePanel.Controls.Add(mottoLabel);
            candidatePanel.Controls.Add(buttonPanel);

            flowLayoutPanel2.Controls.Add(candidatePanel);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddCandidate candidate1 = new AddCandidate();
            candidate1.Show();
            candidate1.FormClosing += (s, args) =>
            {
                string name = candidate1.GetName();
                string motto = candidate1.GetMotto();
                int studentId = candidate1.GetStudentId();
                Image candidateImage = candidate1.GetCandidateImage();
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(motto) && studentId > 0)
                {
                    AddCandidate(name, motto, studentId, candidateImage);
                    lb_no_of_candidates.Text = candidate1.GetNoOfCandidates().ToString();
                }
            };
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new Login().Show();
                this.Hide(); 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
