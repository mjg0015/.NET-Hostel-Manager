using System.Windows;
using DesktopClient.ViewModel;

namespace DesktopClient.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            DataContext =viewModel;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.User.Password = pbPassword.Password;
        }
    }
}
