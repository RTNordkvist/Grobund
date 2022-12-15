using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using GrobundLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class MemberInfoViewModel : ObservableObject
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

        public RelayCommand DeleteMemberCommand => new RelayCommand(m => DeleteMember());

        public RelayCommand ViewUpdateCommand => new RelayCommand(m => ViewUpdateMember());

        public RelayCommand NavigateToUpdateMemberCommand { get; set; }
        public RelayCommand NavigateHomeCommand { get; set; }



        public MemberInfoViewModel()
        {
            Member = new MemberDTO();
        }

        public void LoadMember(int id)
        {
            var db = new MemberRepository();

            var member = db.ReadById(id);

            if(member == null)
            {
                return;
            }

            Member = new MemberDTO(member);
        }

        public void ViewUpdateMember()
        {


            NavigateToUpdateMemberCommand.Execute(new Member { Id = Member.Id });
        }

        public bool DeleteMember()
        {

            var db = new MemberRepository();
            

            var member = db.ReadById(Member.Id);

            if (member == null)
            {
                return false;
            }

            db.Delete(member.Id);
            NavigateHomeCommand.Execute(null);
            return true;

        }
    }
}
