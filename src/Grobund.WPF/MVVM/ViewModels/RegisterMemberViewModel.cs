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
        public string ViewTitle { get; set;}

        private MemberViewModel _member;

        public MemberViewModel Member
        {
            get { return _member; }
            set
            {
                _member = value;
                OnPropertyChanged(nameof(Member));
            }
        }

        public RelayCommand SaveMemberCommand => new RelayCommand(m => SaveMember());
        public RelayCommand NavigateToShowMemberCommand;

        public RegisterMemberViewModel()
        {
            ViewTitle = "Registrer medlem";
            Member = new MemberViewModel();
        }

        public void SaveMember()
        {
            try
            {

                if (Member.Validate())
                {
                    var member = new Member(Member.Name, Member.Email, Member.PhoneNumber, Member.MobileNumber, 
                                            Member.Address1, Member.Address2, Member.PostalCode, Member.City, Member.Country);

                    var db = new MemberRepository();
                    //saves member in db
                    var id = db.Create(member);

                    //Clearing forms
                    Member = new MemberViewModel();

                    NavigateToShowMemberCommand.Execute(new Member { Id = member.Id});
                } else
                {
                    MessageBox.Show("Der er fejl i formularen");
                }
            }
            catch (Exception e)
            {
                throw new Exception("The member already exist");
            }
        }
    }
}
