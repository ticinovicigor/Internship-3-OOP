using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_dump1
{
    public class Contact
    {
        public Contact(string name, string phone, string pref) 
        {
            Name = name;
            Phone = phone;
            Preference = pref;
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Preference { get; set; }
    }
}
