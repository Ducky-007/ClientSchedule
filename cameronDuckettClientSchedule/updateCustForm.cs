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
        public updateCustForm()
        {
            InitializeComponent();
        }

        private void updateCustForm_Load(object sender, EventArgs e)
        {
            //change custCurrInfo label to show current customer info
            custCurrInfo.Text = $"{custNameToUpdate}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void custCurrInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
