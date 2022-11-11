using System.Windows;
using SOTR_Fixer.Classes;

namespace SOTR_Fixer
{
    /// <summary>
    /// Interaction logic for NewSpeaker_Window.xaml
    /// </summary>
    public partial class NewSpeaker_Window : Window
        
    {
        public NewSpeaker_Window()
        {
            InitializeComponent();            
            this.Owner = App.Current.MainWindow;
            
            

    }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Items.Add(new Speakers() { Shortcut = "m", FirstName = "Martin", LastName = "Splitt" });
        }






        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
