using cameronDuckettClientSchedule.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace cameronDuckettClientSchedule
{
    internal static class Program
    {
        //create variable to hold user location
        public static string userLocation = System.Globalization.RegionInfo.CurrentRegion.DisplayName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////testing for Finnish phrase translations
            ////use thread to direct ui culture change to Finnish
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("fi-FI");
            ////thread for translating Finnish dates and numbers
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("fi-FI");

            Application.Run(new loginForm());
        }
    }
}
