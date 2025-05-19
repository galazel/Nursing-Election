namespace Nursing_Election
{
    partial class ChooseCandidate
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
            this.lb_choose_candidate = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.cb_choose_candidate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb_choose_candidate
            // 
            this.lb_choose_candidate.AutoSize = true;
            this.lb_choose_candidate.Location = new System.Drawing.Point(40, 28);
            this.lb_choose_candidate.Name = "lb_choose_candidate";
            this.lb_choose_candidate.Size = new System.Drawing.Size(94, 13);
            this.lb_choose_candidate.TabIndex = 1;
            this.lb_choose_candidate.Text = "Choose Candidate";
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(132, 93);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 2;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // cb_choose_candidate
            // 
            this.cb_choose_candidate.FormattingEnabled = true;
            this.cb_choose_candidate.Location = new System.Drawing.Point(43, 57);
            this.cb_choose_candidate.Name = "cb_choose_candidate";
            this.cb_choose_candidate.Size = new System.Drawing.Size(255, 21);
            this.cb_choose_candidate.TabIndex = 3;
            this.cb_choose_candidate.SelectedIndexChanged += new System.EventHandler(this.cb_choose_candidate_SelectedIndexChanged);
            // 
            // ChooseCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 151);
            this.Controls.Add(this.cb_choose_candidate);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.lb_choose_candidate);
            this.Name = "ChooseCandidate";
            this.Text = "ChooseCandidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_choose_candidate;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.ComboBox cb_choose_candidate;
    }
}