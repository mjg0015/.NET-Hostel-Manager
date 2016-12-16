using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DesktopClient.BedroomService;
using DesktopClient.CheckInService;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Helpers;
using DesktopClient.View;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using DesktopClient.ViewModel;

namespace DesktopClient.Managers
{
    internal class ViewManager
    {
        private LoginWindow loginWindow;
        private ICheckInService checkInService;
        private IBedroomService bedroomService;
        private CheckInManagementViewModel checkInManagementViewModel;
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
            
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                window.Close();
            }

            InvoiceCreator pdfCreator= new InvoiceCreator();
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false,PdfFontEmbedding.Always);
            pdfRenderer.Document = pdfCreator.CreateDocument(eventArgs.CheckIn, "Manager: " + userName);
            pdfRenderer.RenderDocument();
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss")+".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
            eventArgs.CheckIn.ArrivingDate = eventArgs.CheckIn.ArrivingDate.AddDays(1);
            eventArgs.CheckIn.DepartureDate = eventArgs.CheckIn.DepartureDate.AddDays(1);
            await checkInService.CreateAsync(eventArgs.CheckIn).ContinueWith(antecendent => checkInManagementViewModel.reloadData());
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
            await checkInService.DoCheckOutAsync(eventArgs.CheckIn).ContinueWith(antecendent => checkInManagementViewModel.reloadData()); ;
        }

        private async void onDeleteBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            await bedroomService.RemoveAsync(eventArgs.Bedroom).ContinueWith(antecendent => checkInManagementViewModel.reloadData()); ;
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
            await bedroomService.CreateOrUpdateAsync(eventArgs.Bedroom).ContinueWith(antecendent => checkInManagementViewModel.reloadData());
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
            var checkInManagementWindow = new CheckInManagementWindow(eventArgs);
            checkInManagementWindow.Show();
            checkInManagementViewModel = (CheckInManagementViewModel) checkInManagementWindow.DataContext;
            userName = eventArgs.UserName;
            loginWindow.Close();
        }
    }
}