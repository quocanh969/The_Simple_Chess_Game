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
using System.Windows.Shapes;
using DTO;
using BUS;

namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for MatchInfo.xaml
    /// </summary>
    public partial class MatchInfo : Window
    {
        private string ID;
        private int i;
        public MatchInfo(string id, int stage)
        {
            InitializeComponent();
            txblID.Text = id;
            ID = id;
            i = stage;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {// Xử lý sự kiện drag window
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiện ấn button CANCEL
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiến ấn button OK

            OKClicked();
        }

        private void OKClicked()
        {
            if (boxPass.Password.Count() == 0)
            {
                lblWrongAcc.Content = "Please enter password";
                lblWrongAcc.Visibility = Visibility.Visible;
                return;
            }

            MatchBUS bus = new MatchBUS();
            MatchDTO match = bus.LoadMatch(ID);
            if (boxPass.Password != match.password)
            {
                lblWrongAcc.Content =  "Wrong password";
                lblWrongAcc.Visibility = Visibility.Visible;
                return;
            }

            //da nhap dung password
            bus.deleteMatch(ID);

            GlobalItem.IDPlayer1 = match.player1;
            GlobalItem.IDPlayer2 = match.player2;
            GlobalItem.time1 = match.time1;
            GlobalItem.time2 = match.time2;
            GlobalItem.turn = match.turn;
            GlobalItem.chessboard = match.chessboard;
            GlobalItem.check = match.check;

            //cap nhat cac quan co da an
            GlobalItem.numOfWhitePawn = match.ate[0] - '0';
            GlobalItem.numOfBlackPawn = match.ate[1] - '0';
            GlobalItem.numOfWhiteBishop = match.ate[2] - '0';
            GlobalItem.numOfBlackBishop = match.ate[3] - '0';
            GlobalItem.numOfWhiteKnight = match.ate[4] - '0';
            GlobalItem.numOfBlackKnight = match.ate[5] - '0';
            GlobalItem.numOfWhiteCastle = match.ate[6] - '0';
            GlobalItem.numOfBlackCastle = match.ate[7] - '0';
            GlobalItem.numOfWhiteQueen = match.ate[8] - '0';
            GlobalItem.numOfBlackQueen = match.ate[9] - '0';
            GlobalItem.numOfWhiteKing = match.ate[10] - '0';
            GlobalItem.numOfBlackKing = match.ate[11] - '0';


            GlobalItem.main.UCPlayground.Visibility = Visibility.Visible;
            GlobalItem.main.UCPlayground.loadMatch();// Hàm tái khởi tạo CinemaSeats
           // GlobalItem.main.UCPlayground.itPlayTime(); // Bắt đầu thời gian đếm ngược
            // man hình load sẽ tắt -> màn hình này cũng tắt
            this.Owner.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xử lý khi  tắt màn hình
            GlobalItem.isAnyMatchInfo[i] = false;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi minimize
            this.WindowState = WindowState.Minimized;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {// Xử lý OK 
            if(e.Key == Key.Enter)
            {
                          OKClicked();
            }
        }
    }
}
