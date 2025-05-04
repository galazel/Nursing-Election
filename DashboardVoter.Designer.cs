namespace Nursing_Election
{
    partial class DashboardVoter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardVoter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_vote_now = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_show_status = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_vote_now);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(36, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 109);
            this.panel1.TabIndex = 0;
            // 
            // btn_vote_now
            // 
            this.btn_vote_now.BackColor = System.Drawing.Color.Gold;
            this.btn_vote_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vote_now.Location = new System.Drawing.Point(19, 61);
            this.btn_vote_now.Name = "btn_vote_now";
            this.btn_vote_now.Size = new System.Drawing.Size(207, 37);
            this.btn_vote_now.TabIndex = 2;
            this.btn_vote_now.Text = "VOTE NOW";
            this.btn_vote_now.UseVisualStyleBackColor = false;
            this.btn_vote_now.Click += new System.EventHandler(this.btn_vote_now_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Voting for the School Election is now open.\r\nSelect your candidate from the list." +
    "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cast Your Vote";
            // 
            // btn_show_status
            // 
            this.btn_show_status.BackColor = System.Drawing.Color.Gold;
            this.btn_show_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_status.Location = new System.Drawing.Point(860, 25);
            this.btn_show_status.Name = "btn_show_status";
            this.btn_show_status.Size = new System.Drawing.Size(124, 34);
            this.btn_show_status.TabIndex = 3;
            this.btn_show_status.Text = "Show Status";
            this.btn_show_status.UseVisualStyleBackColor = false;
            this.btn_show_status.Click += new System.EventHandler(this.btn_show_status_Click);
            // 
            // DashboardVoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1006, 693);
            this.Controls.Add(this.btn_show_status);
            this.Controls.Add(this.panel1);
            this.Name = "DashboardVoter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardVoter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_vote_now;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_show_status;
    }
}