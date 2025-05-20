namespace Nursing_Election
{
    partial class EditLevelBlock
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_level = new System.Windows.Forms.TextBox();
            this.tb_block = new System.Windows.Forms.TextBox();
            this.btn_confirm_edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block";
            // 
            // tb_level
            // 
            this.tb_level.Location = new System.Drawing.Point(112, 19);
            this.tb_level.Name = "tb_level";
            this.tb_level.Size = new System.Drawing.Size(188, 20);
            this.tb_level.TabIndex = 2;
            // 
            // tb_block
            // 
            this.tb_block.Location = new System.Drawing.Point(112, 54);
            this.tb_block.Name = "tb_block";
            this.tb_block.Size = new System.Drawing.Size(188, 20);
            this.tb_block.TabIndex = 3;
            // 
            // btn_confirm_edit
            // 
            this.btn_confirm_edit.Location = new System.Drawing.Point(225, 98);
            this.btn_confirm_edit.Name = "btn_confirm_edit";
            this.btn_confirm_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm_edit.TabIndex = 4;
            this.btn_confirm_edit.Text = "Save";
            this.btn_confirm_edit.UseVisualStyleBackColor = true;
            this.btn_confirm_edit.Click += new System.EventHandler(this.btn_confirm_edit_Click);
            // 
            // EditLevelBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 133);
            this.Controls.Add(this.btn_confirm_edit);
            this.Controls.Add(this.tb_block);
            this.Controls.Add(this.tb_level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditLevelBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditLevelBlock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_level;
        private System.Windows.Forms.TextBox tb_block;
        private System.Windows.Forms.Button btn_confirm_edit;
    }
}