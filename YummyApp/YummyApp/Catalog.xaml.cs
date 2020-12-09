using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Drawing;

namespace YummyApp
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        yummyDatabaseDataContext dc;
        List<MediaData> myCategories;
        List<MediaData> myRecipes;
        List<Category> catTable;
        List<Recipe> recTable;

        public Catalog()
        { 
            InitializeComponent();
            dc = new yummyDatabaseDataContext();
            ShowCategories();
            ShowRecipes();
        }

        private void loadDataToDisplay(List<Recipe> tab)
        {
            myRecipes = new List<MediaData>();
            foreach (var recipeObj in tab)
            {
                MediaData cnt = new MediaData();
                if (recipeObj.Image != null)
                {
                    cnt.ImageData = ByteArrayToImage(recipeObj.Image.ToArray());
                }
                cnt.Id = recipeObj.RecipeId;
                cnt.Title = recipeObj.Name;
                cnt.Description = recipeObj.Description;
                myRecipes.Add(cnt);
            }
        }
        
        private void loadDataToDisplay(List<Category> tab)
        {
            myCategories = new List<MediaData>();
            foreach (var categoryObj in tab)
            {
                MediaData cnt = new MediaData();
                if (categoryObj.CategoryImage != null)
                {
                    cnt.ImageData = ByteArrayToImage(categoryObj.CategoryImage.ToArray());
                }
                cnt.Id = categoryObj.CategoryId;
                cnt.Title = categoryObj.CategoryName;
                myCategories.Add(cnt);
            }
        }

        private void ShowCategories()
        {
           var query = (from Cat in dc.Categories orderby Cat.CategoryName ascending select Cat).Take(5);
            catTable = query.ToList();
            loadDataToDisplay(catTable);
            CategoriesCarousel.ItemsSource = myCategories;
        }
        
        private void ShowRecipes()
        {
            var query = (from Rec in dc.Recipes orderby Rec.Name ascending select Rec).Take(4);
            recTable = query.ToList();
            loadDataToDisplay(recTable);
            RecipesCarousel.ItemsSource = myRecipes;
        }

        public BitmapImage ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void InspectRecipe(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipesCarousel.SelectedItem != null)
            {
                PrintRecipe printRecipe = new PrintRecipe((RecipesCarousel.SelectedItem as MediaData).Id);
                printRecipe.ShowDialog();
            }
        }
        
        private void InspectCategory(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CategoriesCarousel.SelectedItem != null)
            {
                int categoryId = (CategoriesCarousel.SelectedItem as MediaData).Id;
                Category category = dc.Categories.Where(cat => cat.CategoryId == categoryId).Single();
                CategoryForm cf = new CategoryForm(category);
                cf.Show();
            }
        }

        private void SearchCategory_Click(object sender, RoutedEventArgs e)
        {
            var tab = (from C in dc.Categories where C.CategoryName.ToUpper().Contains(SearchCategoryInput.Text.ToUpper()) orderby C.CategoryName ascending select C).Take(5);

            loadDataToDisplay(tab.ToList());

            CategoriesCarousel.ItemsSource = myCategories;
        }

        private void SearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            var tab = (from R in dc.Recipes where R.Name.ToUpper().Contains(SearchRecipeInput.Text.ToUpper()) orderby R.Name ascending select R).Take(4);

            loadDataToDisplay(tab.ToList());

            RecipesCarousel.ItemsSource = myRecipes;
        }

        private void SeeMoreRecipesClick(object sender, MouseButtonEventArgs e)
        {
            extra recipePage = new extra();
            recipePage.Show();
        }

        private void SeeMoreCategoriesClick(object sender, MouseButtonEventArgs e)
        {
            CategoryPage categoryPage = new CategoryPage();
            categoryPage.Show();
        }
    }
}
