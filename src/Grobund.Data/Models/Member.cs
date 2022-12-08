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
        public DateTime Registered { get; set; }
        public Address Address { get; set; }

        public Member() {}

        public Member(string name,
            string email,
            string phoneNumber,
            string mobileNumber,
            Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            //Address = new Address
            //{
            //    Address1 = address.Address1,
            //    Address2 = address.Address2,
            //    City = address.City,
            //    PostalCode = address.PostalCode,
            //    Country = address.Country
            //};
            Address = address;
    }
    }
}
