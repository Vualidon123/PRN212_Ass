using BO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepo : IProductRepo
    {
        public void CreateProduct(Product product)
        =>ProductDAO.CreateProduct(product);
        

        public void DeleteProduct(Product product)
        =>ProductDAO.DeleteProduct(product);

        public List<Product> GetAllProducts()
        => ProductDAO.GetProduct();

        public Product GetProduct(int id)
        =>ProductDAO.GetProductById(id);

        public void UpdateProduct(Product product)
        =>ProductDAO.UpdateProduct(product);
    }
}
