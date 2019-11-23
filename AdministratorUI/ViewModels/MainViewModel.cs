using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class MainViewModel:BaseViewModel
    {
        private ICommand _registerClientCommand;
        private ICommand _signInClientCommand;

        public ICommand RegisterClientCommand => _registerClientCommand ??
                                         (_registerClientCommand =
                                             new RelayCommand<object>(RegisterClientImplementation));

        public ICommand SignInClientCommand => _signInClientCommand ??
                                                 (_signInClientCommand =
                                                     new RelayCommand<object>(SignInClientImplementation));

        private void RegisterClientImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.RegisterClient);
        }

        private void SignInClientImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignInClient);
        }
    }
}
