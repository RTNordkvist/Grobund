using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using GrobundLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using Grobund.DataAccess;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class RegisterMemberViewModel : ObservableObject
    {
        private MemberDTO _member;

        public MemberDTO Member
        {
            get { return _member; }
            set
            {
                _member = value;
                OnPropertyChanged(nameof(Member));
            }
        }

        public RelayCommand SaveMemberCommand => new RelayCommand(m => SaveMember());

        public RegisterMemberViewModel()
        {
            Member = new MemberDTO();
        }

        public async void SaveMember()
        {
            
            try
            {
                if (ValidateMemberForm(Member))
                {
                    var member = new Member(Member.Name,
                        Member.Email,
                        Member.PhoneNumber,
                        Member.MobileNumber,
                        Member.Registered,
                        Member.Address1,
                        Member.Address2,
                        Member.City,
                        Member.PostalCode,
                        Member.Country,
                        Member.UserCertificate,
                        Member.LandCertificate);

                    
                    foreach (IRepository<Member, int> repository in GlobalConfig.MemberRepositories)
                    {
                        //saves member in db
                        member =  await repository.Insert(member);

                        //show message box with the member id
                        MessageBox.Show(member.Id.ToString());
                    }

                    //Clearing forms
                    Member = new MemberDTO();
                }
            }
            catch (Exception)
            {
                throw new Exception("The member already exist");
            }
        }

        //TODO - implement validation logic for member registration
        //TODO - Make it validate all properties
        public static bool ValidateMemberForm(MemberDTO Member)
        {
            bool isValid = true;

            return isValid;
        }

        private bool validateFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        private bool validateLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        private bool validateEmail(string email)
        {
            throw new NotImplementedException();
        }

        private bool validatePhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
