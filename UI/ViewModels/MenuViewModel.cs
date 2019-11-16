using System;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class MenuViewModel : BaseViewModel
    {
        private ICommand _withdrawCommand;
        private ICommand _limitExceedingProtectionCommand;
        private ICommand _closeCommand;
        private ICommand _replenishCommand;
        private ICommand _cashSurplusCommand;
        private ICommand _automaticTransferCommand;
        private ICommand _quitCommand;

        public ICommand WithdrawCommand => _withdrawCommand ??
                                         (_withdrawCommand =
                                             new RelayCommand<object>(WithdrawImplementation));

        private void WithdrawImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Withdraw);
        }

        public ICommand LimitExceedingProtectionCommand => _limitExceedingProtectionCommand ??
                                           (_limitExceedingProtectionCommand =
                                               new RelayCommand<object>(LimitExceedingProtectionImplementation));

        private void LimitExceedingProtectionImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LimitExceeding);
        }

        public ICommand ReplenishCommand => _replenishCommand ??
                                           (_replenishCommand =
                                               new RelayCommand<object>(ReplenishImplementation));

        private void ReplenishImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Replenish);
        }

        public ICommand CashSurplusCommand => _cashSurplusCommand ??
                                                           (_cashSurplusCommand =
                                                               new RelayCommand<object>(CashSurplusImplementation));

        private void CashSurplusImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.CashSurplus);
        }

        public ICommand AutomaticTransferCommand => _automaticTransferCommand ??
                                                           (_automaticTransferCommand =
                                                               new RelayCommand<object>(AutomaticTransferImplementation));

        private void AutomaticTransferImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.AutomaticTransfer);
        }

        public ICommand QuitCommand => _quitCommand ?? (_quitCommand = new RelayCommand<object>(QuitExecute));
        private void QuitExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }


        public override void Button11Implementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Withdraw);
        }

        public override void Button12Implementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LimitExceeding);
        }

        public override void Button13Implementation(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Button21Implementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Replenish);
        }

        public override void Button22Implementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.CashSurplus);
        }

        public override void Button23Implementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.AutomaticTransfer);
        }


        public override void ClearImplementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void CancelImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        public override void EnterImplementation(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
