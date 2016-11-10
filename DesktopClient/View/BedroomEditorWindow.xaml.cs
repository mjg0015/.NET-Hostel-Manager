using System.Windows;
using DesktopClient.ViewModel;


namespace DesktopClient.View
{
    /// <summary>
    /// Interaction logic for BedroomEditorWindow.xaml
    /// </summary>
    public partial class BedroomEditorWindow : Window
    {
        public BedroomEditorWindow()
        {
            DataContext = new BedroomEditorViewModel();
            InitializeComponent();
        }
    }
}
