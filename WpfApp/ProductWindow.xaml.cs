using BO;
using Repository;
using System;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Page
    {
        private readonly IProductRepo productRepo;
        public ProductWindow()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
            LoadProduct();
        }
        private void LoadProduct()
        {
            var list = productRepo.GetAllProducts();
            dg_data.ItemsSource = list;
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

        private void Dg_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_data.SelectedItem is Product selected)
            {
                txtProductId.Text = selected.Id.ToString();
                txtPrice.Text = selected.Price.ToString();
                txtAmount.Text = selected.Amount.ToString();
                txtCateId.Text = selected.CategoryId.ToString();
                txtDescription.Text = selected.Description.ToString();
                txtProductName.Text = selected.ProductName.ToString();
                txtRating.Text = selected.ProductRating.ToString();
                txtCreateAt.Text = selected.CreatedAt.ToString();
                txtExpiresAt.Text = selected.ExpiresAt.ToString();
             
            }
        }

        private void btn_Create(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductName = txtProductName.Text,
                    ProductImage = ConvertImageToByteArray(ImagePathTextBox.Text),
                    CategoryId = int.Parse(txtCateId.Text),
                    Description = txtDescription.Text,
                    CreatedAt = DateTime.Parse(txtCreateAt.Text),
                    ExpiresAt = DateTime.Parse(txtExpiresAt.Text),
                    Price = int.Parse(txtPrice.Text),
                    Amount = int.Parse(txtAmount.Text),
                    ProductRating = double.Parse(txtRating.Text),
                };
                productRepo.CreateProduct(product);
                LoadProduct();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Product: {ex.Message}");

            }
        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            if (dg_data.SelectedItem is Product selected)
            {
                selected.ProductName = txtProductName.Text;
                selected.Price = int.Parse(txtPrice.Text);
                selected.Amount = int.Parse(txtAmount.Text);
                selected.Description = txtDescription.Text;
                selected.CreatedAt = DateTime.Parse(txtCreateAt.Text);
                selected.ExpiresAt = DateTime.Parse(txtExpiresAt.Text);
                selected.ProductRating = int.Parse(txtRating.Text);
                selected.ProductImage = ConvertImageToByteArray(ImagePathTextBox.Text);
                productRepo.UpdateProduct(selected);
                dg_data.Items.Refresh();
            }

        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            if (dg_data.SelectedItem is Product selected)
            {
               productRepo.DeleteProduct(dg_data.SelectedItem as Product);
                MessageBox.Show("Customer delete success");
                LoadProduct();
            }
            else
            {
                MessageBox.Show("Error in deleting");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
