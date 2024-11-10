using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }
        public void CreateCategory(Category category)
        {
            _categoryRepo.CreateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepo.DeleteCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public Category GetCategory(int id)
        {
            return _categoryRepo.GetCategory(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepo.UpdateCategory(category);
        }
    }
}
