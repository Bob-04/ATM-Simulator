using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.Views;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class SignInViewModel: BaseViewModel
    {
        private SignInView _view;
        public  SignInViewModel(SignInView view)
        {
            _view = view;
            
        }
        private string _cardNumber;

        public string Password { get; set; }

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

        private void ExecutePasswordChangedCommand(PasswordBox obj)
        {
            if (obj != null)
                Password = obj.Password;
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






        public override void Press0Implementation(object obj)
        {
            //((PasswordBox) obj).Password = ((PasswordBox) obj).Password + "0";
            CardNumber = CardNumber + "0";
            
        }

        public override void Press1Implementation(object obj)
        {
            CardNumber = CardNumber + "1";
        }

        public override void Press2Implementation(object obj)
        {
            CardNumber = CardNumber + "2";
        }

        public override void Press3Implementation(object obj)
        {
            CardNumber = CardNumber + "3";
        }

        public override void Press4Implementation(object obj)
        {
            CardNumber = CardNumber + "4";
        }

        public override void Press5Implementation(object obj)
        {
            CardNumber = CardNumber + "5";
        }

        public override  void Press6Implementation(object obj)
        {
            CardNumber = CardNumber + "6";
        }

        public override void Press7Implementation(object obj)
        {
            CardNumber = CardNumber + "7";
        }

        public override void Press8Implementation(object obj)
        {
            CardNumber = CardNumber + "8";
        }

        public override void Press9Implementation(object obj)
        {
            CardNumber = CardNumber + "9";
        }

        public override void ClearImplementation(object obj)
        {
            CardNumber = "";
        }

        public override void CancelImplementation(object obj)
        {
            StationManager.CloseApp();
        }

        public override async void EnterImplementation(object obj)
        {
            Account currentClient = null;
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                //try
                //{
                //    currentClient = StationManager.ATMClient.LoginAccount(_cardNumber, Password);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Wrong card number or PIN");
                //    return false;
                //}
                MessageBox.Show(_view.PassBox.Password);
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                StationManager.CurrentAccount = currentClient;
                NavigationManager.Instance.Navigate(ViewType.Menu);
                CardNumber = "";
                //((PasswordBox)obj).Password = "";
            }
        }
    }
    
}
