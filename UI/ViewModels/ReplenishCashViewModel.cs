using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class ReplenishCashViewModel:BaseViewModel
    {
        private string _replenishSum = "0";


        public string ReplenishSum
        {
            get => _replenishSum;
            set
            {
                _replenishSum = value;
                if (_replenishSum.StartsWith("0"))
                    _replenishSum = _replenishSum.Substring(1);
                OnPropertyChanged();
            }
        }

        private async void AcceptImplementation(object obj)
        {
            if (_replenishSum.Equals("0"))
                return;
            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    res = StationManager.ATMClient.AddMoney(StationManager.CurrentAccount,Convert.ToUInt32(_replenishSum));
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
                ClearImplementation(obj);
                StationManager.CurrentAccount.Balance += Convert.ToUInt32(_replenishSum);
                MessageBox.Show(res);
            }
        }

        public override void ClearImplementation(object obj)
        {
            ReplenishSum = "00";
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
        public override void Press9Implementation(object obj) { AddDigit("9"); }

        private void AddDigit(string digit)
        {
            ReplenishSum += digit;
        }
    }
}
