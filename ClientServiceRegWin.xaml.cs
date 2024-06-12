using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для ClientServiceRegWin.xaml
    /// </summary>
    public partial class ClientServiceRegWin : Window
    {
        FolderClass.InterationDataBase InterationDataBase;

        List<Client> allClient;

        Service service;

        public ClientServiceRegWin(Service service)
        {
            InitializeComponent();

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            this.service = service;

            allClient = InterationDataBase.RcdbEntities.Client.ToList();

            keyValuePairs = InterationDataBase.RcdbEntities.Client.ToDictionary(item => item.ID, item2 => item2.FirstName + item2.LastName + item2.Patronymic);

            cbClients.ItemsSource = keyValuePairs;

            DataContext = service;
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            ClientService clientService = new ClientService();

            clientService.Service = service;

            clientService.Client = allClient[cbClients.SelectedIndex];

            clientService.StartTime = (DateTime)dpStartTime.SelectedDate;

            if (InterationDataBase.AddClientService(clientService))
            {
                MessageBox.Show("Запись сохранена");
            }
            else
            {
                MessageBox.Show("Запись не сохранена");
            }
        }

        private void dpStartTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpEndTime.Text = dpStartTime.SelectedDate.Value.AddMinutes(service.DurationInSeconds).ToString();
        }
    }
}
