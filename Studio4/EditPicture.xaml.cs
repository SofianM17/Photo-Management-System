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
    /// Interaction logic for EditPicture.xaml
    /// </summary>
    public partial class EditPicture : Page
    {
        
        public EditPicture(UploadedImage newPicture)
        {
            InitializeComponent();
            //viewPicture.Source = (ImageSource) new Uri(newPicuture.ImgSrc, UriKind.Relative);
            viewPicture.Source = newPicture.ImgSrcAsImageSource;
            pictureTitle.Text = newPicture.ImgName;
            pictureDesc.Text = newPicture.ImgDescription;
            picturePrice.Text = newPicture.ImgPrice.ToString();
            SelectedPhoto = newPicture;

            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                PageTitle.Foreground = Brushes.White;
                BackBtn.Foreground = Brushes.White;
                SalesPrice.Foreground = Brushes.White;
                Desc.Foreground = Brushes.White;
                Title.Foreground = Brushes.White;
                tooltip1.Background = Brushes.White;
                tooltip2.Background = Brushes.White;
                tooltip3.Background = Brushes.White;
            }

            if (GlobalData.SetTips == true)
            {
                tooltip1.Opacity = 1;
            }


            else
            {
                tooltip1.Opacity = 0;
                tooltip2.Opacity = 0;
                tooltip3.Opacity = 0;
                tooltipsalestext.Foreground = Brushes.Transparent;
                tooltipdestext.Foreground = Brushes.Transparent;
                tooltiptitletext.Foreground = Brushes.Transparent;
                tooltip3sales1.Background = Brushes.Transparent;
                tooltip3sales1.BorderBrush = Brushes.Transparent;
                tooltip2des1.Background = Brushes.Transparent;
                tooltip2des1.BorderBrush = Brushes.Transparent;
                tooltip1title1.Background = Brushes.Transparent;
                tooltip1title1.BorderBrush = Brushes.Transparent;
            }


        }

        public UploadedImage SelectedPhoto { get; set; }

        private void clickGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }
        private void saveChanges(object sender, RoutedEventArgs e)
        {
            SelectedPhoto.ImgName = pictureTitle.Text;
            SelectedPhoto.ImgDescription= pictureDesc.Text;
            SelectedPhoto.ImgPrice= Double.Parse(picturePrice.Text);

            MessageBox.Show("Changes applied");
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }
        private void deletePicture(object sender, RoutedEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("Delete selected photograph?", "Confirmation", buttons);
            if (result == MessageBoxResult.Yes)
            {

                foreach (var item in GlobalData.albums)
                {
                    item.RemoveImageFromAlbum(SelectedPhoto);
                }
                GlobalData.UploadedImages.Remove(SelectedPhoto);


                MessageBox.Show("Photo has been deleted");
                GalleryPage gallery_page = new GalleryPage();
                this.NavigationService.Navigate(gallery_page);
            }

        }
       
        

    }
}
