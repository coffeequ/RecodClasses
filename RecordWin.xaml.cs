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
    /// Логика взаимодействия для RecordWin.xaml
    /// </summary>
    public partial class RecordWin : Window
    {
        FolderClass.InterationDataBase InterationDataBase;

        List<Service> sortService;

        int currentPage = 1;

        int countPage = 6;

        int maxPage = 0;

        public RecordWin()
        {
            InitializeComponent();

            sortService = new List<Service>();

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            lvRecordClasses.ItemsSource = InterationDataBase.RcdbEntities.Service.ToList();

        }

        private void Refresh()
        {
            var services = sortService;

            var servicesPage = sortService.Skip((currentPage - 1) * countPage).Take(countPage).ToList();

            maxPage = CountMaxRecord(services.Count());

            labelStats.Content = $"Страница {currentPage} из {maxPage}";

            lvRecordClasses.ItemsSource = servicesPage;
        }

        private int CountMaxRecord(int AllCount) => (int)Math.Ceiling(AllCount * 1.0 / 6);

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }
    }
}
