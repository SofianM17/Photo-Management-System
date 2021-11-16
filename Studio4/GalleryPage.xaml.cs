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
    public partial class GalleryPage : Page
    {
        public GalleryPage()
        {
            InitializeComponent();

            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                AlbumLabel.Foreground = Brushes.White;
                PortfolioLabel.Foreground = Brushes.White;
                tooltip.Background = Brushes.White;
                noUploadsLbl.Foreground = Brushes.White;
                CreateBtn.Foreground = new SolidColorBrush(Color.FromRgb(255, 230, 230));
            }

            if (GlobalData.SetTips == true)
            {
                tooltip.Opacity = 1;
            }

            else
            {
                tooltips.Opacity = 0;
                tooltiptext.Foreground = Brushes.Transparent;
                tooltip.Visibility = Visibility.Hidden;
            }

            // List<UploadedImage> galleryImages = new List<UploadedImage>();

            //FOR TESTING
            //UploadedImage img1 = new UploadedImage("Photo 1", "pack://application:,,,/Resources/sampleimage1.jpg", "hehe", 30);
            //img1.DateCreated = img1.DateCreated.Add(new TimeSpan(-8, 0, 0));
            //galleryImages.Add(img1);

            //UploadedImage img2 = new UploadedImage("Photo 2", "pack://application:,,,/Resources/sampleimage2.jpg", "chupa", 20);
            //img2.DateCreated = img2.DateCreated.Add(new TimeSpan(-2, 0, 0));
            //galleryImages.Add(img2);

            //UploadedImage img3 = new UploadedImage("Photo 3", "pack://application:,,,/Resources/sampleimage3.jpg", "poowoo", 100);
            //img3.DateCreated = img3.DateCreated.Add(new TimeSpan(-4, 0, 0));
            //galleryImages.Add(img3);

            //UploadedImage img4 = new UploadedImage("Photo 4", "pack://application:,,,/Resources/sampleimage4.jpg", "test desc", 50);
            //img4.DateCreated = img4.DateCreated.Add(new TimeSpan(-1, 0, 0));
            //galleryImages.Add(img4);

            albumsListBox.ItemsSource = GlobalData.albums;
            photosListBox.ItemsSource = GlobalData.UploadedImages;

            // if no images, hide portfolio and display import button
            if (GlobalData.UploadedImages.Count == 0)
            {
                photosListBox.Visibility = Visibility.Hidden;
                importButton.Visibility = Visibility.Visible;
                noUploadsLbl.Visibility = Visibility.Visible;
            }
            //photosListBox.ItemsSource = galleryImages;

        }

        private void Import_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Upload_Pre_Import());
        }



        private void Create_Album_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAlbum());
        }

        private void Album_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAlbum());
        }



        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account());
        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Upload_Pre_Import());
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SalesPage());
        }

        private void sortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (photosListBox == null) return;
            
            // get currently selected sort method
            string currentSortMethod = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            switch (currentSortMethod)
            {
                case "Sort: Newest":
                    photosListBox.ItemsSource = SortNewest();
                    break;
                case "Sort: Oldest":
                    photosListBox.ItemsSource = SortOldest();
                    break;
                case "Sort: Price Asc.":
                    photosListBox.ItemsSource = SortPriceAsc();
                    break;
                case "Sort: Price Desc.":
                    photosListBox.ItemsSource = SortPriceDesc();
                    break;
                default:
                    break;
            }
        }

        private void Image_MouseEnter(object sender, MouseButtonEventArgs e)
        {
            ((ToolTip)((FrameworkElement)sender).ToolTip).IsOpen = true;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            ((ToolTip)((FrameworkElement)sender).ToolTip).IsOpen = false;
        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            //MouseUp = "Image_MouseUp"
            ((ToolTip)((FrameworkElement)sender).ToolTip).IsOpen = true;
        }

        // when the user clicks on an album on the page
        private void AlbumSelected(object sender, SelectionChangedEventArgs e)
        {
            var album = (albumsListBox.SelectedItem as Album);
            NavigationService.Navigate(new ViewAlbumPage(album));
        }

        // when the user clicks on a photo on the page
        private void PhotoSelected(object sender, SelectionChangedEventArgs e)
        {
            var image = (photosListBox.SelectedItem as UploadedImage);
            NavigationService.Navigate(new EditPicture(image));
        }

        private List<UploadedImage> SortNewest()
        {
            // store an instance of the current uploaded images
            var allPhotos = new List<UploadedImage>(GlobalData.UploadedImages);
            var sortedPhotos = new List<UploadedImage>();

            while(allPhotos.Count != 0)
            {
                DateTime oldestTime = DateTime.Now;
                UploadedImage currentOldestUploadedImage = new UploadedImage();
                int indexOfOldest = -1;
                
                for (int i = 0; i < allPhotos.Count; i++)
                {
                    // new oldest photo found in remaining photos
                    if(allPhotos.ToArray()[i].DateCreated <= oldestTime)
                    {
                        currentOldestUploadedImage = allPhotos.ToArray()[i];
                        oldestTime = currentOldestUploadedImage.DateCreated;
                        indexOfOldest = i;
                    }
                }
                // push the found oldest image to the front
                sortedPhotos.Insert(0, currentOldestUploadedImage);
                if(allPhotos.Count > 0)
                {
                    allPhotos.RemoveAt(indexOfOldest);
                }
            }

            return sortedPhotos;
        }

        private List<UploadedImage> SortOldest()
        {
            // store an instance of the current uploaded images
            var allPhotos = new List<UploadedImage>(GlobalData.UploadedImages);
            var sortedPhotos = new List<UploadedImage>();

            while (allPhotos.Count != 0)
            {
                DateTime oldestTime = DateTime.Now;
                UploadedImage currentOldestUploadedImage = new UploadedImage();
                int indexOfOldest = -1;

                for (int i = 0; i < allPhotos.Count; i++)
                {
                    // new newest photo found in remaining photos
                    if (allPhotos.ToArray()[i].DateCreated <= oldestTime)
                    {
                        currentOldestUploadedImage = allPhotos.ToArray()[i];
                        oldestTime = currentOldestUploadedImage.DateCreated;
                        indexOfOldest = i;
                    }
                }
                // add the found newer image to the back
                sortedPhotos.Add(currentOldestUploadedImage);
                if (allPhotos.Count > 0)
                {
                    allPhotos.RemoveAt(indexOfOldest);
                }
            }

            return sortedPhotos;
        }

        private List<UploadedImage> SortPriceAsc()
        {
            // store an instance of the current uploaded images
            var allPhotos = new List<UploadedImage>(GlobalData.UploadedImages);
            var sortedPhotos = new List<UploadedImage>();

            while (allPhotos.Count != 0)
            {
                double highestPrice = 0.0;
                UploadedImage currentLowestPriceUploadedImage = new UploadedImage();
                int indexOfLowest = -1;

                for (int i = 0; i < allPhotos.Count; i++)
                {
                    // new highest price photo found in remaining photos
                    if (allPhotos.ToArray()[i].ImgPrice >= highestPrice)
                    {
                        currentLowestPriceUploadedImage = allPhotos.ToArray()[i];
                        highestPrice = currentLowestPriceUploadedImage.ImgPrice;
                        indexOfLowest = i;
                    }
                }
                // push the new highest priced photo to the front
                sortedPhotos.Insert(0, currentLowestPriceUploadedImage);
                if (allPhotos.Count > 0)
                {
                    allPhotos.RemoveAt(indexOfLowest);
                }
            }

            return sortedPhotos;
        }

        private List<UploadedImage> SortPriceDesc()
        {
            // store an instance of the current uploaded images
            var allPhotos = new List<UploadedImage>(GlobalData.UploadedImages);
            var sortedPhotos = new List<UploadedImage>();

            while (allPhotos.Count != 0)
            {
                double highestPrice = 0.0;
                UploadedImage currentLowestPriceUploadedImage = new UploadedImage();
                int indexOfLowest = -1;

                for (int i = 0; i < allPhotos.Count; i++)
                {
                    // new highest price photo found in remaining photos
                    if (allPhotos.ToArray()[i].ImgPrice >= highestPrice)
                    {
                        currentLowestPriceUploadedImage = allPhotos.ToArray()[i];
                        highestPrice = currentLowestPriceUploadedImage.ImgPrice;
                        indexOfLowest = i;
                    }
                }
                // add the new highest priced photo to the back
                sortedPhotos.Add(currentLowestPriceUploadedImage);
                if (allPhotos.Count > 0)
                {
                    allPhotos.RemoveAt(indexOfLowest);
                }
            }

            return sortedPhotos;
        }

        private void toGallery(object sender, RoutedEventArgs e)
        {

        }
    }
}
