using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class SignInViewModel: BaseViewModel
    {
        private string _cardNumber;

        private ICommand _signInCommand;
        private ICommand _closeCommand;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand => _signInCommand ??
                                         (_signInCommand =
                                             new RelayCommand<object>(SignInImplementation, CanSignInExecute));

        private async void SignInImplementation(object obj)
        {
            Account currentClient = null;
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    currentClient = StationManager.ATMClient.LoginAccount(_cardNumber, ((PasswordBox)obj).Password);
            }
                catch (Exception ex)
            {
                MessageBox.Show("Wrong card number or PIN");
                return false;
            }

            return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                StationManager.CurrentAccount = currentClient;
                NavigationManager.Instance.Navigate(ViewType.Menu);
                CardNumber = "";
                ((PasswordBox) obj).Password = "";
            }
        }
        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber);// && !string.IsNullOrWhiteSpace(_password);
        }

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }

        
    }
    
}
