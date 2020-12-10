using MaterialDesignThemes.Wpf;
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
    /// // Created by Waqas Bashir
    /// </summary>
    public partial class ShoppingList : Window
    {
        yummyDatabaseDataContext ShopingList = new yummyDatabaseDataContext(); // Instanciating main Database
        Recipe recipe;                                                          // referencing the Recipe table
        RecipeIngredient IngredientQuantity = new RecipeIngredient();           // Instantiating from RecipeIngredient table 


        bool updateRequested = false;


       
        public ShoppingList(int? recipeId)
        {
            InitializeComponent(); 

            recipe = ShopingList.Recipes.Where(recipe => recipe.RecipeId == recipeId).Single(); /*  Bringing the selected Recipe into Focus 
                                                                                                    so we could extract the recipe name, servign sizes 
                                                                                                    and Ingredients */

            string recipeIngredients = string.Empty;          // Here we define a string and keeping it empty before this form processes

            recipeNameOnList.Text = recipe.Name.ToString();   // To display the recipe name and serving size into text boxes  
            noOfServings.Text = recipe.Serving.ToString();      

            /* Here we are defining some global variables to do our calculations for ingredients in grams for easy purchase AND to store the 
               current serving size in-case user wants to update it. then a new calculation will be done based in updated value by user. */

            double? currentServingSize =  recipe.Serving;        
            double? CupToGrams = 0.0;
            double? OuncesToGrams = 0.0;
            double? TablespoonToGrams = 0.0;
            double? TeaspoonToGrams = 0.0;

            /* Here we are iterating through each ingredient and depending on its type, Mathematical conversion is being taken place 
                followed printing of list */

            if (updateRequested == false)
            {
                foreach (var recipeIngredient in recipe.RecipeIngredients)
                {

                    switch (recipeIngredient.Measurement)

                    {
                        case "Cup":
                            double quantityInCup = recipeIngredient.Quantity;
                            CupToGrams = 128 * quantityInCup;
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

            } else 
              {
                //string servingsizeUpdate = UpdateServingSize.Text;
                //goto UpdateServing;
                MessageBox.Show("new serving size");
            }

            //UpdateServing:
            /*  In case of new serving size being typed by user, we are iterating through each ingredient and depending on its type, 
                 Mathematical conversion is being taken place followed printing of list  */


            //      string servingsizeUpdate = UpdateServingSize.Text;   //Taking input of new serving size by user

            /* int newServingSize = int.Parse(UpdateServingSize.Text);  // Converting into in Optional Integer

                           foreach (var recipeIngredient in recipe.RecipeIngredients)
                           {

                               switch (recipeIngredient.Measurement)

                               {
                                   case "Cup":
                                       double quantityInCup = recipeIngredient.Quantity;
                                       CupToGrams = 128 * quantityInCup;
                                       CupToGrams = CupToGrams/currentServingSize*newServingSize;
                                       recipeIngredients += $"{CupToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                                       shopinglisttext.Text = recipeIngredients;
                                       noOfServings.Text = newServingSize;
                                       break;
                                   case "Tablespoon":
                                       double quantityInTablespoon = recipeIngredient.Quantity;
                                       TablespoonToGrams = 21.25 * quantityInTablespoon;
                                       TablespoonToGrams = TablespoonToGrams/currentServingSize* newServingSize;
                                       recipeIngredients += $"{TablespoonToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                                       shopinglisttext.Text = recipeIngredients;
                                       noOfServings.Text = newServingSize;
                                         break;
                                   case "Ounces":
                                       double quantityInOunces = recipeIngredient.Quantity;
                                       OuncesToGrams = 28.3495 * quantityInOunces;
                                       OuncesToGrams = OuncesToGrams/currentServingSize*newServingSize;
                                       recipeIngredients += $"{OuncesToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                                       shopinglisttext.Text = recipeIngredients;
                                       noOfServings.Text = newServingSize;
                                       break;
                                   case "Teaspoon":
                                       var quantityInTeaspoon = recipeIngredient.Quantity;
                                       TeaspoonToGrams = 4.2 * quantityInTeaspoon;
                                       TeaspoonToGrams = TeaspoonToGrams/currentServingSize*newServingSize;
                                       recipeIngredients += $"{TeaspoonToGrams} Grams {recipeIngredient.Ingredient.Name} ( or {recipeIngredient.Quantity} {recipeIngredient.Measurement}) \n";
                                       shopinglisttext.Text = recipeIngredients;
                                       noOfServings.Text = newServingSize;
                                       break;

                               }
                            } */
        }





        private void Shopinglisttext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RecipeNameOnList_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void NoOfServings_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog myPrintDialog = new PrintDialog();
            if (myPrintDialog.ShowDialog() == true)
            {
                myPrintDialog.PrintVisual(this, recipe.Name);
            }
        }


        private void UpdateServing(object sender, RoutedEventArgs e)
        {
            yummyDatabaseDataContext ShopingList = new yummyDatabaseDataContext();
            updateRequested = true;
            //ShopingList.ShowDialog();
            


        }


        private void NewServingSize_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void NoOfServings_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void UpdateServingSize_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

       
    }


}
