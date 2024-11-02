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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for KoiDetail.xaml
    /// </summary>
    public partial class KoiDetail : Window
    {
        public KoiDetail(KoiFish koiFish)
        {
            InitializeComponent();
            DataContext = koiFish;
            DisplayKoiImage(koiFish.Image);
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
    }
}
