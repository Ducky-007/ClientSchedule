using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Globalization;

namespace cameronDuckettClientSchedule
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            label3.Text = $"Current Loaction: {System.Globalization.RegionInfo.CurrentRegion.DisplayName}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // open connection
            DBConnection.OpenConnection();
            // test query
            string testQuery = "SELECT * FROM user";
            //execute query using the connection string
            MySqlCommand cmd = new MySqlCommand(testQuery, DBConnection.conn);
            //display results
            //create reader
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader["userName"] + " - " + reader["password"]);
            }
            //close connection
            DBConnection.CloseConnection();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void loginGroupBox_Enter(object sender, EventArgs e)
        {

        }

    }
}
