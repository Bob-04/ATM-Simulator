using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class UnblockCardViewModel : BaseViewModel
    {
        private ICommand _unblockCommand;
        private ICommand _backCommand;
        private string _cardNumber;


        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand UnblockCommand => _unblockCommand ??
                                         (_unblockCommand =
                                             new RelayCommand<object>(UnblockImplementation, CanSignInExecute));

        private bool CanSignInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber);
        }

        private void Clear()
        {
            CardNumber = "";
        }

        private async void UnblockImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {

                    res = StationManager.AdminClient.UnblockAccount(StationManager.CurrentClient,_cardNumber);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong");
                    return false;
                }

                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                MessageBox.Show(res);
                Clear();
                NavigationManager.Instance.Navigate(ViewType.Client);
                ;
            }
        }

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackExecute));
        private void BackExecute(object obj)
        {
            Clear();
            NavigationManager.Instance.Navigate(ViewType.Client);
        }
    }
}
