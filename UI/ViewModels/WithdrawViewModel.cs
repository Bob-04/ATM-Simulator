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

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CloseExecute));
        private void CloseExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }
    }
}
