using Grobund.WPF.MVVM.ViewModels;
using GrobundLibrary;
using GrobundLibrary.DataAccess;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Grobund.WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for RegisterMemberView.xaml
    /// </summary>
    public partial class RegisterMemberView : UserControl
    {
        public RegisterMemberView()
        {
            InitializeComponent();
        }

        private void registerMemberSubmitButton_Click(object sender, RoutedEventArgs e)
        {

            //TODO - Move this to a mehtod in registerMemberViewModel
            if (RegisterMemberViewModel.ValidateMemberForm(firstNameText.Text, lastNameText.Text, emailText.Text, phoneNumberText.Text))
            {
                MemberModel memberModel = new MemberModel(firstNameText.Text, lastNameText.Text, emailText.Text, phoneNumberText.Text);
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    //show message box with the member id
                    MessageBox.Show(db.CreateMember(memberModel).Id.ToString());
                }
                
                //Clearing forms
                firstNameText.Text = "";
                lastNameText.Text = "";
                emailText.Text = "";
                phoneNumberText.Text = "";
            }
        }
    }
}
