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
    public partial class AddPictureToAlbum : Page
    {
        public AddPictureToAlbum(Album album)
        {
            InitializeComponent();
            SelectedAlbum = album;
            AlbumLabel.Text = album.Name;
            var albImgs = album.GetImages();
            var galImgs = GlobalData.UploadedImages;
            var result = galImgs.Except(albImgs);

            photosListBox.ItemsSource = result;
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
                    SelectedAlbum.AddImageToAlbum(item as UploadedImage);
                }
                MessageBox.Show("Photo(s) Added to Album");
                this.NavigationService.Navigate(new AddPictureToAlbum(SelectedAlbum));

            }
            else
            {
                MessageBox.Show("Please select photo(s) to add");

            }
        }

        private void backtoAlbum(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditAlbum(SelectedAlbum));

        }
    }
}
