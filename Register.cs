using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class Register : Form
    {
        private string selectedImagePath = "";

        public Register()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_student_id.Text, out int student_id))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            string name = tb_name.Text.Trim();
            string email = tb_email.Text.Trim();
            string block = tb_block.Text.Trim().ToUpper();

            if (!int.TryParse(cb_level.Text, out int level))
            {
                MessageBox.Show("Please select a valid level.");
                return;
            }

            if (student_id == 0 || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(block))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath) || !File.Exists(selectedImagePath))
            {
                MessageBox.Show("Please upload a valid image.");
                return;
            }

            byte[] imageData;
            try
            {
                imageData = File.ReadAllBytes(selectedImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading image: " + ex.Message);
                return;
            }

            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Voters WHERE student_id = @student_id OR email = @email";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@student_id", student_id);
                    checkCommand.Parameters.AddWithValue("@email", email);

                    int exists = (int)checkCommand.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("A voter with this Student ID or Email already exists.");
                        ClearFormFields();
                        return;
                    }
                    string insertQuery = @"INSERT INTO Voters (name, student_id, level, block, email, profile)
                                           VALUES (@name, @student_id, @level, @block, @email, @profile)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@name", name);
                    insertCommand.Parameters.AddWithValue("@student_id", student_id);
                    insertCommand.Parameters.AddWithValue("@level", level);
                    insertCommand.Parameters.AddWithValue("@block", block);
                    insertCommand.Parameters.AddWithValue("@email", email);
                    insertCommand.Parameters.AddWithValue("@profile", imageData);

                    insertCommand.ExecuteNonQuery();


                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            StartElectionClass startElectionClass = new StartElectionClass();
            startElectionClass.SetNoOfVoters(startElectionClass.GetNoOfVoters() + 1);
            MessageBox.Show("Registration successful!");
            new Login().Show();
            this.Close();
        }

        private void ClearFormFields()
        {
            tb_student_id.Clear();
            tb_name.Clear();
            tb_email.Clear();
            tb_block.Clear();
            cb_level.SelectedIndex = -1;
            lb_image.Text = "";
            selectedImagePath = "";
        }

        private void btn_upload_photo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    lb_image.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        private void tb_student_id_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
