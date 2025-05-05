using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class AdminDashboard : Form
    {
        private int noOfCandidates = 0; 
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AddPosition(string positionTitle, string description)
        {
            Panel positionPanel = new Panel();
            positionPanel.Size = new Size(250, 200);
            positionPanel.BackColor = Color.White;
            positionPanel.Margin = new Padding(10);
            positionPanel.BorderStyle = BorderStyle.FixedSingle;
            positionPanel.Padding = new Padding(10);

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
            titleLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Height = 30;

            Label descriptionLabel = new Label();
            descriptionLabel.Text = description;
            descriptionLabel.Tag = description;
            descriptionLabel.Font = new Font("Segoe UI", 9);
            descriptionLabel.ForeColor = Color.Gray;
            descriptionLabel.Dock = DockStyle.Top;
            descriptionLabel.TextAlign = ContentAlignment.TopLeft;
            descriptionLabel.Padding = new Padding(5);
            descriptionLabel.Height = 50;

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 40;
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.Padding = new Padding(5);
            buttonPanel.BackColor = Color.White;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Width = 60;
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
            updateButton.Width = 60;
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
            deleteButton.Width = 60;
            deleteButton.Click += (s, e) =>
            {
                flowLayoutPanel1.Controls.Remove(positionPanel);
                positionPanel.Dispose();
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
            AddPostion position = new AddPostion();
            position.Show();
            position.FormClosing += (s, args) =>
            {
                string positionTitle = position.GetPositionTitle();
                string description = position.GetDescription();
                if (!string.IsNullOrEmpty(positionTitle) && !string.IsNullOrEmpty(description))
                {
                    AddPosition(positionTitle, description);
                }
            };
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
