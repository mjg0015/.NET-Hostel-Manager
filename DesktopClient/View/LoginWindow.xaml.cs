using System.Windows;
using DesktopClient.ViewModel;

namespace DesktopClient.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel viewModel;
        public LoginWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            DataContext =viewModel;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.UserPassword = pbPassword.Password;
        }
    }
}
