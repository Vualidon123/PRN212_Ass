﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Shop_management.xaml
    /// </summary>
    public partial class Shop_management : Page
    {
        public Shop_management()
        {
            InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductWindow());
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryWindow());

        }


    }
}
