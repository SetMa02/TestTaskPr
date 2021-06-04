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

namespace TestTaskPr.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCat.xaml
    /// </summary>
    public partial class WindowCat : Window
    {
        DBLibraryEntities context;
        public WindowCat()
        {
            InitializeComponent();
            context = new DBLibraryEntities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var newCat = new Categoryes();
            newCat.nameCat = txtGenre.Text;
            context.Categoryes.Add(newCat);
            context.SaveChanges();
            this.Close();
        }
    }
}
