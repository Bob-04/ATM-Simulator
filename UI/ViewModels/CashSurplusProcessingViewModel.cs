using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    internal class CashSurplusProcessingViewModel:BaseViewModel
    {
        private string _cardNumber;
        private uint _maxBalance;
        private DateTime _dateOfStart = DateTime.Today;

        private ICommand _acceptCommand;
        private ICommand _cancelCommand;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public uint MaxBalance
        {
            get => _maxBalance;
            set
            {
                _maxBalance = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfStart
        {
            get => _dateOfStart;
            set
            {
                _dateOfStart = value;
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
                     res = StationManager.ATMClient.CashSurplusProcessing(StationManager.CurrentAccount, StationManager.CurrentAccount.Pin,_maxBalance,_cardNumber);
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
                MessageBox.Show(res);
                NavigationManager.Instance.Navigate(ViewType.Menu);
                CardNumber = "";
            }
        }
        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber) && MaxBalance <=0;// && !string.IsNullOrWhiteSpace(_password);
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CancelExecute));
        private void CancelExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }

    }
}
