
using System.Windows.Controls;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.AdministratorUI.ViewModels;

namespace KMA.MOOP.ATM.AdministratorUI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
