using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nursing_Election
{
    public partial class EditLevelBlock : Form
    {

        private int level;
        private string block;
        public EditLevelBlock(int level, string block)
        {
            InitializeComponent();
            this.level = level;
            this.block = block;
        }
        public int GetLevel()
        {
            return int.Parse(tb_level.Text); 
        }

        public string GetBlock()
        {
            return tb_block.Text.Trim(); 
        }

        private void btn_confirm_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_level.Text) || string.IsNullOrWhiteSpace(tb_block.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
