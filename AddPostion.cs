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
        private static int noOfPositions = 0;
        public AddPostion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            positionTitle = tb_position.Text;
            description = tb_description.Text;

            if(positionTitle.Length > 50 || description.Length > 100)
            {
                MessageBox.Show("Title or Description is too long. Please limit to 50 and 200 characters respectively.");
                return;
            }

            if (string.IsNullOrEmpty(positionTitle) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            ++noOfPositions;
            MessageBox.Show("Position Added Successfully!");
            this.Close();
        }

        public void SetPositionTitle(string title)
        {
            tb_position.Text = title;
        }
        public void SetDescription(string desc)
        {
            tb_description.Text = desc;
        }
        public string GetPositionTitle()
        {
            return positionTitle;
        }
        public string GetDescription()
        {
            return description;
        }
        public void SetNoOfPositions(int no)
        {
            noOfPositions = no;
        }
        public int GetNoOfPositions()
        {
            return noOfPositions;
        }


    }
}
