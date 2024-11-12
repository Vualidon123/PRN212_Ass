using BO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class Menu : Window
    {
        private int userRole;
        public Menu()
        {
            InitializeComponent();

            // Show the button if role is 3
            if (userRole == 3)
            {
                btnShopManagement.Visibility = Visibility.Visible;
            }
        }
        
        private void KoiFishButton_Click(object sender, RoutedEventArgs e)
        {
            // Convert MainWindow to a Page first
            MainFrame.Navigate(new MainWindow());
        }

        private void PondButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PondPage());
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
          MainFrame.Navigate(new ShopUI());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Shop_management());

        }
    }
}