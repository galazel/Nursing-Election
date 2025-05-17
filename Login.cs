using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class Login : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public Login()
        {
            InitializeComponent();
            SendMessage(tb_student_id.Handle, EM_SETCUEBANNER, 0, "22203624");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string id = tb_student_id.Text;

            foreach (char c in id)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Please enter a valid student ID.");
                    tb_student_id.Clear();
                    return;
                }
            }
            if (id.Length != 8)
            {
                MessageBox.Show("Student ID must be 8 digits long.");
                tb_student_id.Clear();
                return;
            }

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Student ID cannot be empty.");
                tb_student_id.Clear();
                return;
            }

            if(string.Equals(id, "11111111"))
            {
                form_admin_dashboard admin = new form_admin_dashboard();
                admin.Show();
                this.Hide();
                return;
            }



            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Voters WHERE student_id = @student_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@student_id", id);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successfully!");
                        string detailsQuery = "SELECT name, student_id, level, block, email, profile FROM Voters WHERE student_id = @student_id";
                        SqlCommand detailsCommand = new SqlCommand(detailsQuery, connection);
                        detailsCommand.Parameters.AddWithValue("@student_id", id);
                        SqlDataReader reader = detailsCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int student_Id = reader.GetInt32(1);
                            int level = reader.GetInt32(2);
                            string block = reader.GetString(3);
                            byte[] profile = (byte[])reader["profile"];

                            VotersInformation loggedInVoter = new VotersInformation(name, block, student_Id, level, profile);
                            DashboardVoter dashboard = new DashboardVoter();
                            dashboard.SetVoter(loggedInVoter);
                            dashboard.Show();
                          
                           
                            this.Hide();
                        }
                        reader.Close();
                    }

                    else
                    {
                        MessageBox.Show("Student ID not found. Please register first.");
                        tb_student_id.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
