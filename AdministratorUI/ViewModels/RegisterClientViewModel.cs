using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class RegisterClientViewModel:BaseViewModel
    {
        private string _identificationCode;
        private string _password;
        private string _repeatPassword;
        private string _phone;
        private string _firstName;
        private string _lastName;

        private ICommand _registerCommand;
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

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                _repeatPassword = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand => _registerCommand ??
                                         (_registerCommand =
                                             new RelayCommand<object>(RegisterImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName)
                    && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Phone) && !string.IsNullOrWhiteSpace(RepeatPassword);
        }

        private void Clear()
        {
            IdentificationCode = "";
            Password = "";
            RepeatPassword = "";
            Phone = "+";
            FirstName = "";
            LastName = "";
        }

        private async void RegisterImplementation(object obj)
        {
            if (Password != RepeatPassword)
            {
                MessageBox.Show("Password not the same");
                return;
            }
            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                //try
                //{
                    res = StationManager.AdminClient.RegisterClient(
                        new DBModels.Client(Convert.ToInt64
                            (_identificationCode),_firstName,_lastName, _phone, _password));
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Wrong");
                //    return false;
                //}

                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                MessageBox.Show(res);
                Clear();
                NavigationManager.Instance.Navigate(ViewType.Main);
                ;
            }
        }

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackExecute));
        private void BackExecute(object obj)
        {
            Clear();
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}
