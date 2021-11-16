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
    /// Interaction logic for ViewAlbumPage.xaml
    /// </summary>
    public partial class ViewAlbumPage : Page
    {
        public ViewAlbumPage(Album album)
        {
            InitializeComponent();
            AlbumLabel.Content = album.Name;
            photosListBox.ItemsSource = album.GetImages();
            SelectedAlbum = album;

            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                BackBtn.Foreground = Brushes.White;
                ScrollViewer.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                editBtn.Foreground = Brushes.White;
            }

        }
        public Album SelectedAlbum { get; set; }

        private void clickGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void SelectedPhoto(object sender, SelectionChangedEventArgs e)
        {
            var image = (photosListBox.SelectedItem as UploadedImage);
            NavigationService.Navigate(new EditPicture(image));
        }

        private void EditAlbum(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAlbum(SelectedAlbum));
        }
    }
}

