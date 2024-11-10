using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepo
    {
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}
