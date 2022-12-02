using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using GrobundLibrary.DataAccess;
using GrobundLibrary;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using Grobund.DataAccess.Repositories;
using Grobund.Data.Models;

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
        public RelayCommand NavigateToMemberInfoCommand;

        public RegisterMemberViewModel()
        {
            Member = new MemberDTO();
        }

        public void SaveMember()
        {
            try
            {
                if (ValidateMemberForm(Member.FirstName, Member.LastName, Member.Email, Member.PhoneNumber))
                {
                    var member = new Member()
                    {
                        FirstName = Member.FirstName,
                        LastName = Member.LastName,
                        Email = Member.Email,
                        PhoneNumber = Member.PhoneNumber
                    };

                    var db = new MemberRepository();
                    //saves member in db
                    var id = db.Create(member);

                    //show message box with the member id
                    MessageBox.Show(id.ToString());

                    //Clearing forms
                    Member = new MemberDTO();

                    NavigateToMemberInfoCommand.Execute(new MemberModel { Id = member.Id});
                }
            }
            catch (Exception)
            {
                throw new Exception("The member already exist");
            }
        }

        //TODO - implement validation logic for member registration
        public static bool ValidateMemberForm(string firstName, string lastName, string email, string phoneNumber)
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
