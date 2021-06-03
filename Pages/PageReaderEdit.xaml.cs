﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для PageReaderEdit.xaml
    /// </summary>
    public partial class PageReaderEdit : Page
    {
        DBLibraryEntities context;
        public PageReaderEdit(DBLibraryEntities context, Reader newReader)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = newReader;


            dateOfReg.SelectedDate = DateTime.Today;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                FrameManager.MainFrame.Navigate(new PageReaders());
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show("Error");
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(MessageBox.Show(" The validation errors are: " + fullErrorMessage));
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
        }
    }
}
