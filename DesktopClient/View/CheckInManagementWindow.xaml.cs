﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xaml.Permissions;
using System.Xml;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.ViewModel;

namespace DesktopClient.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CheckInManagementWindow : Window
    {
        public CheckInManagementWindow(UserEventArgs eventArgs)
        {
            InitializeComponent();
            DataContext = new CheckInManagementViewModel(eventArgs);
         
        }
    }
}
