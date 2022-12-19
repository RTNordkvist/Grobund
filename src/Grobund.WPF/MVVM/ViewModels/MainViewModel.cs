﻿using Grobund.Data.Models;
using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Grobund.WPF.MVVM.ViewModels
{

    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand RegisterMemberViewCommand { get; set; }
        public RelayCommand ShowAssociationViewCommand { get; set; }

		public RelayCommand ReadMemberViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public RegisterMemberViewModel RegisterMemberVM { get; set; }
        public MemberInfoViewModel MemberInfoVM { get; set; }
        public UpdateMemberViewModel UpdateMemberVM { get; set; }
        public ShowAssociationViewModel ShowAssociationVM { get; set; }
        public ShowCertificateViewModel ShowCertificateVM { get; set; }


        private object _currentView;
        public ReadMemberViewModel ReadMemberVM { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			
            ReadMemberVM = new ReadMemberViewModel()
            {
                NavigateToMemberInfoCommand = new RelayCommand(o =>
                {
                    MemberInfoVM.LoadMember(((MemberDTO)o).Id);
                    CurrentView = MemberInfoVM;
                })
            };

            MemberInfoVM = new MemberInfoViewModel() 
            {
                NavigateToUpdateMemberCommand= new RelayCommand(o =>
                {
                    UpdateMemberVM.LoadMember(((Member)o).Id);
                    CurrentView = UpdateMemberVM;
                }),
                NavigateHomeCommand= new RelayCommand(o =>
                {
                    CurrentView = ReadMemberVM;
                })
            };

            UpdateMemberVM = new UpdateMemberViewModel()
            {
                NavigateToMemberInfoCommand = new RelayCommand(o =>
                {
                    MemberInfoVM.LoadMember(((Member)o).Id);
                    CurrentView = MemberInfoVM;
                })
            };

            RegisterMemberVM = new RegisterMemberViewModel()
			{
				NavigateToMemberInfoCommand = new RelayCommand(o => 
				{
					MemberInfoVM.LoadMember(((Member)o).Id);
					CurrentView = MemberInfoVM;
				})
			};

            ShowAssociationVM = new ShowAssociationViewModel()
            {
                NavigateToCertificateCommand = new RelayCommand(o =>
                {
                    ShowCertificateVM.LoadCertificate(((Certificate)o).Id);
                    CurrentView = ShowCertificateVM;
                })
            };

            ShowCertificateVM = new ShowCertificateViewModel()
            {
                NavigateToOwnerCommand = new RelayCommand(o =>
                {
                    MemberInfoVM.LoadMember(((Member)o).Id);
                    CurrentView = MemberInfoVM;
                })
            };

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            RegisterMemberViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegisterMemberVM;
            });

            ShowAssociationViewCommand = new RelayCommand(o =>
            {
                CurrentView = ShowAssociationVM;
            });

            CurrentView = HomeVM;

			ReadMemberViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReadMemberVM;
            });
        }
    }
}
