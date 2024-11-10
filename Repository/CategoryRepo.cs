using BO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        public void CreateCategory(Category category)
       =>CategoryDAO.CreateCategory(category);

        public void DeleteCategory(Category category)
       =>CategoryDAO.DeleteCategory(category);

        public List<Category> GetAllCategories()
       => CategoryDAO.GetCategory();

        public Category GetCategory(int id)
        =>CategoryDAO.GetCategoryById(id);

        public void UpdateCategory(Category category)
        =>CategoryDAO.UpdateCategory(category);
    }
}
