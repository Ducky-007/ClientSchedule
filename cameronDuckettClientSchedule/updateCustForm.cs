using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;
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

namespace cameronDuckettClientSchedule
{
    public partial class updateCustForm : Form
    {
        //call value of custNameToUpdate from mainForm
        string _custName;
        int custId;
        public updateCustForm(string custName)
        {
            InitializeComponent();
            _custName = custName;
        }

        private void updateCustForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"UPDATE {_custName.ToUpper()}'S INFORMATION";
            custCurrInfo.Text = $"Enter Information into all fields to update for {_custName}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void custCurrInfo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void UpdateCustBtn_Click(object sender, EventArgs e)
        {
            //if any textboxes are empty, do nothing
            string name = custNameTextBox.Text.Trim();
            string address = custAddressTextBox.Text.Trim();
            string city = custCityTextBox.Text.Trim();
            string zip = custZipTextBox.Text.Trim();
            string country = countryTextBox.Text.Trim();
            string phone = custPhoneTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(zip) ||
                string.IsNullOrWhiteSpace(country) ||
                string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show($"Enter values into all fields!");
            }
            if (!Regex.IsMatch(phone, @"^[0-9-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
            }

            //run query to insert values into each table accordingly
            //start with countryId
            DBConnection.OpenConnection();
            string getCountryIdQuery = $"SELECT countryId from country where country = {country}";
            MySqlCommand countryIdCmd = new MySqlCommand(getCountryIdQuery, DBConnection.conn);
            //create reader to finish query
        }
    }
}

