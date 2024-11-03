using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
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
    }
}