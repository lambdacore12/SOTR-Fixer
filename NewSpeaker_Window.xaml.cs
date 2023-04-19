using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using SOTR_Fixer.Classes;

namespace SOTR_Fixer
{
    /// <summary>
    /// Interaction logic for NewSpeaker_Window.xaml
    /// </summary>
    public partial class NewSpeaker_Window : Window
        
    {
        public string shortcut { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


        public NewSpeaker_Window()
        {
            InitializeComponent();
            Shortcut_TB.Focus();
        }    

        private void NewSpeaker_Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewSpeaker_Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            shortcut = Shortcut_TB.Text;
            firstName = FirstName_TB.Text;
            lastName = LastName_TB.Text;

            DialogResult = true;
        }

        #region using 't' not allowed in shortcuts
        private void Shortcut_TB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "t")
            {
                e.Handled = true; // prevent the "t" from being entered
                //ToolTip.Visibility = Visibility.Visible; // show the ToolTip
                MessageBox.Show("You cannot use 't' here as it is reserved for the time indicator.", "Shortcut Rule", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (Shortcut_TB.Text.Length >= 1)
            {
                e.Handled = true;
                MessageBox.Show("You may not use more than one letter as a shortcut.", "Shortcut Rule", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region using 'space' not allowed in shortcuts
        private void Shortcut_TB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("You cannot use 'space' here. Only letters are permitted.", "Shortcut Rule", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        } 
        #endregion


    }
}
