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
        MemberRepository db = new MemberRepository();

        private MemberDTO _member;

        public MemberDTO SelectedMember
        {
            get => _member;
            set
            {
                NavigateToMemberInfoCommand.Execute(value);
            }
        }

        public RelayCommand SearchMemberCommand => new RelayCommand(m => searchCommand());
        public RelayCommand NavigateToMemberInfoCommand;

        public ObservableCollection<MemberDTO> Members { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }

        }


        public ReadMemberViewModel()
        {
            Members= new ObservableCollection<MemberDTO>();
        }

        public void searchCommand()
        {
           Members.Clear();

           //Members = db.Search(searchText);

            var seachresult = db.Search(SearchText)
                .Select(x => new MemberDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber
                });

            foreach (var dog in seachresult)
            {
                Members.Add(dog);
            }
        }

    }
}
