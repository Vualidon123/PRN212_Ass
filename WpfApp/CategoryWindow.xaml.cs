using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Page
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryWindow()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepo();
            LoadCategory();
        }
        public void LoadCategory()
        {
            var list = categoryRepo.GetAllCategories();
            dg_data.ItemsSource = list;
        }
        

        private void Dg_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_data.SelectedItem is Category selected)
            {
               txtCateId.Text = selected.CategoryId.ToString();
                txtCateName.Text = selected.CategoryName.ToString();
            }
        }

        private void btn_Create(object sender, RoutedEventArgs e)
        {
            try
            {
                var cate = new Category
                {
                    CategoryName = txtCateName.Text,

                };
                categoryRepo.CreateCategory(cate);
                LoadCategory();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating");
            }
        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            if (dg_data.SelectedItem is Category selected)
            {
                selected.CategoryName = txtCateName.Text;
                categoryRepo.UpdateCategory(selected);
                dg_data.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            if (dg_data.SelectedItem is Category selected)
            {
                categoryRepo.DeleteCategory(dg_data.SelectedItem as Category);
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();

        }
    }
}
