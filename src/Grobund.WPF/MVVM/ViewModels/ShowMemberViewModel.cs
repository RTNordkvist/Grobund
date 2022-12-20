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
using System.Windows;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class ShowMemberViewModel : ObservableObject
    {
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

        public RelayCommand DeleteMemberCommand => new RelayCommand(m => DeleteMember());
        public RelayCommand NavigateToUpdateMemberCommand { get; set; }
        public RelayCommand NavigateHomeCommand { get; set; }


        public ShowMemberViewModel()
        {
            Member = new MemberViewModel();
        }

        public void LoadMember(int id)
        {
            var db = new MemberRepository();

            var member = db.ReadById(id);

            if(member == null)
            {
                return;
            }

            Member = new MemberViewModel(member);
        }

        public bool DeleteMember()
        {
            var confirmation = MessageBox.Show("Er du sikker på at du vil slette medlemmet?", "Slet medlem", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
            var db = new MemberRepository();

            var member = db.ReadById(Member.Id);

            if (member == null)
            {
                    MessageBox.Show("Medlemmet blev ikke fundet i databasen", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
            }

            db.Delete(member.Id);

                //TODO - Lav dette så den går tilbage til søg viewet
                NavigateHomeCommand.Execute(null);
            return true;
            }
            else
            {
                return false;
            }

        }
    }
}
