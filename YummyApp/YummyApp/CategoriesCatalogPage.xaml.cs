﻿//
//
//

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
    public partial class CategoriesCatalogPage : Page
    {
        yummyDatabaseDataContext dc;
        List<MediaData> myCategories;
        List<Category> catTable;

        public CategoriesCatalogPage()
        {
            InitializeComponent();
            dc = new yummyDatabaseDataContext();
            ShowCategories();
        }
        private void loadDataToDisplay(List<Category> tab)
        {
            myCategories = new List<MediaData>();
            foreach (var categoryObj in tab)
            {
                MediaData cnt = new MediaData();
                if (categoryObj.CategoryImage != null)
                {
                    cnt.ImageData = cnt.ByteArrayToImage(categoryObj.CategoryImage.ToArray());
                }
                cnt.Id = categoryObj.CategoryId;
                cnt.Title = categoryObj.CategoryName;
                myCategories.Add(cnt);
            }
        }

        private void ShowCategories()
        {
            var query = (from Cat in dc.Categories orderby Cat.CategoryName ascending select Cat);
            catTable = query.ToList();
            loadDataToDisplay(catTable);
            CategoriesCarousel.ItemsSource = myCategories;
        }

        private void SearchCategory_Click(object sender, RoutedEventArgs e)
        {
            var tab = (from C in dc.Categories where C.CategoryName.ToUpper().Contains(SearchCategoryInput.Text.ToUpper()) orderby C.CategoryName ascending select C);

            loadDataToDisplay(tab.ToList());

            CategoriesCarousel.ItemsSource = myCategories;
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

        private void AddNewCategoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMenuClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Visible;
            ButtonMenuClose.Visibility = Visibility.Collapsed;
        }

        private void ButtonMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Collapsed;
            ButtonMenuClose.Visibility = Visibility.Visible;
        }

        private void CatalogButton_Selected(object sender, RoutedEventArgs e)
        {
            Catalog catalogPage = new Catalog(); // creates an instance of the Catalog page
            var parent = this.Parent as Window;
            parent.Content = catalogPage; // show the Catalog page
        }

        private void AllRecipesButton_Selected(object sender, RoutedEventArgs e)
        {
            extra extraPage = new extra(); // creates an instance of the All Recipes page
            var parent = this.Parent as Window;
            parent.Content = extraPage; // show the All Recipes page
        }

        private void DashboardButton_Selected(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(); // creates an instance of the dashboard page
            dashboard.InitializeComponent();
            var parent = this.Parent as Window;
            parent.Content = dashboard.Content; // show the dashboard page
        }

        private void AllCategoriesButton_Selected(object sender, RoutedEventArgs e)
        {
            CategoriesCatalogPage categoriesCatalogPage = new CategoriesCatalogPage(); // creates an instance of the All Categories page
            var parent = this.Parent as Window;
            parent.Content = categoriesCatalogPage; // show the All Categories page
        }
    }
}
