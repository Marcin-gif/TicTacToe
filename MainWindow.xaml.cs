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
using System.ComponentModel;
using System.Reflection;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool turn = true;
        int countTurn = 0;
        int winnerXCount = 0;
        int winnerOCount = 0;
        Window1 w1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aboutGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Marcin Majchrzak");
        }

        private void exitGame_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender; 
            if(turn)
            {
                b.Content = "X";
            }else
            {
                b.Content = "O";
            }
            turn = !turn;
            b.IsEnabled = false ;
            countTurn++;
            checkForWinner();
        }
        private void checkForWinner()
        {
            bool thereIsAWinner = false;
            //horizontal checks
            if(A1.Content == A2.Content && A2.Content == A3.Content && !A1.IsEnabled)
            {
                thereIsAWinner = true;
            }
            else if (B1.Content == B2.Content && B2.Content == B3.Content && !B1.IsEnabled)
            {
                thereIsAWinner = true;
            }
            else if (C1.Content == C2.Content && C2.Content == C3.Content && !C1.IsEnabled)
            {
                thereIsAWinner = true;
            }

            //Vertical checks
            if (A1.Content == B1.Content && B1.Content == C1.Content && !A1.IsEnabled)
            {
                thereIsAWinner = true;
            }
            else if (A2.Content == B2.Content && B2.Content == C2.Content && !A2.IsEnabled)
            {
                thereIsAWinner = true;
            }
            else if (A3.Content == B3.Content && B3.Content == C3.Content && !A3.IsEnabled)
            {
                thereIsAWinner = true;
            }

            //diagonal checks
            if (A1.Content == B2.Content && B2.Content == C3.Content && !A1.IsEnabled)
            {
                thereIsAWinner = true;
            }
            else if (A3.Content == B2.Content && B2.Content == C1.Content && !C1.IsEnabled)
            {
                thereIsAWinner = true;
            }
            

            StringBuilder winner = new StringBuilder();
            if (thereIsAWinner)
            {
                disabledButtons();
                if(turn)
                {
                    winner.Append("O");
                    winnerOCount++;
                    
                }else {
                    winner.Append("X");
                    winnerXCount++;
                }
                w1 = new Window1(restartGame);
                MessageBox.Show(winner.ToString() + "wins!");
                w1.Show();
                xCounter.Content = winnerXCount.ToString();
                oCounter.Content = winnerOCount.ToString();

            }else
            {
                if(countTurn == 9)
                {
                    MessageBox.Show("draw");
                    w1 = new Window1(restartGame);
                    w1.Show();  
                }
            }
            
        }
        private void disabledButtons()
        {
            foreach (UIElement e in MyPanel.Children)
            {
                if(e is Button b)
                    b.IsEnabled = false;
            }
            
        }

        private void newGame_click(object sender, RoutedEventArgs e)
        {
            turn = true;
            countTurn = 0;

            foreach (UIElement f in MyPanel.Children)
            {
                if (f is Button b)
                {
                    b.IsEnabled = true;
                    b.Content = "";
                }
                
            }
        }
        private void restartGame()
        {
            turn = true;
            countTurn = 0;
            foreach (UIElement f in MyPanel.Children)
            {
                if (f is Button b)
                {
                    b.IsEnabled = true;
                    b.Content = "";
                }

            }
        }
    }
}