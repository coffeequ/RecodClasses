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
using System.Timers;
using System.Windows.Threading;

namespace RecordClasses
{
    /// <summary>
    /// Логика взаимодействия для ComingPostsWin.xaml
    /// </summary>
    public partial class ComingPostsWin : Window
    {
        FolderClass.InterationDataBase InterationDataBase;

        DispatcherTimer timer;

        public ComingPostsWin()
        {
            InitializeComponent();

            InterationDataBase = new FolderClass.InterationDataBase(MainWindow.RcdbEntities);

            dgClientService.ItemsSource = InterationDataBase.RcdbEntities.ClientService.ToList();

            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(30);

            timer.Start();

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Таймер сработан");

            dgClientService.ItemsSource = null;

            dgClientService.ItemsSource = InterationDataBase.RcdbEntities.ClientService.ToList();
        }
    }
}
