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
    /// Логика взаимодействия для PageJun.xaml
    /// </summary>
    public partial class PageJun : Page
    {
        DBLibraryEntities context;

        public PageJun()
        {
            InitializeComponent();
            context = new DBLibraryEntities();
            DGJun.ItemsSource = context.Books.ToList();
        }
    }
}
