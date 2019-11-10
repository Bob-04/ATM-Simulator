using System;
using KMA.MOOP.ATM.UI.Views;

namespace KMA.MOOP.ATM.UI.Tools.Navigation
{
    internal class InitializationNavigationModel :BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner)
        :base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType, new SignInView());
                    break;
                case ViewType.AutomaticTransfer:
                    ViewsDictionary.Add(viewType,new AutomaticTransferMenuView());
                    break;
                case ViewType.CashSurplus:
                    ViewsDictionary.Add(viewType,new CashSurplusProcessingMenuView());
                    break;
                case ViewType.LimitExceeding:
                    ViewsDictionary.Add(viewType,new LimitExceedingProtectionMenuView());
                    break;
                case ViewType.Menu:
                    ViewsDictionary.Add(viewType, new MenuView());
                    break;
                case ViewType.Withdraw: 
                    ViewsDictionary.Add(viewType, new WithdrawMenuView());
                    break;
                case ViewType.Replenish:
                    ViewsDictionary.Add(viewType, new ReplenishCashMenuView());
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }


    }
}
