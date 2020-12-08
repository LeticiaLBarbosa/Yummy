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
            myCategories = new List<MediaData>();
            myRecipes = new List<MediaData>();
            catTable = dc.Categories.ToList();
            recTable = dc.Recipes.ToList();
            ShowCategories();
            ShowRecipes();
        }

        private void ShowCategories()
        {
            foreach (var categoryObj in catTable)
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

            CategoriesCarousel.ItemsSource = myCategories;
        }
        
        private void ShowRecipes()
        {
            foreach (var recipeObj in recTable)
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

            RecipesCarousel.ItemsSource = myRecipes;
        }

        private void SearchCategory_Click(object sender, RoutedEventArgs e)
        {
            
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
    }
}
