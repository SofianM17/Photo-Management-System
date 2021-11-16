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
using System.IO;

using Microsoft.Win32;

namespace Studio4
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        //public int ctr = 0;
        public string graph_path = "/Images/Graph0.png";

        public SalesPage()
        {
            InitializeComponent();
            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                tooltip.Background = Brushes.White;
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
            }
            invoiceBox.ItemsSource = GlobalData.InvoiceList;

            GraphPic.Source = new BitmapImage(new Uri(graph_path, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void toGallery(object sender, RoutedEventArgs e)
        {
            GalleryPage gallery_page = new GalleryPage();
            this.NavigationService.Navigate(gallery_page);
        }

        private void toUpload(object sender, RoutedEventArgs e)
        {
            Upload_Pre_Import preupload_page = new Upload_Pre_Import();
            this.NavigationService.Navigate(preupload_page);
        }

        private void toSettingsPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Account());
        }

        private void addInvoice(object sender, RoutedEventArgs e)
        {
            String file_n;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Pdf Files (*.pdf)|*.pdf";

            if (fileDialog.ShowDialog() == true) {
                file_n = fileDialog.SafeFileName;

                string sourceFile = fileDialog.FileName;
                System.IO.Directory.CreateDirectory("../../../LoadedInvoices");
                string destFile = "../../../LoadedInvoices/" + file_n;
                string destFileForUse = "./LoadedInvoices/" + file_n;

                File.Copy(sourceFile, destFile, true);

                string date = DateTime.Today.ToString("d");
                InvoiceItem newItem = new InvoiceItem();
                //ctr++;
                GlobalData.ctr++;
                newItem.Num = GlobalData.ctr;
                newItem.Name = file_n;
                newItem.Date = date;
                newItem.pdfName = fileDialog.SafeFileName;
                

                //invoiceBox.Items.Add(newItem);
                GlobalData.InvoiceList.Add(newItem);
                invoiceBox.ItemsSource = null;
                invoiceBox.ItemsSource = GlobalData.InvoiceList;

                string temp_path = changeGraph();
                graph_path = temp_path;
                GraphPic.Source = null;
                GraphPic.Source = new BitmapImage(new Uri(graph_path, UriKind.Relative));

            }

            
        }

 

        private void deleteInvoice(object sender, RoutedEventArgs e)
        {
            //Try catch might not be needed here, but put here just in case.
            try
            {
                var selected = (invoiceBox.SelectedItem as InvoiceItem);
                
                //invoiceBox.Items.RemoveAt(invoiceBox.SelectedIndex);
                //string delete_num = selected.Num;
                if (selected != null)
                {
                    for (int i = 0; i < GlobalData.InvoiceList.Count; i++)
                    {
                        if (selected == GlobalData.InvoiceList[i])
                        {
                            int num = selected.Num;
                            GlobalData.InvoiceList.RemoveAt(i);

                            reNumber(num);
                            GlobalData.ctr--;
                            invoiceBox.ItemsSource = null;
                            invoiceBox.ItemsSource = GlobalData.InvoiceList;

                            string temp_path = changeGraph();
                            graph_path = temp_path;
                            GraphPic.Source = null;
                            GraphPic.Source = new BitmapImage(new Uri(graph_path, UriKind.Relative));
                        }
                    }
                } else
                {
                    MessageBox.Show("Please select an invoice to delete");
                }
            } catch
            {
                MessageBox.Show("Please select an invoice to delete.");
            }
        }

       private void reNumber(int start)
        {
            for (int i = (start-1); i < GlobalData.InvoiceList.Count; i++)
            {
                GlobalData.InvoiceList[i].Num--;
            }
        }

       private string changeGraph()
        {
            string img_path = "";
            if (GlobalData.InvoiceList.Count == 0)
            {
                img_path = "/Images/Graph0.png";
            } else if (GlobalData.InvoiceList.Count == 1) 
            {
                img_path = "/Images/Graph1.png";
            } else if (GlobalData.InvoiceList.Count == 2)
            {
                img_path = "/Images/Graph2.png";
            } else if (GlobalData.InvoiceList.Count == 3)
            {
                img_path = "/Images/Graph3.png";
            } else if (GlobalData.InvoiceList.Count == 4)
            {
                img_path = "/Images/Graph4.png";
            } else if (GlobalData.InvoiceList.Count == 5)
            {
                img_path = "/Images/Graph5.png";
            } else if (GlobalData.InvoiceList.Count == 6)
            {
                img_path = "/Images/Graph6.png";
            } else if (GlobalData.InvoiceList.Count == 7)
            {
                img_path = "/Images/Graph7.png";
            } else if (GlobalData.InvoiceList.Count == 8)
            {
                img_path = "/Images/Graph8.png";
            } else if (GlobalData.InvoiceList.Count == 9)
            {
                img_path = "/Images/Graph9.png";
            } else if (GlobalData.InvoiceList.Count == 10)
            {
                img_path = "/Images/Graph10.png";
            }
            return img_path;
        }

        public string DisplayImage
        {
            get { return graph_path; }
        }

        private void download (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your invoice has been successfully downloaded.");
        }


        private void template_btn(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "word files(*.docx) | *.docx ";
            save.FileName = "InvoiceTemplate";
            Nullable<bool> result = save.ShowDialog();
            if (result == true)
            {
                if (!File.Exists(save.FileName))
                {
                    File.Copy("InvoiceTemplate.docx", save.FileName);
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBox.Show("Template Downloaded", "Confirmation", button);
                }

            }
            {

            }
         
        }

        private void downloadInvoices(object sender, RoutedEventArgs e)
        {
            //Get the item to download.
         
            var selected = invoiceBox.SelectedItem as InvoiceItem;
            if (selected != null)
            {
                SaveFileDialog download = new SaveFileDialog();
                download.Filter = "pdf files(*.pdf) | *.pdf ";
                download.FileName = selected.pdfName;
                Nullable<bool> result = download.ShowDialog();
                if (result == true)
                {
                    if (!File.Exists(download.FileName))
                    {
                        string destFile = "../../../LoadedInvoices/" + selected.pdfName;
                      
                        File.Copy(destFile, download.FileName, true);
                        MessageBox.Show("File successfully downloaded.");
                    }
                }
            } else
            {
                MessageBox.Show("Please select the invoice to download.");
            }
            
         


        }

    }
}
