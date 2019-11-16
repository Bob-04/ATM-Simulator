
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
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



        public override void Press0Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press0Implementation(obj);
        }

        public override void Press1Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press1Implementation(obj);
        }

        public override void Press2Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press2Implementation(obj);
        }

        public override void Press3Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press3Implementation(obj);
        }

        public override void Press4Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press4Implementation(obj);
        }

        public override void Press5Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press5Implementation(obj);
        }

        public override void Press6Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press6Implementation(obj);
        }

        public override void Press7Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press7Implementation(obj);
        }

        public override void Press8Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press8Implementation(obj);
        }

        public override void Press9Implementation(object obj)
        {
            StationManager.CurrentViewModel.Press9Implementation(obj);
        }

        public override void ClearImplementation(object obj)
        {
            StationManager.CurrentViewModel.ClearImplementation(obj);
        }

        public override void CancelImplementation(object obj)
        {

            StationManager.CurrentViewModel.CancelImplementation(obj);
        }

        public override void EnterImplementation(object obj)
        {
            StationManager.CurrentViewModel.EnterImplementation(obj);
        }

        public override void Button11Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button11Implementation(obj);
        }

        public override void Button12Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button12Implementation(obj);
        }

        public override void Button13Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button13Implementation(obj);
        }

        public override void Button21Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button21Implementation(obj);
        }

        public override void Button22Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button22Implementation(obj);
        }

        public override void Button23Implementation(object obj)
        {
            StationManager.CurrentViewModel.Button23Implementation(obj);
        }
    }
}
