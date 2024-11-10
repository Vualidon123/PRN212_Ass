using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;
        public ProductService() { 
            repo = new ProductRepo();
        }

        public void CreateProduct(Product product)
        {
            repo.CreateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProduct(id);
        }

        public void UpdateProduct(Product product)
        {
             repo.UpdateProduct(product);
        }
    }
}
