using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace YummyApp
{
    /// <summary>
    /// Interaction logic for RecipesCatalogPage.xaml
    /// </summary>
    public partial class RecipesCatalogPage : Page
    {
        yummyDatabaseDataContext dc;
        List<MediaData> myRecipes;
        List<Recipe> recTable;

        public RecipesCatalogPage()
        {
            InitializeComponent();
            ShowRecipes();
        }

        private void loadDataToDisplay(List<Recipe> tab)
        {
            dc = new yummyDatabaseDataContext();
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
            RecipesCarousel.ItemsSource = myRecipes;
        }

        private void ShowRecipes()
        {
            dc = new yummyDatabaseDataContext();
            var query = (from Rec in dc.Recipes orderby Rec.Name ascending select Rec);
            recTable = query.ToList();
            loadDataToDisplay(recTable);
        }

        private void SearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            var tab = (from R in dc.Recipes where R.Name.ToUpper().Contains(SearchRecipeInput.Text.ToUpper()) orderby R.Name ascending select R);

            loadDataToDisplay(tab.ToList());
        }

        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesCarousel.SelectedItem != null)
            {
                PrintRecipe printRecipe = new PrintRecipe((RecipesCarousel.SelectedItem as MediaData).Id);
                printRecipe.ShowDialog();
            }
        }

        public BitmapImage ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.ShowDialog();
            refreshRecipies();
        }

        private void EditRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesCarousel.SelectedItem != null)
            {
                AddRecipe addRecipe = new AddRecipe((RecipesCarousel.SelectedItem as MediaData).Id);
                addRecipe.labelNewRecipe.Content = "Edit Recipe";
                addRecipe.Title = "Edit Recipe";
                addRecipe.ShowDialog();
                refreshRecipies();
            }
            else
            {
                MessageBox.Show("Please select a recipe to update.", "Update Recipe");
            }
        }

        private void RemoveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesCarousel.SelectedItem != null)
            {
                int recipeId = (RecipesCarousel.SelectedItem as MediaData).Id;
                string recipeName = (RecipesCarousel.SelectedItem as MediaData).Title;

                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete recipe '{recipeName}' ?", "Delete Recipe", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var recipe = dc.Recipes.Single(r => r.RecipeId == recipeId);
                    dc.RecipeIngredients.DeleteAllOnSubmit(recipe.RecipeIngredients);
                    dc.Recipes.DeleteOnSubmit(recipe);
                    dc.SubmitChanges();
                    refreshRecipies();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.", "Delete Recipe");
            }
        }

        private void refreshRecipies()
        {
            dc = new yummyDatabaseDataContext();
            RecipesCarousel.ItemsSource = null;

            // selecting specific columns to display in the recipe datagrid
            var recTab = (from R in dc.Recipes orderby R.Name ascending select R);
            loadDataToDisplay(recTab.ToList());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Catalog catalogWindow = new Catalog();
            var parent = this.Parent as Window;
            parent.Content = catalogWindow;
        }
    }
}
