using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class ClientViewModel:BaseViewModel
    {
        private ICommand _addAccountCommand;
        private ICommand _unblockCardCommand;
        private ICommand _backCommand;

        public ICommand AddAccountCommand => _addAccountCommand ??
                                                 (_addAccountCommand =
                                                     new RelayCommand<object>(AddAccountImplementation));

        public ICommand UnblockCardCommand => _unblockCardCommand ??
                                               (_unblockCardCommand =
                                                   new RelayCommand<object>(UnblockCardImplementation));

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackImplementation));
        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private void AddAccountImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.AddAccount);
        }

        private void UnblockCardImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.UnblockCard);
        }
    }
}
