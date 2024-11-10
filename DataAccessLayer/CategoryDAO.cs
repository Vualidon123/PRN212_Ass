using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategory()
        {
            var list = new List<Category>();
            try
            {
                using var context = new TestyContext();
                list = context.Categories.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Category GetCategoryById(int id)
        {


            using var context = new TestyContext();
            return context.Categories.FirstOrDefault(x => x.CategoryId == id);

        }
        public static void CreateCategory(Category category)
        {
            try
            {
                using var context = new TestyContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteCategory(Category category)
        {
            try
            {
                using var context = new TestyContext();
                var p1 = context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
                    context.Categories.Remove(p1);
                context.SaveChanges();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateCategory(Category category)
        {
            try
            {
                using var context = new TestyContext();
                context.Entry<Category>(category).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
