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

namespace Exo3_Calculatrice_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Un_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "1";
        }

        private void Deux_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "2";
        }

        private void Trois_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "3";
        }

        private void Quatre_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "4";
        }

        private void Cinq_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "6";
        }

        private void Sept_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "7";
        }

        private void Huit_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "8";
        }

        private void Neuf_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "9";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "0";
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "+";
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "/";
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "*";
        }

        private void Soustraction_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "-";
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "";
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            string tmp = "";
            for (int i = 0; i < result.Text.Length-1; i++)
            {
                tmp += result.Text[i];
            }
            result.Text = tmp;            
        }

        private void Total_Click(object sender, RoutedEventArgs e)
        {
            Calculatrice Calc = new Calculatrice();
            result.Text = Calc.Calcul(result.Text);
        }
    }
}
