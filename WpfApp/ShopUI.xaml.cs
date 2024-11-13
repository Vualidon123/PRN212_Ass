using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ShopUI.xaml
    /// </summary>
    public partial class ShopUI : Page
    {
        private readonly IProductRepo productRepo;
        private readonly ICartRepo cartRepo;

        // Observable collection to hold CartItems
        private ObservableCollection<CartItem> cartItems;

        public ShopUI()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
            cartRepo = new CartRepo();
            cartItems = new ObservableCollection<CartItem>(); // Initialize ObservableCollection
            cartList.ItemsSource = cartItems; // Bind the ListBox to the ObservableCollection
            LoadProduct();
            DataContext = this;
        }

        public void LoadProduct()
        {
            var list = productRepo.GetAllProducts();
            dg_products.ItemsSource = list;
        }

        private void Dg_Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_products.SelectedItem is Product selectedProduct)
            {
                txtProductName.Text = selectedProduct.ProductName;
                txtPrice.Text = selectedProduct.Price?.ToString("C") ?? "$0.00";
                txtDescription.Text = selectedProduct.Description;

                // Enable the "Add to Cart" button when a product is selected
                btnAddtoCart.IsEnabled = true;
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dg_products.SelectedItem as Product;
            if (selectedProduct != null)
            {
                CartItem cartItem = new CartItem
                {
                    Product = selectedProduct,
                    Quantity = 1,
                    Date = DateTime.Now
                };

                cartItems.Add(cartItem);
                UpdateTotal(); // Update the total after adding item
            }
        }

        private void UpdateTotal()
        {
            decimal total = cartItems.Sum(item => item.Product.Price.GetValueOrDefault() * item.Quantity);
            txtTotalPrice.Text = total.ToString("C");
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before checking out.");
                return;
            }

            decimal total = cartItems.Sum(item => item.Product.Price.GetValueOrDefault() * item.Quantity);
            MessageBox.Show($"Proceeding to checkout...\nTotal Amount: {total:C}");

            cartItems.Clear();
            UpdateTotal(); // Update the total after clearing cart
        }
        private void cartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cartList.SelectedItem is CartItem selectedItem)
            {
                txtProductName.Text = selectedItem.Product.ProductName;
                txtPrice.Text = selectedItem.Product.Price?.ToString("C") ?? "$0.00";
                txtDescription.Text = selectedItem.Product.Description ?? "No description available";
                btnAddtoCart.IsEnabled = true;
            }
            else
            {
                txtProductName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDescription.Text = string.Empty;
                btnAddtoCart.IsEnabled = false;
            }
        }

      
    }
    }
