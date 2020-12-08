using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace YummyApp
{
    /// <summary>
    /// Interaction logic for CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : Window
    {
        yummyDatabaseDataContext dc = new yummyDatabaseDataContext();
        BitmapImage image;
        Category category = new Category();
        public CategoryForm(Category categoryObj)
        {
            InitializeComponent();
            if (categoryObj != null)
                loadCategoryForm(categoryObj);
        }

        //load catageory 
        private void loadCategoryForm(Category categoryObj)
        {
            try
            {
                categoryName.Text = categoryObj.CategoryName;
                //store categoryId to get at edit time
                category.CategoryId = categoryObj.CategoryId;
                if (categoryObj.CategoryImage != null)
                {
                    image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(categoryObj.CategoryImage.ToArray());
                    image.EndInit();
                    categoryImg.Source = image;
                }
                //get recipes of category
                recipeDataGrid.ItemsSource = from R in dc.Recipes where R.Category == categoryObj.CategoryId select new { Receipe = R.Name };
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, " error");
            }
        
        }

        //handle edit operation(categoryId present in Editing mode)
        private void editCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (category.CategoryId != 0)
                {
                    ModifyCategory mc = new ModifyCategory(category.CategoryId);
                    mc.Show();
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, " error");
            }
        }

        //handle add operation(No CategoryId in Adding mode)
        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyCategory mc = new ModifyCategory();
                mc.modifyCategory.Content = "ADD";
                mc.modifyName.Focus();
                mc.LMlabel.Visibility = Visibility.Hidden;
                mc.LMdateLabel.Visibility = Visibility.Hidden;
                mc.LMtimeLabel.Visibility = Visibility.Hidden;
                mc.LMdate.Visibility = Visibility.Hidden;
                mc.LMtime.Visibility = Visibility.Hidden;
                mc.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, " error");
            }
        }

        private void closeCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Catalog ct = new Catalog();
                ct.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, " error");
            }
           
        }
    }
}
