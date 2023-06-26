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

namespace Restaurant
{
    /// <summary>
    /// Logique d'interaction pour AdminPlat.xaml
    /// </summary>
    public partial class AdminPlat : Window
    {
        public AdminPlat()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (verifmdt(PWD.Text) == true)
            {
                gestionAdmin g = new gestionAdmin();
                g.Show();
            }
        }
        private bool verifmdt(string mdp)
        {
            return mdp == "ilan";
        }
    }
}
