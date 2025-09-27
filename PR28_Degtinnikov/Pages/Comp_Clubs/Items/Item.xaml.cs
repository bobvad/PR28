using PR28_Degtinnikov.Classes;
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

namespace PR28_Degtinnikov.Pages.Comp_Clubs.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private Classes.Comp_Clubs item;

        public Item(Classes.Comp_Clubs item,Pages.Comp_Clubs.Main main)
        {
            InitializeComponent();
            this.item = item;
            name.Text = item.Name; 
            address.Text = item.Address; 
            workHours.Text = item.WorkHours.ToString("HH:mm"); 
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Comp_Clubs.Add(this.item));
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
