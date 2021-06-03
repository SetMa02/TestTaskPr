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

namespace TestTaskPr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReaders.xaml
    /// </summary>
    public partial class PageReaders : Page
    {
        DBLibraryEntities context;
        public PageReaders()
        {
            InitializeComponent();
            context = new DBLibraryEntities();
            DGReader.ItemsSource = context.Reader.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newReader = new Reader();
            context.Reader.Add(newReader);
            FrameManager.MainFrame.Navigate(new PageReaderEdit(context, newReader));
            DGReader.ItemsSource = context.Books.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var row = (Reader)DGReader.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберете строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этц строку?",
                "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Reader.Remove(row);
                context.SaveChanges();
            }
            context = new DBLibraryEntities();
            DGReader.ItemsSource = context.Reader.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = (Button)sender;
            var currentReader = (Reader)BtnEdit.DataContext;
            FrameManager.MainFrame.Navigate(new PageReaderEdit(context, currentReader));
            DGReader.ItemsSource = context.Reader.ToList();
        }
    }
}
