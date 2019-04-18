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

namespace ChessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private static Game game;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void A8_Click(object sender, RoutedEventArgs e) => ClickActions("a8");
        private void A7_Click(object sender, RoutedEventArgs e) => ClickActions("a7");
        private void A6_Click(object sender, RoutedEventArgs e) => ClickActions("a6");
        private void A5_Click(object sender, RoutedEventArgs e) => ClickActions("a5");

        private static void ClickActions(string position)
        {
            if (game != null)
                game.ClickField(position);
        }

        
    }
}
