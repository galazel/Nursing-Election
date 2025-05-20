namespace Nursing_Election
{
    partial class VoteNow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoteNow));
            this.btn_vote_now = new System.Windows.Forms.Button();
            this.fp_vote = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_vote_now
            // 
            this.btn_vote_now.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_vote_now.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_vote_now.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vote_now.ForeColor = System.Drawing.Color.White;
            this.btn_vote_now.Location = new System.Drawing.Point(221, 432);
            this.btn_vote_now.Name = "btn_vote_now";
            this.btn_vote_now.Size = new System.Drawing.Size(207, 34);
            this.btn_vote_now.TabIndex = 27;
            this.btn_vote_now.Text = "SUBMIT";
            this.btn_vote_now.UseVisualStyleBackColor = false;
            this.btn_vote_now.Click += new System.EventHandler(this.btn_vote_now_Click);
            // 
            // fp_vote
            // 
            this.fp_vote.AutoScroll = true;
            this.fp_vote.Location = new System.Drawing.Point(12, 56);
            this.fp_vote.Name = "fp_vote";
            this.fp_vote.Size = new System.Drawing.Size(639, 370);
            this.fp_vote.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(189, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "STUDENT ELECTION BALLOT";
            // 
            // VoteNow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 478);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fp_vote);
            this.Controls.Add(this.btn_vote_now);
            this.DoubleBuffered = true;
            this.Name = "VoteNow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoteNow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_vote_now;
        private System.Windows.Forms.FlowLayoutPanel fp_vote;
        private System.Windows.Forms.Label label1;
    }
}