namespace Nursing_Election
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_login = new System.Windows.Forms.Button();
            this.tb_student_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.LightCoral;
            this.btn_login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_login.Location = new System.Drawing.Point(320, 444);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(200, 39);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_student_id
            // 
            this.tb_student_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_student_id.Location = new System.Drawing.Point(320, 394);
            this.tb_student_id.Name = "tb_student_id";
            this.tb_student_id.Size = new System.Drawing.Size(200, 44);
            this.tb_student_id.TabIndex = 2;
            this.tb_student_id.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Register";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(839, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_student_id);
            this.Controls.Add(this.btn_login);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tb_student_id;
        private System.Windows.Forms.Label label1;
    }
}

