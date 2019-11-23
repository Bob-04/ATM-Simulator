
namespace KMA.MOOP.ATM.AdministratorUI.Tools.Navigation
{
    internal enum ViewType
    {
        MainWindow,
        Main,
        Client,
        SignInClient,
        UnblockCard,
        AddAccount,
        RegisterClient
    }
    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
