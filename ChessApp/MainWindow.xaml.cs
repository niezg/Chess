using ChessApp.Models.Chessboard;
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
            game = new Game(TypeOfGame.Chess);
        }

        

        private void A8_Click(object sender, RoutedEventArgs e) => ClickActions("a8");
        private void A7_Click(object sender, RoutedEventArgs e) => ClickActions("a7");
        private void A6_Click(object sender, RoutedEventArgs e) => ClickActions("a6");
        private void A5_Click(object sender, RoutedEventArgs e) => ClickActions("a5");
        private void A4_Click(object sender, RoutedEventArgs e) => ClickActions("a4");
        private void A3_Click(object sender, RoutedEventArgs e) => ClickActions("a3");
        private void A2_Click(object sender, RoutedEventArgs e) => ClickActions("a2");
        private void A1_Click(object sender, RoutedEventArgs e) => ClickActions("a1");
        private void B8_Click(object sender, RoutedEventArgs e) => ClickActions("b8");
        private void B7_Click(object sender, RoutedEventArgs e) => ClickActions("b7");
        private void B6_Click(object sender, RoutedEventArgs e) => ClickActions("b6");
        private void B5_Click(object sender, RoutedEventArgs e) => ClickActions("b5");
        private void B4_Click(object sender, RoutedEventArgs e) => ClickActions("b4");
        private void B3_Click(object sender, RoutedEventArgs e) => ClickActions("b3");
        private void B2_Click(object sender, RoutedEventArgs e) => ClickActions("b2");
        private void B1_Click(object sender, RoutedEventArgs e) => ClickActions("b1");
        private void C8_Click(object sender, RoutedEventArgs e) => ClickActions("c8");
        private void C7_Click(object sender, RoutedEventArgs e) => ClickActions("c7");
        private void C6_Click(object sender, RoutedEventArgs e) => ClickActions("c6");
        private void C5_Click(object sender, RoutedEventArgs e) => ClickActions("c5");
        private void C4_Click(object sender, RoutedEventArgs e) => ClickActions("c4");
        private void C3_Click(object sender, RoutedEventArgs e) => ClickActions("c3");
        private void C2_Click(object sender, RoutedEventArgs e) => ClickActions("c2");
        private void C1_Click(object sender, RoutedEventArgs e) => ClickActions("c1");
        private void D8_Click(object sender, RoutedEventArgs e) => ClickActions("d8");
        private void D7_Click(object sender, RoutedEventArgs e) => ClickActions("d7");
        private void D6_Click(object sender, RoutedEventArgs e) => ClickActions("d6");
        private void D5_Click(object sender, RoutedEventArgs e) => ClickActions("d5");
        private void D4_Click(object sender, RoutedEventArgs e) => ClickActions("d4");
        private void D3_Click(object sender, RoutedEventArgs e) => ClickActions("d3");
        private void D2_Click(object sender, RoutedEventArgs e) => ClickActions("d2");
        private void D1_Click(object sender, RoutedEventArgs e) => ClickActions("d1");
        private void E8_Click(object sender, RoutedEventArgs e) => ClickActions("e8");
        private void E7_Click(object sender, RoutedEventArgs e) => ClickActions("e7");
        private void E6_Click(object sender, RoutedEventArgs e) => ClickActions("e6");
        private void E5_Click(object sender, RoutedEventArgs e) => ClickActions("e5");
        private void E4_Click(object sender, RoutedEventArgs e) => ClickActions("e4");
        private void E3_Click(object sender, RoutedEventArgs e) => ClickActions("e3");
        private void E2_Click(object sender, RoutedEventArgs e) => ClickActions("e2");
        private void E1_Click(object sender, RoutedEventArgs e) => ClickActions("e1");
        private void F8_Click(object sender, RoutedEventArgs e) => ClickActions("f8");
        private void F7_Click(object sender, RoutedEventArgs e) => ClickActions("f7");
        private void F6_Click(object sender, RoutedEventArgs e) => ClickActions("f6");
        private void F5_Click(object sender, RoutedEventArgs e) => ClickActions("f5");
        private void F4_Click(object sender, RoutedEventArgs e) => ClickActions("f4");
        private void F3_Click(object sender, RoutedEventArgs e) => ClickActions("f3");
        private void F2_Click(object sender, RoutedEventArgs e) => ClickActions("f2");
        private void F1_Click(object sender, RoutedEventArgs e) => ClickActions("f1");
        private void G8_Click(object sender, RoutedEventArgs e) => ClickActions("g8");
        private void G7_Click(object sender, RoutedEventArgs e) => ClickActions("g7");
        private void G6_Click(object sender, RoutedEventArgs e) => ClickActions("g6");
        private void G5_Click(object sender, RoutedEventArgs e) => ClickActions("g5");
        private void G4_Click(object sender, RoutedEventArgs e) => ClickActions("g4");
        private void G3_Click(object sender, RoutedEventArgs e) => ClickActions("g3");
        private void G2_Click(object sender, RoutedEventArgs e) => ClickActions("g2");
        private void G1_Click(object sender, RoutedEventArgs e) => ClickActions("g1");
        private void H8_Click(object sender, RoutedEventArgs e) => ClickActions("h8");
        private void H7_Click(object sender, RoutedEventArgs e) => ClickActions("h7");
        private void H6_Click(object sender, RoutedEventArgs e) => ClickActions("h6");
        private void H5_Click(object sender, RoutedEventArgs e) => ClickActions("h5");
        private void H4_Click(object sender, RoutedEventArgs e) => ClickActions("h4");
        private void H3_Click(object sender, RoutedEventArgs e) => ClickActions("h3");
        private void H2_Click(object sender, RoutedEventArgs e) => ClickActions("h2");
        private void H1_Click(object sender, RoutedEventArgs e) => ClickActions("h1");

        private static void ClickActions(string position)
        {
            if (game != null)
                game.ClickField(new Position(position));
        }

        
    }
}
