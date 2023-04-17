using System.Collections.Generic;
using System.Windows;
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
    }
}
