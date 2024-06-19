using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddAndEditServices.xaml
    /// </summary>
    public partial class AddAndEditServices : Window
    {
        Service service;

        List<Service> allService;

        FolderClass.InterationDataBase InterationDataBase;

        public AddAndEditServices(Service service)
        {
            InitializeComponent();

            this.service = service;

            DataContext = service;

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            allService = InterationDataBase.RcdbEntities.Service.ToList();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            if (service.ID == 0)
            {
                int countExist = allService.Where(item => item.Title.Contains(tbTitleService.Text)).Count();

                double countHours = int.Parse(tbDurationService.Text) / 60;

                if (countExist == 0 && countHours > 0 && countHours <= 4)
                {
                    if (InterationDataBase.AddService(service))
                    {
                        MessageBox.Show("Сохранено");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении");
                }
            }
            else
            {
                InterationDataBase.RcdbEntities.SaveChanges();
            }
        }

        private void ButtonSelectImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string fileName = openFileDialog.FileName;

                service.MainImagePath = fileName;

                imageService.Source = new BitmapImage(new Uri(fileName));

            }
            
        }
    }
}
