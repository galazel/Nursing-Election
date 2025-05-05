using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class AddCandidate : Form
    {
        private string name, motto;
        private int studentId;
        private Image candidateImage;

        public AddCandidate()
        {
            InitializeComponent();
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetMotto(string motto)
        {
            this.motto = motto;
        }

        public void SetStudentId(int studentId)
        {
            this.studentId = studentId;
        }
        public string GetName()
        {
            return name;
        }

        public string GetMotto()
        {
            return motto;
        }

        public int GetStudentId()
        {
            return studentId;
        }

        public Image GetCandidateImage()
        {
            return candidateImage;
        }

        private void tb_student_id_candidate_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Candidate Image";
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                candidateImage = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = candidateImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btn_profile_candidate_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_confirm_candidate_Click(object sender, EventArgs e)
        {
            name = tb_name_candidate.Text.Trim();
            motto = tb_candidate_motto.Text.Trim();

            if (int.TryParse(tb_student_id_candidate.Text, out int id))
            {
                studentId = id;
            }
            else
            {
                MessageBox.Show("Invalid Student ID");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || candidateImage == null)
            {
                MessageBox.Show("Please complete all fields and upload a picture.");
                return;
            }

            this.Close();
        }
    }
}
