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
    internal class ShowCertificateViewModel : ObservableObject
    {
		private Certificate _certificate;

		public Certificate Certificate
		{
			get { return _certificate; }
			set 
			{ 
				_certificate = value; 
				OnPropertyChanged(nameof(Certificate));
			}
		}

		private string _certificateType;

		public string CertificateType
        {
			get { return _certificateType; }
			set 
			{ 
				_certificateType = value; 
				OnPropertyChanged(nameof(CertificateType));
			}
		}


		public ObservableCollection<Trade> Trades { get; set; }

		public RelayCommand NavigateToOwnerCommand;

		public ShowCertificateViewModel()
		{
			Certificate= new Certificate();
			Trades= new ObservableCollection<Trade>();
		}

		public void LoadCertificate(int id)
		{
			Trades.Clear();

            var db = new CertificateRepository();

            var certificate = db.GetById(id);

            if (certificate == null)
            {
                return;
            }

            Certificate = certificate;

            certificate.Trades.ForEach(x => Trades.Add(x));

            CertificateType = Certificate.AssociationId == 1 ? "Brugerbevis" : "Jordbevis"; //TODO værdier hentes fra databasen
        }

    }
}
