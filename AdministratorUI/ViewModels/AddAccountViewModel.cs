using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class AddAccountViewModel:BaseViewModel
    {
        private string _cardNumber;
        private AccountType _type = AccountType.CalculatedAccount;
        private long _identificationCode;

        private ICommand _addAccountCommand;
        private ICommand _backCommand;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
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

        public ICommand AddAccountCommand => _addAccountCommand ??
                                         (_addAccountCommand =
                                             new RelayCommand<object>(AddAccountImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber) && !string.IsNullOrWhiteSpace(((PasswordBox)obj).Password);
        }

        private void Clear()
        {
            CardNumber = "";
            IdentificationCode = 0;
        }

        private async void AddAccountImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {

                    res = StationManager.AdminClient.AddAccount(StationManager.CurrentClient,new Account(_cardNumber, ((PasswordBox)obj).Password,_type));
                }
                catch (Exception)
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
                ((PasswordBox)obj).Password = "";
                NavigationManager.Instance.Navigate(ViewType.Client);
                ;
            }
        }

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackImplementation));
        private void BackImplementation(object obj)
        {
            Clear();
            ((PasswordBox)obj).Password = "";
            NavigationManager.Instance.Navigate(ViewType.Client);
        }

    }
}
