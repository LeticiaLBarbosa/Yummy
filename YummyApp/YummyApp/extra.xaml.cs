﻿using System;
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

    //Carolina Naoum Junqueira
    public partial class extra : Window
    {
        yummyDatabaseDataContext dc = new yummyDatabaseDataContext();

        public extra()
        {
            InitializeComponent();

            // subscribing to the auto generated columns event from the recipe datagrid
            //this is used to hide the column id and setting column 4 width to use all the extra space in the row
            dgRecipes.AutoGeneratedColumns += DgRecipes_AutoGeneratedColumns;
            refreshRecipies();
        }

        /// <summary>
        /// delegate called by the auto generated columns event, hides the recipeId collum from the recipe datagrid and sets column 4 width
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgRecipes_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgRecipes.Columns[0].Visibility = Visibility.Hidden;
            dgRecipes.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// btnAddRecipe click handler, calls the addRecipe form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.ShowDialog();
            refreshRecipies();
        }

        /// <summary>
        /// btnUpdateRecipe click handler, calls the addRecipe form and passes the selected recipe ID to be updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecipes.SelectedItem != null)
            {
                AddRecipe addRecipe = new AddRecipe((dgRecipes.SelectedItem as dynamic).RecipeId);
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

        /// <summary>
        /// btnDeleteRecipe click handler, deletes the selected recipe from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecipes.SelectedItem != null)
            {
                int recipeId = (dgRecipes.SelectedItem as dynamic).RecipeId;
                string recipeName = (dgRecipes.SelectedItem as dynamic).Name;

                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete recipe '{recipeName}' ?", "Delete Recipe", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var recipe = dc.Recipes.Single(r => r.RecipeId == recipeId);
                    dc.RecipeIngredients.DeleteAllOnSubmit(recipe.RecipeIngredients);
                    dc.Recipes.DeleteOnSubmit(recipe);
                    dc.SubmitChanges();
                    refreshRecipies();
                } 
            } else
            {
                MessageBox.Show("Please select a recipe to delete.", "Delete Recipe");
            }
        }

        /// <summary>
        /// method to update the recipe datagrid to reflect database changes
        /// </summary>
        private void refreshRecipies()
        {
            dc = new yummyDatabaseDataContext();
            dgRecipes.ItemsSource = null;

            // selecting specific columns to display in the recipe datagrid
            dgRecipes.ItemsSource = dc.Recipes.Select(recipe => new { recipe.RecipeId, recipe.Name, recipe.PrepTime, recipe.Serving, Category = recipe.Category1.CategoryName });
        }

        private void dgRecipes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }

        //This method calls a new window that displays the selected recipe
        private void btnPrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecipes.SelectedItem != null)
            {
                PrintRecipe printRecipe = new PrintRecipe((dgRecipes.SelectedItem as dynamic).RecipeId);
                string recipeName = (dgRecipes.SelectedItem as dynamic).Name;
                printRecipe.Title = recipeName;
                printRecipe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to print.", "Print Recipe");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecipes.SelectedItem != null)
            {
                ShoppingList SL = new ShoppingList((dgRecipes.SelectedItem as dynamic).RecipeId);
                SL.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to get the shoping List.");
            }
        }

        private void DgRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
