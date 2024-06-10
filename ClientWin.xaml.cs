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

namespace RecordClasses
{
    /// <summary>
    /// Логика взаимодействия для ClientWin.xaml
    /// </summary>
    public partial class ClientWin : Window
    {
        FolderClass.InterationDataBase InterationDataBase;

        public ClientWin()
        {
            InitializeComponent();

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            dgClient.ItemsSource = InterationDataBase.RcdbEntities.Client.ToList();

        }

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;

            var itemSelected = item.DataContext as Client;

            new AddAndEditClient(itemSelected).ShowDialog();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Client client = new Client();

            new AddAndEditClient(client).ShowDialog();
        }
    }
}
