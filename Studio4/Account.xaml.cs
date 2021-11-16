using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
using System.Timers;

namespace Studio4
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            if (GlobalData.dark_mode == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
                Text.Foreground = Brushes.White;
                Text1.Foreground = Brushes.White;
                Text2.Foreground = Brushes.White;
                Text3.Foreground = Brushes.White;
                Text4.Foreground = Brushes.White;
                Tips.Foreground = Brushes.White;
                Darkmode.Foreground = Brushes.White;
                ExitBtn.Background = Brushes.White;
                Darkmode.IsChecked = true;
                CurrentEmail.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                NewEmail.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                NewPassword.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                CurrentPassword.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                CurrentEmail.Foreground = Brushes.White;
                NewEmail.Foreground = Brushes.White;
                NewPassword.Foreground = Brushes.White;
                CurrentPassword.Foreground = Brushes.White;
            }
            if(GlobalData.SetTips == true)
            {
                Tips.IsChecked = true;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBox.Show("Are you sure you want to delete all data?", "Delete all data", buttons, MessageBoxImage.Warning);


        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void logout_btn(object sender, RoutedEventArgs e)
        {
            GlobalData.dark_mode = false;
            GlobalData.SetTips = false;
            Login login_p = new Login();
            this.NavigationService.Navigate(login_p);

        }

        private void ExitSettings(object sender, RoutedEventArgs e)
        {
            MainPage main_p2 = new MainPage();
            this.NavigationService.Navigate(main_p2);
        }

        private void modifyAccount()
        {
            if (NewEmail.Text.Contains('@') && NewPassword.Password.Length > 0)
            {
                GlobalData.change_bool = true;
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save these changes?", "Save Changes", buttons);
                if(result == MessageBoxResult.Yes)
                {
                    removeOldInfo();
                    StreamWriter sw2 = new StreamWriter("Accounts.txt", true);
                    sw2.WriteLine(NewEmail.Text + ";" + NewPassword.Password);
                    sw2.Close();
                    GlobalData.username = NewEmail.Text;
                    WarningLabel.Foreground = new SolidColorBrush(Colors.Green);
                    WarningLabel.Content = "Changes Saved!";

                }
                else
                {
                    WarningLabel.Foreground = new SolidColorBrush(Colors.Green);
                    WarningLabel.Content = "No Changes Made";
                }

            }
            else
            {
                WarningLabel.Foreground = new SolidColorBrush(Colors.Red);
                WarningLabel.Content = "New email or password is invalid!";

            }
        }

        private void removeOldInfo()
        {
            String line;
            StreamReader sr3 = new StreamReader("Accounts.txt");
            StreamWriter rem2 = new StreamWriter("temp.txt");
            while (!sr3.EndOfStream)

            {
                line = sr3.ReadLine();
                if (line != (CurrentEmail.Text + ";" + CurrentPassword.Password))
                {
                    rem2.WriteLine(line);

                }

            }
            sr3.Close();
            rem2.Close();
            File.Delete("Accounts.txt");
            File.Move("temp.txt", "Accounts.txt");
        }


        private void save_changes(object sender, RoutedEventArgs e)
        {
            String line;
            StreamReader sr2 = new StreamReader("Accounts.txt");
            while (!sr2.EndOfStream)

            {
                line = sr2.ReadLine();
                if (line != (CurrentEmail.Text + ";" + CurrentPassword.Password) && GlobalData.change_bool == false)
                {
                    WarningLabel.Foreground = new SolidColorBrush(Colors.Red);
                    WarningLabel.Content = ("Current email or password is incorrect!");

                }
                else
                {
                    sr2.Close();
                    modifyAccount();
                    GlobalData.change_bool = false;
                    break;
                }

            }

            sr2.Close();

        }

        private void CurrentEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dark_mode_checked(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(18, 18, 18));
            Text.Foreground = Brushes.White;
            Text1.Foreground = Brushes.White;
            Text2.Foreground = Brushes.White;
            Text3.Foreground = Brushes.White;
            Text4.Foreground = Brushes.White;
            Tips.Foreground = Brushes.White;
            Darkmode.Foreground = Brushes.White;
            ExitBtn.Background = Brushes.White;
            GlobalData.dark_mode = true;
            WarningLabel.Foreground = Brushes.Green;
            WarningLabel.Content = "Dark mode has been set!";
            CurrentEmail.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
            NewEmail.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
            NewPassword.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
            CurrentPassword.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
            CurrentEmail.Foreground = Brushes.White;
            NewEmail.Foreground = Brushes.White;
            NewPassword.Foreground = Brushes.White ;
            CurrentPassword.Foreground = Brushes.White;
        }

        private void dark_mode_unchecked(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(197, 207, 229));
            Text.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Text1.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Text2.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Text3.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Text4.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Tips.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            Darkmode.Foreground = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            ExitBtn.Background = Brushes.Transparent;
            GlobalData.dark_mode = false;
            WarningLabel.Content = "";
            CurrentEmail.Background = Brushes.White;
            NewEmail.Background = Brushes.White;
            NewPassword.Background = Brushes.White;
            CurrentPassword.Background = Brushes.White;
            CurrentEmail.Foreground = Brushes.Black ;
            NewEmail.Foreground = Brushes.Black;
            NewPassword.Foreground = Brushes.Black;
            CurrentPassword.Foreground = Brushes.Black;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void tipsclickon(object sender, RoutedEventArgs e)
        {
            GlobalData.SetTips = true;
            WarningLabel.Foreground = Brushes.Green;
            WarningLabel.Content = "tips have been set!";
        }

        private void tipsclickoff(object sender, RoutedEventArgs e)
        {
            GlobalData.SetTips = false;
            WarningLabel.Content = "";
        }
    }
}
