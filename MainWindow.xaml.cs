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
using System.Windows.Threading;
using TestTaskPr.Pages;

namespace TestTaskPr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        int panelWidth;
        bool hidden;
        public MainWindow()
        {
            InitializeComponent();
           FrameManager.MainFrame = MainFrame;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1);
            timer.Tick += Timer_Tick;
            panelWidth = (int)sidePanel.Width;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {

                sidePanel.Width += 1;
                FrameWidth.Width -= 1;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
                txtBook.Visibility = Visibility.Visible;
               
                txtReader.Visibility = Visibility.Visible;
                txtTag1.Visibility = Visibility.Visible;
                txtJun.Visibility = Visibility.Visible;
            }
            else
            {
                txtBook.Visibility = Visibility.Collapsed;
                txtJun.Visibility = Visibility.Collapsed;
                txtReader.Visibility = Visibility.Collapsed;
                txtTag1.Visibility = Visibility.Collapsed;
                sidePanel.Width -= 1;
                FrameWidth.Width += 1;
                if (sidePanel.Width <= 45)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new PageBooks());
            if (hidden == false)
                timer.Start();
        }

        private void lwReaders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new PageReaders());
            if(hidden == false)
                timer.Start();
        }

        private void ListViewItem_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new PageTags());
            if (hidden == false)
                timer.Start();
        }

        private void ListViewItem_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new PageJun());
            if (hidden == false)
                timer.Start();
        }
    }
}
