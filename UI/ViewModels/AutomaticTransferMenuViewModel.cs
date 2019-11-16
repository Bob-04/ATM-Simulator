
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


        public override void Press0Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press1Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press2Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press3Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press4Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press5Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press6Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press7Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press8Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Press9Implementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void ClearImplementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override void CancelImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Menu);
            
        }

        public override void EnterImplementation(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
