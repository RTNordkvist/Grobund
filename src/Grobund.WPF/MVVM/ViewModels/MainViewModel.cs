﻿using Grobund.Data.Models;
using Grobund.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;



namespace Grobund.WPF.MVVM.ViewModels
{

	internal class MainViewModel : ObservableObject
	{
		public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand RegisterMemberViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }

		public RegisterMemberViewModel RegisterMemberVM { get; set;}

		public MemberInfoViewModel MemberInfoVM { get; set; }

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			MemberInfoVM = new MemberInfoViewModel();
			RegisterMemberVM = new RegisterMemberViewModel()
			{
				NavigateToMemberInfoCommand = new RelayCommand(o => 
				{
					MemberInfoVM.LoadMember(((Member)o).Id);
					CurrentView = MemberInfoVM;
				})
			};

            CurrentView = HomeVM;

			HomeViewCommand = new RelayCommand(o =>
			{
				CurrentView= HomeVM;
			});

            RegisterMemberViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegisterMemberVM;
            });
        }
    }
}
