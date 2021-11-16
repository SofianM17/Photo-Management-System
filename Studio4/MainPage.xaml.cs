using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Studio4
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            formatName();
            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18,18,18));
                Text.Foreground = Brushes.White;
                Text1.Foreground = Brushes.White;
                Text2.Foreground = Brushes.White;
                Text3.Foreground = Brushes.White;
            }
            else
            {
                MainGrid.Background = Brushes.White;
            }

            if (GlobalData.SetTips == true && GlobalData.dark_mode == false)
            {
                Text3.Foreground = Brushes.Black;
            }


            else if (GlobalData.SetTips == true && GlobalData.dark_mode == true) {
                Text3.Foreground = Brushes.White;
            }
            else
            {
                Text3.Foreground = Brushes.Transparent;
            }
        }

            private void clickSales(object sender, RoutedEventArgs e)
        {
            SalesPage sales_page = new SalesPage();
            this.NavigationService.Navigate(sales_page);
        }

        private void mainPage_galleryBtn(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
            
        }

        private void MainPage_UploadBtn(object sender, RoutedEventArgs e)
        {
            Upload_Pre_Import pre_import_page = new Upload_Pre_Import();
            this.NavigationService.Navigate(pre_import_page);
        }

        private void SettingsBtn_MainPage(object sender, RoutedEventArgs e)
        {
            if(GlobalData.settingsPage == null)
            {
                Account settings_page = new Account();
                this.NavigationService.Navigate(settings_page);
            }
            else
            {
                this.NavigationService.Navigate(GlobalData.settingsPage);
            }
        }
        
        // Displays the username (text before email) as a label at the top of the page
        void formatName()
        {
            string name = GlobalData.username;
            if (name != null)
            {
                int index = name.IndexOf('@');
                if(index > 0)
                {
                    Name_Label.Content = name.Substring(0, index);
                }
                
            } else
            {
                Name_Label.Content = GlobalData.username;
            }
        }

    }

}
