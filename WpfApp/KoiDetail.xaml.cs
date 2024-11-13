using BO;
using System;
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
using System.IO;
using Repository;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for KoiDetail.xaml
    /// </summary>
    public partial class KoiDetail : Page
    {
        private readonly IKoiRepository koiRepository;
        private readonly TestyContext context;
        public KoiDetail(KoiFish koiFish)
        {
            InitializeComponent();
            DataContext = koiFish;
            DisplayKoiInfo(koiFish);
            DisplayKoiImage(koiFish.Image);
            koiRepository = new KoiRepository();
            context = new TestyContext();
        }

        private void DisplayKoiImage(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                try
                {
                    var image = new BitmapImage();
                    using (var mem = new MemoryStream(imageData))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = mem;
                        image.EndInit();
                    }
                    KoiImage.Source = image;
                }   
                catch
                {
                    // Handle image loading error
                    MessageBox.Show("Error loading image");
                }
            }
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

        private void DisplayKoiInfo(KoiFish koiFish)
        {
            KoiFishIdTextBox.Text = koiFish.KoiFishId.ToString();
            NameTextBox.Text = koiFish.Name;
            BreederTextBox.Text = koiFish.Breeder;
            AgeTextBox.Text = koiFish.Age?.ToString();
            LengthTextBox.Text = koiFish.Length?.ToString();
            WeightTextBox.Text = koiFish.Weight?.ToString();
            PriceTextBox.Text = koiFish.Price?.ToString();
            VarietyTextBox.Text = koiFish.Variety;
            OriginTextBox.Text = koiFish.Origin;
            PhysiqueTextBox.Text = koiFish.Physique;
            SexTextBox.Text = koiFish.Sex;
            PondIdTextBox.Text = koiFish.PondId?.ToString();
        
            InPondSinceTextBox.SelectedDate = koiFish.InPondSince?.ToDateTime(TimeOnly.MinValue);
        }
    }
}
