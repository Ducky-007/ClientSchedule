using cameronDuckettClientSchedule.Database;
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
                MessageBox.Show("Appointments can only be scheduled between 9:00 AM and 5:00 PM EST.");
                return;
            }
            try
            {
                DBConnection.OpenConnection();

                //TODO: Check for overlapping appointments for the same customer
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
