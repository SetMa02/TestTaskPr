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
using TestTaskPr.Windows;

namespace TestTaskPr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTags.xaml
    /// </summary>
    public partial class PageTags : Page
    {
        DBLibraryEntities context;
        public PageTags()
        {
            InitializeComponent();
            context = new DBLibraryEntities();
            DGCat.ItemsSource = context.Categoryes.ToList();
            DGTags.ItemsSource = context.Tags.ToList();
           
        }

        private void btnAddGenre_Click(object sender, RoutedEventArgs e)
        {
            WindowCat windowCat = new WindowCat();
            windowCat.Show();
        }

        private void btnDelGenre_Click(object sender, RoutedEventArgs e)
        {
            var row = (Categoryes)DGCat.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Categoryes.Remove(row);
                    context.SaveChanges();
                    DGCat.ItemsSource = context.Categoryes.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            WindowTag windowTag = new WindowTag();
            windowTag.Show();
        }

        private void btnDelPublisher_Click(object sender, RoutedEventArgs e)
        {
            var row = (Tags)DGTags.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку на удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Delete question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Tags.Remove(row);
                    context.SaveChanges();
                    DGTags.ItemsSource = context.Tags.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DGCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGCat.ItemsSource = context.Categoryes.ToList();
            context.SaveChanges();
        }

        private void DGTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGTags.ItemsSource = context.Tags.ToList();
            context.SaveChanges();
        }

        private void DGCat_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
