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

        List<Service> allService;

        List<Service> temps;

        int currentPage = 1;

        int countPage = 6;

        int maxPage = 0;

        public RecordWin()
        {
            InitializeComponent();

            sortService = new List<Service>();

            temps = new List<Service>();

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            lvRecordClasses.ItemsSource = InterationDataBase.RcdbEntities.Service.ToList();

            allService = InterationDataBase.RcdbEntities.Service.ToList();

            cbSortBy.Items.Add("По возрастанию");

            cbSortBy.Items.Add("По убыванию");

            cbDiscount.Items.Add("Все");

            cbDiscount.Items.Add("0 - 5%");

            cbDiscount.Items.Add("5% - 15%");
            
            cbDiscount.Items.Add("15% - 30%");
            
            cbDiscount.Items.Add("30% - 70%");

            cbDiscount.Items.Add("70% - 100%");

            cbSortBy.SelectedItem = cbSortBy.Items[0];

            cbDiscount.SelectedItem = cbDiscount.Items[0];

            sortService = allService.Where(item => item.Title.Contains(tbSearch.Text)).ToList();

            Apply();

            Refresh();
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

        private void ButtonFirstPage(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            Refresh();
        }

        private void ButtonLastPage(object sender, RoutedEventArgs e)
        {
            currentPage = maxPage;
            Refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Apply();
            Refresh();
        }

        private void cbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Apply();
            Refresh();
        }

        private void Apply()
        {
            string SelectedItem = cbSortBy.SelectedItem as string;

            string SelectedItem2 = cbDiscount.SelectedItem as string;

            if (SelectedItem == "По возрастанию")
            {
                temps = allService.OrderBy(item => item.ResultPrice).Where(item => item.Title.Contains(tbSearch.Text)).ToList();   
            }

            if (SelectedItem == "По убыванию")
            {
                temps = allService.OrderByDescending(item => item.ResultPrice).Where(item => item.Title.Contains(tbSearch.Text)).ToList();
            }

            if (SelectedItem2 == "Все")
            {
                sortService = temps;
            }
            if (SelectedItem2 == "0 - 5%")
            {
                sortService = temps.Where(item => item.Discount >= 0 & item.Discount <= 0.05 - 0.01).ToList();
            }
            if (SelectedItem2 == "5% - 15%")
            {
                sortService = temps.Where(item => item.Discount >= 0.05 & item.Discount <= 0.15 - 0.01).ToList();
            }
            if (SelectedItem2 == "15% - 30%")
            {
                sortService = temps.Where(item => item.Discount >= 0.15 & item.Discount <= 0.3 - 0.01).ToList();
            }
            if (SelectedItem2 == "30% - 70%")
            {
                sortService = temps.Where(item => item.Discount >= 0.3 & item.Discount <= 0.7 - 0.01).ToList();
            }
            if (SelectedItem2 == "70% - 100%")
            {
                sortService = temps.Where(item => item.Discount >= 0.7 & item.Discount <= 1).ToList();
            }
        }

        private void cbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Apply();
            Refresh();
        }

        private void ButtonBackPage(object sender, RoutedEventArgs e)
        {
            if (currentPage <= 1) currentPage = 1;
            else
            {
                currentPage--;
            }
            Refresh();
        }

        private void ButtonNextPage(object sender, RoutedEventArgs e)
        {
            if (currentPage >= maxPage) currentPage = maxPage;
            else
            {
                currentPage++;
            }
            Refresh();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Service service = new Service();

            new AddAndEditServices(service).ShowDialog();

            UpdateLV();
        }

        private void UpdateLV()
        {
            lvRecordClasses.ItemsSource = null;
            lvRecordClasses.ItemsSource = allService.ToList();
        }
    }
}
