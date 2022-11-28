using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.WPF.MVVM.ViewModels
{
    internal class RegisterMemberViewModel
    {
        //TODO - implement validation logic for member registration
        public static bool ValidateMemberForm(string firstName, string  lastName, string email, string phoneNumber)
        {
            bool isValid = true;

            return isValid;
        }

        private bool validateFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        private bool validateLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        private bool validateEmail(string email)
        {
            throw new NotImplementedException();
        }

        private bool validatePhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
