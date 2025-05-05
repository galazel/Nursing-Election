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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_name_candidate = new System.Windows.Forms.Label();
            this.lb_student_id_candidate = new System.Windows.Forms.Label();
            this.lb_motto = new System.Windows.Forms.Label();
            this.tb_name_candidate = new System.Windows.Forms.TextBox();
            this.tb_student_id_candidate = new System.Windows.Forms.TextBox();
            this.tb_candidate_motto = new System.Windows.Forms.TextBox();
            this.btn_confirm_candidate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(61, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 195);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lb_name_candidate
            // 
            this.lb_name_candidate.AutoSize = true;
            this.lb_name_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_name_candidate.Location = new System.Drawing.Point(294, 85);
            this.lb_name_candidate.Name = "lb_name_candidate";
            this.lb_name_candidate.Size = new System.Drawing.Size(50, 22);
            this.lb_name_candidate.TabIndex = 1;
            this.lb_name_candidate.Text = "Name";
            // 
            // lb_student_id_candidate
            // 
            this.lb_student_id_candidate.AutoSize = true;
            this.lb_student_id_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_student_id_candidate.Location = new System.Drawing.Point(295, 149);
            this.lb_student_id_candidate.Name = "lb_student_id_candidate";
            this.lb_student_id_candidate.Size = new System.Drawing.Size(110, 22);
            this.lb_student_id_candidate.TabIndex = 2;
            this.lb_student_id_candidate.Text = "Student ID";
            // 
            // lb_motto
            // 
            this.lb_motto.AutoSize = true;
            this.lb_motto.Font = new System.Drawing.Font("Consolas", 14F);
            this.lb_motto.Location = new System.Drawing.Point(295, 210);
            this.lb_motto.Name = "lb_motto";
            this.lb_motto.Size = new System.Drawing.Size(60, 22);
            this.lb_motto.TabIndex = 3;
            this.lb_motto.Text = "Motto";
            // 
            // tb_name_candidate
            // 
            this.tb_name_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_name_candidate.Location = new System.Drawing.Point(298, 110);
            this.tb_name_candidate.Name = "tb_name_candidate";
            this.tb_name_candidate.Size = new System.Drawing.Size(333, 29);
            this.tb_name_candidate.TabIndex = 4;
            // 
            // tb_student_id_candidate
            // 
            this.tb_student_id_candidate.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_student_id_candidate.Location = new System.Drawing.Point(298, 174);
            this.tb_student_id_candidate.Name = "tb_student_id_candidate";
            this.tb_student_id_candidate.Size = new System.Drawing.Size(333, 29);
            this.tb_student_id_candidate.TabIndex = 5;
            // 
            // tb_candidate_motto
            // 
            this.tb_candidate_motto.Font = new System.Drawing.Font("Consolas", 14F);
            this.tb_candidate_motto.Location = new System.Drawing.Point(298, 236);
            this.tb_candidate_motto.Name = "tb_candidate_motto";
            this.tb_candidate_motto.Size = new System.Drawing.Size(333, 29);
            this.tb_candidate_motto.TabIndex = 6;
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
            // 
            // AddCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 376);
            this.Controls.Add(this.btn_confirm_candidate);
            this.Controls.Add(this.tb_candidate_motto);
            this.Controls.Add(this.tb_student_id_candidate);
            this.Controls.Add(this.tb_name_candidate);
            this.Controls.Add(this.lb_motto);
            this.Controls.Add(this.lb_student_id_candidate);
            this.Controls.Add(this.lb_name_candidate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddCandidate";
            this.Text = "AddCandidate";
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
    }
}