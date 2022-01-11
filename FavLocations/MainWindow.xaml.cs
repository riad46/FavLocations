using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
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
        private List<string> pathsList = Properties.Settings.Default.pathsList == null? new() : Properties.Settings.Default.pathsList.Cast<string>().ToList() ;
        private List<string> namesList= Properties.Settings.Default.namesList == null ? new() : Properties.Settings.Default.namesList.Cast<string>().ToList();

       
        public MainWindow()
        {
            InitializeComponent();  
            FillShortcutsPage();
            ApplySettingsOnStartUp();            
            CalculatePosition();            
            
        }
        private void CalculatePosition()
        {
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
        }
        private void TurnElementsToDark()
        {
            // shortcuts tab
            var childrensList = shortcuts_panel.Children;
            foreach (var child in childrensList)
            {
                if (child.GetType() == new Button().GetType())
                {
                    (child as Button).Foreground= new SolidColorBrush(Colors.White);                  
                    (child as Button).BorderBrush = new SolidColorBrush(Colors.Ivory);

                }
            }
            //management tab
            childrensList=managementTab.Children;
            foreach (var child in childrensList)
            {
                if (child.GetType() == new TextBox().GetType())
                {
                    (child as TextBox).Background = new SolidColorBrush(Colors.Black);
                    (child as TextBox).BorderBrush = new SolidColorBrush(Colors.Ivory);
                    (child as TextBox).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new TextBlock().GetType())
                {

                    (child as TextBlock).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new Button().GetType())
                {
                    (child as Button).Background = new SolidColorBrush(Colors.Black);
                    (child as Button).BorderBrush = new SolidColorBrush(Colors.Ivory);
                    (child as Button).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new Border().GetType())
                {
                    (child as Border).Background = new SolidColorBrush(Colors.Ivory);
                    (child as Border).BorderBrush = new SolidColorBrush(Colors.Ivory);

                }
                //if (child.GetType() == new ComboBox().GetType())
                //{
                //    (child as ComboBox).Background = new SolidColorBrush(Colors.Transparent);
                //    (child as ComboBox).Foreground = new SolidColorBrush(Colors.Blue);
                //}
            }
            //settings tab
             childrensList = settingsTab.Children;
            foreach (var child in childrensList)
            {
                if (child.GetType() == new TextBox().GetType())
                {
                    (child as TextBox).Background = new SolidColorBrush(Colors.Black);
                    (child as TextBox).BorderBrush = new SolidColorBrush(Colors.Ivory);
                    (child as TextBox).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new TextBlock().GetType())
                {

                    (child as TextBlock).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new Button().GetType())
                {
                    (child as Button).Background = new SolidColorBrush(Colors.Black);
                    (child as Button).BorderBrush = new SolidColorBrush(Colors.Ivory);
                    (child as Button).Foreground = new SolidColorBrush(Colors.White);
                }
                if (child.GetType() == new Border().GetType())
                {
                    (child as Border).Background = new SolidColorBrush(Colors.Ivory);
                    (child as Border).BorderBrush = new SolidColorBrush(Colors.Ivory);

                }
                if (child.GetType() == new CheckBox().GetType())
                {
                    (child as CheckBox).Foreground = new SolidColorBrush(Colors.White);

                }
                if (child.GetType() == new GroupBox().GetType())
                {
                    (child as GroupBox).Foreground = Brushes.White;
                }
            }
        }
        private void TurnToDarkMode()
        {
            mainWindow.Background = new SolidColorBrush(Colors.Black);
            TurnElementsToDark();
        }
        private void TurnToLightMode()
        {
            //mainWindow.Background = new SolidColorBrush(Colors.White);
        }
        private void CreateButton(string name)
        {
            Button btn = new();
            btn.Content = name;
            btn.Height = 41;
            btn.Background = new SolidColorBrush(Colors.Transparent);
            btn.Foreground = new SolidColorBrush(Colors.Black);
            btn.Click += new RoutedEventHandler(shortcutButton_Click);     
            shortcuts_panel.Children.Add(btn);  
        }
      
     
        //used to save the path and name to lists before saving on close
        private void addPathAndNameToList(string path,string name)
        {
            pathsList.Add(path);
            namesList.Add(name);
        }
        #region Controls Events
       
        #region Management page Events
         private void pathBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (returnToInitialStat_pathBox)
            {
                pathBox.Text = "";
                pathBox.Foreground =Brushes.Black;
                if (nameBox.Text == "Name this Location Here")
                {
                    nameBox.Text = "";
                }
                returnToInitialStat_pathBox = false;
            } 
        }
         private void pathBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pathBox.Text.Length == 0 )
            {
                pathBox.Text = "Insert your path here";
                pathBox.Foreground = Brushes.LightGray;
                returnToInitialStat_pathBox = true;
            }            
        }
         private void nameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (returnToInitialStat_nameBox)
            {
                if (pathBox.Text == "Insert your path here")
                {
                    pathBox.Text = "";
                }
                nameBox.Text = "";
                nameBox.Foreground =Brushes.Black;
                returnToInitialStat_nameBox = false;
            }
        }
         private void nameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Length == 0)
            {
                nameBox.Text = "Name this Location Here";
                nameBox.Foreground = Brushes.LightGray;
                returnToInitialStat_nameBox = true;
            }
        }
         private void addPathButton_Click(object sender, RoutedEventArgs e)
        {
            string shortcutElementPath = $"{pathBox.Text}";
            string shortcutElementName = $"{nameBox.Text}";
            if(shortcutElementPath.Length == 0 || shortcutElementPath== "Insert your path here" || shortcutElementName.Length == 0 || shortcutElementName== "Name this Location")
            {
                MessageBox.Show(this, "Please Fill Both Boxes", "HEY!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            addPathAndNameToList(shortcutElementPath, shortcutElementName);
            pathBox.Text = "";
            nameBox.Text = "";        
            ResetDeleteComboBox();  
            FillDeleteComboBox();
            FillShortcutsPage(); 
        }
         private void deleteShortcutButton_Click(object sender, RoutedEventArgs e)
        {
            if(delete_comboBox.SelectedItem==null) return;  
            string shortcutElement = delete_comboBox.SelectedItem.ToString();
            if (shortcutElement != null)
            {
                var elementIdex = namesList.IndexOf(shortcutElement);
                namesList.Remove(shortcutElement);
                pathsList.RemoveAt(elementIdex);
                ResetDeleteComboBox();
                FillDeleteComboBox();
                FillShortcutsPage();
            }
        }

        #endregion

        #region Settings page Events
        private void applySettings_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
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
        private void hiddenWindowWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            float minWidth = 50;
            if (Convert.ToSingle(hiddenWindowWidth.Text) < minWidth)
            {
                hiddenWindowWidth.Text = $"{minWidth}";
                hiddenWindowWidth.Foreground = Brushes.Red;
                MessageBox.Show(this, "Minimum Width for window in hidden mode is 50", "Wait!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private void hiddenWindowHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            float minHeight = 50;
            if (Convert.ToSingle(hiddenWindowHeight.Text) < minHeight)
            {
                hiddenWindowHeight.Text = $"{minHeight}";
                hiddenWindowHeight.Foreground = Brushes.Red;
                MessageBox.Show(this, "Minimum Height for window in hidden mode is 50", "Wait!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
          
        }
        private void shownWindowWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            float minWidth = 300;
            if (Convert.ToSingle(shownWindowWidth.Text) < minWidth)
            {
                shownWindowWidth.Text = $"{minWidth}";
                shownWindowWidth.Foreground = Brushes.Red;
                MessageBox.Show(this, "Minimum Width for window in shown mode is 300", "Wait!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
        private void shownWindowHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            float minHeight = 320;
            if (Convert.ToSingle(shownWindowHeight.Text) < minHeight)
            {
                shownWindowHeight.Text = $"{minHeight} ";
                shownWindowHeight.Foreground = Brushes.Red;
                MessageBox.Show(this, "Minimum height for window in shown mode is 320", "Wait!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
        private void SizeWindows_GetFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Foreground = Brushes.Black;
        }
        #endregion
      
        #region Shortcuts Events
        private void openApath(Object senderButton)
        {
            var pathsname = (senderButton as Button).Content as string;
            var pathsIndex = namesList.IndexOf(pathsname);
            var pathToOpen = pathsList[pathsIndex];
            Process.Start("explorer.exe", @$"{pathToOpen}");
        }
        private void shortcutButton_Click(object sender, RoutedEventArgs e)
        {
            openApath(sender);        
        }

        #endregion

        #region Window Events
        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }
        #endregion

        #endregion
        
        #region From App to Settings
        //app user's settings
        private void AddWindowDisplayModeToSettings()
        {
            Properties.Settings.Default.isWindowHidden = (bool)hideApp_CheckBox.IsChecked;
            Properties.Settings.Default.isWindowInDarkMode=(bool)darkmode_CheckBox.IsChecked;
            Properties.Settings.Default.Save();
        }
        private void AddSizeToSettings(float hiddenWidth, float hiddenHeigth, float shownWidth, float shownHeigth)
        {
            Properties.Settings.Default.hiddenWindowWidth = hiddenWidth;
            Properties.Settings.Default.hiddenWindowHeight = hiddenHeigth;
            Properties.Settings.Default.shownWindowWidth = shownWidth;
            Properties.Settings.Default.shownWindowHeight = shownHeigth;
            Properties.Settings.Default.Save();
        }
        //shortcuts
        private void AddDataToSettings()
        {
            StringCollection pathsCollection = new();
            foreach (var item in pathsList)
            {
                pathsCollection.Add(item);
            }

            StringCollection namesCollection = new();
            foreach (var item in namesList)
            {
               namesCollection.Add(item);
            }

            Properties.Settings.Default.pathsList = pathsCollection;
            Properties.Settings.Default.namesList = namesCollection;
            Properties.Settings.Default.Save();
        }
        private void SaveSettings()
        {
            AddSizeToSettings(Convert.ToSingle(hiddenWindowWidth.Text), Convert.ToSingle(hiddenWindowHeight.Text), Convert.ToSingle(shownWindowWidth.Text), Convert.ToSingle(shownWindowHeight.Text));
            AddWindowDisplayModeToSettings();
            AddDataToSettings();           
         
        }
        #endregion
        
        #region From Settings to App    
        private void RetreiveSavedSize()
        {
            hiddenWindowWidth.Text = Properties.Settings.Default.hiddenWindowWidth.ToString();
            hiddenWindowHeight.Text = Properties.Settings.Default.hiddenWindowHeight.ToString();
            shownWindowWidth.Text = Properties.Settings.Default.shownWindowWidth.ToString();
            shownWindowHeight.Text = Properties.Settings.Default.shownWindowHeight.ToString();
        }
        #endregion
      
        #region Load Values from Settings to Components
        private void ApplySettingsOnStartUp()
        {
            darkmode_CheckBox.IsChecked = Properties.Settings.Default.isWindowInDarkMode;
            hideApp_CheckBox.IsChecked = Properties.Settings.Default.isWindowHidden;
            RetreiveSavedSize();
            if (hideApp_CheckBox.IsChecked == true)
            {
                MinimizeWindow();
            }
            else
            {
                MaximizeWindow();
            }
            if(darkmode_CheckBox.IsChecked==true)
            {
                TurnToDarkMode();
            }
           FillDeleteComboBox();
            
        }
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
        private void FillShortcutsPage()
        {
            shortcuts_panel.Children.Clear();
            if (pathsList == null)
            {
                return;
            }
            foreach (var item in namesList)
            {
                CreateButton(item);
            }
        }
        private void FillDeleteComboBox()
        {
            if (namesList != null)
            {
                delete_comboBox.ItemsSource = namesList;

            }
            else
            {
                delete_comboBox.ItemsSource = new List<string>();
            }
        }
        private void ResetDeleteComboBox()
        {
            delete_comboBox.SelectedItem = null;
            delete_comboBox.ItemsSource = null;
        }

        #endregion

       
    }

}
