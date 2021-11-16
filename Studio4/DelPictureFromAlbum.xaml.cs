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
using System.Linq;
namespace Studio4
{
    /// <summary>
    /// Interaction logic for ViewAlbumPage.xaml
    /// </summary>
    public partial class DelPictureFromAlbum : Page
    {
        public DelPictureFromAlbum(Album album)
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
            }

        }
        public Album SelectedAlbum { get; set; }

        private void SaveAlbum(object sender, RoutedEventArgs e)
        {
            var selected = (photosListBox.SelectedItem as UploadedImage);

            //invoiceBox.Items.RemoveAt(invoiceBox.SelectedIndex);
            //string delete_num = selected.Num;
            if (selected != null)
            {
                SelectedAlbum.Name = AlbumLabel.Text;
                foreach (var item in photosListBox.SelectedItems)
                {
                    SelectedAlbum.RemoveImageFromAlbum(item as UploadedImage);
                }
                MessageBox.Show("Photo(s) Removed From Album");
                this.NavigationService.Navigate(new DelPictureFromAlbum(SelectedAlbum));
            }
            else
            {
                MessageBox.Show("Please select photo(s) to remove");

            }
    

        }

        private void backtoAlbum(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAlbum(SelectedAlbum));

        }
    }
}
