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
    /// Interaction logic for AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Page
    {
        public AddAlbum()
        {
            InitializeComponent();

            photosListBox.ItemsSource = GlobalData.UploadedImages;

            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                infoLbl.Foreground = Brushes.White;
                BackBtn.Foreground = Brushes.White;
                tooltip.Background = Brushes.White;
                ScrollViewer.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                AlbumNameTextbox.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                AlbumNameTextbox.Foreground = Brushes.White;
            }

            if (GlobalData.SetTips == true)
            {
                tooltip.Opacity = 1;
            }

            else
            {
                tooltips.Opacity = 0;
                tooltip.Visibility = Visibility.Hidden;
                tooltiptext.Foreground = Brushes.Transparent;
                tooltips1.Background = Brushes.Transparent;
                tooltips1.BorderBrush = Brushes.Transparent;
            }


        }


        //private List<UploadedImage> GetPhotos()
        //{
        //    return new List<UploadedImage>()
        //    {
        //        new UploadedImage("Photo 1", "./Resources/sampleimage1.jpg", "hehe", 420),
        //        new UploadedImage("Photo 2", "./Resources/sampleimage2.jpg", " chupa ", 420),
        //        new UploadedImage("Photo 3", "./Resources/sampleimage3.jpg", "opop", 420),
        //        new UploadedImage("Photo 4", "./Resources/sampleimage4.jpg", "jajajaja", 420),

        //      };
        //}
        private void clickGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void create_Album(object sender, RoutedEventArgs e)
        {
            if(photosListBox.Items.Count > 0 && photosListBox.SelectedIndex > -1)
            {
                Album album = new Album(AlbumNameTextbox.Text);


                foreach (var item in photosListBox.SelectedItems)
                {
                    album.AddImageToAlbum(item as UploadedImage);
                }

                GlobalData.albums.Add(album);
                GalleryPage gallery_page = new GalleryPage();
                this.NavigationService.Navigate(gallery_page);
            }

            if(photosListBox.Items.Count == 0)
            {
                MessageBox.Show("Please upload a photo to create an album");
            }

            if(photosListBox.SelectedIndex == -1 && photosListBox.Items.Count > 0)
            {
                MessageBox.Show("Please select a photo to create the album");
            }

        }


    }
}
