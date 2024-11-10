using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartRepo
    {
        void AddProductToCart(int userId, Product product, int quantity);

        // Removes a product from the user's cart
        void RemoveProductFromCart(int userId, int productId);
        Cart GetCart(int id);
        List<CartItem> GetCartItemsByUserId(int userId);

        void ClearCart(int userId); 
    }
}
