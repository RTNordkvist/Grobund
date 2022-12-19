using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using Grobund.WPF.Core;
using Grobund.WPF.MVVM.ViewModels.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class ShowAssociationViewModel : ObservableObject
    {
		private Association _currentAssociation;

		public Association CurrentAssociation
		{
			get { return _currentAssociation; }
			set 
			{ 
				_currentAssociation = value;
				OnPropertyChanged(nameof(CurrentAssociation));
				LoadAssociationInfo(_currentAssociation.Id);
            }
		}

		public ObservableCollection<Certificate> CurrentAssociationCertificates { get; set; }

		private Certificate _selectedCertificate;

		public Certificate SelectedCertificate
        {
			get { return _selectedCertificate; }
			set 
			{
                NavigateToCertificateCommand.Execute(value);
            }
		}

        private string _noOfMembers;

        public string NoOfMembers
        {
            get { return _noOfMembers; }
            set
            {
                _noOfMembers = value;
                OnPropertyChanged(nameof(NoOfMembers));
            }
        }

        public List<Association> Associations { get; set; }

		public RelayCommand NavigateToCertificateCommand;

        public ShowAssociationViewModel()
		{
            var db = new AssociationRepository();

            Associations = db.GetAll();

			CurrentAssociationCertificates = new();

            CurrentAssociation = Associations.FirstOrDefault();
        }

        public void LoadAssociationInfo(int id)
		{
			CurrentAssociationCertificates.Clear();

            var db = new AssociationRepository();

			var association = db.GetById(id);

			if (association == null)
			{
				return;
			}
			association.Certificates.ForEach(x => CurrentAssociationCertificates.Add(x));

			int membersCount = CurrentAssociationCertificates.Where(x => x.OwnerId != null).Count();

			NoOfMembers = $"{membersCount}/{CurrentAssociation.MaxNoOfCertificates}";
		}
	}
}
