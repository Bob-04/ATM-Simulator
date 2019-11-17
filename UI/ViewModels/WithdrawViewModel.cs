using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class WithdrawViewModel:BaseViewModel
    {
        private string _withdrawSum = "0";


        public string WithdrawSum
        {
            get => _withdrawSum;
            set
            {
                    _withdrawSum = value;
                    if (_withdrawSum.StartsWith("0"))
                        _withdrawSum = _withdrawSum.Substring(1);
                    OnPropertyChanged();

            }
        }

        private async void WithdrawImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    res = StationManager.ATMClient.WithdrawMoney(StationManager.CurrentAccount, StationManager.CurrentAccount.Pin,Convert.ToUInt32(_withdrawSum));
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
                MessageBox.Show(res);
            }
        }

        public override void ClearImplementation(object obj)
        {
            WithdrawSum = "00";
        }

        public override void CancelImplementation(object obj)
        {
            ClearImplementation(obj);
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }

        public override void EnterImplementation(object obj)
        {
            WithdrawImplementation(obj);
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

        private void AddDigit(string digit)
        {
            WithdrawSum = WithdrawSum + digit;
        }

    }
}
