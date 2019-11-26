using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class LimitExceedingProtectionViewModel:BaseViewModel
    {
        private string _cardNumber;
        private string _minBalance;
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

        public string MinBalance
        {
            get => _minBalance;
            set
            {
                _minBalance = value;
                if (_minBalance.StartsWith("0"))
                    _minBalance = _minBalance.Substring(1);
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
                    res = StationManager.ATMClient.LimitExceedingProtection(StationManager.CurrentAccount, StationManager.CurrentAccount.Pin, Convert.ToUInt32(_minBalance), _cardNumber);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            MessageBox.Show(res);
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Menu);
                ClearImplementation(obj);
            }
        }


        public override void ClearImplementation(object obj)
        {
            CardNumber = "";
            MinBalance = "00";
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


        public override void Button22Implementation(object obj)
        {
            NumTextBox = 0;
        }
        public override void Button23Implementation(object obj)
        {
            NumTextBox = 1;
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
        public override void Press9Implementation(object obj) { AddDigit("9"); }

        private void AddDigit(string digit)
        {
            switch (_numTextBox)
            {
                case 0:
                    CardNumber = CardNumber + digit;
                    break;
                case 1:
                    MinBalance = MinBalance + digit;
                    break;

            }
        }
    }
}
