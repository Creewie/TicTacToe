using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[] btns = new Button[16];
        private TextBlock turn;
        private TextBlock scoreX;
        private TextBlock scoreO;
        private bool isPlayerTurn;
        public bool IsPlayerTurn { get => isPlayerTurn; set {
                isPlayerTurn = value;
                if (turn != null) turn.Text = value ? "Kolej: O" : "Kolej: X";
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            turn = (TextBlock)FindName("tura");
            scoreX = (TextBlock)FindName("wynikX");
            scoreO = (TextBlock)FindName("wynikO");
            InitializebtnArray();
            NewGame();
            check();
            //turn.Text = "Kolej: O";
        }
        private void NewGame()
        {
            IsPlayerTurn = true;
            ClearBtnArray();
        }
        private void ClearBtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Background = Brushes.AliceBlue;
                btns[i].Content = String.Empty;
            }
        }
        private void InitializebtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = (Button)FindName($"btn{i + 1}") as Button;
                btns[i].Background = Brushes.AliceBlue;
                btns[i].Content = "?";
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = IsPlayerTurn ? "O" : "X";
            button.Background = IsPlayerTurn ? Brushes.Coral : Brushes.MediumPurple;
            for (int i = 0; i < 1; i++)
            {
                if (btns[i].Content != "" && btns[i+1].Content != "" && btns[i+2].Content != "" && btns[i + 3].Content != "" && btns[i+4].Content != "" && btns[i + 5].Content != "" && btns[i+6].Content != "" && btns[i + 7].Content != "" && btns[i+8].Content != "" && btns[i + 9].Content != "" && btns[i+10].Content != "" && btns[i + 11].Content != "" && btns[i+12].Content != "" && btns[i + 13].Content != "" && btns[i+14].Content != "" && btns[i + 15].Content != "")
                {
                    MessageBox.Show("Remis");
                    NewGame();
                    break;
                }
            }

            check();
            IsPlayerTurn = !IsPlayerTurn;

            
        }
        int wynikXlicznik = 0;
        int wynikOlicznik = 0;
            
        public int WynikX
        {
            get => wynikXlicznik;
            set { wynikXlicznik = value; scoreX.Text = $"X: {wynikXlicznik}"; }
        }

        public int WynikO { get => wynikOlicznik; set { wynikOlicznik = value; scoreO.Text = $"O: {wynikOlicznik}"; } }

        private void check()
        {
            for (int row = 0; row <= btns.Length-4; row+=4)
            {
                if (btns[row].Content == "O" && btns[row+1].Content == "O" && btns[row+2].Content == "O" && btns[row+3].Content == "O")
                {
                    MessageBox.Show("Wygrywa O");
                    NewGame();
                    WynikO++;
                    break;
                }
                if (btns[row].Content == "X" && btns[row+1].Content == "X" && btns[row+2].Content == "X" && btns[row+3].Content == "X")
                {
                    MessageBox.Show("Wygrywa X");
                    NewGame();
                    WynikX++;
                    break;
                }
            }
            for (int column = 0; column < 4; column++)
            {
                if (btns[column].Content == "O" && btns[column + 4].Content == "O" && btns[column + 8].Content == "O" && btns[column + 12].Content == "O")
                {
                    MessageBox.Show("Wygrywa O");
                    NewGame();
                    WynikO++;
                    break;
                }
                if (btns[column].Content == "X" && btns[column + 4].Content == "X" && btns[column + 8].Content == "X" && btns[column + 12].Content == "X")
                {
                    MessageBox.Show("Wygrywa X");
                    NewGame();
                    WynikX++;
                    break;
                }
            }
            for (int slant = 0; slant < 1; slant++)
            {
                if (( btns[0].Content == "O" && btns[5].Content == "O" && btns[10].Content == "O" && btns[15].Content == "O") || (btns[3].Content == "O" && btns[6].Content == "O" && btns[9].Content == "O" && btns[12].Content == "O"))
                {
                    MessageBox.Show("Wygrywa O");
                    NewGame();
                    WynikO++;
                    break;
                }
                else if((btns[0].Content == "X" && btns[5].Content == "X" && btns[10].Content == "X" && btns[15].Content == "X") || (btns[3].Content == "X" && btns[6].Content == "X" && btns[9].Content == "X" && btns[12].Content == "X"))
                {
                    MessageBox.Show("Wygrywa X");
                    NewGame();
                    WynikX++;
                    break;
                }
            }

        }
    } 

}