using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class AddAccountViewModel:BaseViewModel
    {
        private string _number;
        private string _pin;
        private AccountType _type;
        private long _identificationCode;
        private string _password;

        private ICommand _acceptCommand;
        private ICommand _cancelCommand;

        public string Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        public string Pin
        {
            get => _pin;
            set
            {
                _pin = value;
                OnPropertyChanged();
            }
        }

        public AccountType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
                //TODO make setting AccountType
            }
        }

        public long IdentificationCode
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

        public ICommand AcceptCommand => _acceptCommand ??
                                         (_acceptCommand =
                                             new RelayCommand<object>(AcceptImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(Number) && !string.IsNullOrWhiteSpace(Pin);
        }

        private void Clear()
        {
            Number = "";
            Pin = "";
            IdentificationCode = 0;
            Password = "";
        }

        private async void AcceptImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {

                    res = StationManager.AdminClient.AddAccount(StationManager.AdminClient.GetClient(_identificationCode,_password),new Account(_number,_pin,_type));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong");
                    return false;
                }

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

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CancelExecute));
        private void CancelExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

    }
}
