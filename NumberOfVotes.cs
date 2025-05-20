using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nursing_Election
{
    internal class NumberOfVotes
    {
        private Dictionary<string, string[,]> voteData = new Dictionary<string, string[,]>();

        private readonly string[] positions = {
            "president",
            "vice",
            "secretary",
            "treasurer",
            "auditor",
            "pio",
            "first_rep",
            "second_rep",
            "third_rep",
            "fourth_rep",
            "acad_rep",
            "cares_rep"
        };

        public NumberOfVotes()
        {
            LabelCount labelCount = new LabelCount();

            voteData["president"] = new string[labelCount.GetPresidentCandidates().Count, 2];
            voteData["vice"] = new string[labelCount.GetVicePresidentCandidates().Count, 2];
            voteData["secretary"] = new string[labelCount.GetSecretaryCandidates().Count, 2];
            voteData["treasurer"] = new string[labelCount.GetTreasurerCandidates().Count, 2];
            voteData["auditor"] = new string[labelCount.GetAuditorCandidates().Count, 2];
            voteData["pio"] = new string[labelCount.GetPublicRelationsCandidates().Count, 2];
            voteData["first_rep"] = new string[labelCount.GetFirstYearRepresentativeCandidates().Count, 2];
            voteData["second_rep"] = new string[labelCount.GetSecondYearRepresentativeCandidates().Count, 2];
            voteData["third_rep"] = new string[labelCount.GetThirdYearRepresentativeCandidates().Count, 2];
            voteData["fourth_rep"] = new string[labelCount.GetFourthYearRepresentativeCandidates().Count, 2];
            voteData["acad_rep"] = new string[labelCount.GetAcademicRepresentativeCandidates().Count, 2];
            voteData["cares_rep"] = new string[labelCount.GetCaresRepresentativeCandidates().Count, 2];

            CountVotes();
        }

        private void CountVotes()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (string position in positions)
                    {
                        string query = $@"
                            SELECT {position} AS Candidate, COUNT(*) AS Votes
                            FROM CandidatesChoice
                            WHERE {position} IS NOT NULL
                            GROUP BY {position}
                            ORDER BY Votes DESC";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read() && i < voteData[position].GetLength(0))
                            {
                                voteData[position][i, 0] = reader["Candidate"].ToString();
                                voteData[position][i, 1] = reader["Votes"].ToString();
                                i++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error counting votes: " + ex.Message);
                }
            }
        }
        public string[,] GetVotesByPosition(string position)
        {
            if (voteData.ContainsKey(position))
                return voteData[position];
            return new string[0, 0];
        }

        public string[,] GetPresidentVotes() => GetVotesByPosition("president");
        public string[,] GetVicePresidentVotes() => GetVotesByPosition("vice");
        public string[,] GetSecretaryVotes() => GetVotesByPosition("secretary");
        public string[,] GetTreasurerVotes() => GetVotesByPosition("treasurer");
        public string[,] GetAuditorVotes() => GetVotesByPosition("auditor");
        public string[,] GetPIOVotes() => GetVotesByPosition("pio");
        public string[,] GetFirstYearRepVotes() => GetVotesByPosition("first_rep");
        public string[,] GetSecondYearRepVotes() => GetVotesByPosition("second_rep");
        public string[,] GetThirdYearRepVotes() => GetVotesByPosition("third_rep");
        public string[,] GetFourthYearRepVotes() => GetVotesByPosition("fourth_rep");
        public string[,] GetAcademicRepVotes() => GetVotesByPosition("acad_rep");
        public string[,] GetCaresRepVotes() => GetVotesByPosition("cares_rep");
    }
}