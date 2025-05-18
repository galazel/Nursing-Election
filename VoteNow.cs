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
    public partial class VoteNow : Form
    {
        Dictionary<string, List<string>> candidatesPerPosition = new Dictionary<string, List<string>>();
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);

        public VoteNow()
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
            btnChoose.Location = new Point(panel.Width - btnChoose.Width - 20, 10); // Right side, aligned with lblPosition


            Label lblChosen = new Label();
            lblChosen.Text = "Chosen: None";
            lblChosen.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblChosen.AutoSize = true;
            lblChosen.Location = new Point(10, 50);

            btnChoose.Click += (s, e) =>
            {
                using (var form = new CandidateSelectionForm(candidates))
                {
                    form.StartPosition = FormStartPosition.CenterParent; // Center the form on parent
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        lblChosen.Text = "Chosen: " + form.SelectedCandidate;
                    }
                }
            };

            panel.Controls.Add(lblPosition);
            panel.Controls.Add(btnChoose);
            panel.Controls.Add(lblChosen);

            fp_vote.Controls.Add(panel);
        }




        private void fp_vote_Paint(object sender, PaintEventArgs e)
        {
        }

        private void VoteNow_Load(object sender, EventArgs e)
        {

        }
    }
}
