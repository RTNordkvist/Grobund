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
        public MemberDTO() { }

        public MemberDTO(MemberModel member)
        {
            Id = member.Id;
            FirstName = member.FirstName;
            LastName = member.LastName;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
        }

        public int Id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (FirstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (LastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
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
    }
}
