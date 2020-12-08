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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace YummyApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToMyCatalogPage(object sender, RoutedEventArgs e)
        {
            Catalog catalogWindow = new Catalog();
            catalogWindow.Show();
        }

        private void GoToMyCategoryPage(object sender, RoutedEventArgs e)
        {
            CategoryPage categoryPage = new CategoryPage();
            categoryPage.Show();
        }
        private void GoToMyRecipePage(object sender, RoutedEventArgs e)
        {
            extra recipePage = new extra();
            recipePage.Show();
        }
    }
}
