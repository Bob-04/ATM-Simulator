using System.ComponentModel;
using System.Windows.Input;

namespace KMA.MOOP.ATM.UI.Tools
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _press0Command;
        private ICommand _press1Command;
        private ICommand _press2Command;
        private ICommand _press3Command;
        private ICommand _press4Command;
        private ICommand _press5Command;
        private ICommand _press6Command;
        private ICommand _press7Command;
        private ICommand _press8Command;
        private ICommand _press9Command;
        private ICommand _clearCommand;
        private ICommand _cancelCommand;
        private ICommand _enterCommand;
        private ICommand _button11Command;
        private ICommand _button12Command;
        private ICommand _button13Command;
        private ICommand _button21Command;
        private ICommand _button22Command;
        private ICommand _button23Command;

        public ICommand Press0Command => _press0Command ??
                                         (_press0Command =
                                             new RelayCommand<object>(Press0Implementation));

        public ICommand Press1Command => _press1Command ??
                                         (_press1Command =
                                             new RelayCommand<object>(Press1Implementation));
        public ICommand Press2Command => _press2Command ??
                                         (_press2Command =
                                             new RelayCommand<object>(Press2Implementation));
        public ICommand Press3Command => _press3Command ??
                                         (_press3Command =
                                             new RelayCommand<object>(Press3Implementation));
        public ICommand Press4Command => _press4Command ??
                                         (_press4Command =
                                             new RelayCommand<object>(Press4Implementation));
        public ICommand Press5Command => _press5Command ??
                                         (_press5Command =
                                             new RelayCommand<object>(Press5Implementation));
        public ICommand Press6Command => _press6Command ??
                                         (_press6Command =
                                             new RelayCommand<object>(Press6Implementation));
        public ICommand Press7Command => _press7Command ??
                                         (_press7Command =
                                             new RelayCommand<object>(Press7Implementation));
        public ICommand Press8Command => _press8Command ??
                                         (_press8Command =
                                             new RelayCommand<object>(Press8Implementation));
        public ICommand Press9Command => _press9Command ??
                                         (_press9Command =
                                             new RelayCommand<object>(Press9Implementation));

        public ICommand ClearCommand => _clearCommand ??
                                        (_clearCommand =
                                            new RelayCommand<object>(ClearImplementation));

        public ICommand CancelCommand => _cancelCommand ??
                                        (_cancelCommand =
                                            new RelayCommand<object>(CancelImplementation));

        public ICommand EnterCommand => _enterCommand ??
                                        (_enterCommand =
                                            new RelayCommand<object>(EnterImplementation));

        public ICommand Button11Command => _button11Command ??
                                        (_button11Command =
                                            new RelayCommand<object>(Button11Implementation));
        public ICommand Button12Command => _button12Command ??
                                           (_button12Command =
                                               new RelayCommand<object>(Button12Implementation));
        public ICommand Button13Command => _button13Command ??
                                           (_button13Command =
                                               new RelayCommand<object>(Button13Implementation));
        public ICommand Button21Command => _button21Command ??
                                           (_button21Command =
                                               new RelayCommand<object>(Button21Implementation));
        public ICommand Button22Command => _button22Command ??
                                           (_button22Command =
                                               new RelayCommand<object>(Button22Implementation));
        public ICommand Button23Command => _button23Command ??
                                           (_button23Command =
                                               new RelayCommand<object>(Button23Implementation));



        public virtual void Press0Implementation(object obj){}

        public virtual void Press1Implementation(object obj){}
        public virtual void Press2Implementation(object obj) { }
        public virtual void Press3Implementation(object obj) { }
        public virtual void Press4Implementation(object obj) { }
        public virtual void Press5Implementation(object obj) { }
        public virtual void Press6Implementation(object obj) { }
        public virtual void Press7Implementation(object obj) { }
        public virtual void Press8Implementation(object obj) { }
        public virtual void Press9Implementation(object obj) { }
        public virtual void ClearImplementation(object obj) { }
        public virtual void CancelImplementation(object obj) { }
        public virtual void EnterImplementation(object obj) { }
        public virtual void Button11Implementation(object obj) { }
        public virtual void Button12Implementation(object obj) { }
        public virtual void Button13Implementation(object obj) { }
        public virtual void Button21Implementation(object obj) { }
        public virtual void Button22Implementation(object obj) { }
        public virtual void Button23Implementation(object obj) { }



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
