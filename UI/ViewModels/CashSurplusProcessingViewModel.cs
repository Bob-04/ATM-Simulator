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
