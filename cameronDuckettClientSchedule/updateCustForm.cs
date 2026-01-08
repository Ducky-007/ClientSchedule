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
            custCurrInfo.Text = $"You are editing {_custName}'s information!";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void custCurrInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
