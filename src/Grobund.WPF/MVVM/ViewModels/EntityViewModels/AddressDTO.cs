using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels.EntityViewModels
{
    public class AddressDTO : BaseDTO
    {

        public AddressDTO() { }
        public AddressDTO(Address adress)
        {
            if (adress != null)
            {
                Id = adress.Id;
                Address1 = adress.Address1;
                Address2 = adress.Address2;
                PostalCode = adress.PostalCode;
                City = adress.City;
                Country = adress.Country;
            }
        }

        public int Id { get; set; }

        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (Address1 != value)
                {
                    _address1 = value;
                    OnPropertyChanged(nameof(Address1));
                }
            }
        }

        private string _address2;

        public string Address2
        {
            get { return _address2; }
            set
            {
                if (Address2 != value)
                {
                    _address2 = value;
                    OnPropertyChanged(nameof(Address2));
                }
            }
        }

        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (PostalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (City != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {
                if (Country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }
    }
}
