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
    /// Interaction logic for PrintRecipe.xaml
    /// </summary>
    public partial class PrintRecipe : Window
    {
        yummyDatabaseDataContext dc = new yummyDatabaseDataContext();
        Recipe recipe;
        BitmapImage bitmapImage;
        public PrintRecipe(int? recipeId = null)
        {
            InitializeComponent();
            recipe = dc.Recipes.Where(recipe => recipe.RecipeId == recipeId).Single();

            if (recipe.Image != null)
            {
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(recipe.Image.ToArray());
                bitmapImage.EndInit();
                imgRecipePhoto.Source = bitmapImage;
            }
            labelRecipeName.Content = recipe.Name;
            txtRecipeDescription.Text = recipe.Description;
            txtRecipePrepTime.Text = recipe.PrepTime.ToString();
            txtRecipeServings.Text = recipe.Serving.ToString();
            txtRecipeDirections.Text = recipe.Directions;

            string recipeIngredients = string.Empty; 
            foreach (var recipeIngredient in recipe.RecipeIngredients)
                recipeIngredients += $"{recipeIngredient.Quantity} {recipeIngredient.Measurement} {recipeIngredient.Ingredient.Name}\n";

            txtRecipeIngrediensList.Text = recipeIngredients;
        }

        private void TxtRecipeIngrediensList_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
