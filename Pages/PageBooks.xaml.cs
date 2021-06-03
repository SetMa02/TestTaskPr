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
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        DBLibraryEntities context;

        public PageBooks()
        {
            InitializeComponent();
            context = new DBLibraryEntities();
            DGBooks.ItemsSource = context.Books.ToList();
            var books = context.Books.ToList();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Books();
            context.Books.Add(newBook);
            FrameManager.MainFrame.Navigate(new PageBookEdit(context, newBook));
           DGBooks.ItemsSource = context.Books.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var row = (Books)DGBooks.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберете строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этц строку?",
                "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Books.Remove(row);
                context.SaveChanges();
            }
            context = new DBLibraryEntities();
            DGBooks.ItemsSource = context.Books.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = (Button)sender;
            var currentBook = (Books)BtnEdit.DataContext;
            FrameManager.MainFrame.Navigate(new PageBookEdit(context, currentBook));
            DGBooks.ItemsSource = context.Books.ToList();
        }
    }
}
