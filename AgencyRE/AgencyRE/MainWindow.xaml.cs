using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgencyRE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            updateRE();
        }
        public void updateRE() { 
            var r = App.ADB.RealEstates.Select(x => x.TypeREs.NameType + "\n"+x.Vcode+"\nКол-во комнат: "+x.QuaRooms+". Этаж:"+x.Flat+"\nАдрес и координаты: "+x.AddressRE+" "+x.coordinates).ToList();
            RealEstatesViews.ItemsSource = r;
        }
        private void MainLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (LogInGrid.Visibility == Visibility.Hidden)
            {
                LogInGrid.Visibility = Visibility.Visible;
            }
            else if (LogInGrid.Visibility == Visibility.Visible)
            {
                LogInGrid.Visibility = Visibility.Hidden;
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            NClass.UserType = 1;
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        private void LogInGrid_button_Click(object sender, RoutedEventArgs e)
        {
            string[] FIO = FIOText.Text.Split(' ');
            string surname = FIO[0];
            string name = FIO[1];
            string patronomic = FIO[2];


            var r = App.ADB.Realtors.Where(c => c.Surname == surname && c.Namee == name && c.Patronomic == patronomic).FirstOrDefault();
            if (r == null)
            {
                var w = App.ADB.Clients.Where(s => s.Surname == surname && s.Namee == name && s.Patronomic == patronomic).FirstOrDefault();
                if (w == null)
                {
                    MessageBox.Show("dsa");
                }
                else
                {
                    //клиент
                    MainLogIn.Visibility = Visibility.Hidden;
                    LogInGrid.Visibility = Visibility.Hidden;
                    UserGrid.Visibility = Visibility.Visible;
                    FIOLabel.Content = surname + " " + name + " " + patronomic + "\nКлиент";
                }
            }
            else
            {
                //риэлтор
                MainLogIn.Visibility = Visibility.Hidden;
                LogInGrid.Visibility = Visibility.Hidden;
                UserGrid.Visibility = Visibility.Visible;
                AddRealtorButton.Visibility = Visibility.Visible;
                REAdd.Visibility = Visibility.Visible;
                FIOLabel.Content = surname + " " + name + " " + patronomic+ "\nРиэлтор";
            }
        }

        private void AddRealtorButton_Click(object sender, RoutedEventArgs e)
        {
            NClass.UserType = 2;
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        private void REAdd_Click(object sender, RoutedEventArgs e)
        {
            NClass.UserType = 3;
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }
    }
}
