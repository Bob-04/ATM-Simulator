
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.MOOP.ATM.AdministratorUI.Tools.Navigation;
using KMA.MOOP.ATM.AdministratorUI.ViewModels;

namespace KMA.MOOP.ATM.AdministratorUI.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInClientView.xaml
    /// </summary>
    public partial class SignInClientView : UserControl, INavigatable
    {
        public SignInClientView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
