using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CartItemDAO
    {
        public static List<CartItem> getAllItem() {
            var list = new List<CartItem>();
            try
            {
                using var context = new TestyContext();
                list = context.CartItems.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        } 
    }
}
