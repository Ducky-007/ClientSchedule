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
    public partial class reportsForm : Form
    {
        public reportsForm()
        {
            InitializeComponent();
        }

        private void reportsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            custRecordsForm custRecordsForm = new custRecordsForm();
            custRecordsForm.Show();
        }

        private void btnByMonth_Click(object sender, EventArgs e)
        {
            //BUTTON TO SHOW APPOINTMENTS TYPES COUNT BY MONTH
            //number of appointment types by month report
            try
            {
                DBConnection.OpenConnection();
                string query = "SELECT type, start from appointment";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                var allAppts = new List<dynamic>();

                while (reader.Read())
                {
                    allAppts.Add(new
                    {
                        Type = reader.GetString("type"),
                        Start = reader.GetDateTime("start").ToLocalTime()
                    });
                }
                reader.Close();

                //LAMBDA EXPRESSION TO GROUP APPOINTMENTS BY MONTH AND TYPE
                //GROUP BY MONTH AND YEAR then TYPE then count
                var reportData = allAppts
                    .GroupBy(a => new { Month = a.Start.ToString("MMMM"), Year = a.Start.Year, Type = a.Type })
                    .Select(g => new
                    {
                        Month = g.Key.Month,
                        Year = g.Key.Year,
                        Type = g.Key.Type,
                        Count = g.Count()
                    })
                    .OrderBy(r => r.Year).ThenBy(r => r.Month)
                    .ToList();

                reportDGV.DataSource = reportData;
                reportDGV.Columns["Month"].HeaderText = "Month";
                reportDGV.Columns["Year"].HeaderText = "Year";
                reportDGV.Columns["Type"].HeaderText = "Appointment Type";
                reportDGV.Columns["Count"].HeaderText = "Count";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            //BUTTON TO SHOW SCHEDULED APPOINTMENTS BY USER
            //need to get user, customer, appointment title, start, end
            try
            {
                DBConnection.OpenConnection();

                string query = "SELECT u.userName, a.title, a.start, a.end, c.customerName " +
                                "FROM appointment a " +
                                "JOIN user u ON a.userId = u.userId " +
                                "JOIN customer c on c.customerId = a.customerId";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                //create list to hold data
                var allAppts = new List<dynamic>();

                while (reader.Read())
                {
                    allAppts.Add(new
                    {
                        //convert time to local time
                        UserName = reader.GetString("userName"),
                        Title = reader.GetString("title"),
                        Customer = reader.GetString("customerName"),
                        Start = reader.GetDateTime("start").ToLocalTime(),
                        End = reader.GetDateTime("end").ToLocalTime()
                    });
                }
                reader.Close();

                //LAMBDA EXPRESSION TO GROUP APPOINTMENTS BY USER, THEN BY START TIME
                var reportData = allAppts
                    .OrderBy(a => a.UserName)
                    .ThenBy(a => a.Start)
                    .Select(a => new
                    {
                        User = a.UserName,
                        Appointment = a.Title,
                        Customer = a.Customer,
                        Start = a.Start,
                        End = a.End
                    })
                    .ToList();

                reportDGV.DataSource = reportData;

                reportDGV.Columns["User"].HeaderText = "User";
                reportDGV.Columns["Appointment"].HeaderText = "Appointment Title";
                reportDGV.Columns["Customer"].HeaderText = "Customer Name";
                reportDGV.Columns["Start"].HeaderText = "Start Time";
                reportDGV.Columns["End"].HeaderText = "End Time";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }

        private void btnCustCount_Click(object sender, EventArgs e)
        {
            //BUTTON TO SHOW CUSTOMER COUNT BY COUNTRY
            //need to get country
            try
            {
                DBConnection.OpenConnection();

                string query = "SELECT c.country " +
                               "FROM customer cust " +
                               "JOIN address a ON cust.addressId = a.addressId " +
                               "JOIN city ci ON a.cityId = ci.cityId " +
                               "JOIN country c ON ci.countryId = c.countryId";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                var allCustCountries = new List<string>();

                while (reader.Read())
                {
                    allCustCountries.Add(reader.GetString("country"));
                }
                reader.Close();

                //USE LAMBDA EXPRESSION TO GROUP CUSTOMERS BY COUNTRY AND COUNT
                var reportData = allCustCountries
                    .GroupBy(country => country)
                    .Select(group => new
                    {
                        Country = group.Key,
                        Count = group.Count()
                    })
                    .OrderByDescending(row => row.Count)
                    .ToList();

                reportDGV.DataSource = reportData;
                reportDGV.Columns["Country"].HeaderText = "Country";
                reportDGV.Columns["Count"].HeaderText = "Total Customers";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
    }
}
