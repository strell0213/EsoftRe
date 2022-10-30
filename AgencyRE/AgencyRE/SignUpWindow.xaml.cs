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
using System.Windows.Shapes;

namespace AgencyRE
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {

        public SignUpWindow()
        {
            InitializeComponent();
            if (NClass.UserType == 1 || NClass.UserType == 2)
            {
                RealtorsAndClientsGrid.Visibility = Visibility.Visible;
            }
            else if (NClass.UserType == 3) { 
                REGrid.Visibility = Visibility.Visible;
                var type = App.ADB.TypeREs.Select(x => x.NameType).ToList();
                TypeText.ItemsSource = type;
                QuaRoomsext.Items.Add("1");
                QuaRoomsext.Items.Add("2");
                QuaRoomsext.Items.Add("3");
                QuaRoomsext.Items.Add("4");
                QuaRoomsext.Items.Add("5");

                QuaFlatText.Items.Add("1");
                QuaFlatText.Items.Add("2");
                QuaFlatText.Items.Add("3");

                for (int i = 1; i <= 25; i++) {
                    FlatText.Items.Add(i.ToString());
                }
            }
        }

        private void LogInGrid_button_Click(object sender, RoutedEventArgs e)
        {
            if (NClass.UserType == 1)
            {

                int CountForDone = 0;
                //проверка имени
                if (NameText.Text != null)
                {
                    CountForDone++;
                }
                if (CountForDone == 1)
                {
                    Clients clients = new Clients()
                    {
                        Namee = NameText.Text,
                        Surname = SurnameText.Text,
                        Patronomic = PatronomicText.Text,
                        Age = 18,
                        PhoneNumber = PhoneText.Text,
                        Email = EmailText.Text
                    };
                    App.ADB.Clients.Add(clients);
                    App.ADB.SaveChanges();
                    MessageBox.Show("Успешно", "esoft", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    NClass.UserType = 0;
                }
                else
                {
                    MessageBox.Show("Не корректно введены данные", "esoft", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (NClass.UserType == 2)
            {
                int CountForDone = 0;
                //проверка имени
                if (NameText.Text != null)
                {
                    CountForDone++;
                }
                if (CountForDone == 1)
                {
                    Realtors realtors = new Realtors()
                    {
                        Namee = NameText.Text,
                        Surname = SurnameText.Text,
                        Patronomic = PatronomicText.Text
                    };
                    App.ADB.Realtors.Add(realtors);
                    App.ADB.SaveChanges();
                    MessageBox.Show("Успешно", "esoft", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    NClass.UserType = 0;
                }
                else
                {
                    MessageBox.Show("Не корректно введены данные", "esoft", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (NClass.UserType == 3) {
                int CountForDone = 0;
                //проверка имени
                if (VcodeText.Text != null)
                {
                    CountForDone++;
                }
                if (CountForDone == 1)
                {
                    RealEstates realEstates = new RealEstates()
                    {
                        Vcode = Convert.ToInt32(VcodeText.Text),
                        AddressRE = AddressText.Text,
                        TypeRE = Convert.ToInt32(TypeText.SelectedIndex + 1),
                        coordinates = "аа забыл",
                        QuaRooms = Convert.ToInt32(QuaRoomsext.SelectedItem.ToString()),
                        QuaFlats = Convert.ToInt32(QuaFlatText.SelectedItem.ToString()),
                        Flat = Convert.ToInt32(FlatText.SelectedItem.ToString()),
                        Squares = SqText.Text,
                        Price = Convert.ToInt32(PriceText.Text),
                    };
                    App.ADB.RealEstates.Add(realEstates);
                    App.ADB.SaveChanges();
                    MessageBox.Show("Успешно", "esoft", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    NClass.UserType = 0;
                }
                else
                {
                    MessageBox.Show("Не корректно введены данные", "esoft", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
