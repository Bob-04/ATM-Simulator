using System.Windows.Controls;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.AdministratorUI.ViewModels;

namespace KMA.MOOP.ATM.AdministratorUI.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl, INavigatable
    {
        public ClientView()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        }
    }
}
