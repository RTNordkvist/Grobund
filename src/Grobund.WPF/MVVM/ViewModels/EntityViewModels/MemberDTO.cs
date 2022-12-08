using Grobund.Data.Models;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels.EntityViewModels
{
    public class MemberDTO : BaseDTO
    {
        public MemberDTO() 
        {
        }

        public MemberDTO(Member member)
        {
            Id = member.Id;
            Name = member.Name;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
            MobileNumber = member.MobileNumber;
            Address1 = member.Address1;
            Address2 = member.Address2;
            PostalCode = member.PostalCode;
            City = member.City;
            Country = member.Country;
        }

        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (Name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (Email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (PhoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private string _mobileNumber;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                if (MobileNumber != value)
                {
                    _mobileNumber = value;
                    OnPropertyChanged(nameof(MobileNumber));
                }
            }
        }

        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (Address1 != value)
                {
                    _address1 = value;
                    OnPropertyChanged(nameof(Address1));
                }
            }
        }

        private string _address2;

        public string Address2
        {
            get { return _address2; }
            set
            {
                if (Address2 != value)
                {
                    _address2 = value;
                    OnPropertyChanged(nameof(Address2));
                }
            }
        }

        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (PostalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (City != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {
                if (Country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private DateTime _registered;

        public DateTime Registered
        {
            get { return _registered; }
            set 
            { 
                _registered = value;
                OnPropertyChanged(nameof(Registered));
            }
        }
    }
}
