using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cameronDuckettClientSchedule
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateTime StartLocal
        {
            get
            {
                return Start.ToLocalTime();
            }
        }

        public DateTime EndLocal
        {
            get
            {
                return End.ToLocalTime();
            }
        }

        public string DisplayString
        {
            get
            {
                return $"{StartLocal:g} - {EndLocal:t}";
            }
        }
    } 
}
