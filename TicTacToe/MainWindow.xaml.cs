using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private bool isXTurn = true; 
        private int movesCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content != null)
                return;

            button.Content = isXTurn ? "X" : "O";
            movesCount++;
            if (CheckWin(out Button[] winningButtons))
            {
 
                foreach (var btn in winningButtons)
                {
                    btn.Background = System.Windows.Media.Brushes.Green;
                }

                MessageBox.Show($"{(isXTurn ? "X" : "O")} виграв!");
                return; 
            }
            if (movesCount == 9)
            {
                MessageBox.Show("Нічия!");
                ResetGame();
                return;
            }
            isXTurn = !isXTurn;
        }

        private bool CheckWin(out Button[] winningButtons)
        {
            Button[,] buttons = {
                { Button00, Button01, Button02 },
                { Button10, Button11, Button12 },
                { Button20, Button21, Button22 }
            };
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content != null &&
                    buttons[i, 0].Content == buttons[i, 1].Content &&
                    buttons[i, 1].Content == buttons[i, 2].Content)
                {
                    winningButtons = new Button[] { buttons[i, 0], buttons[i, 1], buttons[i, 2] };
                    return true;
                }
                if (buttons[0, i].Content != null &&
                    buttons[0, i].Content == buttons[1, i].Content &&
                    buttons[1, i].Content == buttons[2, i].Content)
                {
                    winningButtons = new Button[] { buttons[0, i], buttons[1, i], buttons[2, i] };
                    return true;
                }
            }

            if (buttons[0, 0].Content != null &&
                buttons[0, 0].Content == buttons[1, 1].Content &&
                buttons[1, 1].Content == buttons[2, 2].Content)
            {
                winningButtons = new Button[] { buttons[0, 0], buttons[1, 1], buttons[2, 2] };
                return true;
            }

            if (buttons[0, 2].Content != null &&
                buttons[0, 2].Content == buttons[1, 1].Content &&
                buttons[1, 1].Content == buttons[2, 0].Content)
            {
                winningButtons = new Button[] { buttons[0, 2], buttons[1, 1], buttons[2, 0] };
                return true;
            }

            winningButtons = null;
            return false;
        }

        private void ResetGame()
        {
            Button[,] buttons = {
                { Button00, Button01, Button02 },
                { Button10, Button11, Button12 },
                { Button20, Button21, Button22 }
            };

            foreach (Button button in buttons)
            {
                button.Content = null;
                button.Background = System.Windows.Media.Brushes.LightGray; 
            }

            isXTurn = true;
            movesCount = 0;
        }
    }
}