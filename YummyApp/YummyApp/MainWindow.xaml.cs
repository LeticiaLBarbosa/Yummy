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
        private Catalog catalogWindow;
        public MainWindow()
        {
            InitializeComponent();
            yummyDatabaseDataContext dc = new yummyDatabaseDataContext();
            Table<UserRecipe> tab = dc.UserRecipes;
            ExampleGrid.ItemsSource = tab;
            catalogWindow = new Catalog();
        }

        private void GoToMyCatalogPage(object sender, RoutedEventArgs e)
        {
            catalogWindow.Show();
        }
    }
}
