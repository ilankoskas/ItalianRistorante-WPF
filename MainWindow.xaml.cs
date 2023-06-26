using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Commandes c = new Commandes();  
            c.Plats = new List<Plat>(); 

        }

      

        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
            AdminPlat adm = new AdminPlat();
            adm.Show();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
         
        
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
        
        }

    }
}
