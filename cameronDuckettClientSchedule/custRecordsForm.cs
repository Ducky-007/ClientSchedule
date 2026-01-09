using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
            //ADDING CUSTOMER BUTTON FUNCTIONALITY

            //variables for trimmed text box values
            string name = nameTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
            string city = cityTextBox.Text.Trim();
            string country = countryTextBox.Text.Trim();
            string zipCode = zipCodeTextBox.Text.Trim();
            string phoneNum = phoneNumTextBox.Text.Trim();
            int countryId = 0;
            int cityId = 0;
            int addressId = 0;

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
            //allow only digits and dashes in phone number field
            if (!Regex.IsMatch(phoneNum, @"^[0-9-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
            }
            try
            {
                // open connection
                DBConnection.OpenConnection();

                //if country does not exist in database, insert it else get countryId from database
                //select couuntryId from country table where country matches text box value entered in country text box
                string countrySelectQuery = "SELECT countryId FROM country WHERE country = @country;";

                //sql command to select/check countryId in country table
                MySqlCommand countryCmd = new MySqlCommand(countrySelectQuery, DBConnection.conn);

                //add country parameter to sql command with value from country text box
                countryCmd.Parameters.AddWithValue("@country", country);

                //execute sql command and read results
                MySqlDataReader countryReader = countryCmd.ExecuteReader();
                //if countryReader has rows, country exists in database
                if (countryReader.HasRows)
                {
                    //get countryId from database
                    countryReader.Read();
                    countryId = countryReader.GetInt32("countryId");
                    countryReader.Close();
                }
                //if country does not exist in database, insert it into country table
                else
                {
                    countryReader.Close();
                    //insert country into country table
                    string countryInsertQuery = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        "VALUES (@country, NOW(), @createdBy, NOW(), @lastUpdateBy);";
                    MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertQuery, DBConnection.conn);
                    countryInsertCmd.Parameters.AddWithValue("@country", country);
                    countryInsertCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    countryInsertCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    countryInsertCmd.ExecuteNonQuery();

                    //get the newly inserted countryId and save it as countryId
                    string getCountryIdQuery = "SELECT LAST_INSERT_ID() AS countryId;";
                    MySqlCommand getCountryIdCmd = new MySqlCommand(getCountryIdQuery, DBConnection.conn);
                    MySqlDataReader getCountryIdReader = getCountryIdCmd.ExecuteReader();
                    getCountryIdReader.Read();
                    countryId = getCountryIdReader.GetInt32("countryId");
                    getCountryIdReader.Close();
                }

                //if city doesn't exist in city table, insert it else get cityId from database
                //check and see if city exists in city table with matching city name and countryId

                //create sql command to select cityId from city table where city and countryId match text box value and retrieved countryId from Country text box
                string citySelectQuery = "SELECT cityId FROM city WHERE city = @city AND countryId = @countryId;";
                MySqlCommand cityCmd = new MySqlCommand(citySelectQuery, DBConnection.conn);
                cityCmd.Parameters.AddWithValue("@city", city);
                cityCmd.Parameters.AddWithValue("@countryId", countryId);
                MySqlDataReader cityReader = cityCmd.ExecuteReader();

                //if city exists in database with the same name and countryId, get cityId
                if (cityReader.HasRows)
                {
                    cityReader.Read();
                    cityId = cityReader.GetInt32("cityId");
                    cityReader.Close();
                }
                //else insert city into city table
                else
                {
                    cityReader.Close();
                    //insert city into city table
                    string cityInsertQuery = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        "VALUES (@city, @countryId, NOW(), @createdBy, NOW(), @lastUpdateBy);";
                    MySqlCommand cityInsertCmd = new MySqlCommand(cityInsertQuery, DBConnection.conn);
                    cityInsertCmd.Parameters.AddWithValue("@city", city);
                    cityInsertCmd.Parameters.AddWithValue("@countryId", countryId);
                    cityInsertCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    cityInsertCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    cityInsertCmd.ExecuteNonQuery();
                    //get the newly inserted cityId and assign it as cityId
                    string getCityIdQuery = "SELECT LAST_INSERT_ID() AS cityId;";
                    MySqlCommand getCityIdCmd = new MySqlCommand(getCityIdQuery, DBConnection.conn);
                    MySqlDataReader getCityIdReader = getCityIdCmd.ExecuteReader();
                    getCityIdReader.Read();
                    cityId = getCityIdReader.GetInt32("cityId");
                    getCityIdReader.Close();
                }

                //logic for address table
                string addressSelectQuery = "SELECT addressId FROM address WHERE address = @address AND cityId = @cityId " +
                    "AND postalCode = @postalCode ";
                MySqlCommand addressCmd = new MySqlCommand(addressSelectQuery, DBConnection.conn);
                addressCmd.Parameters.AddWithValue("@address", address);
                addressCmd.Parameters.AddWithValue("@cityId", cityId);
                addressCmd.Parameters.AddWithValue("@postalCode", zipCode);
                MySqlDataReader addressReader = addressCmd.ExecuteReader();
                if (addressReader.HasRows)
                {
                    addressReader.Read();
                    addressId = addressReader.GetInt32("addressId");
                    addressReader.Close();
                }
                else
                {
                    addressReader.Close();
                    //insert address into address table
                    string addressInsertQuery = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        "VALUES (@address, '', @cityId, @postalCode, @phone, NOW(), @createdBy, NOW(), @lastUpdateBy);";
                    MySqlCommand addressInsertCmd = new MySqlCommand(addressInsertQuery, DBConnection.conn);
                    addressInsertCmd.Parameters.AddWithValue("@address", address);
                    addressInsertCmd.Parameters.AddWithValue("@cityId", cityId);
                    addressInsertCmd.Parameters.AddWithValue("@postalCode", zipCode);
                    addressInsertCmd.Parameters.AddWithValue("@phone", phoneNum);
                    addressInsertCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    addressInsertCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    addressInsertCmd.ExecuteNonQuery();
                    //get the newly inserted addressId and assign it as addressId
                    string getAddressIdQuery = "SELECT LAST_INSERT_ID() AS addressId;";
                    MySqlCommand getAddressIdCmd = new MySqlCommand(getAddressIdQuery, DBConnection.conn);
                    MySqlDataReader getAddressIdReader = getAddressIdCmd.ExecuteReader();
                    getAddressIdReader.Read();
                    addressId = getAddressIdReader.GetInt32("addressId");
                    getAddressIdReader.Close();
                }

                //insert text in name field to database using SQL command
                string nameSelectQuery = "SELECT customerName FROM customer WHERE customerName = @name AND addressId = @addressId;";
                MySqlCommand nameSelectCmd = new MySqlCommand(nameSelectQuery, DBConnection.conn);
                nameSelectCmd.Parameters.AddWithValue("@name", name);
                nameSelectCmd.Parameters.AddWithValue("@addressId", addressId);
                MySqlDataReader nameSelectReader = nameSelectCmd.ExecuteReader();
                if (nameSelectReader.HasRows)
                {
                    nameSelectReader.Read();
                    MessageBox.Show("Customer already exists in database.");
                    nameSelectReader.Close();
                }
                else
                {
                    nameSelectReader.Close();
                    string nameInsertQuery = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        "VALUES (@name, @addressId, 1, NOW(), @createdBy, NOW(), @lastUpdateBy);";
                    MySqlCommand nameInsertCmd = new MySqlCommand(nameInsertQuery, DBConnection.conn);
                    nameInsertCmd.Parameters.AddWithValue("@name", name);
                    nameInsertCmd.Parameters.AddWithValue("@addressId", addressId);
                    nameInsertCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                    nameInsertCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    nameInsertCmd.ExecuteNonQuery();
                    MessageBox.Show($"{name} added successfully to Customer Database!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                //close database connection
                DBConnection.CloseConnection();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cityLabel_Click(object sender, EventArgs e)
        {

        }

        private void deleteCustBtn_Click(object sender, EventArgs e)
        {
            //DELETE CUSTOMER BUTTON FUNCTIONALITY
            string custNameToDelete = custDelTextBox.Text.Trim();
            int addressIdToDelete = 0;

            if (string.IsNullOrWhiteSpace(custNameToDelete))
            {
                MessageBox.Show("Please enter a customer name to delete.");
                return;
            }
            DBConnection.OpenConnection();
            try
            {
                //get addressId associated with the customer to delete
                string getAddressIdQuery = "SELECT addressId FROM customer WHERE customerName = @custName;";
                MySqlCommand getAddressIdCmd = new MySqlCommand(getAddressIdQuery, DBConnection.conn);
                getAddressIdCmd.Parameters.AddWithValue("@custName", custNameToDelete);
                MySqlDataReader addressIdReader = getAddressIdCmd.ExecuteReader();
                if (addressIdReader.HasRows)
                {
                    addressIdReader.Read();
                    addressIdToDelete = addressIdReader.GetInt32("addressId");
                    addressIdReader.Close();
                }
                else
                {
                    addressIdReader.Close();
                    MessageBox.Show($"Customer '{custNameToDelete}' not found in the database.");
                    return;
                }

                //delete customer from customer table
                string deleteCustQuery = "DELETE FROM customer Where customerName = @custName;";
                MySqlCommand deleteCustCmd = new MySqlCommand(deleteCustQuery, DBConnection.conn);
                deleteCustCmd.Parameters.AddWithValue("@custName", custNameToDelete);
                deleteCustCmd.ExecuteNonQuery();

                //delete address from address table
                string deleteAddressQuery = "DELETE FROM address WHERE addressId = @addressId;";
                MySqlCommand deleteAddressCmd = new MySqlCommand(deleteAddressQuery, DBConnection.conn);
                deleteAddressCmd.Parameters.AddWithValue("@addressId", addressIdToDelete);
                deleteAddressCmd.ExecuteNonQuery();
                MessageBox.Show($"Customer '{custNameToDelete}' and associated address(es) deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void custDelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void custRecordsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string custNameToUpdate = custUpdateTextBox.Text.Trim();
            //if name is in database, open update customer form
            //query database to ensure name is already in customer table, if not don't open form
            DBConnection.OpenConnection();
            string nameExistQuery = "SELECT customerName FROM customer" +
                                     " WHERE customerName = @customerName;";
            MySqlCommand nameCheckCmd = new MySqlCommand(nameExistQuery, DBConnection.conn);
            nameCheckCmd.Parameters.AddWithValue("customerName", custNameToUpdate);
            MySqlDataReader reader = nameCheckCmd.ExecuteReader();
            if (reader.HasRows)
            {
                updateCustForm updateForm = new updateCustForm(custNameToUpdate);
                updateForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show($"Customer '{custNameToUpdate}' does not exist in the database.");
            }
            DBConnection.CloseConnection();
        }

        private void addAppointBtn_Click(object sender, EventArgs e)
        {
            //open add appointment form
            addAppointmentForm addAppForm = new addAppointmentForm();
            addAppForm.Show();
            this.Hide();
        }
    }
}
