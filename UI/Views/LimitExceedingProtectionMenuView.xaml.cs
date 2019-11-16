
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;

namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for LimitExceedingProtectionMenuView.xaml
    /// </summary>
    public partial class LimitExceedingProtectionMenuView : UserControl, INavigatable
    {
        public LimitExceedingProtectionMenuView()
        {
            InitializeComponent();
            DataContext = new LimitExceedingProtectionViewModel();
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
