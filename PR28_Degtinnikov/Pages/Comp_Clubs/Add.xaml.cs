using PR28_Degtinnikov.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PR28_Degtinnikov.Pages.Comp_Clubs
{
    public partial class Add : Page
    {
        private Classes.Comp_Clubs currentClub;

        public Add(Classes.Comp_Clubs club = null)
        {
            InitializeComponent();
            currentClub = club;

            if (club != null)
            {
                name.Text = club.Name;
                address.Text = club.Address;
                Time.Text = club.WorkHours.ToString("HH:mm");
                bthAdd.Content = "Изменить";
            }
        }
        private void AddRecord(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Необходимо ввести название клуба.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    name.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(address.Text))
                {
                    MessageBox.Show("Необходимо ввести адрес клуба.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    address.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(Time.Text) || !TimeSpan.TryParse(Time.Text, out TimeSpan workTime))
                {
                    MessageBox.Show("Неверный формат времени работы. Используйте формат ЧЧ:мм.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    Time.Focus();
                    return;
                }

                DateTime workHoursDateTime = DateTime.Now.Date + workTime;

                if (currentClub == null)
                {
                    Classes.Comp_Clubs newClub = new Classes.Comp_Clubs(
                        0,
                        name.Text.Trim(),
                        address.Text.Trim(),
                        workHoursDateTime 
                    );
                    newClub.Add();
                    MessageBox.Show("Компьютерный клуб успешно добавлен!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    currentClub.Name = name.Text.Trim();
                    currentClub.Address = address.Text.Trim();
                    currentClub.WorkHours = workHoursDateTime; 
                    currentClub.Update();
                    MessageBox.Show("Данные клуба успешно обновлены!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                MainWindow.init.frame.Navigate(new Pages.Comp_Clubs.Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Comp_Clubs.Main());
        }

        private void ForGlavPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.GlavPage.GlavPage());
        }
    }
}