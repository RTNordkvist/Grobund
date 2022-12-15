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

        private MemberDTO _updateMember;

        public MemberDTO UpdateMember
        {
            get { return _updateMember; }
            set
            {
                _updateMember = value;
                OnPropertyChanged(nameof(UpdateMember));
            }
        }

        public UpdateMemberViewModel()
        {
            ViewTitle = "Opdater medlem";
            Member = new MemberDTO();
            UpdateMember = new MemberDTO();
        }

        public void LoadMember(int id)
        {
            var db = new MemberRepository();

            var member = db.ReadById(id);

            if (member == null)
            {
                return;
            }

            Member = new MemberDTO(member);
        }
    }
}
