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
    /// Логика взаимодействия для AddAndEditClient.xaml
    /// </summary>
    public partial class AddAndEditClient : Window
    {
        private Client client;

        FolderClass.InterationDataBase InterationDataBase;

        public AddAndEditClient(Client client)
        {
            InitializeComponent();

            this.client = client;

            DataContext = client;

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            cbGender.ItemsSource = InterationDataBase.RcdbEntities.Gender.ToList();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            if (client.ID == 0)
            {
                if (InterationDataBase.AddClient(client))
                {
                    MessageBox.Show("Успешное сохранение");
                }
            }
            else
            {
                InterationDataBase.RcdbEntities.SaveChanges();
            }
        }
    }
}
