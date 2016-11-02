using Domain.Model;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            IAuthenticationService authService = new AuthenticationService();
            User user = authService.DoLogin(tbUsername.Text, pbPassword.Password);
            if(user == null)
            {
                BindingExpression bindingExpression =
                BindingOperations.GetBindingExpression(tbUsername, TextBox.TextProperty);

                BindingExpressionBase bindingExpressionBase =
                BindingOperations.GetBindingExpressionBase(tbUsername, TextBox.TextProperty);

                ValidationError validationError =
                    new ValidationError(new ExceptionValidationRule(), bindingExpression);

                Validation.MarkInvalid(bindingExpressionBase, validationError);
            }
        }
    }
}
