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
    }
}
