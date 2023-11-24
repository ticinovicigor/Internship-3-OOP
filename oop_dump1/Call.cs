using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_dump1
{
    public class Call
    {
        public Call(DateTime time, string status) 
        {
            Time = time;
            Status = status;
        }
        public DateTime Time { get; set; }
        public string Status { get; set; }
    }
}
