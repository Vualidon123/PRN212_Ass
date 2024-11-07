using System;
using System.Windows.Controls;
using BO;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.IO;
using System.Windows;
using System.Windows.Navigation;

namespace WpfApp
{
    public partial class MainWindow : Page
    {
        private readonly IKoiRepository koiRepository;
        private readonly TestyContext context;

        public MainWindow()
        {
            InitializeComponent();
            koiRepository = new KoiRepository();
            context = new TestyContext();
            LoadKoi();
        }

        // Load data into DataGrid
        public void LoadKoi()
        {
            var koiList = koiRepository.GetKois();
            KoiFishDataGrid.ItemsSource = koiList;
        }

        // Add this method to convert image file to byte array
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

        // Modified CreateButton_Click method
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var koi = new KoiFish
                {
                    Name = NameTextBox.Text,
                    Breeder = BreederTextBox.Text,
                    Age = string.IsNullOrWhiteSpace(AgeTextBox.Text) ? null : int.Parse(AgeTextBox.Text),
                    Length = string.IsNullOrWhiteSpace(LengthTextBox.Text) ? null : double.Parse(LengthTextBox.Text),
                    Weight = string.IsNullOrWhiteSpace(WeightTextBox.Text) ? null : double.Parse(WeightTextBox.Text),
                    Price = string.IsNullOrWhiteSpace(PriceTextBox.Text) ? null : decimal.Parse(PriceTextBox.Text),
                    Variety = VarietyTextBox.Text,
                    Origin = OriginTextBox.Text,
                    Physique = PhysiqueTextBox.Text,
                    Sex = SexTextBox.Text,
                    PondId = string.IsNullOrWhiteSpace(PondIdTextBox.Text) ? null : int.Parse(PondIdTextBox.Text),
                    UserId = string.IsNullOrWhiteSpace(UserIdTextBox.Text) ? null : int.Parse(UserIdTextBox.Text),
                    InPondSince = DateOnly.TryParse(InPondSinceTextBox.Text, out var date) ? date : null,
                    Image = ConvertImageToByteArray(ImagePathTextBox.Text)
                };

                koiRepository.CreateKoi(koi);
                LoadKoi();
                ClearTextFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating KoiFish: {ex.Message}");
            }
        }

        // Update an existing KoiFish
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(KoiFishIdTextBox.Text, out int id))
            {
                var koiFish = context.KoiFishes.Find(id);
                if (koiFish != null)
                {
                    try
                    {
                        koiFish.Name = NameTextBox.Text;
                        koiFish.Breeder = BreederTextBox.Text;
                        koiFish.Age = string.IsNullOrWhiteSpace(AgeTextBox.Text) ? null : int.Parse(AgeTextBox.Text);
                        koiFish.Length = string.IsNullOrWhiteSpace(LengthTextBox.Text) ? null : double.Parse(LengthTextBox.Text);
                        koiFish.Weight = string.IsNullOrWhiteSpace(WeightTextBox.Text) ? null : double.Parse(WeightTextBox.Text);
                        koiFish.Price = string.IsNullOrWhiteSpace(PriceTextBox.Text) ? null : decimal.Parse(PriceTextBox.Text);
                        koiFish.Variety = VarietyTextBox.Text;
                        koiFish.Origin = OriginTextBox.Text;
                        koiFish.Physique = PhysiqueTextBox.Text;
                        koiFish.Sex = SexTextBox.Text;
                        koiFish.PondId = string.IsNullOrWhiteSpace(PondIdTextBox.Text) ? null : int.Parse(PondIdTextBox.Text);
                        koiFish.UserId = string.IsNullOrWhiteSpace(UserIdTextBox.Text) ? null : int.Parse(UserIdTextBox.Text);
                        koiFish.InPondSince = DateOnly.TryParse(InPondSinceTextBox.Text, out var date) ? date : null;
                        
                        // Handle image update
                        if (!string.IsNullOrEmpty(ImagePathTextBox.Text))
                        {
                            byte[]? newImage = ConvertImageToByteArray(ImagePathTextBox.Text);
                            if (newImage != null)
                            {
                                koiFish.Image = newImage;
                            }
                        }

                        koiRepository.UpdateKoi(koiFish);
                        LoadKoi();
                        MessageBox.Show("KoiFish updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating KoiFish: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid KoiFish ID.");
            }
        }

        // Delete the selected KoiFish
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(KoiFishIdTextBox.Text, out int id))
            {
                var koiFish = koiRepository.GetKoi(id);
                if (koiFish != null)
                {
                    koiRepository.DeleteKoi(koiFish);
                    LoadKoi();
                    ClearTextFields();
                }
                else
                {
                    MessageBox.Show("KoiFish not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid KoiFish ID.");
            }
        }

        // SelectionChanged event to populate text boxes when a DataGrid row is selected
        private void dg_selection(object sender, SelectionChangedEventArgs e)
        {
            if (KoiFishDataGrid.SelectedItem is KoiFish selectedKoiFish)
            {
                KoiFishIdTextBox.Text = selectedKoiFish.KoiFishId.ToString();
                NameTextBox.Text = selectedKoiFish.Name;
                BreederTextBox.Text = selectedKoiFish.Breeder;
                AgeTextBox.Text = selectedKoiFish.Age?.ToString();
                LengthTextBox.Text = selectedKoiFish.Length?.ToString();
                WeightTextBox.Text = selectedKoiFish.Weight?.ToString();
                PriceTextBox.Text = selectedKoiFish.Price?.ToString("F2");
                VarietyTextBox.Text = selectedKoiFish.Variety;
                OriginTextBox.Text = selectedKoiFish.Origin;
                PhysiqueTextBox.Text = selectedKoiFish.Physique;
                SexTextBox.Text = selectedKoiFish.Sex;
                PondIdTextBox.Text = selectedKoiFish.PondId?.ToString();
                UserIdTextBox.Text = selectedKoiFish.UserId?.ToString();
                InPondSinceTextBox.Text = selectedKoiFish.InPondSince?.ToString("yyyy-MM-dd");
                ImagePathTextBox.Text = selectedKoiFish.Image?.ToString();
                NavigationService?.Navigate(new KoiDetail(selectedKoiFish));
            }
            else
            {
                ClearTextFields();
            }
        }

        // Clears all text fields
        private void ClearTextFields()
        {
            KoiFishIdTextBox.Clear();
            NameTextBox.Clear();
            BreederTextBox.Clear();
            AgeTextBox.Clear();
            LengthTextBox.Clear();
            WeightTextBox.Clear();
            PriceTextBox.Clear();
            VarietyTextBox.Clear();
            OriginTextBox.Clear();
            PhysiqueTextBox.Clear();
            SexTextBox.Clear();
            PondIdTextBox.Clear();
            UserIdTextBox.Clear();
            ImagePathTextBox.Clear();
            InPondSinceTextBox.Text = string.Empty;
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
    }
}

