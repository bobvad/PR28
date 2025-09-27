using PR28_Degtinnikov.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PR28_Degtinnikov.Pages.ArendGameComps
{
    public partial class Add : Page
    {
        private Arenda_CompGames currentArenda;

        public Add(Arenda_CompGames arenda = null)
        {
            InitializeComponent();
            currentArenda = arenda;

            if (arenda != null)
            {
                Date.SelectedDate = arenda.dateTime.Date;
                Time.Text = arenda.dateTime.ToString("HH:mm");
                clientName.Text = arenda.FIOClients;
                bthAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clientName.Text))
                {
                    MessageBox.Show("Необходимо ввести ФИО клиента.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (Date.SelectedDate == null)
                {
                    MessageBox.Show("Укажите дату аренды.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Time.Text) || !TimeSpan.TryParse(Time.Text, out TimeSpan time))
                {
                    MessageBox.Show("Неверный формат времени. Используйте формат ЧЧ:мм.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DateTime fullDateTime = Date.SelectedDate.Value.Date + time;


                if (currentArenda == null)
                {
                    Arenda_CompGames newArenda = new Arenda_CompGames(
                        0,
                        fullDateTime,
                        clientName.Text.Trim()
                    );
                    newArenda.Add();
                    MessageBox.Show("Аренда успешно добавлена!", "Успех");
                }
                else
                {
                    currentArenda.dateTime = fullDateTime;
                    currentArenda.FIOClients = clientName.Text.Trim();
                    currentArenda.Update();
                    MessageBox.Show("Данные аренды успешно обновлены!", "Успех");
                }

                MainWindow.init.frame.Navigate(new Pages.ArendGameComps.Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ArendGameComps.Main());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.GlavPage.GlavPage());
        }
    }
}