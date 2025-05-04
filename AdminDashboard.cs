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
            positionPanel.Size = new Size(200, 120);
            positionPanel.BackColor = Color.LightBlue;
            positionPanel.Margin = new Padding(10);

            Label titleLabel = new Label();
            titleLabel.Text = positionTitle;
            titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Height = 30;

            Label descriptionLabel = new Label();
            descriptionLabel.Text = Convert.ToString(noOfCandidates);
            descriptionLabel.Font = new Font("Arial", 9, FontStyle.Regular);
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.TextAlign = ContentAlignment.TopCenter;
            descriptionLabel.Padding = new Padding(5);


            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Dock = DockStyle.Bottom;
            deleteButton.Height = 30;
            deleteButton.BackColor = Color.Red;
            deleteButton.ForeColor = Color.White;

            deleteButton.Click += (s, e) =>
            {
                flowLayoutPanel1.Controls.Remove(positionPanel);
                positionPanel.Dispose();
            };

            Button viewButton = new Button();
            viewButton.Text = "View Details";
            viewButton.Dock = DockStyle.Bottom;
            viewButton.Height = 30;
            viewButton.BackColor = Color.Red;
            viewButton.ForeColor = Color.White;

            viewButton.Click += (s, e) =>
            {
                MessageBox.Show($"Position: {positionTitle}\nDescription: {description}", "Position Details");
            };

            positionPanel.Controls.Add(viewButton);
            positionPanel.Controls.Add(deleteButton);
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
    }
}
