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

namespace PR28_Degtinnikov.Pages.ArendGameComps
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<Classes.Arenda_CompGames> AllKinoteatrs = Arenda_CompGames.Select();
        Pages.ArendGameComps.Main main;
        public Main()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (Arenda_CompGames item in AllKinoteatrs)
            {
                parent.Children.Add(new Pages.ArendGameComps.Items.Item(item, main));
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ArendGameComps.Add());
        }
    }
}
