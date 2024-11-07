using BO;
using Service;
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Printing;

namespace WpfApp
{
    public partial class PondPage : Page
    {
        private readonly IPondService pondService;
        private readonly TestyContext context;

        public PondPage()
        {
            InitializeComponent();
            pondService = new PondService();
            context = new TestyContext();
            LoadPond();
        }

        private byte[]? ConvertImageToByteArray(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return null;

            try
            {
                return File.ReadAllBytes(imagePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading image file.");
                return null;
            }
        }

        public void LoadPond()
        {
            var pondList = pondService.GetAllPond();
            PondDataGrid.ItemsSource = pondList;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pond = new Pond
                {
                    Name = NameTextBox.Text,
                    Volume = string.IsNullOrWhiteSpace(VolumeTextBox.Text) ? null : double.Parse(VolumeTextBox.Text),
                    Depth = string.IsNullOrWhiteSpace(DepthTextBox.Text) ? null : double.Parse(DepthTextBox.Text),
                    Drain = string.IsNullOrWhiteSpace(DrainTextBox.Text) ? null : int.Parse(DrainTextBox.Text),
                    Location = LocationTextBox.Text,
                    Skimmers = string.IsNullOrWhiteSpace(SkimmersTextBox.Text) ? null : int.Parse(SkimmersTextBox.Text),
                    WaterSource = WaterSourceTextBox.Text,
                    PumpingCapacity = string.IsNullOrWhiteSpace(PCTextBox.Text) ? null : int.Parse(PCTextBox.Text),
                    Picture = ConvertImageToByteArray(ImagePathTextBox.Text)
                };

                pondService.CreatePond(pond);
                LoadPond();
                ClearTextFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Pond: {ex.Message}");
            }
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PondIdTextBox.Text, out int id))
            {
                var pond = pondService.GetPondById(id);
                if (pond != null)
                {
                    pondService.DeletePond(pond);
                    LoadPond();
                    ClearTextFields();
                }
                else
                {
                    MessageBox.Show("Pond not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Pond ID.");
            }
        }

        private void dg_selection(object sender, SelectionChangedEventArgs e)
        {
            if (PondDataGrid.SelectedItem is Pond selectedPond)
            {
                PondIdTextBox.Text = selectedPond.PondId.ToString();
                NameTextBox.Text = selectedPond.Name;
                VolumeTextBox.Text = selectedPond.Volume?.ToString();
                DepthTextBox.Text = selectedPond.Depth?.ToString();
                LocationTextBox.Text = selectedPond.Location;
                DrainTextBox.Text = selectedPond.Drain?.ToString();
                WaterSourceTextBox.Text = selectedPond.WaterSource?.ToString();
                PCTextBox.Text = selectedPond.PumpingCapacity.ToString();
                SkimmersTextBox.Text = selectedPond.Skimmers?.ToString();
            }
            else
            {
                ClearTextFields();
            }
        }

        private void ClearTextFields()
        {
            PondIdTextBox.Clear();
            NameTextBox.Clear();
            VolumeTextBox.Clear();
            DepthTextBox.Clear();
            LocationTextBox.Clear();
            ImagePathTextBox.Clear();
            PCTextBox.Clear();
            SkimmersTextBox.Clear();
            WaterSourceTextBox.Clear();
            DrainTextBox.Clear();
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void PondIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null)
            {
                int pondId = Convert.ToInt32(button.Tag);
                var selectedPond = pondService.GetPondById(pondId);

                if (selectedPond != null)
                {
                    PondDetails pondDetailsPage = new PondDetails(selectedPond, pondService);
                    NavigationService.Navigate(pondDetailsPage);
                }
                else
                {
                    MessageBox.Show("Pond not found.");
                }
            }
        }
    }
}