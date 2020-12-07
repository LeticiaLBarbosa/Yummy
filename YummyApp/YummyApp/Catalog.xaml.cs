using System;
using System.Collections.Generic;
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
using System.Data;
using System.IO;
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
        List<Category> catTable;

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
