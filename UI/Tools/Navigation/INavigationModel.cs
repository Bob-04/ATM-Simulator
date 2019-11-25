

namespace KMA.MOOP.ATM.UI.Tools.Navigation
{
    internal enum ViewType
    {
        Main,
        AutomaticTransfer,
        CashSurplus,
        LimitExceeding,
        Menu,
        SignIn,
        Withdraw,
        Replenish,
        AccountInfo
    }
    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
