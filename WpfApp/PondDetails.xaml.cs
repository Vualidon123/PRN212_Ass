using BO;
using Service;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public partial class PondDetails : Page
    {
        private readonly Pond _pond;
        private readonly IPondService _pondService;

        public PondDetails(Pond pond, IPondService pondService)
        {
            InitializeComponent();
            _pond = pond;
            _pondService = pondService;
            LoadPondDetails();
        }

        private void LoadPondDetails()
        {
            this.DataContext = _pond;
            if (_pond.Picture != null && _pond.Picture.Length > 0)
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(_pond.Picture))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = ms;
                        image.EndInit();
                    }
                    PondImage.Source = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            else
            {
                // Optionally set a placeholder image or hide the image control
                PondImage.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _pond.Name = NameTextBox.Text;
                _pond.Volume = string.IsNullOrWhiteSpace(VolumeTextBox.Text) ? null : double.Parse(VolumeTextBox.Text);
                _pond.Depth = string.IsNullOrWhiteSpace(DepthTextBox.Text) ? null : double.Parse(DepthTextBox.Text);
                _pond.Drain = string.IsNullOrWhiteSpace(DrainTextBox.Text) ? null : int.Parse(DrainTextBox.Text);
                _pond.Location = LocationTextBox.Text;
                _pond.Skimmers = string.IsNullOrWhiteSpace(SkimmersTextBox.Text) ? null : int.Parse(SkimmersTextBox.Text);
                _pond.WaterSource = WaterSourceTextBox.Text;
                _pond.PumpingCapacity = string.IsNullOrWhiteSpace(PCTextBox.Text) ? null : int.Parse(PCTextBox.Text);

                _pondService.UpdatePond(_pond);

                MessageBox.Show("Pond updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Pond: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PondPage());
        }
    }
}