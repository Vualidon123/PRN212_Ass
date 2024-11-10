using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CartDAO
    {
        public static List<CartItem> GetCartItemsByUserId(int userId)
        {
            try
            {
                using var _context = new TestyContext();

                // Fetch the Cart for the specified userId
                var cart = _context.Carts
                                   .Where(c => c.UserId == userId)  // Filter by UserId
                                   .Include(c => c.CartItems)       // Include CartItems of this Cart
                                   .ThenInclude(ci => ci.Product)   // Include related Product data for CartItems
                                   .FirstOrDefault();               // Get the first cart (or null if not found)

                if (cart == null)
                {
                    return new List<CartItem>();  // Return an empty list if no cart is found for this user
                }

                return cart.CartItems.ToList();  // Return the CartItems associated with the Cart
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cart items", ex);
            }
        }
        public static Cart GetCartById(int id)
        {


            using var context = new TestyContext();
            return context.Carts.FirstOrDefault(x => x.Id == id);

        }
        public static void AddToCart(int userId, Product product, int quantity)
        {
            try
            {
                using var context = new TestyContext();

                // Validate product
                if (product == null || product.Id <= 0)
                {
                    throw new ArgumentException("Invalid product specified");
                }

                // Find or create the cart
                var cart = context.Carts.FirstOrDefault(c => c.UserId == userId);
                if (cart == null)
                {
                    cart = new Cart { UserId = userId };
                    context.Carts.Add(cart);
                    context.SaveChanges();  // Save the cart to get the cart's ID
                }

                // Ensure the product exists
                var existingProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct == null)
                {
                    throw new Exception("Product does not exist.");
                }

                // Find or create the cart item
                var cartItem = context.CartItems
                    .FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == product.Id);

                if (cartItem != null)
                {
                    // Update quantity
                    cartItem.Quantity += quantity;
                }
                else
                {
                    // Add new CartItem
                    cartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = product.Id,
                        Quantity = quantity
                    };
                    context.CartItems.Add(cartItem);
                }

                // Save changes
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }



        public static void RemoveFromCart(int userId, int productId)
        {
            try
            {
                using var context = new TestyContext();

                // Find the user's cart
                var cart = context.Carts.FirstOrDefault(c => c.UserId == userId);

                if (cart == null)
                {
                    throw new Exception("Cart not found for this user.");
                }

                // Find the cart item corresponding to the productId
                var cartItem = context.CartItems
                    .FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == productId);

                if (cartItem != null)
                {
                    // Remove the cart item (product) from the cart
                    context.CartItems.Remove(cartItem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product not found in cart.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while removing the product from the cart: " + ex.Message);
            }
        }
        public static void ClearCart(int userId)
        {
            try
            {
                using var context = new TestyContext();

                // Find the cart for the specified user
                var cart = context.Carts
                                  .Where(c => c.UserId == userId)
                                  .Include(c => c.CartItems)  // Include CartItems to delete them
                                  .FirstOrDefault();

                if (cart == null || !cart.CartItems.Any())
                {
                    throw new Exception("No items found in the cart for this user.");
                }

                // Remove all items in the user's cart
                context.CartItems.RemoveRange(cart.CartItems);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while clearing the cart: " + ex.Message);
            }
        }

    }
}

