using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Técnica.Model
{
    public class Company
    {
        public Company() { }
        public Company(string name, int code, string address, string phone, string city, string department, string country, DateTime dateAdded, DateTime dateModified)
        {
            Name = name;
            Code = code;
            Address = address;
            Phone = phone;
            City = city;
            Department = department;
            Country = country;
            DateAdded = dateAdded;
            DateModified = dateModified;
        }

        public int CompanyID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }

}
