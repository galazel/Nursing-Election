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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lb_choose_candidate = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(31, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(298, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lb_choose_candidate
            // 
            this.lb_choose_candidate.AutoSize = true;
            this.lb_choose_candidate.Location = new System.Drawing.Point(28, 27);
            this.lb_choose_candidate.Name = "lb_choose_candidate";
            this.lb_choose_candidate.Size = new System.Drawing.Size(94, 13);
            this.lb_choose_candidate.TabIndex = 1;
            this.lb_choose_candidate.Text = "Choose Candidate";
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(254, 101);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 2;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            // 
            // ChooseCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 145);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.lb_choose_candidate);
            this.Controls.Add(this.comboBox1);
            this.Name = "ChooseCandidate";
            this.Text = "ChooseCandidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lb_choose_candidate;
        private System.Windows.Forms.Button btn_confirm;
    }
}