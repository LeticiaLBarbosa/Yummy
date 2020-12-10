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
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Window
    {
        yummyDatabaseDataContext ShopingList = new yummyDatabaseDataContext();
        Recipe recipe;
      // RecipeIngredient IngredientQuantity = new RecipeIngredient();

        public ShoppingList(int? recipeId)
        {
            InitializeComponent();

            recipe = ShopingList.Recipes.Where(recipe => recipe.RecipeId == recipeId).Single();
            string recipeIngredients = string.Empty;
            recipeNameOnList.Text = recipe.Name;
            noOfServings.Text = recipe.Serving.ToString();


            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
  
                var CupToGrams = 0.0;
                var OuncesToGrams = 0.0;
                var TablespoonToGrams = 0.0;
                var TeaspoonToGrams = 0.0;
                
            switch (recipeIngredient.Measurement)
                  
                    {
                    case "Cup":
                        double quantityInCup = recipeIngredient.Quantity;
                        CupToGrams = 240 * quantityInCup;
                        recipeIngredients += $"{CupToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                        shopinglisttext.Text = recipeIngredients;
                        break;
                    case "Tablespoon":
                        double quantityInTablespoon = recipeIngredient.Quantity;
                        TablespoonToGrams = 21.25 * quantityInTablespoon;
                        recipeIngredients += $"{TablespoonToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                        shopinglisttext.Text = recipeIngredients;
                        break;
                    case "Ounces":
                        double quantityInOunces = recipeIngredient.Quantity;
                        OuncesToGrams = 28.3495 * quantityInOunces;
                        recipeIngredients += $"{OuncesToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                        shopinglisttext.Text = recipeIngredients;
                        break;
                    case "Teaspoon":
                        var quantityInTeaspoon = recipeIngredient.Quantity;
                        TeaspoonToGrams = 4.2 * quantityInTeaspoon;
                        recipeIngredients += $"{TeaspoonToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                        shopinglisttext.Text = recipeIngredients;
                        break;
                 
               }
            }









        }
       

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

      
        private void Shopinglisttext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
