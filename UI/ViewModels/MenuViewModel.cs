using System;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class MenuViewModel : BaseViewModel
    {

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

        public override void CancelImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

    }
}
