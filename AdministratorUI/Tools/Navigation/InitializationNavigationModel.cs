using System;

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
                case ViewType.SignIn:
                    
                    break;
                case ViewType.AddAccount:
                    break;
                case ViewType.RegisterClient:
                    break;
                case ViewType.Main:
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }


    }
}
