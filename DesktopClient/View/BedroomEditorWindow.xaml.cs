using System.Windows;
using DesktopClient.EventArgsExtenctions;

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

        public BedroomEditorWindow(BedroomEventArgs eventArgs)
        {
            DataContext = new BedroomEditorViewModel(eventArgs);
            InitializeComponent();
        }
    }
}
