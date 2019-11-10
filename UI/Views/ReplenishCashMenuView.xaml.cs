
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for ReplenishCashMenuView.xaml
    /// </summary>
    public partial class ReplenishCashMenuView : UserControl, INavigatable
    {
        public ReplenishCashMenuView()
        {
            InitializeComponent();
            DataContext = new ReplenishCashViewModel();


        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
