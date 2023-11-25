using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_dump1
{
    public class Contact
    {
        public Contact(string name, string number, string pref) 
        {
            Name = name;
            Number = number;
            Preference = pref;
        }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Preference { get; set; }
    }
}
