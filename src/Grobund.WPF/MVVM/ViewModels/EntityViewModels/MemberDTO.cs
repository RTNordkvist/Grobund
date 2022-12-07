using Grobund.Data.Models;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels.EntityViewModels
{
    public class MemberDTO : BaseDTO
    {
        public MemberDTO() 
        {
            Address = new AddressDTO();
        }

        public MemberDTO(Member member)
        {
            Id = member.Id;
            Name = member.Name;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
            MobileNumber = member.MobileNumber;
            Address = new AddressDTO(member.Adress);
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


        private AddressDTO _address;
        public AddressDTO Address
        {
            get { return _address; }
            set
            {
                if (Address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
    }
}
