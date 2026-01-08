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

            try
            {
                //run query to insert values into each table accordingly
                //start with countryId
                DBConnection.OpenConnection();
                string getCountryIdQuery = "SELECT countryId from country where country = @country";
                MySqlCommand countryIdCmd = new MySqlCommand(getCountryIdQuery, DBConnection.conn);
                countryIdCmd.Parameters.AddWithValue("@country", country);
                MySqlDataReader countryIdReader = countryIdCmd.ExecuteReader();
                int countryId = 0;
                if (countryIdReader.Read())
                {
                    countryId = countryIdReader.GetInt32("countryId");
                    countryIdReader.Close();
                }
                else
                {
                    //add country if it doesn't exist
                    countryIdReader.Close();
                    string insertCountryQuery = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        $"VALUES (@country, NOW(), @createdBy, NOW(), @lastUpdateBy)";
                    MySqlCommand insertCountryCmd = new MySqlCommand(insertCountryQuery, DBConnection.conn);
                    insertCountryCmd.Parameters.AddWithValue("@country", country);
                    insertCountryCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    insertCountryCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    insertCountryCmd.ExecuteNonQuery();
                    countryId = (int)insertCountryCmd.LastInsertedId;
                }

                //check city
                int cityId = 0;
                string getCityIdQuery = "SELECT cityId from city where city = @city";
                MySqlCommand getCityId = new MySqlCommand(getCityIdQuery, DBConnection.conn);
                getCityId.Parameters.AddWithValue("@city", city);
                MySqlDataReader cityIdReader = getCityId.ExecuteReader();
                if (cityIdReader.Read())
                {
                    cityId = cityIdReader.GetInt32("cityId");
                    cityIdReader.Close();
                }
                else
                {
                    //add city if it doesn't exist
                    cityIdReader.Close();
                    string insertCityQuery = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        $"VALUES (@city, @countryId, NOW(), @createdBy, NOW(), @lastUpdateBy)";
                    MySqlCommand insertCityCmd = new MySqlCommand(insertCityQuery, DBConnection.conn);
                    insertCityCmd.Parameters.AddWithValue("@city", city);
                    insertCityCmd.Parameters.AddWithValue("@countryId", countryId);
                    insertCityCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    insertCityCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    insertCityCmd.ExecuteNonQuery();
                    cityId = (int)insertCityCmd.LastInsertedId;
                }

                //check address
                int addressId = 0;
                int addressIdtoDel = 0;
                string getAddressIdQuery = "SELECT addressId from address where address = @address";
                MySqlCommand getAddressId = new MySqlCommand(getAddressIdQuery, DBConnection.conn);
                getAddressId.Parameters.AddWithValue("@address", address);
                MySqlDataReader addressIdReader = getAddressId.ExecuteReader();
                if (addressIdReader.Read())
                {
                    addressId = addressIdReader.GetInt32("addressId");
                    //copy addressId to use to delete once cust is updated
                    addressIdtoDel = addressIdReader.GetInt32("addressId");
                    addressIdReader.Close();
                }
                else
                {
                    //add address if it doesn't exist
                    addressIdReader.Close();
                    string insertAddressQuery = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        $"VALUES (@address, '', @cityId, @postalCode, @phone, NOW(), @createdBy, NOW(), @lastUpdateBy)";
                    MySqlCommand insertAddressCmd = new MySqlCommand(insertAddressQuery, DBConnection.conn);
                    insertAddressCmd.Parameters.AddWithValue("@address", address);
                    insertAddressCmd.Parameters.AddWithValue("@cityId", cityId);
                    insertAddressCmd.Parameters.AddWithValue("@postalCode", zip);
                    insertAddressCmd.Parameters.AddWithValue("@phone", phone);
                    insertAddressCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    insertAddressCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    insertAddressCmd.ExecuteNonQuery();
                    addressId = (int)insertAddressCmd.LastInsertedId;
                }

                //finally, update customer info
                string updateCustomerQuery = "UPDATE customer SET customerName = @customerName, addressId = @addressId, " +
                    "active = 1, createDate = NOW(), createdBy = @lastUpdateBy, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy WHERE customerName = @oldCustomerName";
                MySqlCommand updateCustomerCmd = new MySqlCommand(updateCustomerQuery, DBConnection.conn);
                updateCustomerCmd.Parameters.AddWithValue("@customerName", name);
                updateCustomerCmd.Parameters.AddWithValue("@addressId", addressId);
                updateCustomerCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                updateCustomerCmd.Parameters.AddWithValue("@oldCustomerName", _custName);
                updateCustomerCmd.ExecuteNonQuery();
                MessageBox.Show($"Customer {_custName} updated successfully to {name}!");

                //FIGURE OUT A WAY TO DELETE OLD ADDRESS IF NO OTHER CUSTOMER USES IT
                //delete old address
                string delOldAddressQuery = "DELETE FROM address WHERE addressId = @oldAddressId";
                MySqlCommand delAddressCmd = new MySqlCommand(delOldAddressQuery, DBConnection.conn);
                delAddressCmd.Parameters.AddWithValue("oldAddressId", addressIdtoDel);
                delAddressCmd.ExecuteNonQuery();
                MessageBox.Show($"Old address '{addressIdtoDel}' now deleted from database!");

                this.Close();
                custRecordsForm custForm = new custRecordsForm();
                custForm.Show();
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
    }
}

