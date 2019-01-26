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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private int player;// Đánh dấu là player thứ mấy
        public Login(int p)
        {
            InitializeComponent();
            player = p;
            if(p == 1)
            {
                lblPlayer.Content = "PLAYER 1";
            }
            else
            {
                lblPlayer.Content = "PLAYER 2";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn nút Cancel
            if(player == 1)
            {// Kiểm tra xem người dùng có muốn tiếp tục đăng nhập không
                GlobalItem.isPlayer1LoingOK = false;
            }
            else
            {
                GlobalItem.isPlayer2LoingOK = false;
            }
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn nút OK

            OKClicked();
        }

        private void OKClicked()
        {
            UserBUS bus = new UserBUS();
            int result = bus.Login(txtUserName.Text, txtPassword.Password);
            if (result == 0)
            {
                lblWrongAcc.Content="Wrong password";
                lblWrongAcc.Visibility = Visibility.Visible;
                return;
            }
            else if (result == 2)
            {
                lblWrongAcc.Content = "ID is invalid";
                lblWrongAcc.Visibility = Visibility.Visible;
                return;
            }
            if (player != 1)
            {
                if (txtUserName.Text == GlobalItem.IDPlayer1)
                {
                    lblWrongAcc.Content = "Player 1 is logging this account";
                    lblWrongAcc.Visibility = Visibility.Visible;
                    return;
                }
            }

            // Login thanh cong


            // Kiểm tra tài k
            if (player == 1)
            {// Kiểm tra xem người dùng có muốn tiếp tục đăng nhập thành công không
                GlobalItem.isPlayer1LoingOK = true;
                GlobalItem.IDPlayer1 = txtUserName.Text;
            }
            else
            {
                GlobalItem.isPlayer2LoingOK = true;
                GlobalItem.IDPlayer2 = txtUserName.Text;
            }
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {// Xử lý nut enter
            if (e.Key == Key.Enter)
            {
                OKClicked();
            }
        }
    }
}
