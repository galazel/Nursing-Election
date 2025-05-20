namespace Nursing_Election
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_student_id = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.cb_level = new System.Windows.Forms.ComboBox();
            this.tb_block = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_upload_photo = new System.Windows.Forms.Button();
            this.lb_image = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F);
            this.label1.Location = new System.Drawing.Point(136, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 15F);
            this.label2.Location = new System.Drawing.Point(136, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 15F);
            this.label3.Location = new System.Drawing.Point(136, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 15F);
            this.label4.Location = new System.Drawing.Point(136, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 15F);
            this.label5.Location = new System.Drawing.Point(136, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Block";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tb_student_id
            // 
            this.tb_student_id.Font = new System.Drawing.Font("Consolas", 15F);
            this.tb_student_id.Location = new System.Drawing.Point(339, 137);
            this.tb_student_id.Name = "tb_student_id";
            this.tb_student_id.Size = new System.Drawing.Size(231, 31);
            this.tb_student_id.TabIndex = 5;
            this.tb_student_id.TextChanged += new System.EventHandler(this.tb_student_id_TextChanged);
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Consolas", 15F);
            this.tb_name.Location = new System.Drawing.Point(339, 189);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(231, 31);
            this.tb_name.TabIndex = 6;
            // 
            // cb_level
            // 
            this.cb_level.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_level.Font = new System.Drawing.Font("Consolas", 15F);
            this.cb_level.FormattingEnabled = true;
            this.cb_level.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_level.Location = new System.Drawing.Point(339, 246);
            this.cb_level.Name = "cb_level";
            this.cb_level.Size = new System.Drawing.Size(231, 31);
            this.cb_level.TabIndex = 7;
            // 
            // tb_block
            // 
            this.tb_block.Font = new System.Drawing.Font("Consolas", 15F);
            this.tb_block.Location = new System.Drawing.Point(339, 310);
            this.tb_block.Name = "tb_block";
            this.tb_block.Size = new System.Drawing.Size(231, 31);
            this.tb_block.TabIndex = 8;
            // 
            // tb_email
            // 
            this.tb_email.Font = new System.Drawing.Font("Consolas", 15F);
            this.tb_email.Location = new System.Drawing.Point(339, 371);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(231, 31);
            this.tb_email.TabIndex = 9;
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.Gold;
            this.btn_register.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Location = new System.Drawing.Point(221, 482);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(233, 37);
            this.btn_register.TabIndex = 10;
            this.btn_register.Text = "REGISTER";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(318, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "back";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 15F);
            this.label7.Location = new System.Drawing.Point(136, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Profile";
            // 
            // btn_upload_photo
            // 
            this.btn_upload_photo.BackColor = System.Drawing.Color.White;
            this.btn_upload_photo.Location = new System.Drawing.Point(339, 432);
            this.btn_upload_photo.Name = "btn_upload_photo";
            this.btn_upload_photo.Size = new System.Drawing.Size(93, 30);
            this.btn_upload_photo.TabIndex = 14;
            this.btn_upload_photo.Text = "Choose";
            this.btn_upload_photo.UseVisualStyleBackColor = false;
            this.btn_upload_photo.Click += new System.EventHandler(this.btn_upload_photo_Click);
            // 
            // lb_image
            // 
            this.lb_image.AutoSize = true;
            this.lb_image.Location = new System.Drawing.Point(482, 442);
            this.lb_image.Name = "lb_image";
            this.lb_image.Size = new System.Drawing.Size(0, 13);
            this.lb_image.TabIndex = 15;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 561);
            this.Controls.Add(this.lb_image);
            this.Controls.Add(this.btn_upload_photo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_block);
            this.Controls.Add(this.cb_level);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_student_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_student_id;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.ComboBox cb_level;
        private System.Windows.Forms.TextBox tb_block;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_upload_photo;
        private System.Windows.Forms.Label lb_image;
    }
}