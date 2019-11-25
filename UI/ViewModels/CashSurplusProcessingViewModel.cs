using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class CashSurplusProcessingViewModel:BaseViewModel
    {
        private string _cardNumber;
        private string _maxBalance;
        private short _numTextBox = 0;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string MaxBalance
        {
            get => _maxBalance;
            set
            {
                _maxBalance = value;
                if (_maxBalance.StartsWith("0"))
                    _maxBalance = _maxBalance.Substring(1);
                OnPropertyChanged();
            }
        }


        private async void AcceptImplementation(object obj)
        {
            
            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                     res = StationManager.ATMClient.CashSurplusProcessing(StationManager.CurrentAccount, StationManager.CurrentAccount.Pin,Convert.ToUInt32(_maxBalance),_cardNumber);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong");
                    return false;
                }

                return true;
            });
            MessageBox.Show(res);
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Menu);
                ClearImplementation(obj);
            }
        }

        public override void ClearImplementation(object obj)
        {
            CardNumber = "";
            MaxBalance = "00";
            _numTextBox = 0;
        }

        public override void CancelImplementation(object obj)
        {
            ClearImplementation(obj);
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }

        public override void EnterImplementation(object obj)
        {

            AcceptImplementation(obj);
        }

        public override void Press0Implementation(object obj) { AddDigit("0"); }
        public override void Press1Implementation(object obj) { AddDigit("1"); }
        public override void Press2Implementation(object obj) { AddDigit("2"); }
        public override void Press3Implementation(object obj) { AddDigit("3"); }
        public override void Press4Implementation(object obj) { AddDigit("4"); }
        public override void Press5Implementation(object obj) { AddDigit("5"); }
        public override void Press6Implementation(object obj) { AddDigit("6"); }
        public override void Press7Implementation(object obj) { AddDigit("7"); }
        public override void Press8Implementation(object obj) { AddDigit("8"); }
        public override void Press9Implementation(object obj) { AddDigit("9");}
        public override void Button22Implementation(object obj)
        {
            _numTextBox = 0;
        }

        public override void Button24Implementation(object obj)
        {
            _numTextBox = 1;
        }

        private void AddDigit(string digit)
        {
            switch (_numTextBox)
            {
                case 0:
                    CardNumber = CardNumber + digit;
                    break;
                case 1:
                    MaxBalance = MaxBalance + digit;
                    break;
            }
        }
    }
}
