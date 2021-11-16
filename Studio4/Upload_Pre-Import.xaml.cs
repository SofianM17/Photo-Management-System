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
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Studio4
{
    /// <summary>
    /// Interaction logic for Upload_Pre_Import.xaml
    /// </summary>
    public partial class Upload_Pre_Import : Page
    {
        public Upload_Pre_Import()
        {
            InitializeComponent();

            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                Text.Foreground = Brushes.White;
                tooltip.Background = Brushes.White;
                Upload.Foreground = Brushes.White;
                Gallery.Foreground = Brushes.White;
                Sales.Foreground = Brushes.White;
            }
            else
            {
                MainGrid.Background = Brushes.White;
            }
            if (GlobalData.SetTips == false)
            {
                tooltip.Background = Brushes.Transparent;
                tooltip1.Opacity = 0;
                tooltip.Visibility = Visibility.Hidden;
                tooltiptext.Foreground = Brushes.Transparent;
                tooltip2.Background = Brushes.Transparent;
                tooltip2.BorderBrush = Brushes.Transparent;
            }
        }


        private void Import_Btn(object sender, RoutedEventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = opf.FileName;
                System.IO.Directory.CreateDirectory("../../../LoadedImages/");
                string destFile = "../../../LoadedImages/" + opf.SafeFileName;

                string destFileForUse = "./LoadedImages/" + opf.SafeFileName;

                File.Copy(sourceFile, destFile, true);

                UploadedImage uI = new UploadedImage(opf.SafeFileName, destFileForUse, "Enter a description", 0);

                // convert the string to an image source
                ImageSourceConverter conv = new ImageSourceConverter();
                uI.ImgSrcAsImageSource = (ImageSource)conv.ConvertFromInvariantString(destFile);
                
                GlobalData.UploadedImages.Add(uI);

                System.Windows.MessageBox.Show("Photo uploaded!");

            }
        }

        private void toGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void toSales(object sender, RoutedEventArgs e)
        {
            SalesPage sales_page = new SalesPage();
            this.NavigationService.Navigate(sales_page);
        }

        private void toSettingsPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Account());
        }
    }
}
