
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for WithdrawMenuView.xaml
    /// </summary>
    public partial class WithdrawMenuView : UserControl, INavigatable
    {
        public WithdrawMenuView()
        {
            InitializeComponent();
            DataContext = new WithdrawViewModel();
        }
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
    public object GetContext()
    {
        return this.DataContext;
    }
    }
}
