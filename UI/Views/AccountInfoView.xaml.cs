using System.Windows.Controls;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для AccountInfo.xaml
    /// </summary>
    public partial class AccountInfoView : UserControl, INavigatable
    {
        public AccountInfoView()
        {
            InitializeComponent();
            DataContext = new AccountInfoViewModel();
        }
        public object GetContext()
        {
            return this.DataContext;
        }
    }
}
