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
    public partial class EditAlbum : Page
    {
        public EditAlbum(Album album)
        {
            InitializeComponent();
            AlbumLabel.Text = album.Name;
            photosListBox.ItemsSource = album.GetImages();
            SelectedAlbum = album;
            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                BackBtn.Foreground = Brushes.White;
                ScrollViewer.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                AlbumLabel.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                AlbumLabel.Foreground = Brushes.White;
                addPics.Foreground = Brushes.White;
                delPics.Foreground = Brushes.White;

            }

        }
        public Album SelectedAlbum{ get; set; }

        private void clickGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void SaveAlbum(object sender, RoutedEventArgs e)
        {
            SelectedAlbum.Name= AlbumLabel.Text;

            MessageBox.Show("Changes applied");
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void addPics_Click(object sender, RoutedEventArgs e)
        {
            SelectedAlbum.Name = AlbumLabel.Text;
            this.NavigationService.Navigate(new AddPictureToAlbum(SelectedAlbum));

        }

        private void delPics_Click(object sender, RoutedEventArgs e)
        {
            SelectedAlbum.Name = AlbumLabel.Text;
            this.NavigationService.Navigate(new DelPictureFromAlbum(SelectedAlbum));


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("Delete This Album?", "Confirmation", buttons);
            if (result == MessageBoxResult.Yes)
            {
                GlobalData.albums.Remove(SelectedAlbum);

                MessageBox.Show("Album has been deleted");
                GalleryPage gallery_page = new GalleryPage();
                this.NavigationService.Navigate(gallery_page);
            }
        }
    }
}
