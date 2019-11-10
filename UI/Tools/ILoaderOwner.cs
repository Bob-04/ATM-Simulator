    
using System.ComponentModel;
using System.Windows;

namespace KMA.MOOP.ATM.UI.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
