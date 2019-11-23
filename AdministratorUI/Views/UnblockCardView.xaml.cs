
using System.Windows.Controls;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.AdministratorUI.ViewModels;

namespace KMA.MOOP.ATM.AdministratorUI.Views
{
    /// <summary>
    /// Логика взаимодействия для UnblockCardView.xaml
    /// </summary>
    public partial class UnblockCardView : UserControl, INavigatable
    {
        public UnblockCardView()
        {
            InitializeComponent();
            DataContext = new UnblockCardViewModel();
        }
    }
}
