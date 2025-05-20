using System;
using System.IO;
using System.Windows.Forms;

namespace Nursing_Election
{
    internal class ViewResultClass
    {
        private readonly string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\HistoryResults.txt";

        public void ShowElectionResults()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string results = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(results))
                    {
                        MessageBox.Show(results, "Election Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The results file is empty.", "Election Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No results found.", "Election Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
