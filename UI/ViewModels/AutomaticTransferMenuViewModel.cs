
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class AutomaticTransferMenuViewModel:BaseViewModel
    {
        private string _cardNumber;
        private ICommand _cancelCommand;

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CancelExecute));
        private void CancelExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }
    }
}
