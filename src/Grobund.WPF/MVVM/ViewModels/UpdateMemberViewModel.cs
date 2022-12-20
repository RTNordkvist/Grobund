using Grobund.WPF.Core;
using Grobund.Data.Models;
using Grobund.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Grobund.DataAccess.Repositories;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class UpdateMemberViewModel : ObservableObject
    {
        public string ViewTitle { get; set; }

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

        public RelayCommand UpdateMemberCommand => new RelayCommand(m => UpdateMember());
        public RelayCommand NavigateToMemberInfoCommand;

        public UpdateMemberViewModel()
        {
            ViewTitle = "Opdater medlem";
            Member = new MemberViewModel();
        }

        public void LoadMember(int id)
        {
            var db = new MemberRepository();

            var member = db.ReadById(id);

            if (member == null)
            {
                return;
            }

            Member = new MemberViewModel(member);
        }

        public void UpdateMember()
        {
            var db = new MemberRepository();

            var member = new Member(Member.Id, Member.Name, Member.Email, Member.PhoneNumber, Member.MobileNumber, Member.Address1, Member.Address2, Member.PostalCode, Member.City, Member.Country);

            db.Update(member);

            NavigateToMemberInfoCommand.Execute(new Member { Id = member.Id });
        }
    }
}
