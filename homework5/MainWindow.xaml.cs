using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool player1Turn = true;

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "It is player X's turn";
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        Dictionary<string, string> position = new Dictionary<string, string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            if (player1Turn == true)
            {
                clicked.Content = "X";
                player1Turn = false;
                position.Add(clicked.Tag.ToString(), "X");
                uxTurn.Text = "It is player O's turn";
            }
            else
            {
                clicked.Content = "O";
                position.Add(clicked.Tag.ToString(), "O");
                player1Turn = true;
                uxTurn.Text = "It is player X's turn";
            }
            clicked.IsEnabled = false;

            checkRowForWinner();
            checkColForWinner();
            checkDiagForWinner();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            position.Clear();
            foreach (Button button in uxGrid.Children)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            player1Turn = true;
            uxTurn.Text = "It is player X's turn";
        }

        private void checkRowForWinner()
        {
            //row 1
            if (position.ContainsKey("0,0") && position.ContainsKey("0,1") && position.ContainsKey("0,2"))
            {
                if (position["0,0"] == "X" && position["0,1"] == "X" && position["0,2"] == "X")
                {
                    uxTurn.Text="X is a winner";
                    disableGrid();
                }
                else if (position["0,0"] == "O" && position["0,1"] == "O" && position["0,2"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
            //row 2
            else if (position.ContainsKey("1,0") && position.ContainsKey("1,1") && position.ContainsKey("1,2"))
            {
                if (position["1,0"] == "X" && position["1,1"] == "X" && position["1,2"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["1,0"] == "O" && position["1,1"] == "O" && position["1,2"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
            //row 3
            else if (position.ContainsKey("2,0") && position.ContainsKey("2,1") && position.ContainsKey("2,2"))
            {
                if (position["2,0"] == "X" && position["2,1"] == "X" && position["2,2"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["2,0"] == "O" && position["2,1"] == "O" && position["2,2"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
        }

        private void checkColForWinner()
        {
            //col 1
            if (position.ContainsKey("0,0") && position.ContainsKey("1,0") && position.ContainsKey("2,0"))
            {
                if (position["0,0"] == "X" && position["1,0"] == "X" && position["2,0"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["0,0"] == "O" && position["1,0"] == "O" && position["2,0"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
            //col 2
            else if (position.ContainsKey("0,1") && position.ContainsKey("1,1") && position.ContainsKey("2,1"))
            {
                if (position["0,1"] == "X" && position["1,1"] == "X" && position["2,1"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["0,1"] == "O" && position["1,1"] == "O" && position["2,1"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
            //col 3
            else if (position.ContainsKey("0,2") && position.ContainsKey("1,2") && position.ContainsKey("2,2"))
            {
                if (position["0,2"] == "X" && position["1,2"] == "X" && position["2,2"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["0,2"] == "O" && position["1,2"] == "O" && position["2,2"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
        }

        private void checkDiagForWinner()
        {
            //left to right diag
            if (position.ContainsKey("0,0") && position.ContainsKey("1,1") && position.ContainsKey("2,2"))
            {
                if (position["0,0"] == "X" && position["1,1"] == "X" && position["2,2"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["0,0"] == "O" && position["1,1"] == "O" && position["2,2"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
            //right to left diag
            else if (position.ContainsKey("0,2") && position.ContainsKey("1,1") && position.ContainsKey("2,0"))
            {
                if (position["0,2"] == "X" && position["1,1"] == "X" && position["2,0"] == "X")
                {
                    uxTurn.Text = "X is a winner";
                    disableGrid();
                }
                else if (position["0,2"] == "O" && position["1,1"] == "O" && position["2,0"] == "O")
                {
                    uxTurn.Text = "O is a winner";
                    disableGrid();
                }
            }
        }

        private void disableGrid()
        {
            foreach (Button button in uxGrid.Children)
            {
                button.IsEnabled = false;
            }
        }
    }
}
