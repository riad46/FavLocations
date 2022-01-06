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

namespace FavLocations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool returnToInitialStat_pathBox = true;//use it to know wether to clear the PATH_box or not depending on the text in it
        private bool returnToInitialStat_nameBox =true;//use it to know wether to clear the NAME_box or not depending on the text in it
        public MainWindow()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            
        }
        private void pathBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (returnToInitialStat_pathBox)
            {
                pathBox.Text = "";
                returnToInitialStat_pathBox = false;
            } 
        }
        private void pathBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pathBox.Text.Length == 0)
            {
                pathBox.Text = "Insert your path here";
                returnToInitialStat_pathBox = true;
            }            
        }

        private void nameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (returnToInitialStat_nameBox)
            {
                nameBox.Text = "";
                returnToInitialStat_nameBox = false;
            }
        }

        private void nameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Length == 0)
            {
                nameBox.Text = "Name this Location";
                returnToInitialStat_nameBox = true;
            }
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void darkmode_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Black;
            Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }
}
