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
        //used after changing the window's size
        private void CalculatePosition()
        {
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
        }
        private void SaveSettings(float hiddenWidth,float hiddenHeigth ,float shownWidth,float shownHeigth)
        {
            Properties.Settings.Default.isWindowHidden = (bool)hideApp_CheckBox.IsChecked;
            Properties.Settings.Default.isWindowInDarkMode = (bool)darkmode_CheckBox.IsChecked;

            Properties.Settings.Default.hiddenWindowWidth=hiddenWidth;
            Properties.Settings.Default.hiddenWindowHeight=hiddenHeigth;
            Properties.Settings.Default.shownWindowWidth=shownWidth;
            Properties.Settings.Default.shownWindowHeight = shownHeigth;
            Properties.Settings.Default.Save();

        }
        private void RetreiveSavedSize()
        {
            hiddenWindowWidth.Text = Properties.Settings.Default.hiddenWindowWidth.ToString();
            hiddenWindowHeight.Text = Properties.Settings.Default.hiddenWindowHeight.ToString();
            shownWindowWidth.Text = Properties.Settings.Default.shownWindowWidth.ToString();
            shownWindowHeight.Text = Properties.Settings.Default.shownWindowHeight.ToString();
        }

        //--------------------------------------------work on this Feature---------------------------
        private void TurnToDarkMode()
        {
                this.Background = Brushes.Black;
                Foreground = Brushes.White;        
        }
        private void TurnToLightMode()
        {

        }
        //--------------------------------------------------------------------------------------------
        private void ApplySettingsOnStartUp()
        {
            darkmode_CheckBox.IsChecked=Properties.Settings.Default.isWindowInDarkMode;
            hideApp_CheckBox.IsChecked=Properties.Settings.Default.isWindowHidden;
            RetreiveSavedSize();
            if (hideApp_CheckBox.IsChecked == true)
            {
                MinimizeWindow();
            }
            if(darkmode_CheckBox.IsChecked == true)
            {
                TurnToDarkMode();
            }

        }
        //to make it as a Tab on Desktop
        private void MinimizeWindow()
        {
            Width = Properties.Settings.Default.hiddenWindowWidth;
            Height = Properties.Settings.Default.hiddenWindowHeight;
            exit_btn.Visibility = Visibility.Collapsed;
            tabs.Visibility = Visibility.Collapsed;
            mainWindow.Background = Brushes.Red;
            logo.Visibility = Visibility.Visible;
            CalculatePosition();
        }
        private void MaximizeWindow()
        {
            Width = Properties.Settings.Default.shownWindowWidth;
            Height = Properties.Settings.Default.shownWindowHeight;
            exit_btn.Visibility = Visibility.Visible;
            tabs.Visibility = Visibility.Visible;
            mainWindow.Background = Brushes.White;
            logo.Visibility = Visibility.Collapsed;
            CalculatePosition();
        }
        public MainWindow()
        {
            InitializeComponent();
            ApplySettingsOnStartUp();
            CalculatePosition();
            
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
       
        private void applySettings_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings(Convert.ToSingle(hiddenWindowWidth.Text), Convert.ToSingle(hiddenWindowHeight.Text), Convert.ToSingle(shownWindowWidth.Text), Convert.ToSingle(shownWindowHeight.Text));
            if (hideApp_CheckBox.IsChecked==true)
            {
                MinimizeWindow();
            }
            else
            {
                MaximizeWindow();
            }
            if (darkmode_CheckBox.IsChecked == true)
            {
                TurnToDarkMode();
            }
            else
            {
                TurnToLightMode();
            }



        }  
        private void window_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.isWindowHidden)
            {
                MaximizeWindow();
            }
        }
        private void window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.isWindowHidden)
            {
                MinimizeWindow();
            }
        }
        private void hiddenWindowWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            float minWidth = 50;
            if (Convert.ToSingle(hiddenWindowWidth.Text) < minWidth)
            {
                hiddenWindowWidth.Text = $"{minWidth}";
                hiddenWindowWidth.Foreground = Brushes.Red;
            }
        }
        private void hiddenWindowHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            float minHeight = 50;
            if (Convert.ToSingle(hiddenWindowHeight.Text) < minHeight)
            {
                hiddenWindowHeight.Text = $"{minHeight}";
                hiddenWindowHeight.Foreground = Brushes.Red;
            }
        }
        private void shownWindowWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            float minWidth = 300;
            if (Convert.ToSingle(shownWindowWidth.Text) < minWidth)
            {
                shownWindowWidth.Text = $"{minWidth}";
                shownWindowWidth.Foreground = Brushes.Red;
            }
        }
        private void shownWindowHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            float minHeight = 320;
            if (Convert.ToSingle(shownWindowHeight.Text) < minHeight)
            {
                shownWindowHeight.Text = $"{minHeight} ";
                shownWindowHeight.Foreground = Brushes.Red;
            }
        }
        private void SizeWindows_GetFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Foreground = Brushes.Black;
        }
    }
            
}
