
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using KMA.MOOP.ATM.Client.ATMClient;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl => _contentControl;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            StationManager.InitializeATMClient(new ATMClient());
            LoginClient();
        }

        private void LoginClient()
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }
    }
}
