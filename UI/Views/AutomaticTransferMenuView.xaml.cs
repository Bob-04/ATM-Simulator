
using System.Text.RegularExpressions;

using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for AutomaticTransferMenuView.xaml
    /// </summary>
    public partial class AutomaticTransferMenuView : UserControl, INavigatable
    {
        public AutomaticTransferMenuView()
        {
            InitializeComponent();
            DataContext = new AutomaticTransferMenuViewModel();
        }

        public object GetContext()
        {
            return this.DataContext;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
