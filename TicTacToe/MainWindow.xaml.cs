using System.Data.Common;
using System.Text;
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
using System.Windows.Threading;

namespace TicTacToe
{

    public partial class MainWindow : Window
    {
   
        private bool PlayerTurn = true;
        private string[,] board = new string[3, 3];
        private Random rnd = new Random();
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            Reset();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.5)
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Computer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button || button.Content != null){ return; }

            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            Move(button, row, column);

            PlayerTurn  = !PlayerTurn;

            if (CheckWin())
            {
                MessageBox.Show("Vyhrál jsi!");
                PlayerTurn = true;
                Reset();
                return;
            }

            if (CheckDraw())
            {
                MessageBox.Show("Remíza");
                PlayerTurn = true;
                Reset();
                return;
            }

            if (!PlayerTurn)
            {
                timer.Start();
            }
        }

        private void Move(Button button, int row, int column)
        {
            if (PlayerTurn)
            {
                board[row, column] = "X";
                button.Content = "X";
                button.Foreground = Brushes.WhiteSmoke;
            }
            else
            {
                board[row, column] = "O";
                button.Content = "O";
                button.Foreground = Brushes.WhiteSmoke;
            }
        }



        private void Computer()
        {

            List<Button> Empty = new List<Button>();

            foreach (object child in MainGrid.Children)
            {
                if (child is Button button && button.Content == null)
                {
                    Empty.Add(button);
                } 
            }

            if (Empty.Count > 0)
            {
                Button PcButton = Empty[rnd.Next(Empty.Count)];
                int row = Grid.GetRow(PcButton);
                int column = Grid.GetColumn(PcButton);
                Move(PcButton, row, column);

                PlayerTurn = !PlayerTurn;

                if (CheckWin())
                {
                    MessageBox.Show("Prohrál jsi!");
                    PlayerTurn = true;
                    Reset();
                }

                if (CheckDraw())
                {
                    MessageBox.Show("Remíza");
                    PlayerTurn = true;
                    Reset();
                }

                
            }
        }

        private void Reset()
        {
            board = new string[3, 3];
            PlayerTurn = true;

            foreach (object child in MainGrid.Children)
            {
                if (child is Button button)
                {
                    button.Content = null;
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(board[i, 0]) && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
                if (!string.IsNullOrEmpty(board[0, i]) && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }
            if (!string.IsNullOrEmpty(board[0, 0]) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (!string.IsNullOrEmpty(board[0, 2]) && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;
            

            return false;
        }

        private bool CheckDraw()
        {
            foreach (string value in board)
            {
                if (string.IsNullOrEmpty(value))
                    return false;
            }
            return true;
        }

    }
}
