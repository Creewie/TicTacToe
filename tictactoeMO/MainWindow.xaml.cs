using System;
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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string imie = "";
        private Button[] btns = new Button[16];
        private int Counter { get; set; }
        public bool IsPlayerTurn { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializebtnArray();
            NewGame();
            check();
        }
        private void NewGame()
        {
            IsPlayerTurn = true;
            Counter = 0;
            ClearBtnArray();
        }
        private void ClearBtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Background = Brushes.Tan;
                btns[i].Content = String.Empty;
            }
        }
        private void InitializebtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = (Button)FindName($"btn{i + 1}") as Button;
                btns[i].Background = Brushes.Tan;
                btns[i].Content = "?";
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = IsPlayerTurn ? "O" : "X";
            button.Background = IsPlayerTurn ? Brushes.Peru : Brushes.Plum;
            Counter++;
            if (Counter > 15)
            {
                MessageBox.Show("Koniec gry", "Koniec", MessageBoxButton.OK);
                NewGame();
                return;
            }
            
            
            check();
            IsPlayerTurn = !IsPlayerTurn;
        }
        private void check()
        {
            for (int row = 0; row <= btns.Length-4; row+=4)
            {
                if (btns[row].Content == "O" && btns[row+1].Content == "O" && btns[row+2].Content == "O" && btns[row+3].Content == "O")
                {
                    MessageBox.Show("Strike!");
                    NewGame();
                    break;
                }
                if (btns[row].Content == "X" && btns[row+1].Content == "X" && btns[row+2].Content == "X" && btns[row+3].Content == "X")
                {
                    MessageBox.Show("Strike!");
                    NewGame();
                    break;
                }
            }
            for (int column = 0; column < 4; column++)
            {
                if (btns[column].Content == "O" && btns[column + 4].Content == "O" && btns[column + 8].Content == "O" && btns[column + 12].Content == "O")
                {
                    MessageBox.Show("Strike Column!");
                    NewGame();
                    break;
                }
                if (btns[column].Content == "X" && btns[column + 4].Content == "X" && btns[column + 8].Content == "X" && btns[column + 12].Content == "X")
                {
                    MessageBox.Show("Strike Column!");
                    NewGame();
                    break;
                }
            }

        }
    } 

}