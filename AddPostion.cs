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
    public partial class AddPostion : Form
    {
        private string positionTitle, description;
        public AddPostion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            positionTitle = tb_position.Text;
            description = tb_description.Text;
            if (string.IsNullOrEmpty(positionTitle) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            MessageBox.Show("Position Added Successfully!");
            this.Close();
        }
        public string GetPositionTitle()
        {
            return positionTitle;
        }
        public string GetDescription()
        {
            return description;
        }


    }
}
