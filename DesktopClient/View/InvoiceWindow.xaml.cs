using System.Windows;
using DesktopClient.ViewModel;
using DomainModel.DataContracts;

namespace DesktopClient.View
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow(CheckInDto checkIn)
        {
            InitializeComponent();
            DataContext = new InvoiceViewModel(checkIn);
        }
    }
}
