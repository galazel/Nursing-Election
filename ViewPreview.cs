using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class ViewPreview : Form
    {
        public ViewPreview(int student_id)
        {
            InitializeComponent();

            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM CandidatesChoice WHERE student_id = @student_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@student_id", student_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string president = reader["president"].ToString(); 
                            string vicePresident = reader["vice"].ToString();
                            string secretary = reader["secretary"].ToString();
                            string treasurer = reader["treasurer"].ToString();
                            string auditor = reader["auditor"].ToString();
                            string publicInformationOfficer = reader["pio"].ToString();
                            string firstRep = reader["first_rep"].ToString();
                            string secondRep = reader["second_rep"].ToString();
                            string thirdRep = reader["third_rep"].ToString();
                            string fourthRep = reader["fourth_rep"].ToString();
                            string caresRep = reader["cares_rep"].ToString();
                            string acadRep = reader["acad_rep"].ToString();

                            MessageBox.Show($"Voting Record:\n" +
                                $"President: {president}\n" +
                                $"Vice President: {vicePresident}\n" +
                                $"Secretary: {secretary}\n" +
                                $"Treasurer: {treasurer}\n" +
                                $"Auditor: {auditor}\n" +
                                $"Public Information Officer: {publicInformationOfficer}\n" +
                                $"First Representative: {firstRep}\n" +
                                $"Second Representative: {secondRep}\n" +
                                $"Third Representative: {thirdRep}\n" +
                                $"Fourth Representative: {fourthRep}\n" +
                                $"Cares Representative: {caresRep}\n" +
                                $"Academic Representative: {acadRep}");
                        }
                        else
                        {
                            MessageBox.Show("No voting record found for this student.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




    }
}
