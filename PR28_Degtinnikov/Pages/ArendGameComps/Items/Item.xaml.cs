using PR28_Degtinnikov.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PR28_Degtinnikov.Pages.ArendGameComps.Items
{
    public partial class Item : UserControl
    {
        private Arenda_CompGames item;

        public Item(Arenda_CompGames item, Pages.ArendGameComps.Main main)
        {
            InitializeComponent();
            this.item = item;
            clientName.Text = item.FIOClients;
            Date.SelectedDate = item.dateTime.Date;
            time.Text = item.dateTime.ToString("HH:mm");
        }


        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ArendGameComps.Add(this.item));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                    item.Delete();
                    MessageBox.Show("Запись успешно удалена");

                    if (Parent is Panel parentPanel)
                    {
                        parentPanel.Children.Remove(this);
                    }
                    else if (Parent is ItemsControl itemsControl)
                    {
                        itemsControl.Items.Remove(this);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
    }
}