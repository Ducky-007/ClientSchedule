using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;
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
    public partial class updateAppointmentForm : Form
    {
        string _custName;
        string _appointTitle;
        public updateAppointmentForm(string custName, string appointTitle)
        {
            InitializeComponent();
            _custName = custName;
            _appointTitle = appointTitle;
        }

        private void updateAppointmentForm_Load(object sender, EventArgs e)
        {
            DBConnection.OpenConnection();
            //get current values to place in text boxes as placeholders
            //description texbox placeholder
            string getAppDescQuery = "SELECT description FROM appointment WHERE title = @title";
            MySqlCommand getAppDescCmd = new MySqlCommand(getAppDescQuery, DBConnection.conn);
            getAppDescCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appDesc = Convert.ToString(getAppDescCmd.ExecuteScalar());

            //location textbox placeholder
            string getAppLocationQuery = "SELECT location FROM appointment WHERE title = @title";
            MySqlCommand getAppLocationCmd = new MySqlCommand(getAppLocationQuery, DBConnection.conn);
            getAppLocationCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appLocation = Convert.ToString(getAppLocationCmd.ExecuteScalar());

            //contact textbox placeholder
            string getAppContactQuery = "SELECT contact FROM appointment WHERE title = @title";
            MySqlCommand getAppContactCmd = new MySqlCommand(getAppContactQuery, DBConnection.conn);
            getAppContactCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appContact = Convert.ToString(getAppContactCmd.ExecuteScalar());

            //type textbox placeholder
            string getAppTypeQuery = "SELECT type FROM appointment WHERE title = @title";
            MySqlCommand getAppTypeCmd = new MySqlCommand(getAppTypeQuery, DBConnection.conn);
            getAppTypeCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appType = Convert.ToString(getAppTypeCmd.ExecuteScalar());

            //URL textbox placeholder
            string getAppURLQuery = "SELECT url FROM appointment WHERE title = @title";
            MySqlCommand getAppURLCmd = new MySqlCommand(getAppURLQuery, DBConnection.conn);
            getAppURLCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appURL = Convert.ToString(getAppURLCmd.ExecuteScalar());

            //start time textbox placeholder
            string getStartTimeQuery = "SELECT start FROM appointment WHERE title = @title";
            MySqlCommand getStartTimeCmd = new MySqlCommand(getStartTimeQuery, DBConnection.conn);
            getStartTimeCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appStartTime = Convert.ToString(getStartTimeCmd.ExecuteScalar());

            //end time textbox placeholder
            string getEndTimeQuery = "SELECT end FROM appointment WHERE title = @title";
            MySqlCommand getEndTimeCmd = new MySqlCommand(getEndTimeQuery, DBConnection.conn);
            getEndTimeCmd.Parameters.AddWithValue("@title", _appointTitle);
            string appEndTime = Convert.ToString(getEndTimeCmd.ExecuteScalar());
            DBConnection.CloseConnection();

            DateTime appointStartTime = Convert.ToDateTime(appStartTime);
            DateTime appointEndTime = Convert.ToDateTime(appEndTime);

            DateTime startUTC = DateTime.SpecifyKind(appointStartTime, DateTimeKind.Utc);
            DateTime endUTC = DateTime.SpecifyKind(appointEndTime, DateTimeKind.Utc);

            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEST = TimeZoneInfo.ConvertTimeFromUtc(startUTC, est);
            DateTime endEST = TimeZoneInfo.ConvertTimeFromUtc(endUTC, est);

            //add current values for each field in text box as placeholders when form loads so the user can see current values and update what they want
            custNameTextBox.Text = _custName;
            appointmentTitleTextBox.Text = _appointTitle;
            appointmentDescriptTextBox.Text = appDesc;
            appointmentLocTextBox.Text = appLocation;
            appointmentContactTextBox.Text = appContact;
            appointmentTypeTextBox.Text = appType;
            appointmentURLTextBox.Text = appURL;
            appointmentStartTextBox.Text = startEST.ToString();
            appointmentEndTextBox.Text = endEST.ToString();
        }

        private void addAppointBtn_Click(object sender, EventArgs e)
        {
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

                    //get current appointmentId to exclude from overlap check
                    string getCurrApptIdQuery = "SELECT appointmentId FROM appointment WHERE title = @title and userId = @userId";
                    MySqlCommand getCurrApptIdCmd = new MySqlCommand(getCurrApptIdQuery, DBConnection.conn);
                    getCurrApptIdCmd.Parameters.AddWithValue("@title", _appointTitle);
                    getCurrApptIdCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                    object currApptIdObj = getCurrApptIdCmd.ExecuteScalar();
                    int currApptId = Convert.ToInt32(currApptIdObj);

                    string overlapQuery = "SELECT COUNT(*) FROM appointment WHERE " +
                                          "(@start < end AND @end > start AND userID = @userId AND appointmentId != @currApptId)";
                    MySqlCommand checkCmd = new MySqlCommand(overlapQuery, DBConnection.conn);
                    checkCmd.Parameters.AddWithValue("@start", startUTC);
                    checkCmd.Parameters.AddWithValue("@end", endUTC);
                    checkCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                    checkCmd.Parameters.AddWithValue("@currApptId", currApptId);
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

                    //update appointment
                    string updateAppointmentQuery = "UPDATE appointment SET customerId = @customerId, userId = @userId, title = @title, " +
                                                    "description = @description, location = @location, contact = @contact, type = @type, " +
                                                    "url = @url, start = @start, end = @end, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy " +
                                                    "WHERE appointmentId = @currApptId";
                    MySqlCommand updateAppointmentCmd = new MySqlCommand(updateAppointmentQuery, DBConnection.conn);
                    updateAppointmentCmd.Parameters.AddWithValue("@customerId", customerId);
                    updateAppointmentCmd.Parameters.AddWithValue("@userId", userSession.UserId);
                    updateAppointmentCmd.Parameters.AddWithValue("@title", title);
                    updateAppointmentCmd.Parameters.AddWithValue("@description", description);
                    updateAppointmentCmd.Parameters.AddWithValue("@location", location);
                    updateAppointmentCmd.Parameters.AddWithValue("@contact", contact);
                    updateAppointmentCmd.Parameters.AddWithValue("@type", type);
                    updateAppointmentCmd.Parameters.AddWithValue("@url", url);
                    updateAppointmentCmd.Parameters.AddWithValue("@start", startUTC);
                    updateAppointmentCmd.Parameters.AddWithValue("@end", endUTC);
                    updateAppointmentCmd.Parameters.AddWithValue("@lastUpdateBy", userSession.UserName);
                    updateAppointmentCmd.Parameters.AddWithValue("@currApptId", currApptId);
                    updateAppointmentCmd.ExecuteNonQuery();
                    MessageBox.Show($"Appointment '{title}' updated successfully!");
                    custRecordsForm custForm = new custRecordsForm();
                    custForm.Show();
                    this.Close();
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
}
