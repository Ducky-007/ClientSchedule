using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cameronDuckettClientSchedule
{
    public partial class custRecordsForm : Form
    {
        public custRecordsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check and ensure all text boxes are filled
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text) ||
                string.IsNullOrWhiteSpace(cityTextBox.Text) ||
                string.IsNullOrWhiteSpace(countryTextBox.Text) ||
                string.IsNullOrWhiteSpace(zipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
