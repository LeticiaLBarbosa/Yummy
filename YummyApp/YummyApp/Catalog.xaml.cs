using System;
using System.Collections.Generic;
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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        yummyDatabaseDataContext dc = new yummyDatabaseDataContext();
        public Catalog()
        {
            InitializeComponent();
            fillCategoryComboBox();
            fillCategoryImage();
        }

        //fill the category Dropbox at loading time
        private void fillCategoryComboBox()
        {
            List<Category> data = dc.Categories.ToList();
            searchCategory.ItemsSource = data;
            searchCategory.DisplayMemberPath = "CategoryName";
            searchCategory.SelectedValuePath = "CategoryId";
        }


        private void categorySelectedFromComboBox(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = searchCategory.SelectedItem as Category;
            MessageBox.Show(selectedCategory.CategoryId.ToString() + ' '+ selectedCategory.CategoryName);
        }

     
    }
}
