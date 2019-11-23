

using System.Windows;
using KMA.MOOP.ATM.AdministratorUI.Tools;
using KMA.MOOP.ATM.AdministratorUI.Tools.Managers;

namespace KMA.MOOP.ATM.AdministratorUI.ViewModels
{
    internal class MainWindowViewModel:BaseViewModel, ILoaderOwner
    {
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
