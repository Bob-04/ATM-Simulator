using System;
using KMA.MOOP.ATM.AdministratorUI.Views;

namespace KMA.MOOP.ATM.AdministratorUI.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner)
            : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.SignInClient:
                    ViewsDictionary.Add(viewType,new SignInClientView());
                    break;
                case ViewType.AddAccount:
                    ViewsDictionary.Add(viewType,new AddAccountView());
                    break;
                case ViewType.RegisterClient:
                    ViewsDictionary.Add(viewType,new RegisterClientView());
                    break;
                case ViewType.Client:
                    ViewsDictionary.Add(viewType,new ClientView());
                    break;
                case ViewType.Main:
                    ViewsDictionary.Add(viewType,new MainView());
                    break;
                case ViewType.UnblockCard:
                    ViewsDictionary.Add(viewType,new UnblockCardView());
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }


    }
}
