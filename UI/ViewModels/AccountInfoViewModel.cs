using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class AccountInfoViewModel:BaseViewModel
    {
        public string CardNumber => $"{StationManager.CurrentAccount.Number}";
        public string Balance => $"{StationManager.CurrentAccount.Balance}";

        public override void CancelImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }
    }
}
