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
        //create dailyAppts binding list to hold daily appointments
        BindingList<Appointment> dailyAppts = new BindingList<Appointment>();
        public custRecordsForm()
        {
            InitializeComponent();

            //bind empty list to dailyAppts on load
            //set the list as the data source for the data grid view
            dataGridView1.DataSource = dailyAppts;

            //create custom columns for dgv
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            //maunally set columns
            //col for appt type
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.DataPropertyName = "Type";
            typeCol.HeaderText = "Type";
            dataGridView1.Columns.Add(typeCol);

            //col for customer name
            DataGridViewTextBoxColumn custNameCol = new DataGridViewTextBoxColumn();
            custNameCol.DataPropertyName = "CustomerName";
            custNameCol.HeaderText = "Customer Name";
            dataGridView1.Columns.Add(custNameCol);

            //col for start time calling the local conversion from appointment class for start time
            DataGridViewTextBoxColumn startCol = new DataGridViewTextBoxColumn();
            startCol.DataPropertyName = "StartLocal";
            startCol.HeaderText = "Start Time";
            dataGridView1.Columns.Add(startCol);

            //col for end time calling the local conversion from appointment class for end time
            DataGridViewTextBoxColumn endCol = new DataGridViewTextBoxColumn();
            endCol.DataPropertyName = "EndLocal";
            endCol.HeaderText = "End Time";
            dataGridView1.Columns.Add(endCol);
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
                return;
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
            //create alert if user logs in and has an appointment within 15 minutes
            //create function to call the alert on load
            CheckUpcomingAppts();
        }

        private void CheckUpcomingAppts()
        {
            try
            {
                DBConnection.OpenConnection();

                //query database for user for any appts that start now - now + 15 minutes
                //use UTC time for comparison as that's how data is stored in database
                DateTime utcNow = DateTime.UtcNow;
                DateTime utcNowPlus15 = utcNow.AddMinutes(15);

                string upcomingApptQuery = "SELECT a.appointmentId, a.title, a.start, c.customerName " +
                                           "FROM appointment a " +
                                           "JOIN customer c on a.customerId = c.customerId " +
                                           "WHERE a.userId = @userId " +
                                           "AND a.start BETWEEN @now AND @nowPlus15;";
                MySqlCommand upcomingApptCmd = new MySqlCommand(upcomingApptQuery, DBConnection.conn);
                upcomingApptCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                upcomingApptCmd.Parameters.AddWithValue("@now", utcNow);
                upcomingApptCmd.Parameters.AddWithValue("@nowPlus15", utcNowPlus15);
                MySqlDataReader upcomingApptReader = upcomingApptCmd.ExecuteReader();
                if (upcomingApptReader.HasRows)
                {
                    while (upcomingApptReader.Read()) 
                    {
                        string customerName = upcomingApptReader.GetString("customerName");
                        DateTime startTimeUtc = upcomingApptReader.GetDateTime("start");
                        DateTime startLocal = startTimeUtc.ToLocalTime();

                        MessageBox.Show($"You have an upcoming appointment ({upcomingApptReader.GetString("title")}) " +
                                        $"with {customerName} at {startLocal:t}.");
                    }
                }
                else
                {
                    MessageBox.Show("You have no appointments within the next 15 minutes.");
                }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string custNameToUpdate = custUpdateTextBox.Text.Trim();
            //if name is in database, open update customer form
            //query database to ensure name is already in customer table, if not don't open form
            try
            {
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

        private void addAppointBtn_Click(object sender, EventArgs e)
        {
            //open add appointment form
            addAppointmentForm addAppForm = new addAppointmentForm();
            addAppForm.Show();
            this.Hide();
        }

        private void delAppointBtn_Click(object sender, EventArgs e)
        {
            //ADD delete button based on appointment selected in data grid view
            //check if row is selected in data grid view
            if (dataGridView1.CurrentRow == null || !dataGridView1.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            //get object from the selected row
            //use data bound item to get the actual selected row to an appointment object
            Appointment selectedAppt = dataGridView1.CurrentRow.DataBoundItem as Appointment;

            //safety check just in case
            if (selectedAppt == null) return;

            //get apptId from the selected appointment object
            int apptId = selectedAppt.AppointmentId;

            //delete appointment from database based on apptId
            try
            {
                DBConnection.OpenConnection();
                string deleteApptQuery = "DELETE FROM appointment WHERE appointmentId = @apptId;";
                MySqlCommand deleteApptCmd = new MySqlCommand(deleteApptQuery, DBConnection.conn);
                deleteApptCmd.Parameters.AddWithValue("@apptId", apptId);
                deleteApptCmd.ExecuteNonQuery();
                MessageBox.Show($"Appointment '{selectedAppt.Title}' deleted successfully!");

                //remove appointment from dailyAppts binding list to update data grid view
                dailyAppts.Remove(selectedAppt);
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

        private void updateAppointBtn_Click(object sender, EventArgs e)
        {
            string nameUpdate = nameToUpdate.Text.Trim();
            string titleUpdate = titleToUpdate.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(nameUpdate) || string.IsNullOrWhiteSpace(titleUpdate))
                {
                    MessageBox.Show("Please enter both customer name and appointment title to update an appointment.");
                    return;
                }

                //ensure there is an appointment in the database that matches the customer name and appointment title and userId before opening update appointment form
                DBConnection.OpenConnection();
                string appointExistQuery = "SELECT a.appointmentId FROM appointment a " +
                                           "JOIN customer c ON a.customerId = c.customerId " +
                                           "WHERE c.customerName = @customerName AND a.title = @appointmentTitle " +
                                           "AND a.userId = @userId;";
                MySqlCommand appointCheckCmd = new MySqlCommand(appointExistQuery, DBConnection.conn);
                appointCheckCmd.Parameters.AddWithValue("@customerName", nameUpdate);
                appointCheckCmd.Parameters.AddWithValue("@appointmentTitle", titleUpdate);
                appointCheckCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                MySqlDataReader reader = appointCheckCmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show($"No appointment found for customer '{nameUpdate}' with title '{titleUpdate}'.");
                    return;
                }
                reader.Read();
                int foundApptId = reader.GetInt32("appointmentId");
                reader.Close();

                //open update appointment form
                updateAppointmentForm updateAppForm = new updateAppointmentForm(nameUpdate, titleUpdate, foundApptId);
                updateAppForm.Show();
                this.Hide();
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

        private void titleToUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            //query database for appointments on selected date (use start of day and end of day for selected date)
            //convert DB times with TimeZone

            try
            {
                DBConnection.OpenConnection();

                string dailyApptQuery = "SELECT a.appointmentId, c.customerName, a.customerId, a.userId, a.title, a.description, a.location, " +
                    "a.contact, a.type, a.url, a.start, a.end " +
                    "FROM appointment a " +
                    "JOIN customer c ON a.customerId = c.customerId " +
                    "WHERE a.start >= @startDay AND a.start < @endDay " +
                    "AND a.userId = @userId;";
                MySqlCommand dailyApptCmd = new MySqlCommand(dailyApptQuery, DBConnection.conn);
                dailyApptCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                dailyApptCmd.Parameters.AddWithValue("@startDay", selectedDate.Date);
                dailyApptCmd.Parameters.AddWithValue("@endDay", selectedDate.Date.AddDays(1));
                MySqlDataReader dailyApptReader = dailyApptCmd.ExecuteReader();
                dailyAppts.Clear();

                while (dailyApptReader.Read())
                {
                    Appointment appt = new Appointment
                    {
                        AppointmentId = dailyApptReader.GetInt32("appointmentId"),
                        CustomerId = dailyApptReader.GetInt32("customerId"),
                        CustomerName = dailyApptReader.GetString("customerName"),
                        Title = dailyApptReader.GetString("title"),
                        Description = dailyApptReader.GetString("description"),
                        Type = dailyApptReader.GetString("type"),
                        Start = dailyApptReader.GetDateTime("start"),
                        End = dailyApptReader.GetDateTime("end")
                    };
                    dailyAppts.Add(appt);
                }
                dailyApptReader.Close();
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

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            reportsForm reportsForm = new reportsForm();
            reportsForm.Show();
        }
    }
}
