using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class Address
    {
        //public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address(string address1, string address2, string postalCode, string city, string country) 
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.PostalCode = postalCode;
            this.Country = country;

        }
    }
}
