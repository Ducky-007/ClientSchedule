using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cameronDuckettClientSchedule
{
    public partial class addAppointmentForm : Form
    {
        public addAppointmentForm()
        {
            InitializeComponent();
        }

        private void addAppointBtn_Click(object sender, EventArgs e)
        {
            string name = custNameTextBox.Text.Trim();
            string title = appointmentTitleTextBox.Text.Trim();
            string description = appointmentDescriptTextBox.Text.Trim();
            string location = appointmentLocTextBox.Text.Trim();
            string contact = appointmentContactTextBox.Text.Trim();
            string type = appointmentTypeTextBox.Text.Trim();
            string url = appointmentURLTextBox.Text.Trim();
            DateTime start;
            DateTime end;

            //validate if date time entered correctly
            bool isValidStart = DateTime.TryParse(appointmentStartTextBox.Text.Trim(), out start);
            bool isValidEnd = DateTime.TryParse(appointmentEndTextBox.Text.Trim(), out end);

            //if all fields are filled out, add appointment to database
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(contact) ||
                string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(url) ||
                !isValidStart ||
                !isValidEnd)
            {
                MessageBox.Show("Please fill out all fields with valid information.");
                return;
            }

            //appointments can only be scheduled Mon-Fri between 9am-5pm EST
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEST = TimeZoneInfo.ConvertTime(start, est);
            DateTime endEST = TimeZoneInfo.ConvertTime(end, est);

            //no weekend appointments
            if (startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday ||
                endEST.DayOfWeek == DayOfWeek.Saturday || endEST.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments can only be scheduled Monday through Friday.");
                return;
            }

            //no appointments before 9am or after 5pm EST
            TimeSpan openTime = new TimeSpan(9, 0, 0); //9:00 AM
            TimeSpan closeTime = new TimeSpan(17, 0, 0); //5:00 PM
            if (startEST.TimeOfDay < openTime || endEST.TimeOfDay > closeTime)
            {
                MessageBox.Show("Appointments can only be scheduled Monday - Friday between 9:00 AM and 5:00 PM EST.");
                return;
            }
            try
            {
                DBConnection.OpenConnection();

                //LOGIC: an appointment overlaps if its start time is before another appointment's end time
                //and its end time is after another appointment's start time
                //Convert to UTC as DB will store datetime as UTC
                DateTime startUTC = start.ToUniversalTime();
                DateTime endUTC = end.ToUniversalTime();

                string overlapQuery = "SELECT COUNT(*) FROM appointments WHERE " +
                                      "(@start < end AND @end > start AND userID = @userId)";
                MySqlCommand checkCmd = new MySqlCommand(overlapQuery, DBConnection.conn);
                checkCmd.Parameters.AddWithValue("@start", startUTC);
                checkCmd.Parameters.AddWithValue("@end", endUTC);
                checkCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show($"This time slot overlaps with an existing appointment. Please pick another time slot");
                    return;
                }

                //insert appointment to appointment table
                //get customerId
                string customerIdQuery = "SELECT customerId FROM customer WHERE customername = @name";
                MySqlCommand customerCmd = new MySqlCommand(customerIdQuery, DBConnection.conn);
                customerCmd.Parameters.AddWithValue("@name", name);
                object customer = customerCmd.ExecuteScalar();
                if (customer == null)
                {
                    MessageBox.Show($"Customer not found. Please verify you entered the correct customer name.");
                    return;
                }
                int customerId = Convert.ToInt32(customer);

                //insert appointment
                string insertAppointmentQuery = "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                                "VALUES(@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, NOW(), @createdBy, NOW(), @lastUpdateBy)";
                MySqlCommand insertAppointmentCmd = new MySqlCommand(insertAppointmentQuery, DBConnection.conn);
                insertAppointmentCmd.Parameters.AddWithValue("@customerId", customerId);
                insertAppointmentCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                insertAppointmentCmd.Parameters.AddWithValue("@title", title);
                insertAppointmentCmd.Parameters.AddWithValue("@description", description);
                insertAppointmentCmd.Parameters.AddWithValue("@location", location);
                insertAppointmentCmd.Parameters.AddWithValue("@contact", contact);
                insertAppointmentCmd.Parameters.AddWithValue("@type", type);
                insertAppointmentCmd.Parameters.AddWithValue("@url", url);
                insertAppointmentCmd.Parameters.AddWithValue("@start", startUTC);
                insertAppointmentCmd.Parameters.AddWithValue("@end", endUTC);
                insertAppointmentCmd.Parameters.AddWithValue("@createdBy", userSession.UserName);
                insertAppointmentCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                insertAppointmentCmd.ExecuteNonQuery();
                MessageBox.Show($"Appointment '{title}' added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
                return;
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
    }
}
