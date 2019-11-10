
using System.Windows.Controls;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl, INavigatable
    {
        public MenuView()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
        }
    }
}
