using System;
using System.Collections.Generic;
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
        public string Registered { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string UserCertificate { get; set; }

        public string LandCertificate { get; set; }



        public Member(string name, 
            string email, 
            string phoneNumber, 
            string mobileNumber, 
            string registered, 
            string address1, 
            string address2, 
            string city,
            string postalCode,
            string country,
            string userCertificate,
            string landCertificate)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Registered = registered;
            Address1 = address1;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Country = country;
            UserCertificate = userCertificate;
            LandCertificate = landCertificate;
        }
    }
}
