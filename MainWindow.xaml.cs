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

namespace RecordClasses
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RcdbEntities RcdbEntities;

        public MainWindow()
        {
            InitializeComponent();

            RcdbEntities = new RcdbEntities();
        }

        private void ButtonWatchClasses(object sender, RoutedEventArgs e)
        {
            new RecordWin().ShowDialog();
        }

        private void ButtonClient(object sender, RoutedEventArgs e)
        {
            new ClientWin().ShowDialog();
        }

        private void ButtonRegistrationClientForAService(object sender, RoutedEventArgs e)
        {
            new ClientServiceWin().ShowDialog();
        }

        private void ButtonComingPosts(object sender, RoutedEventArgs e)
        {
            new ComingPostsWin().ShowDialog();
        }
    }
}
