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
        private long _identificationCode;
        private string _password;
        private string _phone;
        private string _firstName;
        private string _lastName;

        private ICommand _acceptCommand;
        private ICommand _cancelCommand;

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

        public ICommand AcceptCommand => _acceptCommand ??
                                         (_acceptCommand =
                                             new RelayCommand<object>(AcceptImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName)
                    && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Phone);
        }

        private void Clear()
        {
            IdentificationCode = 0;
            Password = "";
            Phone = "+";
            FirstName = "";
            LastName = "";
        }

        private async void AcceptImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    
                    res = StationManager.AdminClient.RegisterClient(new DBModels.Client(_identificationCode,_firstName,_lastName, _phone, _password));
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
