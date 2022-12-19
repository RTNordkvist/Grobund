using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Data.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime Registered { get; set; }

        public Member() {}

        public Member(string name, string email, string phoneNumber, string mobileNumber , 
                        string address1, string address2, string city, string postalCode, string country)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address1 = address1;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public Member(int id, string name, string email, string phoneNumber, string mobileNumber,
                        string address1, string address2, string city, string postalCode, string country)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address1 = address1;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
