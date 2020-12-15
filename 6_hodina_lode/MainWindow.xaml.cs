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

namespace _6_hodina_lode
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sirka = 10;
        int vyska = 10;

        int pocetLodi = 10;

        int[,] pole;

        int skore = 0;

        public MainWindow()
        {
            InitializeComponent();
            Random nahoda = new Random();

            for (int i = 0; i < sirka; i++)
            {
                mrizka.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < vyska; i++)
            {
                mrizka.RowDefinitions.Add(new RowDefinition());
            }

            for (int x = 0; x < sirka; x++)
            {
                for (int y = 0; y < vyska; y++)
                {
                    Button tlacitko = new Button();
                    tlacitko.Background = Brushes.White;
                    tlacitko.SetValue(Grid.ColumnProperty, x);
                    tlacitko.SetValue(Grid.RowProperty, y);
                    tlacitko.Click += Tlacitko_Click;
                    mrizka.Children.Add(tlacitko);
                }
            }

            pole = new int[sirka, vyska];
            for (int i = 0; i < pocetLodi;)
            {
                int x = nahoda.Next(sirka);
                int y = nahoda.Next(vyska);

                if(pole[x, y] == 0)
                {
                    pole[x, y] = 1;
                    i++;
                }
            }
        }

        private void Tlacitko_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button tlacitko)
            {
                int x = (int)tlacitko.GetValue(Grid.ColumnProperty);
                int y = (int)tlacitko.GetValue(Grid.RowProperty);

                if (pole[x, y] == 1)
                {
                    tlacitko.Background = Brushes.Red;
                    skore = skore + 1;
                    this.Title = skore.ToString() + "/" + pocetLodi;
                }
                else
                {
                    tlacitko.Background = Brushes.LightBlue;
                }
                tlacitko.Click -= Tlacitko_Click;
            }
        }
    }
}
