using cameronDuckettClientSchedule.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace cameronDuckettClientSchedule
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            // set label to display user location
            label3.Text = $"{Messages.label3}";
            label1.Text = Messages.label1;
            usernameLabel.Text = Messages.usernameLabel;
            pwLabel.Text = Messages.pwLabel;
            loginButton.Text = Messages.loginButton;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // open connection
            DBConnection.OpenConnection();

            // get username and password from text boxes
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            // create query to check for matching username and password
            string loginQuery = "SELECT * FROM user WHERE userName = @username AND password = @password";

            MySqlCommand cmd = new MySqlCommand(loginQuery, DBConnection.conn);

            //if username and password match, show messgage box saying login successful
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show($"{Messages.loginSuccess} {username}!");
                //set current user session username through userSession static class
                userSession.UserName = username;
                //open main form
                custRecordsForm custForm = new custRecordsForm();
                custForm.Show();

                //close login form
                this.Hide();
                //close connection
                DBConnection.CloseConnection();
            }
            else
            {
                MessageBox.Show($"{Messages.loginFail}");
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void loginGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
