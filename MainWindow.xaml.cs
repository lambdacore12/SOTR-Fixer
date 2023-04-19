using System.IO;
using System.Linq;
using System.Windows;
using SOTR_Fixer.Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Win32;

using System;
using System.Windows.Input;

namespace SOTR_Fixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables that will be used throughout the code
        public static string fileName = "";
        //string filePath = "";
        public static string filePath = "";

        public static ObservableCollection<Speakers> items = new ObservableCollection<Speakers>();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            items.Add(new Speakers() { Shortcut = "j", FirstName = "John", LastName = "Mueller" });
            items.Add(new Speakers() { Shortcut = "l", FirstName = "Lizzi", LastName = "Sassman" });
            items.Add(new Speakers() { Shortcut = "m", FirstName = "Martin", LastName = "Splitt" });
            Speakers_Lv.ItemsSource = items;
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

        #region Transform button
        private void Transform_Btn_Click(object sender, RoutedEventArgs e)
        {
            //main activity happens here (check transformer class)
            string finalText = Transformer.Transform(filePath);

            //get just the pure name of the file
            string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension(filePath);

            //prepare new file to write into (same path as original but of course different name)
            string finalPath = System.IO.Path.GetDirectoryName(filePath) + "\\" + fileNameOnly + "_SOTRfixed.srt";
            
            using (StreamWriter writer = new StreamWriter(finalPath))
            {
                writer.Write(finalText);
            }

            //write the file name in the final textbox (filename_SOTRfixed.srt)
            Final_TBox.Text = System.IO.Path.GetFileName(finalPath);

        }
        #endregion

        #region Open final file
        private void Open_Final_Btn_Click(object sender, RoutedEventArgs e)
        {
            string directory = System.IO.Path.GetDirectoryName(filePath);

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = directory; // set the initial directory
            dialog.FileName = Final_TBox.Text; // set the initial file name
            dialog.Filter = "SubRip file (.srt)|*.srt"; // Filter files by extension
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            bool? result = dialog.ShowDialog(); // show the dialog

            
            if (result == true)
            {
                string filePath = dialog.FileName;
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        } 
        #endregion

        #region Exit button
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        #endregion

        #region Add button
        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            NewSpeaker_Window NewSpeaker = new NewSpeaker_Window();

            if (NewSpeaker.ShowDialog() == true)
            {
                items.Add(new Speakers()
                {
                    Shortcut = NewSpeaker.shortcut,
                    FirstName = NewSpeaker.firstName,
                    LastName = NewSpeaker.lastName
                });
                
            }

        }
        #endregion

        #region Remove button
        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = Speakers_Lv.SelectedItems;
            foreach (var selectedItem in selectedItems.Cast<Speakers>().ToList())
            {
                items.Remove(selectedItem);
            }
        }
        #endregion

        #region Remove with Delete
        private void Speakers_Lv_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var selectedItems = Speakers_Lv.SelectedItems;
                foreach (var selectedItem in selectedItems.Cast<Speakers>().ToList())
                {
                    items.Remove(selectedItem);
                }
            }
        } 
        #endregion
    }
}
