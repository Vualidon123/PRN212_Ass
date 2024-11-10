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
    public partial class ShopUI : Window
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

                cartItems.Add(cartItem);  // Add CartItem to ObservableCollection
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (CartItem cartItem in cartItems)  // Iterate through CartItem objects
            {
                total += cartItem.Product.Price.GetValueOrDefault() * cartItem.Quantity;
            }

            txtTotalPrice.Text = total.ToString("C");
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before checking out.");
                return;
            }

            // Assuming you will have a backend or service to handle the checkout process here
            MessageBox.Show("Proceeding to checkout...");

            // Clear the cart items after checkout
            cartItems.Clear();

            // Update the total price display
            txtTotalPrice.Text = "$0.00";
        }

        private void cartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure that there is a selected item
            if (cartList.SelectedItem != null)
            {
                // Cast the selected item to the CartItem class
                var selectedItem = (CartItem)cartList.SelectedItem;

                // Display the product details in the text boxes
                txtProductName.Text = selectedItem.Product.ProductName;  // Corrected the property name
                txtPrice.Text = selectedItem.Price.ToString("C"); // Format as currency
                txtDescription.Text = selectedItem.Product.Description ?? "No description available"; // Assuming you have a description field in CartItem

                btnAddtoCart.IsEnabled = true; // Enable the "Add to Cart" button
            }
            else
            {
                // Clear textboxes and disable the "Add to Cart" button when no item is selected
                txtProductName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDescription.Text = string.Empty;
                btnAddtoCart.IsEnabled = false;
            }
        }

        private void txtTotalPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal total = 0;

            foreach (var item in cartItems)  // Replace 'CartItems' with your actual collection of cart items
            {
                total += item.Price * item.Quantity;  // Assuming Quantity is a property of CartItem
            }

            // Update the total price display
            txtTotalPrice.Text = total.ToString("C");
        }
    }
    }
