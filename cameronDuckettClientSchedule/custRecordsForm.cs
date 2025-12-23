using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;

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
            //variables for trimmed text box values
            string name = nameTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
            string city = cityTextBox.Text.Trim();
            string country = countryTextBox.Text.Trim();
            string zipCode = zipCodeTextBox.Text.Trim();
            string phoneNum = phoneNumTextBox.Text.Trim();

            //check and ensure all text boxes are filled
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(country) ||
                string.IsNullOrWhiteSpace(zipCode) ||
                string.IsNullOrWhiteSpace(phoneNum))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (!Regex.IsMatch(phoneNum, @"^[0-9-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
            }
            // open connection
            DBConnection.OpenConnection();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
