using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class SignInViewModel:BaseViewModel
    {
        private string _identificationCode;

        private ICommand _signInCommand;
        private ICommand _backCommand;

        public string IdentificationCode
        {
            get => _identificationCode;
            set
            {
                _identificationCode = value;
                OnPropertyChanged();
            }
        }


        public ICommand SignInCommand => _signInCommand ??
                                         (_signInCommand =
                                             new RelayCommand<object>(SignInImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(IdentificationCode) && !string.IsNullOrWhiteSpace(((PasswordBox)obj).Password);
        }

        private void Clear()
        {
            IdentificationCode = "";
        }

        private async void SignInImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    StationManager.InitializeCurrentClient(
                        StationManager.AdminClient.GetClient(Convert.ToInt64(_identificationCode), ((PasswordBox)obj).Password));
                    if (StationManager.CurrentClient == null)
                    {
                        res = "Wrong Identification code or password";
                        return false;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong");
                }

                return true;
            });
            
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                Clear();
                ((PasswordBox) obj).Password = "";
                NavigationManager.Instance.Navigate(ViewType.Client);
                
            }
            else
            {
                MessageBox.Show(res);
            }
        }

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackImplementation));
        private void BackImplementation(object obj)
        {
            StationManager.CurrentClient = null;
            Clear();
            ((PasswordBox) obj).Password = "";
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}
