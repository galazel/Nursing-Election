namespace Nursing_Election
{
    partial class AddCandidate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCandidate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_name_candidate = new System.Windows.Forms.Label();
            this.lb_student_id_candidate = new System.Windows.Forms.Label();
            this.lb_motto = new System.Windows.Forms.Label();
            this.tb_name_candidate = new System.Windows.Forms.TextBox();
            this.tb_student_id_candidate = new System.Windows.Forms.TextBox();
            this.tb_candidate_motto = new System.Windows.Forms.TextBox();
            this.btn_confirm_candidate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_positions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(37, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 219);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_name_candidate
            // 
            this.lb_name_candidate.AutoSize = true;
            this.lb_name_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_name_candidate.Location = new System.Drawing.Point(295, 70);
            this.lb_name_candidate.Name = "lb_name_candidate";
            this.lb_name_candidate.Size = new System.Drawing.Size(50, 22);
            this.lb_name_candidate.TabIndex = 1;
            this.lb_name_candidate.Text = "Name";
            // 
            // lb_student_id_candidate
            // 
            this.lb_student_id_candidate.AutoSize = true;
            this.lb_student_id_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_student_id_candidate.Location = new System.Drawing.Point(295, 127);
            this.lb_student_id_candidate.Name = "lb_student_id_candidate";
            this.lb_student_id_candidate.Size = new System.Drawing.Size(110, 22);
            this.lb_student_id_candidate.TabIndex = 2;
            this.lb_student_id_candidate.Text = "Student ID";
            // 
            // lb_motto
            // 
            this.lb_motto.AutoSize = true;
            this.lb_motto.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_motto.Location = new System.Drawing.Point(295, 184);
            this.lb_motto.Name = "lb_motto";
            this.lb_motto.Size = new System.Drawing.Size(60, 22);
            this.lb_motto.TabIndex = 3;
            this.lb_motto.Text = "Motto";
            // 
            // tb_name_candidate
            // 
            this.tb_name_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_name_candidate.Location = new System.Drawing.Point(299, 95);
            this.tb_name_candidate.Name = "tb_name_candidate";
            this.tb_name_candidate.Size = new System.Drawing.Size(333, 29);
            this.tb_name_candidate.TabIndex = 4;
            this.tb_name_candidate.TextChanged += new System.EventHandler(this.tb_name_candidate_TextChanged);
            // 
            // tb_student_id_candidate
            // 
            this.tb_student_id_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_student_id_candidate.Location = new System.Drawing.Point(298, 152);
            this.tb_student_id_candidate.Name = "tb_student_id_candidate";
            this.tb_student_id_candidate.Size = new System.Drawing.Size(333, 29);
            this.tb_student_id_candidate.TabIndex = 5;
            this.tb_student_id_candidate.TextChanged += new System.EventHandler(this.tb_student_id_candidate_TextChanged);
            // 
            // tb_candidate_motto
            // 
            this.tb_candidate_motto.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_candidate_motto.Location = new System.Drawing.Point(299, 209);
            this.tb_candidate_motto.Name = "tb_candidate_motto";
            this.tb_candidate_motto.Size = new System.Drawing.Size(333, 29);
            this.tb_candidate_motto.TabIndex = 6;
            this.tb_candidate_motto.TextChanged += new System.EventHandler(this.tb_candidate_motto_TextChanged);
            // 
            // btn_confirm_candidate
            // 
            this.btn_confirm_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.btn_confirm_candidate.Location = new System.Drawing.Point(527, 317);
            this.btn_confirm_candidate.Name = "btn_confirm_candidate";
            this.btn_confirm_candidate.Size = new System.Drawing.Size(104, 34);
            this.btn_confirm_candidate.TabIndex = 7;
            this.btn_confirm_candidate.Text = "Confirm";
            this.btn_confirm_candidate.UseVisualStyleBackColor = true;
            this.btn_confirm_candidate.Click += new System.EventHandler(this.btn_confirm_candidate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F);
            this.label1.Location = new System.Drawing.Point(295, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Position";
            // 
            // cb_positions
            // 
            this.cb_positions.AutoCompleteCustomSource.AddRange(new string[] {
            "Select"});
            this.cb_positions.FormattingEnabled = true;
            this.cb_positions.Location = new System.Drawing.Point(299, 268);
            this.cb_positions.Name = "cb_positions";
            this.cb_positions.Size = new System.Drawing.Size(332, 21);
            this.cb_positions.TabIndex = 9;
            this.cb_positions.SelectedIndexChanged += new System.EventHandler(this.cb_positions_SelectedIndexChanged);
            // 
            // AddCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 376);
            this.Controls.Add(this.cb_positions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_confirm_candidate);
            this.Controls.Add(this.tb_candidate_motto);
            this.Controls.Add(this.tb_student_id_candidate);
            this.Controls.Add(this.tb_name_candidate);
            this.Controls.Add(this.lb_motto);
            this.Controls.Add(this.lb_student_id_candidate);
            this.Controls.Add(this.lb_name_candidate);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "AddCandidate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCandidate";
            this.Load += new System.EventHandler(this.AddCandidate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_name_candidate;
        private System.Windows.Forms.Label lb_student_id_candidate;
        private System.Windows.Forms.Label lb_motto;
        private System.Windows.Forms.TextBox tb_name_candidate;
        private System.Windows.Forms.TextBox tb_student_id_candidate;
        private System.Windows.Forms.TextBox tb_candidate_motto;
        private System.Windows.Forms.Button btn_confirm_candidate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_positions;
    }
}