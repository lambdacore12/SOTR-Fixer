﻿using System;
using System.IO;
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

namespace SOTR_Fixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables that will be used throughout the code
        string fileName = "";
        string filePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Open original file
        private void Open_Original_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = ""; // Default file name
            dialog.DefaultExt = ".srt"; // Default file extension
            dialog.Filter = "SubRip file (.srt)|*.srt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                //Get file name with path (don't be fooled by the method's name)
                filePath = dialog.FileName;
                //Get just file name plus extension
                fileName = System.IO.Path.GetFileName(filePath);
                //Display file name in Original text box
                Original_TBox.Text = fileName;
            }
        }

        #endregion

        private void Transform_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
