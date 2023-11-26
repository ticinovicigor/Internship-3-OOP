using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_dump1
{
    public class Call
    {
        public Call(DateTime time, string status, int length) 
        {
            Time = time;
            Status = status;
            Length = length;
        }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public int Length { get; set; }

        
    }
}
