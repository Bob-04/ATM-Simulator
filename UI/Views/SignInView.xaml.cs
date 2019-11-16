
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;
using KMA.MOOP.ATM.UI.ViewModels;


namespace KMA.MOOP.ATM.UI.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SignInView : UserControl, INavigatable
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel(this);
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
