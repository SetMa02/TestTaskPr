﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTaskPr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBookEdit.xaml
    /// </summary>
    public partial class PageBookEdit : Page
    {
        DBLibraryEntities context;
        public PageBookEdit(DBLibraryEntities context, Books newbook)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = newbook;

            cmbCat.ItemsSource = context.Categoryes.ToList();
            cmbShielf.ItemsSource = context.Shielfs.ToList();
            cmbTag.ItemsSource = context.Tags.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                FrameManager.MainFrame.Navigate(new PageBooks());
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
            imagePhoto.Source = null;
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png| *.jpg; *.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);
                var addBook = (Books)this.DataContext;
                addBook.photo = image;
                imagePhoto.Source = new BitmapImage(new Uri(nameFile));
            }
        }
    }
}
