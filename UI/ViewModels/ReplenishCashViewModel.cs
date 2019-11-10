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
    internal class ReplenishCashViewModel:BaseViewModel
    {
        private uint _replenishSum;

        private ICommand _acceptCommand;
        private ICommand _cancelCommand;

        public uint ReplenishSum
        {
            get => _replenishSum;
            set
            {
                _replenishSum = value;
                OnPropertyChanged();
            }
        }

        public ICommand AcceptCommand => _acceptCommand ??
                                         (_acceptCommand =
                                             new RelayCommand<object>(AcceptImplementation, CanSignInExecute));

        private async void AcceptImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    res = StationManager.ATMClient.AddMoney(StationManager.CurrentAccount,_replenishSum);
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
                ReplenishSum = 0;
                MessageBox.Show(res);
            }
        }
        private bool CanSignInExecute(object obj)
        {
            return true;// && !string.IsNullOrWhiteSpace(_password);
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CancelExecute));
        private void CancelExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }
    }
}
