using BO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepo : ICartRepo
    {
        public void AddProductToCart(int userId, Product product,int quantity)
       => CartDAO.AddToCart(userId,product,quantity);

        public void RemoveProductFromCart(int userId, int productId)
       =>CartDAO.RemoveFromCart(userId,productId);

        public Cart GetCart(int id)
        =>CartDAO.GetCartById(id);

        public List<CartItem> GetCartItemsByUserId(int userId)
        => CartDAO.GetCartItemsByUserId(userId);

        public void ClearCart(int userId)
        =>CartDAO.ClearCart(userId);
    }
}
