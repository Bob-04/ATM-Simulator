using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class WithdrawViewModel:BaseViewModel
    {
        private uint _withdrawSum;

        private ICommand _withdrawCommand;
        private ICommand _cancelCommand;

        public uint WithdrawSum
        {
            get => _withdrawSum;
            set
            {
                _withdrawSum = value;
                OnPropertyChanged();
            }
        }

        public ICommand WithdrawCommand => _withdrawCommand ??
                                         (_withdrawCommand =
                                             new RelayCommand<object>(WithdrawImplementation, CanSignInExecute));

        private async void WithdrawImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    res = StationManager.ATMClient.WithdrawMoney(StationManager.CurrentAccount, StationManager.CurrentAccount.Pin,_withdrawSum);
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
                WithdrawSum = 0;
                MessageBox.Show(res);
            }
        }
        private bool CanSignInExecute(object obj)
        {
            return true;// && !string.IsNullOrWhiteSpace(_password);
        }

        public override void Press0Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press1Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press2Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press3Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press4Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press5Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press6Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press7Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press8Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Press9Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void ClearImplementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void CancelImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }

        public override void EnterImplementation(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
