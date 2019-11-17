
using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.Views;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class SignInViewModel: BaseViewModel
    {
        private readonly SignInView _view;
        public  SignInViewModel(SignInView view)
        {
            _view = view;
            
        }
        private string _cardNumber;

        private short _numTextBox = 0;

        public short NumTextBox
        {
            get => _numTextBox;
            set => _numTextBox = value;
        }


        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        private async void SignInImplementation(object obj)
        {
            Account currentClient = null;
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    currentClient = StationManager.ATMClient.LoginAccount(_cardNumber, _view.PassBox.Password);
                }
                catch (Exception)
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
                ClearImplementation(obj);
                NavigationManager.Instance.Navigate(ViewType.Menu);
            }
        }
        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber);// && !string.IsNullOrWhiteSpace(_password);
        }

        public override void ClearImplementation(object obj)
        {
            CardNumber = "";
            _view.PassBox.Password = "";
            _numTextBox = 0;

        }

        public override void CancelImplementation(object obj)
        {
            ClearImplementation(obj);
            StationManager.CloseApp();
        }

        public override void EnterImplementation(object obj)
        {
            SignInImplementation(obj);
        }

        public override void Press0Implementation(object obj){AddDigit("0");}

        public override void Press1Implementation(object obj) { AddDigit("1"); }

        public override void Press2Implementation(object obj) { AddDigit("2"); }

        public override void Press3Implementation(object obj) { AddDigit("3"); }

        public override void Press4Implementation(object obj) { AddDigit("4"); }

        public override void Press5Implementation(object obj) { AddDigit("5"); }

        public override  void Press6Implementation(object obj) { AddDigit("6"); }

        public override void Press7Implementation(object obj) { AddDigit("7"); }

        public override void Press8Implementation(object obj) { AddDigit("8"); }

        public override void Press9Implementation(object obj) { AddDigit("9"); }

        private void AddDigit(string digit)
        {
            switch (_numTextBox)
            {
                case 0:
                    CardNumber = CardNumber + digit;
                    break;
                case 1:
                    if(_view.PassBox.Password.Length < 4)
                        _view.PassBox.Password = _view.PassBox.Password + digit;
                    break;

            }
        }

        public override void Button22Implementation(object obj){_numTextBox = 0;}

        public override void Button23Implementation(object obj){_numTextBox = 1;}
    }
    
}
