﻿using Microsoft.Win32;
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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        yummyDatabaseDataContext dc = new yummyDatabaseDataContext();
        BitmapImage bitmapImage;
        Recipe recipe;

        public AddRecipe(int? recipeId = null)
        {
            InitializeComponent();

            if (recipeId == null)
            {
                recipe = new Recipe();
                loadCategories();
            }
            else
            {
                recipe = dc.Recipes.Where(recipe => recipe.RecipeId == recipeId).Single();
                loadCategories(recipe.Category);

                if (recipe.Image != null)
                {
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(recipe.Image.ToArray());
                    bitmapImage.EndInit();
                    imgRecipePhoto.Source = bitmapImage;
                }
               
                txtRecipeName.Text = recipe.Name;
                txtRecipePrepTime.Text = recipe.PrepTime.ToString();
                txtRecipeServings.Text = recipe.Serving.ToString();
                txtRecipeDirections.Text = recipe.Directions;
            }

            dgRecipeIngredients.ItemsSource = recipe.RecipeIngredients.Select(ingredient => new { ingredient.Quantity, ingredient.Measurement, Ingredient = ingredient.Ingredient.Name });
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a recipe photo";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
            if ((bool)openFileDialog.ShowDialog())
            {
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = System.IO.File.OpenRead(openFileDialog.FileName);
                bitmapImage.EndInit();
                imgRecipePhoto.Source = bitmapImage;
            }
        }

        private void btnDeleteImage_Click(object sender, RoutedEventArgs e)
        {
            imgRecipePhoto.Source = null;
            bitmapImage = null;
        }

        private bool addRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            recipe.Name = txtRecipeName.Text;

            if (!string.IsNullOrEmpty(txtRecipeServings.Text))
                recipe.Serving = Convert.ToInt32(txtRecipeServings.Text);

            if (!string.IsNullOrEmpty(txtRecipePrepTime.Text))
                recipe.PrepTime = Convert.ToInt32(txtRecipePrepTime.Text);

            recipe.Directions = txtRecipeDirections.Text;
            recipe.Category = (int)cbRecipeCategory.SelectedValue;

            if (bitmapImage != null)
            {
                byte[] imageData = new byte[bitmapImage.StreamSource.Length];
                // now, you have get the image bytes array, and you can store it to SQl Server
                bitmapImage.StreamSource.Seek(0, SeekOrigin.Begin);
                //very important, it should be set to the start of the stream
                bitmapImage.StreamSource.Read(imageData, 0, imageData.Length);
                recipe.Image = imageData;
            } else
            {
                recipe.Image = null;
            }

            if (recipe.RecipeId == 0)
                dc.Recipes.InsertOnSubmit(recipe);
            
            dc.SubmitChanges();
            Close();
        }

        private void loadCategories(int selectedValue = 0)
        {
            List<Category> Categories = dc.Categories.ToList();
            Categories.Insert(0, new Category { CategoryId = 0, CategoryName = "Select a Category" });
            cbRecipeCategory.ItemsSource = Categories;
            cbRecipeCategory.DisplayMemberPath = "CategoryName";
            cbRecipeCategory.SelectedValuePath = "CategoryId";
            cbRecipeCategory.SelectedValue = selectedValue;
        }

        private void btnAddRecipeIngredient_Click(object sender, RoutedEventArgs e)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Ingredient = new Ingredient() { Name = txtRecipeIngredientIngredient.Text };
            recipeIngredient.Recipe = recipe;
            recipeIngredient.Quantity = Convert.ToDouble(txtRecipeIngredientQuantity.Text);
            recipeIngredient.Measurement = cbRecipeIngredientMeasurement.Text;
            recipe.RecipeIngredients.Add(recipeIngredient);
        }
    }
}
