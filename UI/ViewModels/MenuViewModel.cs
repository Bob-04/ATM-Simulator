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
    }
}
