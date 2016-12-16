using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using DesktopClient.BedroomService;
using DesktopClient.CheckInService;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Helpers;
using DesktopClient.View;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace DesktopClient.Managers
{
    internal class ViewManager
    {
        private LoginWindow loginWindow;
       // private CheckInService checkInService;
        private ICheckInService checkInService;
        private IBedroomService bedroomService;
        private string userName;

        public ViewManager(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            loginWindow.Show();
            checkInService = new CheckInServiceClient();
            bedroomService = new BedroomServiceClient();
            subscribeEvents();
        }

        private void subscribeEvents()
        {
            Managers.EventManager.UserLoggedIn += onUserLoggedIn;
            Managers.EventManager.CheckTheInvoiceButtonPressed += onCheckTheInvoiceButtonPressed;
            Managers.EventManager.SaveNewBedroomButtonPressed += onSaveNewBedroomButtonPressed;
            Managers.EventManager.CreateNewBedroomButtonPressed += onCreateNewBedroomButtonPressed;
            Managers.EventManager.DeleteBedroomButtonPressed += onDeleteBedroomButtonPressed;
            Managers.EventManager.UpdateBedroomButtonPressed += onUpdateBedroomButtonPressed;
            Managers.EventManager.DeleteCheckInButtonPressed += onDeleteCheckInButtonPressed;
            Managers.EventManager.CancelInvoiceButtonPressed += onCancelInvoiceButtonPressed;
            Managers.EventManager.SaveCheckInAndPrintInvoiceButtonPressed += onSaveCheckInAndPrintInvoiceButtonPressed;
        }

        private async void onSaveCheckInAndPrintInvoiceButtonPressed(object source, CheckInEventArgs eventArgs)
        {
            
            await checkInService.CreateAsync(eventArgs.CheckIn);
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                window.Close();
            }

            InvoiceCreator pdfCreator= new InvoiceCreator();
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false,PdfFontEmbedding.Always);
            pdfRenderer.Document = pdfCreator.CreateDocument(eventArgs.CheckIn, "Manager: " + userName);
            pdfRenderer.RenderDocument();
            string filename = eventArgs.CheckIn.Id+".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);

        }

        private void onCancelInvoiceButtonPressed(object source, EventArgs eventArgs)
        {
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                window.Close();
            }
        }

        private async void onDeleteCheckInButtonPressed(object source, CheckInEventArgs eventArgs)
        {
            await checkInService.DoCheckOutAsync(eventArgs.CheckIn);
        }

        private async void onDeleteBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            await bedroomService.RemoveAsync(eventArgs.Bedroom);
        }

        private void onUpdateBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            new BedroomEditorWindow(eventArgs).Show();
        }

        private void onCheckTheInvoiceButtonPressed(object source,CheckInEventArgs eventArgs)
        {
            new InvoiceWindow(eventArgs.CheckIn).Show();
        }

        private async void onSaveNewBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            await bedroomService.CreateOrUpdateAsync(eventArgs.Bedroom);
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                window.Close();
            }
        }

        private void onCreateNewBedroomButtonPressed(object source,EventArgs eventArgs)
        {
            new BedroomEditorWindow().Show();
        }
        
        private void onUserLoggedIn(object source, UserEventArgs eventArgs)
        {
            new CheckInManagementWindow(eventArgs).Show();
            userName= eventArgs.UserName;
            loginWindow.Close();
        }
    }
}