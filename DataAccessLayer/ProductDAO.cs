using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        public static List<Product> GetProduct()
        {
            var list = new List<Product>();
            try
            {
                using var context = new TestyContext();
                list = context.Products.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Product GetProductById(int id)
        {


            using var context = new TestyContext();
            return context.Products.FirstOrDefault(x => x.Id == id);

        }
        public static void CreateProduct(Product product)
        {
            try
            {
                using var context = new TestyContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(Product product)
        {
            try
            {
                using var context = new TestyContext();
                var p1 = context.Products.SingleOrDefault(x=> x.Id == product.Id);
                    context.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new TestyContext();
                context.Entry<Product>(product).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

