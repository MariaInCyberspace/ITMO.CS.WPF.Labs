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

namespace BackgroundWorkerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.ComponentModel.BackgroundWorker aWorker = new System.ComponentModel.BackgroundWorker();
        private delegate void UpdateDelegate(int i);
        public MainWindow()
        {
            InitializeComponent();
            aWorker.WorkerSupportsCancellation = true;
            aWorker.DoWork += AWorker_DoWork;
            aWorker.RunWorkerCompleted += AWorker_RunWorkerCompleted;
        }

        private void AWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i <= 50; i++)
            {
                for (int j = 1; j <= 10000000; j++)
                {
                    if (aWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
               
                UpdateDelegate update = new UpdateDelegate(UpdateLabel);
                label1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, update, i);
                
            }
        }

        private void AWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled))
            {
                label2.Content = "Run Completed.";
            }
            else
            {
                label2.Content = "Run Cancelled.";
            }
        }

        private void UpdateLabel(int i)
        {
            label1.Content = "Cycles: " + i.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            aWorker.RunWorkerAsync();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }
    }
}
