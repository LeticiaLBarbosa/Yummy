﻿using System;
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
using System.Windows.Controls;

namespace YummyApp
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        yummyDatabaseDataContext dc;
        List<MediaData> myCategories;
        List<Category> catTable;

        Category category;

        public Catalog()
        { 
            InitializeComponent();
            dc = new yummyDatabaseDataContext();
            myCategories = new List<MediaData>();
            catTable = dc.Categories.ToList();
            ShowCategories();
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
                cnt.Title = categoryObj.CategoryName;
                myCategories.Add(cnt);
            }

            CategoriesCarousel.ItemsSource = myCategories;
        }

        private void SearchCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListView listView = sender as ListView;

                if (listView.SelectedItem != null)
                {
                    string categoryName = (listView.SelectedItem as dynamic).Title;
                    category = dc.Categories.Where(category => category.CategoryName == categoryName).Single();
                    CategoryForm cf = new CategoryForm(category);
                    cf.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " error");
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
