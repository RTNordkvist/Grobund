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
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class ReadMemberViewModel : ObservableObject
    {
        private MemberViewModel _selectedMember;

        public MemberViewModel SelectedMember
        {
            get => _selectedMember;
            set
            {
                NavigateToShowMemberCommand.Execute(value);
            }
        }

        public RelayCommand SearchMemberCommand => new RelayCommand(m => Search());
        public RelayCommand NavigateToShowMemberCommand;

        public ObservableCollection<MemberViewModel> Members { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }

        }

        public ReadMemberViewModel()
        {
            Members = new ObservableCollection<MemberViewModel>();
        }

        public void Search()
        {
            Members.Clear();

            var db = new MemberRepository();

            var seachresult = db.Search(SearchText)
                .Select(x => new MemberViewModel(x));

            foreach (var member in seachresult)
            {
                Members.Add(member);
            }
        }

    }
}
