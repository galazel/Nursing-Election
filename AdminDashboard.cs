﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Web.Razor.Parser.SyntaxTree;
using System.Windows.Forms;
using System.Xml.Linq;
using Label = System.Windows.Forms.Label;

namespace Nursing_Election
{
    public partial class form_admin_dashboard : Form
    {
        private AddPostion position = new AddPostion();
        private AddCandidate candidate = new AddCandidate();
        private static ArrayList positionTitles = new ArrayList();
        private static ArrayList presidentCandidates = new ArrayList();
        private static ArrayList vicePresidentCandidates = new ArrayList();
        private static ArrayList secretaryCandidates = new ArrayList();
        private static ArrayList treasurerCandidates = new ArrayList();
        private static ArrayList auditorCandidates = new ArrayList();
        private static ArrayList publicRelationsCandidates = new ArrayList();
        private static ArrayList firstYearRepCandidates = new ArrayList();
        private static ArrayList secondYearRepCandidates = new ArrayList();
        private static ArrayList thirdYearRepCandidates = new ArrayList();
        private static ArrayList fourthYearRepCandidates = new ArrayList();
        private static ArrayList caresRepCandidates = new ArrayList();
        private static ArrayList academicrepresentativeCandidates = new ArrayList();
        private static ArrayList history = new ArrayList();
        public static string viewResult;

        NumberOfVotes numberOfVotes = new NumberOfVotes();
        string[,] presidentVotes;
        string[,] vicePresidentVotes;
        string[,] secretaryVotes;
        string[,] treasurerVotes;
        string[,] auditorVotes;
        string[,] publicRelationsVotes;
        string[,] firstYearRepVotes;
        string[,] secondYearRepVotes;
        string[,] thirdYearRepVotes;
        string[,] fourthYearRepVotes;
        string[,] caresRepVotes;
        string[,] academicRepresentativeVotes;

        public form_admin_dashboard()
        {
            InitializeComponent();
            btn_end_election.Enabled = false;
            string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string countQuery = "SELECT COUNT(*) FROM Voters";
                    SqlCommand countCommand = new SqlCommand(countQuery, connection);
                    int totalVoters = (int)countCommand.ExecuteScalar();

                    StartElectionClass startElectionClass = new StartElectionClass();
                    startElectionClass.SetNoOfVoters(totalVoters);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            string filePathPositions = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
            string filePathCandidates = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";
            string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\Count.txt";

            fp_pres.Controls.Clear();
            fp_vice.Controls.Clear();
            fp_sec.Controls.Clear();
            fp_treas.Controls.Clear();
            fp_auditor.Controls.Clear();
            fp_pio.Controls.Clear();
            fp_first.Controls.Clear();
            fp_second.Controls.Clear();
            fp_third.Controls.Clear();
            fp_fourth.Controls.Clear();
            fp_cares.Controls.Clear();
            fp_acad.Controls.Clear();

            StartElectionClass startElectionClass1 = new StartElectionClass();
            if (!startElectionClass1.IsElectionStarted())
            {
                SetPanelForResult();
            }
            else
            {
                fp_pres.Controls.Clear();
                fp_vice.Controls.Clear();
                fp_sec.Controls.Clear();
                fp_treas.Controls.Clear();
                fp_auditor.Controls.Clear();
                fp_pio.Controls.Clear();
                fp_first.Controls.Clear();
                fp_second.Controls.Clear();
                fp_third.Controls.Clear();
                fp_fourth.Controls.Clear();
                fp_cares.Controls.Clear();
                fp_acad.Controls.Clear();
            }


            if (startElectionClass1.IsStartButtonClicked())
            {
                fp_pres.Controls.Clear();
                fp_vice.Controls.Clear();
                fp_sec.Controls.Clear();
                fp_treas.Controls.Clear();
                fp_auditor.Controls.Clear();
                fp_pio.Controls.Clear();
                fp_first.Controls.Clear();
                fp_second.Controls.Clear();
                fp_third.Controls.Clear();
                fp_fourth.Controls.Clear();
                fp_cares.Controls.Clear();
                fp_acad.Controls.Clear();


                presidentVotes = numberOfVotes.GetPresidentVotes();
                vicePresidentVotes = numberOfVotes.GetVicePresidentVotes();
                secretaryVotes = numberOfVotes.GetSecretaryVotes();
                treasurerVotes = numberOfVotes.GetTreasurerVotes();
                auditorVotes = numberOfVotes.GetAuditorVotes();
                publicRelationsVotes = numberOfVotes.GetPIOVotes();
                firstYearRepVotes = numberOfVotes.GetFirstYearRepVotes();
                secondYearRepVotes = numberOfVotes.GetSecondYearRepVotes();
                thirdYearRepVotes = numberOfVotes.GetThirdYearRepVotes();
                fourthYearRepVotes = numberOfVotes.GetFourthYearRepVotes();
                caresRepVotes = numberOfVotes.GetAcademicRepVotes();
                academicRepresentativeVotes = numberOfVotes.GetCaresRepVotes();

                AddPanelOfVotes("PRESIDENT", presidentCandidates, presidentVotes);
                AddPanelOfVotes("VICE PRESIDENT", vicePresidentCandidates, vicePresidentVotes);
                AddPanelOfVotes("SECRETARY", secretaryCandidates, secretaryVotes);
                AddPanelOfVotes("TREASURER", treasurerCandidates, treasurerVotes);
                AddPanelOfVotes("AUDITOR", auditorCandidates, auditorVotes);
                AddPanelOfVotes("PUBLIC RELATIONS OFFICER", publicRelationsCandidates, publicRelationsVotes);
                AddPanelOfVotes("FIRST YEAR REPRESENTATIVE", firstYearRepCandidates, firstYearRepVotes);
                AddPanelOfVotes("SECOND YEAR REPRESENTATIVE", secondYearRepCandidates, secondYearRepVotes);
                AddPanelOfVotes("THIRD YEAR REPRESENTATIVE", thirdYearRepCandidates, thirdYearRepVotes);
                AddPanelOfVotes("FOURTH YEAR REPRESENTATIVE", fourthYearRepCandidates, fourthYearRepVotes);
                AddPanelOfVotes("CARES REPRESENTATIVE", caresRepCandidates, caresRepVotes);
                AddPanelOfVotes("ACADEMIC REPRESENTATIVE", academicrepresentativeCandidates, academicRepresentativeVotes);

                btn_start_election.Enabled = false;
                btn_end_election.Enabled = true;
            }

            if (startElectionClass1.IsElectionFinished())
            {
                string b = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
                string c = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";
                string d = "D:\\Glyzel's Files\\C#\\Nursing Election\\Count.txt";
                string e = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionAndCandidates.txt";

                File.WriteAllText(b, string.Empty);
                File.WriteAllText(c, string.Empty);
                File.WriteAllText(d, string.Empty);
                File.WriteAllText(e, string.Empty);

                LabelCount labelCount = new LabelCount();
                labelCount.ClearAll();

                positionTitles.Clear();
                history.Clear();

                presidentCandidates.Clear();
                vicePresidentCandidates.Clear();
                secretaryCandidates.Clear();
                treasurerCandidates.Clear();
                auditorCandidates.Clear();
                publicRelationsCandidates.Clear();
                firstYearRepCandidates.Clear();
                secondYearRepCandidates.Clear();
                thirdYearRepCandidates.Clear();
                fourthYearRepCandidates.Clear();
                caresRepCandidates.Clear();
                academicrepresentativeCandidates.Clear();


                presidentVotes = numberOfVotes.GetPresidentVotes();
                vicePresidentVotes = numberOfVotes.GetVicePresidentVotes();
                secretaryVotes = numberOfVotes.GetSecretaryVotes();
                treasurerVotes = numberOfVotes.GetTreasurerVotes();
                auditorVotes = numberOfVotes.GetAuditorVotes();
                publicRelationsVotes = numberOfVotes.GetPIOVotes();
                firstYearRepVotes = numberOfVotes.GetFirstYearRepVotes();
                secondYearRepVotes = numberOfVotes.GetSecondYearRepVotes();
                thirdYearRepVotes = numberOfVotes.GetThirdYearRepVotes();
                fourthYearRepVotes = numberOfVotes.GetFourthYearRepVotes();
                caresRepVotes = numberOfVotes.GetAcademicRepVotes();
                academicRepresentativeVotes = numberOfVotes.GetCaresRepVotes();

                position.SetNoOfPositions(0);
                candidate.SetNoOfCandidates(0);
                startElectionClass1.SetNoOfVoters(0);
                startElectionClass1.SetNoOfVotersVoted(0);
                startElectionClass1.SetStartButtonClicked(false);
                startElectionClass1.SetElectionFinished(false);
                startElectionClass1.SetElectionStarted(false);
                presidentVotes = new string[0, 0];
                vicePresidentVotes = new string[0, 0];
                secretaryVotes = new string[0, 0];
                treasurerVotes = new string[0, 0];
                auditorVotes = new string[0, 0];
                publicRelationsVotes = new string[0, 0];
                firstYearRepVotes = new string[0, 0];
                secondYearRepVotes = new string[0, 0];
                thirdYearRepVotes = new string[0, 0];
                fourthYearRepVotes = new string[0, 0];
                caresRepVotes = new string[0, 0];
                academicRepresentativeVotes = new string[0, 0];

                fp_pres.Controls.Clear();
                fp_vice.Controls.Clear();
                fp_sec.Controls.Clear();
                fp_treas.Controls.Clear();
                fp_auditor.Controls.Clear();
                fp_pio.Controls.Clear();
                fp_first.Controls.Clear();
                fp_second.Controls.Clear();
                fp_third.Controls.Clear();
                fp_fourth.Controls.Clear();
                fp_cares.Controls.Clear();
                fp_acad.Controls.Clear();

                SetPanelForResult();

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                btn_start_election.Enabled = true;
                btn_end_election.Enabled = false;
            }

            presidentVotes = numberOfVotes.GetPresidentVotes();
            vicePresidentVotes = numberOfVotes.GetVicePresidentVotes();
            secretaryVotes = numberOfVotes.GetSecretaryVotes();
            treasurerVotes = numberOfVotes.GetTreasurerVotes();
            auditorVotes = numberOfVotes.GetAuditorVotes();
            publicRelationsVotes = numberOfVotes.GetPIOVotes();
            firstYearRepVotes = numberOfVotes.GetFirstYearRepVotes();
            secondYearRepVotes = numberOfVotes.GetSecondYearRepVotes();
            thirdYearRepVotes = numberOfVotes.GetThirdYearRepVotes();
            fourthYearRepVotes = numberOfVotes.GetFourthYearRepVotes();
            caresRepVotes = numberOfVotes.GetAcademicRepVotes();
            academicRepresentativeVotes = numberOfVotes.GetCaresRepVotes();

            for (int i = 0; i < presidentVotes.GetLength(0); i++)
            {
                string name = presidentVotes[i, 0];
                string count = presidentVotes[i, 1];

                if (!string.IsNullOrEmpty(name))
                    Console.WriteLine($"{name} - {count} votes");
            }
           
            lb_no_voters_voted.Text = startElectionClass1.GetNoOfVotersVoted().ToString();
            lb_no_of_voters.Text = startElectionClass1.GetNoOfVoters().ToString();

            if (filePathPositions.Length > 0 || filePathCandidates.Length > 0 || filePath.Length > 0)
            {

                LabelCount labelCount = new LabelCount();
                try
                {
                    FileInfo countFile = new FileInfo(filePath);
                    if (countFile.Exists && countFile.Length > 0)
                    {
                        string[] lines = File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray(); ;
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (i == 0)
                            {
                                lb_no_of_positions.Text = lines[i];
                                labelCount.SetPositionsCount(int.Parse(lines[i]));
                                position.SetNoOfPositions(int.Parse(lines[i]));
                            }
                            else if (i == 1)
                            {
                                lb_no_of_candidates.Text = lines[i];
                                labelCount.SetCandidatesCount(int.Parse(lines[i]));
                                candidate.SetNoOfCandidates(int.Parse(lines[i]));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: where " + ex.Message);
                }

                positionTitles = labelCount.GetPositionTitles();
                presidentCandidates = labelCount.GetPresidentCandidates();
                vicePresidentCandidates = labelCount.GetVicePresidentCandidates();
                secretaryCandidates = labelCount.GetSecretaryCandidates();
                treasurerCandidates = labelCount.GetTreasurerCandidates();
                auditorCandidates = labelCount.GetAuditorCandidates();
                publicRelationsCandidates = labelCount.GetPublicRelationsCandidates();
                firstYearRepCandidates = labelCount.GetFirstYearRepresentativeCandidates();
                secondYearRepCandidates = labelCount.GetSecondYearRepresentativeCandidates();
                thirdYearRepCandidates = labelCount.GetThirdYearRepresentativeCandidates();
                fourthYearRepCandidates = labelCount.GetFourthYearRepresentativeCandidates();
                caresRepCandidates = labelCount.GetCaresRepresentativeCandidates();
                academicrepresentativeCandidates = labelCount.GetAcademicRepresentativeCandidates();



                try
                {
                    FileInfo filePositions = new FileInfo(filePathPositions);
                    if (filePositions.Exists && filePositions.Length > 0)
                    {
                        string[] lines1 = File.ReadAllLines(filePathPositions).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                        for (int i = 0; i < lines1.Length; i += 2)
                        {
                            if (i + 1 < lines1.Length)
                            {
                                string title = lines1[i].Trim();
                                string description = lines1[i + 1].Trim();
                                Console.WriteLine("Title: " + title);

                                positionTitles.Add(title);
                                AddPosition(title, description);
                            }
                        }
                    }

                    FileInfo fileCandidates = new FileInfo(filePathCandidates);
                    if (fileCandidates.Exists && fileCandidates.Length > 0)
                    {
                        string[] lines2 = File.ReadAllLines(filePathCandidates).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                        for (int i = 0; i < lines2.Length; i += 5)
                        {
                            if (i + 4 < lines2.Length)
                            {
                                string name = lines2[i].Trim();
                                string motto = lines2[i + 1].Trim();
                                int studentId = int.Parse(lines2[i + 2].Trim());
                                string imagePath = lines2[i + 3].Trim();
                                string positionTitle = lines2[i + 4].Trim();

                                if (File.Exists(imagePath))
                                {
                                    Image candidateImage = Image.FromFile(imagePath);
                                    AddCandidate(name, motto, studentId, candidateImage, positionTitle);
                                }
                                else
                                {
                                    MessageBox.Show("Image file not found: " + imagePath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file ff: " + ex.Message);
                }
            }

        }


        public void SetPanelForResult()
        {
            Label presidentResult = new Label();
            presidentResult.Text = "No President Yet.";
            presidentResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            presidentResult.ForeColor = Color.DimGray;
            presidentResult.AutoSize = true;
            presidentResult.Location = new Point(20, 20);
            fp_pres.Controls.Add(presidentResult);
            Label viceResult = new Label();
            viceResult.Text = "No Vice President Yet.";
            viceResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            viceResult.ForeColor = Color.DimGray;
            viceResult.AutoSize = true;
            viceResult.Location = new Point(20, 20);
            fp_vice.Controls.Add(viceResult);
            Label secretaryResult = new Label();
            secretaryResult.Text = "No Secretary Yet.";
            secretaryResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            secretaryResult.ForeColor = Color.DimGray;
            secretaryResult.AutoSize = true;
            secretaryResult.Location = new Point(20, 20);
            fp_sec.Controls.Add(secretaryResult);
            Label treasurerResult = new Label();
            treasurerResult.Text = "No Treasurer Yet.";
            treasurerResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            treasurerResult.ForeColor = Color.DimGray;
            treasurerResult.AutoSize = true;
            treasurerResult.Location = new Point(20, 20);
            fp_treas.Controls.Add(treasurerResult);
            Label auditorResult = new Label();
            auditorResult.Text = "No Auditor Yet.";
            auditorResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            auditorResult.ForeColor = Color.DimGray;
            auditorResult.AutoSize = true;
            auditorResult.Location = new Point(20, 20);
            fp_auditor.Controls.Add(auditorResult);
            Label pioResult = new Label();
            pioResult.Text = "No Public Relations Officer Yet.";
            pioResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            pioResult.ForeColor = Color.DimGray;
            pioResult.AutoSize = true;
            pioResult.Location = new Point(20, 20);
            fp_pio.Controls.Add(pioResult);
            Label firstResult = new Label();
            firstResult.Text = "No First Year Representative Yet.";
            firstResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            firstResult.ForeColor = Color.DimGray;
            firstResult.AutoSize = true;
            firstResult.Location = new Point(20, 20);
            fp_first.Controls.Add(firstResult);
            Label secondResult = new Label();
            secondResult.Text = "No Second Year Representative Yet.";
            secondResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            secondResult.ForeColor = Color.DimGray;
            secondResult.AutoSize = true;
            secondResult.Location = new Point(20, 20);
            fp_second.Controls.Add(secondResult);
            Label thirdResult = new Label();
            thirdResult.Text = "No Third Year Representative Yet.";
            thirdResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            thirdResult.ForeColor = Color.DimGray;
            thirdResult.AutoSize = true;
            thirdResult.Location = new Point(20, 20);
            fp_third.Controls.Add(thirdResult);
            Label fourthResult = new Label();
            fourthResult.Text = "No Fourth Year Representative Yet.";
            fourthResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            fourthResult.ForeColor = Color.DimGray;
            fourthResult.AutoSize = true;
            fourthResult.Location = new Point(20, 20);
            fp_fourth.Controls.Add(fourthResult);
            Label caresResult = new Label();
            caresResult.Text = "No Cares Representative Yet.";
            caresResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            caresResult.ForeColor = Color.DimGray;
            caresResult.AutoSize = true;
            caresResult.Location = new Point(20, 20);
            fp_cares.Controls.Add(caresResult);
            Label acadResult = new Label();
            acadResult.Text = "No Academic Representative Yet.";
            acadResult.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            acadResult.ForeColor = Color.DimGray;
            acadResult.AutoSize = true;
            acadResult.Location = new Point(20, 20);
            fp_acad.Controls.Add(acadResult);
        }

        private void AddPosition(string positionTitle, string description)
        {
            Panel positionPanel = new Panel();
            positionPanel.Size = new Size(850, 100);
            positionPanel.BackColor = Color.WhiteSmoke;
            positionPanel.BorderStyle = BorderStyle.Fixed3D;
            positionPanel.Margin = new Padding(8);
            positionPanel.Padding = new Padding(10);

            Label titleLabel = new Label();
            titleLabel.Text = positionTitle.ToUpper();
            titleLabel.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 20);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = $"Role: {description}";
            descriptionLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            descriptionLabel.ForeColor = Color.DimGray;
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(20, 45);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point(700, 35);
            buttonPanel.Padding = new Padding(0);

            int btnWidth = 60;
            int btnHeight = 28;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Size = new Size(btnWidth, btnHeight);
            viewButton.Font = new Font("Segoe UI", 8);
            viewButton.Click += (s, e) =>
            {


                if (titleLabel.Text.Equals("PRESIDENT"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in presidentCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }

                    Console.WriteLine("Presidents: \n" + sb.ToString());
                    MessageBox.Show("President Candidates: \n" + sb.ToString(), "Candidates for President");
                }
                else if (titleLabel.Text.Equals("VICE PRESIDENT") || titleLabel.Text.Equals("VICE-PRESIDENT"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in vicePresidentCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }

                    MessageBox.Show("Vice President Candidates: \n" + sb.ToString(), "Candidates for Vice President");
                }
                else if (titleLabel.Text.Equals("SECRETARY"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in secretaryCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Secretary Candidates: \n" + sb.ToString(), "Candidates for Secretary");

                }
                else if (titleLabel.Text.Equals("TREASURER"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in treasurerCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Treasurer Candidates: \n" + sb.ToString(), "Candidates for Treasurer");
                }
                else if (titleLabel.Text.Equals("AUDITOR"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in auditorCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Auditor Candidates: \n" + sb.ToString(), "Candidates for Auditor");
                }
                else if (titleLabel.Text.Equals("PUBLIC RELATIONS OFFICER"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in publicRelationsCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Public Relations Officer Candidates: \n" + sb.ToString(), "Candidates for PRO");
                }
                else if (titleLabel.Text.Equals("FIRST YEAR REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in firstYearRepCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("1st Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                }
                else if (titleLabel.Text.Equals("SECOND YEAR REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in secondYearRepCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("2nd Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");

                }
                else if (titleLabel.Text.Equals("THIRD YEAR REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in thirdYearRepCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("3rd Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                    ;
                }
                else if (titleLabel.Text.Equals("FOURTH YEAR REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in fourthYearRepCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("4th Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                }
                else if (titleLabel.Text.Equals("CARES REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in caresRepCandidates)
                        sb.Append(item + "\n");
                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Cares Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                }
                else if (titleLabel.Text.Equals("ACADEMIC REPRESENTATIVE"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in academicrepresentativeCandidates)
                        sb.Append(item + "\n");

                    if (sb.Length == 0)
                    { MessageBox.Show("The are no candidates in this position"); return; }
                    MessageBox.Show("Academic Representative Candidates: \n" + sb.ToString(), "Candidates for Representative");
                }
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(btnWidth, btnHeight);
            deleteButton.Font = new Font("Segoe UI", 8);
            deleteButton.Click += (s, e) =>
            {
                string removed = titleLabel.Text;
                string desc = description;
                int noOfPositions = -1;

                if (btn_start_election.Enabled == false && btn_end_election.Enabled == false)
                {
                    positionTitles.Remove(removed);
                    candidate.SetPositionTitles(positionTitles);
                    flowLayoutPanel1.Controls.Remove(positionPanel);
                    positionPanel.Dispose();

                    position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                    noOfPositions = position.GetNoOfPositions();
                    lb_no_of_positions.Text = noOfPositions.ToString();

                    try
                    {
                        string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        lines.RemoveAll(line => line.Equals(removed) || line.Equals(desc));
                        File.WriteAllLines(filePath, lines);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading or writing file: " + ex.Message);
                    }
                }
                else if (btn_start_election.Enabled == false)
                {
                    MessageBox.Show("Please end the election first.");
                    return;
                }
                else
                {
                    positionTitles.Remove(removed);
                    candidate.SetPositionTitles(positionTitles);
                    flowLayoutPanel1.Controls.Remove(positionPanel);
                    positionPanel.Dispose();

                    position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                    noOfPositions = position.GetNoOfPositions();
                    lb_no_of_positions.Text = noOfPositions.ToString();


                    try
                    {
                        string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt";
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        lines.RemoveAll(line => line.Equals(removed) || line.Equals(desc));
                        File.WriteAllLines(filePath, lines);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading or writing file: " + ex.Message);
                    }

                }



            };

            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(deleteButton);

            positionPanel.Controls.Add(titleLabel);
            positionPanel.Controls.Add(descriptionLabel);
            positionPanel.Controls.Add(buttonPanel);

            flowLayoutPanel1.Controls.Add(positionPanel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (positionTitles.Count == 0 && btn_start_election.Enabled == false && btn_end_election.Enabled == false)
            {
                btn_end_election.Enabled = false;
                btn_start_election.Enabled = true;
            }

            if (btn_start_election.Enabled == false && btn_end_election.Enabled == false)
            {
                MessageBox.Show("Please start the election first.");
                return;
            }
            else if (btn_start_election.Enabled == false)
            {
                MessageBox.Show("Please end the election first.");
                return;
            }

            if (positionTitles.Count == 12)
            {
                MessageBox.Show("You have reached the maximum number of positions.");
                return;
            }


            AddPostion position1 = new AddPostion();
            position1.Show();


            position1.FormClosing += (s, args) =>
            {
                string positionTitle = position1.GetPositionTitle();
                string description = position1.GetDescription();

                if (string.IsNullOrEmpty(positionTitle) && string.IsNullOrEmpty(description))
                    return;

                foreach (string title in positionTitles)
                {
                    if (title.Equals(positionTitle))
                    {
                        position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                        MessageBox.Show("Position already exists.");
                        return;
                    }
                }
                String[] listOfPositoins =
                {
                    "PRESIDENT",
                    "VICE PRESIDENT",
                    "SECRETARY",
                    "TREASURER",
                    "AUDITOR",
                    "PUBLIC RELATIONS OFFICER",
                    "FIRST YEAR REPRESENTATIVE",
                    "SECOND YEAR REPRESENTATIVE",
                    "THIRD YEAR REPRESENTATIVE",
                    "FOURTH YEAR REPRESENTATIVE",
                    "CARES REPRESENTATIVE",
                    "ACADEMIC REPRESENTATIVE",
                };

                bool isValidPosition = false;
                for (int i = 0; i < listOfPositoins.Length; i++)
                {
                    if (positionTitle.ToUpper().Equals(listOfPositoins[i]) || positionTitle.ToUpper().EndsWith(listOfPositoins[i]))
                    {
                        isValidPosition = true;
                        break;
                    }
                }

                if (!isValidPosition)
                {
                    MessageBox.Show("Invalid position title. Please enter a valid position.");
                    position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                    return;
                }
                foreach (string title in positionTitles)
                {
                    if (title.Equals(positionTitle.ToUpper()))
                    {
                        position.SetNoOfPositions(position.GetNoOfPositions() - 1);
                        MessageBox.Show("Position already exists.");
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(positionTitle) && !string.IsNullOrEmpty(description))
                {
                    AddPosition(positionTitle, description);
                    lb_no_of_positions.Text = position1.GetNoOfPositions().ToString();
                    positionTitles.Add(positionTitle.ToUpper());
                    candidate.SetPositionTitles(positionTitles);

                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\PositionData.txt", true))
                        {
                            sw.WriteLine(positionTitle.ToUpper());
                            sw.WriteLine(description);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing to file: " + ex.Message);
                    }
                }
            };
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        public void AddCandidate(string name, string motto, int studentId, Image candidateImage, string positionTitle)
        {
            Panel candidatePanel = new Panel();
            candidatePanel.Size = new Size(850, 100);
            candidatePanel.BackColor = Color.White;
            candidatePanel.BorderStyle = BorderStyle.FixedSingle;
            candidatePanel.Margin = new Padding(8);
            candidatePanel.Padding = new Padding(10);

            candidatePanel.BackColor = Color.WhiteSmoke;
            candidatePanel.BorderStyle = BorderStyle.Fixed3D;

            PictureBox profilePicture = new PictureBox();
            profilePicture.Image = candidateImage;
            profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            profilePicture.Size = new Size(60, 60);
            profilePicture.Location = new Point(15, 20);
            profilePicture.BorderStyle = BorderStyle.FixedSingle;

            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            nameLabel.ForeColor = Color.Black;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(90, 20);

            Label idLabel = new Label();
            idLabel.Text = $"{studentId}";
            idLabel.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            idLabel.ForeColor = Color.DimGray;
            idLabel.AutoSize = true;
            idLabel.Location = new Point(90, 45);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point(700, 35);
            buttonPanel.Padding = new Padding(0);

            int btnWidth = 60;
            int btnHeight = 28;

            Button viewButton = new Button();
            viewButton.Text = "View";
            viewButton.BackColor = Color.DodgerBlue;
            viewButton.ForeColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.Size = new Size(btnWidth, btnHeight);
            viewButton.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            viewButton.Click += (s, e) =>
            {
                MessageBox.Show($"Name: {name}\nMotto: {motto} \nStudent ID: {studentId}\nPosition: {positionTitle}", "Candidate Info");
            };

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(btnWidth, btnHeight);
            deleteButton.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            deleteButton.Click += (s, e) =>
            {

                if (btn_start_election.Enabled == false && btn_end_election.Enabled == false)
                {
                    flowLayoutPanel2.Controls.Remove(candidatePanel);
                    candidatePanel.Dispose();
                    candidate.SetNoOfCandidates(candidate.GetNoOfCandidates() - 1);
                    int noOfCandidates = candidate.GetNoOfCandidates();
                    lb_no_of_candidates.Text = noOfCandidates.ToString();

                    string title = positionTitle.Trim().ToUpper();
                    if (title == "PRESIDENT")
                        presidentCandidates.Remove(name);
                    else if (title == "VICE PRESIDENT" || title == "VICE-PRESIDENT")
                        vicePresidentCandidates.Remove(name);
                    else if (title == "SECRETARY")
                        secretaryCandidates.Remove(name);
                    else if (title == "TREASURER")
                        treasurerCandidates.Remove(name);
                    else if (title == "AUDITOR")
                        auditorCandidates.Remove(name);
                    else if (title == "PUBLIC RELATIONS OFFICER")
                        publicRelationsCandidates.Remove(name);
                    else if (title.Equals("FIRST YEAR REPRESENTATIVE"))
                        firstYearRepCandidates.Remove(name);
                    else if (title.Equals("SECOND YEAR REPRESENTATIVE"))
                        secondYearRepCandidates.Remove(name);
                    else if (title.Equals("THIRD YEAR REPRESENTATIVE"))
                        thirdYearRepCandidates.Remove(name);
                    else if (title.Equals("FOURTH YEAR REPRESENTATIVE"))
                        fourthYearRepCandidates.Remove(name);
                    else if (title.Equals("CARES REPRESENTATIVE"))
                        caresRepCandidates.Remove(name);
                    else if (title.Equals("ACADEMIC REPRESENTATIVE"))
                        academicrepresentativeCandidates.Remove(name);


                    try
                    {
                        string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        for (int i = 0; i <= lines.Count - 5; i++)
                        {
                            if (lines[i].Trim() == name.Trim() &&
                                lines[i + 1].Trim() == motto.Trim() &&
                                lines[i + 2].Trim() == studentId.ToString().Trim())
                            {
                                string imagePath = lines[i + 3].Trim();


                                try
                                {
                                    if (File.Exists(imagePath))
                                    {
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        File.Delete(imagePath);
                                    }
                                }
                                catch (Exception exImg)
                                {
                                    MessageBox.Show("Image delete failed: " + exImg.Message);
                                }

                                lines.RemoveRange(i, 5);

                                if (i < lines.Count && string.IsNullOrWhiteSpace(lines[i]))
                                    lines.RemoveAt(i);

                                File.WriteAllLines(filePath, lines);
                                return;
                            }
                        }

                        MessageBox.Show("Candidate not found in file.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting candidate data or image: " + ex.Message);
                    }
                    return;
                }
                else if (btn_start_election.Enabled == false)
                {
                    MessageBox.Show("Please end the election first.");
                    return;
                }
                else
                {
                    flowLayoutPanel2.Controls.Remove(candidatePanel);
                    candidatePanel.Dispose();
                    candidate.SetNoOfCandidates(candidate.GetNoOfCandidates() - 1);
                    int noOfCandidates = candidate.GetNoOfCandidates();
                    lb_no_of_candidates.Text = noOfCandidates.ToString();

                    string title = positionTitle.Trim().ToUpper();
                    if (title == "PRESIDENT")
                        presidentCandidates.Remove(name);
                    else if (title == "VICE PRESIDENT" || title == "VICE-PRESIDENT")
                        vicePresidentCandidates.Remove(name);
                    else if (title == "SECRETARY")
                        secretaryCandidates.Remove(name);
                    else if (title == "TREASURER")
                        treasurerCandidates.Remove(name);
                    else if (title == "AUDITOR")
                        auditorCandidates.Remove(name);
                    else if (title == "PUBLIC RELATIONS OFFICER")
                        publicRelationsCandidates.Remove(name);
                    else if (title.Equals("FIRST YEAR REPRESENTATIVE"))
                        firstYearRepCandidates.Remove(name);
                    else if (title.Equals("SECOND YEAR REPRESENTATIVE"))
                        secondYearRepCandidates.Remove(name);
                    else if (title.Equals("THIRD YEAR REPRESENTATIVE"))
                        thirdYearRepCandidates.Remove(name);
                    else if (title.Equals("FOURTH YEAR REPRESENTATIVE"))
                        fourthYearRepCandidates.Remove(name);
                    else if (title.Equals("CARES REPRESENTATIVE"))
                        caresRepCandidates.Remove(name);
                    else if (title.Equals("ACADEMIC REPRESENTATIVE"))
                        academicrepresentativeCandidates.Remove(name);


                    try
                    {
                        string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt";
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        for (int i = 0; i <= lines.Count - 5; i++)
                        {
                            if (lines[i].Trim() == name.Trim() &&
                                lines[i + 1].Trim() == motto.Trim() &&
                                lines[i + 2].Trim() == studentId.ToString().Trim())
                            {
                                string imagePath = lines[i + 3].Trim();


                                try
                                {
                                    if (File.Exists(imagePath))
                                    {
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        File.Delete(imagePath);
                                    }
                                }
                                catch (Exception exImg)
                                {
                                    MessageBox.Show("Image delete failed: " + exImg.Message);
                                }

                                lines.RemoveRange(i, 5);

                                if (i < lines.Count && string.IsNullOrWhiteSpace(lines[i]))
                                    lines.RemoveAt(i);

                                File.WriteAllLines(filePath, lines);
                                return;
                            }
                        }

                        MessageBox.Show("Candidate not found in file.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting candidate data or image: " + ex.Message);
                    }

                }
            };

            //string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();
            //        string query = "INSERT INTO Result (time_and_date, president_winner, vp_winner, secretary_winner, treasurer_winner, pro_winner, auditor_winner, first_rep_winner, second_rep_winner, third_rep_winner, fourth_rep_winner, cares_rep_winner, acad_rep_winner) " +
            //            "VALUES (@timestamp, @presWinner, @viceWinner, @secWinner, @treasWinner, @auditorWinner, @pioWinner, @firstWinner, @secondWinner, @thirdWinner, @fourthWinner , @caresWinner , @acadWinner)";
            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@timestamp", timestamp);
            //            command.Parameters.AddWithValue("@presWinner", presWinner);
            //            command.Parameters.AddWithValue("@viceWinner", viceWinner);
            //            command.Parameters.AddWithValue("@secWinner", secWinner);
            //            command.Parameters.AddWithValue("@treasWinner", treasWinner);
            //            command.Parameters.AddWithValue("@auditorWinner", auditorWinner);
            //            command.Parameters.AddWithValue("@pioWinner", pioWinner);
            //            command.Parameters.AddWithValue("@firstWinner", firstWinner);
            //            command.Parameters.AddWithValue("@secondWinner", secondWinner);
            //            command.Parameters.AddWithValue("@thirdWinner", thirdWinner);
            //            command.Parameters.AddWithValue("@fourthWinner", fourthWinner);
            //            command.Parameters.AddWithValue("@caresWinner", caresWinner);
            //            command.Parameters.AddWithValue("@acadWinner", acadWinner);
            //            command.ExecuteNonQuery();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error counting votes: " + ex.Message);
            //    }
            //}

            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(deleteButton);

            candidatePanel.Controls.Add(profilePicture);
            candidatePanel.Controls.Add(nameLabel);
            candidatePanel.Controls.Add(idLabel);
            candidatePanel.Controls.Add(buttonPanel);

            flowLayoutPanel2.Controls.Add(candidatePanel);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (positionTitles.Count == 0 && btn_start_election.Enabled == false && btn_end_election.Enabled == false)
            {
                btn_end_election.Enabled = false;
                btn_start_election.Enabled = true;
            }
            if (position.GetNoOfPositions() == 0)
            {
                MessageBox.Show("Please add a position first.");
                return;
            }
            if (btn_start_election.Enabled == false && btn_end_election.Enabled == false)
            {
                MessageBox.Show("Please start the election first.");
                return;
            }
            else if (btn_start_election.Enabled == false)
            {
                MessageBox.Show("Please end the election first.");
                return;
            }
            AddCandidate candidate1 = new AddCandidate();
            candidate1.Show();


            candidate1.FormClosing += (s, args) =>
            {
                string name = candidate1.GetName();
                string motto = candidate1.GetMotto();
                int studentId = candidate1.GetStudentId();
                Image candidateImage = candidate1.GetCandidateImage();


                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(motto) && studentId == 0)
                    return;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(motto) && studentId > 0)
                {
                    AddCandidate(name, motto, studentId, candidateImage, candidate1.GetPositionTitle());
                    lb_no_of_candidates.Text = candidate1.GetNoOfCandidates().ToString();


                    string positionTitle = candidate1.GetPositionTitle();
                    if (positionTitle.ToUpper().Equals("PRESIDENT"))
                        presidentCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("VICE PRESIDENT") || name.Equals("VICE-PRESIDENT"))
                        vicePresidentCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("SECRETARY"))
                        secretaryCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("TREASURER"))
                        treasurerCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("AUDITOR"))
                        auditorCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("PUBLIC RELATIONS OFFICER"))
                        publicRelationsCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("FIRST YEAR REPRESENTATIVE"))
                        firstYearRepCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("SECOND YEAR REPRESENTATIVE"))
                        secondYearRepCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("THIRD YEAR REPRESENTATIVE"))
                        thirdYearRepCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("FOURTH YEAR REPRESENTATIVE"))
                        fourthYearRepCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("CARES REPRESENTATIVE"))
                        caresRepCandidates.Add(name);
                    else if (positionTitle.ToUpper().Equals("ACADEMIC REPRESENTATIVE"))
                        academicrepresentativeCandidates.Add(name);


                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateData.txt", true))
                        {
                            sw.WriteLine(name);
                            sw.WriteLine(motto);
                            sw.WriteLine(studentId);

                            string imageFileName = $"{studentId}_{DateTime.Now.Ticks}.png";
                            string imagePath = Path.Combine("D:\\Glyzel's Files\\C#\\Nursing Election\\CandidateImages", imageFileName);
                            candidateImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                            sw.WriteLine(imagePath);
                            sw.WriteLine(candidate1.GetPositionTitle());
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing to file: sdf" + ex.Message);
                    }

                }
            };
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LabelCount labelCount = new LabelCount();
                labelCount.SetPositionTitles(positionTitles);
                labelCount.SetPresidentCandidates(presidentCandidates);
                labelCount.SetVicePresidentCandidates(vicePresidentCandidates);
                labelCount.SetSecretaryCandidates(secretaryCandidates);
                labelCount.SetTreasurerCandidates(treasurerCandidates);
                labelCount.SetAuditorCandidates(auditorCandidates);
                labelCount.SetPublicRelationsCandidates(publicRelationsCandidates);
                labelCount.SetFirstYearRepresentativeCandidates(firstYearRepCandidates);
                labelCount.SetSecondYearRepresentativeCandidates(secondYearRepCandidates);
                labelCount.SetThirdYearRepresentativeCandidates(thirdYearRepCandidates);
                labelCount.SetFourthYearRepresentativeCandidates(fourthYearRepCandidates);
                labelCount.SetCaresRepresentativeCandidates(caresRepCandidates);
                labelCount.SetAcademicRepresentativeCandidates(academicrepresentativeCandidates);


                //try
                //{
                //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\Count.txt", true))
                //    {
                //        sw.WriteLine(lb_no_of_positions.Text);
                //        sw.WriteLine(lb_no_of_candidates.Text);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error writing to file: " + ex.Message);
                //}


                try
                {
                    string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\Count.txt";
                    FileInfo countFile = new FileInfo(filePath);
                    if (countFile.Exists && countFile.Length == 0)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                        {
                            sw.WriteLine(lb_no_of_positions.Text);
                            sw.WriteLine(lb_no_of_candidates.Text);
                        }

                    }
                    else if (countFile.Exists && countFile.Length > 0)
                    {
                        File.WriteAllText(filePath, string.Empty);
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                                {
                                    sw.WriteLine(lb_no_of_positions.Text);
                                }
                            }
                            else if (i == 1)
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                                {
                                    sw.WriteLine(lb_no_of_candidates.Text);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: where " + ex.Message);
                }


                new Login().Show();
                this.Hide();
            }
        }
        private void btn_start_election_Click_1(object sender, EventArgs e)
        {
            string historyPath = "D:\\Glyzel's Files\\C#\\Nursing Election\\History.txt";

            FileInfo fileInfo = new FileInfo(historyPath);

            if (fileInfo.Exists && fileInfo.Length > 0)
            {
                File.WriteAllText(historyPath, string.Empty);
            }

            if (position.GetNoOfPositions() == 0)
            {
                MessageBox.Show("Please add a position first.");
                return;
            }
            else if (candidate.GetNoOfCandidates() == 0)
            {
                MessageBox.Show("Please add a candidate first.");
                return;
            }
            else if (candidate.GetNoOfCandidates() < 5)
            {
                MessageBox.Show("Candidates should atleast 10.");
                return;
            }

            if (position.GetNoOfPositions() < 12)

            { MessageBox.Show("The number of positions must exactly 12"); return; }

            if (presidentCandidates.Count < 2 || vicePresidentCandidates.Count < 2 || secretaryCandidates.Count < 2 || treasurerCandidates.Count < 2 || auditorCandidates.Count < 2 || publicRelationsCandidates.Count < 2 || firstYearRepCandidates.Count < 2 || secondYearRepCandidates.Count < 2 || thirdYearRepCandidates.Count < 2 || fourthYearRepCandidates.Count < 2 || caresRepCandidates.Count < 2 || academicrepresentativeCandidates.Count < 2)
            {
                MessageBox.Show("Candidates should atleast 2");
                return;
            }



            foreach (var item in positionTitles)
            {
                if (item.Equals("PRESIDENT"))
                {
                    if (presidentCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for President.");
                        return;
                    }
                }
                else if (item.Equals("VICE PRESIDENT") || item.Equals("VICE-PRESIDENT"))
                {
                    if (vicePresidentCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Vice President.");
                        return;
                    }
                }
                else if (item.Equals("SECRETARY"))
                {
                    if (secretaryCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Secretary.");
                        return;
                    }
                }
                else if (item.Equals("TREASURER"))
                {
                    if (treasurerCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Treasurer.");
                        return;
                    }
                }
                else if (item.Equals("AUDITOR"))
                {
                    if (auditorCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Auditor.");
                        return;
                    }
                }
                else if (item.Equals("PUBLIC RELATIONS OFFICER"))
                {
                    if (publicRelationsCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Public Relations Officer.");
                        return;
                    }
                }
                else if (item.Equals("FIRST YEAR REPRESENTATIVE"))
                {
                    if (firstYearRepCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for First Year Representative.");
                        return;
                    }
                }
                else if (item.Equals("SECOND YEAR REPRESENTATIVE"))
                {
                    if (secondYearRepCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Second Year Representative.");
                        return;
                    }
                }
                else if (item.Equals("THIRD YEAR REPRESENTATIVE"))
                {
                    if (thirdYearRepCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Third Year Representative.");
                        return;
                    }
                }
                else if (item.Equals("FOURTH YEAR REPRESENTATIVE"))
                {
                    if (fourthYearRepCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Fourth Year Representative.");
                        return;
                    }
                }
                else if (item.Equals("CARES REPRESENTATIVE"))
                {
                    if (caresRepCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Cares Representative.");
                        return;
                    }
                }
                else if (item.Equals("ACADEMIC REPRESENTATIVE"))
                {
                    if (academicrepresentativeCandidates.Count == 0)
                    {
                        MessageBox.Show("Please add a candidate for Academic Representative.");
                        return;
                    }
                }

            }
            btn_start_election.BackColor = Color.Gray;
            StartElectionClass start = new StartElectionClass();
            start.SetElectionStarted(true);
            start.SetStartButtonClicked(true);
            btn_start_election.Enabled = false;
            btn_end_election.Enabled = true;
            btn_add_candidate.Enabled = false;


            string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\PositionAndCandidates.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Glyzel's Files\\C#\\Nursing Election\\PositionAndCandidates.txt", true))
                    {

                        if (positionTitles.Contains("PRESIDENT"))
                        {
                            sw.WriteLine("PRESIDENT");
                            foreach (var item in presidentCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("VICE PRESIDENT") || positionTitles.Contains("VICE-PRESIDENT"))
                        {
                            sw.WriteLine("VICE PRESIDENT");
                            foreach (var item in vicePresidentCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("SECRETARY"))
                        {
                            sw.WriteLine("SECRETARY");
                            foreach (var item in secretaryCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("TREASURER"))
                        {
                            sw.WriteLine("TREASURER");
                            foreach (var item in treasurerCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("AUDITOR"))
                        {
                            sw.WriteLine("AUDITOR");
                            foreach (var item in auditorCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("PUBLIC RELATIONS OFFICER"))
                        {
                            sw.WriteLine("PUBLIC RELATIONS OFFICER");
                            foreach (var item in publicRelationsCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("FIRST YEAR REPRESENTATIVE"))
                        {
                            sw.WriteLine("FIRST YEAR REPRESENTATIVE");
                            foreach (var item in firstYearRepCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("SECOND YEAR REPRESENTATIVE"))
                        {
                            sw.WriteLine("SECOND YEAR REPRESENTATIVE");
                            foreach (var item in secondYearRepCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("THIRD YEAR REPRESENTATIVE"))
                        {
                            sw.WriteLine("THIRD YEAR REPRESENTATIVE");
                            foreach (var item in thirdYearRepCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("FOURTH YEAR REPRESENTATIVE"))
                        {
                            sw.WriteLine("FOURTH YEAR REPRESENTATIVE");
                            foreach (var item in fourthYearRepCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("CARES REPRESENTATIVE"))
                        {
                            sw.WriteLine("CARES REPRESENTATIVE");
                            foreach (var item in caresRepCandidates)
                                sw.WriteLine(item);
                        }
                        if (positionTitles.Contains("ACADEMIC REPRESENTATIVE"))
                        {
                            sw.WriteLine("ACADEMIC REPRESENTATIVE");
                            foreach (var item in academicrepresentativeCandidates)
                                sw.WriteLine(item);
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing to file: " + ex.Message);
                }
            }

            AddPanelOfVotes("PRESIDENT", presidentCandidates, presidentVotes);
            AddPanelOfVotes("VICE PRESIDENT", vicePresidentCandidates, vicePresidentVotes);
            AddPanelOfVotes("SECRETARY", secretaryCandidates, secretaryVotes);
            AddPanelOfVotes("TREASURER", treasurerCandidates, treasurerVotes);
            AddPanelOfVotes("AUDITOR", auditorCandidates, auditorVotes);
            AddPanelOfVotes("PUBLIC RELATIONS OFFICER", publicRelationsCandidates, publicRelationsVotes);
            AddPanelOfVotes("FIRST YEAR REPRESENTATIVE", firstYearRepCandidates, firstYearRepVotes);
            AddPanelOfVotes("SECOND YEAR REPRESENTATIVE", secondYearRepCandidates, secondYearRepVotes);
            AddPanelOfVotes("THIRD YEAR REPRESENTATIVE", thirdYearRepCandidates, thirdYearRepVotes);
            AddPanelOfVotes("FOURTH YEAR REPRESENTATIVE", fourthYearRepCandidates, fourthYearRepVotes);
            AddPanelOfVotes("CARES REPRESENTATIVE", caresRepCandidates, caresRepVotes);
            AddPanelOfVotes("ACADEMIC REPRESENTATIVE", academicrepresentativeCandidates, academicRepresentativeVotes);
        }

        private void form_admin_dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LabelCount labelCount = new LabelCount();
                labelCount.SetPositionTitles(positionTitles);
                labelCount.SetPresidentCandidates(presidentCandidates);
                labelCount.SetVicePresidentCandidates(vicePresidentCandidates);
                labelCount.SetSecretaryCandidates(secretaryCandidates);
                labelCount.SetTreasurerCandidates(treasurerCandidates);
                labelCount.SetAuditorCandidates(auditorCandidates);
                labelCount.SetPublicRelationsCandidates(publicRelationsCandidates);
                labelCount.SetFirstYearRepresentativeCandidates(firstYearRepCandidates);
                labelCount.SetSecondYearRepresentativeCandidates(secondYearRepCandidates);
                labelCount.SetThirdYearRepresentativeCandidates(thirdYearRepCandidates);
                labelCount.SetFourthYearRepresentativeCandidates(fourthYearRepCandidates);
                labelCount.SetCaresRepresentativeCandidates(caresRepCandidates);
                labelCount.SetAcademicRepresentativeCandidates(academicrepresentativeCandidates);
                try
                {
                    string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\Count.txt";
                    FileInfo countFile = new FileInfo(filePath);
                    if (countFile.Exists && countFile.Length == 0)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                        {
                            sw.WriteLine(lb_no_of_positions.Text);
                            sw.WriteLine(lb_no_of_candidates.Text);
                        }

                    }
                    else if (countFile.Exists && countFile.Length > 0)
                    {
                        File.WriteAllText(filePath, string.Empty);
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                                {
                                    sw.WriteLine(lb_no_of_positions.Text);
                                }
                            }
                            else if (i == 1)
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                                {
                                    sw.WriteLine(lb_no_of_candidates.Text);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: where " + ex.Message);
                }

                this.Hide();
                new Login().Show();
            }
        }

        private void form_admin_dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btn_end_election_Click(object sender, EventArgs e)
        {
            btn_end_election.BackColor = Color.HotPink;
            btn_end_election.Enabled = false;
            SaveButton();
            MessageBox.Show("Election ended successfully. The data will be stored in the database.");
            StartElectionClass startElectionClass = new StartElectionClass();
            startElectionClass.SetElectionStarted(false);
            startElectionClass.SetStartButtonClicked(false);
            startElectionClass.SetElectionFinished(true);
            

        }

        private void AddPanelOfVotes(string positionTitle, ArrayList candidates, string[,] votes)
        {
            Panel positionPanel = new Panel();
            positionPanel.Size = new Size(850, 60 + candidates.Count * 60);
            positionPanel.BackColor = Color.WhiteSmoke;
            positionPanel.BorderStyle = BorderStyle.Fixed3D;
            positionPanel.Margin = new Padding(8);
            positionPanel.Padding = new Padding(10);

            Label titleLabel = new Label();
            titleLabel.Text = positionTitle.ToUpper();
            titleLabel.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(10, 10);
            positionPanel.Controls.Add(titleLabel);

            int startY = 50;

            foreach (var candidate in candidates)
            {
                string candidateName = candidate.ToString();
                string voteCount = "0";

                for (int i = 0; i < votes.GetLength(0); i++)
                {
                    if (votes[i, 0] != null && votes[i, 0].Equals(candidateName))
                    {
                        voteCount = votes[i, 1];
                        break;
                    }
                }

                Panel candidatePanel = new Panel();
                candidatePanel.Size = new Size(800, 40);
                candidatePanel.Location = new Point(10, startY);
                candidatePanel.BackColor = Color.White;

                Label nameLabel = new Label();
                nameLabel.Text = candidateName;
                nameLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(10, 10);
                candidatePanel.Controls.Add(nameLabel);

                Label voteLabel = new Label();
                voteLabel.Text = $"{voteCount} votes";
                voteLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                voteLabel.AutoSize = true;
                voteLabel.Location = new Point(candidatePanel.Width - 100, 10);
                voteLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                candidatePanel.Controls.Add(voteLabel);

                positionPanel.Controls.Add(candidatePanel);
                startY += 50;
            }

            string pos = positionTitle.ToUpper();
            if (pos == "PRESIDENT")
                fp_pres.Controls.Add(positionPanel);
            else if (pos == "VICE PRESIDENT" || pos == "VICE-PRESIDENT")
                fp_vice.Controls.Add(positionPanel);
            else if (pos == "SECRETARY")
                fp_sec.Controls.Add(positionPanel);
            else if (pos == "TREASURER")
                fp_treas.Controls.Add(positionPanel);
            else if (pos == "AUDITOR")
                fp_auditor.Controls.Add(positionPanel);
            else if (pos == "PUBLIC RELATIONS OFFICER")
                fp_pio.Controls.Add(positionPanel);
            else if (pos == "FIRST YEAR REPRESENTATIVE")
                fp_first.Controls.Add(positionPanel);
            else if (pos == "SECOND YEAR REPRESENTATIVE")
                fp_second.Controls.Add(positionPanel);
            else if (pos == "THIRD YEAR REPRESENTATIVE")
                fp_third.Controls.Add(positionPanel);
            else if (pos == "FOURTH YEAR REPRESENTATIVE")
                fp_fourth.Controls.Add(positionPanel);
            else if (pos == "CARES REPRESENTATIVE")
                fp_cares.Controls.Add(positionPanel);
            else if (pos == "ACADEMIC REPRESENTATIVE")
                fp_acad.Controls.Add(positionPanel);
        }
        public void SaveButton()
        {
            StartElectionClass startElectionClass = new StartElectionClass();

            if (btn_end_election.Enabled == false && btn_start_election.Enabled == false)
            {
                string presWinner = GetWinner(presidentVotes, out int presVotes);
                string viceWinner = GetWinner(vicePresidentVotes, out int viceVotes);
                string secWinner = GetWinner(secretaryVotes, out int secVotes);
                string treasWinner = GetWinner(treasurerVotes, out int treasVotes);
                string auditorWinner = GetWinner(auditorVotes, out int auditorVotesCount);
                string pioWinner = GetWinner(publicRelationsVotes, out int pioVotes);
                string firstWinner = GetWinner(firstYearRepVotes, out int firstVotes);
                string secondWinner = GetWinner(secondYearRepVotes, out int secondVotes);
                string thirdWinner = GetWinner(thirdYearRepVotes, out int thirdVotes);
                string fourthWinner = GetWinner(fourthYearRepVotes, out int fourthVotes);
                string caresWinner = GetWinner(caresRepVotes, out int caresVotes);
                string acadWinner = GetWinner(academicRepresentativeVotes, out int acadVotes);

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string electionResults =
                 $"President: {presWinner} - {presVotes} votes\n" +
                 $"Vice President: {viceWinner} - {viceVotes} votes\n" +
                 $"Secretary: {secWinner} - {secVotes} votes\n" +
                 $"Treasurer: {treasWinner} - {treasVotes} votes\n" +
                 $"Auditor: {auditorWinner} - {auditorVotesCount} votes\n" +
                 $"PRO: {pioWinner} - {pioVotes} votes\n" +
                 $"First Year Representative: {firstWinner} - {firstVotes} votes\n" +
                 $"Second Year Representative: {secondWinner} - {secondVotes} votes\n" +
                 $"Third Year Representative: {thirdWinner} - {thirdVotes} votes\n" +
                 $"Fourth Year Representative: {fourthWinner} - {fourthVotes} votes\n" +
                 $"CARES Representative: {caresWinner} - {caresVotes} votes\n" +
                 $"Academic Representative: {acadWinner} - {acadVotes} votes";

                viewResult = electionResults;

                Console.WriteLine("Winners: "+electionResults);

                string connectionString = "Data Source=localhost;Initial Catalog=election2025;Integrated Security=True;TrustServerCertificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO Result (time_and_date, president_winner, vp_winner, secretary_winner, treasurer_winner, pro_winner, auditor_winner, first_rep_winner, second_rep_winner, third_rep_winner, fourth_rep_winner, cares_rep_winner, acad_rep_winner) " +
                            "VALUES (@timestamp, @presWinner, @viceWinner, @secWinner, @treasWinner, @auditorWinner, @pioWinner, @firstWinner, @secondWinner, @thirdWinner, @fourthWinner , @caresWinner , @acadWinner)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@timestamp", timestamp);
                            command.Parameters.AddWithValue("@presWinner", presWinner);
                            command.Parameters.AddWithValue("@viceWinner", viceWinner);
                            command.Parameters.AddWithValue("@secWinner", secWinner);
                            command.Parameters.AddWithValue("@treasWinner", treasWinner);
                            command.Parameters.AddWithValue("@auditorWinner", auditorWinner);
                            command.Parameters.AddWithValue("@pioWinner", pioWinner);
                            command.Parameters.AddWithValue("@firstWinner", firstWinner);
                            command.Parameters.AddWithValue("@secondWinner", secondWinner);
                            command.Parameters.AddWithValue("@thirdWinner", thirdWinner);
                            command.Parameters.AddWithValue("@fourthWinner", fourthWinner);
                            command.Parameters.AddWithValue("@caresWinner", caresWinner);
                            command.Parameters.AddWithValue("@acadWinner", acadWinner);
                            command.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error counting votes: " + ex.Message);
                    }
                }
                string filePath = "D:\\Glyzel's Files\\C#\\Nursing Election\\HistoryResults.txt";

                try
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine($"=== RECORD: {timestamp} ===");
                        sw.WriteLine(electionResults);
                        sw.WriteLine("=== END OF RECORD ===\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving record to file: " + ex.Message);
                }
            }
            else if (btn_end_election.Enabled == false && btn_start_election.Enabled == true)
            {
                MessageBox.Show("Complete the positions and candidates first");
            }
            else if (btn_start_election.Enabled == false && btn_end_election.Enabled == true)
            {
                MessageBox.Show("End the election first");
            }
        }

        private string GetWinner(string[,] votes, out int highestVotes)
        {
            string winner = "";
            highestVotes = -1;

            for (int i = 0; i < votes.GetLength(0); i++)
            {
                string name = votes[i, 0];
                if (int.TryParse(votes[i, 1], out int voteCount) && voteCount > highestVotes)
                {
                    highestVotes = voteCount;
                    winner = name;
                    break;
                }
            }

            return winner;
        }
    }

    
}

    

