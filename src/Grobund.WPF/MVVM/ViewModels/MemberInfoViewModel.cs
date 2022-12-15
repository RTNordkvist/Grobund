using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using GrobundLibrary.DataAccess;
using System;
using System.Collections.Generic;
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

        public RelayCommand DeleteMemberViewCommand { get; set; }

        public RelayCommand NavigateToUpdateMemberCommand { get; set; }

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

        public Member ViewUpdateMember()
        {


            return new Member();
        }
    }
}
