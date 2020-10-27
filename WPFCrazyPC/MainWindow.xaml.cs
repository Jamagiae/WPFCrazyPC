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
using System.Threading;
using System.Windows.Threading;

namespace WPFCrazyPC
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random _random = new Random();


        int playerScore = 0;
        public static int x = 20;
        public static int y = 20;
        public MainWindow()
        {
            InitializeComponent();

            Thread crazyMouseThread = new Thread(new ThreadStart(CrazyMouseThread));
            crazyMouseThread.Start();

        }



        
        public void CrazyMouseThread()
        {
            int moveX = 0;
            int moveY = 0;

            while (true)
            {

                moveX = _random.Next(x) - (x / 2);
                moveY = _random.Next(y) - (y / 2);

                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + moveX, System.Windows.Forms.Cursor.Position.Y + moveY);
                Thread.Sleep(50);
            }

            
         }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (start.Height <= 20)
            {
                MessageBox.Show("You Win!");
                Environment.Exit(0);

            }
            else
            {
                playerScore++;
                score.Text = playerScore.ToString();

                x = x + 2;
                y = y + 2;


                start.Height = start.Height - 5;
                start.Width = start.Width - 7;
            }
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private int increment = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;
            TimerLabel.Content = increment.ToString();
        }
    }
}
